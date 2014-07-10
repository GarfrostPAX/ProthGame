Module modStructures

    <Serializable()> Public Structure MapRec
        Dim Title As String
        Dim BorderingMap() As Integer

        Dim SizeX As Byte
        Dim SizeY As Byte
        Dim LayerCount As Byte

        Dim Layers() As LayerRec

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

End Module
