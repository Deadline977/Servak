using System.Runtime.InteropServices;
using System.Text.Json;

namespace MainService
{
    public class MainServiceClass
    {
        public List<Client> getAllUsers()
        {
            return users;
        }
        public string serializeObject(object obj)
        {
            string json = JsonSerializer.Serialize(obj);
            return json;
        }
        public string addNewUser(Client newUser)
        {
            if ((newUser.Name != "") && (newUser.Email != ""))
            {
                foreach(Client user in users)
                {
                    if(user.Email == newUser.Email)
                    {
                        return "Клиент уже есть в базе";
                    }
                }
                users.Add(newUser);
                return "Клиент добавлен в базу";
            }

            return "Недостаточно данных";

        }
        public string deleteUser(Client userForDelete)
        {
            foreach(Client user in users)
            {
                if((user.Name == userForDelete.Name) && (user.Email == userForDelete.Email))
                {
                    users.Remove(user);
                    return "Клиент успешно удалён";
                }
            }
            return "Клиент не найден в базе";
        }

        public string editUser(Client userForEdit)
        {
            foreach(Client user in users)
            {
                if(user.Email == userForEdit.Email)
                {
                    users.Remove(user);
                    users.Add(userForEdit);
                    return "Изменения успешны";
                }
            }
            return "Клиент не найдет";
        }

        List<Client> users = new List<Client>
        {
            new Client("BigFloppa", "123123"),
            new Client("BudgeAbuzer", "123123"),
            new Client("Deadline", "123123"),
        };
    }
    public class Client
    {
        public string Name { get; }
        public string Email { get; }
        public Client(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
    public class Messenger
    {
        public string messageValue { get; }
        public Messenger(string value)
        {
            this.messageValue = value;
        }
    }
}