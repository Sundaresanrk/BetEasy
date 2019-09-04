using System.Collections.Generic;

namespace dotnet_code_challenge.Model
{
    /// <summary>
    /// Class to keep Caulifield Meeting information
    /// </summary>
    public class Meeting
    {
        /// <summary>
        /// Gets or sets the Meeting Id.
        /// </summary>
        public string MeetingId { get; set; }

        /// <summary>
        /// Gets or sets the Meeting Track.
        /// </summary>
        public Track Track { get; set; }

        /// <summary>
        /// Gets or sets the Meeting Races.
        /// </summary>
        public IEnumerable<Race> Races { get; set; }
    }
}