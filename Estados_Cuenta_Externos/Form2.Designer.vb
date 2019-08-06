<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Agregar = New System.Windows.Forms.Button()
        Me.Banco = New System.Windows.Forms.ComboBox()
        Me.BancoText = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Actualizar = New System.Windows.Forms.Button()
        Me.Calendario = New System.Windows.Forms.DateTimePicker()
        Me.Fecha = New System.Windows.Forms.Label()
        Me.BancoImage = New System.Windows.Forms.PictureBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Lista1 = New System.Windows.Forms.ListBox()
        CType(Me.BancoImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Agregar
        '
        Me.Agregar.BackColor = System.Drawing.Color.Khaki
        Me.Agregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Agregar.Location = New System.Drawing.Point(12, 616)
        Me.Agregar.Name = "Agregar"
        Me.Agregar.Size = New System.Drawing.Size(121, 31)
        Me.Agregar.TabIndex = 4
        Me.Agregar.Text = "Agregar"
        Me.Agregar.UseVisualStyleBackColor = False
        '
        'Banco
        '
        Me.Banco.FormattingEnabled = True
        Me.Banco.Location = New System.Drawing.Point(12, 58)
        Me.Banco.Name = "Banco"
        Me.Banco.Size = New System.Drawing.Size(121, 21)
        Me.Banco.TabIndex = 0
        '
        'BancoText
        '
        Me.BancoText.AutoSize = True
        Me.BancoText.Location = New System.Drawing.Point(139, 64)
        Me.BancoText.Name = "BancoText"
        Me.BancoText.Size = New System.Drawing.Size(52, 13)
        Me.BancoText.TabIndex = 12
        Me.BancoText.Text = "               "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Cuenta de Mayor"
        '
        'Actualizar
        '
        Me.Actualizar.BackColor = System.Drawing.Color.Khaki
        Me.Actualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Actualizar.Location = New System.Drawing.Point(855, 616)
        Me.Actualizar.Name = "Actualizar"
        Me.Actualizar.Size = New System.Drawing.Size(123, 31)
        Me.Actualizar.TabIndex = 5
        Me.Actualizar.Text = "Actualizar"
        Me.Actualizar.UseVisualStyleBackColor = False
        '
        'Calendario
        '
        Me.Calendario.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Calendario.Location = New System.Drawing.Point(729, 58)
        Me.Calendario.Name = "Calendario"
        Me.Calendario.Size = New System.Drawing.Size(98, 20)
        Me.Calendario.TabIndex = 1
        '
        'Fecha
        '
        Me.Fecha.AutoSize = True
        Me.Fecha.Location = New System.Drawing.Point(760, 42)
        Me.Fecha.Name = "Fecha"
        Me.Fecha.Size = New System.Drawing.Size(37, 13)
        Me.Fecha.TabIndex = 13
        Me.Fecha.Text = "Fecha"
        '
        'BancoImage
        '
        Me.BancoImage.InitialImage = Nothing
        Me.BancoImage.Location = New System.Drawing.Point(387, 12)
        Me.BancoImage.Name = "BancoImage"
        Me.BancoImage.Size = New System.Drawing.Size(206, 103)
        Me.BancoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BancoImage.TabIndex = 21
        Me.BancoImage.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 134)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(966, 476)
        Me.DataGridView1.TabIndex = 2
        '
        'Lista1
        '
        Me.Lista1.FormattingEnabled = True
        Me.Lista1.Location = New System.Drawing.Point(155, 346)
        Me.Lista1.Name = "Lista1"
        Me.Lista1.Size = New System.Drawing.Size(120, 147)
        Me.Lista1.TabIndex = 3
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(990, 659)
        Me.Controls.Add(Me.Lista1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.BancoImage)
        Me.Controls.Add(Me.Fecha)
        Me.Controls.Add(Me.Calendario)
        Me.Controls.Add(Me.Actualizar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BancoText)
        Me.Controls.Add(Me.Banco)
        Me.Controls.Add(Me.Agregar)
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tratar estados de cuentas externos"
        CType(Me.BancoImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Referencia As ComboBox
    Friend WithEvents Debito As TextBox
    Friend WithEvents Credito As TextBox
    Friend WithEvents Documento As TextBox
    Friend WithEvents Agregar As Button
    Friend WithEvents Banco As ComboBox
    Friend WithEvents BancoText As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Actualizar As Button
    Friend WithEvents Codigo As TextBox
    Friend WithEvents Calendario As DateTimePicker
    Friend WithEvents Fecha As Label
    Friend WithEvents Descripcion As TextBox
    Friend WithEvents BancoImage As PictureBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Lista1 As ListBox
End Class
