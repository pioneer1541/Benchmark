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
        public string path = "./data/Data.txt";
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
            
            if (!Directory.Exists("./data"))
            {
                Directory.CreateDirectory("./data");
            }

            if (!File.Exists(path))
            {
                File.Create(path);
            }
            
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Flush();
                foreach (string data in this.data)
                {
                    sw.WriteLine(data);
                }

                sw.Close();
            }
        }

        public Boolean load_List()
        {

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        this.data.Add(line);
                    }
                    sr.Close();
                }
                return true;
            } else
            {
                return false;
            }
            
        }
    }
}
