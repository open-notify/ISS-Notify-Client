import urllib2
import simplejson
import data.locations
import datetime

class OpenNotifyAPI:

  DOMAIN = "http://api.open-notify.org"
  PASS_SERVICE = "/iss/v1/"
  
  def __init__(self):
    pass
  
  def get_pass(self, location):
    baseurl = self.DOMAIN + self.PASS_SERVICE
    
    lat = location.latitude
    lon = location.longitude
    alt = location.altitude
    
    url = baseurl + "?lat=%f&lon=%f&alt=%d&f&n=1" % (lat, lon, alt)

    #print url
    
    response = urllib2.urlopen(url)
    data = simplejson.loads(response.read())

    return self.timestr(data["response"][0]["risetime"])
    
  def timestr(self, unixtime):
    return datetime.datetime.fromtimestamp(int(unixtime)).strftime('%Y-%m-%d %H:%M:%S UTC')
