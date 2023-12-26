
namespace Todo.Domain.Notifications
{
    public class Notification( string property , string message )
    {
        public string Property { get; private set; } = property;
        public string Message { get; private set; } = message;
    }
}
