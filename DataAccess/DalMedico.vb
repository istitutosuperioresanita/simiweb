Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess.JsonDto

Public Class DalMedico
    Public Function Add(ByVal localtable As ReferenteUlss) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.ReferenteUlsses.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal LocalTable As ReferenteUlss)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.ReferenteUlsses.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetByID(ByVal id As Integer) As ReferenteUlss
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.ReferenteUlsses Where tab.id = id).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllMedicoJsonByIdRegione(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.ReferenteUlsses Where tab.idRegione = idRegione And tab.valido = True Order By tab.cognome Ascending _
                                  Select New JsonDto(tab.id, tab.nome + " " + tab.cognome)).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllMedicoJsonByIdAsl(ByVal idAsl As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.ReferenteUlsses Where tab.idAsl = idAsl And tab.valido = True Order By tab.cognome Ascending _
                                  Select New JsonDto(tab.id, tab.nome + " " + tab.cognome)).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllMedicoByIdRegione(ByVal idRegione As String) As List(Of ReferenteMedicoDTO)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.ReferenteUlsses Join asl In ObjDataContext.Asls _
                        On tab.idAsl Equals asl.idAsl Where tab.idRegione = idRegione And tab.valido = True Order By tab.idAsl _
                        Select New ReferenteMedicoDTO(tab.id, tab.idRegione, asl.Descrizione, _
                                                      tab.nome, tab.cognome, tab.email, tab.telefono, tab.valido)).ToList

            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    'Public Function GetAllMedico(ByVal idRegione As String, _
    '                             ByVal idAsl As String) As List(Of ReferenteUlss)
    '    Try
    '        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
    '            Return (From tab In ObjDataContext.ReferenteUlsses Where tab.idRegione = idRegione And tab.valido = True Select tab Order By tab.cognome).ToList

    '        End Using
    '    Catch ex As Exception
    '        Throw ex

    '    End Try
    'End Function
    Public Sub Invalida(ByVal id As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Medico_invalida(id)
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
End Class
