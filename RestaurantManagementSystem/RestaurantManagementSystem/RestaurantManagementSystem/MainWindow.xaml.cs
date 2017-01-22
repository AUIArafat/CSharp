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
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;
using RestaurantManagementSystem.Service;
using RestaurantManagementSystem.Entity;

namespace RestaurantManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        OpenFileDialog op = new OpenFileDialog();
        private void button1_Click(object sender, RoutedEventArgs e)
        {

            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                image2.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            Person p = new Person();
            p.Name = nameBox.Text;
            //dob.Value().ToString();
            p.Id = idBox.Text;
            p.Image = image2.Source.ToString();
            p.Date = dob.SelectedDate.Value.Date;
            PersonService ps = new PersonService();
            if (ps.Add(p) > 0)
            {
                MessageBox.Show("Added Successfully");
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            (new ExpenseOperation()).ShowDialog();
            this.Hide();
        }
    }
}
