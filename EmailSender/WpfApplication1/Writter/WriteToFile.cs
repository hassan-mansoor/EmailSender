using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace EmailComposer.Writter
{
    class WriteToFile
    {
        private  DateTime dt;
        private  string directory_name;
        private  string subdirectory_name;

        public WriteToFile()
        {
            dt = DateTime.Now;
            directory_name = ConfigurationManager.AppSettings["WEJSCIEDirectory"]; ;
            subdirectory_name = directory_name+"/"+dt.ToString("ddyyMMHHmmss");
        }
        public void CreateDirectory()
        {
            bool directoryExists = Directory.Exists(ConfigurationManager.AppSettings["WEJSCIEDirectory"]);
            if (!directoryExists)
            {
                Directory.CreateDirectory(directory_name);
            }
        }

        public void CreateSubDirectoryWithTimeStamp()
        {
            try
            {
                Directory.CreateDirectory(subdirectory_name);
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.Message);
            }
        }

        public void FileWritter(string file_name,string data)
        {
            try
            {
                if (data != string.Empty)
                {
                    System.IO.File.WriteAllText(subdirectory_name+"/"+ file_name+".txt", data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.Message);
            }
        }

       
        public void FileWritter(string file_name, List<string> data_list)
        {
            try
            {
                if (data_list.Count > 0)
                {
                    System.IO.File.WriteAllLines(subdirectory_name+"/"+file_name+".txt", data_list.ToList());
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine("error" + e.Message);
            }
        }

    }
}
