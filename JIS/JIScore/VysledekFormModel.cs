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
    public class VysledekFormModel
    {
        public Collection<Zavody> zavody;
        public Collection<Soutez> souteze;
        public int zid, cid;


        public VysledekFormModel(int sid)
        {
            zavody = ZavodyTable.SelectStaj(sid);
            souteze = SoutezTable.Select_zavod(zid);
        }

        public void reloadSouteze()
        {
            souteze = SoutezTable.Select_zavod(zid);
        }


        public void updateVysledek(Vysledek vysledek)
        {
            if(vysledek.vyloucen.HasValue && vysledek.vyloucen.Value == true)
            {
                vysledek.tr_body = null;
                vysledek.cas = null;
                
            }
            else
            {
                if (vysledek.chyby.HasValue)
                    vysledek.tr_body = vysledek.chyby.Value * 4; 
            }
            VysledekTable.Update(vysledek);
        }
    }
}
