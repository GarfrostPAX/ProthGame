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

        ' Only do the following once the form object exists.
        If IsNothing(frm_Main) = False Then

            ' Set the status.
            StatusMessage("New Map Created")

            ' Set the form title.
            frm_Main.Text = "Prothesys Map Editor [New Map]"

        End If

        ' Set our last saved map to nothing
        var_LastSavedMap = ""

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

        ' Set the form title.
        frm_Main.Text = "Prothesys Map Editor [" + FileName + MAPINF_EXT + "]"

        ' Set our last saved map to this one.
        var_LastSavedMap = FileName

        ' Set the status.
        StatusMessage("Saved Map")

    End Sub

    Public Sub LoadMap(ByVal FileName As String)
        Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim tempStr As String, TempDat() As String

        ' First let's read the basic map info we need to load it up again.
        tempstr = System.IO.File.ReadAllText(FileName + MAPINF_EXT)

        ' Split it up.
        TempDat = Split(tempStr, ",")

        ' Instead of being fancy and redimming everything, let's just load in a brand new map.
        ' It's easier. I'm lazy.
        NewMap(CByte(TempDat(0)), CByte(TempDat(1)), CByte(TempDat(2)))

        ' Now let's read our map data!
        ' Open a new filestream.
        Dim fStream As New System.IO.FileStream(FileName + MAPDAT_EXT, System.IO.FileMode.OpenOrCreate)

        ' Dump the Array into the file.
        Map = bf.Deserialize(fStream)

        ' Close the filestream.
        fStream.Close()

        ' Set the form title.
        frm_Main.Text = "Prothesys Map Editor [" + FileName + MAPINF_EXT + "]"

        ' Tell the renderer that something changed.
        var_MainChanged = True

        ' Populate our layer lists with the new values.
        PopulateLayerList()

        ' Set our last saved map to this one.
        var_LastSavedMap = FileName

        ' Set the status.
        StatusMessage("Loaded Map")

    End Sub

    Public Sub DeleteLayer(ByVal Layer As Integer)
        Dim i As Integer

        ' Let's see if the layer is above or below the limit.
        If Layer < Map.LayerCount Then

            ' Move down all the data in the array by one into the one we're deleting.
            ' This makes it much easier, as at the end of it we can just delete the last layer.
            For i = Layer To Map.LayerCount - 1

                ' Move our data!
                Map.Layers(i) = Map.Layers(i + 1)
                tex_Layer(i) = tex_Layer(i + 1)
                var_LayerChanged(i) = var_LayerChanged(i + 1)
            Next
        End If

        ' Now just redim our top layer away and all is good!
        ReDim Preserve Map.Layers(Map.LayerCount - 1)
        ReDim Preserve tex_Layer(Map.LayerCount - 1)
        ReDim Preserve var_LayerChanged(Map.LayerCount - 1)

        ' Remove one layer from the layercount.
        Map.LayerCount = Map.LayerCount - 1

        ' Update our lists.
        PopulateLayerList()

        ' Status Message.
        StatusMessage("Deleted Layer #" + Layer.ToString)

    End Sub

    Public Sub AddLayer(ByVal Name As String, ByVal UnderPlayer As Boolean)
        Dim tempX As Integer, tempY As Integer, tempLayer As Integer, i As Integer

        ' Check to see if the new layer is added to the upper or lower layers.
        If Not UnderPlayer Then
            ' The Upper Layers! this is really easy as all we need to do is expand the arrays.
            ' First add a brand new layer to the counter.
            Map.LayerCount = Map.LayerCount + 1

            ' Now just redim the arrays. :)
            ReDim Preserve Map.Layers(Map.LayerCount)
            ReDim Preserve tex_Layer(Map.LayerCount)
            ReDim Preserve var_LayerChanged(Map.LayerCount)
            ReDim Map.Layers(Map.LayerCount).Tiles(Map.SizeX, Map.SizeY)

            ' Adding one because the rendered view needs to be an additional tile wide.
            tempX = Map.SizeX + 1
            tempY = Map.SizeY + 1
            tex_Layer(Map.LayerCount) = New SFML.Graphics.RenderTexture(tempX * TILE_X, tempY * TILE_Y)


            ' Add data to the new Array entry.
            Map.Layers(Map.LayerCount).LayerName = Name
            Map.Layers(Map.LayerCount).UnderPlayer = UnderPlayer

            ' Force the editor to render a blank texture.
            var_LayerChanged(Map.LayerCount) = True

        Else
            ' Under the player, so we'll need to shove this layer in somewhere halfway into the array.
            ' Basically, let's add a new entry and push all the data to the end of the array, and then push in our new layer.

            ' Figure out what the highest Layer that's under our player is.
            ' Add one to this at the end, this will be the layer we're going to re-use.
            For x = 1 To Map.LayerCount
                If Map.Layers(x).UnderPlayer Then tempLayer = x
            Next
            tempLayer = tempLayer + 1

            ' First add a brand new layer to the counter.
            Map.LayerCount = Map.LayerCount + 1

            ' Now just redim the arrays. :)
            ReDim Preserve Map.Layers(Map.LayerCount)
            ReDim Preserve tex_Layer(Map.LayerCount)
            ReDim Preserve var_LayerChanged(Map.LayerCount)
            ReDim Map.Layers(Map.LayerCount).Tiles(Map.SizeX, Map.SizeY)

            ' Adding one because the rendered view needs to be an additional tile wide.
            tempX = Map.SizeX + 1
            tempY = Map.SizeY + 1
            tex_Layer(Map.LayerCount) = New SFML.Graphics.RenderTexture(tempX * TILE_X, tempY * TILE_Y)

            ' Loop through the maps backwards to move the data up.
            i = Map.LayerCount
            Do While i > tempLayer

                ' Move our data.
                Map.Layers(i) = Map.Layers(i - 1)

                ' Force the editor to render this layer later.
                var_LayerChanged(i) = True

                ' Move on to the next.
                i = i - 1
            Loop

            'Clear out our new layer.
            For tempX = 0 To Map.SizeX
                For tempY = 0 To Map.SizeY
                    Map.Layers(tempLayer).Tiles(tempX, tempY).TileSetID = 0
                    Map.Layers(tempLayer).Tiles(tempX, tempY).TileSetX = 0
                    Map.Layers(tempLayer).Tiles(tempX, tempY).TileSetY = 0
                Next
            Next
            var_LayerChanged(tempLayer) = True

            ' Set data to new layer.
            Map.Layers(tempLayer).LayerName = Name
            Map.Layers(tempLayer).UnderPlayer = UnderPlayer

        End If

        ' Force an update to the lists.
        PopulateLayerList()

        ' Set a status message.
        StatusMessage("Added new layer '" + Name + "'")

    End Sub

End Module
