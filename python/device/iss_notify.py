# -*- encoding: utf-8 -*-
import serial
import datetime
import time

DEVICE_PORT     = '/dev/ttyACM0'
DEVICE_BAUD     = 9600

class ISSNotify:

  def __init__(self):
    self.conneced = False
    self.battery_status = ""

  def claim_device(self):
    s = serial.Serial(DEVICE_PORT, DEVICE_BAUD, timeout=0.1)
    return s
  
  def read_fail(self):
    print "No device"
    self.battery_status = ""
    self.conneced = False
  
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

  def lights_color(self, c):
    #print c

    c = self.rgb2device(c)
    
    #print c
    
    try: 
        ser = self.claim_device()
        #print "c" + str(c)
        ser.write("c" + str(c))
        ser.close()
    except:
        self.read_fail()
  
  def set_color(self, c):
    c = self.rgb2device(c)
   
    try:
        ser = self.claim_device()
        print "setc"+str(c)
        ser.write("setc"+str(c))
        ser.close()
    except:
        self.read_fail()

  def rgb2device(self, color):
    
    r = color[0] / 30
    g = color[1] / 30
    b = color[2] / 30
    
    c = r + (g<<4) + (b<<8)
    
    return c

  def read_time(self):
    try:
      ser = self.claim_device()
      ser.write("t?")
      line  = ser.readline()
      if line != "":

        year = int(line[1:3])
        
        # Fix 8 bit year
        if year < 70: year = year + 2000
        else: year = year + 1900
        
        month   = int(line[ 4: 6])
        day     = int(line[ 7: 9])
        hour    = int(line[10:12])
        minute  = int(line[13:15])
        second  = int(line[16:18])
        print year, month, day, hour, minute, second
        
        device_time   = datetime.datetime(year, month, day, hour, minute, second)
        comp_time_utc = datetime.datetime.utcnow()
        diff          = (device_time - comp_time_utc)
        
        print "From Device:", device_time.strftime('%Y-%m-%d %H:%M:%S')
        print "Real       :", comp_time_utc.strftime('%Y-%m-%d %H:%M:%S')
        print "Difference :", diff.total_seconds()
        
      ser.close()
    except:
      self.read_fail()

  def set_time(self):
    try:
      ser = self.claim_device()
      
      comp_time_utc = datetime.datetime.utcnow()
      tstring = comp_time_utc.strftime('TY%yM%mD%dH%HM%MS%S')
      ser.write(tstring)
      print tstring
      
      print ser.readline()
      ser.close()
    except:
      self.read_fail()

  def set_alarm(self):
    try:
      ser = self.claim_device()
      
      alarm = datetime.datetime.utcnow()
      alarm = alarm + datetime.timedelta(seconds=5)
      tstring = alarm.strftime('AY%yM%mD%dH%HM%MS%S')
      ser.write(tstring)
      print tstring
      
      print ser.readline()
      ser.close()
    except:
      self.read_fail()

  def clear_alarm0(self):
    try:
      ser = self.claim_device()
      print "ra?"
      ser.write("ra?")
      print ser.readline()
      ser.close()
    except:
      self.read_fail()

  def get_ms(self):
    try:
      ser = self.claim_device()
      print "ms?"
      ser.write("ms?")
      print ser.readline()
      ser.close()
    except:
      self.read_fail()
