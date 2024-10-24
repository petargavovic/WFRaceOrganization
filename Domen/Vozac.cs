using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Vozac
    {
        public int VozacID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Drzava { get; set; }
        public Status Status { get; set; } = Status.Unchanged;
    }
}
