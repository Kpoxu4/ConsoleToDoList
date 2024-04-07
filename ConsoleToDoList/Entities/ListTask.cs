using System.Text;

namespace ConsoleToDoList.Entities
{
    public class ListTask
    {
        public List<Task>  ListTasks {  get; set; }

        public ListTask()
        {
            ListTasks = new List<Task>();
        }
    }
}
