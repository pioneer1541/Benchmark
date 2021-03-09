using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Benchmark
{
    class FileManager
    {
        public string path = "./data"; //Define a directory path
        public string path_PreviousData = "./data/PrevioursData.txt"; //Define a txt file path for the previous saving data.
        public string path_InitialData = "./data/InitialData.txt"; //Define a txt file path for the initial data.
        public ArrayList data { set; get; }  //Used for storing data to writing file or reading file.

        public FileManager(ArrayList data) //A Construction method for action of the writing file.
        {
            this.data = data; 

        }

        public FileManager() //A Construction method for action of the reading file.
        {
            this.data = new ArrayList();
        }

        public void save_List() //Used for saving recent list.
        {
            try
            {
                if (!Directory.Exists(path)) //Create a directory if it is not exist.
                {
                    Directory.CreateDirectory(path);
                }

                if (!File.Exists(path_PreviousData)) //Create a txt file if it is not exist.
                {
                    File.Create(path_PreviousData);
                }

                StreamWriter sw = new StreamWriter(path_PreviousData);
                sw.Flush();//clear all existing data.
                foreach (string data in this.data)
                {
                    sw.WriteLine(data);
                }

                sw.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        public Boolean load_List(int loading_Type)
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
                            this.data.Add(line);
                        }
                        sr.Close();
                        return true;
                    }
                    else if (loading_Type == 1 && File.Exists(path_InitialData))
                    {
                        StreamReader sr = new StreamReader(path_InitialData);
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            this.data.Add(line);
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
