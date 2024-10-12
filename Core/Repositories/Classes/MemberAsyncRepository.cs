using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Core;
using Core.Data.Entity;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Classes
{
    public class MemberAsyncRepository : IMemberAsyncRepository
    {
        private readonly SoruHavuzuContext db;

        public MemberAsyncRepository()
        {
            db = new SoruHavuzuContext();
        }
        public async Task<List<Member>> GetAllAsync()
        {
            return await Task.Run(() => {
                var members = db.Members.ToList();

                return members ?? new List<Member>();
            });
        }

        public async Task<List<Member>> GetAsync()
        {
            return await Task.Run(() =>
            {
                var members = db.Members
                    .Where(e => e.MemberSettings.Any(e => e.DeletedDate == null))
                    .ToListAsync();

                return members;
            });
        }

        public async Task<Member> GetByEmailAsync(string email)
        {
            return await Task.Run(() => {
                var member = db.Members
                .FirstAsync(e => e.Email == email);

                return member;
            });
        }

        public async Task<Member> GetByIdAsync(int id)
        {
            return await Task.Run(() => {
                var member = db.Members
                .FirstAsync(e => e.Id == id);

                return member;
            });
        }

        public async Task<List<Member>> GetDeletedAsync()
        {
            return await Task.Run(() => {
                var member = db.Members
                .Where(e => e.MemberSettings.Any(e => e.DeletedDate != null))
                .ToListAsync();

                return member;
            });
        }

        public async Task<MemberSetting> GetRoleAsync(Member member)
        {
            return await Task.Run(() => {
                var role = db.MemberSettings
                .FirstAsync(e => e.MemberId == member.Id);

                return role;
            });
        }

        public async Task RemoveAsync(int id)
        {
            var member = await db.MemberSettings.FirstOrDefaultAsync(e => e.Id == id && e.DeletedDate == null);

            if (member != null)
            {
                member.DeletedDate = DateTime.Now;
                await db.SaveChangesAsync();
            }
        }

        public async Task SetAsync(Member member)
        {
            db.Members.Update(member);
            await db.SaveChangesAsync();
        }

        public async Task<int> SetRoleAsync(int id, string newRole)
        {
            int affectedRows = await db.MemberSettings
                .Where(e => e.MemberId == id)
                .ExecuteUpdateAsync(e => e.SetProperty(x => x.Role, newRole));

            return affectedRows;
        }
    }
}