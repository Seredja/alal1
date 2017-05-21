using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
        }

        public void function(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width / 2; i++)//R
            {
                for (int j = 0; j < bmp.Height / 2; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    Color newPix = Color.FromArgb(255, R, 0, 0);
                    bmp.SetPixel(i, j, newPix);
                }
            }
            for (int i = bmp.Width / 2; i < bmp.Width; i++)//G
            {
                for (int j = 0; j < bmp.Height / 2; j++)
                {
                    int G = bmp.GetPixel(i, j).G;
                    Color newPix = Color.FromArgb(255, 0, G, 0);
                    bmp.SetPixel(i, j, newPix);
                }
            }
            for (int i = 0; i < bmp.Width / 2; i++)//B
            {
                for (int j = bmp.Height / 2; j < bmp.Height; j++)
                {
                    int B = bmp.GetPixel(i, j).B;
                    Color newPix = Color.FromArgb(255, 0, 0, B);
                    bmp.SetPixel(i, j, newPix);
                }
            }
            for (int i = bmp.Width / 2; i < bmp.Width; i++)//gray
            {
                for (int j = bmp.Height / 2; j < bmp.Height; j++)
                {
                    int R = bmp.GetPixel(i, j).R;
                    int G = bmp.GetPixel(i, j).G;
                    int B = bmp.GetPixel(i, j).B;
                    int Gray = (R + G + B) / 3;
                    Color newPix = Color.FromArgb(255, Gray, Gray, Gray);
                    bmp.SetPixel(i, j, newPix);
                }
            }
        }
        private void отрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                int width = image.Width;
                int height = image.Height;
                bmp = new Bitmap(image, width, height);
                function(bmp);
                pictureBox1.Image = bmp;
            }
        }
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();

            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "Bitmap File(*.bmp)|*.bmp|" + "GIF File(*.gif)|*.gif|" + "JPEG File(*.jpg)|*.jpg|" + "TIF File(*.tif)|*.tif|" + "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savedialog.FileName;
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                switch (strFilExtn)
                {
                    case "bmp": bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                    case "jpg": bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                    case "gif": bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif); break;
                    case "tif": bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff); break;
                    case "png": bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png); break;
                    default: break;
                }

            }
        }
    }
}
