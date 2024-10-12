using Core.Data.Core;
using Core.Data.Entity;
using Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Classes
{
    public class QuestionRepository : IQuestionRepository
    {
        public void Add(Question question, Library library, Member member)
        {
            using (var db = new SoruHavuzuContext())
            {
                question.LibraryId = library.Id;
                question.MemberId = member.Id;
                db.Questions.Add(question);
                db.SaveChanges();
            }
        }

        public List<Question> Get()
        {
            using (var db = new SoruHavuzuContext())
            {
                var quetions = db.Questions
                .Where(e => e.QuestionSettings.Any(e => e.DeletedDate == null))
                .Include(e => e.QuestionSettings)
                .ToList();

                return quetions ?? new List<Question>();
            }
        }

        public Question GetById(int id)
        {
            using (var db = new SoruHavuzuContext())
            {
                var question = db.Questions
                .Where(e => e.Id == id)
                .Include(e => e.QuestionSettings)
                .FirstOrDefault();

                return question ?? new Question();
            }
        }

        public List<Question> GetByLibraryId(int libraryId)
        {
            using (var db = new SoruHavuzuContext())
            {
                var questions = db.Questions
                .Where(e => e.LibraryId == libraryId)
                .Include(e => e.QuestionSettings)
                .ToList();

                return questions ?? new List<Question>();
            }
        }

        public List<Question> GetByMemberId(int memberId)
        {
            using (var db = new SoruHavuzuContext())
            {
                var questions = db.Questions
                .Where(e => e.MemberId == memberId)
                .Include(e => e.QuestionSettings)
                .ToList();

                return questions ?? new List<Question>();
            }
        }

        public List<Question> GetByType(int type)
        {
            using (var db = new SoruHavuzuContext())
            {
                var questions = db.Questions
                .Where(e => e.QuestionType == type)
                .Include(e => e.QuestionSettings)
                .ToList();

                return questions ?? new List<Question>();
            }
        }

        public void Remove(int id)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.QuestionSettings
                .Where(e => e.Id == id)
                .ExecuteUpdate(e => e.SetProperty(e => e.DeletedDate, DateTime.Now));
            }
        }

        public void Set(Question question)
        {
            using (var db = new SoruHavuzuContext())
            {
                db.Questions.Update(question);
                db.SaveChanges();
            }
        }
    }
}