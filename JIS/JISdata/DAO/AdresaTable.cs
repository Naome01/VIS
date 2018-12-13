using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JISdata.DAO
{
    public class AdresaTable
    {
        private String DOCUMENT_NAME = "adresy.xml";
        private String START_TAG = "adresy";
        private String FIRST_TAG = "adresa";
        private String ID_VALUE = "id";

        private String TAG_ULICE = "ulice";
        private String TAG_MESTO = "mesto";
        private String TAG_CP = "cislo_popisne";

        List<Adresa> adresy;

        private AdresaTable()
        {
            adresy = loadAdresses();
        }

        private static AdresaTable instance = null;

        public static AdresaTable getInstance()
        {
            if (instance == null)
                instance = new AdresaTable();
            return instance;
        }


        public void Insert(Adresa adresa)
        {     
            
            adresy.Add(adresa);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter xw = XmlWriter.Create(@DOCUMENT_NAME, settings);

            xw.WriteStartDocument(); // hlavička
            xw.WriteStartElement("adresy"); // otevření kořenového elementu uzivatele

            foreach (Adresa a in adresy) {
                xw.WriteStartElement(FIRST_TAG);
                xw.WriteAttributeString(ID_VALUE, a.aid.ToString());

                xw.WriteElementString(TAG_ULICE, a.ulice);

                xw.WriteElementString(TAG_MESTO, a.mesto);

                xw.WriteElementString(TAG_CP, a.cislo_popisne);

                xw.WriteEndElement();
            }
            xw.WriteEndElement(); // uzavření kořenového elementu
            xw.WriteEndDocument(); // konec dokument
            xw.Flush();
            xw.Dispose();

        }

        public List<Adresa> loadAdresses()
        {
            List<Adresa> adresy = new List<Adresa>();

            XmlReader xr = XmlReader.Create(@DOCUMENT_NAME);

            string element = "";
            int id = 0;
            String mesto = "";
            String ulice = "";
            String cislo = "";
            try
            {
                xr.Read();
            }
            catch (Exception e)
            {
                return adresy;
            }
            do
            {
                // načítáme element
                if (xr.NodeType == XmlNodeType.Element)
                {
                    element = xr.Name; // název aktuálního elementu
                    if (element == "adresa")
                    {
                        id = int.Parse(xr.GetAttribute("id"));
                    }
                }
                // načítáme hodnotu elementu
                else if (xr.NodeType == XmlNodeType.Text)
                {
                    if (element.Equals(TAG_MESTO))
                    { mesto = xr.Value; }
                    else if (element.Equals(TAG_ULICE))
                    { ulice = xr.Value; }
                    else if (element.Equals(TAG_CP))
                    { cislo = xr.Value; }

                }
                // načítáme ukončující element
                else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "adresa"))
                    adresy.Add(new Adresa
                    {
                        aid = id,
                        mesto = mesto,
                        ulice = ulice,
                        cislo_popisne = cislo
                    });

            } while (xr.Read());
            xr.Close();
            xr.Dispose();

            return adresy;
        }

        public List<Adresa> getAdresses()
        {
            return adresy;
        }

        public int getLastID()
        {
            if (adresy.Count == 0)
            {
                return -1;
            }
            int lastID = int.MinValue;
            foreach (Adresa a in adresy)
            {
                if (a.aid > lastID)
                {
                    lastID = a.aid;
                }
            }
            return lastID;
        }

        public Adresa getByID(int id)
        {
            Adresa adresa;
            try
            {
               adresa = adresy.Single(s => s.aid == id);
            }
            catch(Exception e)
            {
                return (new Adresa{ aid = -1});
            }

            return adresa;
        }



    }

    
    
}
