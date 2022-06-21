using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextReda
{
    public partial class SRForm : Form
    {

        bool Search, Replace;


        public SRForm(bool Se,bool Re)
        {
            InitializeComponent();
            Search = Se;
            Replace = Re;
            int H = this.Size.Height;
            int W = this.Size.Width;
            groupBox1.Location = new Point(W / 2 - groupBox1.Size.Width / 2, H / 2 - groupBox1.Size.Height * 3 / 4);

            if (Search == true)// Поиск...
            {
                label1.Text = "Найти";
                label2.Visible = false;
                label2.Enabled = false;

            }else
            if (Replace == true)// Замена...
            {
                label1.Text = "Заменить";
                label2.Text = "на";
            }
            else // Перейти...
            {
                label1.Text = "Найти";
                label2.Visible = false;
                label2.Enabled = false;
                PrevB.Visible = false;
                NextB.Text = "Перейти";
            }
        }

        public SRForm()
        {
            InitializeComponent();
        }

        private void SRForm_Resize(object sender, EventArgs e)
        {
            int H = this.Size.Height;
            int W = this.Size.Width;
            groupBox1.Location = new Point(W / 2 - groupBox1.Size.Width / 2, H / 2 - groupBox1.Size.Height * 3 / 4);
        }
    }
}
