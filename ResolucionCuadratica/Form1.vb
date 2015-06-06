Public Class Form1
    Private Sub FrmCuadratica_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CmdCalcular_Click(sender As System.Object, e As System.EventArgs) Handles CmdCalcular.Click
        Dim c As New cCuadratica
        If TxtTCuadratico.Text = "" OrElse Not IsNumeric(TxtTCuadratico.Text) OrElse Val(TxtTCuadratico.Text) = 0 Then
            MsgBox("La ecuacion especificada no es cuadratica", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Snoopy")
            Exit Sub
        End If

        pGrafica.Width = Me.Width - pGrafica.Left
        pGrafica.Height = Me.Height - pGrafica.Top

        c.T_Cuadratico = Convert.ToDouble(TxtTCuadratico.Text)

        If Not Double.TryParse(TxtTLineal.Text, c.T_Lineal) Then c.T_Lineal = 0
        If Not Double.TryParse(TxtTIndependiente.Text, c.T_Independiente) Then c.T_Independiente = 0
        c.Calcular()

        TxtResultado.Text = "Tipo de raices:"
        If c.TipoRaices = cCuadratica.QUAD_TIPO_RAIZ.COMPLEJAS_CONJUGADAS Then
            TxtResultado.Text &= "Complejas y conjugadas"
        ElseIf c.TipoRaices = cCuadratica.QUAD_TIPO_RAIZ.REALES_DISTINTAS Then
            TxtResultado.Text &= "Reales y Distintas"
        Else
            TxtResultado.Text &= "Multiples"
        End If

        TxtResultado.Text &= vbCrLf & "Ceros de la funcion:" & vbCrLf
        TxtResultado.Text &= "x1 = " & c.Raices(0).ToString & vbCrLf
        TxtResultado.Text &= "x2 = " & c.Raices(1).ToString & vbCrLf
        TxtResultado.Text &= "Eje de simetria: " & c.EjeSimetria & vbCrLf
        TxtResultado.Text &= "Extremo: " & c.Extremo & vbCrLf
        TxtResultado.Text &= "Ordenada al origen: " & c.T_Independiente

        pGrafica.Image = c.Grafica(True, pGrafica.Width, pGrafica.Height)
    End Sub
End Class
