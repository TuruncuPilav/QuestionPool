using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entity;

namespace Core.Repositories.Interfaces
{
    public interface ILibraryRepository
    {
        // Created a new library. Needed paramters Library, Member
        // Will be changed
        // OK
        public void Add(Library library);
        // Added a new member in libray, default role is student. Altarnative roles: 'Teacher, Editor.'
        // Will be changed. Added role parameter.
        // Ok
        public void AddMember(int memberId, int libraryId, string role);
        // Get all open libraries
        public List<Library> Get();
        // Get deleted libraries
        public List<Library> GetDeleted();
        // Get all libraries.
        public List<Library> GetAll();
        // Get library by id. But i dont have idea for where used
        public Library GetById(int id);
        // Get libraries by memberId
        // Will be changed. Library will be List<Library>
        // OK
        public List<Library> GetByMemberId(int memberId);
        // Get libraries by librar name
        public List<Library> GetByName(string name);
        // Get libraries by category.
        public List<Library> GetByCategory(string category);
        // Update the shipped library.
        public void Set(Library library);
        // Update the member role.
        public void SetMemberRole(int memberId, string newRole);
        // Change the library visibility.
        public void ToggleVisibility(int id);
        // Remove the library by id.
        public void Remove(int id);
        // remove member in library by id. But no remove teacher.
        // Ok
        public void RemoveMember(int libraryId, int memberId);
    }
}