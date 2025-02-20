using Emgu.CV;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV.Structure;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace WebcamHW
{
    public partial class Form1 : Form
    {
        private VideoCapture _capture;
        private Thread _captureThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // create the capture object and processing thread
            _capture = new VideoCapture(0);
            _captureThread = new Thread(DisplayWebcam);
            _captureThread.Start();
        }

        private void DisplayWebcam()
        {
            while (_capture.IsOpened)
            {
                // frame maintenance
                Mat frame = _capture.QueryFrame();

                // resize to PictureBox aspect ratio
                int newHeight = (frame.Size.Height * emguPictureBox.Size.Width) / frame.Size.Width;
                Size newSize = new Size(emguPictureBox.Size.Width, newHeight);
                CvInvoke.Resize(frame, frame, newSize);

                // display the image in the PictureBox
                emguPictureBox.Image = frame.ToBitmap();

                /* Your code for grayscaling and binary threshold-ing the image should go here */
                CvInvoke.CvtColor(frame, frame, ColorConversion.Bgr2Gray);
                CvInvoke.Threshold(frame, frame, 150, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                binaryPictureBox.Image = frame.ToBitmap();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // terminate the image processing thread to avoid orphaned processes
            _captureThread.Abort();
        }
    }
}