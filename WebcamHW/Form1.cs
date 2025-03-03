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
using System.Security.Cryptography;

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

                // filter out non white pixels and display it
                Mat binaryFrame = new Mat();
                CvInvoke.CvtColor(frame, binaryFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                Mat thresholdedImage = new Mat();
                CvInvoke.Threshold(binaryFrame, thresholdedImage, 200, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                binaryPictureBox.Image = thresholdedImage.ToBitmap();

                // create hsv
                Mat hsvFrame = new Mat();
                CvInvoke.CvtColor(frame, hsvFrame, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);

                // split hsv into hue, saturation, and value channels
                Mat[] hsvChannels = hsvFrame.Split();

                // min and max values for hue, saturation, and value of red
                int hMin = 0;
                int hMax = 5;
                int sMin = 70;
                int sMax = 255;
                int vMin = 50;
                int vMax = 255;

                // create filters for each
                Mat hueFilter = new Mat();
                CvInvoke.InRange(hsvChannels[0], new ScalarArray(hMin), new ScalarArray(hMax), hueFilter);

                Mat saturationFilter = new Mat();
                CvInvoke.InRange(hsvChannels[1], new ScalarArray(sMin), new ScalarArray(sMax), saturationFilter);

                Mat valueFilter = new Mat();
                CvInvoke.InRange(hsvChannels[2], new ScalarArray(vMin), new ScalarArray(vMax), valueFilter);

                // merge into one image and display
                Mat mergedImage = new Mat();
                CvInvoke.BitwiseAnd(hueFilter, saturationFilter, mergedImage);
                CvInvoke.BitwiseAnd(mergedImage, valueFilter, mergedImage);
                Invoke(new Action(() => { HSVPictureBox.Image = mergedImage.ToBitmap(); }));

                /*
                // Count pixels
                int whitepixels1 = 0;
                int whitepixels2 = 0;
                int whitepixels3 = 0;
                int whitepixels4 = 0;
                int whitepixels5 = 0;
                Image<Gray, byte> img = frame.ToImage<Gray, byte>();
                for (int i = 1; i <= 5; i++)
                {
                    for (int x = frame.Width / 5 * (i - 1); x < frame.Width / 5 * i; x++)
                    {
                        for (int y = 0; y < frame.Height; y++)
                        {
                            if (img.Data[y, x, 0] == 255)
                            {
                                if (i == 1) whitepixels1++;
                                if (i == 2) whitepixels2++;
                                if (i == 3) whitepixels3++;
                                if (i == 4) whitepixels4++;
                                if (i == 5) whitepixels5++;
                            }
                        }
                    }
                }
                Invoke(new Action(() =>
                {
                    label1.Text = $"{whitepixels1}";
                    label2.Text = $"{whitepixels2}";
                    label3.Text = $"{whitepixels3}";
                    label4.Text = $"{whitepixels4}";
                    label5.Text = $"{whitepixels5}";
                }));
                */
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // terminate the image processing thread to avoid orphaned processes
            _captureThread.Abort();
        }
    }
}