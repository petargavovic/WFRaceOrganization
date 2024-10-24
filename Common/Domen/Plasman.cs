using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Common.Domen
{
    [Serializable]
    public class Plasman : IEntity
    {
        public int PlasmanID { get; set; }
        [DisplayName("Vozač")]
        public Vozac Vozac { get; set; }
        public RangLista RangLista { get; set; }
        public string TableName => "Plasman";
        [DisplayName("Poeni")]
        public int BrojPoena { get; set; }

        public string Values => $"'{Vozac.Id}', '{RangLista.Id}', '{BrojPoena}'";

        public string UpdateValues => $"VozacID = '{Vozac.Id}', RangListaID = '{RangLista.Id}', BrojPoena = '{BrojPoena}' WHERE ({Vozac.VozacID} = VozacID) AND ({RangLista.RangListaID} = RangListaID)";

        public string OrderByParam => "BrojPoena";

        public string Id => PlasmanID.ToString();

        public Status Status { get; set; } = Status.Unchanged;

        public string Select => "p.PlasmanID pid, v.VozacID vid, p.VozacID pvid, v.Ime vi, v.Prezime vp, r.RangListaID rlid, p.RangListaID prlid, p.BrojPoena pbp";

        public string Join => "JOIN Vozac v ON (v.VozacID = p.VozacID) JOIN RangLista r ON (r.RangListaID = p.RangListaID)";

        public string Where(string param1 = "", string param2 = "")
        {
            if (!int.TryParse(param2, out _))
                return $"WHERE ({param1} = {param2.Substring(0, 1).ToLower()}.{param2}ID)";
            else
                return $"WHERE ({param1} = v.VozacID) AND ({param2} = p.RangListaID)";
        }

        public static Plasman EntityToPlasman(IEntity entity) => (Plasman)entity;

        public object GetProperty(string param)
        {
            Type myType = typeof(Plasman);
            PropertyInfo myPropInfo = myType.GetProperty(param);
            return myPropInfo.GetValue(this, null);
        }

        public void SetAll(List<object> param, List<string> paramNames)
        {
            PropertyInfo[] pis = GetType().GetProperties();
            for (int i = 0; i < param.Count; i++)
            {
                foreach (PropertyInfo p in pis)
                {
                    if (p.ToString().Split(' ')[1] == paramNames[i])
                    {
                        p.SetValue(this, param.ElementAt(i));
                        break;
                    }
                }
            }
        }

        public List<IEntity> GetReaderList(SqlDataReader reader, List<IEntity> list)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    Plasman p = new Plasman()
                    {
                        PlasmanID = (int)reader["pid"],
                        RangLista = new RangLista()
                        {
                            RangListaID = (int)reader["rlid"]
                        },
                        Vozac = new Vozac()
                        {
                            VozacID = (int)reader["pvid"],
                            Ime = (string)reader["vi"],
                            Prezime = (string)reader["vp"]
                        },
                        BrojPoena = (int)reader["pbp"]
                    };
                    list.Add(p);
                }
            }
            return list;
        }

        public IEntity VratiPrazan()
        {
            return new Plasman();
        }
    }
}
