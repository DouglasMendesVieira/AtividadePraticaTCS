using AtividadePraticaTCS.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AtividadePraticaTCS.Services.Exceptions;
using System.Threading.Tasks;

namespace AtividadePraticaTCS.Services
{
    public class MachineService
    {
        private readonly AtividadePraticaTCSContext _context;

        public MachineService(AtividadePraticaTCSContext context)
        {
            _context = context;
        }
        public async Task<List<Machine>> FindAllAsync()
        {
            return await _context.Machine.Include(obj => obj.Status).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task InsertAsync(Machine obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Machine> FindByIdAsync(int id)
        {
            return await _context.Machine.Include(obj => obj.Status).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Machine.FindAsync(id);
            _context.Machine.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Machine obj)
        {
            bool hasAny = await _context.Machine.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
