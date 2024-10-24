using Common.Communication;
using Common.Domen;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;

namespace Server.SystemOperation
{
    public class SaveRezultatiSO : SystemOperationBase
    {
        readonly List<Ucinak> ucinci;
        readonly Converter<Ucinak, IEntity> converter1 = Ucinak.UcinakToEntity;
        readonly Converter<IEntity, RangLista> converter2 = RangLista.EntityToRangLista;
        readonly Converter<IEntity, Plasman> converter3 = Plasman.EntityToPlasman;
        readonly int[] brojeviPoena = { 12, 10, 8, 5, 4, 3, 2, 1 };

        public SaveRezultatiSO(List<Ucinak> ucinci)
        {
            this.ucinci = ucinci;
        }
        protected override void ExecuteConcreteOperation()
        {
            bool zaCuvanje = true;
            List<Ucinak> zaDodavanje = new List<Ucinak>();
            Ucinak granicnik = null;
            List<Ucinak> ucinciPre = new List<Ucinak>();
            foreach (Ucinak u in ucinci)
            {
                if (zaCuvanje)
                {
                    if (u.UcinakID == -1)
                    {
                        zaCuvanje = false;
                        granicnik = u;
                        continue;
                    }
                    zaDodavanje.Add(u);
                }
                else
                    ucinciPre.Add(u);
            }

            broker.SaveEntities(zaDodavanje.ConvertAll(converter1));

            RangLista rl = new RangLista()
            {
                Kategorija = granicnik.Trka.Kategorija,
                KrajSezone = granicnik.Trka.DatumTrke,
                Status = Status.Added
            };
            List<RangLista> listaRangListi = broker.GetAll(rl, rl.Where("Kategorija", rl.Kategorija.KategorijaID.ToString())).ConvertAll(converter2);
            RangLista rl2 = null;
            bool hasSeason = false;
            foreach (RangLista rangLista in listaRangListi)
                if (rangLista.KrajSezone.Year == rl.KrajSezone.Year)
                {
                    hasSeason = true;
                    rl2 = rangLista;
                    rl.RangListaID = rangLista.RangListaID;
                }
            if (!hasSeason)
            {
                rl2 = rl;
                rl2.RangListaID = broker.SaveEntity(rl);
            }
            else
            {
                if (rl.KrajSezone > rl2.KrajSezone)
                {
                    rl.Status = Status.Modified;
                    broker.SaveEntity(rl);
                }
            }
            Plasman pl = new Plasman();
            List<Plasman> plasmani = broker.GetAll(pl, pl.Where(rl2.Id, "RangLista")).ConvertAll(converter3);
            int brojObrisanihPlasmana = 0;
            foreach (Ucinak ucinak in ucinci)
            {
                if (ucinak.Status != Status.Unchanged)
                {
                    Plasman p = new Plasman()
                    {
                        Vozac = ucinak.Vozac,
                        RangLista = rl2,
                        BrojPoena = brojeviPoena[ucinak.Plasman - 1],
                        Status = Status.Added
                    };
                    pl = plasmani.Find(x => x.Vozac.VozacID == p.Vozac.VozacID);
                    if (pl != null)
                    {
                        p = pl;
                        Ucinak ucinakStari = ucinciPre.Find(u => u.Vozac.VozacID == p.Vozac.VozacID);
                        if (ucinakStari != null)
                            p.BrojPoena -= brojeviPoena[ucinakStari.Plasman - 1];
                        p.Status = Status.Modified;
                        if (ucinak.Status != Status.Deleted)
                            p.BrojPoena += brojeviPoena[ucinak.Plasman - 1];
                        else
                            if (p.BrojPoena <= 0)
                        {
                            p.Status = Status.Deleted;
                            brojObrisanihPlasmana++;
                        }
                    }
                    broker.SaveEntity(p);
                }
            }
            if (plasmani.Count != 0 && brojObrisanihPlasmana == plasmani.Count)
            {
                rl2.Status = Status.Deleted;
                broker.SaveEntity(rl2);
            }
        }

        public override bool Conditions()
        {
            foreach (Ucinak ucinak in ucinci)
            {
                if (ucinak.UcinakID != -1)
                {
                    bool ispravno = false;
                    if (ucinak.Vozac != null)
                        if (ucinak.StartnaPozicija > 0 && ucinak.StartnaPozicija < 9)
                            if (ucinak.Plasman > 0 && ucinak.Plasman < 9)
                                if (ucinak.VratiVremeUSekundama() > 0)
                                    ispravno = true;
                    if (!ispravno)
                        return false;
                }
            }
            return true;
        }
    }
}
