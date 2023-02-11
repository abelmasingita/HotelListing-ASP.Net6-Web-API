namespace HotelListing.Contracts
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllsync();

        Task<T> AddAsync(T entity);
        Task DeleteAsync(int? id);
        Task UpdateAsync(T entity);

        Task<bool> Exists(int id);

    }

}
