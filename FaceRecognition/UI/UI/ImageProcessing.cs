using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace UI
{
    public class ImageProcessing
    {
        public static Bitmap ImagePreProcessing(Bitmap image)
        {

            return HistogramEqualization(DoG(GammaCorrection(image, 0.2), 5, 3));
        }

        public static Bitmap GaussianFilter1D(Bitmap originalImage, float sigma)
        {
            Bitmap bmp = new Bitmap(originalImage.Width, originalImage.Height, PixelFormat.Format24bppRgb);

            BitmapData bmpOriginalD = originalImage.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpD = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int oldExtraBytes = bmpOriginalD.Stride - (bmp.Width * 3);
            int newExtraBytes = bmpD.Stride - (bmp.Width * 3);

            PHFastCpp.PHGaussian1DFilter((int)bmpOriginalD.Scan0, (int)bmpD.Scan0, bmp.Width, bmp.Height, oldExtraBytes, newExtraBytes, sigma);

            originalImage.UnlockBits(bmpOriginalD);
            bmp.UnlockBits(bmpD);

            return bmp;
        }

        public static Bitmap HistogramEqualization(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap bmpNew = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap bmpOld = image;


            unsafe
            {
                BitmapData bmpNewD = bmpNew.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                BitmapData bmpOldD = bmpOld.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int originalExtraBytes = bmpOldD.Stride - (width * 3);
                int originalHeight = height;
                int originalWidth = width;

                double[] redEqul = new double[256];
                double[] redHisto = new double[256];

                int i, j, originalPixelIndex;

                byte* pOriginal = (byte*)bmpOldD.Scan0;
                byte* pNew = (byte*)bmpNewD.Scan0;



                //fill arry histogram
                for (i = 0; i < originalHeight; i++)
                {
                    for (j = 0; j < originalWidth; j++)
                    {
                        originalPixelIndex = (i * originalWidth * 3) + (i * originalExtraBytes) + (j * 3);
                        redHisto[pOriginal[originalPixelIndex]]++;
                    }
                }

                redEqul[0] = redHisto[0];
                //for accumlated sum
                for (i = 1; i < 256; i++)
                {
                    redEqul[i] = redEqul[i - 1] + redHisto[i];
                }

                double largeRed = redEqul[255];
                //divided
                for (i = 0; i < 256; i++)
                {
                    redEqul[i] = redEqul[i] / largeRed;
                }

                //Multiply
                for (i = 0; i < 256; i++)
                {
                    redEqul[i] = redEqul[i] * 255; // maxValueR;
                }

                //round
                for (i = 0; i < 256; i++)
                {
                    redEqul[i] = Math.Floor(redEqul[i]);
                }

                byte value;
                //move in new buffer
                for (i = 0; i < originalHeight; i++)
                {
                    for (j = 0; j < originalWidth; j++)
                    {
                        originalPixelIndex = (i * originalWidth * 3) + (i * originalExtraBytes) + (j * 3);
                        value = (byte)(redEqul[pOriginal[originalPixelIndex]]);

                        pNew[originalPixelIndex] = value;
                        pNew[originalPixelIndex + 1] = value;
                        pNew[originalPixelIndex + 2] = value;
                    }
                }

                bmpNew.UnlockBits(bmpNewD);
                bmpOld.UnlockBits(bmpOldD);
                // TimeSpan diff = DateTime.Now - before;
                // MessageBox.Show(diff.TotalMilliseconds.ToString());
                //  newImage = Operations.ConvertBitmapToStructure(bmpNew);

            }
            return bmpNew;
        }

        public static Bitmap GammaCorrection(Bitmap image, double gammaValue)
        {
            int width = image.Width;
            int height = image.Height;
            double[,] tempR;
            Bitmap bmpOld = image;


            unsafe
            {

                BitmapData bmpOldD = bmpOld.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int originalExtraBytes = bmpOldD.Stride - (width * 3);
                int originalHeight = height;
                int originalWidth = width;
                int i, j, originalPixelIndex;
                byte* pOriginal = (byte*)bmpOldD.Scan0;
                tempR = new double[originalHeight, originalWidth];

                for (i = 0; i < originalHeight; i++)
                {
                    for (j = 0; j < originalWidth; j++)
                    {
                        originalPixelIndex = (i * originalWidth * 3) + (i * originalExtraBytes) + (j * 3);

                        tempR[i, j] = Math.Pow(pOriginal[originalPixelIndex], /* 1/ */ gammaValue);
                    }
                }

                bmpOld.UnlockBits(bmpOldD);

                return Normalizationbitmap(originalHeight, originalWidth, tempR);
            }
        }

        private static void GetMinMaxValues(int height, int width, double[,] tempR, ref double min, ref  double max)
        {
            double tempMaxR = 0;
            double tempMinR = 255;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tempMaxR = (tempR[i, j] > tempMaxR) ? tempR[i, j] : tempMaxR;
                    tempMinR = (tempR[i, j] < tempMinR) ? tempR[i, j] : tempMinR;
                }
            }

            min = tempMinR;
            max = tempMaxR;
        }

        public static Bitmap Normalizationbitmap(int height, int width, double[,] tempR)
        {
            double min = 0;
            double max = 0;

            GetMinMaxValues(height, width, tempR, ref  min, ref  max);
            if (min - max == 0)
            {
                return null;
            }
            Bitmap newimage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            int originalPixelIndex;
            unsafe
            {
                BitmapData bmpNewD = newimage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* pNew = (byte*)bmpNewD.Scan0;
                int newExtraBytes = bmpNewD.Stride - (width * 3);
                byte value;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        originalPixelIndex = (i * width * 3) + (i * newExtraBytes) + (j * 3);
                        value = Convert.ToByte(((tempR[i, j] - min) / (max - min)) * 255); ;

                        pNew[originalPixelIndex] = value;
                        pNew[originalPixelIndex + 1] = value;
                        pNew[originalPixelIndex + 2] = value;
                    }
                }
                newimage.UnlockBits(bmpNewD);
            }

            return newimage;
        }

        public static Bitmap DoG(Bitmap image, int mask1, int mask2/*float alpha1, float alpha2*/)
        {
            // Bitmap G1 = GaussianFilter1D(image, alpha1);
            // Bitmap G2 = GaussianFilter1D(image, alpha2);
             Bitmap G1 = LowPassFilter(image, 5);
             Bitmap G2 = LowPassFilter(image, 11);
            int width = image.Width;
            int height = image.Height;
            double[,] tempR;
            Bitmap bmpOld = image;

            unsafe
            {

                BitmapData bmpOldD = bmpOld.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData bmpG1 = G1.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData bmpG2 = G2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int originalExtraBytes = bmpOldD.Stride - (width * 3);
                int originalHeight = height;
                int originalWidth = width;
                int i, j, originalPixelIndex;
                byte* pOriginal = (byte*)bmpOldD.Scan0;
                byte* pG1 = (byte*)bmpG1.Scan0;
                byte* pG2 = (byte*)bmpG2.Scan0;
                tempR = new double[originalHeight, originalWidth];

                for (i = 0; i < originalHeight; i++)
                {
                    for (j = 0; j < originalWidth; j++)
                    {
                        originalPixelIndex = (i * originalWidth * 3) + (i * originalExtraBytes) + (j * 3);

                        tempR[i, j] = (pG1[originalPixelIndex] - pG2[originalPixelIndex]);// *pOriginal[originalPixelIndex]; // Not sure of this part (* pOriginal[originalPixelIndex]).
                    }
                }

                bmpOld.UnlockBits(bmpOldD);

                return Normalizationbitmap(originalHeight, originalWidth, tempR);
            }
        }

        public static Bitmap DoG3(Bitmap image, float alpha1, float alpha2)
        {
            Bitmap G1 = GaussianFilter1D(image, alpha1);
            Bitmap G2 = GaussianFilter1D(image, alpha2);
            int width = image.Width;
            int height = image.Height;
            double[,] tempR, tempG, tempB;
            Bitmap bmpOld = image;

            unsafe
            {

                BitmapData bmpOldD = bmpOld.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData bmpG1 = G1.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData bmpG2 = G2.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int originalExtraBytes = bmpOldD.Stride - (width * 3);
                int originalHeight = height;
                int originalWidth = width;
                int i, j, originalPixelIndex;
                byte* pOriginal = (byte*)bmpOldD.Scan0;
                byte* pG1 = (byte*)bmpG1.Scan0;
                byte* pG2 = (byte*)bmpG2.Scan0;
                tempR = new double[originalHeight, originalWidth];
                tempG = new double[originalHeight, originalWidth];
                tempB = new double[originalHeight, originalWidth];
                double value;
                for (i = 0; i < originalHeight; i++)
                {
                    for (j = 0; j < originalWidth; j++)
                    {
                        originalPixelIndex = (i * originalWidth * 3) + (i * originalExtraBytes) + (j * 3);
                        tempR[i, j] = (pG1[originalPixelIndex] - pG2[originalPixelIndex]) * pOriginal[originalPixelIndex]; // Not sure of this part (* pOriginal[originalPixelIndex]).
                        tempG[i, j] = (pG1[originalPixelIndex + 1] - pG2[originalPixelIndex + 1]) * pOriginal[originalPixelIndex + 1]; // Not sure of this part (* pOriginal[originalPixelIndex]).
                        tempB[i, j] = (pG1[originalPixelIndex + 2] - pG2[originalPixelIndex + 2]) * pOriginal[originalPixelIndex + 2]; // Not sure of this part (* pOriginal[originalPixelIndex]).
                        value = (tempR[i, j] + tempG[i, j] + tempB[i, j]) / 3;
                        tempR[i, j] = value;
                        tempG[i, j] = value;
                        tempB[i, j] = value;
                    }
                }

                bmpOld.UnlockBits(bmpOldD);

                return Normalizationbitmap3(originalHeight, originalWidth, tempR, tempG, tempB);
            }
        }

        private static void GetMinMaxValues3(int height, int width, double[,] tempR, double[,] tempG, double[,] tempB, double[] min, double[] max)
        {
            double tempMaxR = 0;
            double tempMaxG = 0;
            double tempMaxB = 0;

            double tempMinR = 255;
            double tempMinG = 255;
            double tempMinB = 255;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tempMaxR = (tempR[i, j] > tempMaxR) ? tempR[i, j] : tempMaxR;
                    tempMaxG = (tempG[i, j] > tempMaxG) ? tempG[i, j] : tempMaxG;
                    tempMaxB = (tempB[i, j] > tempMaxB) ? tempB[i, j] : tempMaxB;

                    tempMinR = (tempR[i, j] < tempMinR) ? tempR[i, j] : tempMinR;
                    tempMinG = (tempG[i, j] < tempMinG) ? tempG[i, j] : tempMinG;
                    tempMinB = (tempB[i, j] < tempMinB) ? tempB[i, j] : tempMinB;
                }
            }

            min[0] = tempMinR;
            min[1] = tempMinG;
            min[2] = tempMinB;
            max[0] = tempMaxR;
            max[1] = tempMaxG;
            max[2] = tempMaxB;
        }

        public static Bitmap Normalizationbitmap3(int height, int width, double[,] tempR, double[,] tempG, double[,] tempB)
        {
            double[] min = new double[3];
            double[] max = new double[3];
            GetMinMaxValues3(height, width, tempR, tempG, tempB, min, max);
            Bitmap newimage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            int originalPixelIndex;
            unsafe
            {
                BitmapData bmpNewD = newimage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* pNew = (byte*)bmpNewD.Scan0;
                int newExtraBytes = bmpNewD.Stride - (width * 3);

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        originalPixelIndex = (i * width * 3) + (i * newExtraBytes) + (j * 3);
                        pNew[originalPixelIndex] = Convert.ToByte(((tempR[i, j] - min[0]) / (max[0] - min[0])) * 255);
                        pNew[originalPixelIndex + 1] = Convert.ToByte(((tempG[i, j] - min[1]) / (max[1] - min[1])) * 255);
                        pNew[originalPixelIndex + 2] = Convert.ToByte(((tempB[i, j] - min[2]) / (max[2] - min[2])) * 255);
                    }
                }
                newimage.UnlockBits(bmpNewD);
            }

            return newimage;
        }
       
        public static Bitmap LowPassFilter(Bitmap image, int maskSize)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap Lowpass = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap oldImage = image;
            int x, y, xSize = width, ySize = height;byte gray;
            int LowpassSize = maskSize; //insert an odd size: 3, 5, 7, ..., 29. 
            int MidWeight = 1; //set a positive mid weight: 1, 2, 3, ..., 1000. 
            int xx, yy, sum, d = LowpassSize / 2;
            float divisor = (2 * d + 1) * (2 * d + 1) + MidWeight - 1; //MidWeight == 1 means no weight 
            int originalPixelIndex;
            unsafe
            {
                BitmapData bmpNewD = Lowpass.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData bmpOldD = oldImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                byte* pNew = (byte*)bmpNewD.Scan0;
                byte* pOld = (byte*)bmpOldD.Scan0;
                int newExtraBytes = bmpNewD.Stride - (width * 3);

                for (y = d; y < ySize - d; y++)
                    for (x = d; x < xSize - d; x++)
                    {
                        originalPixelIndex = (y * width * 3) + (y * newExtraBytes) + (x * 3);
                        sum = (MidWeight - 1) * pOld[originalPixelIndex]; //extra mid weight 
                        for (yy = -d; yy <= d; yy++)
                            for (xx = -d; xx <= d; xx++)
                            {
                                originalPixelIndex = ((y + yy) * width * 3) + ((y + yy) * newExtraBytes) + ((x + xx) * 3);
                                sum += pOld[originalPixelIndex]; //grayarray.GetPixel(x + xx, y + yy).R;
                            }
                        gray = Convert.ToByte((float)sum / divisor);
                        originalPixelIndex = (y * width * 3) + (y * newExtraBytes) + (x * 3);
                        pNew[originalPixelIndex] = gray;
                        pNew[originalPixelIndex+1] = gray;
                        pNew[originalPixelIndex+2] = gray;
                    }
                Lowpass.UnlockBits(bmpNewD);
                oldImage.UnlockBits(bmpOldD);
            }              
                return Lowpass;
        }
    }
}