import framework

class MainWindow(object):
  
  def __init__(self, controller, model):
    self.window = framework.Window(None, "ISS Notify Update", (400,750))
    self.model = model
    self.control = controller
    
    self.init_UI()
    self.update_view()
    
    self.window.add_widgets()

  def init_UI(self):
  
    # Device
    self.device_box     = self.window.add_box("Device")
    self.device_status  = self.window.add_textinfo(self.device_box, 0, "Status:")
    self.connect_btn    = self.window.add_button(self.device_box, 1, "Connect", self.connect_press)
    
    # Location
    self.location_box   = self.window.add_box("Location")
    self.current_loc    = self.window.add_dropdown(self.location_box, 0, "My Location:")
    self.current_lat    = self.window.add_textbox(self.location_box,  1, "Latitude:",  "deg")
    self.current_lon    = self.window.add_textbox(self.location_box,  2, "Longitude:", "deg")
    self.current_alt    = self.window.add_textbox(self.location_box,  3, "Altitude:", "meters")
    self.manage_loc     = self.window.add_button(self.location_box,   4, "Manage Locations", self.manage_loc_press)
    
    # Passes
    self.time_box       = self.window.add_box("ISS Passes")
    self.current_time   = self.window.add_textinfo(self.time_box, 0, "Next Pass:")
    self.get_pass_btn    = self.window.add_button(self.time_box, 1, "Get Next Pass", self.get_pass_press)
    
    # TEST 
    self.test_box       = self.window.add_box("Testing")
    self.blink_btn      = self.window.add_button(self.test_box, 0, "Blink", self.blink_press)
    self.read_clock_btn = self.window.add_button(self.test_box, 1, "Read Clock", self.read_clock_press)
    self.set_clock_btn  = self.window.add_button(self.test_box, 2, "Set Clock", self.set_clock_press)
    self.clear_alarm_btn= self.window.add_button(self.test_box, 3, "Clear Alarms", self.clear_alarm_press)
    self.set_alarm_btn  = self.window.add_button(self.test_box, 4, "Set Alarm", self.set_alarm_press)
    self.get_ms_btn     = self.window.add_button(self.test_box, 5, "Get ms", self.get_ms_press)
    
    

  def connect_press(self, click_arg):
    self.control.connect()

  def manage_loc_press(self, click_arg):
    popup = ManageLocations()

  def blink_press(self, click_arg):
    color = self.window.color()
    self.control.blink(color)

  def read_clock_press(self, click_arg):
    self.control.read_clock()

  def set_clock_press(self, click_arg):
    self.control.set_clock()

  def get_pass_press(self, click_arg):
    self.control.get_next_pass()

  def clear_alarm_press(self, click_arg):
    self.control.clear_alarm()

  def set_alarm_press(self, click_arg):
    self.control.set_alarm()
    
  def get_ms_press(self, click_arg):
    self.control.get_ms()

  def update_view(self):
 
    # Device 
    if self.model.device_connected:
      self.device_status.SetLabel("Connected" + self.model.device_battery_message)
      self.connect_btn.SetLabel("...")
      self.blink_btn.Enable()
    else:
      self.device_status.SetLabel("Not Connected")
      self.blink_btn.Disable()
 
    # Location
    loc = self.model.location
    
    self.current_loc.Clear()
    for location in self.model.all_locations:
        self.current_loc.Append(location.name)
    self.current_loc.SetValue(loc.name)
    self.current_lat.SetValue(framework.LATITUDE_FORMAT  % loc.latitude)
    self.current_lon.SetValue(framework.LONGITUDE_FORMAT % loc.longitude)
    self.current_alt.SetValue(framework.ALTITUDE_FORMAT  % loc.altitude)
    
    # Passes
    self.current_time.SetLabel(self.model.next_pass)

#======================================================================================
class ManageLocations(object):

    def __init__(self):
        self.window = framework.Window(None, "Manage Locations", (600,400))
        self.init_UI()
        self.update_view()
        self.window.add_widgets()

    def init_UI(self):
        # Pick Location
        self.loc_pick_box       = self.window.add_box("Edit Location")
        self.current_loc    = self.window.add_dropdown(self.loc_pick_box, 0, "Location:")

        # Edit Location
        self.loc_edit_box       = self.window.add_box("Edit Location")

    def update_view(self):
        pass
