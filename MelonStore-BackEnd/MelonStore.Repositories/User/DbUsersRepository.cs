using MelonStore.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MelonStore.Repositories
{
    public class DbUsersRepository : IUserRepository
    {
        private const string SessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const int SessionKeyLen = 50;
        protected static Random rand = new Random();
        
        public DbUsersRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Invalid database context! It cannot be null!");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<User>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<User> DbSet { get; set; }

        public IQueryable<User> All()
        {
            var allUsers = this.DbSet;

            return allUsers;
        }

        public User Get(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id must be positive integer number!");
            }

            var user = this.DbSet.Where(x => x.Id == id).FirstOrDefault();

            return user;
        }

        public User Get(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || username == string.Empty)
            {
                throw new ArgumentOutOfRangeException("Nickname must be non-null, not empty or containing only white spaces!");
            }

            username = username.ToLower();
            var user = this.DbSet.Where(x => x.Username == username).FirstOrDefault();

            return user;
        }

        public User Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("Invalid user! It cannot be null!");
            }

            user.Username = user.Username.ToLower();

            if (this.Get(user.Username) != null)
            {
                throw new InvalidOperationException(string.Format("User with nickname {0} already exists!", user.Username));
            }

            this.DbSet.Add(user);
            this.Context.SaveChanges();

            this.LoginUser(user);

            return user;
        }

        public User LoginUser(User user)
        {
            var dbUser = this.Get(user.Username);
            string sessionKey = this.GenerateSessionKey(dbUser.Id);
            dbUser.SessionKey = sessionKey;
            this.Context.SaveChanges();

            return dbUser;
        }

        public void LogoutUser(string sessionKey)
        {
            var dbUser = this.DbSet.Where(x => x.SessionKey == sessionKey).FirstOrDefault();
            dbUser.SessionKey = null;

            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User item)
        {
            throw new NotImplementedException();
        }

        public string GenerateSessionKey(int userId)
        {
            StringBuilder keyChars = new StringBuilder(50);
            keyChars.Append(userId.ToString());
            while (keyChars.Length < SessionKeyLen)
            {
                int randomCharNum;
                lock (rand)
                {
                    randomCharNum = rand.Next(SessionKeyChars.Length);
                }
                char randomKeyChar = SessionKeyChars[randomCharNum];
                keyChars.Append(randomKeyChar);
            }
            string sessionKey = keyChars.ToString();
            return sessionKey;
        }
    }
}