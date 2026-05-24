using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace sealHkthon.Repositories.MinhMN
{
    public class EventsThuanVctRepository : Base.GenericRepository<Entities.MinhMN.Models.EventsThuanVct>
    {
        public EventsThuanVctRepository()
        {
        }
        public EventsThuanVctRepository(DBContext.PRN222_HACKATHONContext context) => _context = context;
        //get all
        public async Task<List<Entities.MinhMN.Models.EventsThuanVct>> GetAllAsync()
        {
            return await _context.EventsThuanVcts.Include(c => c.RoundsThuanVcts).ToListAsync();
        }

        //get by id
        public async Task<Entities.MinhMN.Models.EventsThuanVct> GetByIdAsync(int id)
        {
            return await _context.EventsThuanVcts.Include(c => c.RoundsThuanVcts).FirstOrDefaultAsync(c => c.EventThuanVctid == id);
        }


        //seach
        public async Task<List<Entities.MinhMN.Models.EventsThuanVct>> SearchAsync(string eventName, string description)
        {
            return await _context.EventsThuanVcts.Include(c => c.RoundsThuanVcts)
                .Where(c => c.EventName.Contains(eventName)
                        && c.Description.Contains(description))
                .ToListAsync();
        }
    }
}
