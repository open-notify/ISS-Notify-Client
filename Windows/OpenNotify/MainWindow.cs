using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OpenNotify
{
    public partial class MainWindow : Form
    {

        #region Class Variables

        private UserInterface gui = UserInterface.GetInstance();
        private Location location;
        private List<Location> locations;

        #endregion

        public MainWindow()
        {
            location = gui.CurrentLocation;
            locations = gui.Locations;

            // Initialize
            InitializeComponent();
            this.populateLocationsDropDwn();
            this.UpdateLocationFields();

            /*
            DateTime now = DateTime.Now;
            DateTime lastUpdate = Properties.Settings.Default.LastUpdate;

            TimeSpan sinceUpdate = now.Subtract(lastUpdate);
            LastUpdateTxt.Text = String.Format("{0:d/M/yyyy HH:mm:ss}", lastUpdate);
            LastUpdateTxt.Text += String.Format("{0:  (0 days }", sinceUpdate.Days);
            LastUpdateTxt.Text += String.Format("{0:0 hours ago)}", sinceUpdate.Hours);
            */
        }

        #region Private Methods

        /// <summary>
        /// Draw the current location's data in the location fields
        /// </summary>
        private void UpdateLocationFields()
        {
            // Set the current location
            LatTxt.Text = String.Format("{0:0.0####}", location.Latitude);
            LonTxt.Text = String.Format("{0:0.0####}", location.Longitude);
            AltTxt.Text = String.Format("{0:0}", location.Altitude);
        }

        /// <summary>
        /// Populate the locations drop down
        /// </summary>
        private void populateLocationsDropDwn()
        {
            LocationsDropDwn.Items.Clear();
            foreach (Location loc in locations)
            {
                LocationsDropDwn.Items.Add(loc);
            }

            // Always show the manage locations option
            LocationsDropDwn.Items.Add("Manage Locations...");

            LocationsDropDwn.SelectedIndex = gui.CurrentLocation.Index;
        }

        #endregion

        #region Events 

        private void GetPassBtn_Click(object sender, EventArgs e)
        {
            OpenNotify notify = new OpenNotify(location);
            


            /*
            ApiResponse data = notifier.GetPasses();

            for (int i = 0; i < 4; i++)
            {
                string passString = String.Format("{0:0}", i+1);
                passString += " -  ";
                passString += String.Format("{0:yyyy/d/M   HH:mm:ss}", data.Passes[i].RiseTime);

                UpcomingPassList.Items.Add(passString);

            }
            */
        }

        private void LocationsDropDwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = LocationsDropDwn.SelectedIndex;
            if (LocationsDropDwn.SelectedItem.ToString() == "Manage Locations...")
            {
                ManageLocations locationManageForm = new ManageLocations(this);
                locationManageForm.Show();

                // Set index back to the location
                LocationsDropDwn.SelectedIndex = location.Index;
            }
            else
            {
                gui.SetLocation(index);
                location = gui.CurrentLocation;
                this.UpdateLocationFields();
            }
        }

        public override void Refresh()
        {
            location = gui.CurrentLocation;
            locations = gui.Locations;

            this.populateLocationsDropDwn();
            this.UpdateLocationFields();
            base.Refresh();
        }

        #endregion

    }
}
