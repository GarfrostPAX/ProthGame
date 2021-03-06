﻿Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Module modMain

    Public Sub Main(ByVal Args() As String)

        ' Set some basic settings that reduce flickering and such on rendered surfaces.
        ' Should also stop Windows Aero from spazzing out and switching to a basic graphics layout.
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        ' Initialize Global Variables.
        InitGlobals()

        ' Initialize all the Graphics we'll be using.
        InitGraphics()

        ' Time to fire up our forms.
        ' We'll need to initialize them all seperately due to the way the project is structured.
        ' Not a huge problem, just means we can have a bit more control over what each form does.
        frm_Loading = New frmLoading
        frm_Loading.Show()

        frm_Main = New frmMain
        frm_Main.Start()

        frm_Layers = New frmLayers

        ' Everything should now be in order now.
        ' Of course we still want to be able to SEE our forms.. So let's unide them.
        ' And hide the loading screen!
        frm_Loading.Hide()
        frm_Main.Show()

        ' Populate our lists.
        PopulateLayerList()
        PopulateTileSetList()

        ' We've got a lovely blank map up. Should probably center the view on it.
        CenterCameraOnMap()

        ' Now for a very cheap fix.. For some reason you get blank lines when you first enter the application.
        ' This sorts that out. It's weird, but it works. I believe it's related to the way Views are handled
        ' within SFML, will report this to their project.
        MapEditorZoom(True)
        MapEditorZoom(False)

        ' Time to start the main application loop!
        EditorLoop()

    End Sub

End Module
