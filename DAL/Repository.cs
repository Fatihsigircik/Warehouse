using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<T> where T : class
    {
        private readonly fsEntities _fsEntities;
        public fsEntities Entity => _fsEntities;
        public Repository()
        {
            _fsEntities = new fsEntities();
        }

        public async Task<T> Add(T entity)
        {
            var retVal = _fsEntities.Set<T>().Add(entity);
            await _fsEntities.SaveChangesAsync();
            return retVal;
        }

        public async Task<IEnumerable<T>> AddList(IEnumerable<T> entities)
        {
            var retVal = new List<T>();
            foreach (var entity in entities)
            {
                retVal.Add(_fsEntities.Set<T>().Add(entity));
            }
            await _fsEntities.SaveChangesAsync();
            return retVal;
        }

        public async Task<T> GetById(int id)
        {
            var exp = Helper.GetExpression<T>(typeof(T).Name + "Id", id);
            return await _fsEntities.Set<T>().AsNoTracking().FirstOrDefaultAsync(exp);
        }

        public IEnumerable<T> Get()
        {
            var retVal = _fsEntities.Set<T>().AsNoTracking();
            return retVal.ToList();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            var retVal = _fsEntities.Set<T>().AsNoTracking();
            return await retVal.ToListAsync();
        }

        public async Task<List<T>> GetBySkipAndTake(int skip,int take=100)
        {
            var retVal = _fsEntities.Set<T>().AsNoTracking();
            return await retVal.Skip(skip).Take(take).ToListAsync();
        }

        public List<T> GetByProperty(string propertyName, object value)
        {
            var exp = Helper.GetExpression<T>(propertyName, value);
            var retVal = _fsEntities.Set<T>().AsNoTracking().Where(exp);
            return retVal.ToList();
        }

        public static Expression<Func<T,bool>> GetPropertyExpression(string propertyName, object value)
        {
            return Helper.GetExpression<T>(propertyName, value);

        }
        public static Expression<Func<T, bool>> GetStringMethodsExpression(string propertyName, string value, string methodName)
        {
           var startsWithMethod = typeof(String).GetMethod(methodName, new[] { typeof(String) });

            return Helper.GetCallExpression<T>(propertyName, value,startsWithMethod);


            /*

             // The first parameter is type "String", and well call it "str"
 // The second parameter also type "String", and well call it "startsWith"
 ParameterExpression str = Expression.Parameter(typeof(String), "str");
 ParameterExpression startsWith = Expression.Parameter(typeof(String), "startsWith");

 // Get the method metadata for "StartsWith" -- the version that takes a single "String" input.
 MethodInfo startsWithMethod = typeof(String).GetMethod("StartsWith", new[] { typeof(String) });

 // This is the same as (...) => str.StartsWith(startsWith);
 // That is: Call the method pointed to by "startsWithMethod" bound above. Make sure to call it
 // on 'str', and then use 'startsWith' (defined above as well) as the input.
 MethodCallExpression callStartsWith = Expression.Call(str, startsWithMethod, new Expression[] { startsWith });

 // This means, convert the "callStartsWith" lambda-expression (with two Parameters: 'str' and 'startsWith', into an expression
 // of type Expression<Func<String, String, Boolean>
 Expression<Func<String, String, Boolean>> finalExpression =
     Expression.Lambda<Func<String, String,  Boolean>>(callStartsWith, new ParameterExpression[] { str, startsWith });

 // Now let's compile it for extra speed!
 Func<String, String, Boolean> compiledExpression = finalExpression.Compile();

 // Let's try it out on "The quick brown fox" (str) and "The quick" (startsWith)
 Console.WriteLine(compiledExpression("The quick brown fox", "The quick")); // Outputs: "True"
 Console.WriteLine(compiledExpression("The quick brown fox", "A quick")); // Outputs: "False"

             */


        }

        public async Task<int> Update(T entity)
        {
            try
            {
                _fsEntities.Entry(entity).State = EntityState.Modified;
                return await _fsEntities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        public async Task<int> UpdateList(List<T> entities)
        {
            foreach (var entity in entities)
            {
                _fsEntities.Entry(entity).State = EntityState.Modified;
            }
            return await _fsEntities.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var entity = Activator.CreateInstance<T>();
                var pi = entity.GetType().GetProperty(entity.GetType().Name + "Id");
                pi?.SetValue(entity, id);
                _fsEntities.Set<T>().Attach(entity);
                _fsEntities.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return await _fsEntities.SaveChangesAsync();
        }

        public async Task<int> DeleteByField(string field, object value)
        {
            //var entity = Activator.CreateInstance<T>();
            //var pi = entity.GetType().GetProperty(field);
            //pi?.SetValue(entity, value);
            var exp = Helper.GetExpression<T>(field, value);
            _fsEntities.Set<T>().RemoveRange(_fsEntities.Set<T>().Where(exp));
            return await _fsEntities.SaveChangesAsync();
        }


        public async Task<int> DeleteByMultiField(List<KeyValuePair<string, object>> parameters)
        {
            //var entity = Activator.CreateInstance<T>();
            //var pi = entity.GetType().GetProperty(field);
            //pi?.SetValue(entity, value);
            var expList = parameters.Select(pair => Helper.GetExpression<T>(pair.Key, pair.Value)).ToList();

            try
            {
                var tmp = _fsEntities.Set<T>().Where(expList[0]);
                for (var i = 1; i < expList.Count; i++)
                {
                    tmp = tmp.Where(expList[i]);
                }
                _fsEntities.Set<T>().RemoveRange(tmp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return await _fsEntities.SaveChangesAsync();
        }

        public async Task<int> UpdateListByFields(List<T> entities, params string[] properties)
        {
            try
            {
                foreach (var entity in entities)
                {
                    _fsEntities.Set<T>().Attach(entity);
                    foreach (var property in properties)
                    {
                        _fsEntities.Entry(entity).Property(property).IsModified = true;
                    }
                }
                return await _fsEntities.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


        public ObjectResult<T> GetMethod(string methodName, params object[] prm)
        {
            try
            {
                var retVal = (_fsEntities.GetType().GetMethod(methodName).Invoke(_fsEntities, prm) as ObjectResult<T>);
                return retVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public IQueryable<T> GetByWhereExpression(Expression<Func<T,bool>> expression)
        {
           return _fsEntities.Set<T>().AsNoTracking().Where(expression);
        }
    }
}