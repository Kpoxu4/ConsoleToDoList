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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int count = 1;

            foreach (Task task in ListTasks)
            {
                sb.AppendLine(count + "\n" + task.ToString());
                count++;
            }

            return sb.ToString();
        }
    }
}
