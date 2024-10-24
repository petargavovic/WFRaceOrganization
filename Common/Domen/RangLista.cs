using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Common.Domen
{
    [Serializable]
    public class RangLista : IEntity
    {
        public int RangListaID { get; set; }
        public Kategorija Kategorija { get; set; }
        [DisplayName("Kraj sezone")]
        public DateTime KrajSezone { get; set; }

        private string DateTimeToString => $"{KrajSezone.Year}{KrajSezone.Month.ToString("D2")}{KrajSezone.Day.ToString("D2")}";

        public string TableName => "RangLista";

        public string Values => $"'{DateTimeToString}', '{Kategorija.Id}'";

        public string UpdateValues => $"KrajSezone = '{DateTimeToString}', KategorijaID = '{Kategorija.KategorijaID}' WHERE ({RangListaID} = RangListaID)";

        public string OrderByParam => "KrajSezone";

        public string Id => RangListaID.ToString();

        public Status Status { get; set; } = Status.Unchanged;

        public string Select => "r.RangListaID rid, r.KrajSezone rks, r.KategorijaID rkid, k.KategorijaID kkid, k.NazivKategorije knk";

        public string Join => "JOIN Kategorija k ON (r.KategorijaID = k.KategorijaID)";

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
                    for (int i = 0; i < kat.Length - 1; i++)
                        katerorije.Add(kat[i].Split('=')[1], kat[i].Split('=')[0]);
                    katerorije.TryGetValue(param2.ToUpper(), out kategorijaID);
                }
                else
                    kategorijaID = param2;
                if (by != "RangListaID")
                {
                    if (by == "KrajSezone")
                        return $"WHERE CONVERT(VARCHAR, KrajSezone, 104) LIKE '%{param2}%'";
                    else if (by == "Kategorija")
                        return $"WHERE r.KategorijaID LIKE '{kategorijaID}'";
                    return $"WHERE {by} LIKE '%{param2}%'";
                }
                else
                    return $"WHERE r.KategorijaID LIKE '{kategorijaID}' OR CONVERT(VARCHAR, KrajSezone, 104) LIKE '%{param2}%'";
            }
            return "";
        }

        public static RangLista EntityToRangLista(IEntity entity)
        {
            return (RangLista)entity;
        }

        public object GetProperty(string param)
        {
            Type myType = typeof(RangLista);
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
                        object par = param.ElementAt(i);
                        if (param.ElementAt(i).GetType() != typeof(DateTime))
                            p.SetValue(this, par);
                        else
                        {
                            DateTime date = (DateTime)par;
                            p.SetValue(this, new DateTime(date.Year, date.Month, date.Day));
                        }
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
                    RangLista rg = new RangLista()
                    {
                        RangListaID = (int)reader["rid"],
                        KrajSezone = Convert.ToDateTime(reader["rks"]),
                        Kategorija = new Kategorija()
                        {
                            KategorijaID = (int)reader["rkid"],
                            NazivKategorije = (string)reader["knk"]
                        }
                    };
                    list.Add(rg);
                }
            }
            return list;
        }

        public IEntity VratiPrazan()
        {
            return new RangLista();
        }
    }
}
