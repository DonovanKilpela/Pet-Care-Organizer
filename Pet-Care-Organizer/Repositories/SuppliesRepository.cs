using Pet_Care_Organizer.Data;
using Pet_Care_Organizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pet_Care_Organizer.Repositories
{
    public class SuppliesRepository : ISuppliesRepository
    {
        private readonly ApplicationDbContext _context;
        public SuppliesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Supplies> GetAll() => _context.Supplies.ToList();

        public Supplies? GetById(int id) => _context.Supplies.Find(id);

        public void Add(Supplies supply)
        {
            _context.Supplies.Add(supply);
            _context.SaveChanges();
        }

        public bool Update(Supplies supply)
        {
            var existing = _context.Supplies.Find(supply.Id);
            if (existing == null) return false;
            existing.Name = supply.Name;
            existing.Quantity = supply.Quantity;
            existing.LowThreshold = supply.LowThreshold;
            existing.Notes = supply.Notes;
            existing.EstimatedUsagePerDay = supply.EstimatedUsagePerDay;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var supply = _context.Supplies.Find(id);
            if (supply == null) return false;
            _context.Supplies.Remove(supply);
            _context.SaveChanges();
            return true;
        }
    }
}
