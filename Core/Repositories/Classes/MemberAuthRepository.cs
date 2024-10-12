using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entity;
using Core.Repositories.Interfaces;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Core.Data.Core;

namespace Core.Repositories.Classes
{
    public class MemberAuthRepository : IMemberAuthRepository
    {
        private readonly SoruHavuzuContext db;

        public MemberAuthRepository()
        {
            db = new SoruHavuzuContext();
        }

        public Member Login(string email, string password)
        {
            var member = db.Members
            .Where(e => e.Email == email)
            .Where(e => e.MemberSecurities.Any(e => e.Password == password))
            .FirstOrDefault();

            return member ?? new Member();
        }

        public void Register(Member member, MemberSecurity memberSecurity)
        {
            if(member.Name == null && member.Surname == null)

            if(!ControlPassword(memberSecurity.Password!))
                return; 

            var newMember = db.Members
            .FirstOrDefault(e => e.Email == member.Email);

            if(newMember == null)
                db.Members.Add(newMember!);
        }

        public void SetPassword(int memberId, string oldPassword, string newPassword)
        {
            if(!CheckPassword(memberId, oldPassword))
                return;

            db.MemberSecurities
            .Where(e => e.MemberId == memberId)
            .ExecuteUpdate(e => e.SetProperty(e => e.Password, newPassword));
        }
        
        public void ForgetPassword(string email, string newPassword)
        {
            var member = db.Members
            .FirstOrDefault(e => e.Email == email);

            if(member == null && !ControlPassword(newPassword)) return;

            db.MemberSecurities
            .Where(e => e.MemberId == member!.Id)
            .ExecuteUpdate(e => e.SetProperty(e => e.Password, newPassword));
        }

        private bool ControlPassword(string password)
        {
            string passwordFormat = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\w\d\s]).{8,}$";
            if(Regex.IsMatch(password, passwordFormat))
                return true;
            return false;
        }

        static bool CheckPassword(int memberId, string password)
        {
            using (var db = new SoruHavuzuContext())
            {
                var control = db.MemberSecurities
                .Where(e => e.MemberId == memberId)
                .FirstOrDefault(e => e.Password == password);

                if(control != null)
                    return true;
                return false;
            }
        }
    }
}