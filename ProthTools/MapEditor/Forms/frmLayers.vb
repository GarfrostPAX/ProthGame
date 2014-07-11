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

    Private Sub btn_RenameLayer_Click(sender As Object, e As EventArgs) Handles btn_RenameLayer.Click
        Dim Result As String

        ' Ask for the new name.
        Result = InputBox("Enter the new name for this layer:", "Change Name")

        ' CHange the name
        Map.Layers(lst_Layers.SelectedIndices(0) + 1).LayerName = Trim(Result)

        ' Update lists.
        PopulateLayerList()

        ' Status message
        StatusMessage("Rename Layer #" + (lst_Layers.SelectedIndices(0) + 1).ToString + " to '" + Result + "'")
    End Sub

    Private Sub btn_AddLayer_Click(sender As Object, e As EventArgs) Handles btn_AddLayer.Click
        grp_AddLayer.Visible = True
        Me.Height = 159
    End Sub

    Private Sub btn_CancelAdd_Click(sender As Object, e As EventArgs) Handles btn_CancelAdd.Click
        ' Hide and reset this window again.
        Me.Height = 234
        txt_LayerName.Text = ""
        chk_UnderPlayer.Checked = False
        grp_AddLayer.Visible = False
    End Sub

    Private Sub btn_ConfirmAdd_Click(sender As Object, e As EventArgs) Handles btn_ConfirmAdd.Click
        ' Add layer.
        AddLayer(Trim(txt_LayerName.Text), chk_UnderPlayer.Checked)

        ' Hide and reset this window again.
        Me.Height = 234
        txt_LayerName.Text = ""
        chk_UnderPlayer.Checked = False
        grp_AddLayer.Visible = False
    End Sub
End Class