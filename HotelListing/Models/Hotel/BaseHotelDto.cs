using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Models.Hotel
{
    public abstract class BaseHotelDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double Rating { get; set; }

        //[ForeignKey(nameof(CountryId))]
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
