using System;
using ConsoleToDoList.Entities;
using ConsoleToDoList.Enums;
using System.ComponentModel;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleToDoList
{

    public static class InteractingWithTheConsole
    {
        const string ADD_TASK = "1";
        const string SHOW_LIST = "2";
        const string CHENGE_STATUS = "3";
        const string EDIT_TASK = "4";
        const string DELETE_TASK = "5";
        const string EXIT = "6";
        public static void DoWork()
        {
            ListTask listTask = new ListTask();
            string number = "";
            while (number != EXIT)
            {
                Console.Clear();
                MainMenu();
                number = Console.ReadLine();
                Console.WriteLine();
                switch (number)
                {
                    case ADD_TASK: 
                        {
                            CreateNewTask(listTask);
                        }
                        break;

                    case SHOW_LIST:
                        {
                            ShowTaskList(listTask);  
                        }
                        break;

                    case CHENGE_STATUS:
                        {
                            int taskNumber = 0;
                            bool continueSelecting = false;
                            while (continueSelecting == false)
                            {
                                Console.Clear() ;  
                                Console.WriteLine();
                                ShowTaskList(listTask);
                                if (listTask.ListTasks.Count() == 0) break;
                                
                                InfoToDoList.Info("Выберите номер задачи для отметки как выполненная");
                                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= listTask.ListTasks.Count())
                                {
                                    if (listTask.ListTasks[taskNumber - 1].Status == Status.NotFulfilled)
                                    {
                                        listTask.ListTasks[taskNumber - 1].ChengStatus();
                                        continueSelecting = MiniMenu("Статус задачи изменен");
                                    }
                                    else
                                    {
                                        continueSelecting = MiniMenu("Эта задача уже выполненная");
                                    }
                                }
                                else
                                {
                                    continueSelecting = MiniMenu("Такого номера задачи нет");
                                }
                            }
                        }
                        break;
                    case EDIT_TASK:
                        {
                            int taskNumber = 0;
                            bool continueSelecting = false;
                            while (continueSelecting == false)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                ShowTaskList(listTask);
                                if (listTask.ListTasks.Count() == 0) break;

                                InfoToDoList.Info("Выберите номер задачи для переименования");
                                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= listTask.ListTasks.Count())
                                {
                                    InfoToDoList.Info("Введите новое имя");
                                    string chengeName = Console.ReadLine();
                                    listTask.ListTasks[taskNumber - 1].Name = chengeName;
                                    continueSelecting = MiniMenu($"Имя изменено на {chengeName}.");
                                   
                                }
                                else
                                {
                                    continueSelecting = MiniMenu("Такого номера задачи нет");
                                }
                            }
                        }
                        break;
                    case DELETE_TASK:
                        {
                            int taskNumber = 0;
                            bool continueSelecting = false;
                            while (continueSelecting == false)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                ShowTaskList(listTask);
                                if (listTask.ListTasks.Count() == 0) break;

                                InfoToDoList.Info("Выберите номер задачи для удаления");
                                if (int.TryParse(Console.ReadLine(), out taskNumber) && taskNumber >= 1 && taskNumber <= listTask.ListTasks.Count())
                                {

                                    listTask.ListTasks.Remove(listTask.ListTasks[taskNumber - 1]);
                                    continueSelecting = MiniMenu($"Удалена задача по номеру {taskNumber}.");
                                }
                                else
                                {
                                    continueSelecting = MiniMenu("Такого номера задачи нет");
                                }
                            }
                        }
                        break;
                    case EXIT:
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

        private static bool MiniMenu(string info)
        {
            bool continueSelecting = false;
            Console.WriteLine(info);
            InfoToDoList.Info("Для выбора следующей задачи нажмите любую клавишу.\nДля выхода из этого меню нажмите ESC.");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            if (consoleKey == ConsoleKey.Escape) continueSelecting = true;

            return continueSelecting;
        }
        private static void MainMenu()
        {
            InfoToDoList.Info("Вас приветствует список задач.");
            Console.WriteLine();
            Console.WriteLine(InfoToDoList.MenuInfo());
            InfoToDoList.Info("Выберите пункт меню: ");
        }
    }
}
