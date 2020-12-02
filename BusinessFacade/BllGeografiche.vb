Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllGeografiche
#Region "Nazioni"
    Private mobjdataAccess As New DalGeografiche
    Public Function GetAllNazioni() As List(Of Nazione)
        Try
            Return mobjdataAccess.GetAllNazioni
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllNazioniJson() As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllNazioniJson
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Regioni"
    Public Function GetAllRegioni() As List(Of Regione)
        Try
            Return mobjdataAccess.GetAllRegioni
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllRegioniJson() As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllRegioniJson
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Province"
    Public Function GetAllProvince() As List(Of Provincia)
        Try
            Return mobjdataAccess.GetAllProvince
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllProvinceJson() As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllProvinceJson
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllProvinceJsonByIdRegione(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllProvinceJsonByIdRegione(idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Comuni"

    Public Function GetAllComuniByIdProvincia(ByVal idProvincia As String) As List(Of Comune)
        Try
            Return mobjdataAccess.GetAllComuniByIdProvincia(idProvincia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllComuniByIdProvinciaJson(ByVal idProvincia As String) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllComuniByIdProvinciaJson(idProvincia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllComuniByIdRegioneJson(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllComuniByIdRegioneJson(idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

#Region "Asl"
    Public Function GetAllAslByIdRegioneJson(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllAslByIdRegioneJson(idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCodiceAslByComune(ByVal idComune As String) As String
        Try
            Return mobjdataAccess.GetCodiceAslByComune(idComune)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region



End Class
