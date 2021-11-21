using System.IO;
using System.Threading.Tasks;

namespace Test___TradeArt_YoloGroup.Utilities
{
    public class FileHelper
    {
        public static bool FileExists(string path) => File.Exists(path);
        /// <summary>
        /// Async Reads in bytes, If file exists
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public static async Task<byte[]> ToBytesAsync(string Path)
        {
            if (FileExists(Path))
                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fs.Length];
                    await fs.ReadAsync(buffer, 0, (int)fs.Length);
                    return buffer;
                }
            throw new System.IO.FileNotFoundException();
        }

        /// <summary>
        /// Reads in bytes, If file exists
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException"></exception>
        public static  byte[] ToBytes(string Path)
        {
            if (FileExists(Path))
                using (var fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, (int)fs.Length);
                    return buffer;
                }
            throw new System.IO.FileNotFoundException();
        }
    }
}
