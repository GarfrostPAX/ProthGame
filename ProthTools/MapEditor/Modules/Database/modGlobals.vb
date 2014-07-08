﻿Imports SFML.Graphics
Imports System.Windows.Forms

Module modGlobals

    ' Loading Screen Constants.
    Public Const CON_APPTITLE As String = "Prothesys Map Editor"
    Public Const CON_APPVERSION As String = "InDev 0.0.1"
    Public Const CON_COPYRIGHT As String = "© Sil van Harberden, 2014"

    ' Data Directory Constants
    Public Const DIR_DATA As String = "\data"
    Public Const DIR_TILESETS As String = "\tilesets\"
    Public Const DIR_GENERIC As String = "\generic\"
    Public Const GFX_EXT As String = ".png"

    ' Map Constants.
    Public Const MAP_DEFAULT_X As Byte = 24
    Public Const MAP_DEFAULT_Y As Byte = 19
    Public Const MAP_DEFAULT_LAYERS As Byte = 5
    Public Const TILE_X As Byte = 32
    Public Const TILE_Y As Byte = 32

    ' Data Directory Globals
    Public var_AppPath As String

    ' This little Boolean will determine whether our Threads need to keep looping or not.
    ' Simply set it to False when the program needs to end.
    Public var_IsRunning As Boolean = True

    ' Thread Globals.
    ' Just so we can kill them off forcibly when need be.
    Public thread_Main As System.Threading.Thread

    ' RenderSurface globals.
    ' These are used by our main editor screen and tileset selection to display stuff.
    Public Const OFFSETY As Integer = 49
    Public surf_Main As WindowSurface
    Public surf_TileSelect As WindowSurface
    Public render_Main As RenderWindow
    Public render_TileSelect As RenderWindow
    Public view_Main As SFML.Graphics.View

    ' Graphics Globals
    ' We'll be storing our images in these globals.
    Public tex_TileSet() As SFML.Graphics.Texture
    Public var_NumTileSets As Integer
    Public tex_BackDrop As SFML.Graphics.Texture

    ' Form Globals.
    ' So we can actually address these forms where nessecary.
    Public frm_Main As frmMain
    Public frm_Loading As frmLoading

    ' Mouse location Global.
    Public var_MousePos As SFML.Window.Vector2f

    ' Map Global.
    Public Map As MapRec


    Public Sub InitGlobals()
 
        ' Set up our Default Map Settings.
        ' Since we have a lovely sub set up for this we might as well use it.
        NewMap(MAP_DEFAULT_LAYERS, MAP_DEFAULT_X, MAP_DEFAULT_Y)

        ' Set the application path.
        var_AppPath = Application.StartupPath()

    End Sub

End Module