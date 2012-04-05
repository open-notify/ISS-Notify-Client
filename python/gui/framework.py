import wx
import views

class Window(wx.Frame):

  def __init__(self, parent, title):
    wx.Frame.__init__(self, parent, title=title
                      , size = (512, 300)
                      , style = wx.DEFAULT_FRAME_STYLE|wx.NO_FULL_REPAINT_ON_RESIZE)

    self.container  = wx.Panel(self)
    self.control    = self.container
    self.vbox       = wx.BoxSizer(wx.VERTICAL)
    self.sections    = []

  def add_box(self, label):
    widget    = wx.Panel(self.container)
    wrapper   = wx.BoxSizer(wx.VERTICAL)
    
    box       = wx.StaticBox(widget, label=label)
    boxsizer  = wx.StaticBoxSizer(box, wx.VERTICAL)
    sizer     = wx.GridBagSizer(4, 4)

    boxsizer.Add(sizer, flag=wx.LEFT|wx.TOP|wx.EXPAND)
    
    sizer.AddGrowableCol(1)
    #widget.SetSizerAndFit(sizer)
    
    wrapper.Add(boxsizer,flag=wx.ALL|wx.EXPAND)
    widget.SetSizer(wrapper)
    self.sections.append(widget)
    return (widget, sizer)

  def add_textinfo(self, box, row, label, units):
    a = 45;
    labeltext = wx.StaticText(box[0], label=label, style=wx.ALIGN_CENTRE)
    box[1].Add(labeltext, pos=(row, 0), flag=wx.TOP|wx.LEFT|wx.BOTTOM, border=5)
    box[1].Add(wx.TextCtrl(box[0]), pos=(row, 1), flag=wx.EXPAND|wx.LEFT|wx.RIGHT, border=5)

  def add_widgets(self):
    for section in self.sections:
      self.vbox.Add(section, proportion=1, flag=wx.ALL|wx.EXPAND, border=0)
    
    self.container.SetSizer(self.vbox)
    
    self.Centre()
    self.Show(True)

class Application():
  def run(self):
    app   = wx.App()
    main  = views.MainWindow()
    
    app.SetTopWindow(main.window)
    app.MainLoop()
