# -*- encoding: utf-8 -*-
import urllib2
import json
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

    def build_url(self, l, n):
        # Build URL to API
        baseurl = self.DOMAIN + self.PASS_SERVICE

        lat = l.latitude
        lon = l.longitude
        alt = l.altitude

        # Query String with lat, lon, alt and n=1 (one pass only)
        return baseurl + "?lat=%f&lon=%f&alt=%d&f&n=%d" % (lat, lon, alt, n)


    def get_next_pass(self, location):

        url = self.build_url(location, 1)

        # make http request
        response = urllib2.urlopen(url)
        
        #DEBUG:
        #print url
        #print response

        data = json.loads(response.read())

        # return the next rise time as a pass
        p = models.Pass()
        p.dt = datetime.datetime.fromtimestamp(int(data["response"][0]["risetime"]))
        p.duration = float(data["response"][0]["duration"]) / 60.0
        return p

    def get_passes(self, location, n):

        # make http request
        url = self.build_url(location, n)
        response = urllib2.urlopen(url)
        # Read data
        data = json.loads(response.read())

        passes = []
        for entry in data["response"]:
            p = models.Pass()
            p.dt = datetime.datetime.fromtimestamp(int(entry["risetime"]))
            p.duration = float(entry["duration"]) / 60.0
            passes.append(p)

        return passes


    def timestr(self, unixtime):
        """Helper to convert unix timestamp to string"""

        return datetime.datetime.fromtimestamp(int(unixtime)).strftime('%Y-%m-%d %H:%M:%S UTC')

