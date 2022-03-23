using AtividadePraticaTCS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AtividadePraticaTCS.Services
{
    public class StatusService
    {
        private readonly AtividadePraticaTCSContext _context;

        public StatusService(AtividadePraticaTCSContext context)
        {
            _context = context;
        }
        public async Task<List<Status>> FindAllAsync()
        {
            return await _context.Status.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
