using System;
using Firebase.Database;
using System.Threading.Tasks;
using StoresManagementApp.Model;
using System.Linq;
using Firebase.Database.Query;
using StoresManagementApp.Admin.Model;
using System.Collections.Generic;
using LiteDB;

namespace StoresManagementApp.Services
{
    public class UserService
    {

        private JsonSerializer _serializer = new JsonSerializer();

        private static UserService _ServiceClientInstance;



        public static UserService ServiceClientInstance
        {
            get
            {
                if (_ServiceClientInstance == null)
                    _ServiceClientInstance = new UserService();
                return _ServiceClientInstance;
            }
        }


        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://storemanagement-82a44-default-rtdb.firebaseio.com/");
        }


        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();
            return (user != null);
        }

        public async Task<bool> IsAdminExists(string uname)
        {
            var user = (await client.Child("RegisterAdminTable")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();
            return (user != null);
        }


        public async Task<bool> RegisterUser(string uname, string passwd)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        UserId = Guid.NewGuid(),
                        Username = uname,
                        Password = passwd,

                    }); ;
                return true;
            }
            else
                return false;
        }

        public async Task<User> LoginUser( string uname, string passwd)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == passwd)
               .FirstOrDefault();
            if (user != null)
            {
                var content = user.Object as User;
                return content;
            }
            else
                return null;
            
        }




        public async Task<List<TaskModel>> GetEmployeeTasks ( string userId)
        {
            var GetTasks = (await client.Child("EmployeeTaskTable")
                .OnceAsync<TaskModel>()).Where(u => u.Object.EmployeeId.ToString() == userId).Select(item => new TaskModel
                {
                    EmployeeId = item.Object.EmployeeId,
                    TaskTitle = item.Object.TaskTitle,
                    TaskId = item.Object.TaskId,
                    employeeTasks = item.Object.employeeTasks
                }).ToList();

            if (GetTasks != null)
                return new List<TaskModel>(GetTasks);
            else
                return null;
        }



        //admin
        //get all registered employeee 
        public async Task <List<User>> GetRegisteredUsers()
        {
            var GetEmployee = (await client.Child("Users")
                .OnceAsync<User>()).Select(item => new User
                {
                    Username = item.Object.Username,
                    Password = item.Object.Password,
                    UserId = item.Object.UserId
                }).ToList();
            return GetEmployee;
        }



        //adaugam task la angajati in baza de date
        public async Task AssignTaskToEmployee(TaskModel task)
        {
            var result = await client.Child("EmployeeTaskTable")
                .PostAsync(new TaskModel()
                {
                    EmployeeId= task.EmployeeId,
                    TaskId=task.TaskId,
                    TaskTitle=task.TaskTitle,
                    employeeTasks=task.employeeTasks
                });
        }
        //stergere din baza de date a unei comenzi
        public async Task<bool> DeleteDatabaseContent(TaskModel taskModel)
        {
            var DeleteUserDb = (await client.Child("EmployeeTaskTable")
                .OnceAsync<TaskModel>()).Where(u => u.Object.TaskId == taskModel.TaskId).FirstOrDefault();
            await client.Child("EmployeeTaskTable").Child(DeleteUserDb.Key).DeleteAsync();

            if (DeleteUserDb.Object != null)
                return true;
            else
                return false;
        }

        public async Task<bool> RegisterAdminUser(string username, string password)
        {
            if (await IsAdminExists(username) == false)
            {
               await client.Child("RegisterAdminTable")
                .PostAsync(new User()
                {
                    UserId = Guid.NewGuid(),
                    Username = username,
                    Password = password,

                });
                return true;
            }
            else
                return false;

        }

       
   

        public async Task<User> LoginAdminUser(string username, string passpowrd)
        {
            var GetPerson = (await client.Child("RegisterAdminTable")
                .OnceAsync<User>()).Where(u => u.Object.Username == username)
                .Where(u => u.Object.Password == passpowrd).FirstOrDefault();

            if (GetPerson != null)
            {
                var content = GetPerson.Object as User;
                return content;
            }
            else
                return null;
        }
    }
}
