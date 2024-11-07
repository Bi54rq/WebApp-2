using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Models;

namespace WebApp.Services
{
    public class ProgrammeService
    {
        IDbContextFactory<ApplicationDbContext> contextFactory;

        public ProgrammeService(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Add(Programme record)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                //add record to the dataset
                context.Programmes.Add(record);

                //cascade changes to the database
                context.SaveChanges();
            }
        }

        public Programme GetById(int id)
        {
            using (var context = contextFactory.CreateDbContext())
            {
                //this is a lambda express: m=> m.Id == id
                var record = context.Programmes.SingleOrDefault(m => m.Id == id);
                return record;
            }
        }

        public Programme GetByCode(string code)
        {
            using(var context = contextFactory.CreateDbContext())
            {
                var record = context.Programmes.SingleOrDefault(m => m.Code == code);
                return record;
            }
        }

        public void Update(int id, string code, string title, int credits)
        {
            var record = GetById(id);
            if(record == null)
            {
                throw new Exception("Record does not exist. Nothing to Update");
            }

            record.Code = code;
            record.Title = title;
            record.Credits = credits;

            using (var context = contextFactory.CreateDbContext())
            {
                context.Update(record);
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var record = GetById(id);
            if (record == null)
            {
                throw new Exception("Record does not exist. Nothing to Delete");
            }
            using (var context = contextFactory.CreateDbContext())
            {
                context.Remove(record);
                context.SaveChanges();
            }
        }
    }
}
