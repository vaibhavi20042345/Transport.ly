namespace Transport.ly
{
    class FlightSchedule
    {
        /// <summary>
        /// Display message
        /// </summary>
        /// <param name="schedule">Schedule data</param>
        /// <returns>Message</returns>
        public static string DisplayMessage(Schedule schedule)
        {
            return $"Schedule {schedule.FlightNumber} loaded";
        }
    }
}
