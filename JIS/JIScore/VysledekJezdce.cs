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
    public class VysledekJezdce
    {
        public String kun { get; private set; }
        public String obtiznost { get; private set; }
        public int tr_body { get; private set; }
        public String cas { get; private set; }
        public String vyloucen { get; private set; }

        
        public static Collection<VysledekJezdce> GetVysledkyJezdce(string id)
        {
            Collection<VysledekJezdce> vysledky = new Collection<VysledekJezdce>();
            Collection<Dvojice> dvojice = DvojiceTable.SelectJezdec(id);
            Collection<Vysledek> Vys;

            foreach (Dvojice dvoj in dvojice){
                Vys = VysledekTable.SelectDvojice(dvoj.did);
                    foreach (Vysledek v in Vys)

                {
                    if (v.vyloucen.HasValue)
                    {
                        if (v.vyloucen.Value)
                        {
                            vysledky.Add(new VysledekJezdce
                            {
                                kun = v.kun_name,
                                obtiznost = SoutezTable.Select(v.cid).obtiznost,
                                tr_body = 0,
                                cas = 0 + " sec",
                                vyloucen = "Ano"
                            });
                        }
                        else vysledky.Add(new VysledekJezdce
                        {
                            kun = v.kun_name,
                            obtiznost = SoutezTable.Select(v.cid).obtiznost,
                            tr_body = (v.tr_body.HasValue ? v.tr_body.Value : 0),
                            cas = (v.cas.HasValue ? v.cas.Value.TotalSeconds.ToString() : "0") + "sec",
                            vyloucen = "Ne"
                        });
                    }
                    else vysledky.Add(new VysledekJezdce
                    {
                        kun = v.kun_name,
                        obtiznost = SoutezTable.Select(v.cid).obtiznost,
                        tr_body = (v.tr_body.HasValue ? v.tr_body.Value : 0),
                        cas = (v.cas.HasValue ? v.cas.Value.TotalSeconds.ToString() : "0") + "sec" ,
                        vyloucen = "Ne"
                    });

                }

            }

            return vysledky;
        }

    }
}
