Imports System.Net
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Enum

Public Class Form1

    'Servidor de dominio
    Inherits System.Windows.Forms.Form
    Dim RutaLocal, RutadeRED As String
    Dim Proceso As Integer


    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Static PrimeraVez As Boolean = True
        ' La primera vez que se active, ocultar el form,
        ' es una chapuza, pero el formulario no permite que se oculte en el Form_Load
        If PrimeraVez Then
            PrimeraVez = False
            Visible = False
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  

        Version = "1.9"
        NVersion.Text = "Ver: " & Version
        Proceso = 0
        Dim desktopSize As Size
        desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize
        Dim Alto As Integer = desktopSize.Height
        Dim Ancho As Integer = desktopSize.Width
        Dim Ancho_R, Alto_R As Integer
        Ancho_R = Ancho - Me.Width
        Alto_R = Alto - Me.Height * 2
        Me.Location = New Point(Ancho_R, Alto_R)


      

        ' Asignar los valores para el NotifyIcon
        With NotifyIcon1
            .Icon = Me.Icon
            .ContextMenu = Me.ContextMenu1
            .Text = Application.ProductName
            .Visible = True
        End With




        ruta = Application.StartupPath

        Dim freader As New StreamReader(ruta & "\Configuracion.AutoBACKUP")
        Dim contenido As String
        Dim lineas As New ArrayList()
        i = 0
        Do

            contenido = freader.ReadLine()
            If Not contenido Is Nothing Then

                'si quiero leer solo las líneas que no estén en blanco incluyo esta condicion
                If contenido.Length <> 0 Then
                    i = i + 1
                    If i = 1 Then
                        Carpeta_a_Respaldar = contenido
                    End If

                    If i = 2 Then
                        Servidor_Respaldo = contenido
                    End If
                End If
            End If
        Loop Until contenido Is Nothing
        freader.Close()


            If Servidor_Respaldo = "" Or Carpeta_a_Respaldar = "" Then
                Configuracion.Show()
                Exit Sub
            End If

        RutadeRED = Servidor_Respaldo
        RutaLocal = Carpeta_a_Respaldar


     
        If Directory.Exists(RutadeRED) And Directory.Exists(RutaLocal) Then
            fsw.Path = Carpeta_a_Respaldar
        Else
            Servidor_Respaldo = "Seleccione Servidor de Respaldo"
            Carpeta_a_Respaldar = "Seleccione la Carpe o directorio a respaldar"
            RutadeRED = ""
            RutaLocal = ""
            Configuracion.Show()
        End If
    


      






    End Sub


    Private Function FileCompare(ByVal file1 As String, ByVal file2 As String) As Boolean
        Try
            Dim file1byte As Integer
            Dim file2byte As Integer
            Dim fs1 As FileStream
            Dim fs2 As FileStream

            ' Determine if the same file was referenced two times.
            If (file1 = file2) Then
                ' Return 0 to indicate that the files are the same.
                Return True
            End If

            ' Open the two files.
            fs1 = New FileStream(file1, FileMode.Open)
            fs2 = New FileStream(file2, FileMode.Open)

            ' Check the file sizes. If they are not the same, the files
            ' are not equal.
            If (fs1.Length <> fs2.Length) Then
                ' Close the file
                fs1.Close()
                fs2.Close()

                ' Return a non-zero value to indicate that the files are different.
                Return False
            End If

            ' Read and compare a byte from each file until either a
            ' non-matching set of bytes is found or until the end of
            ' file1 is reached.
            Do
                ' Read one byte from each file.
                file1byte = fs1.ReadByte()
                file2byte = fs2.ReadByte()
            Loop While ((file1byte = file2byte) And (file1byte <> -1))

            ' Close the files.
            fs1.Close()
            fs2.Close()

            ' Return the success of the comparison. "file1byte" is
            ' equal to "file2byte" at this point only if the files are 
            ' the same.
            Return ((file1byte - file2byte) = 0)
        Catch oe As Exception

        End Try
    End Function




    Private Sub fsw_Created(sender As Object, e As FileSystemEventArgs) Handles fsw.Created
        Proceso = 1
        FunCioN = 2
        rutalarga_archivo = ""
        rutacorta_archivo = ""
        rutalarga_archivo = e.FullPath
        rutacorta_archivo = e.Name
        tipo_de_cambio = e.ChangeType
        Ejecutor.Enabled = True

    End Sub

    Private Sub fsw_Changed(sender As Object, e As FileSystemEventArgs) Handles fsw.Changed
        If Proceso = 0 Then
            FunCioN = 1
        End If
        rutalarga_archivo = ""
        rutacorta_archivo = ""
        rutalarga_archivo = e.FullPath
        rutacorta_archivo = e.Name
        tipo_de_cambio = e.ChangeType
        Ejecutor.Enabled = True

    End Sub
    Private Sub fsw_Deleted(sender As Object, e As FileSystemEventArgs) Handles fsw.Deleted
        Proceso = 3
        FunCioN = 3
        rutalarga_archivo = ""
        rutacorta_archivo = ""
        rutalarga_archivo = e.FullPath
        rutacorta_archivo = e.Name
        tipo_de_cambio = e.ChangeType
        Ejecutor.Enabled = True
        
    End Sub

    Private Sub fsw_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles fsw.Renamed

        Proceso = 2
        FunCioN = 4
        rutalarga_archivo = ""
        rutacorta_archivo = ""
        Nombre_Archivo_Viejo = e.OldName
        Nombre_Archivo_Nuevo = e.Name
        tipo_de_cambio = e.ChangeType
        Ejecutor.Enabled = True

    End Sub


    Private Sub mncAcercaDe_Click(sender As Object, e As EventArgs) Handles mncAcercaDe.Click
        MessageBox.Show("AutoBACKUP: " & " Ver: " & Version & vbCrLf & "Tipo de Licencia [" & DEMO.Text & "]: Gamma Quimica de Venezuela, C.A" & vbCrLf & "Desarrollado por: AC, SYSTEMS C.A" & vbCrLf & "www.acsystemsca.com", "AutoBACKUP Ver:" & Version, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

   
    Private Sub mncSalir_Click(sender As Object, e As EventArgs) Handles mncSalir.Click
        Dim result1 As DialogResult = MessageBox.Show("¿Desea salir del AutoBACKUP?", _
                            "AutoBACKUP   Version: " & Version, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If result1 = DialogResult.Yes Then
            End
        End If

    End Sub

    Private Sub mncRestaurar_Click(sender As Object, e As EventArgs) Handles mncConfigurar.Click
        Configuracion.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Directory.Exists(Servidor_Respaldo) And Directory.Exists(Carpeta_a_Respaldar) Then
            msg.ForeColor = Color.Black
            msg.Text = "Monitoreando.."
            Timer1.Enabled = False

        Else

            msg.Text = "FALTA CONFIGURACION.."
            msg.ForeColor = Color.Red
            Timer1.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If l.Visible = True And Timer1.Enabled = False Then
            l.Visible = False
            Proceso = 0
            Exit Sub
        Else
            If l.Visible = False And Timer1.Enabled = False Then
                l.Visible = True
                Proceso = 0
                Exit Sub
            End If

        End If
    End Sub

    Private Sub Ejecutor_Tick(sender As Object, e As EventArgs) Handles Ejecutor.Tick

        If FunCioN = 1 Then 'CAMBIO

            Dim Archivo, Archivo2 As String
            Archivo = rutacorta_archivo
            Archivo2 = rutalarga_archivo
            FS_EVENTO.Items.Clear()
            FS_EVENTO.Items.Add(Archivo2 & "  --->CAMBIADO   " & tipo_de_cambio)

            Dim string1, string2, string3 As String
            string1 = Path.GetFileName(rutacorta_archivo)
            string2 = string1.Substring(0, 2)
            string3 = string1.Substring(0, 1)

            If string2 = "~$" Or string3 = "~" Or string3 = "$" Then
                Proceso = 0
                Ejecutor.Enabled = False
                Timer1.Enabled = True
                Exit Sub
            End If



            If File.Exists(RutadeRED & Archivo) Then
                Try

                    If FileCompare(RutaLocal & Archivo, RutadeRED & Archivo) Then 'Archivos sin cambios
                    Else
                        'Archivos con cambios
                        My.Computer.FileSystem.CopyFile(Archivo2, RutadeRED & Archivo, True)
                        msg.Text = Path.GetFileName(Archivo) & " actualizado.."
                        Ejecutor.Enabled = False
                        Timer1.Enabled = True
                        Proceso = 0
                        Exit Sub
                    End If
                Catch oe As Exception
                    Proceso = 0
                    GoTo RAY3
                    Exit Sub
                End Try
            Else

              
                    Try

                        My.Computer.FileSystem.CopyFile(Archivo2, RutadeRED & Archivo, True)
                        msg.Text = Path.GetFileName(Archivo) & " actualizado.."
                        Ejecutor.Enabled = False
                        Timer1.Enabled = True
                        Proceso = 0
                        Exit Sub

                    Catch oe As Exception
                        Proceso = 0
                        GoTo RAY3
                        Exit Sub
                    End Try





                End If



RAY3:       'Revisa si la carpeta Existe
            If Directory.Exists(RutadeRED & Archivo) Then
            Else
                Try

                    My.Computer.FileSystem.CopyDirectory(Archivo2, RutadeRED & Archivo, True)


                    msg.Text = Path.GetFileName(Archivo) & " actualizado.."
                    Ejecutor.Enabled = False
                    Timer1.Enabled = True
                    Proceso = 0
                    Exit Sub

                Catch oe As Exception
                End Try


            End If


        End If






            If FunCioN = 2 Then 'CREADO

                Dim string1, string2, string3, Archivo, Archivo2 As String
                FS_EVENTO.Items.Clear()
                FS_EVENTO.Items.Add(rutalarga_archivo & "  --->CREADO")

                Archivo = rutacorta_archivo
                Archivo2 = rutalarga_archivo

                string1 = Path.GetFileName(rutacorta_archivo)
                string2 = string1.Substring(0, 2)
                string3 = string1.Substring(0, 1)

            If string2 = "~$" Then
                Ejecutor.Enabled = False
                Timer1.Enabled = True
                Exit Sub
            End If

            If string2 = "~" Then
                Ejecutor.Enabled = False
                Timer1.Enabled = True
                Exit Sub
            End If

            If string3 = "$" Then
                Ejecutor.Enabled = False
                Timer1.Enabled = True
                Exit Sub
            End If





RAY1:

            If File.Exists(RutadeRED & Archivo) Then
                Try
                    My.Computer.FileSystem.CopyFile(Archivo2, RutadeRED & Archivo, True)
                    msg.Text = Path.GetFileName(Archivo) & " actualizado.."
                    Ejecutor.Enabled = False
                    Timer1.Enabled = True
                    GoTo RAY2
                    Exit Sub

                Catch oe As Exception

                End Try
            Else
                If File.Exists(RutadeRED & Archivo) Then
                    Try
                        My.Computer.FileSystem.CopyFile(Archivo2, RutadeRED & Archivo, True)
                        msg.Text = Path.GetFileName(Archivo) & " actualizado.."
                        Ejecutor.Enabled = False
                        Timer1.Enabled = True
                        GoTo RAY2
                        Exit Sub
                    Catch oe As Exception

                    End Try
                End If
            End If


RAY2:
            msg.Text = Path.GetFileName(Archivo) & " actualizado.."
            My.Computer.FileSystem.CopyDirectory(Replace(Archivo2, Path.GetFileName(Archivo), ""), RutadeRED & Replace(Archivo, Path.GetFileName(Archivo), ""), True)
            Ejecutor.Enabled = False
            Timer1.Enabled = True
            Exit Sub
  

        End If






            If FunCioN = 3 Then 'ELIMINAR

                FS_EVENTO.Items.Clear()
                FS_EVENTO.Items.Add(rutalarga_archivo & "  --->ELIMINADO")

                If Directory.Exists(RutadeRED & rutacorta_archivo) Then
                    My.Computer.FileSystem.DeleteDirectory(RutadeRED & rutacorta_archivo, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    msg.Text = Path.GetFileName(rutacorta_archivo) & " actualizado.."
                    Ejecutor.Enabled = False
                    Timer1.Enabled = True
                    Exit Sub
                End If


                If File.Exists(RutadeRED & rutacorta_archivo) Then
                    My.Computer.FileSystem.DeleteFile(RutadeRED & rutacorta_archivo)
                    msg.Text = Path.GetFileName(rutacorta_archivo) & " actualizado.."
                    Ejecutor.Enabled = False
                    Timer1.Enabled = True
                    Exit Sub
                End If



            End If







            If FunCioN = 4 Then 'RENOMBRAR

                FS_EVENTO.Items.Clear()
                FS_EVENTO.Items.Add(Nombre_Archivo_Viejo & "  --->RENOMBRADO POR: ---> " & Nombre_Archivo_Nuevo)

                If Directory.Exists(RutadeRED & Nombre_Archivo_Viejo) Then

                    My.Computer.FileSystem.RenameDirectory(RutadeRED & Nombre_Archivo_Viejo, Path.GetFileName(Nombre_Archivo_Nuevo))
                    msg.Text = Nombre_Archivo_Nuevo & " actualizado.."
                    Ejecutor.Enabled = False
                    Timer1.Enabled = True
                    Exit Sub

                Else

                    If File.Exists(RutadeRED & Nombre_Archivo_Viejo) Then
                        My.Computer.FileSystem.RenameFile(RutadeRED & Nombre_Archivo_Viejo, Path.GetFileName(Nombre_Archivo_Nuevo))
                        msg.Text = Nombre_Archivo_Nuevo & " actualizado.."
                        Ejecutor.Enabled = False
                        Timer1.Enabled = True
                        Exit Sub
                    Else
                        Ejecutor.Enabled = False
                        Timer1.Enabled = True
                        Exit Sub
                    End If
                End If



            End If



    End Sub



    Private Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        'Respalda SAGE
        Dim FileCount As Integer = 0
        CountFiles("C:\Users\Mama_pc\Documents\RAY\SAGE\DESARROLLO", FileCount)
        My.Computer.FileSystem.CopyDirectory("C:\Users\Mama_pc\Documents\RAY\SAGE\DESARROLLO", "\\FACTURACION\servidor_respaldo\Sistema_Facturacion_RF\SAGE", True)
        MessageBox.Show("SAGE Respaldado, copiados [" & FileCount.ToString & "] archivos", "AutoBACKUP Ver:" & Version, MessageBoxButtons.OK, MessageBoxIcon.Information)

        'C:\Users\RAY@HOME\Desktop
    End Sub




    Private Sub MenuItem3_Click(sender As Object, e As EventArgs) Handles MenuItem3.Click
        'Respalda FACTRONIC
        Dim FileCount As Integer = 0
        CountFiles("C:\Users\Mama_pc\Documents\RAY\SAGE\Factronic", FileCount)
        My.Computer.FileSystem.CopyDirectory("C:\Users\Mama_pc\Documents\RAY\SAGE\Factronic", "\\FACTURACION\servidor_respaldo\Sistema_Facturacion_RF\Factronic", True)
        MessageBox.Show("FACTRONIC Respaldado, copiados [" & FileCount.ToString & "] archivos", "AutoBACKUP Ver:" & Version, MessageBoxButtons.OK, MessageBoxIcon.Information)

      
    End Sub






End Class
