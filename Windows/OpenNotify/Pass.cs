using System;

namespace OpenNotify
{
    /// <summary>
    /// Represents the information from one satellite pass
    /// </summary>
    class Pass
    {

        #region Class Variables

        private DateTime _risetime;
        private DateTime _settime;
        private int _duration;
        private static DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #endregion

        public Pass(Int64 risetime, int duration)
        {
            _risetime = origin.AddSeconds(risetime);
            _settime = _risetime.AddSeconds(duration);
            _duration = duration;
        }

        public DateTime RiseTime
        {
            get { return _risetime; }
        }

        public DateTime SetTime
        {
            get { return _settime; }

        }

        public int PassDuration
        {
            get { return _duration; }
        }
    }
}
