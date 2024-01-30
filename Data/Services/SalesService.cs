using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Coursework.Data.Model;
using Coursework.Data.Utils;

namespace Coursework.Data.Services
{
    public class SalesService
    {
        public static void AddSales(Sales newSale)
        {
            try
            {
                // Get the file path where the sales data is stored.
                string filePath = AppUtils.FilePath("Sales.json");

                // Read existing JSON data from the file.
                string existingJSONData = File.ReadAllText(filePath);

                // Check if there is existing data in the file.
                if (!string.IsNullOrEmpty(existingJSONData))
                {
                    // Deserialize the existing JSON data into a list of Sales objects.
                    List<Sales> existingSales = JsonConvert.DeserializeObject<List<Sales>>(existingJSONData);

                    // Add the newSale to the existing list of sales.
                    existingSales.Add(newSale);

                    // Save the updated list of sales back to the JSON file.
                    SaveSalesToJSON(existingSales);
                }
                else
                {
                    // If there is no existing data, create a new list with the newSale and save it to the JSON file.
                    List<Sales> newList = new List<Sales>();
                    newList.Add(newSale);
                    SaveSalesToJSON(newList);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display an error message, etc.)
                Console.WriteLine($"Error adding sales: {ex.Message}");
            }
        }

        // Helper method to save the list of sales to the JSON file.
        private static void SaveSalesToJSON(List<Sales> salesList)
        {
            try
            {
                // Get the file path where the sales data is stored.
                string filePath = AppUtils.FilePath("Sales.json");

                // Serialize the list of sales objects to JSON format.
                string jsonSales = JsonConvert.SerializeObject(salesList, Formatting.Indented);

                // Write the JSON data to the file.
                File.WriteAllText(filePath, jsonSales);
            }
            catch (Exception ex)
            {
                // Handle the exception (log, display an error message, etc.)
                Console.WriteLine($"Error saving sales to JSON: {ex.Message}");
            }
        }

        public static List<Sales> RetrieveSalesData()
        {
            try
            {
                // Get the file path where sales data is stored
                string filePath = AppUtils.FilePath("Sales.json");

                // Read existing JSON data from the file
                string existingJSONData = File.ReadAllText(filePath);

                // If the existing JSON data is empty, return an empty list
                // Otherwise, deserialize the data into a list of Sales objects
                if (string.IsNullOrEmpty(existingJSONData))
                {
                    return new List<Sales>();
                }

                return JsonConvert.DeserializeObject<List<Sales>>(existingJSONData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<Sales>();
            }
        }

    }
}
