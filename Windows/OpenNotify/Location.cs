using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenNotify
{
    class Location
    {
        private float _lat;
        private float _lon;
        private int _alt;
        private string _name;
        private int _index;

        public Location(float lat, float lon, int alt, string name, int index)
        {
            _lat = lat;
            _lon = lon;
            _alt = alt;
            _name = name;
            _index = index;
        }

        public int Index
        {
            get { return _index; }
        }

        public string PlaceName
        {
            get { return _name; }
            set { _name = value; }
        }

        public float Latitude
        {
            get { return _lat; }
            set { _lat = value; }
        }

        public float Longitude
        {
            get { return _lon; }
            set { _lon = value; }
        }

        public int Altitude
        {
            get { return _alt; }
            set { _alt = value; }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
