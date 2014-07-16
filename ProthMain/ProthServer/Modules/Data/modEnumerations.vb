Module modEnumerations

    Public Enum ClientPackets As Byte
        RequestVersion
        RequestPING
        RequestLogin
        RequestLogout
        RequestCreateChar
    End Enum

    Public Enum ServerPackets As Byte
        SendVersion
        SendPING
        SendSystemMessage
        SendClientSlot
        SendLoginFailure
        SendLoginOK
        SendCreateCharResult
    End Enum

    Public Enum SystemMessages As Byte
        MsgWarning
        MsgError
        MsgInfo
    End Enum

    Public Enum Directions As Byte
        Up
        Right
        Down
        Left
    End Enum

    Public Enum LoginStatus As Byte
        None
        Waiting
        Processing
        Verified
        Rejected
    End Enum

End Module
