using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PictureBox.Image.Testes
{
    public class ImageFilters
    {

        //apply color filter to swap pixel colors
        public static Bitmap ApplyFilterSwap(Bitmap bmp)
        {

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for(int i = 0; i < bmp.Width; i++)
            {
                for(int x = 0; x < bmp.Height; x++)
                {
                    Color c = bmp.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        //apply magic mosaic
        public static Bitmap DivideCrop(Bitmap bmp)
        {
            int razX = Convert.ToInt32(bmp.Width / 3);
            int razY = Convert.ToInt32(bmp.Height / 3);

            Bitmap temp = new Bitmap(bmp.Width, bmp.Height);


            for(int i = 0; i < bmp.Width - 1; i++)
            {
                for(int x = 0; x < bmp.Height - 1; x++)
                {
                    if(i < razX && x < razY)
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if(i < (razX * 2) && x < (razY))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x, i));
                    }
                    else if(i < (razX * 3) && x < (razY))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if(i < (razX) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x, i));
                    }
                    else if(i < (razX) && x < (razY * 3))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    else if(i < (razX * 2) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(i, x));
                    }
                    
                    else if(i < (razX * 4) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x / 2, i / 2));
                    }
                    else if (i < (razX * 4) && x < (razY * 3))
                    {
                        temp.SetPixel(i, x, bmp.GetPixel(x / 3, i / 3));
                    }

                }

            }
            return temp;
        }
    }
}
