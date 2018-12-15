using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JISdata;
using JISdata.DAO;

namespace JIScore
{
    public class StajFormModel
    {
        public Staj staj;
        public Adresa adresa;
        public string maj;
        public Collection<Kun> kone;
        public Collection<Zavody> zavodyStaj;
        public Collection<Soutez> newSouteze = new Collection<Soutez>();


        public StajFormModel(Staj staj)
        {
            this.staj = staj;
            adresa = AdresaTable.getInstance().getByID(staj.adresa);
            maj = OsobaTable.Select(staj.majitel).prijmeni + " " + OsobaTable.Select(staj.majitel).jmeno;
            kone = KunTable.Select(staj.sid);
            zavodyStaj = ZavodyTable.SelectAllFromStaj(staj.sid);

        }

        public void saveChanges(string telefon, string nazev, string ulice, string cp, string mesto)
        {
             staj.telefon = telefon;
             staj.nazev = nazev;
            Adresa adres = new Adresa
            {
                aid = -1,
                ulice = ulice,
                cislo_popisne = cp,
                mesto = mesto
            };
            adres.aid = AdresaTable.getInstance().findAddress(adres.ulice, adres.cislo_popisne, adres.mesto);

            if (adres.aid == -1) adres.aid = AdresaTable.getInstance().Insert(adres);
             staj.adresa = adres.aid;
            adresa = adres;

            StajTable.Update(staj);
        }
    }
}
