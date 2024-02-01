using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;
using System.Text;
using Travel.Api.Mapper;
using Travel.Bl.District;
using Travel.Bl.Driver_details;
using Travel.Bl.Location;
using Travel.Bl.Party;
using Travel.Bl.Register;
using Travel.Bl.Register_User;
using Travel.Bl.State;
using Travel.Bl.Trip;
using Travel.Bl.TripExpense;
using Travel.Bl.Vehicle;
using Travel.Bl.VehicleExpense;
using Travel.Bl.Users;
using Travel.Infrastructure;
using Travel.Repository.Interface;
using Travel.Repository.Repositories;

namespace Travel.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperUser());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
            services.AddControllers();
            services.AddDbContext<DataContext>(
             ob => ob.UseSqlServer(Configuration.GetConnectionString("tarvelDbContext"),
             sso => sso.MigrationsAssembly(
               Assembly.GetExecutingAssembly().GetName().Name)
            ));
            // Add authentication services
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Authority = "https://localhost:44396/";
            //        options.Audience = "myapi";
            //    });

   


            

            // Add authorization services
            services.AddAuthorization();
            services.AddCors();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRegisterBl, RegisterBl>();
            services.AddTransient<IVehicleMasterBl, VehicleMasterBl>();
            services.AddTransient<IPartyBl, PartyBl>();
            services.AddTransient<IDriverBl, DriverBl>();
            services.AddTransient<ITripTypeBl, TripTypeBl>();
            services.AddTransient<ITripExpenseBl, TripExpenseBl>();
            services.AddTransient<IVehicleExpenseBl, VehicleExpenseBl>();
            services.AddTransient<IStateBl, StateBl>();
            services.AddTransient<IDistrictBl, DistrictBl>();
            services.AddTransient<ILocationBl, LocationBl>();
            services.AddTransient<IUsersBl,UsersBl>();
            services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<DataContext>()
             .AddDefaultTokenProviders();
            // Adding Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });
            // For Identity
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //  .AddEntityFrameworkStores<DataContext>()
            //  .AddDefaultTokenProviders();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Travel.Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "Travel.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseDeveloperExceptionPage();

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseRouting();
            db.Database.EnsureCreated();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
