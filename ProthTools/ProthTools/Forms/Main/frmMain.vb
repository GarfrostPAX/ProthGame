Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Imports SFML.Window
Imports SFML.Graphics

Public Class frmMain

    Public Sub Start()

        ' Now let's create a rendersurface as big as their resolution will allow.
        ' This way we can scale up the window without much if any trouble.
        ' I -COULD- destroy and recreate this every time the window resizes, and reload the entire thing.
        ' But really, why bother? It's a toolkit, the end-user is never going to see this.
        surf_Main = New WindowSurface(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width)

        ' The viewport has been created, now assign it to our form.
        Me.Controls.Add(surf_Main)

        ' Move the view down by an offset so the first section isn't blocked by other objects.
        surf_Main.Location = New Point(0, OFFSETY)

        ' Everything is in order, now to make sure we can render to it using view_Main as an object.
        ' i.e. forcing SFML to render to our form.
        view_Main = New RenderWindow(surf_Main.Handle)

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' The main form is closing, make sure we exit out of our threads as well.
        var_IsRunning = False
    End Sub

End Class