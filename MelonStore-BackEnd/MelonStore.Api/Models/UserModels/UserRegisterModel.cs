namespace MelonStore.Api.Models
{
    using MelonStore.Models;
    using System.Runtime.Serialization;

    [DataContract(Name = "userRegisterModel")]
    public class UserRegisterModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }

        [DataMember(Name = "storeId")]
        public int StoreId { get; set; }

        public User ToUser()
        {
            User user = new User()
            {
                Username = this.Username,
                Password = this.Password,
                Store_Id = this.StoreId
            };

            return user;
        }
    }
}