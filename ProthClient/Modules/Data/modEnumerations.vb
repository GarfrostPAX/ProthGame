Module modEnumerations

    Public Enum ClientPackets As Byte
        RequestVersion
        RequestPING
        RequestLogin
    End Enum

    Public Enum ServerPackets As Byte
        SendVersion
        SendPING
        SendSystemMessage
        SendClientSlot
        SendLoginFailure
        SendLoginOK
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

    Public Enum LoginStates As Byte
        None
        Processing
        Rejected
        Accepted
    End Enum

End Module
