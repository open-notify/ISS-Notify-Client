using System;
using System.Collections.Generic;
using System.Net;
using JsonFx.Json;


namespace OpenNotify
{
    class OpenNotify
    {
        private OpenNotifyApi api;
        private List<Pass> passes;
        //private Location location;

        public OpenNotify(Location location)
        {
            api = new OpenNotifyApi(location, 5);
            passes = new List<Pass>();
        }

        public void UpdatePasses()
        {
 
        }

        private void getPasses()
        {
            /*
            ApiResponse response = new ApiResponse();
            JsonReader reader = new JsonReader();
            WebClient w = new WebClient();

            string url = api.URL;
            string rawJson = w.DownloadString(url);
            dynamic output = reader.Read(rawJson);

            response.ProccessData(output);
             */
        }
    }

    
    /*
    class IssPassApi
    {
        private String _url;
        private static String api = "iss";
        private Location location;
        private int _n;

        public IssPassApi(Location loc, int passes)
        {
            location = loc;
            _n = passes;

            this.BuildUrl();
        }

        public void BuildUrl()
        {
            _url = "http://api.open-notify.org/";
            _url += api + "/";

            _url += "?";
            _url += "lat=" + String.Format("{0:0.0########}", location.Latitude);
            _url += "&lon=" + String.Format("{0:0.0########}", location.Longitude);
            _url += "&alt=" + String.Format("{0:0}", location.Altitude);
            _url += "&n=" + String.Format("{0:0}", _n);
        }

        public void UpdateLocation(Location loc)
        {
            location = loc;
            this.BuildUrl();
        }

        public string URL
        {
            get { return _url; }
        }

        public int NumberOfPasses
        {
            get { return _n; }

            set 
            { 
                _n = value;
                this.BuildUrl();
            }
        }
    }
    */
}
