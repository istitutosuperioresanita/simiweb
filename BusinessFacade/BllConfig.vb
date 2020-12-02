

Public Class BllConfig

    Private _ChartImageHandler As String
    Private _enableTracing As String

    Public ReadOnly Property enableTracing As Boolean
        Get
            Return _enableTracing
        End Get
    End Property
    Public ReadOnly Property ChartImageHandler As String
        Get
            Return _ChartImageHandler
        End Get
    End Property
    Public Sub New()
        _enableTracing = True
        _ChartImageHandler = ""
    End Sub

    Public Shared Function retrieveTracingStatus() As Boolean
        Return True
    End Function
    Public Function retrievePathLastOperation(ByVal Categoria As String, ByVal Sezione As String) As String
        Dim path As String = "~/Home.aspx"

        If LCase(Categoria) = "notifica" Then
            path = "~/Notifica/Riepilogo.aspx"
            If LCase(Sezione) = "anagrafica" Then
                path = path & "?tab=anagrafica"
            End If
            If Sezione = "clinici" Then
                path = path & "?tab=Clinico"
            End If
            If Sezione = "info" Then
                path = path & "?tab=info"
            End If
            If Sezione = "mib" Then
                path = path & "?tab=mib"
            End If
            If Sezione = "tbc" Then
                path = path & "?tab=tbc"
            End If
        End If
        If LCase(Sezione) = "focolaio" Then
            path = "~/Focolaio/riepilogo.aspx"
        End If
        Return path
    End Function
End Class
