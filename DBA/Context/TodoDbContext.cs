using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DBA.Models;

namespace DBA.Context
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext()
            : base("TodoDb")
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
    }
}