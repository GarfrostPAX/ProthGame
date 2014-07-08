Imports System.Windows.Forms

Module modInput

    Public Sub HandleMainMouseClick(ByVal mButton As MouseButtons, ByVal X As Integer, ByVal Y As Integer)

        ' Let's check what mousebutton is being pressed and act accordingly.
        Select Case mButton

            Case MouseButtons.Left
                ' TODO: Add proper Handler.
                Map.Layers(1).Tiles((X - 16) / TILE_X, (Y - 16) / TILE_Y).TileSetID = 1
                Map.Layers(1).Tiles((X - 16) / TILE_X, (Y - 16) / TILE_Y).TileSetX = 32
                Map.Layers(1).Tiles((X - 16) / TILE_X, (Y - 16) / TILE_Y).TileSetY = 320
                Exit Sub
            Case MouseButtons.Right
                ' TODO: Add Handler.
                Exit Sub
        End Select

    End Sub

End Module
