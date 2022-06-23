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
        string ver = "4.8";
        string au = "Rud";
        public Form1()
        {
            InitializeComponent();
            Init();
            textBoxX.Text = "None";
        }

        private void Init()
        {
            textBox1.Multiline = true; // разрешаем многострочный текст
                                       // textBox1 занимает всю свободную поверхность форм
            textBox1.ReadOnly = false;
            textBox1.Dock = DockStyle.Fill; // Заполнить всю прогрмму textBox1
            // включаем вертикальную и горизонтальную полосы прокрутки
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.WordWrap = false; // запрещаем перенос строк
            textBox1.Clear();
            this.Text = "Безымянный" + name;
            // Для открытия, сохранения файла
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            // Версия программы
            toolStripTextBox1.Text = "v " + ver;
            toolStripTextBox1.ReadOnly = true;
            textBoxX.ReadOnly = true;
        }
        string stropenfile = ""; // Нужен для запоминания текста у отркытого файла.
        string name = " - Notepad 3000";

        public Form1(string s)
        {
            InitializeComponent();
            if (s.IndexOf("ze")!=-1)
                textBoxX.Text = s;
            else
                textBoxX.Text = "None";
            Init();
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
                textBox1.Modified = false;
            }
            catch (System.Exception Ситуация)
            { // Отчет обо всех возможных ошибках
                MessageBox.Show(Ситуация.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            }
        }


        // Обработчик события FormClosing формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // Срабатывает, когда мы будем закрывать файл.
        {
            if (textBox1.Modified == false || stropenfile==textBox1.Text) return; // Если текст модифицирован, то спросить, записывать ли файл
            DialogResult MBox = MessageBox.Show("Текст был изменен.\nСохранить изменения?",
            "Простой редактор", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            // YES — диалог; NO — выход; CANCEL — редактировать
            if (MBox == DialogResult.No) return;
            if (MBox == DialogResult.Cancel) e.Cancel = true;
            if (MBox == DialogResult.Yes)
            {
                if (openFileDialog1.FileName == "") // Если ранее не сохраняли - открывается окно для сохранения
                    if (saveFileDialog1.FileName == "")
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
                this.Text = openFileDialog1.FileName + name;
                // здесь заказ кодовой страницы Winl251 для русских букв
                textBox1.Text = Читатель.ReadToEnd();
                stropenfile = textBox1.Text;
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
            //saveFileDialog1.FileName = openFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) Запись();
            this.Text = openFileDialog1.FileName + name;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e) // Закрыват редактор.
        {
            this.Close();
        }

        private FontDialog fnt = new FontDialog(); // Окно шрифта
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e) // Вызываем диалогове окно для шрифта и если нажат "ОК" - вытаскиваем шрифт.
        {
            if (fnt.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fnt.Font;
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e) // Очистить textBox1
        {
            if (au.IndexOf("ze") != -1)
                au += "ze";
            textBox1.Clear();
            textBox1.Modified = false;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) // Обычное сохранение
        {
            if (openFileDialog1.FileName == "")
            {
                if (saveFileDialog1.FileName == "")
                    сохранитьКакToolStripMenuItem_Click_1(sender, e); // Если у нас файл не был ранее сохранен/открыт - вызывается окно
            }
            else
                saveFileDialog1.FileName = openFileDialog1.FileName;
            Запись();
            this.Text = openFileDialog1.SafeFileName + name;
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textModified = true;
            textBox1.Paste();
        }


        int w = 0; // Количество совпадающих результатов поиска
        int[] xs=null; // Содержит номер начала каждого результата

        private void SearchAll(string str)
        {
            w = 0; // Результатов 0
            if (xs != null) // Если ранее был поиск - очищаем
            {
                xs = null;
            }
            textBox1.Focus();

            string a = str;
            string search_2 = textBox1.Text; // Вытаскиваем текст
            int b = search_2.IndexOf(a); // Ищем первое вхождение

            if (b == -1)
                w = -1;
            while (b != -1) // Ищем, пока закончится поиск
            {
                w++; // Увеличиваем количество найденных

                search_2 = search_2.Remove(b, 1); // Удаляем 1-й символ найденного результата
                search_2 = search_2.Insert(b, ((char)4).ToString()); // И вставляем туда иной символ

                b = search_2.IndexOf(a); // Теперь 1-й результат поиска изменен и первое вхождение - 2-й результат поиска
            }
            if (w > 0) // Если поиск был успешным
            {
                xs = new int[w]; // Создаем массив для результатов
                int j = 0;
                // Далее похоже как было выше
                search_2 = textBox1.Text;
                b = search_2.IndexOf(a);

                while (b != -1)
                {
                    search_2 = search_2.Remove(b, 1);
                    search_2 = search_2.Insert(b, ((char)4).ToString());

                    xs[j] = b; // Записываем начало каждого результата. Пример: ищем "как" в тексте "как, так как". Массив будет [0,10]
                    b = search_2.IndexOf(a);
                    j++;
                }
            }

        }

        bool textModified = true;
        int y=0;
        public void NextB(string str,bool k)
        {
            if (k || textModified) // Если текст поиска или текст файла был изменен, то нужно обновить массив элементов поиска xs
            {
                textModified = false;
                SearchAll(str); // Создает массив xs
                int ww = curs;
                if (xs!=null)
                {
                    if (xs.Length > 1)
                    {
                        for (int i = 0; i < xs.Length - 1; i++) // Ищем, какое слово выделить первым - на каком месте у нас находился курсор до поиска
                        {
                            if (xs[i] <= ww && xs[i + 1] >= ww) // Если нашли, что курсор между двумя найденными словами
                            {
                                if (ww > xs[i])
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
            if (xs == null) // Если поиск дал 0 результатов
            {
                textBox1.Select(curs, 0);
                return;
            }
                // сдвиг вперед
            y++;
            if (y >= xs.Length)
                y = 0;

            textBox1.Select(xs[y], str.Length);
            
            
        }

        public void PrevB(string str, bool k)
        {
            if (k || textBox1.Modified)
            {
                textBox1.Modified = false;
                SearchAll(str);
                int ww = curs;
                if (xs != null)
                {
                    if (xs.Length > 1)
                    {
                        for (int i = 0; i < xs.Length - 1; i++)
                        {
                            if (xs[i] <= ww && xs[i + 1] >= ww)
                            {
                                if (ww < xs[i])
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
            {
                textBox1.Select(curs, 0);
                return;
            }

            // сдвиг назад
            y--;
            if (y < 0)
                y = xs.Length-1;
            
            textBox1.Select(xs[y], str.Length);
            

        }

        public void FReplace(string a, string b,bool bkl,bool bk) // Заменить и Заменить все
        {
            textModified = true;
            if (w == 0 || bk) // Поиск дал 0 результатов или же поиска не было
            {
                NextB(a,true);
            }
            if (w != -1)
            {
                if (bkl) // Заменить
                {
                    textBox1.Select(xs[y], a.Length);
                    textBox1.SelectedText = b;
                    NextB(a, true);
                }
                else
                {
                    int ww = w;
                    for(int i=xs.Length-1;i>=0;i--) // Заменить все, начинаем сзади
                    {
                        textBox1.Select(xs[i], a.Length);
                        textBox1.SelectedText = b;
                        
                        NextB(a, true);
                    }
                }

                textBox1.Modified = true;
            }
            else
            {
                return;
            }
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
            Form1 fr = new Form1(au+"ris");
            fr.Show();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textModified = true;
            textBox1.Cut();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textModified = true;
            textBox1.SelectedText = "";
        }

        // Для окна поиска
        bool Search = false;
        bool Replace = false;
        SRForm SR = null;

        private void SearchForm(object sender, EventArgs e) // Создается новая форма
        {
            if (SR == null)
            {
                SR = new SRForm(Search, Replace, this);
                SR.Show();
            }
            else
            {
                SR.Close();
                SR = new SRForm(Search, Replace, this);
                SR.Show();
            }

        }

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search = true;
            Replace = false;
            SearchForm(sender, e);
        }

        private void заменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textModified = true;
            Search = false;
            Replace = true;
            SearchForm(sender, e);
        }

        public void cross(int X) // Перейти на указанную строку
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

        private void textBox1_TextChanged(object sender, EventArgs e) // Если изменяется основной текст
        {
            textModified = true;
            //search_1 = "";
            w = 0;
            xs = null;
            curs = textBox1.SelectionStart;
            curstext = textBox1.SelectedText;
            //Aaa1.Text = curs.ToString()+curstext;
        }
        string search_1 = "";

        public void setsearch(string b)
        {
            search_1 = b;
        }

        private void найтиДалееToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            Search = true;
            //Aaa1.Text = search_1;
            // Если мы не задали, что нужно искать - создаем окно поиска, если у нас что-то есть - используем NextB
            if (SR != null)
            {
                if (search_1 != "")
                {

                    if (w == 0)
                        NextB(search_1, true);
                    else
                        if (w > 0)
                    {
                        NextB(search_1, false);
                    }
                    else
                    {
                        SR = null;
                        SearchForm(sender, e);
                    }
                }
                else
                {
                    SR = null;
                    SearchForm(sender, e);
                }
            }
            else
            {
                SearchForm(sender, e);
            }
        }

        private void найтиРанееToolStripMenuItem_Click(object sender, EventArgs e) // Так же как выше
        {
            Search = true;
            if (SR != null)
            {
                if (search_1 != "")
                {

                    if (w == 0)
                        PrevB(search_1, true);
                    else
                        if (w > 0)
                    {
                        PrevB(search_1, false);
                    }
                    else
                    {
                        SR = null;
                        SearchForm(sender, e);
                    }
                }
                else
                {
                    SR = null;
                    SearchForm(sender, e);
                }
            }
            else
            {
                SearchForm(sender, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textModified = true;
            w = 0;
            xs = null;
        }
    }
}
