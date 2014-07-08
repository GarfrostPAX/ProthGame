Module modDatabase
    Public Sub ClearPlayer(ByVal ID As Integer)
        ' Time to clear out every value in this player array ID so we can re-use it.
        With obj_Player(ID)
            .PlayerObj = Nothing

            .Name = ""
            .Job = 0
            .Level = 0
            .Experience = 0

            .Map = 0
            .X = 0
            .Y = 0
            .Direction = Directions.Down

        End With
    End Sub

    Public Sub LoadOptions()
        ' define and assign the XDocument reader.
        Dim xml = XDocument.Load(var_AppPath + "\config.xml")

        ' Server connection options
        obj_Options.ServerIP = xml.<config>.<server>.<ipaddress>.Value
        obj_Options.ServerPort = CInt(xml.<config>.<server>.<port>.Value)

        ' Graphical Options
        obj_Options.Device = CByte(xml.<config>.<graphics>.<device>.Value)
        obj_Options.ResolutionX = CInt(xml.<config>.<graphics>.<resolutionx>.Value)
        obj_Options.ResolutionY = CInt(xml.<config>.<graphics>.<resolutiony>.Value)
        obj_Options.Fullscreen = CByte(xml.<config>.<graphics>.<fullscreen>.Value)
        obj_Options.VSync = CByte(xml.<config>.<graphics>.<vsync>.Value)



        ' Clear out the object's memory.
        xml = Nothing
    End Sub
End Module
