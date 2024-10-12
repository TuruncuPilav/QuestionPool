using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Data.Core;
using Core.Data.Entity;
using System.Data.Entity.Infrastructure;
using Z.EntityFramework.Extensions;



namespace Core.Repositories.Classes
{
    public class MemberRepository
    {
        private readonly SoruHavuzuContext db;

        public MemberRepository()
        {
            db = new SoruHavuzuContext();
        }

        // public Task Add(Member member) // MemberAuthRepository
        // {
        //     throw new NotImplementedException();
        // }

        public Task<IDbAsyncEnumerable<Member>> GetAsyncEnumerable()
        {
            return Task.FromResult((IDbAsyncEnumerable<Member>)db.Members.AsQueryable());
        }

        public async Task<bool> Check(int id)
        {
            var user = await db.Members.AsQueryable().FirstOrDefaultAsync(e => e.Id == id);
            if (user != null) return true; return false;
        }

        public async Task<int> Count()
        {
            return await db.Members.AsQueryable().CountAsync();
        }

        public async Task<Member> FindByEmail(string email)
        {
            var member = await db.Members
            .AsQueryable()
            .FirstOrDefaultAsync(e => e.Email == email);

            return member ?? new Member();
        }

        public async Task<Member> FindById(int id)
        {
            var member = await db.Members
            .AsQueryable()
            .FirstOrDefaultAsync(e => e.Id == id);

            return member ?? new Member();
        }

        public async Task<string> FindRole(int id)
        {
            var member = await db.MemberSettings
            .AsQueryable()
            .FirstOrDefaultAsync(e => e.MemberId == id);

            if (member != null)
                return member.Role!;
            return string.Empty;
        }

        public async Task<List<Member>> Get()
        {
            var members = await db.Members
            .AsQueryable()
            .ToListAsync();

            return members;
        }

        public async Task<List<Member>> GetByRole(string role)
        {
            var members = await db.Members
            .AsQueryable()
            .Where(e => e.MemberSettings.Any(e => e.Role == role))
            .ToListAsync();

            return members ?? new List<Member>();
        }

        // public Task<List<Member>> GetDeleted() // Buna Get() metodu ile de bakilabilir
        // {
        //     throw new NotImplementedException();
        // }

        // public Task<bool> isDeleted(int id)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task Remove(int id)
        {
            await db.MemberSettings
            .Where(e => e.MemberId == id)
            .ExecuteUpdateAsync(e => e.SetProperty(e => e.DeletedDate, DateTime.Now));
        }

        // public Task Restore(int id)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<List<Member>> Search(string name, string? surname)
        {
            var fullName = name;
            if (surname != null) fullName = $"{name} {surname}";

            var members = await db.Members
            .AsQueryable()
            .Where(e => e.Name!.Contains(fullName!))
            .ToListAsync();

            return members ?? new List<Member>();
        }

        // public async Task Set(Member member)
        // {
        //     await db.Members
        //     .ExecuteUpdateAsync(e => e.SetProperty(e => e.Name, member.Name));
        // }

        public async Task SetRole(int id, string newRole)
        {
            await db.MemberSettings
            .Where(e => e.MemberId == id)
            .ExecuteUpdateAsync(e => e.SetProperty(e => e.Role, newRole));
        }






        // public async Task<List<Member>> GetAsync()
        // {
        //     var members = await db.Members.AsQueryable().ToListAsync();
        //     return members;
        // }

    }
}


// public List<Member> GetAll() //Tum uyeleri getirir.
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var members = db.Members
//         .Include(e => e.MemberSettings)
//         .Include(e => e.MemberSecurities)
//         .ToList();

//         return members ?? new List<Member>();
//     }
// }

// public List<Member> GetDeleted() //Silinmis uyeleri getirir
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var members = db.Members
//         .Where(e => e.MemberSettings.Any(e => e.DeletedDate != null))
//         .Include(e => e.MemberSettings)
//         .Include(e => e.MemberSecurities)
//         .ToList();

