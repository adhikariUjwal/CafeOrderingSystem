
using Microsoft.AspNetCore.Components;
 namespace Coursework.Data.Services
{
    public class Auth
    {
        public bool IsLoggedIn { get; private set; }
        public void Login(string username, string password)
        {
            if (username.Equals("admin") && password.Equals("admin"))
            {
                IsLoggedIn = true;
            }
            else
            {
                IsLoggedIn = false;
            }
        }

        public void Logout()
        {

            IsLoggedIn = false;
            
        }
    }
}
