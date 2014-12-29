Namespace geo.format
    Public Class Normalized
        Public Shared Function removeComplement(ByVal cadena As String) As String
            Dim calle As String
            Dim numero As String
            Dim calleNumero As String

            'Calle
            Dim indexNumero As Integer = indexFirstNumber(cadena)
            calle = Trim(Mid(cadena, 1, indexNumero - 1))

            'Numero
            Dim cadenaNumeroComuna As String = Mid(cadena, indexNumero, Len(cadena))
            Dim indexEndNumero As Integer = indexFirstString(cadenaNumeroComuna)
            numero = Trim(Mid(cadenaNumeroComuna, 1, indexEndNumero))

            calleNumero = calle + " " + numero

            Return calleNumero

        End Function

        Public Shared Function removeAbr(ByVal cadena As String) As String
            cadena = Replace(cadena, "AVDA", "")
            cadena = Replace(cadena, "AVE", "")
            cadena = Replace(cadena, "PJE", "")
            cadena = Replace(cadena, "NRO", "")
            Return cadena
        End Function

        Public Shared Function optimize(ByVal cadena As String) As String
            cadena = removeComplement(cadena)
            cadena = removeAbr(cadena)
            Return cadena
        End Function

        Private Shared Function indexFirstNumber(ByVal cadena) As Integer
            Dim i As Integer = 1
            Dim ascii

            For i = 1 To Len(cadena)
                ascii = Asc(Mid(cadena, i, 1))
                If ascii > 47 And ascii < 58 Then
                    Return i
                End If
            Next
            Return i
        End Function

        Public Shared Function indexFirstString(ByVal cadena) As Integer
            Dim i As Integer = 1
            Dim ascii
            For i = 1 To Len(cadena)
                ascii = Asc(Mid(cadena, i, 1))
                If ascii <= 47 Or ascii >= 58 Then
                    Return i
                End If
            Next
            Return i
        End Function


    End Class
End Namespace
