Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllMalattie
    Private mobjdataAccess As New DalMalattie

    Public Enum tipo
        tutte = 0
        notifiche = 1
        focolaio = 2
        valide = 3
        visualizzabili = 4
        Mib = 5
        Gruppo = 6
    End Enum


    Public Function GetAuthMallatieList(ByVal username As String) As List(Of Malattia)

        Return mobjdataAccess.GetAuthMallatieList(username)


    End Function


    Public Function GetAllMalattieList(Optional ByVal Tipo As tipo = BllMalattie.tipo.valide, Optional ByVal str As String = "") As List(Of Malattia)
        Try

            Select Case Tipo
                Case BllMalattie.tipo.tutte
                    Return mobjdataAccess.GetAllMalattieList
                Case BllMalattie.tipo.focolaio
                    Return mobjdataAccess.GetAllMalattieFocolaioList
                Case BllMalattie.tipo.valide
                    If str <> "" Then
                        Return mobjdataAccess.GetAllMalattieList(str)
                    Else
                        Return mobjdataAccess.GetAllMalattieList
                    End If
                Case Else
                    Throw New Exception("Tipo non valido")
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMalattieManager() As List(Of Malattia)
        Try
            Return mobjdataAccess.GetAllMalattieManager
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function isMib(ByVal idmalattia As Integer) As Boolean

        Dim localtable As Malattia = mobjdataAccess.getMalattia(idmalattia)

        If LCase(localtable.ModuloMib) = "si" Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function isTbc(ByVal idmalattia As Integer) As Boolean

        Dim localtable As Malattia = mobjdataAccess.getMalattia(idmalattia)

        If LCase(localtable.ModuloTbc) = "si" Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function isMibModuloTipizzazione(ByVal idmalattia As Integer) As Boolean

        Dim localtable As Malattia = mobjdataAccess.getMalattia(idmalattia)

        If LCase(localtable.ModuloMibTipizzazione) = "si" Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Function CanChange(ByVal idmalattia As String, ByRef gruppoMalattia As String) As Boolean
        Try
            Dim malattia As Malattia = mobjdataAccess.InfoMalattia(idmalattia)
            gruppoMalattia = malattia.gruppo
            If malattia.modificabile = "si" And malattia.obbligatoriExtra = "no" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMalattieJson(Optional ByVal Tipo As tipo = BllMalattie.tipo.tutte, Optional ByVal Gruppo As String = "", Optional ByVal username As String = "") As List(Of JsonDto)
        Try
            Select Case Tipo
                Case BllMalattie.tipo.tutte
                    Return mobjdataAccess.GetAllMalattieValideJson()
                Case BllMalattie.tipo.valide
                    Return mobjdataAccess.GetAllMalattieValideJson()
                Case BllMalattie.tipo.visualizzabili
                    Return mobjdataAccess.GetAllMalattieVisualizzabiliJson
                Case BllMalattie.tipo.focolaio
                    Return mobjdataAccess.GetAllMalattieFocolaioJson
                Case BllMalattie.tipo.Mib
                    Return mobjdataAccess.GetAllMalattieMibJson
                Case BllMalattie.tipo.Gruppo
                    If Gruppo = "" Or username = "" Then
                        Throw New Exception("specificare un gruppo e/o lo username")
                    End If
                    Return mobjdataAccess.GetAllMalattieJsonByLevel(Gruppo, username)
                Case Else
                    Throw New Exception("Tipo non valido")
            End Select

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetMalattia(ByVal idMalattia As Integer) As Malattia
        Try
            Return mobjdataAccess.getMalattia(idMalattia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function retrieveClassification(ByVal idMalattia As Integer) As List(Of Malattie_Classificazione_Caso)
        Try
            Return mobjdataAccess.retrieveClassification(idMalattia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCriteri(ByVal idMalattia As Integer) As Malattie_Criteri
        Try
            Return mobjdataAccess.GetCriteri(idMalattia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDescrizioneMalattia(ByVal idMalattia As Integer) As String
        Try
            Return mobjdataAccess.GetDescrizioneMalattia(idMalattia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMalattiaByIdAgenteJson(ByVal codiceAgente As String) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetMalattiaByIdAgenteJson(codiceAgente)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateClassificazione(ByVal LocalTable As Malattie_Classificazione_Caso)

        Try
            mobjdataAccess.UpdateClassificazione(LocalTable)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Function Add(ByVal LocalTable As Malattia) As Integer

        Try
            Return mobjdataAccess.Add(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal LocalTable As Malattia)

        Try
            mobjdataAccess.Update(LocalTable)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateCriterio(ByVal LocalTable As Malattie_Criteri)

        Try
            mobjdataAccess.UpdateCriterio(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Function GetAgentiJsonByIdMalattia(ByVal idMalattia As Integer) As List(Of JsonDto)
        Return mobjdataAccess.GetAgentiJsonByIdMalattia(idMalattia)
    End Function

    Function GetAllGruppiMalattie() As List(Of JsonDto)
        Return mobjdataAccess.GetAllGruppiMalattieJson()
    End Function
    Function Notificabile(ByVal idMalattia) As Boolean
        Try
            Dim malattia As Malattia = mobjdataAccess.getMalattia(idMalattia)
            If malattia.obbligatoriExtra = "si" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
