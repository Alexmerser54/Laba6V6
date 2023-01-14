using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Laba6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text;
            richTextBox1.Text = ""; // очистить поле ввода/вывода

            string[] sentcs = input.Split(new string[] { ". " }, StringSplitOptions.RemoveEmptyEntries); // разбить строку на предожения с удалением пустых элементов
            foreach (var item in sentcs) // перебор предложений
            {
                if (!item.Contains(",")) // если в предложении нет запятой
                    richTextBox1.Text += item + ". "; // добавляем предложение в поле и в конце ставим запятую с пробелом
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = richTextBox2.Text;

            Regex regex = new Regex(@"\([^)]*\)", RegexOptions.IgnoreCase); // открывающаяся скбока, затем все, кроме закрывающейся скбоки, затем сама скбока
            richTextBox2.Text = regex.Replace(input, ""); // удаление нахождений
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int height; // рост
            string input = richTextBox3.Text;
            richTextBox3.Text = ""; // очистить поле ввода 

            Regex regex = new Regex(@"\d*\s(см)"); // шаблон поиска записи роста
            Regex regex2 = new Regex(@"\d*"); // шаблон поиска числа

            foreach (var item in input.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)) // разбить ввод на строки без учёта пустой строки
            {
                string founded = regex.Match(item).ToString(); // вытаскиваем рост из записи
                height = Convert.ToInt32(regex2.Match(founded).ToString()); // ищем число в записи, преобразовываем найденную строку в int и записываем в переменную
                if (height > 190) richTextBox3.Text += item + "\n"; // выводим рост если он больше 190
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"(\s)не(\s|\.)", RegexOptions.IgnoreCase); // любой цифро-буквенный сивол, частица "не", после любой цифро-буквенный символ или точка
            int count = regex.Matches(" " + richTextBox4.Text).Count; // слева добавляется пробел, чтобы в начале был любой цифро-буквенный символ
            richTextBox4.Text = count.ToString(); // вывод количества
        }
    }
}
