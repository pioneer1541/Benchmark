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
using System.Threading;
using System.Windows.Threading;
using System.Runtime.InteropServices;
using System.Collections;


namespace Benchmark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int count;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnCreate_Img(object sender, MouseEventArgs e)
        {
            string[] animal_Array = new string[] { "cows", "deer" };
            Random lucky = new Random();
            int lucky_number = lucky.Next(2);
            string animal_name = animal_Array[lucky_number];
            Point pt = e.GetPosition(bg_rectangle);
            MyClass animal = new MyClass(animal_name, animal_name + count, pt);
            count++;
            bg_rectangle.Children.Add(animal);
        }

        private void btn_removeObj_Click(object sender, RoutedEventArgs e)
        {
            string object_selected = object_list.SelectedItem.ToString();
            string object_key = object_selected.Split(',')[0];
        }
    }

}
