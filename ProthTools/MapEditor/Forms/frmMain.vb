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

    Public Const WM_NCLBUTTONDBLCLK As Integer = &HA3

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_NCLBUTTONDBLCLK Then Return
        MyBase.WndProc(m)
    End Sub

    Public Sub Start()

        ' Force the window to be visible.
        Me.Show()

        ' Maximize it.
        ' We're going to force it to stay like this in the form properties.
        ' Why? Because I'm lazy. The client will eventually need more polished code for this.
        Me.WindowState = FormWindowState.Maximized

        ' Now let's create a rendersurface as big as their resolution will allow.
        ' This way we can scale up the window without much if any trouble.
        ' I -COULD- destroy and recreate this every time the window resizes, and reload the entire thing.
        ' But really, why bother? It's a toolkit, the end-user is never going to see this.
        ' Anyway, the size is calculated by the offset (which is basically the top two bars added onto eachother) and the status strip
        ' being substracted from the inner screen size.
        surf_Main = New WindowSurface(Me.ClientSize.Height - (OFFSETY + strip_Status.Height), Me.ClientSize.Width)

        ' The viewport has been created, now assign it to our form.
        Me.Controls.Add(surf_Main)

        ' Move the view down by an offset so the first section isn't blocked by other objects.
        surf_Main.Location = New Point(0, OFFSETY)

        AddHandler surf_Main.MouseMove, AddressOf surf_Main_MouseMove
        AddHandler surf_Main.MouseDown, AddressOf surf_Main_MouseMove

        ' Everything is in order, now to make sure we can render to it using render_Main as an object.
        ' i.e. forcing SFML to render to our form.
        render_Main = New RenderWindow(surf_Main.Handle)

        ' Now for some funny magic.
        ' We're creating a viewcamera in SFML that will allow us to easily move the viewport around the
        ' world, and zoom in/out as we please without much of a hassle.

        ' First we'll need to set up a rect of our main viewport though.
        ' It basically tells our camera how many pixels it has to show us by default.
        Dim temprec As New SFML.Graphics.FloatRect(0, 0, Me.ClientSize.Width, Me.ClientSize.Height - (OFFSETY + strip_Status.Height))

        ' Now to create said view.
        view_Main = New SFML.Graphics.View(temprec)

        ' And tell our renderwindow to use this view.
        ' Note that to get any future changes to apply to the camera we need to use the command
        ' below AGAIN. 
        render_Main.SetView(view_Main)

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' The main form is closing, make sure we exit out of our threads as well.
        var_IsRunning = False
    End Sub

    Private Sub surf_Main_MouseMove(sender As Object, e As MouseEventArgs)
        ' Pass on the mouse events elsewhere.
        HandleMainMouse(e.Button, e.X, e.Y)
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' Pass on the keyboard events elsewhere.
        HandleKeyBoard(e.Alt, e.Control, e.Shift, e.KeyCode)
    End Sub

    Private Sub frmMain_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        ' Pass on the mousewheel events elsewhere.
        HandleMouseWheel(e.Delta, e.X, e.Y)
    End Sub

End Class