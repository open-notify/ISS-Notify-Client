using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenNotify
{
    class OpenNotifyApi
    {
        private String _url;
        private static string baseurl = "http://api.open-notify.org/";
        private static string api = "iss";
        private Location location;
        private int _n;

        public OpenNotifyApi(Location loc, int passes)
        {
            location = loc;
            _n = passes;

            this.BuildUrl();
        }

        public void BuildUrl()
        {
            _url = baseurl;
            _url += api + "/";

            _url += "?";
            _url += "lat=" + String.Format("{0:0.0########}", location.Latitude);
            _url += "&lon=" + String.Format("{0:0.0########}", location.Longitude);
            _url += "&alt=" + String.Format("{0:0}", location.Altitude);
            _url += "&n=" + String.Format("{0:0}", _n);
        }
    }
}
