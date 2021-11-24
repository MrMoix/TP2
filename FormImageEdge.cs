using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using PictureBox.Image.Testes;

//My take on and implementation of http://www.getcodesamples.com/src/25E5A923
namespace Image
{
    public partial class FormImageEdge : Form
    {
        System.Drawing.Image Origin;
        public FormImageEdge()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load an image on the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            Origin = pictureBoxPreview.Image;
            pictureBoxResult.BackColor = Color.White;
            Bitmap temp = new Bitmap(pictureBoxPreview.Image,
                new Size(pictureBoxPreview.Width, pictureBoxPreview.Height));
            pictureBoxPreview.Image = temp;
            Bitmap tempSecond = new Bitmap(pictureBoxResult.Width, pictureBoxResult.Height);
            pictureBoxResult.Image = tempSecond;
        }

        /// <summary>
        /// The method allow to save an image
        /// </summary>
        public void SaveImage()
        {
            pictureBoxResult.SizeMode = PictureBoxSizeMode.AutoSize;
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if(fl.ShowDialog() != DialogResult.Cancel)
            {
                pictureBoxResult.Image.Save(fl.SelectedPath + @"\" + textBoxSaveImage.Text + @".jpg", ImageFormat.Png);
            };
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /// <summary>
        /// The method allows to load an image on the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Title = "Select image ";
            OpenFileDialog.Filter = "Jpeg Images(*.jpg)|*.jpg|Png Images(*.png)|*.png|Bitmap Images(*.bmp)|*.bmp";

            if (OpenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(OpenFileDialog.FileName);
                Bitmap image = new Bitmap(streamReader.BaseStream);
                streamReader.Close();

                pictureBoxPreview.Image = image;                

            }
        }

        /// <summary>
        /// The method allows to apply X filter and Y filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonApplyFilters_Click(object sender, EventArgs e)
        {
            filter(listBoxXFilter.SelectedItem.ToString(), listBoxYFilter.SelectedItem.ToString());
        }
        /// <summary>
        /// The method allows to apply X filter and Y filter
        /// </summary>
        /// <param name="xfilter"></param>
        /// <param name="yfilter"></param>
        public void filter(string xfilter, string yfilter)
        {
            double[,] xFilterMatrix;
            double[,] yFilterMatrix;
            switch (xfilter)
	        {
                case "Laplacian3x3":
                    xFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    xFilterMatrix = FilterMatrix.Laplacian5x5;
                    break;
                case "Sobel3x3Horizontal":
                    xFilterMatrix = FilterMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    xFilterMatrix = FilterMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    xFilterMatrix = FilterMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    xFilterMatrix = FilterMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    xFilterMatrix = FilterMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    xFilterMatrix = FilterMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    xFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
	        }
            
            switch (yfilter)
	        {
                case "Laplacian3x3":
                    yFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
                case "Laplacian5x5":
                    yFilterMatrix = FilterMatrix.Laplacian5x5;
                    break;
                case "Sobel3x3Horizontal":
                    yFilterMatrix = FilterMatrix.Sobel3x3Horizontal;
                    break;
                case "Sobel3x3Vertical":
                    yFilterMatrix = FilterMatrix.Sobel3x3Vertical;
                    break;
                case "Prewitt3x3Horizontal":
                    yFilterMatrix = FilterMatrix.Prewitt3x3Horizontal;
                    break;
                case "Prewitt3x3Vertical":
                    yFilterMatrix = FilterMatrix.Prewitt3x3Vertical;
                    break;
                case "Kirsch3x3Horizontal":
                    yFilterMatrix = FilterMatrix.Kirsch3x3Horizontal;
                    break;
                case "Kirsch3x3Vertical":
                    yFilterMatrix = FilterMatrix.Kirsch3x3Vertical;
                    break;
                default:
                    yFilterMatrix = FilterMatrix.Laplacian3x3;
                    break;
	        }

            if (pictureBoxPreview.Image.Size.Height > 0)
            {
                Bitmap newbitmap = new Bitmap(pictureBoxPreview.Image);
                BitmapData newbitmapData = new BitmapData();
                newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

                byte[] pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
                byte[] resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

                Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
                newbitmap.UnlockBits(newbitmapData);


                double blueX = 0.0;
                double greenX = 0.0;
                double redX = 0.0;

                double blueY = 0.0;
                double greenY = 0.0;
                double redY = 0.0;

                double blueTotal = 0.0;
                double greenTotal = 0.0;
                double redTotal = 0.0;

                int filterOffset = 1;
                int calcOffset = 0;

                int byteOffset = 0;

                for (int offsetY = filterOffset; offsetY <
                    newbitmap.Height - filterOffset; offsetY++)
                {
                    for (int offsetX = filterOffset; offsetX <
                        newbitmap.Width - filterOffset; offsetX++)
                    {
                        blueX = greenX = redX = 0;
                        blueY = greenY = redY = 0;

                        blueTotal = greenTotal = redTotal = 0.0;

                        byteOffset = offsetY *
                                     newbitmapData.Stride +
                                     offsetX * 4;

                        for (int filterY = -filterOffset;
                            filterY <= filterOffset; filterY++)
                        {
                            for (int filterX = -filterOffset;
                                filterX <= filterOffset; filterX++)
                            {
                                calcOffset = byteOffset +
                                             (filterX * 4) +
                                             (filterY * newbitmapData.Stride);

                                blueX += (double)(pixelbuff[calcOffset]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenX += (double)(pixelbuff[calcOffset + 1]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redX += (double)(pixelbuff[calcOffset + 2]) *
                                          xFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                blueY += (double)(pixelbuff[calcOffset]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                greenY += (double)(pixelbuff[calcOffset + 1]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];

                                redY += (double)(pixelbuff[calcOffset + 2]) *
                                          yFilterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];
                            }
                        }

                        blueTotal = 0;
                        greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                        redTotal = 0;

                        if (blueTotal > 255)
                        { blueTotal = 255; }
                        else if (blueTotal < 0)
                        { blueTotal = 0; }

                        if (greenTotal > 255)
                        { greenTotal = 255; }
                        else if (greenTotal < 0)
                        { greenTotal = 0; }

                        if (redTotal > 255)
                        { redTotal = 255; }
                        else if (redTotal < 0)
                        { redTotal = 0; }

                        resultbuff[byteOffset] = (byte)(blueTotal);
                        resultbuff[byteOffset + 1] = (byte)(greenTotal);
                        resultbuff[byteOffset + 2] = (byte)(redTotal);
                        resultbuff[byteOffset + 3] = 255;
                    }
                }

                Bitmap resultbitmap = new Bitmap(newbitmap.Width, newbitmap.Height);

                BitmapData resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                         resultbitmap.Width, resultbitmap.Height),
                                                          ImageLockMode.WriteOnly,
                                                      PixelFormat.Format32bppArgb);

                Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
                resultbitmap.UnlockBits(resultData);
                pictureBoxResult.Image = resultbitmap;
            }
        }

     
        /// <summary>
        /// Apply the filter Mosaic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMosaicFilter_Click(object sender, EventArgs e)
        {

            pictureBoxPreview.Image = ImageFilters.DivideCrop(new Bitmap(pictureBoxPreview.Image));
            buttonApplyFilters.Enabled = true;
            listBoxXFilter.Enabled = true;
            listBoxYFilter.Enabled = true;
        }

        /// <summary>
        /// Apply the swap filter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSwapFilter_Click(object sender, EventArgs e)
        {
            pictureBoxPreview.Image = ImageFilters.ApplyFilterSwap(new Bitmap(pictureBoxPreview.Image));
            buttonApplyFilters.Enabled = true;
            listBoxXFilter.Enabled = true;
            listBoxYFilter.Enabled = true;
        }

        /// <summary>
        /// Reset the windows as default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            pictureBoxPreview.Image = Origin;
            listBoxXFilter.Enabled = false;
            listBoxYFilter.Enabled = false;
            buttonApplyFilters.Enabled = false;
            pictureBoxResult.Image = null;
            listBoxYFilter.SelectedItem = null;
            listBoxXFilter.SelectedItem = null;
        }


        /// <summary>
        /// Save the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            if(textBoxSaveImage.Text.Equals(""))
            {
                labelEnterValidName.Visible = true;
            }
            else
            {
                SaveImage();
            }
        }

        /// <summary>
        /// Give a name to an image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSave_TextChanged(object sender, EventArgs e)
        {
            labelEnterValidName.Visible = false;
        }
    }
}