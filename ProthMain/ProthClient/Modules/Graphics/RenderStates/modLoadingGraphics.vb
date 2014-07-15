Imports SFML.Graphics
Imports SFML.Window
Imports TGUI

Module modLoadingGraphics

    Private gui_loading As New Gui(obj_GameWindow)
    Private lbl_loading As Label

    Public Sub InitLoading()

        ' Initialize our label.
        lbl_loading = gui_loading.Add(New Label)

        ' Set up the loading screen text.
        ' And position the little rascal somewhere in the center.
        lbl_loading.Text = "Loading.."
        lbl_loading.TextColor = Color.White
        lbl_loading.TextFont = New Font("C:\Windows\Fonts\Arial.ttf")
        lbl_loading.TextSize = 20
        lbl_loading.Position = New Vector2f((obj_Options.ResolutionX / 2) - (lbl_loading.Size.X / 2), (obj_Options.ResolutionY / 2) - (lbl_loading.Size.Y / 2))

    End Sub

    Public Sub RenderLoading()

        ' Draw the loading GUI.
        gui_loading.Draw()

    End Sub

    Public Sub DestroyLoading()
        ' Set all our objects to nothing.
        lbl_loading = Nothing
        gui_loading = Nothing
    End Sub

End Module
