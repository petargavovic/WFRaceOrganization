using Common.Domen;
using System;
using System.Collections.Generic;

namespace Server.SystemOperation
{
    public class GetUcinciSO : SystemOperationBase
    {
        private readonly string where;
        Converter<IEntity, Ucinak> converter = Ucinak.EntityToUcinak;
        public List<Ucinak> Result { get; set; }

        public GetUcinciSO(string where)
        {
            this.where = where;
        }
        protected override void ExecuteConcreteOperation()
        {
            Result = broker.GetAll(new Ucinak(), where).ConvertAll(converter);
        }
    }
}
