using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCore_Api_1.Models;
using System.Security.Claims;

namespace NetCore_Api_1.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public dynamic listClient()
        {
            List<Client> clients = new List<Client>
            {
                new Client
                {
                    name = "client",
                    description = "asdkmsad",
                    type= "tipo"
                },
                new Client
                {
                    name = "client2",
                    description = "asdkmsad2",
                    type= "tipo2"
                },
            };
            return clients;
        }

        [HttpGet]
        [Route("details")]
        public dynamic listClient(string _name)
        {

            return
                new Client
                {
                    name = _name,
                    description = "asdkmsad",
                    type = "tipo"
                };
        }

        [HttpPost]
        [Route("save")]
        public dynamic saveClient(Client client)
        {
            client.name = "Adrian";
            return new
            {
                success = true,
                message = "Client registered",
                result = client
            };
        }

        [HttpDelete]
        [Route("")]
        [Authorize(Roles = ("admin"))]
        public dynamic deleteClient(string _id)
        {

            // To get the user by jwt
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var id = identity.Claims.FirstOrDefault(x => x.Type == "id").Value;
            UserModel user = UserModel.DB().FirstOrDefault(x => x.ID == id);

            return new
            {
                success = true,
                message = "Client deleted",
                result = "user: " + user.Name
            };
        }
    }
}
