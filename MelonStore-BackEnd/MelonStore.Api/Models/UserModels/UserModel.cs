namespace MelonStore.Api.Models
{
    using MelonStore.Models;
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        public static Expression<Func<User, UserModel>> FromUser
        {
            get
            {
                return x => new UserModel { Id = x.Id, Username = x.Username };
            }
        }

        public static UserModel CreateModel(User user)
        {
            UserModel model = new UserModel()
            {
                Id = user.Id,
                Username = user.Username,
            };

            return model;
        }

        public User ToUser()
        {
            User user = new User()
            {
                Id = this.Id,
                Username = this.Username,
            };

            return user;
        }
    }
}