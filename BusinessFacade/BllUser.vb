Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllUser
    Private mobjProfilo As New DalProfilo
    Public Function AddProfilo(ByVal localtable As Utenti_Profilo) As Integer
        Try
            Return mobjProfilo.add(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetProfiloByUsername(ByVal username As String) As Utenti_Profilo
        Try
            Return mobjProfilo.GetByUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateProfilo(ByVal localtable As Utenti_Profilo)
        Try
            mobjProfilo.Update(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteProfilo(ByVal username As String)
        Try
            mobjProfilo.Invalida(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateProfiloUserInfo(ByVal username As String, _
                                     ByVal email As String, _
                                     ByVal telefono As String)
        Try
            mobjProfilo.UpdateUserInfo(username, _
                                        email, _
                                        telefono)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update_permessi(ByVal username As String, ByVal lettura As Boolean, ByVal aggiornamento As Boolean, ByVal eliminazione As Boolean)
        Try
            mobjProfilo.Update_permessi(username, lettura, aggiornamento, eliminazione)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetViewByUsername(ByVal username As String) As Profilo_ViewResult
        Return mobjProfilo.GetViewByUsername(username)
    End Function

    Public Function GetAllProfiles(Optional ByVal idRegione As String = Nothing) As List(Of Profilo_ViewAllResult)
        Return mobjProfilo.GetAllProfiles(idRegione)
    End Function
    Public Function GetAllProfilesJson(Optional ByVal idRegione As String = Nothing) As List(Of JsonDto)
        Return mobjProfilo.GetAllProfilesJson(idRegione)
    End Function
    Public Function GetAllProfilesEmailJson(Optional ByVal idRegione As String = Nothing) As List(Of JsonDto)
        Return mobjProfilo.GetAllProfilesEmailJson(idRegione)
    End Function



    Public Function GetProfilesView(Optional ByVal idRegione As String = Nothing, _
                                    Optional ByVal idAsl As String = Nothing, _
                                    Optional ByVal email As String = Nothing, _
                                    Optional ByVal nome As String = Nothing, _
                                    Optional ByVal cognome As String = Nothing, _
                                    Optional ByVal ruolo As String = Nothing) As List(Of Utenti_ListaResult)
        Try

            Return mobjProfilo.GetProfilesView(idRegione, idAsl, email, nome, cognome, ruolo).ToList

        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetListBulkUser() As List(Of BulkUser)
        Try
            Return mobjProfilo.GetListBulkUser
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub AddUserToMalattieGruppo(ByVal localtable As Utenti_Gruppi_Malattie)
        Try
            mobjProfilo.AddUserToMalattieGruppo(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateUserToMalattieGruppo(ByVal username As String, ByVal idGruppoMalattie As Integer)
        Try
            mobjProfilo.UpdateUserToMalattieGruppo(username, idGruppoMalattie)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetGruppoMelattieFromUsername(ByVal username As String) As Utenti_Gruppi_Malattie
        Try
            Return mobjProfilo.GetGruppoMelattieFromUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
