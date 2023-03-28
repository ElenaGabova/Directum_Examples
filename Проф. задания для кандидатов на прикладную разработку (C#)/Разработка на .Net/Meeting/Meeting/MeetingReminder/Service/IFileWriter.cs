using System.Collections.Generic;

namespace MeetingReminder.FileUtil
{
    /// <summary>
    /// Запись информации в файл.
    /// </summary>
    public interface IFileWriter
    {
        /// <summary>
        /// Запись информации о всех запланированных встречах.
        /// </summary>
        void writeMeetings(List<MeetingModel> meetings);
    }
}
