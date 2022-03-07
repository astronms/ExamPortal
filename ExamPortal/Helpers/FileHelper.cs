using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ExamPortal.Helpers
{
    public static class FileHelper
    {
        public static byte[] GetImageBytes(ZipArchiveEntry attachment)
        {
            StreamReader sr = new StreamReader(attachment.Open());
            var memstream = new MemoryStream();
            sr.BaseStream.CopyTo(memstream);
            return memstream.ToArray();
        }

        private static string GetIFormFileExtension(IFormFile file)
        {
            var fileName = file.FileName;
            var extension = GetExtension(fileName);
            return extension;
        }

        public static string GetExtension(string fileName)
        {
            return fileName.Split('.')[fileName.Split('.').Length - 1];
        }

        public static bool CheckIfXmlFile(IFormFile file)
        {
            var extension = GetIFormFileExtension(file);
            return extension == "xml";
        }

        public static bool CheckIfZipFile(IFormFile file)
        {
            var extension = GetIFormFileExtension(file);
            return extension == "zip";
        }

        public static async Task<string> ReadAsStringAsync(Stream stream)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(stream))
            {
                while (reader.Peek() >= 0)
                    result.AppendLine(await reader.ReadLineAsync());
            }

            return result.ToString();
        }
    }
}
