using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для sotrudnikiWindow.xaml
    /// </summary>
    public partial class sotrudnikiWindow : Window
    {
        public sotrudnikiWindow()
        {
            InitializeComponent();
            sotrudnikiDG.ItemsSource = main.sotrudnkiki.GetData();
        }

        MainWindow main = new MainWindow();
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (N.Text != "" && F.Text != "" && O.Text != "" && S.Text != "")
                {
                    main.sotrudnkiki.InsertQuery(N.Text, O.Text, F.Text, Convert.ToInt32(S.Text));
                    sotrudnikiDG.ItemsSource = main.sotrudnkiki.GetData();
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("поля имени должны иметь строчный тип, а айди - циферный");
            }
        }

        private void ChngClick(object sender, RoutedEventArgs e)
        {
            if (N2.Text != "" && F2.Text != "" && O2.Text != "" && S2.Text != "" && sotrudnikiDG.SelectedItem as DataRowView != null)
            {
                object id = (sotrudnikiDG.SelectedItem as DataRowView).Row[0];
                main.sotrudnkiki.UpdateQuery(N2.Text, F2.Text, O2.Text, Convert.ToInt32(S2.Text), Convert.ToInt32(id));
                sotrudnikiDG.ItemsSource = main.sotrudnkiki.GetData();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }

        private void DltClick(object sender, RoutedEventArgs e)
        {
            if (sotrudnikiDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    object id = (sotrudnikiDG.SelectedItem as DataRowView).Row[0];
                    main.sotrudnkiki.DeleteQuery(Convert.ToInt32(id));
                    sotrudnikiDG.ItemsSource = main.sotrudnkiki.GetData();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Поле должно иметь циферный формат");
                }
            }
        }
    }
}
