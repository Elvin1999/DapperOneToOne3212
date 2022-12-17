using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public int CapitalId { get; set; }
        public virtual Capital Capital { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
