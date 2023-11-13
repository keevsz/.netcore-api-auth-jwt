using System.Net.NetworkInformation;

namespace NetCore_Api_1.Models
{
    public class UserModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string password { get; set; }

        public static List<UserModel> DB()
        {
            var list = new List<UserModel>()
            {
                new UserModel
                {
                    ID = "1",
                    Email = "asd@gmail.com",
                    Name = "user1",
                    Rol = "empleado",
                    password= "asdasd"
                },
                new UserModel
                {
                    ID = "2",
                    Email = "asd2@gmail.com",
                    Name = "user2",
                    Rol = "empleado",
                    password= "asdasd"

                },
                new UserModel
                {
                    ID = "3",
                    Email = "asesor@gmail.com",
                    Name = "user3",
                    Rol = "asesor",
                    password= "asdasd"

                },
                new UserModel
                {
                    ID = "4",
                    Email = "admin@gmail.com",
                    Name = "user4",
                    Rol = "admin",
                    password= "asdasd"

                },
            };
            return list;
        }
    }
}
