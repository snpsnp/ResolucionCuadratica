Public Class cCuadratica
    Public Enum QUAD_TIPO_RAIZ
        REALES_DISTINTAS = 0
        REALES_IGUALES
        COMPLEJAS_CONJUGADAS
    End Enum

    Public Event [Error](ByVal szDesc As String)

    Private Const INTERVALO As Integer = 70

    Private tLineal As Double, tCuadratico As Double, tIndependiente As Double
    Private m_Cero1 As Object, m_Cero2 As Object
    Private m_EjeSimetria As Double

    Private m_discriminante As Double
    Private m_ExtremoRelativo As Double

    Public Sub New()
        'POR DEFECTO INICIALIZAMOS CON LA IDENTIDAD A*X^2
        Me.tCuadratico = 1 : Me.tLineal = 0 : Me.tIndependiente = 0
        'INICIALIZAMOS LOS OBJETOS NECESARIOS
        Me.m_Cero1 = New Object
        Me.m_Cero2 = New Object
    End Sub

    Public Sub New(ByVal tCuadratico As Double, ByVal tLineal As Double, ByVal tIndependiente As Double, ByVal bCalcula As Boolean)
        If tCuadratico = 0 Then
            'NO ES UNA ECUACION CUADRATICA
            RaiseEvent Error("La ecuacion no es cuadratica")
            Exit Sub
        End If

        'INICIALIZAMOS LOS OBJETOS NECESARIOS
        Me.m_Cero1 = New Object
        Me.m_Cero2 = New Object

        Me.tCuadratico = tCuadratico
        Me.tLineal = tLineal
        Me.tIndependiente = tIndependiente
        If bCalcula Then
            Me.Calcular()
        End If
    End Sub

    Public Property T_Cuadratico() As Double
        Get
            Return Me.tCuadratico
        End Get
        Set(value As Double)
            If value <> 0 Then Me.tCuadratico = value
        End Set
    End Property

    Public Property T_Lineal() As Double
        Get
            Return Me.tLineal
        End Get
        Set(value As Double)
            Me.tLineal = value
        End Set
    End Property

    Public Property T_Independiente() As Double
        Get
            Return Me.tIndependiente
        End Get
        Set(value As Double)
            Me.tIndependiente = value
        End Set
    End Property

    Public ReadOnly Property Discriminante() As Double
        Get
            Return Me.m_discriminante
        End Get
    End Property

    Public ReadOnly Property TipoRaices() As QUAD_TIPO_RAIZ
        Get
            If Me.m_discriminante > 0 Then
                Return QUAD_TIPO_RAIZ.REALES_DISTINTAS
            ElseIf Me.m_discriminante = 0 Then
                Return QUAD_TIPO_RAIZ.REALES_IGUALES
            Else
                Return QUAD_TIPO_RAIZ.COMPLEJAS_CONJUGADAS
            End If
        End Get
    End Property

    Public ReadOnly Property Raices() As Object()
        Get
            Return New Object() {Me.m_Cero1, Me.m_Cero2}
        End Get
    End Property

    Public ReadOnly Property EjeSimetria() As Double
        Get
            Return Me.m_EjeSimetria
        End Get
    End Property

    Public ReadOnly Property Extremo() As Double
        Get
            Return Me.m_ExtremoRelativo
        End Get
    End Property

    Public Sub Calcular()
        If Me.tCuadratico = 0 Then
            'NUEVAMENTE NO ES CUADRATICA
            RaiseEvent Error("La ecuacion no es cuadratica")
            Exit Sub
        End If

        'DETERMINAMOS EJE DE SIMETRIA
        Me.m_EjeSimetria = ((-1) * Me.tLineal) / (2 * Me.tCuadratico)

        'DETERMINAMOS EL MINIMO (O MAXIMO)
        'RECUERDEN QUE LA ORDENADA ESTARA DADA POR HALLAR LA IMAGEN
        'DE LA FUNCION EN EL PUNTO DEL DOMINIO CORRESPONDIENTE AL EJE DE SIMETRIA
        'TAMBIEN RECUERDEN QUE LA CORDENADA X DEL EXTREMO YA FUE DADA POR EL EJE DE SIMETRIA
        Me.m_ExtremoRelativo = (Me.tCuadratico * Math.Pow(Me.m_EjeSimetria, 2)) + (Me.tLineal * Me.m_EjeSimetria) + (Me.tIndependiente)

        'CALCULAMOS EL DISCRIMINANTE PARA SABER SI LA ECUACION TIENE RAICES REALES O COMPLEJAS (NO IMPORTA SU
        'ORDEN DE MULTIPLICIDAD)
        'EL DISCRIMINANTE ESTARA DADO POR B^2 - 4*A*C
        Me.m_discriminante = Math.Pow(Me.tLineal, 2) - (4 * Me.tCuadratico * Me.tIndependiente)

        If Me.m_discriminante >= 0 Then
            Dim t_0 As Double, t_1 As Double

            'RAICES REALES LAS CALCULAMOS

            'PARA LA PRIMERA RAIZ
            t_0 = Math.Sqrt(Me.m_discriminante)
            t_0 = ((-1) * Me.tLineal) + t_0
            t_0 = t_0 / (2 * Me.tCuadratico)

            Me.m_Cero1 = t_0

            'PARA LA SEGUNDA RAIZ
            t_1 = Math.Pow(Math.Pow(Me.tLineal, 2) - (4 * Me.tCuadratico * Me.tIndependiente), 0.5)
            t_1 = ((-1) * Me.tLineal) - t_1
            t_1 = t_1 / (2 * Me.tCuadratico)

            Me.m_Cero2 = t_1
        Else
            'RAICES COMPLEJAS Y CONJUGADAS, RESOLVEMOS HASTA DONDE PODEMOS, EXPRESAMOS EL RESULTADO
            'COMO UNA CADENA DEL TIPO A +- Bi (COMPLEJO)

            Dim r1_real As Double, r1_compleja As Double
            'CALCULAMOS LA RAIZ DE -DISCRIMINANTE

            'LA PARTE REAL ESTARA DADA POR -B/2A
            'LA PARTE IMAGINARIA ESTARA DADA POR [SQRT(B^2-4AC)]/2A 
            'PARA CALCULAR LA RAIZ CUADRADA ES NECESARIO MULTIPLICAR EL RADICANDO POR -1 CASO CONTRARIO
            'LA RAIZ NO EXISTIRA DENTRO DE R (TAMBIEN PODRIAMOS HABER USADO EL VALOR ABSOLUTO)

            'SQRT(B^2 - 4AC)
            r1_compleja = Math.Sqrt((-1) * Me.m_discriminante)
            '-B / 2A
            r1_real = ((-1) * Me.tLineal) / (2 * Me.tCuadratico)

            'SQRT(B^2 - 4AC) / 2A
            r1_compleja = r1_compleja / (2 * Me.tCuadratico)

            Me.m_Cero1 = r1_real & " + " & r1_compleja & "i"
            Me.m_Cero2 = r1_real & " - " & r1_compleja & "i"
        End If
    End Sub

    Public Function Grafica(ByVal bDerivada As Boolean, ByVal width As Integer, ByVal height As Integer) As Bitmap
        Dim img As New Bitmap(width, height)

        Dim e As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(img)

        'DIBUJAMOS EL EJE Y
        e.DrawLine(Pens.Black, New Point(width / 2, 0), New Point(width / 2, height))
        'DIBUJAMOS EL EJE X
        e.DrawLine(Pens.Black, New Point(0, height / 2), New Point(width, height / 2))

        e.DrawString("y", New Font("Arial", 8), Brushes.Black, New Point(width / 2 + 4, 0))
        e.DrawString("x", New Font("Arial", 8), Brushes.Black, New Point(width - 10, height / 2 - 4))
        Dim Cordtext As Integer

        'DIBUJAMOS LAS CORDENADAS
        For i As Single = (width / 2 + INTERVALO) To width Step INTERVALO
            Cordtext += 1
            e.DrawLine(New Pen(Brushes.Black, 1), New PointF(i, height / 2 + 2), New PointF(i, height / 2 - 2))
            e.DrawString(Cordtext, New Font("Arial", 8), Brushes.Black, New PointF(i, height / 2 - 14))
        Next

        Cordtext = 0
        For i As Single = width / 2 - INTERVALO To 0 Step -INTERVALO
            Cordtext -= 1
            e.DrawLine(New Pen(Brushes.Black, 1), New PointF(i, height / 2 + 2), New PointF(i, height / 2 - 2))
            e.DrawString(Cordtext, New Font("Arial", 8), Brushes.Black, New PointF(i - 10, height / 2 - 14))
        Next

        Cordtext = 0

        For i As Single = height / 2 + INTERVALO To height Step INTERVALO
            Cordtext -= 1
            e.DrawLine(New Pen(Brushes.Black, 1), New PointF(width / 2 + 2, i), New PointF(width / 2 - 2, i))
            e.DrawString(Cordtext, New Font("Arial", 8), Brushes.Black, New PointF(width / 2 - 20, i - INTERVALO + 10))
        Next

        Cordtext = 0

        For i As Single = height / 2 - INTERVALO To 0 Step -INTERVALO
            Cordtext += 1
            e.DrawLine(New Pen(Brushes.Black, 1), New PointF(width / 2 + 2, i), New PointF(width / 2 - 2, i))
            e.DrawString(Cordtext, New Font("Arial", 8), Brushes.Black, New PointF(width / 2 - 20, i - INTERVALO + 10))
        Next

        'DIBUJAMOS EL EJE DE SIMETRIA
        Dim xSimetria As Double = width / 2 + (Me.m_EjeSimetria * INTERVALO)

        Dim ejePen As New Pen(Brushes.Red)
        ejePen.DashStyle = Drawing2D.DashStyle.DashDotDot
        e.DrawLine(ejePen, New Point(xSimetria, 0), New Point(xSimetria, height))

        'DIBUJAMOS LA IMAGEN DEL MAX/MIN
        Dim yMaxMin As Double = height / 2 - (Me.m_ExtremoRelativo * INTERVALO)

        ejePen.Brush = Brushes.Blue
        e.DrawLine(ejePen, New Point(0, yMaxMin), New Point(width, yMaxMin))

        Dim p1(20) As Point 'curva
        Dim p2(20) As Point 'Derivada
        Dim a As Double = 2 * Me.tCuadratico, b As Double = Me.tLineal

        Dim x As Double, y As Double

        For i = -10 To 10
            x = i
            y = Me.tCuadratico * Math.Pow(i, 2) + Me.tLineal * i + Me.tIndependiente
            p1(i + 10).X = x * INTERVALO + width / 2
            p1(i + 10).Y = -y * INTERVALO + height / 2

            p2(i + 10).X = i * INTERVALO + width / 2
            p2(i + 10).Y = -(a * i + b) * INTERVALO + height / 2
        Next

        e.DrawCurve(New Pen(Brushes.Green, 2), p1)
        If bDerivada Then e.DrawLines(New Pen(Brushes.Violet, 2), p2)

        Return img
    End Function

End Class
