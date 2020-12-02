Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllAccessorie
    Private mobjdataAccess As New DalAccessorie
#Region "Professioni"
    Public Function GettAllProfessioniList() As List(Of Professione)

        Try
            Return mobjdataAccess.GettAllProfessioniList
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GettAllProfessioniJson() As List(Of JsonDto)

        Try
            Return mobjdataAccess.GettAllProfessioniJson
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddProfessione(ByVal localtable As Professione) As Integer
        Try
            Return mobjdataAccess.AddProfessione(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteProfessione(ByVal idProfessione As Integer)
        Try
            mobjdataAccess.DeleteProfessione(idProfessione)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateProfessione(ByVal LocalTable As Professione)
        Try
            mobjdataAccess.UpdateProfessione(LocalTable)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Function GetProfessioneById(ByVal id As Integer) As Professione
        Try
            Return mobjdataAccess.GetProfessioneById(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Comunita"
    Public Function GettAllComunitaList() As List(Of Comunita)

        Try
            Return mobjdataAccess.GettAllComunitaList
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GettAllComunitaJson() As List(Of JsonDto)

        Try
            Return mobjdataAccess.GettAllComunitaJson
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function AddComunita(ByVal localtable As Comunita) As Integer
        Try
            Return mobjdataAccess.AddComunita(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteComunita(ByVal idComunita As Integer)
        Try
            mobjdataAccess.DeleteComunita(idComunita)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateComunita(ByVal LocalTable As Comunita)
        Try
            mobjdataAccess.UpdateComunita(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetComunitaById(ByVal id As Integer) As Comunita
        Try
            Return mobjdataAccess.GetComunitaById(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
