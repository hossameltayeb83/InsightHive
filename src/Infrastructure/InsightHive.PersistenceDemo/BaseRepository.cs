using InsightHive.Application.Interfaces.Persistence;
using InsightHive.Domain.Entities;
using System.Collections;
using System.Linq.Expressions;

namespace InsightHive.PersistenceDemo
{
    internal class BaseRepository<T> : IRepository<T> where T : class
    {
        Dictionary<Type, IList> demoData = new Dictionary<Type, IList>();


        public BaseRepository()
        {

            // Dummy data for Category
            demoData[typeof(Category)] = new List<Category>
            {
                new Category { Id = 1, Name = "Restaurants" },
                new Category { Id = 2, Name = "Repairs" }
            };

            // Dummy data for SubCategory
            demoData[typeof(SubCategory)] = new List<SubCategory>
            {
                new SubCategory { Id = 1, Name = "Burger", CategoryId = 1 },
                new SubCategory { Id = 2, Name = "Pizza", CategoryId = 1 }
            };

            // Dummy data for Business
            demoData[typeof(Business)] = new List<Business>
            {
                new Business { Id = 1, Name = "Burger Joint", Description = "Best burgers in town", Logo = "burger.png", SubCategoryId = 1,OwnerId=1 ,SubCategory=new SubCategory { Id = 1, Name = "Burger", CategoryId = 1 } },

                new Business { Id = 2, Name = "Pizza Place", Description = "Authentic Italian pizzas", Logo = "pizza.png", SubCategoryId = 2,OwnerId = 1,SubCategory=new SubCategory { Id = 1, Name = "Burger", CategoryId = 1 } }
            };

            // Dummy data for Owner
            demoData[typeof(Owner)] = new List<Owner>
            {
                new Owner { Id = 1, BusinessId = 1 },
                new Owner { Id = 2, BusinessId = 2 }
            };


            demoData[typeof(Filter)] = new List<Filter> {
                new Filter { Id=1,Name="Price",Categories=new List<Category> {
                new Category { Id=1,Name="Restaurants" },
                new Category {Id=2,Name="Repairs" }
            } },
                new Filter {Id=2,Name="Features",Categories=new List<Category> {
                new Category { Id=1,Name="Restaurants" },
                new Category {Id=2,Name="Repairs" }
            } }
            };
        }
        public Task<bool> AddAsync(T entity)
        {
            demoData[typeof(T)].Add(entity);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(T entity)
        {
            demoData[typeof(T)].Remove(entity);
            return Task.FromResult(true);
        }

        public Task<T> GetByIdAsync(int id)
        {
            var list = (List<T>)demoData[typeof(T)];
            Func<dynamic, bool> predicate = (list) => list.Id == id;
            return Task.FromResult(list.FirstOrDefault(predicate));
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            return Task.FromResult((IReadOnlyList<T>)demoData[typeof(T)]);
        }

        public Task<T> SelectAllAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> SelectOneAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            var list = (List<T>)demoData[typeof(T)];
            var existingEntity = list.FirstOrDefault(e => ((dynamic)e).Id == ((dynamic)entity).Id);

            if (existingEntity != null)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (prop.Name != "Id")
                    {
                        var newValue = prop.GetValue(entity);
                        prop.SetValue(existingEntity, newValue);
                    }
                }
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }





    }
}
