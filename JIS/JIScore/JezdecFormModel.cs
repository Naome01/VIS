using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JISdata;
using JISdata.DAO;
using JIScore;

namespace JIScore
{
    public class JezdecFormModel

    {
       public Collection<VysledekJezdce> vysledky;
       public  Jezdec jezdec;
       public Adresa adresa;
       public Osoba osoba;
       public List<Kun> kone;
       public Collection<Zavody> zavody;

        public JezdecFormModel(Jezdec jezdec)
        {
            this.jezdec = jezdec;
            this.osoba = OsobaTable.Select(jezdec.oid);
            adresa = AdresaTable.getInstance().getByID(osoba.adresa);

            zavody = ZavodyTable.SelectFuture(DateTime.Now);
            vysledky = VysledekJezdce.GetVysledkyJezdce(jezdec.cislo_licence);

            if (jezdec.licence.HasValue && !jezdec.licence.Value)
            {
                return;
            }
            kone = KunTable.Select().ToList();
            kone = kone.Where(k => k.licence.HasValue && k.licence.Value).ToList();


        }

        public Collection<Soutez> getSouteze(int zavodID)
        {
            return SoutezTable.Select_zavod(zavodID);
        }

        public void PrihlasDvojici(int zid, int cid, string kun, string cislo_licence)
        {
            int did = DvojiceTable.Select(kun, cislo_licence);

            if(did == -1)
            {
                did = DvojiceTable.Insert(new Dvojice { kun = kun, jezdec = cislo_licence });
            }

            Dvojice dvojice = DvojiceTable.Select(did);
            VysledekTable.Prihlas( dvojice, SoutezTable.Select(cid));
            vysledky = VysledekJezdce.GetVysledkyJezdce(jezdec.cislo_licence);
        }
    }
}
