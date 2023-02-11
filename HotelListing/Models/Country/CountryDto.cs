using HotelListing.Models.Hotel;

namespace HotelListing.Models.Country
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }


        public virtual List<HotelDto> Hotels { get; set; }
    }
}
