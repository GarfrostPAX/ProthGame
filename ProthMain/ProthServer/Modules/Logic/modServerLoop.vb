Imports System.Threading

Module modServerLoop

    ' Timer Variables used throughout the sub.
    Private var_Timer As Integer

    Public Sub ServerLoop()
        Dim i As Integer
        Dim var_Timer1second As Integer, var_Timer5minute As Integer

        ' Keep the loop running as long as the server is running. This will end once the server object is no longer active.
        Do While obj_Server.ServerRunning

            ' Start of the loop, time to set the new timer.
            var_Timer = System.Environment.TickCount

            ' Check all our timers and make sure we act accordingly.

            ' Our lovely one second timer.
            If var_Timer1second <= var_Timer Then


                ' Set our timer to go off one second into the future.
                var_Timer1second = var_Timer + 1000
            End If

            ' Our 5 minute timer.
            If var_Timer5minute <= var_Timer Then

                ' Debug Info
                WriteToConsole("Saving online players..")

                ' if there's at least one player online, start saving them!
                If var_PlayerHighIndex > 0 Then
                    ' Loop through all the online players.
                    For i = 1 To var_PlayerHighIndex
                        SavePlayer(i)
                    Next
                End If

                ' Set our timer 5 minutes into the future again.
                var_Timer5minute = var_Timer + 300000
            End If

            ' We don't want to overburden the system's CPU, so let's keep the thread asleep for 1ms every cycle.
            ' That is, if the options allow us to.
            If obj_Options.CapCPS = 1 Then Thread.Sleep(1)
        Loop

    End Sub

End Module
