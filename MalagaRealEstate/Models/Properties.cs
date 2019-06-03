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
        [Display(Name = "Titular")]
        public string Header { get; set; }

        [Display(Name = "Dirección")]
        public string Address { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Número de habitaciones")]
        public int? Rooms { get; set; }

        [Display(Name = "Número de baños")]
        public int? Bathrooms { get; set; }

        [Display(Name = "Número de planta")]
        public int? FloorNumber { get; set; }

        [Display(Name = "Metros cuadrados")]
        public int? SquareMeters { get; set; }

        [Display(Name = "Precio del dueño")]
        public int? OwnerPrice { get; set; }

        [Display(Name = "Garaje")]
        public bool Garaje { get; set; }

        [Display(Name = "Aire acondicionado")]
        public bool AirConditioning { get; set; }

        [Display(Name = "Ascensor")]
        public bool Elevator { get; set; }

        [Display(Name = "Patio")]
        public bool Exterior { get; set; }

        [Display(Name = "Jardín")]
        public bool Garden { get; set; }

        [Display(Name = "Piscina")]
        public bool SwimmingPool { get; set; }

        [Display(Name = "Terraza")]
        public bool Terrace { get; set; }

        [Display(Name = "Trastero")]
        public bool StorageRoom { get; set; }

        [Display(Name = "Foto")]
        public string Image { get; set; }       

        [Display(Name = "Tipo de propiedad")]
        public string PropType { get; set; }

        [Display(Name = "Estado de la propiedad")]
        public string PropState { get; set; }

        public DateTime? PostedDay { get; set; }
        public DateTime? Updated { get; set; }
        [Column(TypeName = "decimal(22,19)")]
        public decimal? Latitude { get; set; }
        [Column(TypeName = "decimal(22,19)")]
        public decimal? Longitude { get; set; }
        
    }
}
