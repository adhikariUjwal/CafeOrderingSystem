using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Data.Utils
{
    public class AppUtils
    {
        public static string DirectoryPath()   // Returns the path of the directory where application data will be stored.
        {
            string directoryPath = @"C:\Users\btbin\Desktop\BIT YEAR 3\SEM-1\Application Development\JSON\";  // Define the path to the directory where you want to store your files.
            if (!Directory.Exists(directoryPath))    // If the directory doesn't exist
            {
                Directory.CreateDirectory(directoryPath);  //Create the directory
                return directoryPath;     // Return the path of the directory.
            }
            else
            {
                return directoryPath;   // else return if it is already there
            }
        }


        public static string FilePath(string fileName)
        {
            string createdDirectoryPath = DirectoryPath();   // Calling the method ApplicationDirectoryPath That returns the folder created, and storing it in directoryPathCreated variable
            string filePath = Path.Combine(createdDirectoryPath, fileName);  // Combine the directory path with the file name to get the complete file path.
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();  // If the file doesn't exist, create it.
                    return filePath;    // Return the path of the file.
                }
                else
                {
                    return filePath;  // Return the path of the file.
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return message;
            }
        }
    }
}
