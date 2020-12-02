Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalAccessorie
    Inherits JsonDto
    Private ObjDataContext As New SimiWebLinqDataContext

#Region "Professione"


    Public Function GettAllProfessioniList() As List(Of Professione)

        Try
            Return (From pro In ObjDataContext.Professiones Select pro Order By pro.Descrizione Ascending).ToList
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GettAllProfessioniJson() As List(Of JsonDto)

        Try
            Return (From pro In ObjDataContext.Professiones Order By pro.Descrizione Select New JsonDto(pro.codice, pro.Descrizione)).ToList
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetProfessioneById(ByVal id As Integer) As Professione
        Try
            Return (From pro In ObjDataContext.Professiones Where pro.id = id).SingleOrDefault
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddProfessione(ByVal localtable As Professione) As Integer
        Try
            ObjDataContext.Professiones.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteProfessione(ByVal idProfessione As Integer)
        Try
            ObjDataContext.Professiones.DeleteOnSubmit( _
                (From pro In ObjDataContext.Professiones _
                 Where pro.id = idProfessione).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateProfessione(ByVal LocalTable As Professione)
        Try
            ObjDataContext.Professiones.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
#End Region
#Region "Comunita"

    Public Function GettAllComunitaList() As List(Of Comunita)

        Try
            Return (From com In ObjDataContext.Comunitas Select com Order By com.Descrizione Ascending).ToList
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GettAllComunitaJson() As List(Of JsonDto)

        Try
            Return (From com In ObjDataContext.Comunitas Order By com.Descrizione Select New JsonDto(com.Codice, com.Descrizione)).ToList
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetComunitaById(ByVal id As Integer) As Comunita
        Try
            Return (From com In ObjDataContext.Comunitas Where com.id = id).SingleOrDefault
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddComunita(ByVal localtable As Comunita) As Integer
        Try
            ObjDataContext.Comunitas.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteComunita(ByVal idComunita As Integer)
        Try
            ObjDataContext.Comunitas.DeleteOnSubmit( _
                (From com In ObjDataContext.Comunitas _
                 Where com.id = idComunita).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateComunita(ByVal LocalTable As Comunita)
        Try
            ObjDataContext.Comunitas.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
#End Region
#Region "Medico"

    Public Function GettAllComunitaList(ByVal idRegione) As List(Of ReferenteUlss)

        Try
            Return (From com In ObjDataContext.ReferenteUlsses Select com).ToList
        Catch ex As Exception
            Throw ex
        End Try

    End Function
#End Region
End Class
