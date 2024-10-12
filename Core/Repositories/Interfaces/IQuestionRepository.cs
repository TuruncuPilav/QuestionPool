using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entity;

namespace Core.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        // Created a new question. Needed paramters Question, Library, Member
        // Will be changed
        // OK
        public void Add(Question question, Library library, Member member);
        // Get all question
        public List<Question> Get();
        // Get question by id
        public Question GetById(int id);
        // Get all question in library
        // Change return type.
        // Will be changed
        // OK
        public List<Question> GetByLibraryId(int libraryId);
        // Get all question by id
        // Change return type
        // Will be changed
        // OK
        public List<Question> GetByMemberId(int memberId);
        // Get all question by type
        public List<Question> GetByType(int type);
        // Update the question by id.
        public void Set(Question question);
        // Remove the remove by id
        public void Remove(int id);
    }
}