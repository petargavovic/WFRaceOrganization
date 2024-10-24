using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.SystemOperation
{
    public class GetRangListeSO : SystemOperationBase
    {
        private readonly string where;
        Converter<IEntity, RangLista> converter = RangLista.EntityToRangLista;
        public List<RangLista> Result { get; set; }

        public GetRangListeSO(string where)
        {
            this.where = where;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new RangLista(), where).ConvertAll(converter);
        }
    }
}
