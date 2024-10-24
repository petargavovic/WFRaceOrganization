using DatabaseBroker;
using Common.Domen;
using System.Collections.Generic;
using Server.SystemOperation;
using System;

namespace Server
{
    public class Controller
    {
        public Broker broker;
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null) instance = new Controller();
                return instance;
            }
        }

        public Controller()
        {
            broker = new Broker();
        }


        public bool Login(string where)
        {
            LoginSO so = new LoginSO(where);
            so.ExecuteTemplate();
            return so.Result;
        }


        public List<Kategorija> GetKategorije()
        {
            GetKategorijeSO so = new GetKategorijeSO();
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Ucinak> GetUcinci(string where)
        {
            GetUcinciSO so = new GetUcinciSO(where);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<RangLista> GetRangListe(string where)
        {
            GetRangListeSO so = new GetRangListeSO(where);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Trka> GetTrke(string where)
        {
            GetTrkeSO so = new GetTrkeSO(where);
            so.ExecuteTemplate();
            return so.Result;
        }

        public List<Vozac> GetVozaci(string where)
        {
            GetVozaciSO so = new GetVozaciSO(where);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal object LoadVozac(Vozac vozac)
        {
            LoadVozacSO so = new LoadVozacSO(vozac);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal object LoadTrka(Trka trka)
        {
            LoadTrkaSO so = new LoadTrkaSO(trka);
            so.ExecuteTemplate();
            return so.Result;
        }

        internal object LoadRangLista(RangLista rl)
        {
            LoadRangListaSO so = new LoadRangListaSO(rl);
            so.ExecuteTemplate();
            return so.Result;
        }

        public void SaveRezultati(List<Ucinak> ucinci)
        {
            SaveRezultatiSO so = new SaveRezultatiSO(ucinci);
            so.ExecuteTemplate();
        }

        public int SaveTrka(Trka trka)
        {
            SaveTrkaSO so = new SaveTrkaSO(trka);
            so.ExecuteTemplate();
            return so.Result;
        }

        public int SaveVozac(Vozac vozac)
        {
            SaveVozacSO so = new SaveVozacSO(vozac);
            so.ExecuteTemplate();
            return so.Result;
        }
    }
}
