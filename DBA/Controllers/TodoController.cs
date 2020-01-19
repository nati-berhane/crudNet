using DBA.DataService;
using DBA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DBA.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TodoController : ApiController
    {
        private readonly TodoDataService todoDataService;

        public TodoController ()
        {
            todoDataService = new TodoDataService();
        }

        // GET: api/Todo
        public HttpResponseMessage Get()
        {
            var result = todoDataService.GetAllTodos();

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // POST: api/Todo
        public HttpResponseMessage Post([FromBody]Todo todo)
        {
            var result = todoDataService.AddNewTodo(todo);

            if(result)
            {
                return Request.CreateResponse(HttpStatusCode.Created, "Todo Added!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // PUT: api/Todo/5
        public HttpResponseMessage Put([FromBody]Todo todo)
        {
            var result = todoDataService.EditTodo(todo);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Todo Modified!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Todo/5
        public HttpResponseMessage Delete(int id)
        {
            var result = todoDataService.DeleteTodo(id);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Todo Deleted!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
