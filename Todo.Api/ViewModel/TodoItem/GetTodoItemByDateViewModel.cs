namespace Todo.Api.ViewModel.TodoItem
{
    public class GetTodoItemByDateViewModel
    {  
        public GetTodoItemByDateViewModel (string? user, string date = "")
        {
            User = user;
            Date = DateTime.Parse( date );
        }

        public string? User { get; set; }
        public DateTime? Date { get; set; }
    }
}
