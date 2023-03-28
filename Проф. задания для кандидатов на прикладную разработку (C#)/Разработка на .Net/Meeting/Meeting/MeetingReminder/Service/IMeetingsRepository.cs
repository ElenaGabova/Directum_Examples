using System;
using System.Collections.Generic;

namespace MeetingReminder.Data
{
    /// <summary>
    /// Репозиторий  запланированных встреч.
    /// </summary>
    public interface IMeetingsRepository
    {
        /// <summary>
        /// Получение общего количества встреч.
        /// </summary>
        /// <returns></returns>
        int GetMeetingsNumber();


        /// <summary>
        /// Получение количество встречь за определенных день.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        int GetMeetingsNumber(DateTime date);

        /// <summary>
        /// Получение списка всех будущих встреч.
        /// </summary>
        /// <returns></returns>
        List<MeetingModel> GetFutureMeetings();

        /// <summary>
        /// Получение списка всех запланированных встреч.
        /// </summary>
        /// <returns></returns>
        List<MeetingModel> GetMeetings();

        /// <summary>
        /// Получение списка всех запланированных встреч за определённый день.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        List<MeetingModel> GetMeetings(DateTime date);

        /// <summary>
        /// Сохранение встречи.
        /// </summary>
        void SaveMeeting(MeetingModel meeting);

        /// <summary>
        /// Удаление встречи по ключу.
        /// </summary>
        void DeleteMeeting(String key);
    }
}
