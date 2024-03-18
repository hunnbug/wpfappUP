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
        private RibolovnieSnasti2Entities ribalka   = new RibolovnieSnasti2Entities();
        public skladiWindow2()
        {
            InitializeComponent();
            skladiDG2.ItemsSource = ribalka.Sklad.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (address.Text != "" && kolvo.Text != "")
                {
                    var sklad = new Sklad();
                    sklad.Adres = address.Text;
                    sklad.SotrudnikiAmount = Convert.ToInt32(kolvo.Text);
                    ribalka.Sklad.Add(sklad);

                    ribalka.SaveChanges();
                    skladiDG2.ItemsSource = ribalka.Sklad.ToList();    
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
                if (skladiDG2.SelectedItem != null)
                {
                    var selected = skladiDG2.SelectedItem as Sklad;

                    selected.SotrudnikiAmount = Convert.ToInt32(kolvo2.Text);
                    selected.Adres = address2.Text;

                    ribalka.SaveChanges();
                    skladiDG2.ItemsSource = ribalka.Sklad.ToList();
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

        private void DltClick(object sender, RoutedEventArgs e)
        {
            try
            {


                if (skladiDG2.SelectedItem != null)
                {
                    ribalka.Sklad.Remove(skladiDG2.SelectedItem as Sklad);
                    ribalka.SaveChanges();

                    skladiDG2.ItemsSource = ribalka.Sklad.ToList();
                }
            }
            catch
            {
                MessageBox.Show("борода");
            }
        }
    }
}
