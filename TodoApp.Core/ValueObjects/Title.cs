using TodoApp.Shared.ValueObjects;

namespace TodoApp.Core.ValueObjects
{
    public class Title : ValueObject
    {
        public Title(string description)
        {
            Description = description;
        }
        public string Description { get; private set; }

        public override string ToString() => Description;
    }
}