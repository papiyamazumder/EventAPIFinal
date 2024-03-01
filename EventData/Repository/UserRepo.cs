using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using EventData.DataContext;
using EventEntity;

namespace EventData.Repository
{
    public class UserRepo : IUserRepo
    {
        private  readonly EventDbContext _userDbContext;
        public UserRepo(EventDbContext userDbContext)
        {
             _userDbContext = userDbContext;
        }
        public bool CreateUser(UserModel user)
        {
            _userDbContext.UserModel.Add(user);
            _userDbContext.SaveChanges();
            return true;
        }

        public UserModel Get(int id)
        {
            UserModel user = _userDbContext.UserModel.Find(id);
            return user;
        }

        public IList<UserModel> GetAll()
        {
            return _userDbContext.UserModel.ToList();
        }
    }
}
