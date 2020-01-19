using DBA.Context;
using DBA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DBA.DataService
{
    public class TodoDataService
    {
        private TodoDbContext todoDbContext;

        public List<Todo> GetAllTodos()
        {
            using (todoDbContext = new TodoDbContext())
            {
                return todoDbContext.Todos.AsNoTracking().ToList(); 
            }
        }

        public bool AddNewTodo(Todo todo)
        {
            using (todoDbContext = new TodoDbContext())
            {
                try
                {
                    todoDbContext.Entry(todo).State = EntityState.Added;
                    todoDbContext.SaveChanges();

                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool EditTodo(Todo todo)
        {
            using (todoDbContext = new TodoDbContext())
            {
                var _todo = todoDbContext.Todos.Where(t => t.id == todo.id).FirstOrDefault();

                if(_todo != null)
                {
                    _todo.todo = todo.todo;
                    _todo.isCompleted = todo.isCompleted;

                    todoDbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteTodo(int id)
        {
            using (todoDbContext = new TodoDbContext())
            {
                var _todo = todoDbContext.Todos.Where(t => t.id == id).FirstOrDefault();

                if(_todo != null)
                {
                    todoDbContext.Entry(_todo).State = EntityState.Deleted;
                    todoDbContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}