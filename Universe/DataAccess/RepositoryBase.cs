using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Universe.CustomAttribute;
using Universe.Entity;

namespace Universe.DataAccess
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private readonly DatabaseContext context = new DatabaseContext(new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("Universe")
                .Options);

        public RepositoryBase()
        {
            context.Users.AddRange(
                new User { Name = "Zülfü", Surname = "Livaneli", TCKN = "12345678901" },
                new User { Name = "Ahmet", Surname = "Ümit", TCKN = "12345678902" },
                new User { Name = "Sunay", Surname = "Akın", TCKN = "12345678903" },
                new User { Name = "Kemal", Surname = "Sunal", TCKN = "12345678904" },
                new User { Name = "Cem", Surname = "Karaca", TCKN = "12345678905" },
                new User { Name = "Barış", Surname = "Manço", TCKN = "12345678906" },
                new User { Name = "Zeki", Surname = "Müren", TCKN = "12345678907" },
                new User { Name = "Seyfi", Surname = "Dursunoğlu", TCKN = "12345678908" },
                new User { Name = "Zeki", Surname = "Alasya", TCKN = "12345678909" },
                new User { Name = "Adile", Surname = "Naşit", TCKN = "12345678910" },
                new User { Name = "Cem", Surname = "Yılmaz", TCKN = "12345678911" }
                );
            context.UserTests.AddRange(
                new UserTest { Name = "Zülfü", Surname = "Livaneli", TCKN = "12345678901" },
                new UserTest { Name = "Ahmet", Surname = "Ümit", TCKN = "12345678902" },
                new UserTest { Name = "Sunay", Surname = "Akın", TCKN = "12345678903" },
                new UserTest { Name = "Kemal", Surname = "Sunal", TCKN = "12345678904" },
                new UserTest { Name = "Cem", Surname = "Karaca", TCKN = "12345678905" },
                new UserTest { Name = "Barış", Surname = "Manço", TCKN = "12345678906" },
                new UserTest { Name = "Zeki", Surname = "Müren", TCKN = "12345678907" },
                new UserTest { Name = "Seyfi", Surname = "Dursunoğlu", TCKN = "12345678908" },
                new UserTest { Name = "Zeki", Surname = "Alasya", TCKN = "12345678909" },
                new UserTest { Name = "Adile", Surname = "Naşit", TCKN = "12345678910" },
                new UserTest { Name = "Cem", Surname = "Yılmaz", TCKN = "12345678911" }
                );
            context.SaveChanges();
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            TEntity entity = context.Set<TEntity>().Where(filter).FirstOrDefault();

            Type entityType = entity.GetType();
            PropertyInfo[] properties = entityType.GetProperties();
            foreach (var property in properties)
            {
                object[] secretAttribute = property.GetCustomAttributes(typeof(SecretAttribute), false);
                if (secretAttribute.Length > 0)
                {
                    for (int i = 0; i < secretAttribute.Length; i++)
                    {
                        property.SetValue(entity, "****");
                    }
                }
            }

            return entity;
        }

        public TEntity GetTest(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter).FirstOrDefault();
        }
    }
}
