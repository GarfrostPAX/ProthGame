Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Public Class WindowSurface
    Inherits System.Windows.Forms.Control

    Public Sub New(ByVal Height As Integer, ByVal Width As Integer)
        Me.Width = Width
        Me.Height = Height
        Me.Left = 0
        Me.Top = 0
    End Sub

    Protected Overrides Sub OnPaint(e As Windows.Forms.PaintEventArgs)
        ' MyBase.OnPaint(e)
    End Sub
    Protected Overrides Sub OnPaintBackground(pevent As Windows.Forms.PaintEventArgs)
        ' MyBase.OnPaintBackground(pevent)
    End Sub

End Class
