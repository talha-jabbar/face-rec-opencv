using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;

namespace UI
{
    public class FaceRecognizer
    {
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, t;
        string name, names = null;
        string lbl3, lbl4;
        public ImageBox imageBoxFrameGrabber;//= new ImageBox();
        public PictureBox pictureBoxFrameGrabber;//= new ImageBox();
        EigenObjectRecognizer recognizer;

        public FaceRecognizer() 
        {
            // momken neshlaha ba3deen peace ya3ni
           // lbl3 = FacesN;
           // lbl4 = allNames;
          //  imageBoxFrameGrabber = icb;

            //Load haarcascades for face detection
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            ContTrain = 0;
            ////Load of previus trainned faces and labels for each image
            //TODO: Nermo 3awezeen ne2ra men el database hena
            // for each record in the database
             // trainingImages.Add(new Image<Gray, byte>(ImagePath));
             // labels.Add(PersonName);
            //foreach (var item in Form1.db.DatabaseDictionary) /// snaia .. enty shofty el run ?? bidrb error 3ashan 3aiz di :D
            //{
            //    foreach (string s in item.Value)
            //    {
            //        trainingImages.Add(new Image<Gray, byte>(s));
            //        labels.Add(item.Key);
            //        ContTrain++;
            //    }
            //}
            
            //if (Form1.database.Persons.Count>0)
           // UpdateRecognizer();
        }
       
        public void StartStreaming()
        {
            grabber = new Capture();
            grabber.QueryFrame();
            Application.Idle += new EventHandler(FrameGrabber);
            //All.Enabled = false;
        }

        public void StopStreaming()
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            grabber = null;
        }

        public void FrameGrabber(object sender, EventArgs e)
        {
            lbl3 = "0";
            lbl4 = "";
            NamePersons.Add("");

            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
               
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                    //UpdateRecognizer();
                    name = recognizer.Recognize(result);
                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                lbl3 = facesDetected[0].Length.ToString();

            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            pictureBoxFrameGrabber.Image = currentFrame.ToBitmap();
            lbl3 = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
        }

        public void FrameGrabberImage(string imgPath, PictureBox pcb)
        {
            lbl3 = "0";
            lbl4 = "";
            NamePersons.Add("");


            //Get the current frame form capture device
            currentFrame = new Image<Bgr, byte>(imgPath).Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            
            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);


                if (trainingImages.ToArray().Length != 0)
                {
                   // UpdateRecognizer();
                    name = recognizer.Recognize(result);

                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));

                }

                NamePersons[t - 1] = name;
                NamePersons.Add("");


                //Set the number of faces detected on the scene
                lbl3 = facesDetected[0].Length.ToString();

            }
            t = 0;

            //Names concatenation of persons recognized
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                names = names + NamePersons[nnn] + ", ";
            }
            //Show the faces procesed and recognized
            pcb.Image = currentFrame.ToBitmap();
            lbl3 = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();

        }

        public bool CatchFace(string label, PictureBox pcb)
        {
            try
            {
                //Trained face counter
                ContTrain = ContTrain + 1;

                //Get a gray frame from capture device
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

                //Face Detector
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));

                //Action for each element detected
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }

                //resize face detected image for force to compare the same size with the 
                //test image with cubic interpolation type method
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(label);

                //Show face added in gray scale
                pcb.Image = TrainedFace.ToBitmap();

                // SAVE FILE 
                int i = 0;
                string path = Application.StartupPath + "/Images/face" + i + ".bmp";
                while (File.Exists(path))
                {
                    path = Application.StartupPath + "/Images/face" + ++i + ".bmp";
                }
                TrainedFace.Save(path);

                // Add to DATABASE 
                //TODO: Nermo 3awezeen nesave fel el database hena


                UpdateRecognizer();
                MessageBox.Show(label + "´s face detected and added :)", "Training OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Enable the face detection first", "Training Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        void UpdateRecognizer()
        {
            //TermCriteria for face recognition with numbers of trained images like maxIteration
            MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

            //Eigen face recognizer
            recognizer = new EigenObjectRecognizer(
               trainingImages.ToArray(),
               labels.ToArray(),
               1000,
               ref termCrit);
        }

        public void AddImageFromFile(string inputpath, string label)
        {
            //Trained face counter
            ContTrain = ContTrain + 1;

            //Get a gray frame from capture device
            gray = new Image<Gray, byte>(inputpath);//.Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
            face,
            1.2,
            10,
            Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
            new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                TrainedFace = gray.Copy(f.rect).Convert<Gray, byte>();
                break;
            }

            //resize face detected image for force to compare the same size with the 
            //test image with cubic interpolation type method
            TrainedFace = TrainedFace.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            trainingImages.Add(TrainedFace);
            labels.Add(label);

            int i = 0;
            string savepath = Application.StartupPath + "/Images/face" + i + ".bmp";
            while (File.Exists(savepath))
            {
                savepath = Application.StartupPath + "/Images/face" + ++i + ".bmp";
            }
            TrainedFace.Save(savepath);

            // Add to DATABASE 
            //TODO: Nermo 3awezeen nesave fel el database hena

        }

        public void AddListFromFile(List<string> inputpaths, string label)
        {
            foreach (string  s  in inputpaths)
            {
                AddImageFromFile(s, label);
            }
        }

    }
}
