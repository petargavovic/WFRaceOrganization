using Common.Domen;
using System;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class GetKategorijeSO : SystemOperationBase
    {
        Converter<IEntity, Kategorija> converter = Kategorija.EntityToKategorija;
        public List<Kategorija> Result { get; set; }

        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Kategorija()).ConvertAll(converter);
        }
    }
}
