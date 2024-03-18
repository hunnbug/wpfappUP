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
using System.Windows.Shapes;

namespace Ribalka
{
    /// <summary>
    /// Логика взаимодействия для sotrudnikiWindow2.xaml
    /// </summary>
    public partial class sotrudnikiWindow2 : Window
    {
        MainWindow main                             = new MainWindow();
        public sotrudnikiWindow2()
        {
            InitializeComponent();
            sotrudnikiDG2.ItemsSource               = main.ribalka.Sotrudniki.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name.Text != "" && Surname.Text != "" && Middlename.Text != "" && S.Text != "")
                {
                    var sotrudniki = new Sotrudniki();
                    
                    sotrudniki.SotrudnikName        = Name.Text;
                    sotrudniki.SotrudnikSurname     = Surname.Text;
                    sotrudniki.SotrudnikMiddleName  = Middlename.Text;
                    sotrudniki.IDSklad              = Convert.ToInt32(S.Text);
                    main.ribalka.Sotrudniki.Add(sotrudniki);

                    main.ribalka.SaveChanges();
                    sotrudnikiDG2.ItemsSource       = main.ribalka.Sotrudniki.ToList();
                }
                else
                {
                    MessageBox.Show("все поля должны быть не пустыми");
                }
            }
            catch
            {
                MessageBox.Show("борода");
            }
        }

        private void ChngClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sotrudnikiDG2.SelectedItem != null)
                {
                    var selected                    = sotrudnikiDG2.SelectedItem as Sotrudniki;

                    selected.SotrudnikName          = Name2.Text;
                    selected.SotrudnikSurname       = Surname2.Text;
                    selected.SotrudnikMiddleName    = MiddleName2.Text;
                    selected.IDSklad                = Convert.ToInt32(S2.Text);

                    main.ribalka.SaveChanges();
                    sotrudnikiDG2.ItemsSource       = main.ribalka.Sotrudniki.ToList();
                }
                else
                {
                    MessageBox.Show("все поля должны быть не пустыми");
                }
            }
            catch { MessageBox.Show("борода");  }
        }

        private void DltClick(object sender, RoutedEventArgs e)
        {
            try
            {

                if (sotrudnikiDG2.SelectedItem != null)
                {
                    main.ribalka.Sotrudniki.Remove(sotrudnikiDG2.SelectedItem as Sotrudniki);
                    main.ribalka.SaveChanges();

                    sotrudnikiDG2.ItemsSource       = main.ribalka.Sotrudniki.ToList();
                }
            }
            catch
            {
                MessageBox.Show("борода");
            }
        }
    }
}
