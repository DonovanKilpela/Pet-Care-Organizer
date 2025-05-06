using Pet_Care_Organizer.Models;
using System.Collections.Generic;

namespace Pet_Care_Organizer.Repositories
{
    public interface IStatusRepository
    {
        List<Status> GetAll();
    }
}
