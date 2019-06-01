using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MalagaRealEstate.Models
{
    public class Properties
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Header { get; set; }

        public string Description { get; set; }
        public int? Rooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? FloorNumber { get; set; }
        public int? SquareMeters { get; set; }
        public int? OwnerPrice { get; set; }

        public bool? Garaje { get; set; }
        public bool? AirConditioning { get; set; }
        public bool? Elevator { get; set; }
        public bool? Exterior { get; set; }
        public bool? Garden { get; set; }
        public bool? SwimmingPool { get; set; }
        public bool? Terrace { get; set; }
        public bool? StorageRoom { get; set; }
        public string Image { get; set; }

        public DateTime? PostedDay { get; set; }
        public int? PropType { get; set; }
        public int? PropState { get; set; }
        [Column(TypeName = "decimal(22,19)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(22,19)")]
        public decimal? Longitude { get; set; }
        public DateTime? Updated { get; set; }
    }
}
