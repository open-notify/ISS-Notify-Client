using System;
using System.Collections.Generic;
using JsonFx.Json;

namespace OpenNotify
{
    /// <summary>
    /// Class UserInterface handles storing and retrieving user data and holding data for the form to use.
    /// </summary>
    class UserInterface
    {
        #region Class Variables

        private static UserInterface instance;
        private Location currentLocation;
        private List<Location> locations;

        #endregion

        /// <summary>
        /// Private constructor
        /// </summary>
        private UserInterface() 
        {
            locations = new List<Location>();

            this.loadLocations();
            this.loadDefaultLocation();
        }

        #region Public Methods

        /// <summary>
        /// Singleton pattern get instance with lazy initialization 
        /// </summary>
        /// <returns>The instance of the user interface</returns>
        public static UserInterface GetInstance()
        {
            if (null == instance)
            {
                instance = new UserInterface();
            }
            return instance;
        }

        /// <summary>
        /// Sets the current location in the program context based on the locations index
        /// </summary>
        /// <param name="index">The index of the location</param>
        public void SetLocation(int index)
        {
            // Set Current Location
            currentLocation = locations[index];
        }

        public void UpdateCurrentLocation(Location newLocation)
        {
            currentLocation = newLocation;
            locations[currentLocation.Index] = currentLocation;
            this.saveSettings();
        }

        public void AddNewLocation(Location newLocation)
        {
            locations.Add(newLocation);
        }

        public void DeleteLocation(Location oldLocation)
        {
            locations.Remove(oldLocation);
            this.loadDefaultLocation();
            this.saveSettings();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Read the stored locations (as JSON) in the user settings and put them into memory.
        /// </summary>
        private void loadLocations()
        {
            // User Setting
            string locationsJson = Properties.Settings.Default.Locations;

            // Clear existing list in case there are new ones to add
            locations.Clear();

            JsonReader reader = new JsonReader();
            dynamic locArray = (Array) reader.Read(locationsJson);

            // Loop through the locations and pack into Location objects
            for (int i = 0; i < locArray.Length; i++)
            {
                dynamic loc = locArray[i];

                string name = (string)loc.PlaceName;
                float lat = (float) loc.Latitude;
                float lon = (float) loc.Longitude;
                int alt = (int) loc.Altitude;

                Location location = new Location(lat, lon, alt, name, i);

                locations.Add(location);
            }
        }

        private void saveSettings()
        {
            JsonWriter writter = new JsonWriter();

            Properties.Settings.Default.Locations = writter.Write(locations);
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// Loads the current location into memory from the locations list and the stored current location index
        /// </summary>
        private void loadDefaultLocation()
        {
            // User Setting
            int currentLocationIndex = Properties.Settings.Default.DefaultLocation;

            this.SetLocation(currentLocationIndex);
        }


        #endregion

        #region Properties

        public Location CurrentLocation
        {
            get { return currentLocation; }
        }

        public List<Location> Locations
        {
            get { return locations; }
        }

        #endregion


    }
}
