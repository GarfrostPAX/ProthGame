Module modStructures

    <Serializable()> Public Structure CharacterRec
        ' Basic Information
        Dim Name As String
        Dim Job As Integer
        Dim Level As Integer
        Dim Experience As Integer

        ' Location Data
        Dim Map As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Direction As Byte
    End Structure

    <Serializable()> Public Structure PlayerRec

        ' Character Data
        Dim Character() As CharacterRec

    End Structure

    Public Structure TempPlayerRec
        ' Generic Data.
        Dim Username As String
        Dim Password As String
        Dim DBPassword As String
        Dim Salt As String

        ' These two variables determine which GUID the player has on the socket system and inside the SQL Database.
        Dim ServerGUID As Guid
        Dim DataGUID As Integer

        ' Temporary Data
        Dim InGame As Boolean
        Dim LoginStatus As Byte
        Dim CurChar As Byte
    End Structure

    Public Structure OptionsRec
        ' Server Bind Information
        Dim ServerBindAddress As String
        Dim ServerBindPort As Integer

        ' MySQL Server Information
        Dim MySQLServer As String
        Dim MySQLPort As Integer
        Dim MySQLUsername As String
        Dim MySQLPassword As String
        Dim MySQLDatabase As String

        ' Generic Options
        Dim CapCPS As Byte
    End Structure

    <Serializable()> Public Structure MapRec
        Dim Title As String
        Dim BorderingMap() As Integer

        Dim SizeX As Integer
        Dim SizeY As Integer
        Dim AttributesX As Integer
        Dim AttributesY As Integer
        Dim LayerCount As Byte

        Dim Layers() As LayerRec
        Dim Attributes(,) As AttributeRec

    End Structure

    <Serializable()> Public Structure LayerRec
        Dim LayerName As String
        Dim UnderPlayer As Boolean

        Dim Tiles(,) As TileRec
    End Structure

    <Serializable()> Public Structure TileRec
        Dim TileSetID As Integer
        Dim TileSetX As Integer
        Dim TileSetY As Integer
    End Structure

    <Serializable()> Public Structure AttributeRec
        Dim AttributeID As Byte
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
    End Structure

End Module
