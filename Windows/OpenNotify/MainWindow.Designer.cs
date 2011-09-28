namespace OpenNotify
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.GetPassBtn = new System.Windows.Forms.Button();
            this.LocationGroupBox = new System.Windows.Forms.GroupBox();
            this.LocationsDropDwn = new System.Windows.Forms.ComboBox();
            this.UnitLbl3 = new System.Windows.Forms.Label();
            this.AltTxt = new System.Windows.Forms.Label();
            this.AltLabel = new System.Windows.Forms.Label();
            this.LonTxt = new System.Windows.Forms.Label();
            this.LonLabel = new System.Windows.Forms.Label();
            this.LatTxt = new System.Windows.Forms.Label();
            this.LatLabel = new System.Windows.Forms.Label();
            this.locationNameLabel = new System.Windows.Forms.Label();
            this.NextPassGroupBox = new System.Windows.Forms.GroupBox();
            this.UpcomingPassList = new System.Windows.Forms.ListBox();
            this.SeeAllPassesBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NextPassTimeTxt = new System.Windows.Forms.Label();
            this.UpdateGroupBox = new System.Windows.Forms.GroupBox();
            this.LastUpdateTxt = new System.Windows.Forms.Label();
            this.LastUpdateLbl = new System.Windows.Forms.Label();
            this.LocationGroupBox.SuspendLayout();
            this.NextPassGroupBox.SuspendLayout();
            this.UpdateGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetPassBtn
            // 
            this.GetPassBtn.Location = new System.Drawing.Point(9, 48);
            this.GetPassBtn.Name = "GetPassBtn";
            this.GetPassBtn.Size = new System.Drawing.Size(110, 23);
            this.GetPassBtn.TabIndex = 0;
            this.GetPassBtn.Text = "Update Passes";
            this.GetPassBtn.UseVisualStyleBackColor = true;
            this.GetPassBtn.Click += new System.EventHandler(this.GetPassBtn_Click);
            // 
            // LocationGroupBox
            // 
            this.LocationGroupBox.Controls.Add(this.LocationsDropDwn);
            this.LocationGroupBox.Controls.Add(this.UnitLbl3);
            this.LocationGroupBox.Controls.Add(this.AltTxt);
            this.LocationGroupBox.Controls.Add(this.AltLabel);
            this.LocationGroupBox.Controls.Add(this.LonTxt);
            this.LocationGroupBox.Controls.Add(this.LonLabel);
            this.LocationGroupBox.Controls.Add(this.LatTxt);
            this.LocationGroupBox.Controls.Add(this.LatLabel);
            this.LocationGroupBox.Controls.Add(this.locationNameLabel);
            this.LocationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.LocationGroupBox.Name = "LocationGroupBox";
            this.LocationGroupBox.Size = new System.Drawing.Size(383, 120);
            this.LocationGroupBox.TabIndex = 2;
            this.LocationGroupBox.TabStop = false;
            this.LocationGroupBox.Text = "Location";
            // 
            // LocationsDropDwn
            // 
            this.LocationsDropDwn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationsDropDwn.FormattingEnabled = true;
            this.LocationsDropDwn.Location = new System.Drawing.Point(83, 20);
            this.LocationsDropDwn.Name = "LocationsDropDwn";
            this.LocationsDropDwn.Size = new System.Drawing.Size(290, 21);
            this.LocationsDropDwn.TabIndex = 10;
            this.LocationsDropDwn.SelectedIndexChanged += new System.EventHandler(this.LocationsDropDwn_SelectedIndexChanged);
            // 
            // UnitLbl3
            // 
            this.UnitLbl3.AutoSize = true;
            this.UnitLbl3.Location = new System.Drawing.Point(154, 86);
            this.UnitLbl3.Name = "UnitLbl3";
            this.UnitLbl3.Size = new System.Drawing.Size(45, 13);
            this.UnitLbl3.TabIndex = 9;
            this.UnitLbl3.Text = "[Meters]";
            // 
            // AltTxt
            // 
            this.AltTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AltTxt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AltTxt.Location = new System.Drawing.Point(83, 86);
            this.AltTxt.Name = "AltTxt";
            this.AltTxt.Size = new System.Drawing.Size(70, 16);
            this.AltTxt.TabIndex = 4;
            // 
            // AltLabel
            // 
            this.AltLabel.AutoSize = true;
            this.AltLabel.Location = new System.Drawing.Point(7, 87);
            this.AltLabel.Name = "AltLabel";
            this.AltLabel.Size = new System.Drawing.Size(45, 13);
            this.AltLabel.TabIndex = 6;
            this.AltLabel.Text = "Altitude:";
            // 
            // LonTxt
            // 
            this.LonTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LonTxt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LonTxt.Location = new System.Drawing.Point(83, 67);
            this.LonTxt.Name = "LonTxt";
            this.LonTxt.Size = new System.Drawing.Size(144, 16);
            this.LonTxt.TabIndex = 3;
            // 
            // LonLabel
            // 
            this.LonLabel.AutoSize = true;
            this.LonLabel.Location = new System.Drawing.Point(6, 67);
            this.LonLabel.Name = "LonLabel";
            this.LonLabel.Size = new System.Drawing.Size(57, 13);
            this.LonLabel.TabIndex = 4;
            this.LonLabel.Text = "Longitude:";
            // 
            // LatTxt
            // 
            this.LatTxt.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LatTxt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LatTxt.Location = new System.Drawing.Point(83, 45);
            this.LatTxt.Name = "LatTxt";
            this.LatTxt.Size = new System.Drawing.Size(144, 16);
            this.LatTxt.TabIndex = 2;
            // 
            // LatLabel
            // 
            this.LatLabel.AutoSize = true;
            this.LatLabel.Location = new System.Drawing.Point(6, 45);
            this.LatLabel.Name = "LatLabel";
            this.LatLabel.Size = new System.Drawing.Size(48, 13);
            this.LatLabel.TabIndex = 2;
            this.LatLabel.Text = "Latitude:";
            // 
            // locationNameLabel
            // 
            this.locationNameLabel.AutoSize = true;
            this.locationNameLabel.Location = new System.Drawing.Point(6, 23);
            this.locationNameLabel.Name = "locationNameLabel";
            this.locationNameLabel.Size = new System.Drawing.Size(51, 13);
            this.locationNameLabel.TabIndex = 0;
            this.locationNameLabel.Text = "Location:";
            // 
            // NextPassGroupBox
            // 
            this.NextPassGroupBox.Controls.Add(this.UpcomingPassList);
            this.NextPassGroupBox.Controls.Add(this.SeeAllPassesBtn);
            this.NextPassGroupBox.Controls.Add(this.label1);
            this.NextPassGroupBox.Controls.Add(this.NextPassTimeTxt);
            this.NextPassGroupBox.Location = new System.Drawing.Point(12, 138);
            this.NextPassGroupBox.Name = "NextPassGroupBox";
            this.NextPassGroupBox.Size = new System.Drawing.Size(382, 182);
            this.NextPassGroupBox.TabIndex = 3;
            this.NextPassGroupBox.TabStop = false;
            this.NextPassGroupBox.Text = "Upcoming Passes";
            // 
            // UpcomingPassList
            // 
            this.UpcomingPassList.FormattingEnabled = true;
            this.UpcomingPassList.Location = new System.Drawing.Point(10, 65);
            this.UpcomingPassList.Name = "UpcomingPassList";
            this.UpcomingPassList.Size = new System.Drawing.Size(233, 69);
            this.UpcomingPassList.TabIndex = 6;
            // 
            // SeeAllPassesBtn
            // 
            this.SeeAllPassesBtn.Location = new System.Drawing.Point(9, 148);
            this.SeeAllPassesBtn.Name = "SeeAllPassesBtn";
            this.SeeAllPassesBtn.Size = new System.Drawing.Size(110, 23);
            this.SeeAllPassesBtn.TabIndex = 3;
            this.SeeAllPassesBtn.Text = "See All Passes";
            this.SeeAllPassesBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Passes:";
            // 
            // NextPassTimeTxt
            // 
            this.NextPassTimeTxt.AutoSize = true;
            this.NextPassTimeTxt.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextPassTimeTxt.Location = new System.Drawing.Point(9, 16);
            this.NextPassTimeTxt.Name = "NextPassTimeTxt";
            this.NextPassTimeTxt.Size = new System.Drawing.Size(264, 27);
            this.NextPassTimeTxt.TabIndex = 0;
            this.NextPassTimeTxt.Text = "Next Pass in 05:24";
            // 
            // UpdateGroupBox
            // 
            this.UpdateGroupBox.Controls.Add(this.LastUpdateTxt);
            this.UpdateGroupBox.Controls.Add(this.LastUpdateLbl);
            this.UpdateGroupBox.Controls.Add(this.GetPassBtn);
            this.UpdateGroupBox.Location = new System.Drawing.Point(12, 326);
            this.UpdateGroupBox.Name = "UpdateGroupBox";
            this.UpdateGroupBox.Size = new System.Drawing.Size(382, 86);
            this.UpdateGroupBox.TabIndex = 4;
            this.UpdateGroupBox.TabStop = false;
            this.UpdateGroupBox.Text = "Update";
            // 
            // LastUpdateTxt
            // 
            this.LastUpdateTxt.AutoSize = true;
            this.LastUpdateTxt.Location = new System.Drawing.Point(80, 20);
            this.LastUpdateTxt.Name = "LastUpdateTxt";
            this.LastUpdateTxt.Size = new System.Drawing.Size(0, 13);
            this.LastUpdateTxt.TabIndex = 2;
            // 
            // LastUpdateLbl
            // 
            this.LastUpdateLbl.AutoSize = true;
            this.LastUpdateLbl.Location = new System.Drawing.Point(7, 20);
            this.LastUpdateLbl.Name = "LastUpdateLbl";
            this.LastUpdateLbl.Size = new System.Drawing.Size(68, 13);
            this.LastUpdateLbl.TabIndex = 1;
            this.LastUpdateLbl.Text = "Last Update:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 423);
            this.Controls.Add(this.UpdateGroupBox);
            this.Controls.Add(this.NextPassGroupBox);
            this.Controls.Add(this.LocationGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(421, 461);
            this.Name = "MainWindow";
            this.Text = "ISS Notify Update";
            this.LocationGroupBox.ResumeLayout(false);
            this.LocationGroupBox.PerformLayout();
            this.NextPassGroupBox.ResumeLayout(false);
            this.NextPassGroupBox.PerformLayout();
            this.UpdateGroupBox.ResumeLayout(false);
            this.UpdateGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetPassBtn;
        private System.Windows.Forms.GroupBox LocationGroupBox;
        private System.Windows.Forms.Label locationNameLabel;
        private System.Windows.Forms.Label LonTxt;
        private System.Windows.Forms.Label LonLabel;
        private System.Windows.Forms.Label LatTxt;
        private System.Windows.Forms.Label LatLabel;
        private System.Windows.Forms.Label AltLabel;
        private System.Windows.Forms.Label AltTxt;
        private System.Windows.Forms.Label UnitLbl3;
        private System.Windows.Forms.GroupBox NextPassGroupBox;
        private System.Windows.Forms.Label NextPassTimeTxt;
        private System.Windows.Forms.GroupBox UpdateGroupBox;
        private System.Windows.Forms.Label LastUpdateTxt;
        private System.Windows.Forms.Label LastUpdateLbl;
        private System.Windows.Forms.Button SeeAllPassesBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox UpcomingPassList;
        private System.Windows.Forms.ComboBox LocationsDropDwn;
    }
}