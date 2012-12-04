# -*- encoding: utf-8 -*-
import json
import datetime
from math import fabs

#========================================================================
# Location helper. CRUD For list of locations
#========================================================================
class Locations():

    def __init__(self):
        self.locations = []
        self.default = 0
        self.build_list()

    def build_list(self):
        # Special non existant location
        #self.locations.append(Location(0))
        
        # read in location list
        data = self.read_list('locations.json')
        if data:
            for loc in data:
                l = Location()
                l.name      = loc['name']
                l.latitude  = loc['latitude']
                l.longitude = loc['longitude']
                l.altitude  = loc['alt']
                self.locations.append(l)
        else:
            self.locations.append(Location())

    def save(self):
        data = {'locations': []}
        for loc in self.locations:
            l = {}
            l['name']         = loc.name
            l['latitude']     = loc.latitude
            l['longitude']    = loc.longitude
            l['alt']          = loc.altitude
            data['locations'].append(l)
        self.save_list('locations.json', data)

    def read_list(self, filename):
        try:
            f_in = open(filename, 'r')
            data = json.loads(f_in.read())
            return data['locations']
        except:
            #TODO: Handle exception
            pass

    def save_list(self, filename, data):
        try:
            f_out = open(filename, 'w')
            f_out.write(json.dumps(data, sort_keys=True, indent=2))
        except:
            #TODO: Handle exception
            pass


#========================================================================
# Class for as single Location
#========================================================================
class Location():
    def __init__(self):
        self.name       = ""
        self.latitude   = 0.0
        self.longitude  = 0.0
        self.altitude   = 0
        self.passes     = []

    def scale_lat_lon(self, mapsize):
        lon_a = mapsize[0] / 360.0
        lon_b = lon_a * 180.0
        
        lat_a = -mapsize[1] / 180.0
        lat_b = lat_a * -90.0

        lat_scale = lat_a*self.latitude  + lat_b
        lon_scale = lon_a*self.longitude + lon_b
        return (lon_scale, lat_scale)


#========================================================================
# Class for a single ISS Pass for a location
#========================================================================
class Pass():
    def __init__(self):
        self.dt = {}
        self.duration = 0.0

    def AOS(self):
        diff = datetime.datetime.utcnow() - self.dt
        diff = diff.total_seconds()

        hours = int(diff / 3600.0)
        minutes = int((diff - (hours*3600)) / 60.0)
        seconds = diff - ((hours*3600) + (minutes*60))

        return "%d:%02d:%02d" % (fabs(hours), fabs(minutes), fabs(seconds))
