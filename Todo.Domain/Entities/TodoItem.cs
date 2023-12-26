

namespace Todo.Domain.Entities
{

    public class TodoItem( string title , string user , DateTime date, string description ) : Entity
    {
        public string Title { get; private set; } = title;
        public string Description { get; private set; } = description;
        public string User { get; private set; } = user;
        public DateTime Date { get; private set; } = date;
        public bool Done { get; private set; } = false;

        public void MarkAsDone()
        {
            Done = true;
        }

        public void MarkAsUndone()
        {
            Done = false;
        }
        public void UpdateTitle(string title)
        {
            Title = title;
        }
        public void UpdateDescription( string description )
        {
            Description = description;
        }
        public void UpdateDate(DateTime date)
        {
            Date = date;
        }

    }
}
