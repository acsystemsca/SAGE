Module Variables
    Public i, ii, FunCioN As Integer

    Public Version, Servidor_Respaldo, Carpeta_a_Respaldar, ruta, rutalarga_archivo, rutacorta_archivo, tipo_de_cambio, Nombre_Archivo_Viejo, Nombre_Archivo_Nuevo As String






    Public Sub CountFiles(InFolder As String, ByRef Result As Integer)
        Result += IO.Directory.GetFiles(InFolder).Count
        For Each f As String In IO.Directory.GetDirectories(InFolder)
            CountFiles(f, Result)
        Next
    End Sub









End Module
