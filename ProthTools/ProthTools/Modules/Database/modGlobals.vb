Imports SFML.Graphics


Module modGlobals

    ' Loading Screen Constants.
    Public Const CON_APPTITLE As String = "Prothesys Map Editor"
    Public Const CON_APPVERSION As String = "InDev 0.0.1"
    Public Const CON_COPYRIGHT As String = "© Sil van Harberden, 2014"

    ' This little Boolean will determine whether our Threads need to keep looping or not.
    ' Simply set it to False when the program needs to end.
    Public var_IsRunning As Boolean = True

    ' Thread Globals.
    ' Just so we can kill them off forcibly when need be.
    Public thread_Main As System.Threading.Thread

    ' RenderSurface globals.
    ' These are used by our main editor screen and tileset selection to display stuff.
    Public surf_Main As WindowSurface
    Public surf_TileSelect As WindowSurface
    Public view_Main As RenderWindow
    Public view_TileSelect As RenderWindow
    Public var_MainReady As Boolean = False

    ' Form Globals.
    ' So we can actually address these forms where nessecary.
    Public frm_Main As frmMain
    Public frm_Loading As frmLoading

End Module
