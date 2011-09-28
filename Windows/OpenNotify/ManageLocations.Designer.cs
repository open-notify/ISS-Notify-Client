namespace OpenNotify
{
    partial class ManageLocations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageLocations));
            this.updateBox = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.placeNameLbl = new System.Windows.Forms.Label();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.altLabel = new System.Windows.Forms.Label();
            this.lonLabel = new System.Windows.Forms.Label();
            this.latLabel = new System.Windows.Forms.Label();
            this.DefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.AltitudeTxt = new System.Windows.Forms.TextBox();
            this.LongitudeTxt = new System.Windows.Forms.TextBox();
            this.LatitudeTxt = new System.Windows.Forms.TextBox();
            this.MapArea = new System.Windows.Forms.PictureBox();
            this.LatitudeSlider = new System.Windows.Forms.TrackBar();
            this.LongitudeSlider = new System.Windows.Forms.TrackBar();
            this.locationsBox = new System.Windows.Forms.GroupBox();
            this.NewLocationBtn = new System.Windows.Forms.Button();
            this.LocationsDropDwn = new System.Windows.Forms.ComboBox();
            this.altUnitsLbl = new System.Windows.Forms.Label();
            this.DeleteLocationBtn = new System.Windows.Forms.Button();
            this.updateBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LatitudeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongitudeSlider)).BeginInit();
            this.locationsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateBox
            // 
            this.updateBox.Controls.Add(this.altUnitsLbl);
            this.updateBox.Controls.Add(this.SaveButton);
            this.updateBox.Controls.Add(this.placeNameLbl);
            this.updateBox.Controls.Add(this.NameTxt);
            this.updateBox.Controls.Add(this.altLabel);
            this.updateBox.Controls.Add(this.lonLabel);
            this.updateBox.Controls.Add(this.latLabel);
            this.updateBox.Controls.Add(this.DefaultCheckBox);
            this.updateBox.Controls.Add(this.AltitudeTxt);
            this.updateBox.Controls.Add(this.LongitudeTxt);
            this.updateBox.Controls.Add(this.LatitudeTxt);
            this.updateBox.Controls.Add(this.MapArea);
            this.updateBox.Controls.Add(this.LatitudeSlider);
            this.updateBox.Controls.Add(this.LongitudeSlider);
            this.updateBox.Location = new System.Drawing.Point(13, 71);
            this.updateBox.Name = "updateBox";
            this.updateBox.Size = new System.Drawing.Size(776, 500);
            this.updateBox.TabIndex = 0;
            this.updateBox.TabStop = false;
            this.updateBox.Text = "Edit Location";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(695, 75);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // placeNameLbl
            // 
            this.placeNameLbl.AutoSize = true;
            this.placeNameLbl.Location = new System.Drawing.Point(7, 20);
            this.placeNameLbl.Name = "placeNameLbl";
            this.placeNameLbl.Size = new System.Drawing.Size(68, 13);
            this.placeNameLbl.TabIndex = 11;
            this.placeNameLbl.Text = "Place Name:";
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(81, 17);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(269, 20);
            this.NameTxt.TabIndex = 10;
            this.NameTxt.TextChanged += new System.EventHandler(this.NameTxt_TextChanged);
            // 
            // altLabel
            // 
            this.altLabel.AutoSize = true;
            this.altLabel.Location = new System.Drawing.Point(366, 60);
            this.altLabel.Name = "altLabel";
            this.altLabel.Size = new System.Drawing.Size(45, 13);
            this.altLabel.TabIndex = 9;
            this.altLabel.Text = "Altitude:";
            // 
            // lonLabel
            // 
            this.lonLabel.AutoSize = true;
            this.lonLabel.Location = new System.Drawing.Point(366, 38);
            this.lonLabel.Name = "lonLabel";
            this.lonLabel.Size = new System.Drawing.Size(57, 13);
            this.lonLabel.TabIndex = 8;
            this.lonLabel.Text = "Longitude:";
            // 
            // latLabel
            // 
            this.latLabel.AutoSize = true;
            this.latLabel.Location = new System.Drawing.Point(366, 16);
            this.latLabel.Name = "latLabel";
            this.latLabel.Size = new System.Drawing.Size(48, 13);
            this.latLabel.TabIndex = 7;
            this.latLabel.Text = "Latitude:";
            // 
            // DefaultCheckBox
            // 
            this.DefaultCheckBox.AutoSize = true;
            this.DefaultCheckBox.Location = new System.Drawing.Point(10, 47);
            this.DefaultCheckBox.Name = "DefaultCheckBox";
            this.DefaultCheckBox.Size = new System.Drawing.Size(165, 17);
            this.DefaultCheckBox.TabIndex = 6;
            this.DefaultCheckBox.Text = "Make this the default location";
            this.DefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // AltitudeTxt
            // 
            this.AltitudeTxt.Location = new System.Drawing.Point(429, 57);
            this.AltitudeTxt.Name = "AltitudeTxt";
            this.AltitudeTxt.Size = new System.Drawing.Size(66, 20);
            this.AltitudeTxt.TabIndex = 5;
            this.AltitudeTxt.TextChanged += new System.EventHandler(this.AltitudeTxt_TextChanged);
            // 
            // LongitudeTxt
            // 
            this.LongitudeTxt.Location = new System.Drawing.Point(429, 35);
            this.LongitudeTxt.Name = "LongitudeTxt";
            this.LongitudeTxt.Size = new System.Drawing.Size(133, 20);
            this.LongitudeTxt.TabIndex = 4;
            this.LongitudeTxt.TextChanged += new System.EventHandler(this.LongitudeTxt_TextChanged);
            // 
            // LatitudeTxt
            // 
            this.LatitudeTxt.Location = new System.Drawing.Point(429, 13);
            this.LatitudeTxt.Name = "LatitudeTxt";
            this.LatitudeTxt.Size = new System.Drawing.Size(133, 20);
            this.LatitudeTxt.TabIndex = 3;
            this.LatitudeTxt.TextChanged += new System.EventHandler(this.LatitudeTxt_TextChanged);
            // 
            // MapArea
            // 
            this.MapArea.Image = ((System.Drawing.Image)(resources.GetObject("MapArea.Image")));
            this.MapArea.Location = new System.Drawing.Point(58, 134);
            this.MapArea.Name = "MapArea";
            this.MapArea.Size = new System.Drawing.Size(700, 350);
            this.MapArea.TabIndex = 2;
            this.MapArea.TabStop = false;
            this.MapArea.Paint += new System.Windows.Forms.PaintEventHandler(this.MapArea_Paint);
            // 
            // LatitudeSlider
            // 
            this.LatitudeSlider.Location = new System.Drawing.Point(7, 124);
            this.LatitudeSlider.Maximum = 120;
            this.LatitudeSlider.Name = "LatitudeSlider";
            this.LatitudeSlider.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LatitudeSlider.Size = new System.Drawing.Size(45, 370);
            this.LatitudeSlider.TabIndex = 1;
            this.LatitudeSlider.TickFrequency = 10;
            this.LatitudeSlider.Value = 60;
            this.LatitudeSlider.Scroll += new System.EventHandler(this.LatitudeSlider_Scroll);
            // 
            // LongitudeSlider
            // 
            this.LongitudeSlider.Location = new System.Drawing.Point(45, 104);
            this.LongitudeSlider.Maximum = 240;
            this.LongitudeSlider.Name = "LongitudeSlider";
            this.LongitudeSlider.Size = new System.Drawing.Size(725, 45);
            this.LongitudeSlider.TabIndex = 0;
            this.LongitudeSlider.TickFrequency = 10;
            this.LongitudeSlider.Value = 120;
            this.LongitudeSlider.Scroll += new System.EventHandler(this.LongitudeSlider_Scroll);
            // 
            // locationsBox
            // 
            this.locationsBox.Controls.Add(this.DeleteLocationBtn);
            this.locationsBox.Controls.Add(this.NewLocationBtn);
            this.locationsBox.Controls.Add(this.LocationsDropDwn);
            this.locationsBox.Location = new System.Drawing.Point(13, 13);
            this.locationsBox.Name = "locationsBox";
            this.locationsBox.Size = new System.Drawing.Size(776, 52);
            this.locationsBox.TabIndex = 1;
            this.locationsBox.TabStop = false;
            this.locationsBox.Text = "My Locations";
            // 
            // NewLocationBtn
            // 
            this.NewLocationBtn.Location = new System.Drawing.Point(282, 19);
            this.NewLocationBtn.Name = "NewLocationBtn";
            this.NewLocationBtn.Size = new System.Drawing.Size(101, 23);
            this.NewLocationBtn.TabIndex = 1;
            this.NewLocationBtn.Text = "New Location";
            this.NewLocationBtn.UseVisualStyleBackColor = true;
            this.NewLocationBtn.Click += new System.EventHandler(this.NewLocationBtn_Click);
            // 
            // LocationsDropDwn
            // 
            this.LocationsDropDwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationsDropDwn.FormattingEnabled = true;
            this.LocationsDropDwn.Location = new System.Drawing.Point(7, 20);
            this.LocationsDropDwn.Name = "LocationsDropDwn";
            this.LocationsDropDwn.Size = new System.Drawing.Size(269, 21);
            this.LocationsDropDwn.TabIndex = 0;
            this.LocationsDropDwn.SelectedIndexChanged += new System.EventHandler(this.LocationsDropDwn_SelectedIndexChanged);
            // 
            // altUnitsLbl
            // 
            this.altUnitsLbl.AutoSize = true;
            this.altUnitsLbl.Location = new System.Drawing.Point(496, 60);
            this.altUnitsLbl.Name = "altUnitsLbl";
            this.altUnitsLbl.Size = new System.Drawing.Size(45, 13);
            this.altUnitsLbl.TabIndex = 13;
            this.altUnitsLbl.Text = "[Meters]";
            // 
            // DeleteLocationBtn
            // 
            this.DeleteLocationBtn.Location = new System.Drawing.Point(646, 18);
            this.DeleteLocationBtn.Name = "DeleteLocationBtn";
            this.DeleteLocationBtn.Size = new System.Drawing.Size(124, 23);
            this.DeleteLocationBtn.TabIndex = 2;
            this.DeleteLocationBtn.Text = "Delete This Location";
            this.DeleteLocationBtn.UseVisualStyleBackColor = true;
            this.DeleteLocationBtn.Click += new System.EventHandler(this.DeleteLocationBtn_Click);
            // 
            // ManageLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 580);
            this.Controls.Add(this.locationsBox);
            this.Controls.Add(this.updateBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageLocations";
            this.Text = "ISS Notify - Manage Locations";
            this.updateBox.ResumeLayout(false);
            this.updateBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LatitudeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongitudeSlider)).EndInit();
            this.locationsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox updateBox;
        private System.Windows.Forms.GroupBox locationsBox;
        private System.Windows.Forms.ComboBox LocationsDropDwn;
        private System.Windows.Forms.PictureBox MapArea;
        private System.Windows.Forms.TrackBar LatitudeSlider;
        private System.Windows.Forms.TrackBar LongitudeSlider;
        private System.Windows.Forms.Label lonLabel;
        private System.Windows.Forms.Label latLabel;
        private System.Windows.Forms.CheckBox DefaultCheckBox;
        private System.Windows.Forms.TextBox AltitudeTxt;
        private System.Windows.Forms.TextBox LongitudeTxt;
        private System.Windows.Forms.TextBox LatitudeTxt;
        private System.Windows.Forms.Label altLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label placeNameLbl;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Button NewLocationBtn;
        private System.Windows.Forms.Label altUnitsLbl;
        private System.Windows.Forms.Button DeleteLocationBtn;
    }
}