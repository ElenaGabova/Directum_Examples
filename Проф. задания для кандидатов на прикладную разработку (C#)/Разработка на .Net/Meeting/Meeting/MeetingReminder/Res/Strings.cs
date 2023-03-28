namespace MeetingReminder.Res
{
    public abstract class Strings
    {
        public const string WelcomeMessage = "Добро пожаловать \n" +
                "Введите название встречи и дату начала встречи в формате \"Название 1000-01-01 00:00:00 1\", " +
            "где последняя цифра - это количество минут длительности встречи. Можно ввести время в формате H, тогда создастся встреча в часах\n" +
                "введите команду \"info\", чтобы узнать информацию о будущих встречах\n" +
                "Чтобы завершить работу программы, введите команду \"exit\" \n" +
            "Чтобы удалить встречу, наберите команду в формате \"delete name\", где name - название встречи.\n" +
            "Для сохранения информации о встречах в текстовом файле, наберите команду \"save\" (сохранение всех встреч), либо \"save 1000-01-01\", если необходимо сохранить встречи за определённый день\n";
        public const string PlanMeeting = "Запланируем будущую встречу";
        public const string Exit = "exit";
        public const string Info = "info";
        public const string Save = "save";
        public const string Delete = "delete";
        public const string PastExceptionMessage = "Нельзя запланировать встречу на прошлое \n";
        public const string IntersectionException = "Нельзя планировать пересекающиеся встречи. Попробуйте изменить время проведения встречи";
        public const string SameNameMessage = "Встреча с таких названием уже запланирована. Назовите встречу по другому.";
        public const string IncorrectInputMessage = "Данные введены некорректно. Попробуйте ещё раз";

        public const string nullNameExceptionMessage = "Нельзя создать задачу без названия!";
        public const string nullDurationExceptionMessage = "Нельзя создать c продолжительностью меньше 0!";

        public const string textFilePath = "text.txt";
    }
}
