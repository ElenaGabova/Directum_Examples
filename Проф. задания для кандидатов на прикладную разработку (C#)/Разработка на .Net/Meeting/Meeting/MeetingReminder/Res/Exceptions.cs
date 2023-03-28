using System;
namespace MeetingReminder
{
    /// <summary>
    /// Исключение, пробрасываемое при попытке запланировать встречу на прошлое.
    /// </summary>
    public class PastMeetingException : Exception {}

    /// <summary>
    /// Исключение, возникающее при попытке создать пересекающиеся встречи.
    /// </summary>
    public class MeetingIntersectionException : Exception {}

    /// <summary>
    /// Исключение, возникающее при попытке создать встречу с неуникальным названием.
    /// </summary>
    public class SameNameException : Exception { }

    /// <summary>
    /// Исключение возникающее при попытке создать встречу с пустым названием
    /// </summary>
    public class NullNameException : Exception { }

    /// <summary>
    /// Исключение при попытке создать встречу с пустой продолжительностью
    /// </summary>
    public class MeetingDurationException : Exception { }
}
