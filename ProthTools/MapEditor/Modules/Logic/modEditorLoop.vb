Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Module modEditorLoop

    Public Sub EditorLoop()
        ' This sub is the main loop that runs through the editor's background.
        ' It will render everything and constantly check for input.
        ' Sadly, the way I'm using SFML won't let me render from a seperate thread.
        ' So this application doesn't use threading the way I'd like it to.

        Do While var_IsRunning

            ' First up we'll need to make sure the user can actually see what is going on.
            ' So let's render our displays!

            ' The Main Window.
            ' Render the changes to the view if anything has changed.
            If var_MainChanged Then
                ' Render!
                RenderMainView()

                ' Set the changed value back to 0.
                var_MainChanged = False
            End If

            ' The Tile Selection Window
            ' Only render changes if anything has actually changed.
            If var_TileSetChanged Then
                ' Render!
                RenderTileSelect()

                ' Set the changed value back to 0.
                var_TileSetChanged = False
            End If


            ' Update our label at the bottom of the window.
            UpdateStatusLabel()

            ' The following must be at the bottom of the loop.
            ' We'll need to make sure the program can still process information from the UI.
            ' So let's get those events out of the way.
            Application.DoEvents()

            ' And make sure we don't overload the processor by putting the application to sleep for 15 miliseconds.
            ' We don't need this program to use a crapload of power after all.
            System.Threading.Thread.Sleep(15)
        Loop

    End Sub

End Module
