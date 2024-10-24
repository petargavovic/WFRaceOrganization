using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Common.Domen
{
    [Serializable]
    public class Trka : IEntity, IComparable
    {
        public int TrkaID { get; set; }
        public string Naziv {  get; set; }
        public Kategorija Kategorija { get; set; }
        [DisplayName("Krugovi")]
        public int BrojKrugova { get; set; }
        [DisplayName("Datum trke")]
        public DateTime DatumTrke { get; set; }
        public string Staza { get; set; }

        public override string ToString()
        {
            return Naziv.ToString();
        }

        private string DateTimeToString => $"{DatumTrke.Year}{DatumTrke.Month.ToString("D2")}{DatumTrke.Day.ToString("D2")} {DatumTrke.Hour.ToString("D2")}:{DatumTrke.Minute.ToString("D2")}:{DatumTrke.Second.ToString("D2")}";

        public string TableName => "Trka";

        public string Values => $"N'{Naziv}', '{BrojKrugova}', '{DateTimeToString}', '{Kategorija.KategorijaID}', '{Staza}'";

        public string UpdateValues => $"Naziv = N'{Naziv}', BrojKrugova = '{BrojKrugova}', DatumTrke = '{DateTimeToString}', KategorijaID = '{Kategorija.KategorijaID}', Staza = '{Staza}' WHERE TrkaID = {TrkaID}";

        public string OrderByParam => "Naziv";

        public string Id => TrkaID.ToString();

        public Status Status { get; set; } = Status.Unchanged;

        public string Select => "t.TrkaID tID, t.Naziv tnaziv, t.DatumTrke tdt, t.KategorijaID tkid, t.BrojKrugova tbk, t.Staza tstaza, k.KategorijaID kkid, k.NazivKategorije knaziv";

        public string Join => "JOIN Kategorija k ON (t.KategorijaID = k.KategorijaID)";

        public string Where(string param1 = "", string param2 = "")
        {
            if (param1 != "")
            {
                string by = param1;
                string kategorijaID = "0";
                if (param1.Contains("$"))
                {
                    string[] split = param1.Split('$');
                    by = split[1];
                    string[] kat = split[0].Split(';');
                    Dictionary<string, string> katerorije = new Dictionary<string, string>();
                    for (int i = 0; i < kat.Length-1; i++)
                        katerorije.Add(kat[i].Split('=')[1], kat[i].Split('=')[0]);
                    katerorije.TryGetValue(param2.ToUpper(), out kategorijaID);
                }

                if (by != "TrkaID")
                {
                    if (by == "DatumTrke")
                        return $"WHERE CONVERT(VARCHAR, DatumTrke, 104) LIKE '%{param2}%'";
                    else if (by == "Kategorija")
                        return $"WHERE t.KategorijaID LIKE '{kategorijaID}'";
                    return $"WHERE {by} LIKE N'%{param2}%'";
                }
                else
                    return $"WHERE Naziv LIKE N'%{param2}%' OR t.KategorijaID LIKE '{kategorijaID}' OR BrojKrugova LIKE '%{param2}%' OR CONVERT(VARCHAR, DatumTrke, 104) LIKE '%{param2}%'";
            }
            return "";
        }

        public static Trka EntityToTrka(IEntity entity)
        {
            return (Trka)entity;
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
                    Trka trka = new Trka()
                    {
                        TrkaID = (int)reader["tid"],
                        Naziv = (string)reader["tnaziv"],
                        BrojKrugova = (int)reader["tbk"],
                        DatumTrke = (DateTime)reader["tdt"],
                        Kategorija = new Kategorija { KategorijaID = (int)reader["tkid"],
                        NazivKategorije = (string)reader["knaziv"],
                        },
                        Staza = (string)reader["tstaza"]
                    };
                    list.Add(trka);
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
                        p.SetValue(this, param.ElementAt(i));
                        break;
                    }
                }
            }
        }

        public IEntity VratiPrazan()
        {
            return new Trka();
        }

        public int CompareTo(object obj)
        {
            return Naziv.CompareTo(((Trka)obj).Naziv);
        }
    }
}
