using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entity;

namespace Core.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> Get();
        Task<List<Member>> GetDeleted();
        Task<List<Member>> GetByRole(string role);
        Task<string> FindRole(int id);
        Task<Member> FindById(int id);
        Task<Member> FindByEmail(string email);
        Task<List<Member>> Search(string? name, string? surnme);
        Task Add(Member member);
        Task Set(Member member);
        Task SetRole(int id, string newRole);
        Task Remove(int id);
        Task Restore(int id);
        Task<bool> Check(int id);
        Task<bool> isDeleted(int id);
        Task<int> Count();

    }
}
