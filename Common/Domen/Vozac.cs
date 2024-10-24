using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Common.Domen
{
    [Serializable]
    public class Vozac : IEntity, IComparable
    {
        public int VozacID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [DisplayName("Država")]
        public string Drzava { get; set; }
        [DisplayName("Datum rođenja")]
        public DateTime DatumRodjenja {  get; set; }

        public Status Status { get; set; } = Status.Unchanged;

        public override string ToString()
        {
            return $"{Ime + " " + Prezime}";
        }

        private string DateTimeToString => $"{DatumRodjenja.Year}{DatumRodjenja.Month.ToString("D2")}{DatumRodjenja.Day.ToString("D2")}";

        public string TableName => "Vozac";

        public string Values => $"N'{Ime}', N'{Prezime}', '{Drzava}', '{DateTimeToString}'";

        public string OrderByParam => "Ime";

        public string UpdateValues => $"Ime = N'{Ime}', Prezime = N'{Prezime}', Drzava = '{Drzava}', DatumRodjenja = '{DateTimeToString}' WHERE VozacID = {VozacID}";

        public string Id => VozacID.ToString();

        public string Select => "*";

        public string Join => "";

        public string Where(string param1 = "", string param2 = "")
        {
            if (param1.StartsWith("$"))
            {
                string by = param1.TrimStart('$');
                if (by != "Ime")
                {
                    if (by == "Prezime")
                        by = "(Ime + ' ' + Prezime)";
                    else if (by == "DatumRodjenja")
                        by = "CONVERT(VARCHAR, DatumRodjenja, 104)";
                    return $"WHERE {by} LIKE N'%{param2}%'";
                }
                else
                    return $"WHERE (Ime + ' ' + Prezime) LIKE N'%{param2}%' OR Drzava LIKE '%{param2}%' OR CONVERT(VARCHAR, DatumRodjenja, 104) LIKE '%{param2}%'"; 
            }
            return $"WHERE Ime = N'{param1}' AND Prezime = N'{param2}'";
        }

        public object GetProperty(string param)
        {
            Type myType = typeof(Vozac);
            PropertyInfo myPropInfo = myType.GetProperty(param);
            return myPropInfo.GetValue(this, null);
        }

        public void SetAll(List<object> param, List<string> paramNames)
        {
            PropertyInfo[] pis = GetType().GetProperties();
            for (int i = 0; i< param.Count; i++)
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
                    Vozac vozac = new Vozac()
                    {
                        VozacID = (int)reader["vozacid"],
                        Ime = (string)reader["ime"],
                        Prezime = (string)reader["prezime"],
                        Drzava = (string)reader["drzava"],
                        DatumRodjenja = Convert.ToDateTime(reader["datumrodjenja"])
                    };
                    list.Add(vozac);
                }
            }
            return list;
        }
        public static Vozac EntityToVozac(IEntity entity)
        {
            return (Vozac)entity;
        }

        public static IEntity VozacToEntity(Vozac vozac)
        {
            return (IEntity)vozac;
        }

        public IEntity VratiPrazan()
        {
            return new Vozac();
        }

        public int CompareTo(object obj)
        {
            return (Ime + Prezime).CompareTo(((Vozac)obj).Ime+ ((Vozac)obj).Prezime);
        }
    }
}
