using System;
using TodoApp.Core.ValueObjects;
using TodoApp.Shared.Entities;

namespace TodoApp.Core.Entities
{
    public class Todo : Entity{
        public Todo()
        {
        }

        public Todo(Title title)
        {
            Title = title;
            Done = false;
            CreateAt = DateTime.Now;
        }

        public Title Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime CreateAt { get; private set; }

        public void AlterDoneStatus(){
            Done = !Done;
        }
        public void AlterTitle(Title title){
            Title = title;
        }

    }
}