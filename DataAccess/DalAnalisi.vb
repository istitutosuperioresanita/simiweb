Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Imports System.Text.StringBuilder
Public Class DalAnalisi
    Public Function GetMod16(ByVal idregione As String, _
                             ByVal idAsl As String, _
                             ByVal anno As Nullable(Of Integer), _
                             ByVal mese As Nullable(Of Integer)) As List(Of Analisi_Mod16Result)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return ObjDataContext.Analisi_Mod16(idAsl, _
                                                    idregione, _
                                                     anno, _
                                                     mese).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAnalisi_Notifica(ByVal sql As String) As List(Of Analisi_NotificaResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Dim rs As IEnumerable(Of Analisi_NotificaResult) = ObjDataContext.ExecuteQuery(Of Analisi_NotificaResult)(sql.ToString)
                Return rs.ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    'Public Function GetAnalisi_Notifica(ByVal datanotificaDa As Nullable(Of Date), _
    '                                   ByVal dataNotificaA As Nullable(Of Date), _
    '                                   ByVal dataSintomiDa As Nullable(Of Date), _
    '                                   ByVal dataSintomiA As Nullable(Of Date), _
    '                                   ByVal dataSegnalazioneDA As Nullable(Of Date), _
    '                                   ByVal dataSegnalazioneA As Nullable(Of Date), _
    '                                   ByVal aslNotifica As String, _
    '                                   ByVal aslResidenza As String, _
    '                                   ByVal stato As String, _
    '                                   ByVal classificazione As String, _
    '                                   ByVal idRegione As String) As List(Of Analisi_NotificaResult)
    '    Try
    '        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
    '            Return ObjDataContext.Analisi_Notifica(datanotificaDa, _
    '                                                     dataNotificaA, _
    '                                                     dataSintomiDa, _
    '                                                     dataSintomiA, _
    '                                                     dataSegnalazioneDA, _
    '                                                     dataSegnalazioneA, _
    '                                                     aslNotifica, _
    '                                                     aslResidenza, _
    '                                                     stato, _
    '                                                     classificazione, _
    '                                                     idRegione).ToList

    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    'Public Function GetAnalisiFocolaio(ByVal datanotificaDa As Nullable(Of Date), _
    '                                 ByVal dataNotificaA As Nullable(Of Date), _
    '                                 ByVal dataInizioDa As Nullable(Of Date), _
    '                                 ByVal dataInizioA As Nullable(Of Date), _
    '                                 ByVal dataSegnalazioneDA As Nullable(Of Date), _
    '                                 ByVal dataSegnalazioneA As Nullable(Of Date), _
    '                                 ByVal aslNotifica As String, _
    '                                 ByVal aslResidenza As String, _
    '                                 ByVal stato As String, _
    '                                 ByVal classificazione As String, _
    '                                 ByVal idRegione As String) As List(Of Analisi_FocolaioResult)
    '    Try
    '        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
    '            Return ObjDataContext.Analisi_Focolaio(datanotificaDa, _
    '                                                     dataNotificaA, _
    '                                                     dataInizioDa, _
    '                                                     dataInizioA, _
    '                                                     dataSegnalazioneDA, _
    '                                                     dataSegnalazioneA, _
    '                                                     aslNotifica, _
    '                                                     aslResidenza, _
    '                                                     stato, _
    '                                                     classificazione, _
    '                                                     idRegione).ToList

    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function

    Public Function GetAnalisi_Focolaio(ByVal sql As String) As List(Of Analisi_FocolaioResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Dim rs As IEnumerable(Of Analisi_FocolaioResult) = ObjDataContext.ExecuteQuery(Of Analisi_FocolaioResult)(sql.ToString)
                Return rs.ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

