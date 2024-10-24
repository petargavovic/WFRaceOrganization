using Common.Domen;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class LoadRangListaSO : SystemOperationBase
    {
        private readonly RangLista rl;
        public List<IEntity> Result { get; set; }

        public LoadRangListaSO(RangLista rl)
        {
            this.rl = rl;
        }
        protected override void ExecuteConcreteOperation()
        {
            Plasman plasman = new Plasman();
            Result = broker.GetAll(plasman, plasman.Where(rl.Id, "RangLista")).Prepend(broker.GetById(rl)).ToList();
        }
    }
}
