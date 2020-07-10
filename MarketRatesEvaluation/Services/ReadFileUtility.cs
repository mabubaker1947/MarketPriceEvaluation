using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRatesEvaluation.Services
{
    /// <summary>
    /// static utility class that return contents of the given file 
    /// </summary>
    /// <author>Muhammad Abubaker</author>
    static class ReadFileUtility
    {
        /// <summary>
        /// Reads in all data from the given file 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string having full text of the file</returns>
        public static string ReadAllText(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(path);
            }
            if (path.Length == 0)
            {
                throw new ArgumentException("Invalid file name");
            }
            return InternalReadAllText(path);
        }

        /// <summary>
        /// Read all the data in a string
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string having full text of the file</returns>
        private static string InternalReadAllText(string path)
        {
            string result;
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
