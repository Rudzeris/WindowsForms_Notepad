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
        Form1 form=null;

        public SRForm(bool Se,bool Re, Form1 F)
        {
            form = F;

            InitializeComponent();
            Search = Se;
            Replace = Re;
            int H = this.Size.Height;
            int W = this.Size.Width;
            groupBox1.Location = new Point(W / 2 - groupBox1.Size.Width / 2, H / 2 - groupBox1.Size.Height * 3 / 4);

            NextB.Enabled = false;
            PrevB.Enabled = false;
            ReplaceB.Enabled = false;
            ReplaceAllB.Enabled = false;

            if (Search == true)// Поиск...
            {
                textBox1.Text = form.getcurstext();
                label1.Text = "Найти";
                label2.Visible = false;
                label2.Enabled = false;
                textBox2.Visible = false;
                ReplaceB.Visible = false;
                ReplaceAllB.Visible = false;
                

            }else
            if (Replace == true)// Замена...
            {
                textBox1.Text = form.getcurstext();
                label1.Text = "Заменить";
                label2.Text = "на";
                ReplaceB.Text = "Заменить";
                ReplaceAllB.Text = "Заменить все";
            }
            else // Перейти...
            {
                label1.Text = "Перейти ";
                textBox1.Text = "Строка";
                label2.Visible = false;
                label2.Enabled = false;
                PrevB.Visible = false;
                NextB.Visible = false;
                ReplaceAllB.Visible = false;
                textBox2.Visible = false;
                ReplaceB.Text = "Перейти";
                ReplaceB.Enabled = false;
            }
        }

        private void PrevB_Click(object sender, EventArgs e)
        {
            form.PrevB(textBox1.Text, textBox1.Modified);
            textBox1.Modified = false;
        }

        

        private void NextB_Click(object sender, EventArgs e)
        {
            form.NextB(textBox1.Text, textBox1.Modified);
            textBox1.Modified = false;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Modified = true;
            
            if (Search == true)// Поиск...
            {

            }
            else
            if (Replace == true)// Замена...
            {

            }
            else // Перейти...
            {
                char number = e.KeyChar;
                if (!Char.IsDigit(number) && number != 8) // цифры, клавиша BackSpace и запятая
                {
                    e.Handled = true;
                }
                if (textBox1.Text.Length != 0)
                {
                    NextB.Enabled = true;
                }
                else
                {
                    NextB.Enabled = false;
                }
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Replace == true)
            {
                form.FReplace(textBox1.Text,textBox2.Text,true);
                textBox1.Modified = true;
            }
            else
            {
                form.Focus();
                int x = int.Parse(textBox1.Text);
                form.cross(x);
            }
        }

        private void ReplaceAllB_Click(object sender, EventArgs e)
        {

            form.FReplace(textBox1.Text, textBox2.Text, false);
            textBox1.Modified = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                NextB.Enabled = true;
                PrevB.Enabled = true;
                ReplaceB.Enabled = true;
                ReplaceAllB.Enabled = true;
            }
            else
            {
                NextB.Enabled = false;
                PrevB.Enabled = false;
                ReplaceB.Enabled = false;
                ReplaceAllB.Enabled = false;
            }
        }

        private void SRForm_Resize(object sender, EventArgs e)
        {
            int H = this.Size.Height;
            int W = this.Size.Width;
            groupBox1.Location = new Point(W / 2 - groupBox1.Size.Width / 2, H / 2 - groupBox1.Size.Height * 3 / 4);
        }
    }
}
