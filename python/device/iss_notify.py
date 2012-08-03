import serial
import time

DEVICE_PORT = '/dev/ttyACM0'

class ISSNotify:

  def __init__(self):
    self.conneced = False
    self.battery_status = ""
  
  def connect(self):
    try:
      ser = serial.Serial(DEVICE_PORT, 9600, timeout=0.1)

      ser.write("hello?")
      #print "hello?"

      line  = ser.readline()
      if line != "":
        #print line
        if line[0:2] == "hi":
          #print "connected"
          self.conneced = True
          return
      ser.close()
    except:
      print "No device"
    
    self.conneced = False

  def get_battery_status(self):
    try:
      ser = serial.Serial(DEVICE_PORT, 9600, timeout=0.1)
      ser.write("bat?")
      #print "bat?"
      line  = ser.readline()
      if line != "":
        #print line
        if "CHARGING" in line:
          self.battery_status = "Battery: charging"
        elif "CHARGED" in line:
          self.battery_status = "Battery: charged"
      ser.close()
    except:
      print "No device"
      self.battery_status = ""
      self.conneced = False
