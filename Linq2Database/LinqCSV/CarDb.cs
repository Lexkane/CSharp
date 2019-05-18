using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace LinqCSV
{
    public class CarDb:DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
