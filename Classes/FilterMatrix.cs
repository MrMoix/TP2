using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Image
{
    public class FilterMatrix
    {
        public static double[,] Laplacian3x3
        {
            get
            {
                return new double[,] 
                { { -1, -1, -1,  },
                  { -1,  8, -1,  },
                  { -1, -1, -1,  }, };
            }
        }

        public static double[,] Laplacian5x5
        {
            get
            {
                return new double[,]
                { { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, 24, -1, -1, },
                  { -1, -1, -1, -1, -1, },
                  { -1, -1, -1, -1, -1  }, };
            }
        }


        public static double[,] Sobel3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -2,  0,  2, },
                  { -1,  0,  1, }, };
            }
        }

        public static double[,] Sobel3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  2,  1, },
                  {  0,  0,  0, },
                  { -1, -2, -1, }, };
            }
        }

        public static double[,] Prewitt3x3Horizontal
        {
            get
            {
                return new double[,]
                { { -1,  0,  1, },
                  { -1,  0,  1, },
                  { -1,  0,  1, }, };
            }
        }

        public static double[,] Prewitt3x3Vertical
        {
            get
            {
                return new double[,]
                { {  1,  1,  1, },
                  {  0,  0,  0, },
                  { -1, -1, -1, }, };
            }
        }


        public static double[,] Kirsch3x3Horizontal
        {
            get
            {
                return new double[,]
                { {  5,  5,  5, },
                  { -3,  0, -3, },
                  { -3, -3, -3, }, };
            }
        }

        public static double[,] Kirsch3x3Vertical
        {
            get
            {
                return new double[,]
                { {  5, -3, -3, },
                  {  5,  0, -3, },
                  {  5, -3, -3, }, };
            }
        }

        public static Bitmap GetEdges(double[,] xFilterMatrix, double[,] yFilterMatrix, Bitmap basePicture)
        {
            var newbitmap = new Bitmap(basePicture);
            var newbitmapData = new BitmapData();
            newbitmapData = newbitmap.LockBits(new Rectangle(0, 0, newbitmap.Width, newbitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppPArgb);

            var pixelbuff = new byte[newbitmapData.Stride * newbitmapData.Height];
            var resultbuff = new byte[newbitmapData.Stride * newbitmapData.Height];

            Marshal.Copy(newbitmapData.Scan0, pixelbuff, 0, pixelbuff.Length);
            newbitmap.UnlockBits(newbitmapData);

            double blue, green, red = 0.0;

            double blueX, greenX, redX = 0.0;

            double blueY, greenY, redY = 0.0;

            double blueTotal, greenTotal, redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            for(var offsetY = filterOffset; offsetY <
                newbitmap.Height - filterOffset; offsetY++)
            {
                for(var offsetX = filterOffset; offsetX <
                    newbitmap.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;

                    blueTotal = greenTotal = redTotal = 0.0;

                    byteOffset = offsetY *
                                 newbitmapData.Stride +
                                 offsetX * 4;

                    for(var filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for(var filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * newbitmapData.Stride);

                            blueX += (double) (pixelbuff[calcOffset]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenX += (double) (pixelbuff[calcOffset + 1]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redX += (double) (pixelbuff[calcOffset + 2]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueY += (double) (pixelbuff[calcOffset]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenY += (double) (pixelbuff[calcOffset + 1]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redY += (double) (pixelbuff[calcOffset + 2]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                        }
                    }

                    blueTotal = 0;
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = 0;

       

                    if(greenTotal > 255)
                    {
                        greenTotal = 255;
                    }
                 

                    resultbuff[byteOffset] = (byte) (blueTotal);
                    resultbuff[byteOffset + 1] = (byte) (greenTotal);
                    resultbuff[byteOffset + 2] = (byte) (redTotal);
                    resultbuff[byteOffset + 3] = 255;
                }
            }

            var resultbitmap = new Bitmap(newbitmap.Width, newbitmap.Height);

            var resultData = resultbitmap.LockBits(new Rectangle(0, 0,
                                     resultbitmap.Width, resultbitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultbuff, 0, resultData.Scan0, resultbuff.Length);
            resultbitmap.UnlockBits(resultData);

            return resultbitmap;
        }
    }
}
