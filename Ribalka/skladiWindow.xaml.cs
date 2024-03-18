using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для skladiWindow.xaml
    /// </summary>
    public partial class skladiWindow : Window
    {
        public skladiWindow()
        {
            InitializeComponent();
        }

        MainWindow main = new MainWindow();
        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (address.Text != "" && kolvo.Text != "")
                {
                    main.skladi.InsertQuery(Convert.ToInt32(kolvo.Text), address.Text as string);
                    skladiDG.ItemsSource = main.skladi.GetData();
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("поле количество должно иметь циферный формат, а ардес - строчный");
            }
        }

        private void ChngClick(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (address2.Text != "" && kolvo2.Text != "" && skladiDG.SelectedItem as DataRowView != null)
                {
                    object Id = (skladiDG.SelectedItem as DataRowView).Row[0];
                    main.skladi.UpdateQuery(Convert.ToInt32(kolvo2.Text), address2.Text, Convert.ToInt32(Id));
                    skladiDG.ItemsSource = main.skladi.GetData();
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("поле количество должно иметь циферный формат, а ардес - строчный");
            }
        }

        private void DltClick(object sender, RoutedEventArgs e)
        {
            if (skladiDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    object id = (skladiDG.SelectedItem as DataRowView).Row[0];
                    main.skladi.DeleteQuery(Convert.ToInt32(id));
                    skladiDG.ItemsSource = main.skladi.GetData();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Поле должно иметь циферный формат");
                }
            }
        }
    }
}
