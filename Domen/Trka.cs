using System;

namespace Domen
{
    public class Trka
    {
        public int TrkaID { get; set; }
        public int BrojKrugova { get; set; }
        public DateTime DatumTrke { get; set; }
        public Kategorija Kategorija { get; set; }
    }
}
