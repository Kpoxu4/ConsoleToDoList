namespace ConsoleToDoList
{
    public static class InfoToDoList
    {
        public static void Info(string info)
        {
            Console.WriteLine(info);
        }
        public static string MenuInfo()
        {
            string menuinfo = """
                1. - Добавить задачу.
                2. - Список всех задач.
                3. - Отметить задачу как выполненная.
                4. - Редактировать задачу.
                5. - Удалить задачу.
                6. - Выход.
                """;
            return menuinfo;    
        }
    }
}
