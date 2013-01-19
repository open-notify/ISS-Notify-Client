# -*- encoding: utf-8 -*-
import serial
import datetime
import time

DEVICE_PORT = '/dev/ttyACM1'
DEVICE_BAUD = 9600

def parse_time(line):
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


def rgb2device(color):
    r = color[0] / 30
    g = color[1] / 30
    b = color[2] / 30
    return r + (g<<4) + (b<<8)



COMMANDS =  { "syn":   {"code": 'a'},
              "ms":    {"code": 'm'},
              "time":  {"code": 't', "parse": parse_time},
              "color": {"code": 'c'}
            }


class ISSNotify:

    def __init__(self):
        self.conneced = False
        self.verbose = False


    def command(self, cmd, arg=None):
        
        c = "ISS"+COMMANDS[cmd]["code"]+"\n"
        if arg is not None:
            c += arg

        if self.verbose:
            print c

        try: 
            ser = self.claim_device()
            ser.write(c)
            line = ser.readline()
            if self.verbose:
                print line
            if "parse" in COMMANDS[cmd]:
                COMMANDS[cmd]["parse"](line)
            ser.close()
        except:
            self.read_fail()


    def claim_device(self):
        s = serial.Serial(DEVICE_PORT, DEVICE_BAUD, timeout=0.1)
        return s


    def read_fail(self):
        print "No device"
        self.conneced = False

"""
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
    
  def update_passes(self):
    try:
        ser = self.claim_device()
        print "dumping 3 passes"

        ser.write("z3\n")
        ser.write("987654321,512,")
        ser.write("123456555,512,")
        ser.write("1355611869,900,")

        ser.close()
    except:
        self.read_fail()

  def read_block(self):
    try:
        ser = self.claim_device()
        print "getvalue?"
        ser.write("getvalue?")
        for i in range(10):
            print ser.readline(),
        ser.close()
    except:
        self.read_fail()

    """
