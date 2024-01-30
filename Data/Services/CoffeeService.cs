using Coursework.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Coursework.Data.Utils;

namespace Coursework.Data.Services
{
    public class CoffeeService
    {
        public static void SaveCoffeeToJSON(List<Coffee> coffee)
        {
            try
            {
                // Gets the file path where form data will be stored from AppFilePath method
                // in FormUtils class in Utils Folder and stores it in the variable filePath.
                string filePath = AppUtils.FilePath("Coffee.json");

                // Serialize the list of coffee to JSON format with formatting Indented and store it in variable JSONData
                string JSONData = JsonConvert.SerializeObject(coffee, Formatting.Indented);

                // Write the JSON data to the file given from filePath variable and data from jsonData variable.
                File.WriteAllText(filePath, JSONData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error saving coffee data to JSON: {ex.Message}");
            }
        }

        public static void PopulateCoffeeData()
        {
            // Gets the file path where hobby data will be stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = AppUtils.FilePath("Coffee.json");

            // Read existing data from the file and store it in variable existingData
            var existingData = File.ReadAllText(filePath);

            // If the file is empty, injects a list of sample hobby data in a object of List<Hobby> called sampleHobbies first and saves it in a Json File by calling method SaveHobbiesToJson.
            if (string.IsNullOrEmpty(existingData))
            {
                List<Coffee> coffeeData = new List<Coffee>
            {
                new Coffee {Id="C01", Name = "Cappuccino", Price="100"},
                new Coffee {Id="C02", Name = "Espresso", Price="100"},
                new Coffee {Id="C03", Name = "Latte", Price="100"},
                new Coffee {Id="C04", Name = "Americano", Price="100"},
                new Coffee {Id="C05", Name = "Macchiato", Price="100"},
                new Coffee {Id="C06", Name = "Mocha", Price="100"},
                new Coffee {Id="C07", Name = "Flat White", Price="100"},
            };
                SaveCoffeeToJSON(coffeeData); // Save the sample hobby data to the JSON file by calling SaveHobbiesToJson Method and passing sampleHobbies as it Argument.
            }

        }

        public static List<Coffee> RetrieveCoffeeData()
        {
            try
            {
                // Gets the file path where coffee data is stored (you may need to adjust this based on your app structure).
                string filePath = AppUtils.FilePath("Coffee.json");

                // Read existing JSON data from the file.
                string existingJsonData = File.ReadAllText(filePath);

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of Coffee objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<Coffee>();
                }
                return JsonConvert.DeserializeObject<List<Coffee>>(existingJsonData);
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
