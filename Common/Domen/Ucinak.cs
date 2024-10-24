using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Common.Domen
{
    [Serializable]
    public class Ucinak : IEntity
    {
        public int UcinakID {  get; set; }
        [DisplayName("Vozač")]
        public Vozac Vozac { get; set; }
        public Trka Trka { get; set; }
        [DisplayName("Startni broj")]
        public int StartnaPozicija { get; set; }
        public int Plasman { get; set; }
        public string Vremena { get; set; }

        public string TableName => "Ucinak";

        public string Values => $"'{Vozac.VozacID}', '{Trka.TrkaID}', '{StartnaPozicija}', '{Plasman}', '{Vremena}'";

        public string UpdateValues => $"VozacID = '{Vozac.VozacID}', TrkaID = '{Trka.TrkaID}', StartnaPozicija = '{StartnaPozicija}', Plasman = '{Plasman}', Vremena = '{Vremena}' WHERE ({Vozac.VozacID} = VozacID) AND ({Trka.TrkaID} = TrkaID)";

        public string OrderByParam => "Plasman";

        public string Id => UcinakID.ToString();

        public Status Status { get; set; } = Status.Unchanged;

        public string Select => "u.UcinakID uID, v.VozacID vID, u.VozacID uVID, t.TrkaID tID, u.TrkaID pTID, u.StartnaPozicija uSP, u.Plasman uP, u.Vremena uV, v.Ime vI, v.Prezime vP, t.Naziv tN";

        public string Join => "JOIN Vozac v ON (v.VozacID = u.VozacID) JOIN Trka t ON (t.TrkaID = u.TrkaID)";

        public string Where(string param1 = "", string param2 = "") => $"WHERE ({param1} = {param2.Substring(0, 1).ToLower()}.{param2}ID)";

        public static Ucinak EntityToUcinak(IEntity entity) => (Ucinak)entity;

        public static IEntity UcinakToEntity(Ucinak ucinak) => ucinak;

        public object GetProperty(string param)
        {
            Type myType = typeof(Ucinak);
            PropertyInfo myPropInfo = myType.GetProperty(param);
            return myPropInfo.GetValue(this, null);
        }

        public List<IEntity> GetReaderList(SqlDataReader reader, List<IEntity> list)
        {
            using (reader)
            {
                while (reader.Read())
                {
                    Ucinak ucinak = new Ucinak()
                    {
                        UcinakID = (int)reader["uID"],
                        Trka = new Trka()
                        {
                            TrkaID = (int)reader["tID"],
                            Naziv = (string)reader["tN"]
                        },
                        Vozac = new Vozac()
                        {
                            VozacID = (int)reader["vID"],
                            Ime = (string)reader["vI"],
                            Prezime = (string)reader["vP"]
                        },
                        StartnaPozicija = (int)reader["uSP"],
                        Plasman = (int)reader["uP"],
                        Vremena = (string)reader["uV"]
                    };
                    list.Add(ucinak);
                }
            }
            return list;
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
                        string paramString = param.ElementAt(i).ToString();
                        p.SetValue(this, (!int.TryParse(paramString, out _) ? param.ElementAt(i) : int.Parse(paramString)));
                        break;
                    }
                }
            }
        }

        public IEntity VratiPrazan()
        {
            return new Ucinak();
        }

        public int VratiVremeUSekundama()
        {
            int vreme = 0;
            int min, sek;
            string[] krugovi = Vremena.Split(';');
            foreach (string str in krugovi)
            {
                string[] minIsek = str.Split(':');
                if (int.TryParse(minIsek[0], out min) & int.TryParse(minIsek[1], out sek))
                    vreme += min * 60 + sek;
            }
            return vreme;
        }
    }
}
