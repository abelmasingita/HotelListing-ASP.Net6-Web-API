using HotelListing.Contracts;
using HotelListing.Data;

namespace HotelListing.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly HotelListingDbContext _context;

        public HotelRepository(HotelListingDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
