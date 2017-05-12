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

        public ReadImages(string imgName)
        {
            
            // To read image files
            string currentDir = Directory.GetCurrentDirectory();
            //MessageBox.Show(currentDir);
            DirectoryInfo imageDir = new DirectoryInfo(currentDir + @"\obentoImages");
            

            //DirectoryInfo imageDir = new DirectoryInfo(@"C:\Users\iii\Documents\Visual Studio 2015\Projects\ObentoOrderSystemClient\obentoImages");

            foreach (FileInfo file in imageDir.GetFiles())
            {
                try
                {
                    string[] strName = file.FullName.Split('\\');
                    if (strName.Last().Split('.')[0] == imgName) {
                        imageList.Images.Add(Image.FromFile(file.FullName));
                    }
                }
                catch
                {
                    Console.WriteLine("There are no image file");
                }
            }
        }

        public ImageList getImages()
        {
            return imageList;
        }
    }
}
