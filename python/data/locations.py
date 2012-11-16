# -*- encoding: utf-8 -*-
import json

class Locations():

    def __init__(self):
        self.locations = []
        self.build_list()

    def build_list(self):
        # Built in location list
        data = self.read_list('locations.json')
        if data:
            for loc in data:
                l = Location(len(self.locations))
                l.name      = loc['name']
                l.latitude  = loc['latitude']
                l.longitude = loc['longitude']
                l.altitude  = loc['alt']
                self.locations.append(l)

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


class Location():
  def __init__(self, id):
    self.id         = id
    self.name       = ""
    self.latitude   = 0.0
    self.longitude  = 0.0
    self.altitude   = 0
