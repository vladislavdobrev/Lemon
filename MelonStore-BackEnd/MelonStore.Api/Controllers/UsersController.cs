using MelonStore.Api.Models;
using MelonStore.Data;
using MelonStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MelonStore.Models;

namespace MelonStore.Api.Controllers
{
    //[EnableCors(origins: "http://localhost:1671/", headers: "*", methods: "*")]
    public class UsersController : BaseController
    {
        private readonly IUserRepository data;

        public UsersController()
        {
            this.data = new DbUsersRepository(new MelonStoreContext());
        }

        public UsersController(IUserRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("Invalid repository! It cannot be null!");
            }

            this.data = repository;
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser([FromBody]
                                                UserRegisterModel model)
        {
            return base.PerformOperationAndHandleExceptions(() =>
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Invalid user register model!");
                }

                User user = model.ToUser();

                var dbUser = this.data.Add(user);
                var userLoggedModel = UserLoggedModel.CreateModel(dbUser);

                var response = this.Request.CreateResponse<UserLoggedModel>(HttpStatusCode.Created, userLoggedModel);
                var resourceLink = Url.Link("UsersGetApi", new { id = userLoggedModel.Id });
                response.Headers.Location = new Uri(resourceLink);
                return response;
            });
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage LoginUser([FromBody]
                                             UserLoginModel model)
        {
            return base.PerformOperationAndHandleExceptions(() =>
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Invalid user login model!");
                }
                User dbUser = this.data.Get(model.Username);
                if (dbUser == null || model.Password != dbUser.Password)
                {
                    throw new Exception("Invalid username or password!");
                }
                User loggedUser = this.data.LoginUser(dbUser);
                UserLoggedModel loggedModel = UserLoggedModel.CreateModel(loggedUser);
                var response = this.Request.CreateResponse<UserLoggedModel>(HttpStatusCode.OK, loggedModel);
                return response;
            });
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage LogoutUser(string sessionKey)
        {
            return base.PerformOperationAndHandleExceptions(() =>
            {
                this.data.LogoutUser(sessionKey);
                var response = this.Request.CreateResponse(HttpStatusCode.OK, "User logged out successfully");
                return response;
            });
        }
    }
}
