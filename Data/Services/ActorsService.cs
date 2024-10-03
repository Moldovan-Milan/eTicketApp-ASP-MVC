using eTicketApp.Data.Base;
using eTicketApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicketApp.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }
}
