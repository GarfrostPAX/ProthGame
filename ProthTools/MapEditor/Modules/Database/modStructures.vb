Module modStructures

    Public Structure MapRec
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

    Public Structure LayerRec
        Dim LayerName As String
        Dim UnderPlayer As Boolean

        Dim Tiles(,) As TileRec
    End Structure

    Public Structure TileRec
        Dim TileSetID As Integer
        Dim TileSetX As Integer
        Dim TileSetY As Integer
    End Structure

    Public Structure AttributeRec
        Dim AttributeID As Byte
        Dim Data1 As Integer
        Dim Data2 As Integer
        Dim Data3 As Integer
    End Structure

End Module
