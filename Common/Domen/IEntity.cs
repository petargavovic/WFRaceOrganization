using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    public interface IEntity
    {
        string TableName { get; }
        string Values { get; }
        string UpdateValues { get; }
        string OrderByParam { get; }
        string Id { get; }
        string Select { get; }
        string Join { get; }
        string Where(string param1 = "", string param2 = "");
        object GetProperty(string param);
        Status Status { get; set; }
        List<IEntity> GetReaderList(SqlDataReader reader, List<IEntity> list);
        void SetAll(List<object> param, List<string> paramNames);
        IEntity VratiPrazan();
    }
}
