<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.msg = New System.Windows.Forms.Label()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu()
        Me.mncConfigurar = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mncAcercaDe = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.mncSalir = New System.Windows.Forms.MenuItem()
        Me.fsw = New System.IO.FileSystemWatcher()
        Me.FS_EVENTO = New System.Windows.Forms.ListBox()
        Me.DEMO = New System.Windows.Forms.Label()
        Me.NVersion = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.l = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Ejecutor = New System.Windows.Forms.Timer(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fsw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.ErrorImage = Nothing
        Me.pb.Image = CType(resources.GetObject("pb.Image"), System.Drawing.Image)
        Me.pb.InitialImage = Nothing
        Me.pb.Location = New System.Drawing.Point(-11, -2)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(82, 35)
        Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pb.TabIndex = 4
        Me.pb.TabStop = False
        '
        'msg
        '
        Me.msg.AutoSize = True
        Me.msg.BackColor = System.Drawing.Color.Transparent
        Me.msg.Location = New System.Drawing.Point(59, 15)
        Me.msg.Name = "msg"
        Me.msg.Size = New System.Drawing.Size(78, 13)
        Me.msg.TabIndex = 5
        Me.msg.Text = "Monitoreando.."
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mncConfigurar, Me.MenuItem2, Me.MenuItem3, Me.MenuItem1, Me.mncAcercaDe, Me.MenuItem5, Me.mncSalir})
        '
        'mncConfigurar
        '
        Me.mncConfigurar.DefaultItem = True
        Me.mncConfigurar.Index = 0
        Me.mncConfigurar.Text = "&Configurar"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'mncAcercaDe
        '
        Me.mncAcercaDe.Index = 4
        Me.mncAcercaDe.Text = "&Acerca de..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 5
        Me.MenuItem5.Text = "-"
        '
        'mncSalir
        '
        Me.mncSalir.Index = 6
        Me.mncSalir.Text = "&Salir"
        '
        'fsw
        '
        Me.fsw.EnableRaisingEvents = True
        Me.fsw.IncludeSubdirectories = True
        Me.fsw.NotifyFilter = CType((((((System.IO.NotifyFilters.FileName Or System.IO.NotifyFilters.DirectoryName) _
            Or System.IO.NotifyFilters.Attributes) _
            Or System.IO.NotifyFilters.Size) _
            Or System.IO.NotifyFilters.CreationTime) _
            Or System.IO.NotifyFilters.Security), System.IO.NotifyFilters)
        Me.fsw.SynchronizingObject = Me
        '
        'FS_EVENTO
        '
        Me.FS_EVENTO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FS_EVENTO.FormattingEnabled = True
        Me.FS_EVENTO.ItemHeight = 12
        Me.FS_EVENTO.Location = New System.Drawing.Point(6, 43)
        Me.FS_EVENTO.Name = "FS_EVENTO"
        Me.FS_EVENTO.Size = New System.Drawing.Size(774, 16)
        Me.FS_EVENTO.Sorted = True
        Me.FS_EVENTO.TabIndex = 12
        '
        'DEMO
        '
        Me.DEMO.AutoSize = True
        Me.DEMO.BackColor = System.Drawing.Color.Transparent
        Me.DEMO.ForeColor = System.Drawing.Color.Red
        Me.DEMO.Location = New System.Drawing.Point(145, 0)
        Me.DEMO.Name = "DEMO"
        Me.DEMO.Size = New System.Drawing.Size(39, 13)
        Me.DEMO.TabIndex = 13
        Me.DEMO.Text = "DEMO"
        '
        'NVersion
        '
        Me.NVersion.AutoSize = True
        Me.NVersion.BackColor = System.Drawing.Color.Transparent
        Me.NVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NVersion.ForeColor = System.Drawing.Color.Red
        Me.NVersion.Location = New System.Drawing.Point(57, 0)
        Me.NVersion.Name = "NVersion"
        Me.NVersion.Size = New System.Drawing.Size(29, 13)
        Me.NVersion.TabIndex = 14
        Me.NVersion.Text = "Ver: "
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'l
        '
        Me.l.AutoSize = True
        Me.l.BackColor = System.Drawing.Color.Transparent
        Me.l.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.l.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.l.ForeColor = System.Drawing.Color.Red
        Me.l.Location = New System.Drawing.Point(-5, -3)
        Me.l.Name = "l"
        Me.l.Size = New System.Drawing.Size(13, 9)
        Me.l.TabIndex = 15
        Me.l.Text = "■"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 700
        '
        'Ejecutor
        '
        Me.Ejecutor.Interval = 150
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 3
        Me.MenuItem1.Text = "Respaldar: SAGE"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Respaldar: FACTRONIC"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(195, 31)
        Me.ControlBox = False
        Me.Controls.Add(Me.NVersion)
        Me.Controls.Add(Me.msg)
        Me.Controls.Add(Me.l)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.DEMO)
        Me.Controls.Add(Me.FS_EVENTO)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Opacity = 0.5R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fsw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents msg As System.Windows.Forms.Label
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents mncConfigurar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mncAcercaDe As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mncSalir As System.Windows.Forms.MenuItem
    Friend WithEvents FS_EVENTO As System.Windows.Forms.ListBox
    Friend WithEvents DEMO As System.Windows.Forms.Label
    Friend WithEvents NVersion As System.Windows.Forms.Label
    Public WithEvents fsw As System.IO.FileSystemWatcher
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents l As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Ejecutor As System.Windows.Forms.Timer
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem

End Class
