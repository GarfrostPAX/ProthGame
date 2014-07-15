Imports SFML.Graphics
Imports SFML.Window
Imports TGUI

Module modCharSelectGraphics

    Private gui_CharSelect As New Gui(obj_GameWindow)
    Private lbl_charname() As Label
    Private pic_charface() As Picture
    Private btn_charselect() As Button
    Private btn_logout As Button

    Public win_CharSelect As ChildWindow

    Public Sub InitCharSelect()

        ' Redim our arrays.
        ReDim pic_charface(MAX_CHARACTERS)
        ReDim lbl_charname(MAX_CHARACTERS)
        ReDim btn_charselect(MAX_CHARACTERS)

        ' Create our window we'll be adding all our lovelies to.
        win_CharSelect = gui_CharSelect.Add(New ChildWindow(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        win_CharSelect.Size = New Vector2f(460, 250)
        win_CharSelect.GlobalFont = New Font("C:\Windows\Fonts\Arial.ttf")
        win_CharSelect.TitleBarHeight = 20
        win_CharSelect.Position = New Vector2f((obj_Options.ResolutionX / 2) - (win_CharSelect.Size.X / 2), (obj_Options.ResolutionY / 2) - (win_CharSelect.Size.Y / 2))

        ' Create our Labels.
        lbl_charname(1) = win_CharSelect.Add(New Label)
        lbl_charname(1).AutoSize = True
        lbl_charname(1).TextSize = 14
        lbl_charname(1).Text = "Char 1"
        lbl_charname(1).Position = New Vector2f(40, 10)

        lbl_charname(2) = win_CharSelect.Add(New Label)
        lbl_charname(2).AutoSize = True
        lbl_charname(2).TextSize = 14
        lbl_charname(2).Text = "Char 2"
        lbl_charname(2).Position = New Vector2f(180, 10)

        lbl_charname(3) = win_CharSelect.Add(New Label)
        lbl_charname(3).AutoSize = True
        lbl_charname(3).TextSize = 14
        lbl_charname(3).Text = "Char 2"
        lbl_charname(3).Position = New Vector2f(320, 10)

        ' Create our pictureboxes.
        pic_charface(1) = win_CharSelect.Add(New Picture(var_AppPath + DATA_ROOT + DATA_FACES + "default" + GFX_EXT))
        pic_charface(1).Size = New Vector2f(100, 100)
        pic_charface(1).Position = New Vector2f(40, 30)

        pic_charface(2) = win_CharSelect.Add(New Picture(var_AppPath + DATA_ROOT + DATA_FACES + "default" + GFX_EXT))
        pic_charface(2).Position = New Vector2f(180, 30)

        pic_charface(3) = win_CharSelect.Add(New Picture(var_AppPath + DATA_ROOT + DATA_FACES + "default" + GFX_EXT))
        pic_charface(3).Position = New Vector2f(320, 30)

        ' Create our buttons.
        btn_charselect(1) = win_CharSelect.Add(New Button(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        btn_charselect(1).Size = New Vector2f(100, 30)
        btn_charselect(1).Text = "Create"
        btn_charselect(1).Position = New Vector2f(40, 150)

        btn_charselect(2) = win_CharSelect.Add(New Button(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        btn_charselect(2).Size = New Vector2f(100, 30)
        btn_charselect(2).Text = "Create"
        btn_charselect(2).Position = New Vector2f(180, 150)

        btn_charselect(3) = win_CharSelect.Add(New Button(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        btn_charselect(3).Size = New Vector2f(100, 30)
        btn_charselect(3).Text = "Create"
        btn_charselect(3).Position = New Vector2f(320, 150)

        btn_logout = win_CharSelect.Add(New Button(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        btn_logout.Size = New Vector2f(100, 30)
        btn_logout.Text = "Logout"
        btn_logout.Position = New Vector2f(180, 200)

        ' Add Handlers
        AddHandler win_CharSelect.ClosedCallback, AddressOf HandleCharSelectCloseButton
        AddHandler btn_logout.LeftMouseClickedCallback, AddressOf HandleCharSelectCloseButton
        AddHandler btn_charselect(1).LeftMouseClickedCallback, AddressOf HandleCharSelectButton1
        AddHandler btn_charselect(2).LeftMouseClickedCallback, AddressOf HandleCharSelectButton2
        AddHandler btn_charselect(3).LeftMouseClickedCallback, AddressOf HandleCharSelectButton3

    End Sub

    Public Sub UpdateCharSelectGraphics()
        Dim i As Integer, tempval As Integer, temploc As Integer

        ' Cycle through our character slots and handle accordingly.
        For i = 1 To MAX_CHARACTERS
            ' Make sure there's data for this character.
            If var_TempName(i).Length > 0 Then
                ' There's data for this character!
                ' Set our Tag.
                lbl_charname(i).Text = var_TempName(i) + " Lv. " + var_TempLevel(i).ToString

                ' Position it to the center.
                tempval = (100 - lbl_charname(i).Size.X) / 2
                If i = 1 Then temploc = 40
                If i = 2 Then temploc = 180
                If i = 3 Then temploc = 320
                lbl_charname(i).Position = New Vector2f(temploc + tempval, lbl_charname(i).Position.Y)

                ' Change the button text to Play!
                btn_charselect(i).Text = "Play"
            Else
                ' No data for this character.
                ' No need to change the button text.
                ' Set our Tag.
                lbl_charname(i).Text = "Empty"

                ' Position it to the center.
                tempval = (100 - lbl_charname(i).Size.X) / 2
                If i = 1 Then temploc = 40
                If i = 2 Then temploc = 180
                If i = 3 Then temploc = 320
                lbl_charname(i).Position = New Vector2f(temploc + tempval, lbl_charname(i).Position.Y)
            End If
        Next

    End Sub

    Public Sub RenderCharSelect()

        ' Render char select
        gui_CharSelect.Draw()

    End Sub

    Public Sub DestroyCharSelect()

        ' Set all our objects to nothing
        lbl_charname(1) = Nothing
        lbl_charname(2) = Nothing
        lbl_charname(3) = Nothing
        btn_charselect(1) = Nothing
        btn_charselect(2) = Nothing
        btn_charselect(3) = Nothing
        pic_charface(1) = Nothing
        pic_charface(2) = Nothing
        pic_charface(3) = Nothing
        btn_logout = Nothing
        win_CharSelect = Nothing
        gui_CharSelect = Nothing

    End Sub


End Module
