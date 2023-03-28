using System;
using System.Collections.Generic;
using System.Linq;
using MeetingReminder.Data;

namespace MeetingReminder
{
    public class MeetingsRepository : IMeetingsRepository
    {

        private static MeetingsRepository meetingsHolderInstance;

        private Dictionary<String, MeetingModel> meetingDictonary = new Dictionary<String, MeetingModel>();

        private MeetingsRepository() {}

        public static MeetingsRepository getInstance()
        {
            if (meetingsHolderInstance == null)
                meetingsHolderInstance = new MeetingsRepository();

            return meetingsHolderInstance;
        }

        public int GetMeetingsNumber() =>  GetMeetings().Count();

        public int GetMeetingsNumber(DateTime date) => GetMeetings(date).Count();

        public void SaveMeeting(MeetingModel meeting)
        {
            if (meetingDictonary.ContainsKey(meeting.Name))
                throw new SameNameException();

            if (!checkIntersectingMeetings(meeting))
                throw new MeetingIntersectionException();

            meetingDictonary.Add(meeting.Name, meeting);
        }

        public void DeleteMeeting(String key)
        {
            if (meetingDictonary.ContainsKey(key))
                meetingDictonary.Remove(key);
        }

        public List<MeetingModel> GetFutureMeetings()
        {
            return meetingDictonary.Values.Where(meeting => meeting.StartTime > DateTime.Now).ToList();
        }

        public List<MeetingModel> GetMeetings() => meetingDictonary.Values.ToList();

        public List<MeetingModel> GetMeetings(DateTime date) => meetingDictonary.Values.
                                                                                 Where(meeting => meeting.StartTime.Date.Equals(date.Date)).
                                                                                 ToList();

        private bool checkIntersectingMeetings(MeetingModel meeting)
        {
            var futureMeetings = meetingDictonary.Values.Where(meeting => meeting.StartTime > DateTime.Now).ToList();
            foreach (MeetingModel futureMeting in futureMeetings)
            {
                if (meeting.EndTime >= futureMeting.EndTime || meeting.EndTime <= futureMeting.StartTime)
                    continue;
                return false;
            }
            return true;
        }

    }
}
