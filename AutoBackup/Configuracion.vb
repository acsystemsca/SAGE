Imports System.IO

Public Class Configuracion

    Dim a As Integer

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim objStreamWriter As StreamWriter = Nothing
        objStreamWriter = New StreamWriter(ruta & "\Configuracion.AutoBACKUP")
        objStreamWriter.WriteLine(Carpeta_a_Respaldar)
        objStreamWriter.WriteLine(Servidor_Respaldo)
        objStreamWriter.Close()


        MessageBox.Show("Configuracion aplicada", "AutoBACKUP Ver:" & Version, MessageBoxButtons.OK, MessageBoxIcon.Information)


        Dim startInfo As System.Diagnostics.ProcessStartInfo
        Dim pStart As New System.Diagnostics.Process
        startInfo = New System.Diagnostics.ProcessStartInfo(ruta & "\Rein.exe")
        pStart.StartInfo = startInfo
        pStart.Start()
        End




    End Sub

    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        a = 0

        If Servidor_Respaldo <> "" And Carpeta_a_Respaldar <> "" Then
            Servidor.Text = Servidor_Respaldo
            carpetaarespaldar.Text = Carpeta_a_Respaldar
        End If



    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim string2, string1, string3 As String
            string1 = FolderBrowserDialog1.SelectedPath
            string2 = string1.Substring(string1.Length - 1, 1)
            If string2 = "/" Or string2 = "\" Then
                string3 = string1.Substring(0, string1.Length - 1)
            Else
                string3 = string1
            End If
            carpetaarespaldar.Text = string3 & "\"
            Carpeta_a_Respaldar = string3 & "\"
            If Servidor.Text <> "Seleccione Servidor de Respaldo" And carpetaarespaldar.Text <> "Seleccione la Carpe o directorio a respaldar" Then
                Button2.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            Dim string2, string1, string3 As String
            string1 = FolderBrowserDialog1.SelectedPath
            string2 = string1.Substring(string1.Length - 1, 1)
            If string2 = "/" Or string2 = "\" Then
                string3 = string1.Substring(0, string1.Length - 1)
            Else
                string3 = string1
            End If

            Servidor.Text = string3 & "\"
            Servidor_Respaldo = string3 & "\"

            If Servidor.Text <> "Seleccione Servidor de Respaldo" And carpetaarespaldar.Text <> "Seleccione la Carpe o directorio a respaldar" Then
                Button2.Enabled = True
            End If
        End If
    End Sub
End Class