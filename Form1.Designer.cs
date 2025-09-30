namespace ImageProcessingProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            menuStrip1 = new MenuStrip();
            copyImageToolStripMenuItem = new ToolStripMenuItem();
            greyscaleToolStripMenuItem = new ToolStripMenuItem();
            colorInversionToolStripMenuItem = new ToolStripMenuItem();
            histogramToolStripMenuItem = new ToolStripMenuItem();
            sepiaToolStripMenuItem = new ToolStripMenuItem();
            openWebcamToolStripMenuItem = new ToolStripMenuItem();
            sToolStripMenuItem = new ToolStripMenuItem();
            applyConvolutionToolStripMenuItem = new ToolStripMenuItem();
            shrinkToolStripMenuItem = new ToolStripMenuItem();
            smoothToolStripMenuItem = new ToolStripMenuItem();
            gaussianToolStripMenuItem = new ToolStripMenuItem();
            sharpenToolStripMenuItem = new ToolStripMenuItem();
            meanRemovalToolStripMenuItem = new ToolStripMenuItem();
            embosingToolStripMenuItem = new ToolStripMenuItem();
            button3 = new Button();
            button2 = new Button();
            button4 = new Button();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(38, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 350);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(580, 35);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(500, 350);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(1106, 391);
            button1.Name = "button1";
            button1.Size = new Size(197, 32);
            button1.TabIndex = 2;
            button1.Text = "subtract";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ApplyGreenScreen_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { copyImageToolStripMenuItem, greyscaleToolStripMenuItem, colorInversionToolStripMenuItem, histogramToolStripMenuItem, sepiaToolStripMenuItem, openWebcamToolStripMenuItem, sToolStripMenuItem, applyConvolutionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1633, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // copyImageToolStripMenuItem
            // 
            copyImageToolStripMenuItem.Name = "copyImageToolStripMenuItem";
            copyImageToolStripMenuItem.Size = new Size(81, 20);
            copyImageToolStripMenuItem.Text = "copy image";
            copyImageToolStripMenuItem.Click += copyImage_Click;
            // 
            // greyscaleToolStripMenuItem
            // 
            greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            greyscaleToolStripMenuItem.Size = new Size(68, 20);
            greyscaleToolStripMenuItem.Text = "greyscale";
            greyscaleToolStripMenuItem.Click += greyscale_Click;
            // 
            // colorInversionToolStripMenuItem
            // 
            colorInversionToolStripMenuItem.Name = "colorInversionToolStripMenuItem";
            colorInversionToolStripMenuItem.Size = new Size(97, 20);
            colorInversionToolStripMenuItem.Text = "color inversion";
            colorInversionToolStripMenuItem.Click += invert_Click;
            // 
            // histogramToolStripMenuItem
            // 
            histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            histogramToolStripMenuItem.Size = new Size(73, 20);
            histogramToolStripMenuItem.Text = "histogram";
            histogramToolStripMenuItem.Click += histogram_Click;
            // 
            // sepiaToolStripMenuItem
            // 
            sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            sepiaToolStripMenuItem.Size = new Size(47, 20);
            sepiaToolStripMenuItem.Text = "Sepia";
            sepiaToolStripMenuItem.Click += sepia_Click;
            // 
            // openWebcamToolStripMenuItem
            // 
            openWebcamToolStripMenuItem.Name = "openWebcamToolStripMenuItem";
            openWebcamToolStripMenuItem.Size = new Size(94, 20);
            openWebcamToolStripMenuItem.Text = "open webcam";
            openWebcamToolStripMenuItem.Click += openwebcam_Click;
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(96, 20);
            sToolStripMenuItem.Text = "stop recording";
            sToolStripMenuItem.Click += stoprecording_Click;
            // 
            // applyConvolutionToolStripMenuItem
            // 
            applyConvolutionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { shrinkToolStripMenuItem, smoothToolStripMenuItem, gaussianToolStripMenuItem, sharpenToolStripMenuItem, meanRemovalToolStripMenuItem, embosingToolStripMenuItem });
            applyConvolutionToolStripMenuItem.Name = "applyConvolutionToolStripMenuItem";
            applyConvolutionToolStripMenuItem.Size = new Size(115, 20);
            applyConvolutionToolStripMenuItem.Text = "apply convolution";
            applyConvolutionToolStripMenuItem.Click += applyConvolutionToolStripMenuItem_Click;
            // 
            // shrinkToolStripMenuItem
            // 
            shrinkToolStripMenuItem.Name = "shrinkToolStripMenuItem";
            shrinkToolStripMenuItem.Size = new Size(180, 22);
            shrinkToolStripMenuItem.Text = "shrink";
            shrinkToolStripMenuItem.Click += shrinkToolStripMenuItem_Click;
            // 
            // smoothToolStripMenuItem
            // 
            smoothToolStripMenuItem.Name = "smoothToolStripMenuItem";
            smoothToolStripMenuItem.Size = new Size(180, 22);
            smoothToolStripMenuItem.Text = "smooth";
            smoothToolStripMenuItem.Click += smoothToolStripMenuItem_Click;
            // 
            // gaussianToolStripMenuItem
            // 
            gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            gaussianToolStripMenuItem.Size = new Size(180, 22);
            gaussianToolStripMenuItem.Text = "gaussian blur";
            gaussianToolStripMenuItem.Click += gaussianToolStripMenuItem_Click;
            // 
            // sharpenToolStripMenuItem
            // 
            sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            sharpenToolStripMenuItem.Size = new Size(180, 22);
            sharpenToolStripMenuItem.Text = "sharpen";
            sharpenToolStripMenuItem.Click += sharpenToolStripMenuItem_Click;
            // 
            // meanRemovalToolStripMenuItem
            // 
            meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            meanRemovalToolStripMenuItem.Size = new Size(180, 22);
            meanRemovalToolStripMenuItem.Text = "mean removal";
            meanRemovalToolStripMenuItem.Click += meanRemovalToolStripMenuItem_Click;
            // 
            // embosingToolStripMenuItem
            // 
            embosingToolStripMenuItem.Name = "embosingToolStripMenuItem";
            embosingToolStripMenuItem.Size = new Size(180, 22);
            embosingToolStripMenuItem.Text = "embosing";
            embosingToolStripMenuItem.Click += embosingToolStripMenuItem_Click;
            // 
            // button3
            // 
            button3.Location = new Point(38, 391);
            button3.Name = "button3";
            button3.Size = new Size(197, 32);
            button3.TabIndex = 5;
            button3.Text = "load image";
            button3.UseVisualStyleBackColor = true;
            button3.Click += LoadImage_Click;
            // 
            // button2
            // 
            button2.Location = new Point(580, 391);
            button2.Name = "button2";
            button2.Size = new Size(197, 32);
            button2.TabIndex = 6;
            button2.Text = "load background";
            button2.UseVisualStyleBackColor = true;
            button2.Click += LoadBackground_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1409, 391);
            button4.Name = "button4";
            button4.Size = new Size(197, 32);
            button4.TabIndex = 7;
            button4.Text = "save";
            button4.UseVisualStyleBackColor = true;
            button4.Click += saveImageButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(1106, 35);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(500, 350);
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1633, 511);
            Controls.Add(pictureBox3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem copyImageToolStripMenuItem;
        private ToolStripMenuItem greyscaleToolStripMenuItem;
        private ToolStripMenuItem colorInversionToolStripMenuItem;
        private ToolStripMenuItem histogramToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private Button button3;
        private Button button2;
        private Button button4;
        private PictureBox pictureBox3;
        private ToolStripMenuItem openWebcamToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem applyConvolutionToolStripMenuItem;
        private ToolStripMenuItem shrinkToolStripMenuItem;
        private ToolStripMenuItem smoothToolStripMenuItem;
        private ToolStripMenuItem gaussianToolStripMenuItem;
        private ToolStripMenuItem sharpenToolStripMenuItem;
        private ToolStripMenuItem meanRemovalToolStripMenuItem;
        private ToolStripMenuItem embosingToolStripMenuItem;
    }
}
