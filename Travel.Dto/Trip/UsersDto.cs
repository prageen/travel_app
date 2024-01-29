using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel.Dto.Trip
{
    public class UsersDto
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
