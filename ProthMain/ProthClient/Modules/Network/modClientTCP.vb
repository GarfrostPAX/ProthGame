Module modClientTCP
    Public obj_Client As Nading.Network.Client.clsClient

    Public Sub InitClientTCP()

        ' Initialize the object.
        obj_Client = New Nading.Network.Client.clsClient

        ' Add event handlers for the events that may occur on the client-side of things.
        AddHandler obj_Client.Connected, AddressOf OnConnected
        AddHandler obj_Client.Disconnected, AddressOf OnDisconnected
        AddHandler obj_Client.PacketReceived, AddressOf OnPacketReceived

        ' And attempt to connect to the server.
        ' Make sure to keep the Packetqueue turned off, we want to use event based processing.
        Try
            ' Set the status label to "connecting"
            lbl_LoginStatus.Text = "Connecting.."

            ' Connect
            obj_Client.Connect(obj_Options.ServerIP, obj_Options.ServerPort.ToString, False)
        Catch ex As Exception
            MsgBox("Unable to connect to the server." + vbNewLine + "Please check your internet connection or the forums for scheduled Maintenance times.", MsgBoxStyle.Exclamation, "Unable to Connect")
            DestroyGame()
        End Try
    End Sub

    Public Sub DestroyClientTCP()
        ' Disconnect from the server if connected.
        If obj_Client.IsConnected = True Then
            Try
                obj_Client.Disconnect()
            Catch ex As Exception
                ' Don't bother.
            End Try
        End If

        ' Set the object to nothing.
        obj_Client = Nothing

    End Sub

    Friend Sub OnConnected()
        ' We're not doing anything here since the client NEEDS to know which ID they have before they can contact the server for information.

        ' Set the label to connected.
        lbl_LoginStatus.Text = "Connected"
    End Sub

    Friend Sub OnPacketReceived(ByVal PacketType As Byte, ByVal Packet As String)
        ' Since our packet is encrypted, we should decrypt it before it all goes to hell.
        Packet = Crypto.Decrypt(Packet, CRYPTO_KEY)

        ' Pass on the data to the handler sub.
        HandleIncomingPacket(PacketType, Packet)
    End Sub

    Friend Sub OnDisconnected()
        If GetClientState() <> GameState.Closing Then
            ' Connection has been lost, possibly for unknown reasons.
            MsgBox("Your connection to the server has been lost! Please check your internet connection.", MsgBoxStyle.Information, "Connection Lost")
            DestroyGame()
        End If
    End Sub

    Public Sub SendData(ByVal PacketType As Byte, ByVal Packet As String)
        ' Add our SlotID to the packet before sending it off.
        Packet = var_MySlot.ToString + SEP_SYMBOL + Packet

        ' Encrypt our data before we send it off.
        Packet = Crypto.Encrypt(Packet, CRYPTO_KEY)

        ' Plain and simple really, nothing much to it.
        obj_Client.Send(PacketType, Packet)
    End Sub

    Public Sub SendRequestVersion()
        Dim Packet As String

        ' Nothing we need to add here, all we're doing is sending a request.
        Packet = ""

        ' Send it over!
        SendData(ClientPackets.RequestVersion, Packet)
    End Sub

    Public Sub SendRequestLogin(ByVal Username As String, ByVal Password As String)
        Dim Packet As String

        ' Encrypt the password to an MD5 hash
        Password = Crypto.StringMD5Hash(Password)

        ' Build our packet to send over to the server.
        Packet = Username + SEP_SYMBOL + Password

        ' Send over our data to the server.
        SendData(ClientPackets.RequestLogin, Packet)
    End Sub

    Public Sub SendRequestLogout()
        Dim Packet As String

        ' No need for packet data, so we'll send an empty one across.
        Packet = ""

        ' Send over our data.
        SendData(ClientPackets.RequestLogout, Packet)

    End Sub

    Public Sub SendRequestCreateChar()
        Dim Packet As String

        ' Add our character data to the packet.
        Packet = var_TempSlot.ToString + SEP_SYMBOL _
            + txt_Charname.Text.Trim

        ' Send over our data.
        SendData(ClientPackets.RequestCreateChar, Packet)

    End Sub

End Module
