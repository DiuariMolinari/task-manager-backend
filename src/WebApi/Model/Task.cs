using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class TaskModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

        public TaskModel(long id, string title, bool completed)
        {
            this.Id = id;
            this.Title = title;
            this.Completed = completed;
        }
    }
}
