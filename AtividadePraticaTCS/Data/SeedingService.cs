using AtividadePraticaTCS.Models;
using System.Linq;

namespace AtividadePraticaTCS.Data
{
    public class SeedingService
    {
        private AtividadePraticaTCSContext _context;
        public SeedingService(AtividadePraticaTCSContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Status.Any() ||
                _context.Machine.Any() ||
                _context.StatusEvent.Any())
            {
                return; //DB has been seeded
            }

            Status s1 = new Status(1, "1", "Status1");
            Status s2 = new Status(2, "2", "Status2");
            Status s3 = new Status(3, "3", "Status3");
            Status s4 = new Status(4, "4", "Status4");

            Machine m1 = new Machine(1, "Machine1", s1);
            Machine m2 = new Machine(2, "Machine2", s2);
            Machine m3 = new Machine(3, "Machine3", s3);
            Machine m4 = new Machine(4, "Machine4", s4);

            _context.Status.AddRange(s1, s2, s3, s4);
            _context.Machine.AddRange(m1, m2, m3, m4);

            _context.SaveChanges();
        }
    }
}
