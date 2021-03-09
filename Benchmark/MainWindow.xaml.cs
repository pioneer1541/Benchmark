using System;
using System.Collections;
using System.Windows;
using System.Windows.Input;


namespace Benchmark
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int count;
        public ArrayList recent_list = new ArrayList();
        public ArrayList search_List = new ArrayList();
        public ArrayList previous_list = new ArrayList();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnCreate_Img(object sender, MouseEventArgs e)
        {
            string[] animal_Array = new string[] { "cows", "deer","horse","dragon" };
            Random lucky = new Random();
            int lucky_number = lucky.Next(4);
            string animal_name = animal_Array[lucky_number];
            System.Windows.Point pt = e.GetPosition(animal_zone);
            MyClass animal = new MyClass(animal_name, animal_name + "_" + count, pt);
            count++;
            animal_zone.Children.Add(animal);
            recent_list.Add(animal);
            refresh_list();
        }

        private void btn_removeObj_Click(object sender, RoutedEventArgs e)
        {
            object object_selected = object_list.SelectedItem;
            string object_key = object_selected.ToString().Split(',')[0];
            recent_list.Remove(object_selected.ToString());
            foreach (System.Windows.Controls.Image item in animal_zone.Children)
            {
                if (item.Name == object_key)
                {
                    animal_zone.Children.Remove(item);
                    remove_list(item.Name);
                    break;
                }
            }
            refresh_list();


        }

        private void btn_searchType_Click(object sender, RoutedEventArgs e)
        {
            string key = tb_search.Text;
            previous_list = recent_list;
            refresh_list(key);
        }

        private void btn_sortType_ZA_Click(object sender, RoutedEventArgs e)
        {
            Filter my_Search = new Filter(recent_list);
            object_list.ItemsSource = null;
            var sort_Result = my_Search.sort_ListZA();
            object_list.ItemsSource = sort_Result;
        }

        private void btn_sortType_AZ_Click(object sender, RoutedEventArgs e)
        {
            Filter my_Search = new Filter(recent_list);
            object_list.ItemsSource = null;
            var sort_Result = my_Search.sort_ListAZ();
            object_list.ItemsSource = sort_Result;
        }

        public void remove_list(string name)
        {
            ArrayList result = new ArrayList();
            foreach (MyClass image in recent_list)
            {
                if(image.Name != name)
                {
                    result.Add(image);
                }
            }
            recent_list = result;
        }

        public void refresh_list(string key = "")
        {
            Filter my_Search = new Filter(recent_list);
            var search_Result = my_Search.search_List(key);
            ArrayList new_List = new ArrayList();
            foreach (MyClass i in search_Result)
            {
                new_List.Add(i);
            }
            recent_list = new_List;
            object_list.ItemsSource = my_Search.get_List(search_Result);
        }

        private void btn_clearAll_Click(object sender, RoutedEventArgs e)
        {
            animal_zone.Children.Clear();
            foreach (MyClass item in recent_list)
            {
                
            }
            recent_list = new ArrayList();
            object_list.ItemsSource = null;
        }

        private void btn_loadData_Previous_Click(object sender, RoutedEventArgs e)
        {
            ArrayList new_Array = new ArrayList();
            new_Array = recent_list;
            btn_clearAll_Click(sender, e);
            recent_list = previous_list;
            previous_list = new_Array;

            foreach (MyClass animal in recent_list)
            {
                animal_zone.Children.Add(animal);
            }
            refresh_list();
        }



        private void btn_showStatus_Click(object sender, RoutedEventArgs e)
        {
            refresh_list();
        }

        private void btn_loadData_Inital_Click(object sender, RoutedEventArgs e)
        {
            FileManager operation = new FileManager();
            if(operation.load_List())
            {
                object_list.ItemsSource = null;
                object_list.ItemsSource = operation.data;
            }
            recreate_animal(operation.data);
        }

        public void recreate_animal(ArrayList data)
        {
            foreach (string animal_Data in data)
            {
                string[] data_Array = animal_Data.Split(',');
                string animal_name = data_Array[0];
                string animal_type = data_Array[0].Substring(0, data_Array[0].IndexOf("_"));
                System.Windows.Point pt = new Point();
                int location_Index = data_Array[3].IndexOf(":");
                pt.X = int.Parse(data_Array[3].Substring(location_Index + 1));
                pt.Y = int.Parse(data_Array[4] );
                int X_Index = data_Array[1].IndexOf(":");
                int Y_Index = data_Array[2].IndexOf(":");
                int speed_X = int.Parse(data_Array[1].Substring(X_Index +1 ));
                int speed_Y = int.Parse(data_Array[2].Substring(Y_Index +1 ));
                string tag = data_Array[5].Substring(data_Array[5].IndexOf(":")+1);
                MyClass animal = new MyClass(animal_type, animal_name, pt,speed_X,speed_Y, tag);
                animal_zone.Children.Add(animal);
                recent_list.Add(animal);
                refresh_list();
            }
        }

        private void btn_saveList_Click(object sender, RoutedEventArgs e)
        {
            ArrayList list_data = new ArrayList();
            foreach (string data in object_list.Items)
            {
                list_data.Add(data);
            }
            FileManager operation = new FileManager(list_data);
            operation.save_List();
        }
    }

}
