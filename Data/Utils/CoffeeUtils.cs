using Coursework.Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Data.Utils
{
    internal class CoffeeUtils
    {
        public static List<Coffee> RetrieveCoffeeData()
        {
            try
            {
                // Gets the file path where coffee data is stored from a method.
                string filePath = AppUtils.FilePath("Coffee.JSON");

                // Read existing JSON data from the file.
                string existingCoffeeData = File.ReadAllText(filePath);

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of Coffee objects.
                if (string.IsNullOrEmpty(existingCoffeeData))
                {
                    return new List<Coffee>();
                }
                return JsonConvert.DeserializeObject<List<Coffee>>(existingCoffeeData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<Coffee>();
            }
        }
    }
}
