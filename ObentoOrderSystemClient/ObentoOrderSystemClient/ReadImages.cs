using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace ObentoOrderSystemClient
{
    class ReadImages
    {
        ImageList imageList = new ImageList();

        public ReadImages()
        {
            // To read image files
            string currentDir = Directory.GetCurrentDirectory();
            //MessageBox.Show(currentDir);
            DirectoryInfo imageDir = new DirectoryInfo(currentDir + @"\obentoImages");

            foreach (FileInfo file in imageDir.GetFiles())
            {
                try
                {
                    imageList.Images.Add(Image.FromFile(file.FullName));
                }
                catch
                {
                    Console.WriteLine("This is not an image file");
                }

            }
        }

        public ImageList getImages()
        {
            return imageList;
        }
    }
}
