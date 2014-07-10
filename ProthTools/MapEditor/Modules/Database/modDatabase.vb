﻿Module modDatabase
    Public Sub NewMap(ByVal Layers As Byte, ByVal SizeX As Byte, ByVal SizeY As Byte)
        Dim i As Byte, x As Integer, y As Integer

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
        ReDim tex_Layer(Map.LayerCount)
        ReDim var_LayerChanged(Map.LayerCount)
        For i = 1 To Map.LayerCount

            ' Make sure the layer can contain the data we want it to.
            ReDim Map.Layers(i).Tiles(Map.SizeX, Map.SizeY)

            ' Create a texture with the appropriate size for the layer.
            ' Because the texture needs to contain 32 pixels that just a regular calculation wouldn't cut
            ' We're adding an additional tile to this.
            x = Map.SizeX + 1
            y = Map.SizeY + 1
            tex_Layer(i) = New SFML.Graphics.RenderTexture(x * TILE_X, y * TILE_Y)
            tex_Layer(i).Smooth = False

            ' Set LayerChanged to true.
            var_LayerChanged(i) = True

            ' Make sure Layer 1-3 are under the player.
            If i <= 3 Then
                Map.Layers(i).UnderPlayer = True
            End If
        Next

        ' Give our layers some names.
        Map.Layers(1).LayerName = "Ground"
        Map.Layers(2).LayerName = "Mask 1"
        Map.Layers(3).LayerName = "Mask 2"
        Map.Layers(4).LayerName = "Fringe 1"
        Map.Layers(5).LayerName = "Fringe 2"

        ' And name the map itself.
        Map.Title = "New Map"
    End Sub
End Module
