﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
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
        Me.chk_Grid = New System.Windows.Forms.ToolStripMenuItem()
        Me.chk_HighLayers = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkLowLayers = New System.Windows.Forms.ToolStripMenuItem()
        Me.chk_FadeLayers = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btn_NewMap = New System.Windows.Forms.ToolStripButton()
        Me.btn_OpenMap = New System.Windows.Forms.ToolStripButton()
        Me.btn_SaveMap = New System.Windows.Forms.ToolStripButton()
        Me.btn_SaveAs = New System.Windows.Forms.ToolStripButton()
        Me.btn_Undo = New System.Windows.Forms.ToolStripButton()
        Me.btn_Redo = New System.Windows.Forms.ToolStripButton()
        Me.grp_TileSelect = New System.Windows.Forms.GroupBox()
        Me.splt_TileSelect = New System.Windows.Forms.SplitContainer()
        Me.cmb_TileSets = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.scrl_HTile = New System.Windows.Forms.HScrollBar()
        Me.scrl_VTile = New System.Windows.Forms.VScrollBar()
        Me.pan_Misc = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_ClearLayer = New System.Windows.Forms.Button()
        Me.btn_FillLayer = New System.Windows.Forms.Button()
        Me.btn_ManageLayers = New System.Windows.Forms.Button()
        Me.cmb_Layers = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.strip_Status = New System.Windows.Forms.StatusStrip()
        Me.lbl_Status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbl_Location = New System.Windows.Forms.ToolStripStatusLabel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chk_AttributeMode = New System.Windows.Forms.CheckBox()
        Me.rd_Blocked = New System.Windows.Forms.RadioButton()
        Me.rd_Warp = New System.Windows.Forms.RadioButton()
        Me.rd_NPCSPawn = New System.Windows.Forms.RadioButton()
        Me.lbl_Data1 = New System.Windows.Forms.Label()
        Me.lbl_Data2 = New System.Windows.Forms.Label()
        Me.lbl_Data3 = New System.Windows.Forms.Label()
        Me.txt_Data1 = New System.Windows.Forms.TextBox()
        Me.txt_Data2 = New System.Windows.Forms.TextBox()
        Me.txt_Data3 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grp_TileSelect.SuspendLayout()
        CType(Me.splt_TileSelect, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splt_TileSelect.Panel1.SuspendLayout()
        Me.splt_TileSelect.Panel2.SuspendLayout()
        Me.splt_TileSelect.SuspendLayout()
        Me.pan_Misc.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.strip_Status.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.EditToolStripMenuItem, Me.ToolStripMenuItem6, Me.ViewToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1264, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.NewMapToolStripMenuItem.Image = Global.ProthTools.My.Resources.Resources.NewFile_6276
        Me.NewMapToolStripMenuItem.Name = "NewMapToolStripMenuItem"
        Me.NewMapToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.NewMapToolStripMenuItem.Text = "New Map (Ctrl+N)"
        '
        'OpenMapToolStripMenuItem
        '
        Me.OpenMapToolStripMenuItem.Image = Global.ProthTools.My.Resources.Resources.Open_6529
        Me.OpenMapToolStripMenuItem.Name = "OpenMapToolStripMenuItem"
        Me.OpenMapToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.OpenMapToolStripMenuItem.Text = "Open Map (Ctrl+O)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(174, 6)
        '
        'SaveMapToolStripMenuItem
        '
        Me.SaveMapToolStripMenuItem.Image = Global.ProthTools.My.Resources.Resources.Save_6530
        Me.SaveMapToolStripMenuItem.Name = "SaveMapToolStripMenuItem"
        Me.SaveMapToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SaveMapToolStripMenuItem.Text = "Save Map (Ctrl+S)"
        '
        'SaveMapAsToolStripMenuItem
        '
        Me.SaveMapAsToolStripMenuItem.Image = Global.ProthTools.My.Resources.Resources.Saveall_6518
        Me.SaveMapAsToolStripMenuItem.Name = "SaveMapAsToolStripMenuItem"
        Me.SaveMapAsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.SaveMapAsToolStripMenuItem.Text = "Save Map As.."
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(174, 6)
        '
        'RecentMapsToolStripMenuItem
        '
        Me.RecentMapsToolStripMenuItem.Name = "RecentMapsToolStripMenuItem"
        Me.RecentMapsToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.RecentMapsToolStripMenuItem.Text = "Recent Maps"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(174, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = Global.ProthTools.My.Resources.Resources.Clearallrequests_8816
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
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
        Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.UndoToolStripMenuItem.Text = "Undo"
        '
        'RedoToolStripMenuItem
        '
        Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
        Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.RedoToolStripMenuItem.Text = "Redo"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(100, 6)
        '
        'CutToolStripMenuItem
        '
        Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
        Me.CutToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CutToolStripMenuItem.Text = "Cut"
        '
        'CopyToolStripMenuItem
        '
        Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CopyToolStripMenuItem.Text = "Copy"
        '
        'PasteToolStripMenuItem
        '
        Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
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
        Me.PropertiesToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.PropertiesToolStripMenuItem.Text = "Properties"
        '
        'LayersToolStripMenuItem
        '
        Me.LayersToolStripMenuItem.Name = "LayersToolStripMenuItem"
        Me.LayersToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.LayersToolStripMenuItem.Text = "Layers"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.chk_Grid, Me.chk_HighLayers, Me.chkLowLayers, Me.chk_FadeLayers})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'chk_Grid
        '
        Me.chk_Grid.CheckOnClick = True
        Me.chk_Grid.Name = "chk_Grid"
        Me.chk_Grid.Size = New System.Drawing.Size(179, 22)
        Me.chk_Grid.Text = "Grid"
        '
        'chk_HighLayers
        '
        Me.chk_HighLayers.CheckOnClick = True
        Me.chk_HighLayers.Name = "chk_HighLayers"
        Me.chk_HighLayers.Size = New System.Drawing.Size(179, 22)
        Me.chk_HighLayers.Text = "Hide Higher Layers"
        '
        'chkLowLayers
        '
        Me.chkLowLayers.CheckOnClick = True
        Me.chkLowLayers.Name = "chkLowLayers"
        Me.chkLowLayers.Size = New System.Drawing.Size(179, 22)
        Me.chkLowLayers.Text = "Hide Lower Layers"
        '
        'chk_FadeLayers
        '
        Me.chk_FadeLayers.Checked = True
        Me.chk_FadeLayers.CheckOnClick = True
        Me.chk_FadeLayers.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chk_FadeLayers.Name = "chk_FadeLayers"
        Me.chk_FadeLayers.Size = New System.Drawing.Size(179, 22)
        Me.chk_FadeLayers.Text = "Fade Inactive Layers"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btn_NewMap, Me.btn_OpenMap, Me.btn_SaveMap, Me.btn_SaveAs, Me.ToolStripSeparator1, Me.btn_Undo, Me.btn_Redo, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1264, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btn_NewMap
        '
        Me.btn_NewMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_NewMap.Image = Global.ProthTools.My.Resources.Resources.NewFile_6276
        Me.btn_NewMap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_NewMap.Name = "btn_NewMap"
        Me.btn_NewMap.Size = New System.Drawing.Size(23, 22)
        Me.btn_NewMap.Text = "New Map"
        '
        'btn_OpenMap
        '
        Me.btn_OpenMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_OpenMap.Image = Global.ProthTools.My.Resources.Resources.Open_6529
        Me.btn_OpenMap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_OpenMap.Name = "btn_OpenMap"
        Me.btn_OpenMap.Size = New System.Drawing.Size(23, 22)
        Me.btn_OpenMap.Text = "Load Map"
        '
        'btn_SaveMap
        '
        Me.btn_SaveMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_SaveMap.Image = Global.ProthTools.My.Resources.Resources.Save_6530
        Me.btn_SaveMap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_SaveMap.Name = "btn_SaveMap"
        Me.btn_SaveMap.Size = New System.Drawing.Size(23, 22)
        Me.btn_SaveMap.Text = "Save Map"
        '
        'btn_SaveAs
        '
        Me.btn_SaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_SaveAs.Image = Global.ProthTools.My.Resources.Resources.Saveall_6518
        Me.btn_SaveAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_SaveAs.Name = "btn_SaveAs"
        Me.btn_SaveAs.Size = New System.Drawing.Size(23, 22)
        Me.btn_SaveAs.Text = "Save As"
        '
        'btn_Undo
        '
        Me.btn_Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Undo.Image = Global.ProthTools.My.Resources.Resources.Undo_16x
        Me.btn_Undo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Undo.Name = "btn_Undo"
        Me.btn_Undo.Size = New System.Drawing.Size(23, 22)
        Me.btn_Undo.Text = "Undo"
        '
        'btn_Redo
        '
        Me.btn_Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btn_Redo.Image = Global.ProthTools.My.Resources.Resources.Redo_16x
        Me.btn_Redo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btn_Redo.Name = "btn_Redo"
        Me.btn_Redo.Size = New System.Drawing.Size(23, 22)
        Me.btn_Redo.Text = "Redo"
        '
        'grp_TileSelect
        '
        Me.grp_TileSelect.Controls.Add(Me.splt_TileSelect)
        Me.grp_TileSelect.Dock = System.Windows.Forms.DockStyle.Left
        Me.grp_TileSelect.Location = New System.Drawing.Point(0, 49)
        Me.grp_TileSelect.Name = "grp_TileSelect"
        Me.grp_TileSelect.Size = New System.Drawing.Size(280, 633)
        Me.grp_TileSelect.TabIndex = 3
        Me.grp_TileSelect.TabStop = False
        Me.grp_TileSelect.Text = "Tile Select"
        '
        'splt_TileSelect
        '
        Me.splt_TileSelect.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splt_TileSelect.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splt_TileSelect.IsSplitterFixed = True
        Me.splt_TileSelect.Location = New System.Drawing.Point(3, 16)
        Me.splt_TileSelect.Name = "splt_TileSelect"
        Me.splt_TileSelect.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splt_TileSelect.Panel1
        '
        Me.splt_TileSelect.Panel1.Controls.Add(Me.cmb_TileSets)
        Me.splt_TileSelect.Panel1.Controls.Add(Me.Label1)
        '
        'splt_TileSelect.Panel2
        '
        Me.splt_TileSelect.Panel2.Controls.Add(Me.scrl_HTile)
        Me.splt_TileSelect.Panel2.Controls.Add(Me.scrl_VTile)
        Me.splt_TileSelect.Size = New System.Drawing.Size(274, 614)
        Me.splt_TileSelect.SplitterDistance = 53
        Me.splt_TileSelect.SplitterWidth = 1
        Me.splt_TileSelect.TabIndex = 1
        '
        'cmb_TileSets
        '
        Me.cmb_TileSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_TileSets.FormattingEnabled = True
        Me.cmb_TileSets.Location = New System.Drawing.Point(9, 20)
        Me.cmb_TileSets.MaxDropDownItems = 100
        Me.cmb_TileSets.Name = "cmb_TileSets"
        Me.cmb_TileSets.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmb_TileSets.Size = New System.Drawing.Size(252, 21)
        Me.cmb_TileSets.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Current Tileset:"
        '
        'scrl_HTile
        '
        Me.scrl_HTile.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.scrl_HTile.LargeChange = 1
        Me.scrl_HTile.Location = New System.Drawing.Point(0, 543)
        Me.scrl_HTile.Maximum = 10
        Me.scrl_HTile.Name = "scrl_HTile"
        Me.scrl_HTile.Size = New System.Drawing.Size(256, 17)
        Me.scrl_HTile.TabIndex = 3
        '
        'scrl_VTile
        '
        Me.scrl_VTile.Dock = System.Windows.Forms.DockStyle.Right
        Me.scrl_VTile.LargeChange = 1
        Me.scrl_VTile.Location = New System.Drawing.Point(256, 0)
        Me.scrl_VTile.Name = "scrl_VTile"
        Me.scrl_VTile.Size = New System.Drawing.Size(18, 560)
        Me.scrl_VTile.TabIndex = 2
        '
        'pan_Misc
        '
        Me.pan_Misc.Controls.Add(Me.GroupBox2)
        Me.pan_Misc.Controls.Add(Me.GroupBox1)
        Me.pan_Misc.Dock = System.Windows.Forms.DockStyle.Right
        Me.pan_Misc.Location = New System.Drawing.Point(1054, 49)
        Me.pan_Misc.Name = "pan_Misc"
        Me.pan_Misc.Size = New System.Drawing.Size(210, 633)
        Me.pan_Misc.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_ClearLayer)
        Me.GroupBox1.Controls.Add(Me.btn_FillLayer)
        Me.GroupBox1.Controls.Add(Me.btn_ManageLayers)
        Me.GroupBox1.Controls.Add(Me.cmb_Layers)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(2, -2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(204, 116)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Layers"
        '
        'btn_ClearLayer
        '
        Me.btn_ClearLayer.Location = New System.Drawing.Point(123, 88)
        Me.btn_ClearLayer.Name = "btn_ClearLayer"
        Me.btn_ClearLayer.Size = New System.Drawing.Size(75, 23)
        Me.btn_ClearLayer.TabIndex = 6
        Me.btn_ClearLayer.Text = "Clear Layer"
        Me.btn_ClearLayer.UseVisualStyleBackColor = True
        '
        'btn_FillLayer
        '
        Me.btn_FillLayer.Location = New System.Drawing.Point(6, 88)
        Me.btn_FillLayer.Name = "btn_FillLayer"
        Me.btn_FillLayer.Size = New System.Drawing.Size(75, 23)
        Me.btn_FillLayer.TabIndex = 5
        Me.btn_FillLayer.Text = "Fill Layer"
        Me.btn_FillLayer.UseVisualStyleBackColor = True
        '
        'btn_ManageLayers
        '
        Me.btn_ManageLayers.Location = New System.Drawing.Point(6, 59)
        Me.btn_ManageLayers.Name = "btn_ManageLayers"
        Me.btn_ManageLayers.Size = New System.Drawing.Size(192, 23)
        Me.btn_ManageLayers.TabIndex = 4
        Me.btn_ManageLayers.Text = "Manage Layers"
        Me.btn_ManageLayers.UseVisualStyleBackColor = True
        '
        'cmb_Layers
        '
        Me.cmb_Layers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_Layers.FormattingEnabled = True
        Me.cmb_Layers.Location = New System.Drawing.Point(6, 32)
        Me.cmb_Layers.MaxDropDownItems = 100
        Me.cmb_Layers.Name = "cmb_Layers"
        Me.cmb_Layers.Size = New System.Drawing.Size(192, 21)
        Me.cmb_Layers.TabIndex = 3
        Me.cmb_Layers.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Current Layer:"
        '
        'strip_Status
        '
        Me.strip_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_Status, Me.ToolStripStatusLabel1, Me.lbl_Location})
        Me.strip_Status.Location = New System.Drawing.Point(280, 660)
        Me.strip_Status.Name = "strip_Status"
        Me.strip_Status.Size = New System.Drawing.Size(774, 22)
        Me.strip_Status.TabIndex = 6
        Me.strip_Status.Text = "StatusStrip1"
        '
        'lbl_Status
        '
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(39, 17)
        Me.lbl_Status.Text = "Ready"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(10, 17)
        Me.ToolStripStatusLabel1.Text = "|"
        '
        'lbl_Location
        '
        Me.lbl_Location.Name = "lbl_Location"
        Me.lbl_Location.Size = New System.Drawing.Size(111, 17)
        Me.lbl_Location.Text = "Map: 1.map (0, 0, 0)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txt_Data3)
        Me.GroupBox2.Controls.Add(Me.txt_Data2)
        Me.GroupBox2.Controls.Add(Me.txt_Data1)
        Me.GroupBox2.Controls.Add(Me.lbl_Data3)
        Me.GroupBox2.Controls.Add(Me.lbl_Data2)
        Me.GroupBox2.Controls.Add(Me.lbl_Data1)
        Me.GroupBox2.Controls.Add(Me.rd_NPCSPawn)
        Me.GroupBox2.Controls.Add(Me.rd_Warp)
        Me.GroupBox2.Controls.Add(Me.rd_Blocked)
        Me.GroupBox2.Controls.Add(Me.chk_AttributeMode)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 115)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(204, 229)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Attributes"
        '
        'chk_AttributeMode
        '
        Me.chk_AttributeMode.AutoSize = True
        Me.chk_AttributeMode.Location = New System.Drawing.Point(6, 19)
        Me.chk_AttributeMode.Name = "chk_AttributeMode"
        Me.chk_AttributeMode.Size = New System.Drawing.Size(95, 17)
        Me.chk_AttributeMode.TabIndex = 0
        Me.chk_AttributeMode.Text = "Attribute Mode"
        Me.chk_AttributeMode.UseVisualStyleBackColor = True
        '
        'rd_Blocked
        '
        Me.rd_Blocked.AutoSize = True
        Me.rd_Blocked.Checked = True
        Me.rd_Blocked.Location = New System.Drawing.Point(5, 54)
        Me.rd_Blocked.Name = "rd_Blocked"
        Me.rd_Blocked.Size = New System.Drawing.Size(64, 17)
        Me.rd_Blocked.TabIndex = 1
        Me.rd_Blocked.TabStop = True
        Me.rd_Blocked.Text = "Blocked"
        Me.rd_Blocked.UseVisualStyleBackColor = True
        '
        'rd_Warp
        '
        Me.rd_Warp.AutoSize = True
        Me.rd_Warp.Location = New System.Drawing.Point(122, 54)
        Me.rd_Warp.Name = "rd_Warp"
        Me.rd_Warp.Size = New System.Drawing.Size(51, 17)
        Me.rd_Warp.TabIndex = 2
        Me.rd_Warp.Text = "Warp"
        Me.rd_Warp.UseVisualStyleBackColor = True
        '
        'rd_NPCSPawn
        '
        Me.rd_NPCSPawn.AutoSize = True
        Me.rd_NPCSPawn.Location = New System.Drawing.Point(5, 77)
        Me.rd_NPCSPawn.Name = "rd_NPCSPawn"
        Me.rd_NPCSPawn.Size = New System.Drawing.Size(83, 17)
        Me.rd_NPCSPawn.TabIndex = 3
        Me.rd_NPCSPawn.Text = "NPC Spawn"
        Me.rd_NPCSPawn.UseVisualStyleBackColor = True
        '
        'lbl_Data1
        '
        Me.lbl_Data1.AutoSize = True
        Me.lbl_Data1.Location = New System.Drawing.Point(2, 103)
        Me.lbl_Data1.Name = "lbl_Data1"
        Me.lbl_Data1.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Data1.TabIndex = 4
        Me.lbl_Data1.Text = "Data1:"
        '
        'lbl_Data2
        '
        Me.lbl_Data2.AutoSize = True
        Me.lbl_Data2.Location = New System.Drawing.Point(2, 142)
        Me.lbl_Data2.Name = "lbl_Data2"
        Me.lbl_Data2.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Data2.TabIndex = 5
        Me.lbl_Data2.Text = "Data2:"
        '
        'lbl_Data3
        '
        Me.lbl_Data3.AutoSize = True
        Me.lbl_Data3.Location = New System.Drawing.Point(2, 181)
        Me.lbl_Data3.Name = "lbl_Data3"
        Me.lbl_Data3.Size = New System.Drawing.Size(39, 13)
        Me.lbl_Data3.TabIndex = 6
        Me.lbl_Data3.Text = "Data3:"
        '
        'txt_Data1
        '
        Me.txt_Data1.Location = New System.Drawing.Point(6, 119)
        Me.txt_Data1.Name = "txt_Data1"
        Me.txt_Data1.Size = New System.Drawing.Size(189, 20)
        Me.txt_Data1.TabIndex = 7
        Me.txt_Data1.Text = "0"
        '
        'txt_Data2
        '
        Me.txt_Data2.Location = New System.Drawing.Point(5, 158)
        Me.txt_Data2.Name = "txt_Data2"
        Me.txt_Data2.Size = New System.Drawing.Size(189, 20)
        Me.txt_Data2.TabIndex = 8
        Me.txt_Data2.Text = "0"
        '
        'txt_Data3
        '
        Me.txt_Data3.Location = New System.Drawing.Point(5, 197)
        Me.txt_Data3.Name = "txt_Data3"
        Me.txt_Data3.Size = New System.Drawing.Size(189, 20)
        Me.txt_Data3.TabIndex = 9
        Me.txt_Data3.Text = "0"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 682)
        Me.Controls.Add(Me.strip_Status)
        Me.Controls.Add(Me.pan_Misc)
        Me.Controls.Add(Me.grp_TileSelect)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prothesys Map Editor [New Map]"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grp_TileSelect.ResumeLayout(False)
        Me.splt_TileSelect.Panel1.ResumeLayout(False)
        Me.splt_TileSelect.Panel1.PerformLayout()
        Me.splt_TileSelect.Panel2.ResumeLayout(False)
        CType(Me.splt_TileSelect, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splt_TileSelect.ResumeLayout(False)
        Me.pan_Misc.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.strip_Status.ResumeLayout(False)
        Me.strip_Status.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
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
    Friend WithEvents chk_Grid As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chk_HighLayers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkLowLayers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_NewMap As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_OpenMap As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_SaveMap As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_Undo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btn_Redo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btn_SaveAs As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents grp_TileSelect As System.Windows.Forms.GroupBox
    Friend WithEvents splt_TileSelect As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_TileSets As System.Windows.Forms.ComboBox
    Friend WithEvents scrl_VTile As System.Windows.Forms.VScrollBar
    Friend WithEvents scrl_HTile As System.Windows.Forms.HScrollBar
    Friend WithEvents pan_Misc As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents strip_Status As System.Windows.Forms.StatusStrip
    Friend WithEvents lbl_Status As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbl_Location As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmb_Layers As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents chk_FadeLayers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_ManageLayers As System.Windows.Forms.Button
    Friend WithEvents btn_FillLayer As System.Windows.Forms.Button
    Friend WithEvents btn_ClearLayer As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chk_AttributeMode As System.Windows.Forms.CheckBox
    Friend WithEvents rd_NPCSPawn As System.Windows.Forms.RadioButton
    Friend WithEvents rd_Warp As System.Windows.Forms.RadioButton
    Friend WithEvents rd_Blocked As System.Windows.Forms.RadioButton
    Friend WithEvents txt_Data3 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Data2 As System.Windows.Forms.TextBox
    Friend WithEvents txt_Data1 As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Data3 As System.Windows.Forms.Label
    Friend WithEvents lbl_Data2 As System.Windows.Forms.Label
    Friend WithEvents lbl_Data1 As System.Windows.Forms.Label
End Class
