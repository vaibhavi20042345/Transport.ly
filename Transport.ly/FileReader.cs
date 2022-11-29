using System.IO;

namespace Transport.ly
{
    class FileReader
    {
        /// <summary>
        /// Read Json file
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>Json data</returns>
        public static string ReadJsonData(string path)
        {
            return File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), path));
        }
    }
}
