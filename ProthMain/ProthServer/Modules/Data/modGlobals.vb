Module modGlobals

    ' Constants
    ' These are values that will never really change on run-time, and most of them will need to be the same client-side as well.
    Public Const SEP_SYMBOL As String = "&^sep^&"
    Public Const VERSION As String = "InDev 0.0.1"
    Public Const CRYPTO_KEY As String = "6c01b89ce9efeab93f983e6d57725703"

    Public Const MAX_PLAYERS As Integer = 500
    Public Const MAX_CHARACTERS As Byte = 3

    Public Const DATA_ROOT As String = "\data"
    Public Const DATA_PLAYERS As String = "\players\"
    Public Const DATA_MAPS As String = "\maps\"

    Public Const MAPINF_EXT As String = ".minf"
    Public Const MAPDAT_EXT As String = ".mdat"

    ' Global Variables
    ' Player HighIndex, used to cap off certain loops from looping through endless amounts of empty player slots.
    Public var_PlayerHighIndex As Integer = 0
    Public MAX_MAPS As Integer = 0

    ' Structure Globals
    Public obj_Player(MAX_PLAYERS) As PlayerRec
    Public obj_TempPlayer(MAX_PLAYERS) As TempPlayerRec
    Public obj_Map() As MapRec
    Public obj_Options As OptionsRec

    ' General Globals
    Public var_AppPath As String

    Public Sub InitGlobals()
        Dim i As Integer

        ' Set up the Options object.
        obj_Options = New OptionsRec

        ' Loop through the player slots to set them all up.
        For i = 1 To MAX_PLAYERS
            ' Set up the object as a new one.
            obj_Player(i) = New PlayerRec
            obj_TempPlayer(i) = New TempPlayerRec

            ' Resize our character arrays.
            ReDim obj_Player(i).Character(MAX_CHARACTERS)

            ' And assign data formats to them.
            obj_Player(i).Character(1) = New CharacterRec
            obj_Player(i).Character(2) = New CharacterRec
            obj_Player(i).Character(3) = New CharacterRec

            ' Clean out the data in memory to make sure it won't cause issues.
            ClearPlayer(i)
        Next

        ' Set the application path.
        var_AppPath = My.Application.Info.DirectoryPath
    End Sub

End Module
