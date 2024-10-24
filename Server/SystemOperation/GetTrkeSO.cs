using Common.Domen;
using System;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class GetTrkeSO : SystemOperationBase
    {
        private readonly string where;
        Converter<IEntity, Trka> converter = Trka.EntityToTrka;
        public List<Trka> Result { get; set; }

        public GetTrkeSO(string where)
        {
            this.where = where;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Trka(), where).ConvertAll(converter);
        }
    }
}
