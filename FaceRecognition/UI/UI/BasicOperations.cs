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
        public static string SaveImage(Image image,ref  int index)
        {
            string savepath = Application.StartupPath + "\\Images\\face" + index + ".bmp";
            while (Form1.database.FindImagePath(savepath))//(File.Exists(savepath))
            {
                savepath = Application.StartupPath + "\\Images\\face" + ++index + ".bmp";
            }
            image.Save(savepath);
            return savepath;
        }

        public static string SaveImage(string path,ref int index)
        {
            Bitmap bmp = new Bitmap(path);
            return SaveImage(bmp, ref index);
        }

        public static void SaveImageinDataBase(string name, Image image,ref int index)
        {
            string newPath = SaveImage(image, ref index);
            SaveInDataBase(name, newPath);
        }

        public static void SaveInDataBase(string name, string path)
        {
            //TODO: Nermo Save in Database
        }

    }
}