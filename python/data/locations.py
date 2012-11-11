import json

class Locations():

    def __init__(self):
        self.locations = []
        self.build_list()

    def build_list(self):
        # Built in location list
        data = self.read_list('data/locations.json')
        if data:
            for loc in data:
                l = Location()
                l.name      = loc['name']
                l.latitude  = loc['latitude']
                l.longitude = loc['longitude']
                l.altitude  = loc['alt']
                self.locations.append(l)

    def read_list(self, filename):
        try:
            f_in = open(filename, 'r')
            data = json.loads(f_in.read())
            return data['locations']
        except:
            pass

class Location():
  def __init__(self):
    self.name       = ""
    self.latitude   = 0.0
    self.longitude  = 0.0
    self.altitude   = 0
