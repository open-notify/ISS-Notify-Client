using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenNotify
{
    /// <summary>
    /// A windows form that lets you add, update and delete locations from the users locations settings
    /// </summary>
    public partial class ManageLocations : Form
    {
        // Get program context
        private UserInterface gui = UserInterface.GetInstance();
        private Location location;
        private Form mainWindow;

        /// <summary>
        /// A windows form that lets you add, update and delete locations from the users locations settings
        /// </summary>
        /// <param name="sender">The form that opened this window</param>
        public ManageLocations(Form sender)
        {
            // Set context
            location = gui.CurrentLocation;
            mainWindow = sender;

            // Initialize
            InitializeComponent();
            this.populateLocationsDropDwn();
            this.updateLocationFields();
        }

        #region Private Methods

        /// <summary>
        /// Sets the text and the map on the screen to the current location
        /// </summary>
        private void updateLocationFields()
        {
            // Set the current location
            NameTxt.Text = location.PlaceName;
            LatitudeTxt.Text = String.Format("{0:0.0####}", location.Latitude);
            LongitudeTxt.Text = String.Format("{0:0.0####}", location.Longitude);
            AltitudeTxt.Text = String.Format("{0:0}", location.Altitude);

            LatitudeSlider.Value = (int)Math.Round((location.Latitude + 90) / 1.5);
            LongitudeSlider.Value = (int)Math.Round((location.Longitude + 180) / 1.5);

            MapArea.Refresh();
        }

        /// <summary>
        /// Sets the drop down list of locations to the users list of locations
        /// </summary>
        private void populateLocationsDropDwn()
        {
            LocationsDropDwn.Items.Clear();
            List<Location> locations = gui.Locations;
            foreach (Location loc in locations)
            {
                LocationsDropDwn.Items.Add(loc);
            }
            LocationsDropDwn.SelectedIndex = gui.CurrentLocation.Index;
        }

        #endregion

        #region Events

        private void LocationsDropDwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = LocationsDropDwn.SelectedIndex;
            gui.SetLocation(index);
            location = gui.CurrentLocation;
            this.updateLocationFields();
        }

        private void MapArea_Paint(object sender, PaintEventArgs e)
        {
            Color c = Color.FromArgb(140, 255, 200, 30);
            int lon = (int)Math.Round(((location.Longitude + 180) / 360) * MapArea.Size.Width);
            int lat = (int)Math.Round(MapArea.Size.Height - ((location.Latitude + 90) / 180) * MapArea.Size.Height);

            // Longitude
            e.Graphics.DrawLine(
                new Pen(c, 1),
                new Point(lon, 0),
                new Point(lon, MapArea.Size.Height));

            // Latitude
            e.Graphics.DrawLine(
                new Pen(c, 1),
                new Point(0, lat),
                new Point(MapArea.Size.Width, lat));
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            gui.UpdateCurrentLocation(location);

            mainWindow.Refresh();
        }

        private void NewLocationBtn_Click(object sender, EventArgs e)
        {
            Location newLocation = new Location((float)0.0, (float)0.0, 0, "New Place", gui.Locations.Count);
            gui.AddNewLocation(newLocation);
            this.populateLocationsDropDwn();

            LocationsDropDwn.SelectedIndex = newLocation.Index;

            //mainWindow.Refresh();
        }

        private void LongitudeSlider_Scroll(object sender, EventArgs e)
        {
            float lon = (float)(LongitudeSlider.Value * 1.5) - 180;
            location.Longitude = lon;
            this.updateLocationFields();
        }

        private void LatitudeSlider_Scroll(object sender, EventArgs e)
        {
            float lat = (float)(LatitudeSlider.Value * 1.5) - 90;
            location.Latitude = lat;
            this.updateLocationFields();
        }

        private void DeleteLocationBtn_Click(object sender, EventArgs e)
        {
            gui.DeleteLocation(location);

            location = gui.CurrentLocation;

            this.populateLocationsDropDwn();
            this.updateLocationFields();
            mainWindow.Refresh();

        }

        private void AltitudeTxt_TextChanged(object sender, EventArgs e)
        {
            location.Altitude = int.Parse(AltitudeTxt.Text);
        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {
            location.PlaceName = NameTxt.Text;
            this.populateLocationsDropDwn();
        }

        private void LatitudeTxt_TextChanged(object sender, EventArgs e)
        {
            location.Latitude = float.Parse(LatitudeTxt.Text);
            LatitudeSlider.Value = (int)Math.Round((location.Latitude + 90) / 1.5);
            MapArea.Refresh();
        }

        private void LongitudeTxt_TextChanged(object sender, EventArgs e)
        {
            location.Longitude = float.Parse(LongitudeTxt.Text);
            LongitudeSlider.Value = (int)Math.Round((location.Longitude + 180) / 1.5);
            MapArea.Refresh();
        }

        #endregion

    }
}
