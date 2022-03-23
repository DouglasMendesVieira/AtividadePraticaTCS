using AtividadePraticaTCS.Models;
using System.Collections.Generic;

namespace AtividadePraticaTCS.Services
{
    public class StatusEventService
    {
        private readonly AtividadePraticaTCSContext _context;

        public StatusEventService(AtividadePraticaTCSContext context)
        {
            _context = context;
        }
    }
}