//         return members ?? new List<Member>();
//     }
// }

// public Member GetByEmail(string email) //E postasi girile uyeyi getirir
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var member = db.Members
//         .Include(e => e.MemberSettings)
//         .Include(e => e.MemberSecurities)
//         .FirstOrDefault(e => e.Email == email);

//         return member ?? new Member();
//     }
// }

// public Member GetById(int id) // Id sine gore uye getirir.
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var member = db.Members
//         .Include(e => e.MemberSettings)
//         .Include(e => e.MemberSecurities)
//         .FirstOrDefault(e => e.Id == id);

//         return member ?? new Member();
//     }
// }

// // public List<Member> Get() // Aktif olan kullanicilari getirir.
// // {
// //     using (var db = new SoruHavuzuContext())
// //     {
// //         var members = db.Members
// //         .Where(e => e.MemberSettings.Any(e => e.DeletedDate == null))
// //         .Select(m => new Member
// //             {
// //                 Id = m.Id,
// //                 Name = m.Name,
// //                 Surname = m.Surname,
// //                 Email = m.Email,
// //                 Gender = m.Gender,
// //                 Birthday = m.Birthday,
// //                 MemberSettings = m.MemberSettings.Where(ms => ms.DeletedDate == null).ToList()
// //             }
// //         )
// //         .ToList();

// //         return members ?? new List<Member>();
// //     }
// // }

// // public List<Member> Get() // Aktif olan kullanicilari getirir.
// // {
// //     using (var db = new SoruHavuzuContext())
// //     {
// //         var members = db.Members
// //         .Where(e => e.MemberSettings.Any(e => e.DeletedDate == null))
// //         .Include(e => e.MemberSettings)
// //         .Include(e => e.MemberSecurities)
// //         .Include(e => e.Libraries)
// //             .ThenInclude(e => e.LibrarySettings)
// //         .Include(e => e.LibraryMembers)
// //         .Include(e => e.Questions)
// //             .ThenInclude(e => e.QuestionSettings)
// //         .ToList();

// //         return members ?? new List<Member>();
// //     }
// // }

// public List<Member> Get() // Aktif olan kullanicilari getirir.
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var members = db.Members
//         //.Where(e => e.MemberSettings.Any(e => e.DeletedDate == null))
//         .Include(e => e.MemberSecurities)
//         .Include(e => e.MemberSettings)
//         .ToList();

//         return members ?? new List<Member>();
//     }
// }


// public List<Member> GetByName(string name, string? surname = null) //Gerek var mi? Ad ve soyada uyan uyeleri getirir.
// {
//     using (var db = new SoruHavuzuContext())
//     {

//         var fullName = name;
//         if(surname != null) fullName += " " + surname;

//         var members = db.Members
//         .Where(e => e.Name!.Contains(fullName))
//         .Include(e => e.MemberSettings)
//         .Include(e => e.MemberSecurities)
//         .ToList();

//         return members ?? new List<Member>();
//     }
// }

// public void Set(Member member) // Gonderilen uyeyi gunceller
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         db.Members.Update(member);
//         db.SaveChanges();
//     }
// }

// public MemberSetting GetRole(Member member) // Uyenin rolunu getirir.
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var role = db.MemberSettings
//         .FirstOrDefault(e => e.MemberId == member.Id);

//         return role ?? new MemberSetting();
//     }
// }

// public void Remove(int id)
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var member = db.MemberSettings
//         .FirstOrDefault(e => e.Id == id && e.DeletedDate == null);

//         if(member != null)
//         {
//             member.DeletedDate = DateTime.Now;
//             db.SaveChanges();
//         }
//     }
// }

// public void SetRole(int id, string newRole)
// {
//     using (var db = new SoruHavuzuContext())
//     {
//         var user = db.MemberSettings
//         .Where(e => e.MemberId == id)
//         .ExecuteUpdate(e => e.SetProperty(e => e.Role, newRole));
//     }
// }
