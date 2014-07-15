Imports SFML.Graphics
Imports SFML.Window
Imports TGUI

Module modLoginGraphics

    Private gui_Login As New Gui(obj_GameWindow)

    Private lbl_Username As Label
    Private lbl_Password As Label
    Private btn_Login As Button
    Private btn_Close As Button

    ' The following two are public, we need them elsewhere
    Public win_Login As ChildWindow
    Public txt_Username As EditBox
    Public txt_Password As EditBox
    Public lbl_LoginStatus As Label

    Public Sub InitLogin()

        ' Create and position our main Login Window.
        win_Login = gui_Login.Add(New ChildWindow(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        win_Login.Size = New Vector2f(300, 230)
        win_Login.GlobalFont = New Font("C:\Windows\Fonts\Arial.ttf")
        win_Login.TitleBarHeight = 20
        win_Login.Position = New Vector2f((obj_Options.ResolutionX / 2) - (win_Login.Size.X / 2), (obj_Options.ResolutionY / 2) - (win_Login.Size.Y / 2))

        ' Create our labels and position them.
        lbl_Username = win_Login.Add(New Label)
        lbl_Username.TextSize = 14
        lbl_Username.Text = "Username:"
        lbl_Username.Position = New Vector2f(20, 20)

        lbl_Password = win_Login.Add(New Label)
        lbl_Password.TextSize = 14
        lbl_Password.Text = "Password:"
        lbl_Password.Position = New Vector2f(20, 70)

        lbl_LoginStatus = win_Login.Add(New Label)
        lbl_LoginStatus.TextSize = 14
        lbl_LoginStatus.AutoSize = True
        lbl_LoginStatus.Position = New Vector2f(20, 120)

        ' Create our textboxes and position them.
        txt_Username = win_Login.Add(New EditBox(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        txt_Username.Size = New Vector2f(260, 20)
        txt_Username.Position = New Vector2f(20, 40)

        txt_Password = win_Login.Add(New EditBox(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        txt_Password.Size = New Vector2f(260, 20)
        txt_Password.Position = New Vector2f(20, 90)
        txt_Password.PasswordCharacter = "*"

        ' And our buttons!
        btn_Login = win_Login.Add(New Button(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        btn_Login.Size = New Vector2f(100, 30)
        btn_Login.Text = "Login"
        btn_Login.Position = New Vector2f(180, 180)

        btn_Close = win_Login.Add(New Button(var_AppPath + DATA_ROOT + DATA_GUI + "black.conf"))
        btn_Close.Size = New Vector2f(100, 30)
        btn_Close.Text = "Close"
        btn_Close.Position = New Vector2f(20, 180)

        ' Add the handlers for the logic of this menu.
        AddHandler btn_Login.LeftMouseClickedCallback, AddressOf HandleLoginButton
        AddHandler btn_Close.LeftMouseClickedCallback, AddressOf HandleLoginCloseButton
        AddHandler win_Login.ClosedCallback, AddressOf HandleLoginCloseButton

    End Sub

    Public Sub RenderLogin()

        gui_login.Draw()

    End Sub

    Public Sub DestroyLogin()
        ' Destroy all our objects.
        txt_Password = Nothing
        txt_Username = Nothing
        lbl_LoginStatus = Nothing
        lbl_Password = Nothing
        lbl_Username = Nothing
        btn_Close = Nothing
        btn_Login = Nothing
        win_Login = Nothing
        gui_login = Nothing
    End Sub

End Module
