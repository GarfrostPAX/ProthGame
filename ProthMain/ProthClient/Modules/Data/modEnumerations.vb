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

    Public Enum LoginStates As Byte
        None
        Processing
        Rejected
        Accepted
    End Enum

    Public Enum GameState
        Closing
        Loading
        Login
        CharSelect
        CharCreate
    End Enum

End Module
