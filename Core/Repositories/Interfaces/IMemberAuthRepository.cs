using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entity;

namespace Core.Repositories.Interfaces
{
    public interface IMemberAuthRepository
    {
        /*
            Login
            Register
            SetPassword
            forgetPassword
        */

        public Member Login(string email, string password);
        public void Register(Member member, MemberSecurity memberSecurity);
        public void SetPassword(int memberId, string oldPassword, string newPassword);
        public void ForgetPassword(string email, string newPassword);
    }
}