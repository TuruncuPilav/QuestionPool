using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entity;

namespace Core.Repositories.Interfaces
{
    public interface IMemberAsyncRepository
    {
        public Task<List<Member>> GetAsync();
        public Task<List<Member>> GetAllAsync();
        public Task<List<Member>> GetDeletedAsync();
        public Task<MemberSetting> GetRoleAsync(Member member);
        public Task<Member> GetByIdAsync(int id);
        public Task<Member> GetByEmailAsync(string email);
        public Task SetAsync(Member member);
        public Task<int> SetRoleAsync(int id, string newRole);
        public Task RemoveAsync(int id);
    }
}


/*

        public List<Member> Get();
        public List<Member> GetAll();
        public List<Member> GetDeleted();
        public MemberSetting GetRole(Member member);
        public Member GetById(int id);
        public Member GetByEmail(string email);
        public List<Member> GetByName(string name, string? surname);
        public void Set(Member member);
        public void SetRole(int id, string newRole);
        public void Remove(int id);

*/