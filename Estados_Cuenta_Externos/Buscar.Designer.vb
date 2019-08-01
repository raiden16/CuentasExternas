<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Buscar
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
        Me.Banco2 = New System.Windows.Forms.ComboBox()
        Me.BancoText2 = New System.Windows.Forms.Label()
        Me.BancoImage2 = New System.Windows.Forms.PictureBox()
        Me.Buscar2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.BancoImage2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Banco2
        '
        Me.Banco2.FormattingEnabled = True
        Me.Banco2.Location = New System.Drawing.Point(12, 58)
        Me.Banco2.Name = "Banco2"
        Me.Banco2.Size = New System.Drawing.Size(121, 21)
        Me.Banco2.TabIndex = 0
        '
        'BancoText2
        '
        Me.BancoText2.AutoSize = True
        Me.BancoText2.Location = New System.Drawing.Point(142, 61)
        Me.BancoText2.Name = "BancoText2"
        Me.BancoText2.Size = New System.Drawing.Size(52, 13)
        Me.BancoText2.TabIndex = 1
        Me.BancoText2.Text = "               "
        '
        'BancoImage2
        '
        Me.BancoImage2.Location = New System.Drawing.Point(381, 12)
        Me.BancoImage2.Name = "BancoImage2"
        Me.BancoImage2.Size = New System.Drawing.Size(204, 105)
        Me.BancoImage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BancoImage2.TabIndex = 2
        Me.BancoImage2.TabStop = False
        '
        'Buscar2
        '
        Me.Buscar2.BackColor = System.Drawing.Color.Khaki
        Me.Buscar2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buscar2.Location = New System.Drawing.Point(782, 51)
        Me.Buscar2.Name = "Buscar2"
        Me.Buscar2.Size = New System.Drawing.Size(122, 30)
        Me.Buscar2.TabIndex = 4
        Me.Buscar2.Text = "Buscar"
        Me.Buscar2.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 140)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(986, 510)
        Me.DataGridView1.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Cuenta de Mayor"
        '
        'Buscar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1010, 662)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Buscar2)
        Me.Controls.Add(Me.BancoImage2)
        Me.Controls.Add(Me.BancoText2)
        Me.Controls.Add(Me.Banco2)
        Me.MaximizeBox = False
        Me.Name = "Buscar"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Buscar"
        CType(Me.BancoImage2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Banco2 As ComboBox
    Friend WithEvents BancoText2 As Label
    Friend WithEvents BancoImage2 As PictureBox
    Friend WithEvents Buscar2 As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
End Class
