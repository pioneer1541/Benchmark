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
        public ArrayList recent_list = new ArrayList();
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
            recent_list.Add(animal.get_Context_ToString());
            object_list.ItemsSource = null;
            object_list.ItemsSource= recent_list;
        }

        private void btn_removeObj_Click(object sender, RoutedEventArgs e)
        {
            object object_selected = object_list.SelectedItem;
            string object_key = object_selected.ToString().Split(',')[0];
            recent_list.Remove(object_selected.ToString());
            object_list.ItemsSource = null;
            object_list.ItemsSource = recent_list;
            foreach (Image item in bg_rectangle.Children)
            {
                if (item.Name == object_key)
                {
                    bg_rectangle.Children.Remove(item);
                    break;
                }
            }
        }

        private void btn_searchType_Click(object sender, RoutedEventArgs e)
        {
            string key = tb_search.Text;
            Filter my_Search = new Filter(recent_list);
            object_list.ItemsSource = null;
        }
    }

}
