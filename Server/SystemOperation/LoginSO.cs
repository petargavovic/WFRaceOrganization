using Common.Domen;
using System;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class LoginSO : SystemOperationBase
    {
        private readonly string where;
        Converter<IEntity, Korisnik> converter = Korisnik.EntityToKorisnik;
        public bool Result { get; set; }

        public LoginSO(string where)
        {
            this.where = where;
        }
        protected override void ExecuteConcreteOperation()
        {
            if (Conditions())
            {
                if (broker.GetAll(new Kategorija()).Count == 0)
                {
                    List<IEntity> kategorije = new List<IEntity>();
                    string[] oznake = { "S", "A", "B", "C", "D" };
                    foreach (string o in oznake)
                        kategorije.Add(new Kategorija { NazivKategorije = o });
                    broker.SaveEntities(kategorije);
                }
                Result = true;
            }
            else
                Result = false;
        }

        public override bool Conditions()
        {
            if (where != null)
                if (broker.GetAll(new Korisnik(), where).ConvertAll(converter).Count != 0)
                    return true;
            return false;
        }
    }
}
