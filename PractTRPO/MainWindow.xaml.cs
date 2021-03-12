using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace PractTRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        SqlConnection sql = new SqlConnection(@"Data Source=LAPTOP-0TM3RTGP\MSSQLSERVER01;Initial Catalog=practTRPO;Integrated Security=True");
        string rezult;
        public void Table_sql()
        {
            try
            {
                sql.Open();
                string zap="Insert into Resh(resh, ID_osn) values ('"+rezult.ToString() + "', '" + Convert.ToInt32(textBoxOsn.Text) + "')";
                SqlDataAdapter apa = new SqlDataAdapter(zap, sql);
                apa.SelectCommand.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Запись добавлена");
            }
            catch (Exception ex)
            {
                sql.Close();
                MessageBox.Show(ex.ToString());
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int osn;
            string first, second;
            try
            {
                osn = Convert.ToInt32(textBoxOsn.Text);
            }
            catch
            {
                bigLabel.Content += "Выберите основание" + "\n";
                return;
            }
            first = Convert.ToString(textBox1.Text);
            second = Convert.ToString(textBox2.Text);
            if (first == "" || second == "")
            {
                bigLabel.Content += "Вы не заполнили поля" + "\n";
                return;
            }
            string final = "";
            int ost = 0;
            int ed = 0;
            int a, b;
            if (first.Length > second.Length)
            {
                for (int i = second.Length; i < first.Length; i++)
                {
                    second = "0" + second;
                }
            }
            else if (second.Length > first.Length)
            {
                for (int i = first.Length; i < second.Length; i++)
                {
                    first = "0" + first;
                }
            }
            for (int i = first.Length - 1; i >= 0; i -= 1)
            {
                if (Convert.ToString(first[i]) == "A" || Convert.ToString(first[i]) == "a")
                {
                    a = 10;
                }
                else if (Convert.ToString(first[i]) == "B" || Convert.ToString(first[i]) == "b")
                {
                    a = 11;
                }
                else if (Convert.ToString(first[i]) == "C" || Convert.ToString(first[i]) == "c")
                {
                    a = 12;
                }
                else if (Convert.ToString(first[i]) == "D" || Convert.ToString(first[i]) == "d")
                {
                    a = 13;
                }
                else if (Convert.ToString(first[i]) == "E" || Convert.ToString(first[i]) == "e")
                {
                    a = 14;
                }
                else if (Convert.ToString(first[i]) == "F" || Convert.ToString(first[i]) == "f")
                {
                    a = 15;
                }
                else
                {
                    a = int.Parse(Convert.ToString(first[i]));
                }
                if (Convert.ToString(second[i]) == "A" || Convert.ToString(second[i]) == "a")
                {
                    b = 10;
                }
                else if (Convert.ToString(second[i]) == "B" || Convert.ToString(second[i]) == "b")
                {
                    b = 11;
                }
                else if (Convert.ToString(second[i]) == "C" || Convert.ToString(second[i]) == "c")
                {
                    b = 12;
                }
                else if (Convert.ToString(second[i]) == "D" || Convert.ToString(second[i]) == "d")
                {
                    b = 13;
                }
                else if (Convert.ToString(second[i]) == "E" || Convert.ToString(second[i]) == "e")
                {
                    b = 14;
                }
                else if (Convert.ToString(second[i]) == "F" || Convert.ToString(second[i]) == "f")
                {
                    b = 15;
                }
                else
                {
                    b = int.Parse(Convert.ToString(second[i]));
                }
                if (a >= osn || b >= osn)
                {
                    bigLabel.Content += "Число(-а) не соответствует(-ют) выбранному основанию" + "\n";
                    return;
                }
                int f = a + b + ed;
                if (f >= osn)
                {
                    ost = f - osn;
                }
                else
                {
                    ost = f;
                }
                ed = (f - ost) / osn;
                if (ost == 10)
                {
                    final = "A" + final;
                }
                else if (ost == 11)
                {
                    final = "B" + final;
                }
                else if (ost == 12)
                {
                    final = "C" + final;
                }
                else if (ost == 13)
                {
                    final = "D" + final;
                }
                else if (ost == 14)
                {
                    final = "E" + final;
                }
                else if (ost == 15)
                {
                    final = "F" + final;
                }
                else
                {
                    final = Convert.ToString(ost) + final;
                }
            }

            if (ed != 0)
            {
                final = Convert.ToString(ed) + final;
            }
            bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "+" + textBox2.Text + "=" + final + "\n";
            rezult = textBox1.Text + "+" + textBox2.Text + "=" + final;
            Table_sql();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int osn;
            string first, second;
            try
            {
                osn = Convert.ToInt32(textBoxOsn.Text);
            }
            catch
            {
                bigLabel.Content += "Выберите основание" + "\n";
                return;
            }
            first = Convert.ToString(textBox1.Text);
            second = Convert.ToString(textBox2.Text);
            if (first == "" || second == "")
            {
                bigLabel.Content += "Вы не заполнили поля" + "\n";
                return;
            }
            string final = "";
            int ost = 0;
            int ed = 0;
            int a, b;
            if (first.Length > second.Length)
            {
                for (int i = second.Length; i < first.Length; i++)
                {
                    second = "0" + second;
                }
            }
            else if (second.Length > first.Length)
            {
                for (int i = first.Length; i < second.Length; i++)
                {
                    first = "0" + first;
                }
            }
            for (int i = first.Length - 1; i >= 0; i -= 1)
            {
                if (Convert.ToString(first[i]) == "A" || Convert.ToString(first[i]) == "a")
                {
                    a = 10;
                }
                else if (Convert.ToString(first[i]) == "B" || Convert.ToString(first[i]) == "b")
                {
                    a = 11;
                }
                else if (Convert.ToString(first[i]) == "C" || Convert.ToString(first[i]) == "c")
                {
                    a = 12;
                }
                else if (Convert.ToString(first[i]) == "D" || Convert.ToString(first[i]) == "d")
                {
                    a = 13;
                }
                else if (Convert.ToString(first[i]) == "E" || Convert.ToString(first[i]) == "e")
                {
                    a = 14;
                }
                else if (Convert.ToString(first[i]) == "F" || Convert.ToString(first[i]) == "f")
                {
                    a = 15;
                }
                else
                {
                    a = int.Parse(Convert.ToString(first[i]));
                }
                if (Convert.ToString(second[i]) == "A" || Convert.ToString(second[i]) == "a")
                {
                    b = 10;
                }
                else if (Convert.ToString(second[i]) == "B" || Convert.ToString(second[i]) == "b")
                {
                    b = 11;
                }
                else if (Convert.ToString(second[i]) == "C" || Convert.ToString(second[i]) == "c")
                {
                    b = 12;
                }
                else if (Convert.ToString(second[i]) == "D" || Convert.ToString(second[i]) == "d")
                {
                    b = 13;
                }
                else if (Convert.ToString(second[i]) == "E" || Convert.ToString(second[i]) == "e")
                {
                    b = 14;
                }
                else if (Convert.ToString(second[i]) == "F" || Convert.ToString(second[i]) == "f")
                {
                    b = 15;
                }
                else
                {
                    b = int.Parse(Convert.ToString(second[i]));
                }
                if (a >= osn || b >= osn)
                {
                    bigLabel.Content += "Число(-а) не соответствует(-ют) выбранному основанию" + "\n";
                    return;
                }
                if (a < b)
                {
                    ost = a - b + osn;
                    ed = -1;
                }
                else
                {
                    ost = a - b + ed;
                    ed = 0;
                }
                if (ost == 10)
                {
                    final = "A" + final;
                }
                else if (ost == 11)
                {
                    final = "B" + final;
                }
                else if (ost == 12)
                {
                    final = "C" + final;
                }
                else if (ost == 13)
                {
                    final = "D" + final;
                }
                else if (ost == 14)
                {
                    final = "E" + final;
                }
                else if (ost == 15)
                {
                    final = "F" + final;
                }
                else
                {
                    final = Convert.ToString(ost) + final;
                }
            }
            if (ed != 0)
            {
                final = Convert.ToString(ed) + final;
            }
            int j = 0;
            for (int i = 0; i < final.Length - 1; i++)
            {
                if (Convert.ToString(final[0]) == "0")
                {
                    j++;
                }
                else
                {
                    i = final.Length;
                }
            }
            bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "-" + textBox2.Text + "=" + final.Substring(j) + "\n";
            rezult = textBox1.Text + "-" + textBox2.Text + "=" + final.Substring(j);
            Table_sql();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int osn;
            string first, second;
            try
            {
                osn = Convert.ToInt32(textBoxOsn.Text);
            }
            catch
            {
                bigLabel.Content += "Выберите основание" + "\n";
                return;
            }
            first = Convert.ToString(textBox1.Text);
            second = Convert.ToString(textBox2.Text);
            if (first == "" || second == "")
            {
                bigLabel.Content += "Вы не заполнили поля" + "\n";
                return;
            }
            string final = "";
            int ost = 0;
            int ed = 0;
            int a, b;
            if (first.Length > second.Length)
            {
                for (int i = second.Length; i < first.Length; i++)
                {
                    second = "0" + second;
                }
            }
            else if (second.Length > first.Length)
            {
                for (int i = first.Length; i < second.Length; i++)
                {
                    first = "0" + first;
                }
            }
            if (first.Length == 1 && second.Length == 1)
            {
                first = "0" + first;
                second = "0" + second;
            }
            for (int i = first.Length - 1; i > 0; i -= 1)
            {
                if (Convert.ToString(first[i]) == "A" || Convert.ToString(first[i]) == "a")
                {
                    a = 10;
                }
                else if (Convert.ToString(first[i]) == "B" || Convert.ToString(first[i]) == "b")
                {
                    a = 11;
                }
                else if (Convert.ToString(first[i]) == "C" || Convert.ToString(first[i]) == "c")
                {
                    a = 12;
                }
                else if (Convert.ToString(first[i]) == "D" || Convert.ToString(first[i]) == "d")
                {
                    a = 13;
                }
                else if (Convert.ToString(first[i]) == "E" || Convert.ToString(first[i]) == "e")
                {
                    a = 14;
                }
                else if (Convert.ToString(first[i]) == "F" || Convert.ToString(first[i]) == "f")
                {
                    a = 15;
                }
                else
                {
                    a = int.Parse(Convert.ToString(first[i]));
                }
                if (Convert.ToString(second[i]) == "A" || Convert.ToString(second[i]) == "a")
                {
                    b = 10;
                }
                else if (Convert.ToString(second[i]) == "B" || Convert.ToString(second[i]) == "b")
                {
                    b = 11;
                }
                else if (Convert.ToString(second[i]) == "C" || Convert.ToString(second[i]) == "c")
                {
                    b = 12;
                }
                else if (Convert.ToString(second[i]) == "D" || Convert.ToString(second[i]) == "d")
                {
                    b = 13;
                }
                else if (Convert.ToString(second[i]) == "E" || Convert.ToString(second[i]) == "e")
                {
                    b = 14;
                }
                else if (Convert.ToString(second[i]) == "F" || Convert.ToString(second[i]) == "f")
                {
                    b = 15;
                }
                else
                {
                    b = int.Parse(Convert.ToString(second[i]));
                }
                if (a >= osn || b >= osn)
                {
                    bigLabel.Content += "Число(-а) не соответствует(-ют) выбранному основанию" + "\n";
                    return;
                }
                string two = "";
                for (int o = second.Length - 1; o >= 0; --o)
                {
                    string one = "";
                    for (int O = first.Length - 1; O >= 0; --O)
                    {
                        ost = int.Parse(first[O].ToString()) * int.Parse(second[o].ToString()) + ed;
                        while (ost >= osn)
                        {
                            ost -= osn;
                            ed++;
                        }
                        if (ost == 10)
                        {
                            one = "A" + one;
                        }
                        else if (ost == 11)
                        {
                            one = "B" + one;
                        }
                        else if (ost == 12)
                        {
                            one = "C" + one;
                        }
                        else if (ost == 13)
                        {
                            one = "D" + one;
                        }
                        else if (ost == 14)
                        {
                            one = "E" + one;
                        }
                        else if (ost == 15)
                        {
                            one = "F" + one;
                        }
                        else
                        {
                            one = Convert.ToString(ost) + one;
                        }
                    }
                    int u = o;
                    while (u < second.Length - 1)
                    {
                        one += "0";
                        u++;
                    }
                    if (two != "")
                    {
                        ost = 0;
                        ed = 0;
                        if (one.Length > two.Length)
                        {
                            for (int v = two.Length; v < one.Length; v++)
                            {
                                two = "0" + two;
                            }
                        }
                        else if (two.Length > one.Length)
                        {
                            for (int v = one.Length; v < two.Length; v++)
                            {
                                one = "0" + one;
                            }
                        }
                        for (int y = one.Length - 1; y >= 0; y -= 1)
                        {
                            if (Convert.ToString(one[y]) == "A" || Convert.ToString(one[y]) == "a")
                            {
                                a = 10;
                            }
                            else if (Convert.ToString(one[y]) == "B" || Convert.ToString(one[y]) == "b")
                            {
                                a = 11;
                            }
                            else if (Convert.ToString(one[y]) == "C" || Convert.ToString(one[y]) == "c")
                            {
                                a = 12;
                            }
                            else if (Convert.ToString(one[y]) == "D" || Convert.ToString(one[y]) == "d")
                            {
                                a = 13;
                            }
                            else if (Convert.ToString(one[y]) == "E" || Convert.ToString(one[y]) == "e")
                            {
                                a = 14;
                            }
                            else if (Convert.ToString(one[y]) == "F" || Convert.ToString(one[y]) == "f")
                            {
                                a = 15;
                            }
                            else
                            {
                                a = int.Parse(Convert.ToString(one[y]));
                            }
                            if (Convert.ToString(two[y]) == "A" || Convert.ToString(two[y]) == "a")
                            {
                                b = 10;
                            }
                            else if (Convert.ToString(two[y]) == "B" || Convert.ToString(two[y]) == "b")
                            {
                                b = 11;
                            }
                            else if (Convert.ToString(two[y]) == "C" || Convert.ToString(two[y]) == "c")
                            {
                                b = 12;
                            }
                            else if (Convert.ToString(two[y]) == "D" || Convert.ToString(two[y]) == "d")
                            {
                                b = 13;
                            }
                            else if (Convert.ToString(two[y]) == "E" || Convert.ToString(two[y]) == "e")
                            {
                                b = 14;
                            }
                            else if (Convert.ToString(two[y]) == "F" || Convert.ToString(two[y]) == "f")
                            {
                                b = 15;
                            }
                            else
                            {
                                b = int.Parse(Convert.ToString(two[y]));
                            }
                            int f = a + b + ed;
                            if (f >= osn)
                            {
                                ost = f - osn;
                            }
                            else
                            {
                                ost = f;
                            }
                            ed = (f - ost) / osn;
                            if (ost == 10)
                            {
                                final = "A" + final;
                            }
                            else if (ost == 11)
                            {
                                final = "B" + final;
                            }
                            else if (ost == 12)
                            {
                                final = "C" + final;
                            }
                            else if (ost == 13)
                            {
                                final = "D" + final;
                            }
                            else if (ost == 14)
                            {
                                final = "E" + final;
                            }
                            else if (ost == 15)
                            {
                                final = "F" + final;
                            }
                            else
                            {
                                final = Convert.ToString(ost) + final;
                            }
                        }
                        two = final;
                    }
                    else
                    {
                        two = one;
                    }
                }
                final = two;
            }
            if (ed != 0)
            {
                final = Convert.ToString(ed) + final;
            }
            int j = 0;
            if (Convert.ToString(final[0]) == "0")
            {
                j++;
            }
            bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "*" + textBox2.Text + "=" + final.Substring(j) + "\n";
            rezult = textBox1.Text + "*" + textBox2.Text + "=" + final.Substring(j);
            Table_sql();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string first = Convert.ToString(textBox1.Text);
            string second = Convert.ToString(textBox2.Text);
            if (first == "" || second == "")
            {
                bigLabel.Content += "Вы не заполнили поля" + "\n";
                return;
            }
            string final = "";
            int ost = 0, ed = 0, a, b, osn;
            try
            {
                osn = Convert.ToInt32(textBoxOsn.Text);
            }
            catch
            {
                bigLabel.Content += "Выберите основание" + "\n";
                return;
            }
            if (int.Parse(Convert.ToString(second)) == 0)
            {
                bigLabel.Content += "Нельзя делить на нуль" + "\n";
                return;
            }
            else if (int.Parse(Convert.ToString(first)) == 0)
            {
                bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "/" + textBox2.Text + "=" + "0" + "\n";
                return;
            }
            else if (first.Length < second.Length)
            {
                bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "/" + textBox2.Text + "=" + "0" + "\n";
                return;
            }
            else
            {
                string one = first.Substring(0, second.Length);
                int fin = 0;
                while (one.Length >= second.Length)
                {
                    for (int i = one.Length - 1; i >= 0; --i)
                    {
                        if (Convert.ToString(one[i]) == "A" || Convert.ToString(one[i]) == "a")
                        {
                            a = 10;
                        }
                        else if (Convert.ToString(one[i]) == "B" || Convert.ToString(one[i]) == "b")
                        {
                            a = 11;
                        }
                        else if (Convert.ToString(one[i]) == "C" || Convert.ToString(one[i]) == "c")
                        {
                            a = 12;
                        }
                        else if (Convert.ToString(one[i]) == "D" || Convert.ToString(one[i]) == "d")
                        {
                            a = 13;
                        }
                        else if (Convert.ToString(one[i]) == "E" || Convert.ToString(one[i]) == "e")
                        {
                            a = 14;
                        }
                        else if (Convert.ToString(one[i]) == "F" || Convert.ToString(one[i]) == "f")
                        {
                            a = 15;
                        }
                        else
                        {
                            a = int.Parse(Convert.ToString(one[i]));
                        }
                        if (Convert.ToString(second[i]) == "A" || Convert.ToString(second[i]) == "a")
                        {
                            b = 10;
                        }
                        else if (Convert.ToString(second[i]) == "B" || Convert.ToString(second[i]) == "b")
                        {
                            b = 11;
                        }
                        else if (Convert.ToString(second[i]) == "C" || Convert.ToString(second[i]) == "c")
                        {
                            b = 12;
                        }
                        else if (Convert.ToString(second[i]) == "D" || Convert.ToString(second[i]) == "d")
                        {
                            b = 13;
                        }
                        else if (Convert.ToString(second[i]) == "E" || Convert.ToString(second[i]) == "e")
                        {
                            b = 14;
                        }
                        else if (Convert.ToString(second[i]) == "F" || Convert.ToString(second[i]) == "f")
                        {
                            b = 15;
                        }
                        else
                        {
                            b = int.Parse(Convert.ToString(second[i]));
                        }
                        if (a >= osn || b >= osn)
                        {
                            bigLabel.Content += "Число(-а) не соответствует(-ют) выбранному основанию" + "\n";
                            return;
                        }
                        if (a < b)
                        {
                            ost = a - b + osn;
                            ed = -1;
                        }
                        else
                        {
                            
                            ost = a - b + ed;
                            ed = 0;
                        }
                        if (ost == 10)
                        {
                            final = "A" + final;
                        }
                        else if (ost == 11)
                        {
                            final = "B" + final;
                        }
                        else if (ost == 12)
                        {
                            final = "C" + final;
                        }
                        else if (ost == 13)
                        {
                            final = "D" + final;
                        }
                        else if (ost == 14)
                        {
                            final = "E" + final;
                        }
                        else if (ost == 15)
                        {
                            final = "F" + final;
                        }
                        else
                        {
                            final = Convert.ToString(ost) + final;
                        }
                    }
                    fin++;
                    int j=0;
                    for (int i = 0; i < final.Length - 1; i++)
                    {
                        if (Convert.ToString(final[0]) == "0")
                        {
                            j++;
                        }
                        else
                        {
                            i = final.Length;
                        }
                    }
                    one = final.Substring(j);
                    final = "";
                }
                bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "/" + textBox2.Text + "=" + fin + "\n";
                rezult = textBox1.Text + "/" + textBox2.Text + "=" + fin;
                Table_sql();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
                string first = Convert.ToString(textBox1.Text);
                string second = Convert.ToString(textBox2.Text);
                if (first == "" || second == "")
                {
                    bigLabel.Content += "Вы не заполнили поля" + "\n";
                    return;
                }
                string final = "";
                int ost = 0, ed = 0, a, b, osn;
                try
                {
                    osn = Convert.ToInt32(textBoxOsn.Text);
                }
                catch
                {
                    bigLabel.Content += "Выберите основание" + "\n";
                    return;
                }
                if (int.Parse(Convert.ToString(second)) == 0)
                {
                    bigLabel.Content += "Нельзя делить на нуль" + "\n";
                    return;
                }
                else if (int.Parse(Convert.ToString(first)) == 0)
                {
                    bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "/" + textBox2.Text + "=" + "0" + "\n";
                    return;
                }
                else if (first.Length < second.Length)
                {
                    bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "/" + textBox2.Text + "=" + "0" + "\n";
                    return;
                }
                else
                {
                    string one = first.Substring(0, second.Length);
                    int fin = 0;
                    while (one.Length >= second.Length)
                    {
                        for (int i = one.Length - 1; i >= 0; --i)
                        {
                            if (Convert.ToString(one[i]) == "A" || Convert.ToString(one[i]) == "a")
                            {
                                a = 10;
                            }
                            else if (Convert.ToString(one[i]) == "B" || Convert.ToString(one[i]) == "b")
                            {
                                a = 11;
                            }
                            else if (Convert.ToString(one[i]) == "C" || Convert.ToString(one[i]) == "c")
                            {
                                a = 12;
                            }
                            else if (Convert.ToString(one[i]) == "D" || Convert.ToString(one[i]) == "d")
                            {
                                a = 13;
                            }
                            else if (Convert.ToString(one[i]) == "E" || Convert.ToString(one[i]) == "e")
                            {
                                a = 14;
                            }
                            else if (Convert.ToString(one[i]) == "F" || Convert.ToString(one[i]) == "f")
                            {
                                a = 15;
                            }
                            else
                            {
                                a = int.Parse(Convert.ToString(one[i]));
                            }
                            if (Convert.ToString(second[i]) == "A" || Convert.ToString(second[i]) == "a")
                            {
                                b = 10;
                            }
                            else if (Convert.ToString(second[i]) == "B" || Convert.ToString(second[i]) == "b")
                            {
                                b = 11;
                            }
                            else if (Convert.ToString(second[i]) == "C" || Convert.ToString(second[i]) == "c")
                            {
                                b = 12;
                            }
                            else if (Convert.ToString(second[i]) == "D" || Convert.ToString(second[i]) == "d")
                            {
                                b = 13;
                            }
                            else if (Convert.ToString(second[i]) == "E" || Convert.ToString(second[i]) == "e")
                            {
                                b = 14;
                            }
                            else if (Convert.ToString(second[i]) == "F" || Convert.ToString(second[i]) == "f")
                            {
                                b = 15;
                            }
                            else
                            {
                                b = int.Parse(Convert.ToString(second[i]));
                            }
                            if (a >= osn || b >= osn)
                            {
                                bigLabel.Content += "Число(-а) не соответствует(-ют) выбранному основанию" + "\n";
                                return;
                            }
                            if (a < b)
                            {
                                ost = a - b + osn;
                                ed = -1;
                            }
                            else
                            {

                                ost = a - b + ed;
                                ed = 0;
                            }
                            if (ost == 10)
                            {
                                final = "A" + final;
                            }
                            else if (ost == 11)
                            {
                                final = "B" + final;
                            }
                            else if (ost == 12)
                            {
                                final = "C" + final;
                            }
                            else if (ost == 13)
                            {
                                final = "D" + final;
                            }
                            else if (ost == 14)
                            {
                                final = "E" + final;
                            }
                            else if (ost == 15)
                            {
                                final = "F" + final;
                            }
                            else
                            {
                                final = Convert.ToString(ost) + final;
                            }
                        }
                        fin++;
                        int j = 0;
                        for (int i = 0; i < final.Length - 1; i++)
                        {
                            if (Convert.ToString(final[0]) == "0")
                            {
                                j++;
                            }
                            else
                            {
                                i = final.Length;
                            }
                        }
                        one = final.Substring(j);
                        final = "";
                    }
                    bigLabel.Content += textBoxOsn.Text + ":" + textBox1.Text + "/" + textBox2.Text + "=" + one + "\n";
                rezult = textBox1.Text + "/" + textBox2.Text + "=" + one;
                Table_sql();
            }
            }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            bigLabel.Content = "Журнал решений:" + "\n";
        }
    }
}
