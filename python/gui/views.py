import framework

class MainWindow(object):
  
  def __init__(self):
    self.window = framework.Window(None, "Title Pane")
    
    self.location_box = self.window.add_box("Location")
    self.current_lat  = self.window.add_textinfo(self.location_box, 0, "Latitude",  "deg")
    self.current_lon  = self.window.add_textinfo(self.location_box, 1, "Longitude", "deg")
    
    self.time_box     = self.window.add_box("Time")
    self.current_time = self.window.add_textinfo(self.time_box, 0, "Time now", "deg")
    
    self.window.add_widgets()
