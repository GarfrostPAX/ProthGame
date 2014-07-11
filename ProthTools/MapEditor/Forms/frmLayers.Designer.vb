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
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lst_Layers
        '
        Me.lst_Layers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lst_Layers.Location = New System.Drawing.Point(3, 16)
        Me.lst_Layers.MultiSelect = False
        Me.lst_Layers.Name = "lst_Layers"
        Me.lst_Layers.Size = New System.Drawing.Size(235, 131)
        Me.lst_Layers.TabIndex = 0
        Me.lst_Layers.UseCompatibleStateImageBehavior = False
        Me.lst_Layers.View = System.Windows.Forms.View.List
        '
        'GroupBox1
        '
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
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lst_Layers As System.Windows.Forms.ListView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn_AddLayer As System.Windows.Forms.Button
    Friend WithEvents btn_DeleteLayer As System.Windows.Forms.Button
    Friend WithEvents btn_RenameLayer As System.Windows.Forms.Button
End Class
