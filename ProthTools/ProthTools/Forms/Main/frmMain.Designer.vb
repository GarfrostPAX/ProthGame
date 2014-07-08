<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.strip_Status = New System.Windows.Forms.StatusStrip()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveMapToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveMapAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.RecentMapsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropertiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideHigherLayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideLowerLayersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.lbl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_Location = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.strip_Status.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'strip_Status
        '
        Me.strip_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Status, Me.lbl_Location})
        Me.strip_Status.Location = New System.Drawing.Point(0, 540)
        Me.strip_Status.Name = "strip_Status"
        Me.strip_Status.Size = New System.Drawing.Size(784, 22)
        Me.strip_Status.TabIndex = 0
        Me.strip_Status.Text = "StatusStrip1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.EditToolStripMenuItem, Me.ToolStripMenuItem6, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(784, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator1, Me.ToolStripButton4, Me.ToolStripButton5, Me.ToolStripSeparator2, Me.ToolStripButton6, Me.ToolStripButton7})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMapToolStripMenuItem, Me.OpenMapToolStripMenuItem, Me.ToolStripMenuItem2, Me.SaveMapToolStripMenuItem, Me.SaveMapAsToolStripMenuItem, Me.ToolStripMenuItem3, Me.RecentMapsToolStripMenuItem, Me.ToolStripMenuItem4, Me.CloseToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'NewMapToolStripMenuItem
        '
        Me.NewMapToolStripMenuItem.Name = "NewMapToolStripMenuItem"
        Me.NewMapToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.NewMapToolStripMenuItem.Text = "New Map"
        '
        'OpenMapToolStripMenuItem
        '
        Me.OpenMapToolStripMenuItem.Name = "OpenMapToolStripMenuItem"
        Me.OpenMapToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenMapToolStripMenuItem.Text = "Open Map"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(149, 6)
        '
        'SaveMapToolStripMenuItem
        '
        Me.SaveMapToolStripMenuItem.Name = "SaveMapToolStripMenuItem"
        Me.SaveMapToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveMapToolStripMenuItem.Text = "Save Map"
        '
        'SaveMapAsToolStripMenuItem
        '
        Me.SaveMapAsToolStripMenuItem.Name = "SaveMapAsToolStripMenuItem"
        Me.SaveMapAsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveMapAsToolStripMenuItem.Text = "Save Map As.."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(149, 6)
        '
        'RecentMapsToolStripMenuItem
        '
        Me.RecentMapsToolStripMenuItem.Name = "RecentMapsToolStripMenuItem"
        Me.RecentMapsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RecentMapsToolStripMenuItem.Text = "Recent Maps"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(149, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.ToolStripMenuItem5, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'UndoToolStripMenuItem
        '
        Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(149, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PasteToolStripMenuItem.Text = "Paste"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PropertiesToolStripMenuItem, Me.LayersToolStripMenuItem})
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(43, 20)
        Me.ToolStripMenuItem6.Text = "Map"
        '
        'PropertiesToolStripMenuItem
        '
        Me.PropertiesToolStripMenuItem.Name = "PropertiesToolStripMenuItem"
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'LayersToolStripMenuItem
        '
        Me.LayersToolStripMenuItem.Name = "LayersToolStripMenuItem"
        Me.LayersToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LayersToolStripMenuItem.Text = "Layers"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GridToolStripMenuItem, Me.HideHigherLayersToolStripMenuItem, Me.HideLowerLayersToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'GridToolStripMenuItem
        '
        Me.GridToolStripMenuItem.Name = "GridToolStripMenuItem"
        Me.GridToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.GridToolStripMenuItem.Text = "Grid"
        '
        'HideHigherLayersToolStripMenuItem
        '
        Me.HideHigherLayersToolStripMenuItem.Name = "HideHigherLayersToolStripMenuItem"
        Me.HideHigherLayersToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.HideHigherLayersToolStripMenuItem.Text = "Hide Higher Layers"
        '
        'HideLowerLayersToolStripMenuItem
        '
        Me.HideLowerLayersToolStripMenuItem.Name = "HideLowerLayersToolStripMenuItem"
        Me.HideLowerLayersToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.HideLowerLayersToolStripMenuItem.Text = "Hide Lower Layers"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "ToolStripButton3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "ToolStripButton4"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "ToolStripButton5"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "ToolStripButton6"
        '
        'lbl_Status
        '
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(39, 17)
        Me.lbl_Status.Text = "Ready"
        '
        'lbl_Location
        '
        Me.lbl_Location.Name = "lbl_Location"
        Me.lbl_Location.Size = New System.Drawing.Size(111, 17)
        Me.lbl_Location.Text = "Map: 1.map (0, 0, 0)"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "ToolStripButton7"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.strip_Status)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Prothesys Map Editor"
        Me.strip_Status.ResumeLayout(False)
        Me.strip_Status.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents strip_Status As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveMapToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveMapAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RecentMapsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropertiesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LayersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideHigherLayersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideLowerLayersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lbl_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_Location As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
End Class
