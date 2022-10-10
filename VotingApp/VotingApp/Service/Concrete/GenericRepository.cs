using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VotingApp.Entities;
using VotingApp.Service.Abstract;

namespace VotingApp.Service.Concrete
{
    public class GenericRepository<T> : IService<T> where T :BaseEntitiy 
    {
        // C:\Users\pc\Desktop\Angular Proje\angular\VotingApp\VotingApp\bin\Debug\net5.0\filename.json
        private string fileName = "./"+typeof(T).Name.ToLower()+".json";
        public bool Add(T entity)
        {
            List<T> entities = this.GetList();
            entities.Add(entity);
            this.WriteFile(entities);
            return true;


        }
        protected void WriteFile(List<T> entities) 
        {
           
            string entitiesString = JsonSerializer.Serialize(entities);
            File.WriteAllText(fileName, entitiesString);
        }
        public void Delete(T entity)
        {
            var result = this.GetList().Select((e,index) => new {e.Id,index} ).FirstOrDefault(x=> x.Id == entity.Id); 
            if(result != null) 
            {
                var entities = this.GetList();
                entities.RemoveAt(result.index);
                this.WriteFile(entities);
            }
        }

        public T Get(Func<T, bool> filter = null)
        {
            return  GetList().SingleOrDefault(filter);
        }

        public List<T> GetList(Func<T, bool> filter = null)
        {
            if (!File.Exists(fileName))
            {
                using (FileStream fs = File.Create(fileName)) 
                {
                    fs.Dispose();
                }
                File.WriteAllText(fileName, "[]");

                return new List<T>();
            }

            string entitiesString = String.IsNullOrEmpty(File.ReadAllText(fileName)) ? "[]": File.ReadAllText(fileName);
            List<T> entities = JsonSerializer.Deserialize<List<T>>(entitiesString);
            return filter == null ? entities : entities.Where(filter).ToList();

        }

        public T Update(T entity)
        {
            var result = this.GetList().Select((e, index) => new { e.Id, index }).FirstOrDefault(x => x.Id == entity.Id);
            if (result != null)
            {
                var entities = this.GetList();
                entities[result.index] = entity;
               /*
                foreach(var item in typeof(T).GetProperties()) 
                {
                    if(item.Name != "Id") 
                    {
                        entities[result.index].GetType().GetProperty(item.Name).SetValue(entities[result.index], entity.GetType().GetProperty(item.Name).GetValue(entity), null);
                    }
                }
                */
                this.WriteFile(entities);
            }
            return entity;
        }

        public int GenerateId() 
        { 
            int id = 0;
            if (GetList().Count() > 0) 
            {
                var s = GetList().Select(e =>
                {
                    id = e.Id > id ? id = e.Id : id;
                    return e;
                }).ToList();
            }
            id += 1;
            return id;
        }
    }
}
