using Pet_Care_Organizer.Models;
using System.Collections.Generic;

namespace Pet_Care_Organizer.Repositories
{
    public interface ISuppliesRepository
    {
        List<Supplies> GetAll();
        Supplies? GetById(int id);
        void Add(Supplies supply);
        bool Update(Supplies supply);
        bool Delete(int id);
    }
}
