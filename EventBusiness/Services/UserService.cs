using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventData.Repository;
using EventEntity;

namespace EventBusiness.Services
{
    public class UserService
    {
        public readonly IUserRepo _userRepo;
        public UserService(IUserRepo userRepo ) 
        {
            _userRepo = userRepo;
        }
        public bool CreateUser(UserModel user)
        {
            return _userRepo.CreateUser(user);
            
        }
        public UserModel GetUser(int id) 
        {
            return _userRepo.Get(id);
           
        }
        public IList<UserModel> GetUsers()
        {
            return _userRepo.GetAll();
        }
    }
}
