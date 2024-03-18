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
    /// Логика взаимодействия для skladiWindow2.xaml
    /// </summary>
    public partial class skladiWindow2 : Window
    {
        MainWindow main                             = new MainWindow();
        public skladiWindow2()
        {
            InitializeComponent();
            skladiDG2.ItemsSource                   = main.ribalka.Snasti.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (address.Text != "" && kolvo.Text != "")
                {
                    var sklad                       = new Sklad();
                    sklad.Adres                     = address.Text;
                    sklad.SotrudnikiAmount          = Convert.ToInt32(kolvo.Text);
                    main.ribalka.Sklad.Add(sklad);

                    main.ribalka.SaveChanges();
                    skladiDG2.ItemsSource           = main.ribalka.Sklad.ToList();    
                }
                else
                {
                    MessageBox.Show("все поля должны быть не пустыми");
                }
            }
            catch { MessageBox.Show("борода"); }
        }

        private void ChngClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (skladiDG2.SelectedItem != null)
                {
                    var selected = skladiDG2.SelectedItem as Sklad;

                    selected.SotrudnikiAmount       = Convert.ToInt32(kolvo2.Text);
                    selected.Adres                  = address2.Text;

                    main.ribalka.SaveChanges();
                    skladiDG2.ItemsSource           = main.ribalka.Sklad.ToList();
                }
                else
                {
                    MessageBox.Show("все поля должны быть не пустыми");
                }
            }
            catch { MessageBox.Show("борода"); }
        }

        private void DltClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (skladiDG2.SelectedItem != null)
                {
                    main.ribalka.Sklad.Remove(skladiDG2.SelectedItem as Sklad);
                    main.ribalka.SaveChanges();

                    skladiDG2.ItemsSource           = main.ribalka.Sklad.ToList();
                }
            }
            catch { MessageBox.Show("борода"); }
        }
    }
}
