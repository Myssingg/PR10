using System;
using System.Collections;
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

namespace BorDer_PR10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> numbers = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddNumber(int.Parse(number.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void number_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    AddNumber(int.Parse(number.Text));
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void AddNumber(int num)
        {
            numbers.Add(num);
            number.Clear();

            listNumbers.Text = "";
            listNumbers.Text = listToString();
        }

        private string listToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in numbers)
            {
                sb.Append(i.ToString() + " ");
            }
            return sb.ToString();
        }

        //Задание (делегаты)
        delegate int deleg(int a, int b);


        //Выбираем тип сортировки
        public int Ascending(int a, int b) => a.CompareTo(b);  // По возрастанию
        public int Descending(int a, int b) => b.CompareTo(a); // По убыванию



        private void sort_Click(object sender, RoutedEventArgs e)
        {
            deleg del = (sortType.SelectedIndex == 0) 
                ? new deleg(Ascending) 
                : new deleg(Descending);

            if (numbers.Count > 0)
            {
                SortingList(del);
                result.Text = listToString();
            }
            else
            {
                MessageBox.Show("Лист с числами пустой!");
                return;
            }
        }

        //Метод сортировки
        void SortingList(deleg sortType)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (sortType(numbers[i], numbers[j]) > 0)
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
        }
    }
}
