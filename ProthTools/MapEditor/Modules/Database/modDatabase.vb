Module modDatabase
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
        ' See Enum Directions.
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

            ' Make sure Layer 1-4 are under the player.
            If i <= 4 Then
                Map.Layers(i).UnderPlayer = True
            End If
        Next

        ' Give our layers some names.
        Map.Layers(1).LayerName = "Ground"
        Map.Layers(2).LayerName = "Foliage 1"
        Map.Layers(3).LayerName = "Foliage 2"
        Map.Layers(4).LayerName = "Decoration 1"
        Map.Layers(5).LayerName = "Overlay 1"
        Map.Layers(6).LayerName = "Overlay 2"
        Map.Layers(7).LayerName = "Overlay 3"

        ' And name the map itself.
        Map.Title = "New Map"
    End Sub

    Public Sub SaveMap(ByVal FileName As String)
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter

        ' First let's save the basic map info we need to load it up again later.
        System.IO.File.WriteAllText(FileName + MAPINF_EXT, Map.LayerCount.ToString + "," + Map.SizeX.ToString + "," + Map.SizeY.ToString)

        ' Now let's dump our Array to a file!
        ' Open a new filestream.
        Dim fStream As New System.IO.FileStream(FileName + MAPDAT_EXT, System.IO.FileMode.OpenOrCreate)

        ' Dump the Array into the file.
        bf.Serialize(fStream, Map)

        ' Close the filestream.
        fStream.Close()

    End Sub

End Module
