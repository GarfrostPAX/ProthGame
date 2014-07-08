Module modStructures

    Public Structure PlayerRec

        ' Client Specific Information
        Dim PlayerObj As Label

        ' Basic Information
        Dim Name As String
        Dim Job As Byte
        Dim Level As Byte
        Dim Experience As Integer

        ' Location Data
        Dim Map As Integer
        Dim X As Integer
        Dim Y As Integer
        Dim Direction As Byte

    End Structure

    Public Structure OptionsRec
        ' Server Information
        Dim ServerIP As String
        Dim ServerPort As Integer

        ' Graphical Options
        Dim Device As Byte
        Dim ResolutionX As Integer
        Dim ResolutionY As Integer
        Dim Fullscreen As Byte
        Dim VSync As Byte
    End Structure

End Module
