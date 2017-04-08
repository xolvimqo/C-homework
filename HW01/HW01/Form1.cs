using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("static void Main(string[] args)");
            Console.WriteLine("{\n\tstring birth; DateTime special;");
            Console.WriteLine("\tConsole.Write(\"請輸入今天日期\");");
            Console.WriteLine("\tbirth = Console.ReadLine();");
            Console.WriteLine("\t//ToDateTime(字串)轉為日期格式");
            Console.WriteLine("\tspecial = Convert.ToDateTime(birth);");
            Console.WriteLine("\tConsole.WriteLine(\"今天是{0}\", special);");
            Console.WriteLine("\tConsole.Read();//讓畫面暫停\n}");
        }
    }
}
