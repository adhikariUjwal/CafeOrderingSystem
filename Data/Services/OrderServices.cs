
using Coursework.Data.Model;
using Coursework.Data.Utils;
using Newtonsoft.Json;

namespace Coursework.Data.Services
{
    public class OrderServices
    {
        public static void SaveOrderDataInJSON(Order order)
        {
            // Get the file path where order data is stored
            string filePath = AppUtils.FilePath("Order.json");

            try
            {
                List<Order> orderList;

                // Read existing JSON data from the file
                string existingJSONData = File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(existingJSONData))
                {
                    // If the file is empty, initialize a new list of orders
                    orderList = new List<Order>();
                }
                else
                {
                    // If there is existing data, deserialize it into a list of orders
                    orderList = JsonConvert.DeserializeObject<List<Order>>(existingJSONData);
                }

                // Add the current order to the list
                orderList.Add(order);

                // Serialize the updated list of orders to JSON format with indented formatting
                string orderJsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);

                // Write the JSON data back to the file
                File.WriteAllText(filePath, orderJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message
                Console.WriteLine($"Error writing JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", $"Error Saving Data", "OK");
            }
        }

        public static List<Order> RetrieveOrderData()
        {
            try
            {
                // Get the file path where order data is stored
                string filePath = AppUtils.FilePath("Order.json");

                // Read existing JSON data from the file
                string existingJSONData = File.ReadAllText(filePath);

                // If the existing JSON data is empty, return an empty list
                // Otherwise, deserialize the data into a list of Order objects
                if (string.IsNullOrEmpty(existingJSONData))
                {
                    return new List<Order>();
                }

                return JsonConvert.DeserializeObject<List<Order>>(existingJSONData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<Order>();
            }
        }

        public static Order GetOrderById(Guid id)
        {
            // Retrieve the list of orders and store it in the orderList object.
            List<Order> orderList = RetrieveOrderData();

            // Return the first order with the specified Id.
            return orderList.FirstOrDefault(order => order.Id == id); // Use an arrow function to check if the Id of the order is equal to the parameter id.
        }


        public static void DeleteOrderById(Guid id)
        {
            try
            {
                // Get the file path where order data is stored
                string filePath = AppUtils.FilePath("Order.json");

                // Retrieve the list of orders from the JSON file and store it in the orderList object.
                List<Order> orderList = RetrieveOrderData();

                // Find the order with the specified Id.
                Order orderToDelete = orderList.FirstOrDefault(order => order.Id == id);

                // Check if the order with the specified Id was found.
                if (orderToDelete != null)
                {
                    // Remove the order from the list.
                    orderList.Remove(orderToDelete);

                    // Serialize the updated order list to JSON with indentation for better readability.
                    string jsonData = JsonConvert.SerializeObject(orderList, Formatting.Indented);

                    // Write the serialized JSON data back to the file.
                    File.WriteAllText(filePath, jsonData);
                }
            }
            catch (Exception ex)
            {
                // Handle any exception that might occur during the deletion process.
                Console.WriteLine($"Error deleting order: {ex.Message}");
            }
        }

    }
}
