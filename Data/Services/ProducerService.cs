using eTicketApp.Data.Base;
using eTicketApp.Models;

namespace eTicketApp.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context) { }
    }
}
