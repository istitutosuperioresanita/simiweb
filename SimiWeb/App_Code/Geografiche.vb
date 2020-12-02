Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports Simiweb.BusinessFacade

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Geografiche
    Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Function GetComuni(ByVal idProvincia As String) As List(Of JsonDto)
        Dim MobjGeografiche As New BllGeografiche

        Return MobjGeografiche.GetAllComuniByIdProvinciaJson(idProvincia)
    End Function
    <WebMethod()> _
    Public Function GetProvince() As List(Of JsonDto)
        Dim MobjGeografiche As New BllGeografiche
        Return MobjGeografiche.GetAllProvinceJson()
    End Function
    <WebMethod()> _
    Public Function GetAllProvinceIdRegione(ByVal idRegione As String) As List(Of JsonDto)
        Dim MobjGeografiche As New BllGeografiche
        Return MobjGeografiche.GetAllProvinceJsonByIdRegione(idRegione)
    End Function
    <WebMethod()> _
    Public Function GetNazioni() As List(Of JsonDto)
        Dim MobjGeografiche As New BllGeografiche
        Return MobjGeografiche.GetAllNazioniJson()
    End Function
    <WebMethod()> _
    Public Function GetAgente() As List(Of JsonDto)
        Dim MobjMalattie As New BllEsami
        Return MobjMalattie.GetAllAgenteJson
    End Function
    <WebMethod()> _
    Public Function GetVeicolo() As List(Of JsonDto)
        Dim MobjMalattie As New BllEsami
        Return MobjMalattie.GetAllVeicoloJson
    End Function
    <WebMethod()> _
    Public Function GetMateriale() As List(Of JsonDto)
        Dim MobjMalattie As New BllEsami
        Return MobjMalattie.GetAllMaterialeJson
    End Function
    <WebMethod()> _
    Public Function GetMetodo() As List(Of JsonDto)
        Dim MobjMalattie As New BllEsami
        Return MobjMalattie.GetAllMetodoJson
    End Function
    <WebMethod()> _
    Public Function GetAgenteByIdMalattia(ByVal idMalattia As Integer) As List(Of JsonDto)
        Dim MobjMalattie As New BllEsami
        Return MobjMalattie.GetAgenteByIdMalattiaJson(idMalattia)
    End Function

    <WebMethod()> _
    Public Function GetMaterialeByMetodo(ByVal IdMetodo As String) As List(Of JsonDto)
        Dim MobjEsame As New BllEsami
        Return MobjEsame.GetMaterialeByMetodo(IdMetodo)
    End Function

End Class