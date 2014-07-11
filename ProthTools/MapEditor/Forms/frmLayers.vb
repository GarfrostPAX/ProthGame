Public Class frmLayers

    Private Sub frmLayers_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ' Now for a little cheating.
        ' We'll cancel the closing event and just hide the form.
        var_LayersOpen = False
        e.Cancel = True
        frm_Main.Enabled = True
        Me.Hide()
    End Sub

    Private Sub btn_DeleteLayer_Click(sender As Object, e As EventArgs) Handles btn_DeleteLayer.Click
        Dim Result As New Microsoft.VisualBasic.MsgBoxResult

        ' Make sure the user wants to delete this layer.
        Result = MsgBox("Deleting the layer '" + Map.Layers(lst_Layers.SelectedIndices(0) + 1).LayerName + "' is irreversible. All changes to this layer will be lost." + vbNewLine + vbNewLine + "Are you sure you want to continue?", MsgBoxStyle.YesNo, "Delete Layer")

        ' If so, do as they say!
        If Result = MsgBoxResult.Yes Then
            ' Delete our layer.
            DeleteLayer(lst_Layers.SelectedIndices(0) + 1)

        End If
    End Sub
End Class