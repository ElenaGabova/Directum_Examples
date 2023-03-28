using System.Collections.Generic;
using System.IO;
using MeetingReminder.FileUtil;
using MeetingReminder.Res;

namespace MeetingReminder
{
    public class FileWriter : IFileWriter
    {
        private static FileWriter readerInstance;

        private FileWriter() { }

        public static FileWriter getInstance()
        {
            if (readerInstance == null)
                readerInstance = new FileWriter();

            return readerInstance;
        }

        public void writeMeetings(List<MeetingModel> meetings)
        {
            StreamWriter writer = new StreamWriter(Strings.textFilePath);
            foreach(MeetingModel meeting in meetings)
            {
                string durationFormat = meeting.DurationMinutesFormat ? "минут " : "час";
                writer.WriteLine($"Встреча {meeting.Name} {meeting.Duration} {durationFormat} с {meeting.StartTime}");
            }
            writer.Close();
        }
    }
}
