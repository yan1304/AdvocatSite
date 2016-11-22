using AdvocatApp.DAL.EF;
using AdvocatApp.DAL.Entities;
using AdvocatApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvocatApp.DAL.Repositories
{
    public class QuestionRepository : IRepository<Question>
    {
        private SiteContext db;

        public QuestionRepository(SiteContext context)
        {
            db = context;
        }

        public void Create(Question item)
        {
            db.Questions.Add(item);
        }

        public void Delete(int id)
        {
            Question question = db.Questions.Find(id);
            if (question != null)
                db.Questions.Remove(question);
        }

        public async Task DeleteAsync(int id)
        {
            Question question = await db.Questions.FindAsync(id);
            if (question != null)
                db.Questions.Remove(question);
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return db.Questions.Where(predicate).ToList();
        }

        public Question Get(int id)
        {
            return db.Questions.Find(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Questions;
        }

        public async Task<Question> GetAsync(int id)
        {
            return await db.Questions.FindAsync(id);
        }

        public void Update(Question item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
