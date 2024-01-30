using Newtonsoft.Json;
using Coursework.Data.Utils;
using Coursework.Data.Model;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace Coursework.Data.Services
{
    public class MemberService
    {
        public static async void SaveMembersToJSON(List<Member> members)
        {
            try
            {
                // Gets the file path where member data will be stored using the AppFilePath method
                // from the AppUtils class in the Utils folder and stores it in the filePath variable.
                string filePath = AppUtils.FilePath("Member.json");

                // Serialize the list of members to JSON format with indented formatting
                // and store it in the JSONData variable.
                string JSONData = JsonConvert.SerializeObject(members, Formatting.Indented);

                // Write the JSON data to the file specified by the filePath variable.
                File.WriteAllText(filePath, JSONData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                await App.Current.MainPage.DisplayAlert("Error", "Error saving member data to JSON.", "OK");
                Console.WriteLine($"{ex.Message}");
            }
        }
        public static async void AddNewMember(Member newMember)
        {
            try
            {
                // Get the file path for storing member data using the AppFilePath method
                // from the AppUtils class in the Utils folder and store it in the filePath variable.
                string filePath = AppUtils.FilePath("Member.json");

                // Retrieve the existing list of members from the JSON file
                List<Member> existingMembers = RetrieveMemberData();

                // Add the new member to the existing list
                existingMembers.Add(newMember);

                // Save the updated list of members to the JSON file
                SaveMembersToJSON(existingMembers);

                //Display an alert indication the succssful member registration
                await App.Current.MainPage.DisplayAlert("Success", "Member added successfully.", "OK");

            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message
                await App.Current.MainPage.DisplayAlert("Error", "Error adding new member.", "OK");
                Console.WriteLine($"{ex.Message}");
            }
        }




        public static List<Member> RetrieveMemberData()
        {
            try
            {
                // Get the file path where member data is stored
                string filePath = AppUtils.FilePath("Member.json");

                // Read existing JSON data from the file
                string existingJSONData = File.ReadAllText(filePath);

                // If the existing JSON data is empty, return an empty list
                // Otherwise, deserialize the data into a list of Member objects
                if (string.IsNullOrEmpty(existingJSONData))
                {
                    return new List<Member>();
                }

                return JsonConvert.DeserializeObject<List<Member>>(existingJSONData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message
                Console.WriteLine($"{ex.Message}");
                return new List<Member>();

            }
        }

        public static bool CheckMembership(string memberPhoneNumber)
        {
            try
            {
                // Retrieve the list of members from the data source
                List<Member> members = RetrieveMemberData();

                // Use LINQ to find a member with the provided phone number
                Member foundMember = members.FirstOrDefault(m => m.PhoneNumber == memberPhoneNumber);

                // Check if a member was found based on the provided phone number
                if (foundMember != null)
                {
                    // Member with the provided phone number exists
                    return true;
                }
                else
                {
                    // Member with the provided phone number does not exist
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions by logging or displaying an error message
                Console.WriteLine($"Error checking membership: {ex.Message}");
                return false;
            }
        }


        public static bool CheckMembershipStatus(string phoneNumber)
        {
            try
            {
                // Retrieve the list of members from the JSON file
                List<Member> members = RetrieveMemberData();

                // Use LINQ to find a member with the provided phone number
                Member foundMember = members.FirstOrDefault(m => m.PhoneNumber == phoneNumber);

                // Check if the member has membership
                bool hasMembership = CheckMembership(phoneNumber);

                // If the member has membership and the membership is active, return true
                if (hasMembership==true)
                {
                    if (foundMember != null && foundMember.MembershipEndDate >= DateTime.Now)
                    {
                        return true;
                    }
                    else
                    {
                        // The member either doesn't exist or the membership has expired
                        return false;
                    }
                }
                else
                {
                    // The member does not have a membership
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception details for debugging
                Console.WriteLine($"Error checking membership status: {ex.Message}");
                return false;
            }
        }

    }
}