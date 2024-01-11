using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Infrastructure;

namespace Travel.Dto
{
  public  class TripDto
    {
        [Key]
        public int TripId { get; set; }
       
        [ForeignKey("PartyId")]
        public PartyDto PartyIdentification { get; set; }
        
        [ForeignKey("VehicleId")]
        public VehicleDto VehicleIdentification { get; set; }

        public string TripOrigin { get; set; }

        public string Destination { get; set; }

        [ForeignKey("TripCategoryId")]
        public TripCategory TripType { get; set; }

        public DateTime TripStartDate { get; set; }

        public TimeSpan TripStartTime { get; set; }

        public DateTime TripEndDate { get; set; }

        public TimeSpan TripEndTime { get; set; }

        public string DestinationViewPoints { get; set; }

        public string PartyLocationRemarks { get; set; }

    }
}
