using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UI
{
    public class Database
    {
        private Dictionary<string, List<string>> databaseDictionary;

        public Database()
        {
            databaseDictionary = new Dictionary<string, List<string>>();
            deleltedImages = new List<string>();
        }

        public Dictionary<string, List<string>> DatabaseDictionary
        {
            get { return databaseDictionary; }
            set { databaseDictionary = value; }
        }

        public List<string> deleltedImages;

        public bool ReadFileToDictionary(string dataPath)
        {
            FileStream fs;
            try
            {
                fs = new FileStream(dataPath, FileMode.Open);
            }
            catch (Exception)
            {

                return false;
            }

            StreamReader sr = new StreamReader(fs);

            if (databaseDictionary != null)
            {
                databaseDictionary.Clear();
            }
            databaseDictionary = new Dictionary<string, List<string>>();

            string line;
            string[] data;

            line = sr.ReadLine();
            while (line != null)
            {
                data = line.Split(';');

                if (!databaseDictionary.ContainsKey(data[1]))
                {
                    databaseDictionary.Add(data[1], new List<string>());
                }
                databaseDictionary[data[1]].Add(data[0]);

                line = sr.ReadLine();

            }

            sr.Close();
            fs.Close();

            return true;
        }

        public bool WriteDictionaryToFile(string dataPath)
        {
            FileStream fs = new FileStream(dataPath, FileMode.Create);
            StreamWriter sr = new StreamWriter(fs);

            foreach (var item in databaseDictionary)
            {
                foreach (string path in databaseDictionary[item.Key])
                {
                    sr.WriteLine(path + ";" + item.Key);
                }
            }

            sr.Close();
            fs.Close();

            this.SaveImages(dataPath);
            this.DeleteTheDeleted(dataPath);
            return true;
        }

        public bool DeleteFromDictionary(string name)
        {
            if (databaseDictionary.ContainsKey(name))
            {
                databaseDictionary.Remove(name);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool EditDictionary(string name, string newName)
        {
            if (databaseDictionary.ContainsKey(name) && !databaseDictionary.ContainsKey(newName))
            {
                databaseDictionary.Add(newName, databaseDictionary[name]);
                databaseDictionary.Remove(name);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditDictionary(string name, List<string> images)
        {
            if (databaseDictionary.ContainsKey(name))
            {
                databaseDictionary[name].Clear();
                databaseDictionary[name] = images;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddToDictionary(string name, List<string> images)
        {
            if (!databaseDictionary.ContainsKey(name))
            {
                databaseDictionary.Add(name, images);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveImages(string dataPath)
        {
            string path = dataPath + "\\Images";//System.Windows.Forms.Application.StartupPath + "\\Images";
            string newpath;
            int i = 0;
            foreach (var item in DatabaseDictionary)
            {
                i = 0;
                foreach (string s in item.Value)
                {
                    if (s.Substring(0, path.Length) != path)
                    {
                        newpath = path + "\\" + item.Key + i++ + s.Split('.')[1];
                        while(File.Exists(newpath))
                        {
                            newpath = path + "\\" + item.Key + i++ + s.Split('.')[1];
                        }
                        File.Copy(s,newpath );
                    }
                }
            }
        }

        public void DeleteTheDeleted(string dataPath)
        {
            string fullPath = dataPath + "\\Images";//System.Windows.Forms.Application.StartupPath + "\\Images";
            foreach (string path in deleltedImages)
            {
                if (path.Substring(0, fullPath.Length) == fullPath)
                File.Delete(path);
            }
        }
    }
}
