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
    
    # Location
    self.location_box   = self.window.add_box("Location")
    self.current_loc    = self.window.add_dropdown(self.location_box, 0, "My Location:")
    self.current_lat    = self.window.add_textbox(self.location_box, 1, "Latitude:",  "deg")
    self.current_lon    = self.window.add_textbox(self.location_box, 2, "Longitude:", "deg")
    self.current_alt    = self.window.add_textbox(self.location_box, 3, "Altitude:", "meters")
    
    # Passes
    self.time_box       = self.window.add_box("ISS Passes")
    self.current_time   = self.window.add_textinfo(self.time_box, 0, "Time now")
    
    
    self.test_box       = self.window.add_box("Testing")
    self.blink_btn      = self.window.add_button(self.test_box, 0, "Blink", self.blink_press)

  def blink_press(self, click_arg):
    color = self.window.color()
    self.control.blink(color)

  def update_view(self):
 
    # Device 
    self.device_status.SetLabel("Not Connected")
 
    # Location
    loc = self.model.location
    
    self.current_loc.SetValue(loc.name)
    self.current_lat.SetValue(framework.LATITUDE_FORMAT  % loc.latitude)
    self.current_lon.SetValue(framework.LONGITUDE_FORMAT % loc.longitude)
    self.current_alt.SetValue(framework.ALTITUDE_FORMAT  % loc.altitude)
