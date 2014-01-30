using System;
using System.IO.IsolatedStorage;
using System.Xml.Linq;
using GestionePeso.App.Model;
using GestionePeso.App.Utils;

namespace GestionePeso.App.Storage
{
    /// <summary>
    /// Classe che parsa il file user.xml
    /// </summary>
    static class UserXmlParser
    {
        private const string _rootNode = "user";
        private const string _username = "username";
        private const string _height = "height";
        private const string _gender = "gender";
        private const string _age = "age";

        internal static User ReadUser()
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!file.FileExists(Constants.UserFileName))
                {
                    return null;
                }

                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(
                    Constants.UserFileName, System.IO.FileMode.Open, file))
                {
                    XDocument doc = XDocument.Load(isoStream);
                    XElement root = doc.Element(_rootNode);
                    string username = root.Attribute(_username).Value;
                    int height = int.Parse(root.Attribute(_height).Value);
                    Gender sex = (Gender)Enum.Parse(typeof(Gender), root.Attribute(_gender).Value, true);
                    int age = int.Parse(root.Attribute(_age).Value);
                    return new User(username, age, sex, height);
                }
            }
        }

        internal static void SaveUser(User user)
        {
            //rimuovo il file
            RemoveUserFile();
            //preparazione doc
            XDocument doc = CreateXDocumentFromUser(user);
            //salvataggio nella IsolatedStorage
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream isoStream = new IsolatedStorageFileStream(
                    Constants.UserFileName, System.IO.FileMode.Create,file))
                {
                    doc.Save(isoStream);
                }
            }
        }

        private static XDocument CreateXDocumentFromUser(User u)
        {
            XDocument rval = new XDocument();
            XElement rootNode = new XElement(_rootNode);
            rootNode.Add(new XAttribute(_username, u.Username));
            rootNode.Add(new XAttribute(_height, u.Altezza));
            rootNode.Add(new XAttribute(_age, u.Age));
            rootNode.Add(new XAttribute(_gender, u.Gender));
            rval.Add(rootNode);
            return rval;
        }

        internal static void RemoveUserFile()
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            file.DeleteFile(Constants.UserFileName);
        }
    }
}
