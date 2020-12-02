Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllMedico
    Private _mobjdataAccess As New DalMedico
    Public Sub Add(ByVal localtable As ReferenteUlss)
        Try
            _mobjdataAccess.Add(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update(ByVal localtable As ReferenteUlss)
        Try
            _mobjdataAccess.Update(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAllMedicoJsonByPArameters(ByVal idRegione As String, Optional ByVal idAsl As String = Nothing) As List(Of JsonDto)
        Try
            If Not idAsl Is Nothing Then
                Return _mobjdataAccess.GetAllMedicoJsonByIdAsl(idAsl)
            Else

                Return _mobjdataAccess.GetAllMedicoJsonByIdRegione(idRegione)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Function GetAllMedicoJsonByIdAsl(ByVal idRegione As String) As List(Of JsonDto)
    '    Try
    '        Return _mobjdataAccess.GetAllMedicoJsonByIdRegione(idRegione)
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Function GetByID(ByVal id As Integer)
        Try
            Return _mobjdataAccess.GetByID(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllMedicoByIdRegione(ByVal idRegione) As List(Of ReferenteMedicoDTO)
        Try
            Return _mobjdataAccess.GetAllMedicoByIdRegione(idRegione)

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Function GetAllMedico(Optional ByVal idRegione As String = "", _
    '                             Optional ByVal idAsl As String = "") As List(Of ReferenteUlss)
    '    Try
    '        Return _mobjdataAccess.GetAllMedico(idRegione)

    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Sub Invalida(ByVal id As Integer)
        Try
            _mobjdataAccess.invalida(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
