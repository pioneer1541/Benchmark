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
        public string path = "./data";
        public string path_PreviousData = "./data/PrevioursData.txt";
        public string path_InitialData = "./data/InitialData.txt";
        public ArrayList data { set; get; }

        public FileManager(ArrayList data)
        {
            this.data = data;

        }

        public FileManager()
        {
            this.data = new ArrayList();
        }

        public void save_List()
        {
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!File.Exists(path_PreviousData))
            {
                File.Create(path_PreviousData);
            }

            StreamWriter sw = new StreamWriter(path_PreviousData);
            sw.Flush();
            foreach (string data in this.data)
            {
                sw.WriteLine(data);
            }

            sw.Close();
        }

        public Boolean load_List(int which)
        {

            if (Directory.Exists(path))
            {
                if (which == 0 && File.Exists(path_PreviousData))
                {
                    StreamReader sr = new StreamReader(path_PreviousData);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        this.data.Add(line);
                    }
                    sr.Close();
                    return true;
                } else if (which == 1 && File.Exists(path_InitialData))
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
                
            } else
            {
                return false;
            }
            
        }
    }
}
