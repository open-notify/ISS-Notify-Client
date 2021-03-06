# -*- encoding: utf-8 -*-
import framework
import resources
from datetime import datetime

#========================================================================
# Main window class
#========================================================================
class MainWindow(object):
  
    def __init__(self, controller, model):
        self.window = framework.Window(None, "ISS Notify Update", (680,680))
        self.model = model
        self.control = controller
    
        self.init_UI()
        self.update_view()
    
        self.window.add_widgets()


    def init_UI(self):
        w = self.window
  
        # Device
        self.device_box     = w.add_box("Device")
        self.device_status  = w.add_textinfo(self.device_box,   0, "Status:")
        self.connect        = w.add_connector(self.device_box,  1, self.connect_press, self.pick_comm)
        self.sync_btn       = w.add_button(self.device_box,     2, "Sync", self.sync_press)
    
        # Location
        self.location_box   = w.add_box("Location")
        self.current_loc    = w.add_dropdown(self.location_box, 0, "My Location:", self.pick_loc)
        self.current_lat    = w.add_textinfo(self.location_box, 1, "Latitude, Longitude:")
        self.current_alt    = w.add_textinfo(self.location_box, 2, "Altitude:")
        self.manage_loc     = w.add_button(self.location_box,   3, "Manage Locations", self.manage_loc_press)
    
        # Passes
        self.time_box       = w.add_box("ISS Passes")
        self.next_pass      = w.add_textinfo(self.time_box,     0, "Next Pass:")
        self.all_passes     = w.add_grid(self.time_box,         1, "All Passes:")
        self.get_pass_btn   = w.add_button(self.time_box,       2, "Update Passes", self.get_pass_press)

        # Timer
        #w.add_timer(self.update_time, 1000)


    def update_view(self):

        # Device 
        self.device_status.SetLabel(self.model.device_message)
        if self.model.device_connected:
            #self.connect_btn.SetLabel("...")
            self.sync_btn.Enable()
        else:
            self.sync_btn.Disable()

        self.connect.Clear()
        for port in self.model.devices:
            self.connect.Append(port)
        self.connect.SetValue(self.model.devices[0])

 
        # Location
        loc = self.model.location
 
        self.current_loc.Clear()
        for location in self.model.all_locations:
            self.current_loc.Append(location.name)
        self.current_loc.SetValue(loc.name)

        self.current_lat.SetLabel(framework.LATITUDE_FORMAT % loc.latitude + u"\xb0 N, " + framework.LONGITUDE_FORMAT % loc.longitude + u"\xb0 W")
        self.current_alt.SetLabel(framework.ALTITUDE_FORMAT % loc.altitude + u" meters")

        # Passes
        now = datetime.utcnow()
        for apass in loc.passes:
            if apass.dt > now:
                self.next_pass.SetLabel(str(apass.dt) + " UTC, for %0.1f min." % apass.duration)
                break
        else:
            self.next_pass.SetLabel("...")
    
        # Grid
        # Clear grid
        self.all_passes.ClearGrid()
        n = self.all_passes.GetNumberRows()
        self.all_passes.DeleteRows(0,n)
        # add data to grid
        for i in range(len(loc.passes)):
            p = loc.passes[i]
            self.all_passes.AppendRows(1)
            self.all_passes.SetCellValue(i,0,str(i+1))
            self.all_passes.SetCellValue(i,1,p.dt.strftime("%A (%b. %d) %H:%M:%S UTC"))
            self.all_passes.SetCellValue(i,2,"%4.1f" % p.duration)


    # Events ============================================================
    def connect_press(self, click_arg):
        self.control.connect()

    def pick_comm(self, arg):
        print arg

    def sync_press(self, click_arg):
        self.control.sync_device()

    def pick_loc(self, arg):
        self.control.update_location(self.current_loc.GetValue())

    def manage_loc_press(self, click_arg):
        self.control.manage_locations()

    def get_pass_press(self, click_arg):
        self.control.get_next_pass()


#========================================================================
# Location Manager Class 
#========================================================================
class ManageLocations(object):

    def __init__(self, controller, model):
        self.window = framework.Window(None, "Manage Locations", (540,740), onclose=self.close)
        self.model = model
        self.control = controller
        self.init_UI()
        self.update_view()
        self.window.add_widgets()

    def init_UI(self):
        w = self.window
        # Pick Location
        self.loc_pick_box       = w.add_box("")
        self.current_loc        = w.add_dropdown(self.loc_pick_box, 0, "Location:", self.pick_loc)
        self.new_loc_button     = w.add_button(self.loc_pick_box,   1, "New Location", self.add_new)

        # Edit Location
        self.loc_edit_box       = w.add_box("Edit Location")
        self.loc_name_field     = w.add_textbox(self.loc_edit_box,  0, "Name:", "")
        self.loc_lat_field      = w.add_textbox(self.loc_edit_box,  1, "Latitude:", u"\xb0 N")
        self.loc_lon_field      = w.add_textbox(self.loc_edit_box,  2, "Longitude:", u"\xb0 E")
        self.loc_alt_field      = w.add_textbox(self.loc_edit_box,  3, "Latitdue:", "meters")
        self.default_check      = w.add_checkbox(self.loc_edit_box, 4, "Default Location", self.loc_default)
        self.del_loc_button     = w.add_button(self.loc_edit_box,   5, "Delete this location", self.del_location)

        # Map
        self.map_box            = w.add_box("Map")
        self.map_draw           = w.add_drawing(self.map_box, self.on_paint)

        # Save
        self.save_box           = w.add_box("Save Locations")
        self.save_button        = w.add_button(self.save_box,       0, "Save", self.save_press)

    def update_view(self):
        loc = self.model.location

        self.current_loc.Clear()
        for location in self.model.all_locations:
            self.current_loc.Append(location.name)
        self.current_loc.SetValue(loc.name)
        self.loc_name_field.SetValue(loc.name)
        self.loc_lat_field.SetValue(framework.LATITUDE_FORMAT  % loc.latitude)
        self.loc_lon_field.SetValue(framework.LONGITUDE_FORMAT % loc.longitude)
        self.loc_alt_field.SetValue(framework.ALTITUDE_FORMAT  % loc.altitude)
        self.map_draw.Refresh()

    # Events
    #=======
    def save_press(self, click_arg):
        if self.validate():
            current = {}
            current['name']      = self.loc_name_field.GetValue()
            current['latitude']  = float(self.loc_lat_field.GetValue())
            current['longitude'] = float(self.loc_lon_field.GetValue())
            current['altitude']  =   int(float(self.loc_alt_field.GetValue()))
            self.control.update_locations(current)

    def validate(self):
        #TODO: do something about fixing fields
        try:
            float(self.loc_lat_field.GetValue())
        except:
            return False
        try:
            float(self.loc_lon_field.GetValue())
        except:
            return False
        try:
            int(float(self.loc_alt_field.GetValue()))
        except:
            return False

        return True

    def on_paint(self, event):
        paint = framework.Painter(event)
        paint.draw_map(resources.getworldImage())
        
        loc = self.model.location.scale_lat_lon((500,250))
        paint.draw_cross(loc, 8)

    def loc_default(self, click_arg):
        if self.default_check.GetValue():
            self.control.set_default_loc()

    def add_new(self, click_arg):
        pass

    def pick_loc(self, arg):
        self.control.update_location(self.current_loc.GetValue())

    def del_location(self, click_arg):
        self.control.del_location()

    def close(self):
        self.control.loc_view = None
