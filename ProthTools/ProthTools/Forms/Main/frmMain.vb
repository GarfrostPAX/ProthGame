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

        ' First of, let's force our window to be of maximum size.
        ' It's not required of course, but I personally prefer fullscreen editors.
        Me.WindowState = Windows.Forms.FormWindowState.Maximized

        ' Now let's create a rendersurface as big as the client's computer resolution can handle.
        surf_Main = New WindowSurface(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width)

        ' The viewport has been created, now assign it to our form.
        Me.Controls.Add(surf_Main)

        ' Everything is in order, now to make sure we can render to it using view_Main as an object.
        ' i.e. forcing SFML to render to our form.
        view_Main = New RenderWindow(surf_Main.Handle)

        ' Move on to the RenderLoop.
        ' I really don't like having it all in one sub.
        RenderMainView()

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' The main form is closing, make sure we exit out of our threads as well.
        var_IsRunning = False
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click

    End Sub
End Class