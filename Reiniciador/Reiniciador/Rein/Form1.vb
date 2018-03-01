Public Class Form1



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        p.Value = p.Value + 10
        Try
            If p.Value = 100 Then
                Timer1.Enabled = False

                Dim startInfo As System.Diagnostics.ProcessStartInfo
                Dim pStart As New System.Diagnostics.Process
                startInfo = New System.Diagnostics.ProcessStartInfo(Application.StartupPath & "\AutoBackup.exe")
                pStart.StartInfo = startInfo
                pStart.Start()

                End
            Else

            End If
        Catch
            End
        End Try
    End Sub
End Class
