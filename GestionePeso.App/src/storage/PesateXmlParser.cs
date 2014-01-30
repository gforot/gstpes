using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GestionePeso.App.Model;
using GestionePeso.App.Utils;

namespace GestionePeso.App.Storage
{
    static class PesateXmlParser
    {
        private const string _rootNode = "pesate";
        private const string _pesataNode = "pesata";
        private const string _dateAtt = "date";
        private const string _weightAtt = "weight";

        private static Pesata GetPesata(XElement pesataNode)
        {
            try
            {
                return new Pesata(DateTime.Parse(pesataNode.Attribute(_dateAtt).Value), float.Parse(pesataNode.Attribute(_weightAtt).Value));
            }
            catch
            {
                return null;
            }
        }

        private static XElement CreatePesata(Pesata pesata)
        {
            return new XElement(_pesataNode, new XAttribute(_dateAtt, pesata.Date),
                new XAttribute(_weightAtt, pesata.Weight));
        }

        internal static void SavePesate(IEnumerable<Pesata> pesate)
        {
            RemovePesateFile();

            //preparazione doc
            XDocument doc = CreateXDocumentFromPesate(pesate);

            //salvataggio nella IsolatedStorage
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(
                    Constants.PesateFileName, System.IO.FileMode.Create, file))
                {
                    doc.Save(isoStream);
                }
            }
        }

        private static XDocument CreateXDocumentFromPesate(IEnumerable<Pesata> pesate)
        {
            XDocument rval = new XDocument();
            XElement rootNode = new XElement(_rootNode);
            foreach (Pesata p in pesate)
            {
                rootNode.Add(CreatePesata(p));
            }
            rval.Add(rootNode);
            return rval;
        }

        internal static List<Pesata> ReadPesate()
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!file.FileExists(Constants.PesateFileName))
                {
                    return null;
                }

                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(
                    Constants.PesateFileName, System.IO.FileMode.Open, file))
                {
                    XDocument doc = XDocument.Load(isoStream);
                    XElement root = doc.Element(_rootNode);
                    IEnumerable<XElement> pesate = root.Elements(_pesataNode);
                    List<Pesata> rval = new List<Pesata>();

                    foreach (XElement xe in pesate)
                    {
                        Pesata p = GetPesata(xe);
                        if (p != null)
                        {
                            rval.Add(p);
                        }
                    }
                    return rval;
                }
            }
        }

        internal static void RemovePesateFile()
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            file.DeleteFile(Constants.PesateFileName);
        }
    }
}
