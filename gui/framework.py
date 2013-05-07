# -*- encoding: utf-8 -*-
import wx
import wx.grid as wxgrid
import views
import data.locations


LATITUDE_FORMAT   = "%11.6f"
LONGITUDE_FORMAT  = "%11.6f"
ALTITUDE_FORMAT   = "%0.0f"

class Window(wx.Frame):

  def __init__(self, parent, title, size, onclose=None):
    wx.Frame.__init__(self, parent, title=title
                      , size = size
                      , style = wx.DEFAULT_FRAME_STYLE|wx.NO_FULL_REPAINT_ON_RESIZE)

    self.container  = wx.Panel(self)
    self.vbox       = wx.BoxSizer(wx.VERTICAL)
    self.sections   = []
    if onclose:
        self.close_callback = onclose
        self.Bind(wx.EVT_CLOSE, self.onclose)

  def add_box(self, label):
    widget    = wx.Panel(self.container)
    wrapper   = wx.BoxSizer(wx.VERTICAL)
    
    box       = wx.StaticBox(widget, label=label)
    boxsizer  = wx.StaticBoxSizer(box, wx.VERTICAL)
    sizer     = wx.GridBagSizer(4, 4)

    boxsizer.Add(sizer, flag=wx.LEFT|wx.TOP|wx.EXPAND)

    sizer.AddGrowableCol(2)
    #widget.SetSizerAndFit(sizer)

    wrapper.Add(boxsizer,flag=wx.ALL|wx.EXPAND)
    widget.SetSizer(wrapper)
    self.sections.append(widget)
    return (widget, sizer)

  def add_textbox(self, box, row, label, units):
    labeltext = wx.StaticText(box[0], label=label, style=wx.ALIGN_CENTRE)
    info      = wx.TextCtrl(box[0], size=(200,30))
    #info.Disable()
    units     = wx.StaticText(box[0], label=units, style=wx.ALIGN_CENTRE)
    
    box[1].Add(labeltext, pos=(row, 0), flag=wx.TOP|wx.BOTTOM, border=5)
    box[1].Add(info,      pos=(row, 1))
    box[1].Add(units,     pos=(row, 2), flag=wx.TOP|wx.BOTTOM, border=5)
    
    return info
  
  def add_button(self, box, row, label, callback):
    button    = wx.Button(box[0], label=label)
    button_id = button.GetId()
    box[1].Add(button, pos=(row, 0), flag=wx.TOP|wx.BOTTOM, border=5)
    
    self.Bind(wx.EVT_BUTTON, callback, id=button_id)
    
    return button

  def add_checkbox(self, box, row, label, callback):
    labeltext = wx.StaticText(box[0], label="", style=wx.ALIGN_CENTRE)
    check = wx.CheckBox(box[0], label=label)

    box[1].Add(labeltext, pos=(row, 0), flag=wx.TOP|wx.BOTTOM, border=5)
    box[1].Add(check,     pos=(row,1))

    self.Bind(wx.EVT_CHECKBOX, callback)

    return check

  def add_dropdown(self, box, row, label, callback):
    labeltext = wx.StaticText(box[0], label=label, style=wx.ALIGN_CENTRE)
    combo     = wx.ComboBox(box[0])
    
    box[1].Add(labeltext, pos=(row, 0), flag=wx.TOP|wx.BOTTOM, border=5)
    box[1].Add(combo,     pos=(row, 1), span=(1,2), flag=wx.TOP|wx.BOTTOM|wx.EXPAND, border=5)

    self.Bind(wx.EVT_COMBOBOX, callback)

    return combo
  
  def add_textinfo(self, box, row, label):
    labeltext = wx.StaticText(box[0], label=label, style=wx.ALIGN_CENTRE)
    info      = wx.StaticText(box[0])

    font1 = wx.Font(10, wx.TELETYPE, wx.NORMAL, wx.NORMAL, False)
    info.SetFont(font1)
    

    box[1].Add(labeltext, pos=(row, 0), flag=wx.TOP|wx.BOTTOM, border=5)
    box[1].Add(info,      pos=(row, 1), flag=wx.TOP|wx.BOTTOM, border=5)
    
    return info

  def add_grid(self, box, row, label):
    labeltext = wx.StaticText(box[0], label=label)
    grid = wxgrid.Grid(box[0], size=(500, 230))
    grid.CreateGrid(0, 3)
    grid.EnableScrolling(True, False)
    grid.SetRowLabelSize(0)
    grid.SetColSize(0, 55)
    grid.SetColSize(1, 335)
    grid.SetColSize(2, 105)
    grid.SetColLabelValue(0, "Pass #")
    grid.SetColLabelValue(1, "Date and Time")
    grid.SetColLabelValue(2, "Duration [min]")
    grid.EnableEditing(False)


    box[1].Add(labeltext, pos=(row, 0))
    box[1].Add(grid, pos=(row+1, 1), flag=wx.ALL|wx.EXPAND, border=1)

    return grid

  def add_image(self, box, imageFile):
    img = wx.Image(imageFile, wx.BITMAP_TYPE_ANY)
    img = img.Scale(500,250)
    canvas = wx.StaticBitmap(box[0], -1, img.ConvertToBitmap(), (0,0), (500, 250))

    box[1].Add(canvas, pos=(0,0))

  def add_drawing(self, box, paint_event):
    paint = wx.Panel(box[0], wx.ID_ANY, size=(500,250))
    paint.Bind(wx.EVT_PAINT, paint_event)

    box[1].Add(paint, pos=(0,0), flag=wx.TOP|wx.BOTTOM|wx.EXPAND)

    return paint

  def add_slider(self, box, row, label, callback):
    label = wx.StaticText(box[0], label=label, style=wx.ALIGN_CENTRE)
    slide = wx.Slider(box[0], wx.ID_ANY, 255, 0, 255, wx.DefaultPosition, (250, -1), wx.SL_AUTOTICKS | wx.SL_HORIZONTAL | wx.SL_LABELS)
    slide_id = slide.GetId()

    self.Bind(wx.EVT_SCROLL, callback, id=slide_id)

    box[1].Add(label, pos=(row,0))
    box[1].Add(slide, pos=(row,1))
    return slide

  def add_timer(self, callback, timeout):
    self.timer = wx.Timer(self)
    self.Bind(wx.EVT_TIMER, callback, self.timer)        
    self.timer.Start(timeout)

  def add_widgets(self):
    for section in self.sections:
      self.vbox.Add(section, flag=wx.ALL|wx.EXPAND, border=10)
    
    self.container.SetSizer(self.vbox)
    
    self.Centre()
    self.Show(True)

  def color(self):
    """display the colour dialog and select"""
    dlg = wx.ColourDialog(self)
    # get the full colour dialog
    # default is False and gives the abbreviated version
    dlg.GetColourData().SetChooseFull(True)
    if dlg.ShowModal() == wx.ID_OK:
        data = dlg.GetColourData()
        # gives red, green, blue tuple (r, g, b)
        # each rgb value has a range of 0 to 255
        rgb = data.GetColour().Get()
        #s = 'The selected colour (r, g, b) = %s' % str(rgb)
        #self.label.SetLabel(s)
        # set the panel's color and refresh
        #self.SetBackgroundColour(rgb)
        #self.Refresh()
    dlg.Destroy()
    return rgb

  def onclose(self, arg):
    self.close_callback()
    self.Destroy()


