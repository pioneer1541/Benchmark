using System;
using System.Collections;
using System.IO;

namespace Benchmark
{
    public class FileManager
    {
        private string[] _initialData_Array = new string[]
        {
            //an Array for initial data to create a new initial data context
            "horse_0, X Speed:6, Y Speed:6, Location:83,75, Direction:RightDown",
            "horse_1, X Speed:-4, Y Speed:-4, Location:123,64, Direction:LeftUp",
            "dragon_2, X Speed:-7, Y Speed:7, Location:69,282, Direction:LeftDown",
            "cows_3, X Speed:3, Y Speed:-3, Location:248,87, Direction:RightUp",
            "dragon_4, X Speed:-5, Y Speed:-5, Location:10,277, Direction:LeftUp"
        };
        public string path = "./data"; //Define a directory path
        public string path_PreviousData = "./data/PrevioursData.txt"; //Define a txt file path for the previous saving data.
        public string path_InitialData = "./data/InitialData.txt"; //Define a txt file path for the initial data.
        public ArrayList Data { set; get; }  //Used for storing data to writing file or reading file.

        public FileManager(ArrayList data) //A Construction method for action of the writing file.
        {
            this.Data = data;

        }

        public FileManager() //A Construction method for action of the reading file.
        {
            this.Data = new ArrayList();
        }

        public Boolean Save_List() //Used for saving recent list.
        {
            try
            {
                if (!Directory.Exists(path)) //Create a directory if it is not exist.
                {
                    Directory.CreateDirectory(path);
                }

                if (!File.Exists(path_PreviousData)) //Create a txt file if it is not exist.
                {
                    FileStream file = File.Create(path_PreviousData);
                    file.Close();
                }

                StreamWriter sw = new StreamWriter(path_PreviousData);
                sw.Flush();//clear all existing data.
                foreach (string data in this.Data)
                {
                    sw.WriteLine(data);
                }

                sw.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public Boolean Load_List(int loading_Type)
        //Used for loading data from a specific txt file.
        //This method will return a Boolean for using it to check if load aciton is success and the loaded data will be stored into [data] proprety.
        //loading_Type 0 means loading previous data,1 means loading initial data.
        {
            try
            {
                if (Directory.Exists(path))
                {
                    if (loading_Type == 0 && File.Exists(path_PreviousData))
                    {
                        StreamReader sr = new StreamReader(path_PreviousData);
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            this.Data.Add(line);
                        }
                        sr.Close();
                        return true;
                    }
                    else if (loading_Type == 1)
                    {
                        if (!File.Exists(path_InitialData))
                        {
                            FileStream file = File.Create(path_InitialData);
                            file.Close();
                            StreamWriter sw = new StreamWriter(path_InitialData);
                            foreach (string data in _initialData_Array)
                            {
                                sw.WriteLine(data);
                            }
                            sw.Close();
                        }

                        StreamReader sr = new StreamReader(path_InitialData);
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            this.Data.Add(line);
                        }
                        sr.Close();
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
