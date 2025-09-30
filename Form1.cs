//using AForge.Video;
//using AForge.Video.DirectShow;
//using WebCamLib;
using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using WebCamLib;

namespace ImageProcessingProject
{
    public partial class Form1 : Form
    {

        Bitmap imageB, imageA, colorgreen, resultImage;

        //for webcam 
        Device[] devices;
        Device currentDevice;
        System.Windows.Forms.Timer frameGrabber;

        private string currentFilter = "None";

        public Form1()
        {
            InitializeComponent();
            devices = DeviceManager.GetAllDevices();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Mat img = CvInvoke.Imread(@"C:\Users\Dell\Downloads\profile.png", Emgu.CV.CvEnum.ImreadModes.AnyColor);

            //CvInvoke.Imshow("My Image", img);
            //CvInvoke.WaitKey(0);
        }


        // ------------------------- BUTTON FUNCTIONS ------------------------- //

        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageB = new Bitmap(ofd.FileName);
                pictureBox1.Image = imageB;
            }
        }

        private void LoadBackground_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageA = new Bitmap(ofd.FileName);
                pictureBox2.Image = imageA;
            }
        }

        private void ApplyGreenScreen_Click(object sender, EventArgs e)
        {

            if (imageA == null || imageB == null)
            {
                MessageBox.Show("No Image Loaded!");
                return;
            }

            Color mygreen = Color.FromArgb(0, 0, 255);
            int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
            int threshold = 5;

            Bitmap result = new Bitmap(imageB.Width, imageB.Height);
            for (int y = 0; y < imageB.Height; y++)
            {
                for (int x = 0; x < imageB.Width; x++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);

                    if (subtractvalue > threshold)
                        result.SetPixel(x, y, pixel);
                    else
                        result.SetPixel(x, y, backpixel);
                }
            }

            pictureBox3.Image = result;

        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null)
            {
                MessageBox.Show("No Image Loaded!");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog.Title = "Save an Image File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                string ext = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg")
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                else if (ext == ".png")
                    format = System.Drawing.Imaging.ImageFormat.Png;
                else if (ext == ".bmp")
                    format = System.Drawing.Imaging.ImageFormat.Bmp;

                pictureBox3.Image.Save(saveFileDialog.FileName, format);

            }
        }


        // ------------------------- IMAGE PROCESSING FUNCTIONS ------------------------- //
        private Bitmap ProcessCopy(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixelColor = source.GetPixel(x, y);
                    result.SetPixel(x, y, pixelColor);
                }
            }
            return result;
        }

        private Bitmap ProcessGreyscale(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);

            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color originalColor = source.GetPixel(x, y);
                    int gray = (originalColor.R + originalColor.G + originalColor.B) / 3;
                    Color greyscaleColor = Color.FromArgb(gray, gray, gray);
                    result.SetPixel(x, y, greyscaleColor);
                }
            }
            return result;
        }

        private Bitmap ProcessInvert(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color originalColor = source.GetPixel(x, y);
                    Color invertedColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    result.SetPixel(x, y, invertedColor);
                }
            }

            return result;
        }

        private Bitmap ProcessSepia(Bitmap source)
        {
            Bitmap result = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color originalColor = source.GetPixel(x, y);

                    int tr = (int)(0.393 * originalColor.R + 0.769 * originalColor.G + 0.189 * originalColor.B);
                    int tg = (int)(0.349 * originalColor.R + 0.686 * originalColor.G + 0.168 * originalColor.B);
                    int tb = (int)(0.272 * originalColor.R + 0.534 * originalColor.G + 0.131 * originalColor.B);

                    // Clamp values to [0,255]
                    tr = Math.Min(255, tr);
                    tg = Math.Min(255, tg);
                    tb = Math.Min(255, tb);

                    Color sepiaColor = Color.FromArgb(tr, tg, tb);
                    result.SetPixel(x, y, sepiaColor);
                }
            }
            return result;
        }


        // ------------------------- IMAGE PROCESSING BUTTONS ------------------------- //
        private void copyImage_Click(object sender, EventArgs e)
        {
            if (imageB == null)
            {
                MessageBox.Show("No Image Loaded!");
                return;
            }
            currentFilter = "copy";
            resultImage = ProcessCopy(imageB);
            pictureBox3.Image = resultImage;
        }

        private void greyscale_Click(object sender, EventArgs e)
        {
            if (imageB == null)
            {
                MessageBox.Show("No Image Loaded!");
                return;
            }
            currentFilter = "grey";
            resultImage = ProcessGreyscale(imageB);
            pictureBox3.Image = resultImage;
        }

        private void invert_Click(object sender, EventArgs e)
        {
            if (imageB == null)
            {
                MessageBox.Show("No Image Loaded!");
                return;
            }
            currentFilter = "invert";
            resultImage = ProcessInvert(imageB);
            pictureBox3.Image = resultImage;
        }

        private void histogram_Click(object sender, EventArgs e)
        {
            if (imageB == null)
            {
                MessageBox.Show("No Image Loaded!");
                return;
            }
            currentFilter = "histogram";
            int[] grayHist = new int[256];

            // Step 1,2 = Convert to grayscale and count pixel levels
            for (int y = 0; y < imageB.Height; y++)
            {
                for (int x = 0; x < imageB.Width; x++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    grayHist[gray]++;
                }
            }

            // Step 3 = Plot the histogram
            int histWidth = 256;
            int histHeight = 100;
            int max = grayHist.Max();

            Bitmap histImage = new Bitmap(histWidth, histHeight);
            using (Graphics g = Graphics.FromImage(histImage))
            {
                g.Clear(Color.White);

                for (int i = 0; i < 256; i++)
                {
                    int height = (int)((grayHist[i] / (float)max) * histHeight);
                    g.DrawLine(Pens.Black, i, histHeight, i, histHeight - height);
                }
            }

            resultImage = histImage;
            pictureBox3.Image = resultImage;
        }

        private void sepia_Click(object sender, EventArgs e)
        {
            if (imageB == null)
            {
                MessageBox.Show("No Image Loaded!");
                return;
            }
            currentFilter = "sepia";
            resultImage = ProcessSepia(imageB);
            pictureBox3.Image = resultImage;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        // ------------------------- WEBCAM PROCESSING FUNCTIONS ------------------------- //


        private void openwebcam_Click(object sender, EventArgs e)
        {
            if (devices.Length > 0)
            {
                currentDevice = devices[0];
                currentDevice.Init(pictureBox1.Height, pictureBox1.Width, pictureBox1.Handle.ToInt32());

                frameGrabber = new System.Windows.Forms.Timer();
                frameGrabber.Interval = 100;
                frameGrabber.Tick += CaptureFrame;
                frameGrabber.Start();
            }
            else
            {
                MessageBox.Show("No webcam found!");
            }

        }

        private void stoprecording_Click(object sender, EventArgs e)
        {

            if (currentDevice != null)
            {
                currentDevice.Stop();
                currentDevice = null;
                pictureBox1.Image = null;
            }

        }

        //helping function to capture frame from webcam
        private void CaptureFrame(object sender, EventArgs e)
        {
            if (currentDevice != null)
            {
                currentDevice.Sendmessage();
                IDataObject data = Clipboard.GetDataObject();

                if (data != null && data.GetDataPresent(typeof(Bitmap)))
                {
                    var temp = data.GetData(typeof(Bitmap)) as Bitmap;
                    if (temp != null)
                    {

                        if (imageB != null) imageB.Dispose();
                        imageB = (Bitmap)temp.Clone();
                        pictureBox1.Image = imageB;


                        if (currentFilter != "None")
                        {
                            Bitmap frameCopy = (Bitmap)imageB.Clone();
                            Task.Run(() =>
                            {
                                Bitmap processed = frameCopy;

                                switch (currentFilter)
                                {
                                    case "grey":
                                        processed = ProcessGreyscale(frameCopy);
                                        break;
                                    case "invert":
                                        processed = ProcessInvert(frameCopy);
                                        break;
                                    case "sepia":
                                        processed = ProcessSepia(frameCopy);
                                        break;
                                    case "copy":
                                        processed = ProcessCopy(frameCopy);
                                        break;
                                }


                                if (pictureBox3.InvokeRequired)
                                {
                                    pictureBox3.Invoke(new Action(() =>
                                    {
                                        if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                                        pictureBox3.Image = processed;
                                    }));
                                }
                                else
                                {
                                    if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
                                    pictureBox3.Image = processed;
                                }
                            });
                        }
                        else
                        {

                            pictureBox3.Image = (Bitmap)imageB.Clone();
                        }
                    }
                }
            }
        }



        // ------------------------- CONVOLUTION MATRIX ------------------------- //


        private void applyConvolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void shrinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded!");
                return;
            }
            Bitmap srcBitmap = (Bitmap)pictureBox1.Image;
            Mat src = srcBitmap.ToMat();

            Matrix<float> kernel = new Matrix<float>(3, 3);
            float val = 1f / 9f; // average of 3x3 neighborhood
            kernel.SetValue(val);

            Mat dst = new Mat(src.Size, DepthType.Cv8U, src.NumberOfChannels);
            CvInvoke.Filter2D(src, dst, kernel, new System.Drawing.Point(-1, -1));
            pictureBox3.Image = dst.ToBitmap();
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) { 
                MessageBox.Show("No image loaded!");
                return; 
            }
            Bitmap srcBitmap = (Bitmap)pictureBox1.Image; 
            Mat src = srcBitmap.ToMat();

            Matrix<float> kernel = new Matrix<float>(3, 3);
            float val = 1f / 16f; // Gaussian 3x3 approximation
            kernel[0, 0] = 1 * val; kernel[0, 1] = 2 * val; kernel[0, 2] = 1 * val;
            kernel[1, 0] = 2 * val; kernel[1, 1] = 4 * val; kernel[1, 2] = 2 * val;
            kernel[2, 0] = 1 * val; kernel[2, 1] = 2 * val; kernel[2, 2] = 1 * val;

            Mat dst = new Mat(src.Size, DepthType.Cv8U, src.NumberOfChannels);
            CvInvoke.Filter2D(src, dst, kernel, new System.Drawing.Point(-1, -1));
            pictureBox3.Image = dst.ToBitmap();
        }

        private void smoothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded!");
                return;
            }
            Bitmap srcBitmap = (Bitmap)pictureBox1.Image;
            Mat src = srcBitmap.ToMat();

            Matrix<float> kernel = new Matrix<float>(3, 3);
            float val = 1f / 16f;
            kernel[0, 0] = 1 * val; kernel[0, 1] = 2 * val; kernel[0, 2] = 1 * val;
            kernel[1, 0] = 2 * val; kernel[1, 1] = 4 * val; kernel[1, 2] = 2 * val;
            kernel[2, 0] = 1 * val; kernel[2, 1] = 2 * val; kernel[2, 2] = 1 * val;

            Mat dst = new Mat(src.Size, DepthType.Cv8U, src.NumberOfChannels);
            CvInvoke.Filter2D(src, dst, kernel, new System.Drawing.Point(-1, -1));
            pictureBox3.Image = dst.ToBitmap();
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded!");
                return;
            }
            Bitmap srcBitmap = (Bitmap)pictureBox1.Image;
            Mat src = srcBitmap.ToMat();

            Matrix<float> kernel = new Matrix<float>(3, 3);
            float factor = 3f;
            kernel[0, 0] = 0 / factor; kernel[0, 1] = -2 / factor; kernel[0, 2] = 0 / factor;
            kernel[1, 0] = -2 / factor; kernel[1, 1] = 11 / factor; kernel[1, 2] = -2 / factor;
            kernel[2, 0] = 0 / factor; kernel[2, 1] = -2 / factor; kernel[2, 2] = 0 / factor;

            Mat dst = new Mat(src.Size, DepthType.Cv8U, src.NumberOfChannels);
            CvInvoke.Filter2D(src, dst, kernel, new System.Drawing.Point(-1, -1));
            pictureBox3.Image = dst.ToBitmap();
        }

        private void meanRemovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded!");
                return;
            }
            Bitmap srcBitmap = (Bitmap)pictureBox1.Image;
            Mat src = srcBitmap.ToMat();

            Matrix<float> kernel = new Matrix<float>(3, 3);
            kernel[0, 0] = -1; kernel[0, 1] = -1; kernel[0, 2] = -1;
            kernel[1, 0] = -1; kernel[1, 1] = 9; kernel[1, 2] = -1;
            kernel[2, 0] = -1; kernel[2, 1] = -1; kernel[2, 2] = -1;

            Mat dst = new Mat(src.Size, DepthType.Cv8U, src.NumberOfChannels);
            CvInvoke.Filter2D(src, dst, kernel, new System.Drawing.Point(-1, -1));
            pictureBox3.Image = dst.ToBitmap();
        }

        private void embosingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image loaded!");
                return;
            }
            Bitmap srcBitmap = (Bitmap)pictureBox1.Image;
            Mat src = srcBitmap.ToMat();

            Matrix<float> kernel = new Matrix<float>(3, 3);
            kernel[0, 0] = -1; kernel[0, 1] = 0; kernel[0, 2] = -1;
            kernel[1, 0] = -0; kernel[1, 1] = 4; kernel[1, 2] = 0;
            kernel[2, 0] = -1; kernel[2, 1] = 0; kernel[2, 2] = -1;

            Mat dst = new Mat(src.Size, DepthType.Cv8U, src.NumberOfChannels);
            CvInvoke.Filter2D(src, dst, kernel, new System.Drawing.Point(-1, -1));
            pictureBox3.Image = dst.ToBitmap();
        }
    }
}
   