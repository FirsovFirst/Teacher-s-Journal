using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using Teacher_s_Journal.Models;

namespace Teacher_s_Journal.Services
{
    class FileIOService
    {
        private readonly string path;

        public FileIOService(string PATH)
        {
            path = PATH;
        }

        public BindingList<Student> LoadData()
        {
            var isFileExist = File.Exists(path);
            if (!isFileExist)
            {
                File.CreateText(path).Dispose();
                return new BindingList<Student>();
            }
            using (StreamReader reader = File.OpenText(path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Student>>(fileText);
            }
        }

        public void SaveData(object Students)
        {
            using (StreamWriter writter = File.CreateText(path))
            {
                string output = JsonConvert.SerializeObject(Students);
                writter.Write(output);
            }
        }
    }
}
