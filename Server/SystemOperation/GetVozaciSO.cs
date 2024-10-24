using Common.Domen;
using System;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class GetVozaciSO : SystemOperationBase
    {
        private readonly string where;
        Converter<IEntity, Vozac> converter = Vozac.EntityToVozac;
        public List<Vozac> Result { get; set; }

        public GetVozaciSO(string where)
        {
            this.where = where;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Vozac(), where).ConvertAll(converter);
        }
    }
}
