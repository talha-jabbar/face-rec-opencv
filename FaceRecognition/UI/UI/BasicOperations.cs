using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public class BasicOperations
    {
        public static string SaveImage(Image image)
        {
            int i = 0;
            string savepath = Application.StartupPath + "/Images/face" + i + ".bmp";
            while (File.Exists(savepath))
            {
                savepath = Application.StartupPath + "/Images/face" + ++i + ".bmp";
            }
            image.Save(savepath);
            return savepath;
        }

        public static string SaveImage(string path)
        {
            Bitmap bmp = new Bitmap(path);
            return SaveImage(bmp);
        }

        public static void SaveImageinDataBase(string name, Image image)
        {
            string newPath = SaveImage(image);
            SaveInDataBase(name, newPath);
        }

        public static void SaveInDataBase(string name, string path)
        {
            //TODO: Nermo Save in Database
        }

    }
}