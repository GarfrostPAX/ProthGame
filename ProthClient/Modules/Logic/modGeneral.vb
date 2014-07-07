Imports System.Runtime.InteropServices

Module modGeneral
    Public Function FileExist(ByVal File As String) As Boolean
        Return System.IO.File.Exists(var_AppPath + File)
    End Function

    Public Function VarPtr(ByVal e As Object) As Integer
        Dim GC As GCHandle = GCHandle.Alloc(e, GCHandleType.Pinned)
        Dim GC2 As Integer = GC.AddrOfPinnedObject.ToInt32
        GC.Free()
        Return GC2
    End Function

    Public Function LenB(ByVal ObjStr As String) As Integer
        'Note that ObjStr.Length will fail if ObjStr was set to Nothing   
        If Len(ObjStr) = 0 Then Return 0
        Return System.Text.Encoding.Unicode.GetByteCount(ObjStr)
    End Function

    Public Function LenB(ByVal Obj As Object) As Integer
        If Obj Is Nothing Then Return 0
        Try 'Structure
            Return Len(Obj)
        Catch 'Leave blank for catch-all
            Try 'Type-def objects
                Return System.Runtime.InteropServices.Marshal.SizeOf(Obj)
            Catch 'Leave blank for catch-all
                Return -1 'Allow user to check for <0 as error
            End Try
        End Try
    End Function

End Module
