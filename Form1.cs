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
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            textBox1.Multiline = true; // разрешаем многострочный текст
                                       // textBox1 занимает всю свободную поверхность форм
            textBox1.ReadOnly = false;
            textBox1.Dock = DockStyle.Fill;
            // включаем вертикальную и горизонтальную полосы прокрутки
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.WordWrap = false; // запрещаем перенос строк
            textBox1.Clear();
            this.Text = "Текстовый редактор 3000";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        }
        // Обработчик события Click пункта меню Открыть

        // Вспомогательный метод для записи текста в файл
        private void Запись()
        {
            try
            { // Создание экземпляра StreamWriter для записи в файл:
                var Писатель = new System.IO.StreamWriter(saveFileDialog1.FileName, false,
                System.Text.Encoding.GetEncoding(1251));
                // - здесь заказ кодовой страницы Winl251 для русских букв
                Писатель.Write(textBox1.Text);
                Писатель.Close();
                //textBox1.Modified = false;
            }
            catch (System.Exception Ситуация)
            { // Отчет обо всех возможных ошибках
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }


        // Обработчик события FormClosing формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Modified == false) return; // Если текст модифицирован, то спросить, записывать ли файл
            DialogResult MBox = MessageBox.Show("Текст был изменен.\nСохранить изменения?",
            "Простой редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            // YES — диалог; NO — выход; CANCEL — редактировать
            if (MBox == DialogResult.No) return;
            if (MBox == DialogResult.Cancel) e.Cancel = true;
            if (MBox == DialogResult.Yes)
            {
                if (openFileDialog1.FileName == "")
                    сохранитьКакToolStripMenuItem_Click_1(sender, e);
                else
                    saveFileDialog1.FileName = openFileDialog1.FileName;
                Запись();
                return;
            } // DialogResult.Yes
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            //if (openFileDialog1.FileName == null) return;
            // Чтение текстового файла: try
            try
            { // Создание экземпляра StreamReader для чтения из файла
                var Читатель = new System.IO.StreamReader(openFileDialog1.FileName,
                System.Text.Encoding.GetEncoding(1251));
                // здесь заказ кодовой страницы Winl251 для русских букв
                textBox1.Text = Читатель.ReadToEnd();
                Читатель.Close();
            }
            catch (System.IO.FileNotFoundException Ситуация)
            {
                MessageBox.Show(Ситуация + "\nНет такого файла", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Exception Ситуация)
            {
                // Отчет о других ошибках
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }

        private void сохранитьКакToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) Запись();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private FontDialog fnt = new FontDialog();

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fnt.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fnt.Font;
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Modified = false;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName == "")
                сохранитьКакToolStripMenuItem_Click_1(sender, e);
            else
                saveFileDialog1.FileName = openFileDialog1.FileName;
            Запись();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textBox1.Modified = true;
            //textBox1.Select();
            textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textBox1.Modified = true;
            textBox1.Paste();
        }

        private void toolStripTextBox2_Click_1(object sender, EventArgs e)
        {

        }
        bool bl = false;
        //public void FSearch(string str)
        //{
        //    bl = true;
        //    textBox1.Focus();
        //    string a = str;
        //    search_1 = textBox1.Text;
        //    int b = textBox1.Text.IndexOf(a);
        //    if (b != -1)
        //    {
        //        int b1 = a.Length;
        //        textBox1.Select(b, b1);
        //        search_1.Remove(b, b1);
        //        for (int i = 0; i < b1; i++)
        //        {
        //            search_1.Insert(b, ((char)4).ToString());
        //        }
        //    }
        //    textBox1.ReadOnly = true;

        //}

        public string gettextbox()
        {
            return textBox1.Text;
        }

        //string search_1; // доп. текст, где мы заменяем символы которые использовали
        int w = 0; // Записывает где находится select для поиска и замены
        int[] xs=null;

        private void SearchAll(string str, bool k)
        {

            if (xs != null)
            {
                xs = null;
            }
            k = false;
            bl = true;
            textBox1.Focus();
            string a = str;
            string search_1 = textBox1.Text;
            int b = b = search_1.IndexOf(a); ;
            while (b != -1)
            {
                w++;

                int b1 = a.Length;
                //textBox1.Select(b, b1);
                search_1 = search_1.Remove(b, b1);
                for (int i = 0; i < b1; i++)
                {
                    search_1 = search_1.Insert(b, ((char)4).ToString());
                }
                b = search_1.IndexOf(a);
            }
            if (w > 0)
            {
                xs = new int[w];
                int j = 0;

                search_1 = textBox1.Text;
                b = search_1.IndexOf(a); ;
                while (b != -1)
                {
                    int b1 = a.Length;
                    //textBox1.Select(b, b1);
                    search_1 = search_1.Remove(b, b1);
                    for (int i = 0; i < b1; i++)
                    {
                        search_1 = search_1.Insert(b, ((char)4).ToString());
                    }
                    xs[j] = b;
                    b = search_1.IndexOf(a);
                    j++;
                }
            }

        }

        int y=0;
        public void NextB(string str,bool k)
        {
            if (k)
            {
                SearchAll(str, k);
                w = curs;
                if (xs!=null)
                {
                    if (xs.Length > 1)
                    {
                        for (int i = 0; i < xs.Length - 1; i++)
                        {
                            if (xs[i] <= w && xs[i + 1] >= w)
                            {
                                if (w > xs[i])
                                    y = i + 1;
                                else
                                    y = i;
                                y--;
                                break;
                            }
                        }
                    }
                    else
                    {
                        y = -1;
                    }
                }
            }
            textBox1.Focus();
            if (xs == null)
                return;
            y++;
            if (y >= xs.Length)
                y = 0;

            textBox1.Select(xs[y], str.Length);
            
            
        }

        public void PrevB(string str, bool k)
        {
            if (k)
            {
                SearchAll(str, k);
                w = curs;
                if (xs != null)
                {
                    if (xs.Length > 1)
                    {
                        for (int i = 0; i < xs.Length - 1; i++)
                        {
                            if (xs[i] <= w && xs[i + 1] >= w)
                            {
                                if (w < xs[i])
                                    y = i + 1;
                                else
                                    y = i;
                                y++;
                                break;
                            }
                        }
                    }
                    else
                    {
                        y = xs.Length;
                    }
                }
            }
            textBox1.Focus();
            if (xs == null)
                return;
            y--;
            if (y < 0)
                y = xs.Length-1;
            
            textBox1.Select(xs[y], str.Length);
            

        }

        public void FReplace(string a, string b,bool bkl)
        {
            if (bkl)
            {
                textBox1.Select(xs[y], a.Length);
                textBox1.SelectedText = b;
                w = xs[y];
            }
            else
            {
                for(int i = 0; i < xs.Length; i++)
                {
                    textBox1.Select(xs[i], a.Length);
                    textBox1.SelectedText = b;
                }
            }
            textBox1.Modified = true;
        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (переносПоСловамToolStripMenuItem.Checked == false)
            {
                переносПоСловамToolStripMenuItem.Checked = true;
                textBox1.WordWrap = true;
            }
            else
            {
                переносПоСловамToolStripMenuItem.Checked = false;
                textBox1.WordWrap = false;
            }
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //textBox1.Select();
            textBox1.Cut();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = "";
        }

        public void settextbox1(string s)
        {
            textBox1.Text = s;
        }

        bool Search = false;
        bool Replace = false;

        private void SearchForm(object sender, EventArgs e)
        {
            SRForm SR = new SRForm(Search, Replace, this);
            SR.Show();
        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search = true;
            Replace = false;
            SearchForm(sender, e);
        }

        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search = false;
            Replace = true;
            SearchForm(sender, e);
        }

        public void cross(int X)
        {
            textBox1.Focus();
            string str = textBox1.Text;
            int x = 1, y = 0;
            int z = X;
            if (z != 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '\n')
                    {
                        x++;
                        if (x == z)
                        {
                            y = i + 1;
                            break;
                        }

                    }
                }
            }
            textBox1.Select(y, 0);
            
        }

        private void перейтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search = false;
            Replace = false;
            SearchForm(sender, e);
        }

        int curs = 0;
        string curstext = "";

        public string getcurstext()
        {
            return curstext;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            curs = textBox1.SelectionStart;
            curstext = textBox1.SelectedText;
            Aaa1.Text = curs.ToString()+curstext;
        }
    }
}
