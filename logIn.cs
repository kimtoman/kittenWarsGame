using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace myGame
{
    class logIn
    {
        private List<User> users;
        JavaScriptSerializer serialize = new JavaScriptSerializer();
        public logIn()
        {
            users = new List<User>();
        }

        public void loadUsers()
        {
            string json = System.IO.File.ReadAllText(@"C:\Users\Yamato\Desktop\project1\myGame\users.json");
            users = serialize.Deserialize<List<User>>(json);
        }
        public void exitGame()
        {
            String output = serialize.Serialize(this.users);
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Yamato\Desktop\project1\myGame\users.json"))
            {
                file.Write(output);

            }
        }

        public void addUser(String userName, String password)
        {
            User newUser = new myGame.User(userName, password);
            this.users.Add(newUser);
        }
    }
}
