Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DAlMib
    'Public Function GetZoneList(ByVal tipo As Integer) As List(Of JsonDto)
    '    Try
    '        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

    '            Return (From tab In ObjDataContext.Tbc_Zones Where tab.tipo = tipo Order By tab.codice Select New JsonDto(tab.descrizione, _
    '                                                                            tab.codice + " " + tab.descrizione)).ToList
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Function GetMib(ByVal idNotifica As Integer) As Notifica_Mib
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Notifica_Mibs Select tab Where tab.idNotifica = idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMibView(ByVal idNotifica As Integer) As notifica_View_mibResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.notifica_View_mib(idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Add(ByVal localtable As Notifica_Mib) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Mibs.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal LocalTable As Notifica_Mib)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Mibs.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
End Class
