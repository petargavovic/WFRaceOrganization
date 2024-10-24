using Common.Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Server.SystemOperation
{
    public class SaveTrkaSO : SystemOperationBase
    {
        private readonly Trka trka;

        public int Result { get; set; }

        public SaveTrkaSO(Trka trka)
        {
            this.trka = trka;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.SaveEntity(trka);
        }

        public override bool Conditions()
        {
            if (!string.IsNullOrEmpty(trka.Naziv) && trka.Naziv.Length <= 32)
                if (trka.BrojKrugova > 0)
                    if (trka.Kategorija != null && !string.IsNullOrEmpty(trka.Kategorija.ToString()) && !trka.Kategorija.ToString().Any(char.IsDigit))
                        return true;
            return false;
        }
    }
}
