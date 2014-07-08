﻿Module modDatabase
    Public Sub NewMap(ByVal Layers As Byte, ByVal SizeX As Byte, ByVal SizeY As Byte)
        Dim i As Byte

        ' First clear out our current data in the Map.
        Map = Nothing

        ' Create a new object to write to.
        Map = New MapRec

        ' Set our basic settings we'll be using to generate the data fields with.
        Map.LayerCount = Layers
        Map.SizeX = SizeX
        Map.SizeY = SizeY

        ' Redim our Bordering Maps Array.
        ' This will be used to determine what map the user is going to walk into when they run into the border.
        ReDim Map.BorderingMap(3)

        ' Create all the layers and the tiles within based on our entered data.
        ReDim Map.Layers(Map.LayerCount)
        For i = 1 To Map.LayerCount
            ' Give our layer a name.
            Map.Layers(i).LayerName = "Layer " + i.ToString

            ' Make sure the layer can contain the data we want it to.
            ReDim Map.Layers(i).Tiles(Map.SizeX, Map.SizeY)

            ' Make sure Layer 1-3 are under the player.
            If i <= 3 Then
                Map.Layers(i).UnderPlayer = True
            End If
        Next

        Map.Layers(1).Tiles(5, 5).TileSetID = 1
        Map.Layers(1).Tiles(5, 5).TileSetX = 32
        Map.Layers(1).Tiles(5, 5).TileSetY = 320

    End Sub
End Module