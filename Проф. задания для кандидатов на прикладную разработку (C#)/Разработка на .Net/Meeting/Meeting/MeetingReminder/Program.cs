using System;
using MeetingReminder.Data;
using MeetingReminder.FileUtil;
using MeetingReminder.Res;

namespace MeetingReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Strings.WelcomeMessage);

            IMeetingsRepository repository = MeetingsRepository.getInstance();

            showMeetingsInfo(repository);

            IFileWriter writer = FileWriter.getInstance();

            Console.WriteLine(Strings.PlanMeeting);
            var t = Strings.Info;
            String userInput = Console.ReadLine();
            while (!userInput.Equals("") && !userInput.ToLower().Equals(Strings.Exit))
            {
                string[] words = userInput.Split(' ');
                string command = words[0];
                
                switch (command)
                {
                    case Strings.Info:
                    {
                        if (words.Length == 1)
                            showMeetingsInfo(repository);
                        else
                        {
                            DateTime date = DateTime.Parse(words[1]);
                            showMeetingsInfo(repository, date);
                        }
                            
                        break;
                     }
                     case Strings.Save:
                        {
                            if (words.Length == 1)
                                writer.writeMeetings(repository.GetMeetings());
                            else
                                writer.writeMeetings(repository.GetMeetings(DateTime.Parse(words[1])));
                            break;
                        }
                    case Strings.Delete:
                        {
                            words = splitString(userInput, 2);
                            var deletingKey = words[1];
                            repository.DeleteMeeting(deletingKey);
                            break;
                        }

                    default:
                        {
                            words = splitString(userInput, 4);

                            try
                            {
                                DateTime date = DateTime.Parse(words[1] + " " + words[2]);
                                int durationInMinutes = 0;
                                bool durationMinutesFormat = true;
                                if (words[3].Contains("H"))
                                {
                                    durationInMinutes = int.Parse(words[3].Trim('H'));
                                    durationMinutesFormat = false;
                                }
                                else
                                   durationInMinutes = int.Parse(words[3]);
                                   

                                MeetingModel meeting = new MeetingModel(words[0],
                                                                        date,
                                                                        durationInMinutes,
                                                                        durationMinutesFormat);
                                repository.SaveMeeting(meeting);
                            }
                            catch (PastMeetingException)
                            {
                                Console.WriteLine(Strings.PastExceptionMessage);
                            }
                            catch (MeetingIntersectionException)
                            {
                                Console.WriteLine(Strings.IntersectionException);
                            }
                            catch (SameNameException)
                            {
                                Console.WriteLine(Strings.SameNameMessage);
                            }
                           
                            catch (NullNameException)
                            {
                                Console.WriteLine(Strings.nullNameExceptionMessage);
                            }
                            catch(MeetingDurationException)
                            {
                                Console.WriteLine(Strings.nullDurationExceptionMessage);
                            } 
                            catch
                            {
                                Console.WriteLine(Strings.IncorrectInputMessage);
                            }
                            break;
                        }
                        
                }
                userInput = Console.ReadLine();
            }
        }

        private static void showMeetingsInfo(IMeetingsRepository repository)
        {
            int numberOfMeetings = repository.GetMeetingsNumber();

            Console.WriteLine($"Запланировано {numberOfMeetings} встреч.");

            if (numberOfMeetings > 0)
            {
                foreach (MeetingModel meeting in repository.GetMeetings())
                {
                    string durationFormat = meeting.DurationMinutesFormat ? "минут " : "час";
                    Console.WriteLine($"{meeting.Name} {meeting.Duration} {durationFormat} в {meeting.StartTime}");
                }
            }
        }

        private static void showMeetingsInfo(IMeetingsRepository repository, DateTime date)
        {
            int numberOfMeetings = repository.GetMeetingsNumber(date);

            Console.WriteLine($"Запланировано {numberOfMeetings} встреч.");

            if (numberOfMeetings > 0)
            {
                foreach (MeetingModel meeting in repository.GetMeetings())
                {
                    string durationFormat = meeting.DurationMinutesFormat ? "минут " : "час";

                    Console.WriteLine($"{meeting.Name} {meeting.Duration} {durationFormat} в {meeting.StartTime}");
                }
            }
        }

        private static String[] splitString(String text, int count)
        {
            return text.Split(' ', count);
        }
    }
}
