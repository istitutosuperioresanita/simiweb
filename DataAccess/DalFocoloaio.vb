Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalFocolaio
    Public Function Add(ByVal localtable As Focolaio) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Focolaios.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                i = localtable.id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal LocalTable As Focolaio)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Focolaios.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetInfo(ByVal id As Integer) As Focolaio_InfoResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return ObjDataContext.Focolaio_Info(id).SingleOrDefault

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Sub Delete(ByVal id As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Focolaios.DeleteOnSubmit( _
                     (From row In ObjDataContext.Focolaios _
                      Where row.id = id).Single)
                ObjDataContext.SubmitChanges()
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Public Function GetFromId(ByVal id As Integer) As Focolaio
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From row In ObjDataContext.Focolaios Select row Where row.id = id).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLista(ByVal idMalattia As Nullable(Of Integer), _
                             ByVal idComune As String, _
                             ByVal dataNotificaDa As Nullable(Of Date), _
                             ByVal dataNotificaA As Nullable(Of Date), _
                             ByVal dataSegnalazioneDa As Nullable(Of Date), _
                             ByVal dataSegnalazioneA As Nullable(Of Date), _
                             ByVal IdAsl As String, _
                             ByVal IdRegione As String, _
                             ByVal username As String,
                             ByVal usernameMedico As String) As List(Of Focolaio_ListaResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Focolaio_Lista(idMalattia, _
                                                     idComune, _
                                                     dataNotificaDa, _
                                                     dataNotificaA, _
                                                     dataSegnalazioneDa, _
                                                     dataSegnalazioneA, _
                                                     IdAsl, _
                                                     IdRegione, _
                                                     username, _
                                                     usernameMedico).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetElenchi(ByVal sql As String) As List(Of Focolaio_ElenchiResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Dim rs As IEnumerable(Of Focolaio_ElenchiResult) = ObjDataContext.ExecuteQuery(Of Focolaio_ElenchiResult)(sql.ToString)
                Return rs.ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetFocoalioView(ByVal id As Integer) As Focolaio_ViewResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Focolaio_View(id).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub CambiaStato(ByVal id As Integer, ByVal stato As String)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Focolaio_Cambia_Stato(id, stato)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ExportData(ByVal idRegione As String, ByVal idAsl As String) As List(Of Focolaio_EsportaResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Focolaio_Esporta(idRegione, idAsl).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportFocolaio(ByVal idRegione As String, _
                                   ByVal idAsl As String, _
                                   ByVal anno As Nullable(Of Integer), _
                                   ByVal username As String, _
                                   ByVal usernameMedico As String) As List(Of Focolaio_exportResult)
        Try

            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Focolaio_export(idRegione, idAsl, anno, username, usernameMedico).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
