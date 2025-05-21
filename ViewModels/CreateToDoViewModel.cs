using Flunt.Notifications;
using Flunt.Validations;

namespace MiniTodo.ViewModels
{
    public class CreateToDoViewModel : Notifiable<Notification>
    {
        public string Title { get; set; }

        public ToDo MapTo()
        {
            var contract = new Contract<Notification>()
                  .Requires()
                  .IsNotNull(Title, "Informe o titulo da tarefa")
                  .IsGreaterThan(Title, 5, "O titulo deve conter mais que cinco caracteres");

            AddNotifications(contract);

            return new ToDo(Guid.NewGuid(), Title, false);
        }
    }
}
