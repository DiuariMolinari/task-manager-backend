using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<TaskModel> _tasks = new List<TaskModel> {
                new TaskModel(1, "Estudar programação.", true),
                new TaskModel(2, "Ler livro.", false),
                new TaskModel(3, "Estudar inglês no DuoLingo.", true)
        };

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> Get()
        {
            return _tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> Get(int id)
        {
            return Ok(_tasks.Find(x => x.Id == id));
        }

        [HttpPost]
        public void Post([FromBody] TaskModel task)
        {
            _tasks.Add(new TaskModel(GetSequenceId(), task.Title, task.Completed));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskModel task)
        {
            var taskEdit = _tasks.Find(x => x.Id == task.Id);
            taskEdit.Title = task.Title;
            taskEdit.Completed = task.Completed;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tasks.Remove(_tasks.Find(x => x.Id == id));
        }

        private long GetSequenceId()
        {
            return _tasks.Count == 0 ? 1:  _tasks.Last().Id + 1;
        }
    }
}
