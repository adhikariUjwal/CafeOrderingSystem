using Coursework.Data.Model;
using Coursework.Data.Utils;
using Newtonsoft.Json;


namespace Coursework.Data.Services
{
    public class Add_insService
    {
     

        public static void SaveAddInsToJSON(List<Add_ins> addIns)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = AppUtils.FilePath("Add-ins.json");

            // Serialize the list of hobbies to JSON format with formatting Indented and store it in Variable jsonData
            string JSONData = JsonConvert.SerializeObject(addIns, Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, JSONData);
        }



        public static void NewAdd_ins(Add_ins newAddIn)
        {
            // Get the file path where the add-ins data is stored.
            string filePath = AppUtils.FilePath("Add-ins.json");

            // Read existing JSON data from the file.
            string existingJSONData = File.ReadAllText(filePath);

            // Check if there is existing data in the file.
            if (!string.IsNullOrEmpty(existingJSONData))
            {
                // Deserialize the existing JSON data into a list of Add_ins objects.
                List<Add_ins> existingAddIns = JsonConvert.DeserializeObject<List<Add_ins>>(existingJSONData);

                // Add the newAddIn to the existing list of add-ins.
                existingAddIns.Add(newAddIn);

                // Save the updated list of add-ins back to the JSON file.
                SaveAddInsToJSON(existingAddIns);
            }
            else
            {
                // If there is no existing data, create a new list with the newAddIn and save it to the JSON file.
                List<Add_ins> newList = new List<Add_ins>();
                newList.Add(newAddIn);
                SaveAddInsToJSON(newList);
            }
        }


        public static List<Add_ins> RetrieveAdd_insData()
        {
            try
            {
                String filePath = AppUtils.FilePath("Add-ins.json");

                string existingJSONData = File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(existingJSONData))
                {
                    return new List<Add_ins>();
                }
                return JsonConvert.DeserializeObject<List<Add_ins>>(existingJSONData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<Add_ins>();

            }

        }


        // Retrieves a specific add-in by its Id.
        public static Add_ins GetAddInsById(Guid id)
        {
            // Retrieve the list of add-ins.
            List<Add_ins> addInsList = RetrieveAdd_insData(); // Retrieve the list of add-ins and store it in the addInsList object.

            // Return the first add-in with the specified Id.
            return addInsList.FirstOrDefault(x => x.Id == id); // Use an arrow function to check if the Id of the add-in is equal to the parameter id.
        }


        public static List<Add_ins> EditAddIns(Guid id, string newPrice)
        {
            // Retrieve the list of add-ins.
            List<Add_ins> addins = RetrieveAdd_insData();

            // Find the add-in with the specified Id.
            Add_ins editedAddins = addins.FirstOrDefault(x => x.Id == id);

            // If the add-in is not found, throw an exception.
            if (editedAddins == null)
            {
                throw new Exception("Add-in not found");
            }

            // Update the price of the add-in.
            editedAddins.Price = newPrice;

            // Save the updated list of add-ins to the JSON file by calling the SaveAddInsToJSON method.
            SaveAddInsToJSON(addins);

            // Return the updated list of add-ins.
            return addins;
        }
    }
}
