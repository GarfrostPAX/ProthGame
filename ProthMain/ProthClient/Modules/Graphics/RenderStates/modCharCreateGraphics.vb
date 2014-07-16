Imports SFML.Graphics
Imports SFML.Window
Imports TGUI

Module modCharCreateGraphics

    Private gui_CharCreate As New Gui(obj_GameWindow)
    Private lbl_CharName As Label
    Private btn_Create As Button

    Public win_CharCreate As ChildWindow
    Public txt_Charname As EditBox

    Public Sub InitCharCreate()

        ' Create our window.
        win_CharCreate = gui_CharCreate.Add(New ChildWindow(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        win_CharCreate.Size = New Vector2f(300, 120)
        win_CharCreate.GlobalFont = New Font("C:\Windows\Fonts\Arial.ttf")
        win_CharCreate.TitleBarHeight = 20
        win_CharCreate.Position = New Vector2f((obj_Options.ResolutionX / 2) - (win_CharCreate.Size.X / 2), (obj_Options.ResolutionY / 2) - (win_CharCreate.Size.Y / 2))

        ' Create our Label.
        lbl_CharName = win_CharCreate.Add(New Label)
        lbl_CharName.Text = "Character Name:"
        lbl_CharName.TextSize = 14
        lbl_CharName.Position = New Vector2f(20, 20)

        ' Create our Textbox.
        txt_Charname = win_CharCreate.Add(New EditBox(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        txt_Charname.Size = New Vector2f(260, 20)
        txt_Charname.Position = New Vector2f(20, 40)

        ' Create our button.
        btn_Create = win_CharCreate.Add(New Button(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        btn_Create.Size = New Vector2f(100, 30)
        btn_Create.Text = "Create"
        btn_Create.Position = New Vector2f(180, 70)

        AddHandler win_CharCreate.ClosedCallback, AddressOf HandleCharCreateCloseButton
        AddHandler btn_Create.LeftMouseClickedCallback, AddressOf HandleCharCreateButton

    End Sub

    Public Sub RenderCharCreate()

        ' Draw our character creation window.
        gui_CharCreate.Draw()

    End Sub

End Module
