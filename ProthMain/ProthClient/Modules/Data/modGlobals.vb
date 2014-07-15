Module modGlobals

    ' Constants
    ' These are values that will never really change on run-time, and most of them will need to be the same server-side as well.
    Public Const SEP_SYMBOL As String = "&^sep^&"
    Public Const VERSION As String = "InDev 0.0.1"
    Public Const CRYPTO_KEY As String = "6c01b89ce9efeab93f983e6d57725703"

    Public Const MAX_PLAYERS As Integer = 500
    Public Const MAX_CHARACTERS As Byte = 3

    Public Const DATA_ROOT As String = "\data"
    Public Const DATA_GUI As String = "\gui\"
    Public Const DATA_FACES As String = "\faces\"

    ' Turn all the structures into something useful.
    Public obj_Options As OptionsRec
    Public obj_Player(MAX_PLAYERS) As PlayerRec

    ' Render Globals
    Public obj_GameWindow As SFML.Graphics.RenderWindow
    Public obj_GameCamera As SFML.Graphics.View

    ' Regular global values.
    Public var_LoggingIn As Byte = 0
    Public var_AppPath As String

    Public var_TempName(MAX_CHARACTERS) As String
    Public var_TempJob(MAX_CHARACTERS) As Byte
    Public var_TempLevel(MAX_CHARACTERS) As Byte

    Public Const GFX_EXT As String = ".png"

    ' Very important! This will need to be used every time the client passes on data so the server knows who it belongs to.
    ' It will be assigned by the server once connected.
    Public var_MySlot As Integer

    Public Sub InitGlobals()
        ' Before we can use these Structures we'll need to initialize them.
        obj_Options = New OptionsRec

        ' Loop through the player slots to set them all up.
        For i = 1 To MAX_PLAYERS
            ' Set up the object as a new one.
            obj_Player(i) = New PlayerRec

            ' Clean out the data in memory to make sure it won't cause issues.
            ClearPlayer(i)
        Next

        ' Set the application path.
        var_AppPath = My.Application.Info.DirectoryPath

    End Sub

    Public Sub DestroyGlobals()
        ' Set all structures to nothing.
        obj_Options = Nothing

    End Sub

End Module
