using eTicketApp.Data.Base;
using eTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicketApp.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<IEnumerable<Movie>> SearchByNameAsync(string name);
        Task<IEnumerable<Movie>> GetAllOrderbyAsync();
    }
}
