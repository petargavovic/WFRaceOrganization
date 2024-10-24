using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domen
{
    [Serializable]
    public class Korisnik : IEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string TableName => "Korisnik";

        public string Values => throw new NotImplementedException();

        public string UpdateValues => throw new NotImplementedException();

        public string OrderByParam => "Username";

        public string Id => throw new NotImplementedException();

        public Status Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Select => "*";

        public string Join => "";

        public string Where(string param1 = "", string param2 = "") => $"WHERE Username COLLATE Latin1_General_BIN = N'{param1}' AND Password COLLATE Latin1_General_BIN = N'{param2}'";

        public object GetProperty(string param)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetReaderList(SqlDataReader reader, List<IEntity> list)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    Korisnik korisnik = new Korisnik()
                    {
                        Username = (string)reader["username"],
                        Password = (string)reader["password"]
                    };
                    list.Add(korisnik);
                }
            }
            return list;
        }

        public void SetAll(List<object> param, List<string> paramNames)
        {
            throw new NotImplementedException();
        }

        public IEntity VratiPrazan()
        {
            throw new NotImplementedException();
        }
        public static Korisnik EntityToKorisnik(IEntity entity)
        {
            return (Korisnik)entity;
        }
    }
}
