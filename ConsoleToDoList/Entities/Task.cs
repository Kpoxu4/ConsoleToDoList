using ConsoleToDoList.Enums;

namespace ConsoleToDoList.Entities
{
    public class Task
    {
        private DateTime DateTime { get; set; }

        public string Name {  get; set; }

        public Status Status { get; set; }

        public Task(string name)
        {
            this.Name = name;
            Status = Status.NotFulfilled;
            DateTime = DateTime.Now;
        }

        /// <summary>
        /// Переопределение ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Задача: {Name}.\nВремя создание: {DateTime}\nСтатус: {DisplayStatuc(Status)}.\n";
        }

        /// <summary>
        /// Метод приведения Enum в строку.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        private string DisplayStatuc(Status status)
        {
            string taskStatus = "";
            switch (status)
            {
                case Status.NotFulfilled:
                    {
                        taskStatus = "Не выполненная";
                    }
                    break;
                case Status.Сompleted: 
                    {
                        taskStatus = "Выполненная";
                    }
                    break;
            }
            return taskStatus;
        }
        public void ChengStatus()
        {
            Status = Status.Сompleted;
        }
    }
}
