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
using Ribalka.pfniuTableAdapters;

namespace Ribalka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SnastiTableAdapter snasti           = new SnastiTableAdapter();
        private SkladTableAdapter skladi            = new SkladTableAdapter();
        private SotrudnikiTableAdapter sotrudnkiki  = new SotrudnikiTableAdapter();
        private RibolovnieSnasti2Entities ribalka   = new RibolovnieSnasti2Entities();
        public MainWindow() 
        {
            InitializeComponent();
        }

        private void skladiButton_Click(object sender, RoutedEventArgs e)
        {
            var window                              = new skladiWindow();
            window.skladiDG.ItemsSource             = skladi.GetData();
            window.Show();
        }

        private void snastiButton_Click(object sender, RoutedEventArgs e)
        {
            var window                              = new snastiWindow();
            window.snastiDG.ItemsSource             = snasti.GetData();
            window.Show();
        }

        private void sotrudnikiButton_Click(object sender, RoutedEventArgs e)
        {
            var window                              = new sotrudnikiWindow();
            window.sotrudnikiDG.ItemsSource         = sotrudnkiki.GetData();
            window.Show();
        }

        private void skladiButton2_Click(object sender, RoutedEventArgs e)
        {
            var window                              = new skladiWindow2();
            window.skladiDG2.ItemsSource            = ribalka.Sklad.ToList();
            window.Show();
        }

        private void snastiButton2_Click(object sender, RoutedEventArgs e)
        {
            var window                              = new snastiWindow2();
            window.snastiDG2.ItemsSource            = ribalka.Snasti.ToList();
            window.Show();
        }

        private void sotrudnikiButton2_Click(object sender, RoutedEventArgs e)
        {
            var window                              = new sotrudnikiWindow2();
            window.sotrudnikiDG2.ItemsSource        = ribalka.Sotrudniki.ToList();
            window.Show();
        }
    }
}
