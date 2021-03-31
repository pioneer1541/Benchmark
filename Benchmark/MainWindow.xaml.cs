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
        public int count; //a public number for creating animal name;
        public ArrayList recent_list = new ArrayList(); //An arraylist for storing recent object list.each item is MyClass' object;
        public string[] animal_Array = new string[] { "cows", "deer", "horse", "dragon" }; //An string array for all animal's image name;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void btnCreate_Img(object sender, MouseEventArgs e) //Creating animal to a scene and add it to the object list;
        {
            try
            {
                //Decide the animal type by a random process;
                Random lucky = new Random();
                int lucky_number = lucky.Next(4);
                string animaltype = animal_Array[lucky_number];
                string animal_name = animaltype + "_" + count;

                //Get a point click location for creating a animal;
                System.Windows.Point pt = e.GetPosition(animal_zone);
                MyClass animal = new MyClass(animaltype, animal_name + "_" + count, pt);
                count++;

                // Add new animal to scene and list;
                animal_zone.Children.Add(animal);
                recent_list.Add(animal);
                Refresh_list();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void btn_removeObj_Click(object sender, RoutedEventArgs e)//remove a selected item from object list.
        {
            try
            {
                if (object_list.SelectedItem != null) //User must select an item from object list;
                {
                    //Get the item which user selected and get its name.
                    object object_selected = object_list.SelectedItem;
                    string object_key = object_selected.ToString().Split(',')[0];

                    //Invoke the remove function to remove item from the list and remove control from the scene base on the item name;
                    recent_list.Remove(object_selected.ToString());
                    foreach (System.Windows.Controls.Image item in animal_zone.Children)
                    {
                        if (item.Name == object_key)
                        {
                            animal_zone.Children.Remove(item);
                            Remove_list(item.Name);
                            break;
                        }
                    }
                    //Refresh the object list base on the lastest recent list.
                    Refresh_list();
                }
                else
                {
                    MessageBox.Show("Please select a record from the list before removing a record.", "Opps!");
                }
            }
            catch (Exception)
            {
                throw;
            }




        }

        public void btn_searchType_Click(object sender, RoutedEventArgs e) //Search the object list base on the keyword that user entered;
        {
            try
            {
                if (tb_search.Text != "") // User must enter a keyword
                {
                    string key = tb_search.Text; //Get a keyword
                    Refresh_list(key); //To invoke the refresh_list function and it will generate a new Listbox source for the object list base on the keyword.
                }
                else
                {
                    MessageBox.Show("Please enter key words for searching.", "Opps!");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void btn_sortType_ZA_Click(object sender, RoutedEventArgs e) //Sorting each animal's name on the object list by descending.
        {
            try
            {
                //New a object of the Filter class and invoke the descending sort method to get the new items source.
                Filter my_Search = new Filter(recent_list);
                var sort_Result = my_Search.Sort_ListZA();

                //Set a new ItemsSource for object list.
                object_list.ItemsSource = null;
                object_list.ItemsSource = sort_Result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void btn_sortType_AZ_Click(object sender, RoutedEventArgs e) //Sorting each animal's name on the object list by descending.
        {
            try
            {
                //New a object of the Filter class and invoke the descending sort method to get the new items source.
                Filter my_Search = new Filter(recent_list);
                var sort_Result = my_Search.Sort_ListAZ();

                //Set a new ItemsSource for object list.
                object_list.ItemsSource = null;
                object_list.ItemsSource = sort_Result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Remove_list(string name)//Remove an item from the object list.
        {
            try
            {
                ArrayList result = new ArrayList(); //For new recent list

                //Loop the recent list and add each item to the new ArrayList except the item which the user wants to remove.
                foreach (MyClass image in recent_list)
                {
                    if (image.Name != name)
                    {
                        result.Add(image);
                    }
                }
                recent_list = result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public void Refresh_list(string key = "")
        //The function is used to refresh the object list and search the list. 
        //When the default value is empty, we can take it as getting the lastest list information.
        //When we invoke it by passing a value, it will return a list that match the keyword on the object list.
        //The return list would not be sorted.

        {
            try
            {
                Filter my_Search = new Filter(recent_list);
                var search_Result = my_Search.Search_List(key);
                object_list.ItemsSource = null;
                object_list.ItemsSource = search_Result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void btn_clearAll_Click(object sender, RoutedEventArgs e) //Remove all objects and items.
        {
            try
            {
                animal_zone.Children.Clear();
                recent_list = new ArrayList();
                object_list.ItemsSource = null;
                MessageBox.Show("Done!", ":)");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Load_Data(int loadtype)
        {
            try
            {
                FileManager operation = new FileManager();
                if (operation.Load_List(loadtype))  //Invoke the load_list method of FileManager Class and passing a value that stand for load type;
                {
                    object_list.ItemsSource = operation.Data;
                }
                Recreate_Animal(operation.Data);

                MessageBox.Show("Done!", ":)");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void btn_loadData_Previous_Click(object sender, RoutedEventArgs e)//Load the previous saving data.
        {
            Load_Data(0);
        }



        public void btn_showStatus_Click(object sender, RoutedEventArgs e) //Get the lastest information for the object list.
        {
            Refresh_list();
        }

        public void btn_loadData_Inital_Click(object sender, RoutedEventArgs e) //Load the inital data to the object list
        {
            Load_Data(1);
        }

        public void Recreate_Animal(ArrayList data)
        //This function is created for create new object by loading data.
        {
            try
            {
                foreach (string animal_Data in data) //Get animal's name.
                {
                    //Get all properties of an object base on the loaded data.
                    string[] data_Array = animal_Data.Split(',');
                    string animal_name = data_Array[0];
                    foreach (MyClass item in recent_list) //Check the animal name if it exists.
                    {
                        if (item.Name == animal_name) //if yes, rename it;
                        {
                            animal_name += "_1";
                        }
                    }
                    string animaltype = data_Array[0].Substring(0, data_Array[0].IndexOf("_"));
                    System.Windows.Point pt = new Point();
                    int location_Index = data_Array[3].IndexOf(":");
                    pt.X = int.Parse(data_Array[3].Substring(location_Index + 1));
                    pt.Y = int.Parse(data_Array[4]);
                    int X_Index = data_Array[1].IndexOf(":");
                    int Y_Index = data_Array[2].IndexOf(":");
                    int speed_X = int.Parse(data_Array[1].Substring(X_Index + 1));
                    int speed_Y = int.Parse(data_Array[2].Substring(Y_Index + 1));
                    string tag = data_Array[5].Substring(data_Array[5].IndexOf(":") + 1);

                    //New a new object of Myclass and add it to the scene and the object list.
                    MyClass animal = new MyClass(animaltype, animal_name, pt, speed_X, speed_Y, tag);
                    animal_zone.Children.Add(animal);
                    recent_list.Add(animal);
                    Refresh_list();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void btn_saveList_Click(object sender, RoutedEventArgs e) //Saving recent list into a txt file as data
        {
            try
            {
                Refresh_list();
                ArrayList list_data = new ArrayList();
                foreach (string data in object_list.Items)
                {
                    list_data.Add(data);
                }
                FileManager operation = new FileManager(list_data);
                operation.Save_List();

                MessageBox.Show("Done!", ":)");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
