using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace Common.Domen
{
    [Serializable]
    public class Kategorija : IEntity, IComparable<Kategorija>
    {
        public int KategorijaID { get; set; }
        public string NazivKategorije { get; set; }

        public string TableName => "Kategorija";

        public string Values => $"'{NazivKategorije}'";

        public string UpdateValues => $"NazivKategorije = '{NazivKategorije}'";

        public string OrderByParam => "KategorijaID";

        public string Id => KategorijaID.ToString();

        public Status Status { get; set; } = Status.Unchanged;

        public string Select => throw new NotImplementedException();

        public string Join => throw new NotImplementedException();

        public string Where(string param1 = "", string param2 = "")
        {
            throw new NotImplementedException();
        }

        public static Kategorija EntityToKategorija(IEntity entity)
        {
            return (Kategorija)entity;
        }

        public int CompareTo(Kategorija other)
        {
            return NazivKategorije.CompareTo(other.NazivKategorije);
        }

        public object GetProperty(string param)
        {
            Type myType = typeof(Trka);
            PropertyInfo myPropInfo = myType.GetProperty(param);
            return myPropInfo.GetValue(this, null);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader, List<IEntity> list)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    Kategorija kategorija = new Kategorija()
                    {
                        KategorijaID = (int)reader["KategorijaID"],
                        NazivKategorije = (string)reader["NazivKategorije"]
                    };
                    list.Add(kategorija);
                }
            }
            return list;
        }

        public void SetAll(List<object> param, List<string> paramNames)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"{NazivKategorije}";
        }

        public IEntity VratiPrazan()
        {
            return new Kategorija();
        }
    }
}
