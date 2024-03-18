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
    /// Логика взаимодействия для snastiWindow.xaml
    /// </summary>
    public partial class snastiWindow : Window
    {
        public snastiWindow()
        {
            InitializeComponent();
            snastiDG.ItemsSource = main.snasti.GetData();
        }
        MainWindow main = new MainWindow();
        private void ChngClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name2.Text != "" && Cvet2.Text != "" && Type2.Text != "" && Razmer2.Text != "" && snastiDG.SelectedItem as DataRowView != null)
                {
                    object Id = (snastiDG.SelectedItem as DataRowView).Row[0];
                    main.snasti.UpdateQuery(Name2.Text, Cvet2.Text, Type2.Text, Razmer2.Text, Convert.ToInt32(Id));
                    snastiDG.ItemsSource = main.snasti.GetData();
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Поля названий должны быть строчными, а айди - циферным");
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name.Text != "" && Cvet.Text != "" && Type.Text != "" && Razmer.Text != "" && Sklad.Text !="")
                {
                    main.snasti.InsertQuery(Name.Text, Cvet.Text, Type.Text, Razmer.Text, Convert.ToInt32(Sklad.Text));
                    snastiDG.ItemsSource = main.snasti.GetData();
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

        private void DltClick(object sender, RoutedEventArgs e)
        {
            if (snastiDG.SelectedItem as DataRowView != null)
            {
                try
                {
                    object id = (snastiDG.SelectedItem as DataRowView).Row[0];
                    main.snasti.DeleteQuery(Convert.ToInt32(id));
                    snastiDG.ItemsSource = main.snasti.GetData();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Поле должно иметь циферный формат");
                }
            }
        }
    }
}
