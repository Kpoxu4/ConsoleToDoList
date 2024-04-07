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
            string number = "";
            while (number != EXIT)
            {
                Console.Clear();
                Console.WriteLine(InfoToDoList.Info("Вас приветствует список задач."));
                Console.WriteLine();
                Console.WriteLine(InfoToDoList.MenuInfo());
                Console.WriteLine();
                Console.Write(InfoToDoList.Info("Выберите пункт меню: "));
                number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        {

                        }
                        break;
                    case "2":
                        {

                        }
                        break;
                    case "3":
                        {

                        }
                        break;
                    case "4":
                        {

                        }
                        break;
                    case "5":
                        {

                        }
                        break;
                    case "6":
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
                Console.Write(InfoToDoList.Info("Нажмите любую клавишу."));
                Console.ReadKey();
            }
        }

    }
}
