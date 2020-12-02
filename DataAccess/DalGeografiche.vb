Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalGeografiche
    Inherits JsonDto
    '   Private ObjDataContext As New SimiWebLinqDataContext


#Region "Province"
    Public Function GetAllProvince() As List(Of Provincia)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From prov In ObjDataContext.Provincias Select prov Order By prov.Descrizione Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllProvinceJson() As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From prov In ObjDataContext.Provincias Order By prov.Descrizione Ascending _
                                  Select New JsonDto(prov.idProvincia, prov.Descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllProvinceJsonByIdRegione(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From prov In ObjDataContext.Provincias Where prov.IdRegione = idRegione Order By prov.Descrizione Ascending _
                                  Select New JsonDto(prov.idProvincia, prov.Descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
#Region "Nazioni"

    Public Function GetAllNazioni() As List(Of Nazione)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From naz In ObjDataContext.Naziones Select naz Order By naz.nazione Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllNazioniJson() As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From naz In ObjDataContext.Naziones Select naz Order By naz.nazione Ascending _
                      Select New JsonDto(naz.IdNazione, naz.nazione)).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
#Region "Regioni"

    Public Function GetAllRegioni() As List(Of Regione)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From reg In ObjDataContext.Regiones Select reg Order By reg.IdRegione Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllRegioniJson() As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From reg In ObjDataContext.Regiones Select reg Order By reg.Descrizione Ascending _
                      Select New JsonDto(reg.IdRegione, reg.Descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Function
#End Region
#Region "Comuni"

    Public Function GetAllComuniByIdProvincia(ByVal idProvincia As String) As List(Of Comune)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From com In ObjDataContext.Comunes Where com.IdProvincia = idProvincia Select com Order By com.descrizione Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllComuniByIdProvinciaJson(ByVal idProvincia As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From comuni In ObjDataContext.Comunes Where comuni.IdProvincia = idProvincia Order By comuni.descrizione Ascending _
                                    Select New JsonDto(comuni.CodiceComune, comuni.descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAllComuniByIdRegioneJson(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From comuni In ObjDataContext.Comunes Order By comuni.descrizione Where comuni.IdRegione = idRegione Order By comuni.descrizione Ascending _
                                    Select New JsonDto(comuni.CodiceComune, comuni.descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Asl"
    Public Function GetAllAslByIdRegioneJson(ByVal idRegione As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Asls Order By tab.Descrizione Where tab.idRegione = idRegione _
                                    Select New JsonDto(tab.idAsl, tab.Descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCodiceAslByComune(ByVal idComune As String) As String
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Comunes Where tab.CodiceComune = idComune Select tab.idAsl).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
