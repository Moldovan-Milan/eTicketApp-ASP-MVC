using eTicketApp.Data.Base;
using eTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicketApp.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Movie>> SearchByNameAsync(string name) =>
            await _context.Movies.Where(x => x.Name.Contains(name)).
                Include(m => m.Cinema).OrderBy(m=>m.Name).ToListAsync();

        public async Task<IEnumerable<Movie>> GetAllOrderbyAsync() =>
            await _context.Movies.Include(m => m.Cinema)
                .OrderBy(m => m.Name).ToListAsync();
    }
}
