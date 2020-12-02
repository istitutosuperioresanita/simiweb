Imports Microsoft.VisualBasic
Imports System

Public Class Helper
    Public Shared Function ChecKStatoNotifica(ByVal stato As String) As String
        Select Case UCase(stato)
            Case "S"
                Return "Segnalazione"
            Case "N"
                Return "Notifica"
            Case "A"
                Return "Archiviata"
            Case Else
                Return "Errore"
        End Select
    End Function
    Public Shared Function IsNull(ByVal value As Object) As String
        Dim retValue As String

        If value Is DBNull.Value Or value Is Nothing Then
            retValue = ""
        Else
            retValue = value.ToString
        End If
        Return retValue.Replace("""", "")
    End Function
    Public Shared Function IsNullDate(ByVal value As Object) As String

        Dim retValue As String

        If value Is DBNull.Value Or value Is Nothing Then
            retValue = ""
        Else
            Dim data As DateTime
            data = Convert.ToDateTime(value)
            retValue = data.ToShortDateString
        End If
        Return retValue

    End Function

    Public Shared Function ConvertEmptyDateToNothing(ByVal value As String) As Object
        If value = "" Then
            Return Nothing
        Else
            Return Convert.ToDateTime(value)
        End If
    End Function

    Public Shared Function ConvertDateToString(ByVal value As Date) As String
        If IsNothing(value) Then
            Return ""
        Else
            Return value.ToShortDateString
        End If
    End Function
    Public Shared Function ConvertBooleanToString(ByVal value As Boolean) As String
        Select Case value
            Case True
                Return "si"
            Case False
                Return "no"
            Case Else
                Return Nothing
        End Select
    End Function
    Public Shared Function ConvertBooleanToInt(ByVal value As Boolean) As String
        Select Case value
            Case True
                Return 1
            Case False
                Return 0
            Case Else
                Return Nothing
        End Select
    End Function
    Public Shared Function ConvertIntToBoolean(ByVal value As Integer) As Boolean
        Select Case LCase(value)
            Case 1
                Return True
            Case 0
                Return False
            Case Else
                Return Nothing
        End Select
    End Function
    Public Shared Function ConvertStringToBoolean(ByVal value As String) As Boolean
        Select Case LCase(value)
            Case "si"
                Return True
            Case "no"
                Return False
            Case Else
                Return Nothing
        End Select
    End Function

    Public Shared Function ConvertIntegerToNothing(ByVal value As String) As Object
        If value = "" Then
            Return Nothing
        Else
            Return Convert.ToInt32(value)
        End If
    End Function

    Public Shared Function ConvertEmptyStringToNothing(ByVal value As String) As Object
        If value = "" Then
            Return Nothing
        Else
            Return value
        End If
    End Function

End Class
