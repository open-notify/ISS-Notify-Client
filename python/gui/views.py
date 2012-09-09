import framework

class MainWindow(object):
  
  def __init__(self, controller, model):
    self.window = framework.Window(None, "ISS Notify Update")
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
    self.current_lat    = self.window.add_textbox(self.location_box, 1, "Latitude:",  "deg")
    self.current_lon    = self.window.add_textbox(self.location_box, 2, "Longitude:", "deg")
    self.current_alt    = self.window.add_textbox(self.location_box, 3, "Altitude:", "meters")
    
    # Passes
    self.time_box       = self.window.add_box("ISS Passes")
    self.current_time   = self.window.add_textinfo(self.time_box, 0, "Next Pass:")
    self.get_pass_btn    = self.window.add_button(self.time_box, 1, "Get Next Pass", self.get_pass_press)
    
    # TEST 
    self.test_box       = self.window.add_box("Testing")
    self.blink_btn      = self.window.add_button(self.test_box, 0, "Blink", self.blink_press)
    self.read_clock_btn = self.window.add_button(self.test_box, 1, "Read Clock", self.read_clock_press)
    self.set_clock_btn  = self.window.add_button(self.test_box, 2, "Set Clock", self.set_clock_press)

  def connect_press(self, click_arg):
    self.control.connect()
  
  def blink_press(self, click_arg):
    color = self.window.color()
    self.control.blink(color)

  def read_clock_press(self, click_arg):
    self.control.read_clock()

  def set_clock_press(self, click_arg):
    self.control.set_clock()

  def get_pass_press(self, click_arg):
    self.control.get_next_pass()

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
    
    self.current_loc.SetValue(loc.name)
    self.current_lat.SetValue(framework.LATITUDE_FORMAT  % loc.latitude)
    self.current_lon.SetValue(framework.LONGITUDE_FORMAT % loc.longitude)
    self.current_alt.SetValue(framework.ALTITUDE_FORMAT  % loc.altitude)
    
    # Passes
    self.current_time.SetLabel(self.model.next_pass)
