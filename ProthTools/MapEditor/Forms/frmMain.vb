Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports SFML.Window
Imports SFML.Graphics

Public Class frmMain

    Private Const WM_NCLBUTTONDBLCLK As Integer = &HA3

    Private CameraMovedX As Integer
    Private CameraMovedY As Integer

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

        ' Calculate some offsets to use for our render window position.
        OFFSETX = grp_TileSelect.Width
        OFFSETY = MenuStrip1.Height + ToolStrip1.Height

        ' Create the two main rendersurfaces we'll be using.
        ' One for the main map window, and one for the tile selection tool.
        surf_Main = New WindowSurface(Me.ClientSize.Height - (OFFSETY + strip_Status.Height), Me.ClientSize.Width - (OFFSETX + pan_Misc.Width))
        surf_TileSelect = New WindowSurface(Me.splt_TileSelect.Panel2.Height - scrl_HTile.Height, Me.splt_TileSelect.Panel2.Width - scrl_VTile.Width)

        ' The viewports have been created, now assign them to our form.
        Me.Controls.Add(surf_Main)
        Me.splt_TileSelect.Panel2.Controls.Add(surf_TileSelect)

        ' Move the main view down by an offset so the first section isn't blocked by other objects.
        surf_Main.Location = New Point(OFFSETX, OFFSETY)

        ' Add handlers for mouse events related to our custom controls.
        AddHandler surf_Main.MouseMove, AddressOf surf_Main_MouseMove
        AddHandler surf_Main.MouseDown, AddressOf surf_Main_MouseMove
        AddHandler surf_TileSelect.MouseMove, AddressOf surf_TileSelectMouseMove
        AddHandler surf_TileSelect.MouseDown, AddressOf surf_TileSelectMouseDown

        ' Everything is in order, now to make sure we can render to our controls.
        ' i.e. forcing SFML to render to our form.
        render_Main = New RenderWindow(surf_Main.Handle)
        render_TileSelect = New RenderWindow(surf_TileSelect.Handle)

        ' Set some framerate limits. No point in ever rendering it more than whatever the end user's refresh rate is.
        render_Main.SetVerticalSyncEnabled(True)
        render_TileSelect.SetVerticalSyncEnabled(True)

        ' Now for some funny magic.
        ' We're creating a viewcamera in SFML that will allow us to easily move the viewport around the
        ' world, and zoom in/out as we please without much of a hassle.

        ' First we'll need to set up a rect of our main and tileset viewport though.
        ' It basically tells our camera how many pixels it has to show us by default.
        Dim temprec As New SFML.Graphics.FloatRect(0, 0, Me.ClientSize.Width - (OFFSETX + pan_Misc.Width), Me.ClientSize.Height - (OFFSETY + strip_Status.Height))
        Dim temprectile As New SFML.Graphics.FloatRect(0, 0, Me.splt_TileSelect.Panel2.Width - scrl_VTile.Width, Me.splt_TileSelect.Panel2.Height - scrl_HTile.Height)

        ' Now to create said views.
        view_Main = New SFML.Graphics.View(temprec)
        view_TileSelect = New SFML.Graphics.View(temprectile)

        ' And tell our renderwindows to use these views.
        ' Note that to get any future changes to apply to the camera we need to use the applicable command
        ' below AGAIN. 
        render_Main.SetView(view_Main)
        render_TileSelect.SetView(view_TileSelect)

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' The main form is closing, make sure we exit out of our threads as well.
        var_IsRunning = False
    End Sub

    Private Sub surf_Main_MouseMove(sender As Object, e As MouseEventArgs)
        ' Pass on the mouse events elsewhere.
        HandleMainMouse(e.Button, e.X, e.Y)

        ' Something likely changed on the main view! A position of the mouse cursor, probably.
        var_MainChanged = True

        ' Return focus to the form
        FocusMain()
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        ' Pass on the keyboard events elsewhere.
        HandleKeyBoard(e.Alt, e.Control, e.Shift, e.KeyCode)
    End Sub

    Private Sub cmb_Layers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_Layers.SelectedIndexChanged
        ' Set out current layer.
        ' Because these indices start at 0 we need to add one.
        var_CurrentLayer = cmb_Layers.SelectedIndex + 1

        ' Status Change!
        StatusMessage("Changed to Layer: " + Map.Layers(var_CurrentLayer).LayerName)

        ' Let the renderer know something changed.
        var_MainChanged = True

        ' Set the focus back to the form.
        FocusMain()

    End Sub

    Private Sub scrl_HTile_Scroll(sender As Object, e As ScrollEventArgs) Handles scrl_HTile.Scroll
        Dim TempVal As Integer

        If e.NewValue > e.OldValue Then
            TempVal = e.OldValue - e.NewValue
            CameraMovedX = CameraMovedX + (TempVal * TILE_X)
            view_TileSelect.Move(New SFML.Window.Vector2f(-(TempVal * TILE_X), 0))
        ElseIf e.OldValue > e.NewValue Then
            TempVal = e.NewValue - e.OldValue
            CameraMovedX = CameraMovedX - (TempVal * TILE_X)
            view_TileSelect.Move(New SFML.Window.Vector2f(TempVal * TILE_X, 0))
        End If

        render_TileSelect.SetView(view_TileSelect)

    End Sub

    Private Sub cmb_TileSets_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_TileSets.SelectedIndexChanged
        var_CurrentTileSet = cmb_TileSets.SelectedIndex + 1

        ' Reset the camera view.
        scrl_HTile.Value = 0
        scrl_VTile.Value = 0
        view_TileSelect.Move(New SFML.Window.Vector2f(CameraMovedX, CameraMovedY))
        render_TileSelect.SetView(view_TileSelect)
        CameraMovedX = 0
        CameraMovedY = 0

        ' Check if we need to disable some scrollbars.
        If tex_TileSet(var_CurrentTileSet).Size.X > render_TileSelect.Size.X Then
            ' We may want to let the scrollbar do something.
            scrl_HTile.Enabled = True
            scrl_HTile.Maximum = (tex_TileSet(var_CurrentTileSet).Size.X \ TILE_X) - (render_TileSelect.Size.X \ TILE_X)
        Else
            ' No need for the horizontal scrollbar, the display is big enough as it is.
            scrl_HTile.Enabled = False
        End If
        If tex_TileSet(var_CurrentTileSet).Size.Y > render_TileSelect.Size.Y Then
            ' We may want to let the scrollbar do something.
            scrl_VTile.Enabled = True
            scrl_VTile.Maximum = (tex_TileSet(var_CurrentTileSet).Size.Y \ TILE_Y) - (render_TileSelect.Size.Y \ TILE_Y)
        Else
            ' No need for the horizontal scrollbar, the display is big enough as it is.
            scrl_VTile.Enabled = False
        End If

        ' Make sure the tileset renderer knows something changed.
        var_TileSetChanged = True

        ' Set the status.
        StatusMessage("Switched to Tileset #" + var_CurrentTileSet.ToString)

        ' Set the focus back to the form.
        FocusMain()
    End Sub

    Private Sub scrl_VTile_Scroll(sender As Object, e As ScrollEventArgs) Handles scrl_VTile.Scroll
        Dim TempVal As Integer

        If e.NewValue > e.OldValue Then
            TempVal = e.OldValue - e.NewValue
            CameraMovedY = CameraMovedY + (TempVal * TILE_Y)
            view_TileSelect.Move(New SFML.Window.Vector2f(0, -(TempVal * TILE_Y)))
        ElseIf e.OldValue > e.NewValue Then
            TempVal = e.NewValue - e.OldValue
            CameraMovedY = CameraMovedY - (TempVal * TILE_Y)
            view_TileSelect.Move(New SFML.Window.Vector2f(0, TempVal * TILE_Y))
        End If

        render_TileSelect.SetView(view_TileSelect)
    End Sub

    Private Sub surf_TileSelectMouseMove(sender As Object, e As MouseEventArgs)
        ' Send off the handler elsewhere.
        HandleTileSelectMouseMove(e.Button, e.X, e.Y)

        ' Something likely changed on the tileset view! A position of the mouse cursor, probably.
        var_TileSetChanged = True

        ' Return focus to the form
        FocusMain()
    End Sub

    Private Sub surf_TileSelectMouseDown(sender As Object, e As MouseEventArgs)
        ' Send off the handler elsewhere.
        HandleTileSelectMouse(e.Button, e.X, e.Y)

        ' Something likely changed on the tileset view! A position of the mouse cursor, probably.
        var_TileSetChanged = True

        ' Return focus to the form
        FocusMain()
    End Sub

    Private Sub btn_SaveMap_Click(sender As Object, e As EventArgs) Handles btn_SaveMap.Click
        HandleSaveMap()
    End Sub

    Private Sub btn_OpenMap_Click(sender As Object, e As EventArgs) Handles btn_OpenMap.Click
        HandleLoadMap()
    End Sub

    Private Sub btn_NewMap_Click(sender As Object, e As EventArgs) Handles btn_NewMap.Click
        HandleNewMap()
    End Sub

    Private Sub NewMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewMapToolStripMenuItem.Click
        HandleNewMap()
    End Sub

    Private Sub OpenMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMapToolStripMenuItem.Click
        HandleLoadMap()
    End Sub

    Private Sub SaveMapToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMapToolStripMenuItem.Click
        HandleSaveMap()
    End Sub

    Private Sub SaveMapAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMapAsToolStripMenuItem.Click
        HandleSaveMap(True)
    End Sub

    Private Sub btn_SaveAs_Click(sender As Object, e As EventArgs) Handles btn_SaveAs.Click
        HandleSaveMap(True)
    End Sub

    Private Sub chk_HighLayers_Click(sender As Object, e As EventArgs) Handles chk_HighLayers.Click
        ' Just so the layers actually appear or disappear right away.
        var_MainChanged = True
    End Sub

    Private Sub chkLowLayers_Click(sender As Object, e As EventArgs) Handles chkLowLayers.Click
        ' Just so the layers actually appear or disappear right away.
        var_MainChanged = True
    End Sub

    Private Sub chk_FadeLayers_Click(sender As Object, e As EventArgs) Handles chk_FadeLayers.Click
        ' Just so the layers actually appear or disappear right away.
        var_MainChanged = True
    End Sub

    Private Sub btn_ManageLayers_Click(sender As Object, e As EventArgs) Handles btn_ManageLayers.Click
        var_LayersOpen = True
        frm_Layers.Visible = True
        frm_Main.Enabled = False
    End Sub

    Private Sub btn_FillLayer_Click(sender As Object, e As EventArgs) Handles btn_FillLayer.Click
        FillLayer(False)
    End Sub

    Private Sub btn_ClearLayer_Click(sender As Object, e As EventArgs) Handles btn_ClearLayer.Click
        FillLayer(True)
    End Sub
End Class