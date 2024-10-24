using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Server.SystemOperation
{
    public class SaveVozacSO : SystemOperationBase
    {
        private readonly Vozac vozac;

        public int Result { get; set; }

        public SaveVozacSO(Vozac vozac)
        {
            this.vozac = vozac;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.SaveEntity(vozac);
        }
        public override bool Conditions()
        {
            if (!string.IsNullOrEmpty(vozac.Ime) && !vozac.Ime.Any(char.IsDigit) && vozac.Ime.Length <= 32)
                if (!string.IsNullOrEmpty(vozac.Prezime) && !vozac.Prezime.Any(char.IsDigit) && vozac.Prezime.Length <= 32)
                    if (!string.IsNullOrEmpty(vozac.Drzava) && !vozac.Drzava.Any(char.IsDigit))
                        if (vozac.DatumRodjenja < DateTime.Today)
                            return true;
            return false;
        }
    }
}
