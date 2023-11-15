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

namespace kornyakovpr7v7
{
    public partial class MainWindow : Window
    {
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Корняков Д.Д \n" + // Информация
             "Практическая работа №7\n" +
             "Использовать класс Triad (тройка чисел). Определить производный класс Date с полями: год, месяц и день." +
             "Определить полный набор методов сравнения дат.");
        }

        Data d1;
        Data d2;

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // Выход
        }

        private void BtSravnenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int day1 = Convert.ToInt32(FirstTr1.Text),
                    day2 = Convert.ToInt32(FirstTr2.Text),

                    month1 = Convert.ToInt32(SecondTr1.Text),
                    month2 = Convert.ToInt32(SecondTr2.Text),

                    year1 = Convert.ToInt32(TherdTr1.Text),
                    year2 = Convert.ToInt32(TherdTr2.Text);

                d1 = new(day1, month1, year1);// объект
                d2 = new(day2, month2, year2);

                int result = Data.CompareDate(d1, d2);

                switch (result)
                {
                    case 1:
                        Sravnenie0.Text = "Первая дата больше, чем вторая.";
                        break;

                    case -1:
                        Sravnenie0.Text = "Первая дата меньше, чем вторая.";
                        break;

                    case 0:
                        Sravnenie0.Text = "Даты равны.";
                        break;
                }
            }
            catch (DataDoesntExistException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException)
            {
                MessageBox.Show("пиши цифры!");
            }
        }

        private void Ochistka_Click(object sender, RoutedEventArgs e)
        {
            FirstTr1.Clear();
            SecondTr1.Clear();
            TherdTr1.Clear();
            FirstTr2.Clear();
            SecondTr2.Clear();
            TherdTr2.Clear();
            Sravnenie0.Clear();
        }
    }
}
