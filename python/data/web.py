# -*- encoding: utf-8 -*-
import urllib2
import simplejson
import data.locations as models
import datetime

class OpenNotifyAPI:
    """A class to interact with a web api for looking up
    ISS pass times for a location.
    """
    
    DOMAIN = "http://api.open-notify.org"
    PASS_SERVICE = "/iss/v1/"

    def __init__(self):
        pass

    def get_next_pass(self, location):

        # Build URL to API
        baseurl = self.DOMAIN + self.PASS_SERVICE

        lat = location.latitude
        lon = location.longitude
        alt = location.altitude

        # Query String with lat, lon, alt and n=1 (one pass only)
        url = baseurl + "?lat=%f&lon=%f&alt=%d&f&n=1" % (lat, lon, alt)

        # make http request
        response = urllib2.urlopen(url)
        
        #DEBUG:
        #print url
        #print response

        data = simplejson.loads(response.read())

        # return the next rise time as a pass
        p = models.Pass()
        p.dt = datetime.datetime.fromtimestamp(int(data["response"][0]["risetime"]))
        p.duration = float(data["response"][0]["duration"]) / 60.0
        return p

    def timestr(self, unixtime):
        """Helper to convert unix timestamp to string"""

        return datetime.datetime.fromtimestamp(int(unixtime)).strftime('%Y-%m-%d %H:%M:%S UTC')

