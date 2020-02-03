using System;
using System.IO;
using System.Reflection;

namespace WCFApp.Helpers
{
    public class FileProvider
    {
        private string GetSolutionDirectory =>
            Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;

        public string GetPath(string fileName)
        {
            var a = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(GetSolutionDirectory, fileName);
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
                throw new ArgumentNullException($"File {path} was not found.");

            return fileInfo.FullName;
        }
    }
}