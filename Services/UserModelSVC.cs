using cty.Interfaces;
using cty.Models;
using cty.Share.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cty.Services
{
    public class UserModelSVC : IUserModels
    {
        protected DataContext _context;
        protected IEncode _enCode;
        public UserModelSVC(DataContext context, IEncode enCode)
        {
            _context = context;
            _enCode = enCode;
        }
        public Task<int> ChangePasswordAdmin(string email, UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAllUserModel()
        {
            List<UserModel> user = new List<UserModel>();
            user = await _context.UserModels.ToListAsync();
            return user;
        }

        public UserModel login(ViewWebLogin viewWebLogin)
        {
            var loginAdmin = _context.UserModels.Where(
              p => p.Email.Equals(viewWebLogin.Email)
              && p.Password.Equals(_enCode.Encode(viewWebLogin.Password))
              ).FirstOrDefault();

            return loginAdmin;
        }
    }
}
