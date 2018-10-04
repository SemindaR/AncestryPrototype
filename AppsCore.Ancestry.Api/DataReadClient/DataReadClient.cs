using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AppsCore.Ancestry.Api.DataReadClient
{
    public class DataReadClient<TModel> : IDataReadClient<TModel>
    {
        public List<TModel> ReadJsonData(string filePrefix)
        {
            var files = GetAllFiles(filePrefix, "json");
            if (files == null) throw new IOException("data couldn't find");
            var data = new List<TModel>();
            foreach (var path in files)
            {
                var fileData = File.ReadAllText(path);
                data.Add(JsonConvert.DeserializeObject<TModel>(fileData));
            }
            return data;
        }

        private static List<string> GetAllFiles(string filePrefix, string fileExtention)
        {
            var files = new List<string>();
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo == null) return files;

            var path = Path.Combine(Directory.GetParent(directoryInfo.FullName).FullName, "Data");
            var folder = new DirectoryInfo(path);
            var filesInDir = folder.GetFiles($"{filePrefix}*.{fileExtention}");

            files.AddRange(filesInDir.Select(foundFile => foundFile.FullName));
            return files;
        }
    }
}
