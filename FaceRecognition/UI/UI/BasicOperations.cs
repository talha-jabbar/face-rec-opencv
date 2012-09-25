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
    }
}
