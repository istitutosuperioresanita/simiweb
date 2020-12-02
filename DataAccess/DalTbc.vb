Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalTbc
    Public Function GetZoneList(ByVal tipo As Integer) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return (From tab In ObjDataContext.Tbc_Zones Where tab.tipo = tipo Order By tab.codice Select New JsonDto(tab.descrizione, _
                                                                                tab.codice + " " + tab.descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTbc(ByVal idNotifica As Integer) As Notifica_Tbc
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Notifica_Tbcs Select tab Where tab.idNotifica = idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddTbc(ByVal localtable As Notifica_Tbc) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Tbcs.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateTbc(ByVal LocalTable As Notifica_Tbc)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Tbcs.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Sub
    Public Function ExportTBC(ByVal idRegione As String, _
                              ByVal idAsl As String, ByVal anno As Nullable(Of Integer), _
                              ByVal username As String, _
                              ByVal usernameMedico As String) As List(Of tbc_exportResult)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Return ObjDataContext.tbc_export(idRegione, idAsl, anno, username, usernameMedico).ToList
        End Using
    End Function
    Public Function ExportTbcFattori(ByVal idRegione As String, _
                                     ByVal idAsl As String, _
                                     ByVal anno As Nullable(Of Integer), _
                                     ByVal username As String, _
                                     ByVal usernameMedico As String) As List(Of tbc_fattori_exportResult)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Return ObjDataContext.tbc_fattori_export(idRegione, idAsl, anno, username, usernameMedico).ToList
        End Using
    End Function
    Public Function ExportMalaria(ByVal idRegione As String, _
                                     ByVal idAsl As String, _
                                     ByVal anno As Nullable(Of Integer), _
                                     ByVal username As String, _
                                     ByVal usernameMedico As String) As List(Of malaria_exportResult)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Return ObjDataContext.malaria_export(idRegione, idAsl, anno, username, usernameMedico).ToList
        End Using
    End Function
End Class
