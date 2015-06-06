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
        Me.pGrafica = New System.Windows.Forms.PictureBox()
        Me.CmdSalir = New System.Windows.Forms.Button()
        Me.CmdCalcular = New System.Windows.Forms.Button()
        Me.TxtResultado = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTIndependiente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtTLineal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtTCuadratico = New System.Windows.Forms.TextBox()
        CType(Me.pGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pGrafica
        '
        Me.pGrafica.Location = New System.Drawing.Point(253, 10)
        Me.pGrafica.Name = "pGrafica"
        Me.pGrafica.Size = New System.Drawing.Size(631, 498)
        Me.pGrafica.TabIndex = 20
        Me.pGrafica.TabStop = False
        '
        'CmdSalir
        '
        Me.CmdSalir.Location = New System.Drawing.Point(158, 171)
        Me.CmdSalir.Name = "CmdSalir"
        Me.CmdSalir.Size = New System.Drawing.Size(75, 23)
        Me.CmdSalir.TabIndex = 19
        Me.CmdSalir.Text = "Salir"
        Me.CmdSalir.UseVisualStyleBackColor = True
        '
        'CmdCalcular
        '
        Me.CmdCalcular.Location = New System.Drawing.Point(77, 171)
        Me.CmdCalcular.Name = "CmdCalcular"
        Me.CmdCalcular.Size = New System.Drawing.Size(75, 23)
        Me.CmdCalcular.TabIndex = 18
        Me.CmdCalcular.Text = "Calcular"
        Me.CmdCalcular.UseVisualStyleBackColor = True
        '
        'TxtResultado
        '
        Me.TxtResultado.Enabled = False
        Me.TxtResultado.Location = New System.Drawing.Point(12, 45)
        Me.TxtResultado.Multiline = True
        Me.TxtResultado.Name = "TxtResultado"
        Me.TxtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TxtResultado.Size = New System.Drawing.Size(221, 120)
        Me.TxtResultado.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(211, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "= 0"
        '
        'TxtTIndependiente
        '
        Me.TxtTIndependiente.Location = New System.Drawing.Point(167, 10)
        Me.TxtTIndependiente.Name = "TxtTIndependiente"
        Me.TxtTIndependiente.Size = New System.Drawing.Size(38, 20)
        Me.TxtTIndependiente.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(140, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "x +"
        '
        'TxtTLineal
        '
        Me.TxtTLineal.Location = New System.Drawing.Point(96, 10)
        Me.TxtTLineal.Name = "TxtTLineal"
        Me.TxtTLineal.Size = New System.Drawing.Size(38, 20)
        Me.TxtTLineal.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "x^2 +"
        '
        'TxtTCuadratico
        '
        Me.TxtTCuadratico.Location = New System.Drawing.Point(12, 10)
        Me.TxtTCuadratico.Name = "TxtTCuadratico"
        Me.TxtTCuadratico.Size = New System.Drawing.Size(38, 20)
        Me.TxtTCuadratico.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 564)
        Me.Controls.Add(Me.pGrafica)
        Me.Controls.Add(Me.CmdSalir)
        Me.Controls.Add(Me.CmdCalcular)
        Me.Controls.Add(Me.TxtResultado)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTIndependiente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTLineal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtTCuadratico)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pGrafica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pGrafica As System.Windows.Forms.PictureBox
    Friend WithEvents CmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdCalcular As System.Windows.Forms.Button
    Friend WithEvents TxtResultado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtTIndependiente As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTLineal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtTCuadratico As System.Windows.Forms.TextBox

End Class
