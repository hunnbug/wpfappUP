using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для snastiWindow2.xaml
    /// </summary>
    public partial class snastiWindow2 : Window
    {
        MainWindow main                                 = new MainWindow();
        public snastiWindow2()
        {
            InitializeComponent();
            snastiDG2.ItemsSource                       = main.ribalka.Snasti.ToList();
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name.Text != "" && Cvet.Text != "" && Type.Text != "" && Razmer.Text != "" && Sklad.Text != "")
                {
                    var snasti                          = new Snasti();
                    snasti.SnastName                    = Name.Text;
                    snasti.Cvet                         = Cvet.Text;
                    snasti.TypeOfSnast                  = Type.Text;
                    snasti.Razmer                       = Razmer.Text;
                    snasti.IDSklad                      = Convert.ToInt32(Sklad.Text);
                    main.ribalka.Snasti.Add(snasti);

                    main.ribalka.SaveChanges();
                    snastiDG2.ItemsSource = main.ribalka.Snasti.ToList();
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
                if (snastiDG2.SelectedItem != null)
                {
                    var selected = snastiDG2.SelectedItem as Snasti;

                    selected.SnastName                  = Name2.Text;
                    selected.Cvet                       = Cvet2.Text;
                    selected.TypeOfSnast                = Type2.Text;
                    selected.Razmer                     = Razmer2.Text;
                    selected.IDSklad                    = Convert.ToInt32(Sklad2.Text);

                    main.ribalka.SaveChanges();
                    snastiDG2.ItemsSource = main.ribalka.Snasti.ToList();
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
                if (snastiDG2.SelectedItem != null)
                {
                    main.ribalka.Snasti.Remove(snastiDG2.SelectedItem as Snasti);
                    main.ribalka.SaveChanges();

                    snastiDG2.ItemsSource               = main.ribalka.Snasti.ToList();
                }
            }
            catch { MessageBox.Show("борода"); }
        }
    }
}
