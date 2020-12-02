Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalProfilo
#Region "Anagrafica"
    Public Function add(ByVal localtable As Utenti_Profilo) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Utenti_Profilos.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Return 1
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal LocalTable As Utenti_Profilo)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Utenti_Profilos.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetByUsername(ByVal username As String) As Utenti_Profilo
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Utenti_Profilos Select tab Where tab.username = username).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetViewByUsername(ByVal username As String) As Profilo_ViewResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Profilo_View(username).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Sub Invalida(ByVal username As String)

        Try
            '  Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Throw New Exception("Metodo non implementato")
            ' End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateUserInfo(ByVal username As String, _
                              ByVal email As String, _
                              ByVal telefono As String)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Profilo_AggiornaDatiPersonali(username, _
                                                             email, _
                                                             telefono)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetAllProfiles(ByVal idRegione As String) As List(Of Profilo_ViewAllResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Profilo_ViewAll(idRegione).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetAllProfilesJson(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Profilo_ViewAll(idRegione) Select New JsonDto(tab.username, (tab.nome + " " + tab.cognome + "- asl:" + tab.Asl))).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetAllProfilesEmailJson(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Profilo_ViewAll(idRegione) Select New JsonDto(tab.Email, (tab.nome + " " + tab.cognome + ":" + tab.Asl))).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetProfilesView(ByVal idRegione As String, _
                                    ByVal idAsl As String, _
                                    ByVal email As String, _
                                    ByVal nome As String, _
                                    ByVal cognome As String, _
                                    ByVal ruolo As String) As List(Of Utenti_ListaResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Utenti_Lista(idRegione, idAsl, email, nome, cognome, ruolo).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function

    Public Function GetListBulkUser() As List(Of BulkUser)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.BulkUsers.ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "gruppi malattie"
    Public Sub AddUserToMalattieGruppo(ByVal localtable As Utenti_Gruppi_Malattie)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Utenti_Gruppi_Malatties.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateUserToMalattieGruppo(ByVal username As String, ByVal idGruppoMalattie As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Utenti_Gruppi_Malattie_Update(username, idGruppoMalattie)                
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update_permessi(ByVal username As String, ByVal lettura As Boolean, ByVal aggiornamento As Boolean, ByVal eliminazione As Boolean)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Profilo_Aggiorna_permessi(username, lettura, aggiornamento, eliminazione)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetGruppoMelattieFromUsername(ByVal username As String) As Utenti_Gruppi_Malattie
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Utenti_Gruppi_Malatties Select tab Where tab.username = username).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
