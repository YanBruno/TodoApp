using System;
using TodoApp.Core.ValueObjects;
using TodoApp.Shared.Entities;

namespace TodoApp.Core.Entities
{
    public class Todo : Entity{
        public Title Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}