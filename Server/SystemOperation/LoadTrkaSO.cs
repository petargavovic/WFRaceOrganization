using Common.Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class LoadTrkaSO : SystemOperationBase
    {
        private readonly Trka trka;
        public List<IEntity> Result { get; set; }

        public LoadTrkaSO(Trka trka)
        {
            this.trka = trka;
        }
        protected override void ExecuteConcreteOperation()
        {
            Ucinak ucinak = new Ucinak();
            Result = broker.GetAll(ucinak, ucinak.Where(trka.Id, "Trka")).Prepend(broker.GetById(trka)).ToList();
        }
    }
}
