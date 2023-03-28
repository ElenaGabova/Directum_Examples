using System;
namespace MeetingReminder
{
    public struct MeetingModel
    {
        /// <summary>
        /// Название встречи
        /// </summary>
        public string Name;

        /// <summary>
        /// Время начала встречи
        /// </summary>
        public DateTime StartTime;

        /// <summary>
        /// Время окончания встречи
        /// </summary>
        public DateTime EndTime;

        /// <summary>
        /// Формат времени для встречи (минуты или часы)
        /// </summary>
        public bool DurationMinutesFormat;
        /// <summary>
        /// Продолжительность встречи (минуты или часы)
        /// </summary>
        public int Duration;



        public MeetingModel(string name, DateTime startTime, int duration, bool durationMinutesFormat)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new NullNameException();

            if (startTime < DateTime.Now)
                throw new PastMeetingException();

            if (duration <= 0)
                throw new MeetingDurationException();

            var dateTime = durationMinutesFormat ? startTime.AddMinutes(duration) : startTime.AddHours(duration);

            this.EndTime = dateTime;
            this.Name = name;
            this.StartTime = startTime;
            this.DurationMinutesFormat = durationMinutesFormat;
            //Выставляем занчение по умолчанию (30 мин, 1 час)
            if (duration == 0)
                this.Duration = durationMinutesFormat ? 30 : 1;
            else
                this.Duration = duration;
        }
    }
}
