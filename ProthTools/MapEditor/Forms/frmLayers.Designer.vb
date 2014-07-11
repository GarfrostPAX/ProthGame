<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLayers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lst_Layers = New System.Windows.Forms.ListView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_AddLayer = New System.Windows.Forms.Button()
        Me.btn_DeleteLayer = New System.Windows.Forms.Button()
        Me.btn_RenameLayer = New System.Windows.Forms.Button()
        Me.grp_AddLayer = New System.Windows.Forms.GroupBox()
        Me.txt_LayerName = New System.Windows.Forms.TextBox()
        Me.chk_UnderPlayer = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_CancelAdd = New System.Windows.Forms.Button()
        Me.btn_ConfirmAdd = New System.Windows.Forms.Button()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.grp_AddLayer.SuspendLayout()
        Me.SuspendLayout()
        '
        'lst_Layers
        '
        Me.lst_Layers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lst_Layers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst_Layers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lst_Layers.Location = New System.Drawing.Point(3, 16)
        Me.lst_Layers.MultiSelect = False
        Me.lst_Layers.Name = "lst_Layers"
        Me.lst_Layers.Size = New System.Drawing.Size(235, 131)
        Me.lst_Layers.TabIndex = 0
        Me.lst_Layers.UseCompatibleStateImageBehavior = False
        Me.lst_Layers.View = System.Windows.Forms.View.Details
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grp_AddLayer)
        Me.GroupBox1.Controls.Add(Me.lst_Layers)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(241, 150)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Layers"
        '
        'btn_AddLayer
        '
        Me.btn_AddLayer.Location = New System.Drawing.Point(12, 165)
        Me.btn_AddLayer.Name = "btn_AddLayer"
        Me.btn_AddLayer.Size = New System.Drawing.Size(75, 23)
        Me.btn_AddLayer.TabIndex = 2
        Me.btn_AddLayer.Text = "Add"
        Me.btn_AddLayer.UseVisualStyleBackColor = True
        '
        'btn_DeleteLayer
        '
        Me.btn_DeleteLayer.Location = New System.Drawing.Point(175, 165)
        Me.btn_DeleteLayer.Name = "btn_DeleteLayer"
        Me.btn_DeleteLayer.Size = New System.Drawing.Size(75, 23)
        Me.btn_DeleteLayer.TabIndex = 3
        Me.btn_DeleteLayer.Text = "Delete"
        Me.btn_DeleteLayer.UseVisualStyleBackColor = True
        '
        'btn_RenameLayer
        '
        Me.btn_RenameLayer.Location = New System.Drawing.Point(93, 165)
        Me.btn_RenameLayer.Name = "btn_RenameLayer"
        Me.btn_RenameLayer.Size = New System.Drawing.Size(75, 23)
        Me.btn_RenameLayer.TabIndex = 4
        Me.btn_RenameLayer.Text = "Rename"
        Me.btn_RenameLayer.UseVisualStyleBackColor = True
        '
        'grp_AddLayer
        '
        Me.grp_AddLayer.Controls.Add(Me.txt_LayerName)
        Me.grp_AddLayer.Controls.Add(Me.chk_UnderPlayer)
        Me.grp_AddLayer.Controls.Add(Me.Label1)
        Me.grp_AddLayer.Controls.Add(Me.btn_CancelAdd)
        Me.grp_AddLayer.Controls.Add(Me.btn_ConfirmAdd)
        Me.grp_AddLayer.Location = New System.Drawing.Point(0, 0)
        Me.grp_AddLayer.Name = "grp_AddLayer"
        Me.grp_AddLayer.Size = New System.Drawing.Size(241, 110)
        Me.grp_AddLayer.TabIndex = 6
        Me.grp_AddLayer.TabStop = False
        Me.grp_AddLayer.Text = "Add Layer"
        Me.grp_AddLayer.Visible = False
        '
        'txt_LayerName
        '
        Me.txt_LayerName.Location = New System.Drawing.Point(9, 32)
        Me.txt_LayerName.Name = "txt_LayerName"
        Me.txt_LayerName.Size = New System.Drawing.Size(226, 20)
        Me.txt_LayerName.TabIndex = 4
        '
        'chk_UnderPlayer
        '
        Me.chk_UnderPlayer.AutoSize = True
        Me.chk_UnderPlayer.Location = New System.Drawing.Point(148, 58)
        Me.chk_UnderPlayer.Name = "chk_UnderPlayer"
        Me.chk_UnderPlayer.Size = New System.Drawing.Size(87, 17)
        Me.chk_UnderPlayer.TabIndex = 3
        Me.chk_UnderPlayer.Text = "Under Player"
        Me.chk_UnderPlayer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Layer Name:"
        '
        'btn_CancelAdd
        '
        Me.btn_CancelAdd.Location = New System.Drawing.Point(160, 81)
        Me.btn_CancelAdd.Name = "btn_CancelAdd"
        Me.btn_CancelAdd.Size = New System.Drawing.Size(75, 23)
        Me.btn_CancelAdd.TabIndex = 1
        Me.btn_CancelAdd.Text = "Cancel"
        Me.btn_CancelAdd.UseVisualStyleBackColor = True
        '
        'btn_ConfirmAdd
        '
        Me.btn_ConfirmAdd.Location = New System.Drawing.Point(9, 81)
        Me.btn_ConfirmAdd.Name = "btn_ConfirmAdd"
        Me.btn_ConfirmAdd.Size = New System.Drawing.Size(75, 23)
        Me.btn_ConfirmAdd.TabIndex = 0
        Me.btn_ConfirmAdd.Text = "Add"
        Me.btn_ConfirmAdd.UseVisualStyleBackColor = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 200
        '
        'frmLayers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(265, 196)
        Me.Controls.Add(Me.btn_RenameLayer)
        Me.Controls.Add(Me.btn_DeleteLayer)
        Me.Controls.Add(Me.btn_AddLayer)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLayers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Layer Management"
        Me.GroupBox1.ResumeLayout(False)
        Me.grp_AddLayer.ResumeLayout(False)
        Me.grp_AddLayer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lst_Layers As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_AddLayer As System.Windows.Forms.Button
    Friend WithEvents btn_DeleteLayer As System.Windows.Forms.Button
    Friend WithEvents btn_RenameLayer As System.Windows.Forms.Button
    Friend WithEvents grp_AddLayer As System.Windows.Forms.GroupBox
    Friend WithEvents txt_LayerName As System.Windows.Forms.TextBox
    Friend WithEvents chk_UnderPlayer As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_CancelAdd As System.Windows.Forms.Button
    Friend WithEvents btn_ConfirmAdd As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class