#========================================================================
# WX Painter Class
#========================================================================
class Painter:

    def __init__(self, paint_event):
        self.dc = wx.PaintDC(paint_event.GetEventObject())
        self.dc.BeginDrawing()
        self.dc.Clear()

    def draw_map(self, mapfile):
        imgBmap = wx.Image(mapfile, wx.BITMAP_TYPE_ANY)
        imgBmap = imgBmap.Scale(500,250, wx.IMAGE_QUALITY_HIGH).ConvertToBitmap()
        self.dc.DrawBitmapPoint(imgBmap, (0,0))

    def draw_cross(self, pos, size):
        self.dc.SetPen(wx.Pen(wx.RED, 1))
        # vertical line
        self.dc.DrawLine(pos[0], pos[1]+1, pos[0], pos[1]+size)
        self.dc.DrawLine(pos[0], pos[1]-1, pos[0], pos[1]-size)
        # horizontal line
        self.dc.DrawLine(pos[0]+1, pos[1], pos[0]+size, pos[1])
        self.dc.DrawLine(pos[0]-1, pos[1], pos[0]-size, pos[1])

#========================================================================
# WX Application
#========================================================================
class Application():

    def __init__(self):
        self.app  = wx.App()

    def run(self):
        self.app.SetTopWindow(self.main.window)
        self.app.MainLoop()


#========================================================================
# MVC Model Data
#========================================================================
class ApplicationData():

    def __init__(self):
        self.location          = {}
        self.device_connected  = False
        self.device_message    = ""
        self.all_locations     = []
