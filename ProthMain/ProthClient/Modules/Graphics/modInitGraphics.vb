Imports SFML.Window
Imports SFML.Graphics

Module modInitGraphics

    Public Sub InitGraphics()
        ' First initialize the window!
        InitWindow()


        ' Finaly, let's get to rendering the regular view of the game.
        RenderGame()
    End Sub
  
    Private Sub InitWindow()

        ' First up, let's get this window set up so we can use it with the resolution provided in the config files.
        If obj_Options.Fullscreen <> 0 Then
            ' Hit it in Fullscreen!
            obj_GameWindow = New RenderWindow(New VideoMode(obj_Options.ResolutionX, obj_Options.ResolutionY), "Prothesys Client", Styles.Fullscreen)
        Else
            ' Boring! Windowed mode!
            obj_GameWindow = New RenderWindow(New VideoMode(obj_Options.ResolutionX, obj_Options.ResolutionY), "Prothesys Client")
        End If

        ' VSync?
        If obj_Options.VSync <> 0 Then
            obj_GameWindow.SetVerticalSyncEnabled(True)
        End If

        ' Add window handlers
        AddHandler obj_GameWindow.Closed, AddressOf DestroyGame

        ' Set up the main game view.
        Dim temprec As New SFML.Graphics.FloatRect(0, 0, obj_Options.ResolutionX, obj_Options.ResolutionY)
        obj_GameCamera = New View(temprec)

        ' Assign the view to the window.
        obj_GameWindow.SetView(obj_GameCamera)

    End Sub

   

End Module
