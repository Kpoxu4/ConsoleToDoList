using ConsoleToDoList.Entities;
using ConsoleToDoList.Enums;
using System.ComponentModel;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleToDoList
{

    public static class InteractingWithTheConsole
    {
        const string EXIT = "6";
        public static void DoWork()
        {
            ListTask listTask = new ListTask();
            string number = "";
            while (number != EXIT)
            {
                Console.Clear();
                InfoToDoList.Info("Вас приветствует список задач.");
                Console.WriteLine();
                Console.WriteLine(InfoToDoList.MenuInfo());
                InfoToDoList.Info("Выберите пункт меню: ");
                number = Console.ReadLine();
                Console.WriteLine();
                switch (int.Parse(number))
                {
                    case (int)SelectMenu.AddTask:
                        {
                            CreateNewTask(listTask);
                        }
                        break;

                    case (int)SelectMenu.ShowListTask:
                        {
                            ShowTaskList(listTask);  
                        }
                        break;

                    case (int)SelectMenu.MarkTheTask:
                        {
                            ShowTaskList(listTask);
                            if (listTask.ListTasks.Count() == 0) break;  
                            int taskNumber = 0;
                            bool continueSelecting = false;
                            while (continueSelecting == false)
                            {
                                InfoToDoList.Info("Выберите номер задачи для отметки как выполненная");
                                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= listTask.ListTasks.Count())
                                {
                                    if (listTask.ListTasks[taskNumber - 1].Status == Status.NotFulfilled)
                                    {
                                        listTask.ListTasks[taskNumber - 1].ChengStatus();
                                        continueSelecting = true;
                                        Console.WriteLine("Статус задачи изменен");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Эта задача уже выполненная");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Такого номера задачи нет");
                                }
                            }
                        }
                        break;
                    case 4:
                        {

                        }
                        break;
                    case 5:
                        {

                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Вы вышли из программы.");
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Надо выбрать пункт.");
                        }
                        break;
                }
                InfoToDoList.Info("Нажмите любую клавишу.");
                Console.ReadKey();
            }
        }
        private static void CreateNewTask(ListTask listTask)
        {
            InfoToDoList.Info("Введите имя задачи");
            string nameTask = Console.ReadLine();
            Entities.Task newTask = new Entities.Task(nameTask);
            listTask.ListTasks.Add(newTask);
            InfoToDoList.Info("Задача добавлена.");
        }

        private static void ShowTaskList(ListTask listTask)
        {
            if (listTask.ListTasks.Count != 0)
            {
                Console.WriteLine(listTask.ToString());
            }
            else
            {
                InfoToDoList.Info("Список задач пустой.");
            }
        }

    }
}
