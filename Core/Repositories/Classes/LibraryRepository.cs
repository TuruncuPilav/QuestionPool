using Core.Data.Core;
using Core.Data.Entity;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Classes
{
    public class LibraryRepository : ILibraryRepository
    {
        public void Add(Library library)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.Libraries.Add(library);
                db.SaveChanges();

                // db.LibraryMembers
                // .Where(e => e.MemberId == library.MemberId && e.LibraryId == library.Id)
                // .ExecuteUpdate(e => e.SetProperty(e => e.Role, "Teacher"));

                db.SaveChanges();
            }
        }

        public void AddMember(int memberId, int libraryId, string role)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.LibraryMembers
                .Add(new LibraryMember(){
                    LibraryId = libraryId,
                    MemberId = memberId,
                    Role = role
                });

                db.SaveChanges();
            }
        }

        public List<Library> Get()
        {
            using (var db = new SoruHavuzuContext())
            {
                var libraries = db.Libraries
                .Where(e => e.LibrarySettings.Any(e => e.DeletedDate == null && e.Visibility == true))
                .Include(e => e.LibrarySettings)
                .Include(e => e.LibraryMembers)
                .ToList();
                
                return libraries ?? new List<Library>();
            }                                                                           
        }

        public List<Library> GetAll()
        {
            using (var db = new SoruHavuzuContext())
            {
                var libraries = db.Libraries
                .Where(e => e.LibrarySettings.Any(e => e.Visibility == true))
                .Include(e => e.LibrarySettings)
                .Include(e => e.LibraryMembers)
                .ToList();

                return libraries ?? new List<Library>();
            }
        }

        public List<Library> GetByCategory(string category)
        {
            using (var db = new SoruHavuzuContext())
            {
                var libraries = db.Libraries
                .Where(e => e.Category == category)
                .Include(e => e.LibrarySettings)
                .Include(e => e.LibraryMembers)
                .ToList();
                
                return libraries ?? new List<Library>();
            }
        }

        public Library GetById(int id)
        {
            using (var db = new SoruHavuzuContext())
            {
                var library = db.Libraries
                .Where(e => e.Id == id )
                .Include(e => e.LibrarySettings)
                .Include(e => e.LibraryMembers)
                .FirstOrDefault();

                return library ?? new Library();
            }
        }

        public List<Library> GetByMemberId(int memberId)
        {
            using (var db = new SoruHavuzuContext())
            {
                var libraries = db.Libraries
                .Where(e => e.MemberId == memberId)
                .Include(e => e.LibrarySettings)
                .Include(e => e.LibraryMembers)
                .ToList();

                return libraries ?? new List<Library>();
            }
        }

        public List<Library> GetByName(string name)
        {
            using (var db = new SoruHavuzuContext())
            {
                var libraries = db.Libraries
                .Where(e => e.Name!.Contains(name))
                .Include(e => e.LibrarySettings)
                .Include(e => e.LibraryMembers)
                .ToList();

                return libraries ?? new List<Library>();
            }
        }

        public List<Library> GetDeleted()
        {
            using (var db = new SoruHavuzuContext())
            {
                var libraries = db.Libraries
                .Where(e => e.LibrarySettings.Any(e => e.DeletedDate != null))
                .Include(e => e.LibrarySettings)
                .Include(e => e.LibraryMembers)
                .ToList();

                return libraries ?? new List<Library>();
            }
        }

        public void Remove(int id)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.LibrarySettings
                .Where(e => e.LibraryId == id)
                .ExecuteUpdate(e => e.SetProperty(e => e.DeletedDate, DateTime.Now));
                db.SaveChanges();
            }
        }

        public void RemoveMember(int libraryId, int memberId)
        {
            using (var db = new SoruHavuzuContext())
            {
                var memberRole = db.LibraryMembers
                .FirstOrDefault(e => e.LibraryId == libraryId && e.MemberId == memberId)!
                .Role;

                if(memberRole == "Teacher") return;

                db.LibraryMembers
                .Where(e => e.LibraryId == libraryId && e.MemberId == memberId)
                .ExecuteUpdate(e => e.SetProperty(e => e.DeletedDate, DateTime.Now));
                db.SaveChanges();
            }
        }

        public void Set(Library library)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.Libraries.Update(library);
                db.SaveChanges();
            }
        }

        public void SetMemberRole(int memberId, string newRole)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.LibraryMembers
                .Where(e => e.MemberId == memberId)
                .ExecuteUpdate(e => e.SetProperty(e => e.Role, newRole));
            }
        }

        public void ToggleVisibility(int id)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.LibrarySettings
                .Where(e => e.LibraryId == id)
                .ExecuteUpdate(e => e.SetProperty(e => e.Visibility, e => !e.Visibility));
            }
        }
    }
}