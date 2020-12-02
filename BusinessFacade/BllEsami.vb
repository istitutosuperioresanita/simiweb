Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllEsami
    Private mobjdataAccess As New DalEsami
#Region "Materiale"
    Public Function GetAllMaterialeList() As List(Of Materiale)
        Try
            Return mobjdataAccess.GetAllMaterialeList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMateriale() As Table(Of Materiale)
        Try
            Return mobjdataAccess.GetAllMateriale
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMaterialeById(ByVal id As Integer) As Materiale
        Try
            Return mobjdataAccess.GetMaterialeById(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMaterialeJson() As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllMaterialeJson
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetMaterialeByMetodo(ByVal idMetodo As String) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetMaterialeByMetodo(idMetodo)
        Catch ex As Exception
            Throw ex

        End Try
    End Function

    Public Function AddMateriale(ByVal localtable As Materiale) As Integer
        Try
            Return mobjdataAccess.AddMateriale(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteMateriale(ByVal idMateriale As Integer)
        Try
            mobjdataAccess.DeleteMateriale(idMateriale)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateMAteriale(ByVal LocalTable As Materiale)
        Try

            mobjdataAccess.UpdateMAteriale(LocalTable)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "Metodo"
    Public Function GetAllMetodo() As List(Of Metodo)
        Try
            Return mobjdataAccess.GetAllMetodo
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetMetodoById(ByVal id As Integer) As Metodo
        Try
            Return mobjdataAccess.GetMetodoById(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMetodoList() As List(Of Metodo)
        Try
            Return mobjdataAccess.GetAllMetodoList
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllMetodoJson() As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllMetodoJson
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function AddMetodo(ByVal localtable As Metodo) As Integer
        Try
            Return mobjdataAccess.AddMetodo(localtable)
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Sub DeleteMetodo(ByVal idMetodo As Integer)
        Try
            mobjdataAccess.DeleteMetodo(idMetodo)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateMetodo(ByVal LocalTable As Metodo)
        Try
            mobjdataAccess.UpdateMetodo(LocalTable)

        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region

#Region "AgenteEziologico"
    Public Function GetAllAgenteList() As List(Of Agente_Eziologico)
        Try
            Return mobjdataAccess.GetAllAgenteList()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAgenteById(ByVal id As Integer) As Agente_Eziologico
        Try
            Return mobjdataAccess.GetAgenteById(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgenteJson() As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllAgenteJson()
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllAgente() As Table(Of Agente_Eziologico)
        Try
            Return mobjdataAccess.GetAllAgente
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente(ByVal localtable As Agente_Eziologico) As Integer
        Try
            Return mobjdataAccess.AddAgente(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente(ByVal idAgente As Integer)
        Try
            mobjdataAccess.DeleteAgente(idAgente)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateAgente(ByVal LocalTable As Agente_Eziologico)
        Try
            mobjdataAccess.UpdateAgente(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetAgenteByIdMalattiaJson(ByVal idMalattia As Integer) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAgenteByIdMalattia(idMalattia)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Esame"
    Public Function GetAllEsami() As Table(Of Esami)
        Try
            Return mobjdataAccess.GetAllEsami
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllEsamiList() As List(Of Esami)
        Try
            Return mobjdataAccess.GetAllEsamiList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddEsame(ByVal localtable As Esami) As Integer
        Try
            Return mobjdataAccess.AddEsame(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteEsame(ByVal idEsame As Integer)
        Try
            mobjdataAccess.DeleteEsame(idEsame)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateEsame(ByVal LocalTable As Esami)
        Try
            mobjdataAccess.UpdateEsame(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Agente_Metodo_Materiale"
    Public Function GetAllAgente_Metodo_Materiale() As Table(Of Agente_Metodo_Materiale)
        Try
            Return mobjdataAccess.GetAllAgente_Metodo_Materiale
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgente_Metodo_MaterialeList() As List(Of Agente_Metodo_Materiale)
        Try
            Return mobjdataAccess.GetAllAgente_Metodo_MaterialeList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetViewAgente_Metodo_Materiale() As List(Of ViewAgenteMetodoMaterialeResult)
        Try
            Return mobjdataAccess.GetViewAgente_Metodo_Materiale()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente_Metodo_Materiale(ByVal localtable As Agente_Metodo_Materiale) As Integer
        Try
            Return mobjdataAccess.AddAgente_Metodo_Materiale(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente_Metodo_Material(ByVal id As Integer)
        Try
            mobjdataAccess.DeleteAgente_Metodo_Materiale(id)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateAgente_Metodo_Materiale(ByVal LocalTable As Agente_Metodo_Materiale)
        Try
            mobjdataAccess.UpdateAgente_Metodo_Materiale(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Veicolo"
    Public Function GetAllVeicolo() As Table(Of Veicolo)
        Try
            Return mobjdataAccess.GetAllVeicolo
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetVeicoloById(ByVal id As Integer) As Veicolo
        Try
            Return mobjdataAccess.GetVeicoloById(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllVeicoloList() As List(Of Veicolo)
        Try
            Return mobjdataAccess.GetAllVeicoloList
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllVeicoloJson() As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetAllVeicoloJson
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function AddVeicolo(ByVal localtable As Veicolo) As Integer
        Try
            Return mobjdataAccess.AddVeicolo(localtable)
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Sub DeleteVeicolo(ByVal idMetodo As Integer)
        Try
            mobjdataAccess.DeleteVeicolo(idMetodo)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateVeicolo(ByVal LocalTable As Veicolo)
        Try
            mobjdataAccess.UpdateVeicolo(LocalTable)

        Catch ex As Exception
            Throw ex

        End Try
    End Sub
#End Region
#Region "Agente_Veicolo"
    Public Function GetAllAgente_Veicolo() As Table(Of Agente_Veicolo)
        Try
            Return mobjdataAccess.GetAllAgente_Veicolo
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgente_VeicoloList() As List(Of Agente_Veicolo)
        Try
            Return mobjdataAccess.GetAllAgente_VeicoloList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente_Veicolo(ByVal localtable As Agente_Veicolo) As Integer
        Try
            Return mobjdataAccess.AddAgente_Veicolo(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente_Veicolo(ByVal id As Integer)
        Try
            mobjdataAccess.DeleteAgente_Veicolo(id)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateAgente_Veicolo(ByVal LocalTable As Agente_Veicolo)
        Try
            mobjdataAccess.UpdateAgente_Veicolo(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetViewAgente_Veicolo() As List(Of ViewAgenteVeicoloResult)
        Try
            Return mobjdataAccess.GetViewAgente_Veicolo()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Agente_Malattia"
    Public Function GetAllAgente_Malattia() As Table(Of Agente_Malattia)
        Try
            Return mobjdataAccess.GetAllAgente_Malattia
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgente_MalattiaList() As List(Of Agente_Malattia)
        Try
            Return mobjdataAccess.GetAllAgente_MalattiaList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente_Malattia(ByVal localtable As Agente_Malattia) As Integer
        Try
            Return mobjdataAccess.AddAgente_Malattia(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente_Malattia(ByVal id As Integer)
        Try
            mobjdataAccess.DeleteAgente_Malattia(id)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateAgente_Malattia(ByVal LocalTable As Agente_Malattia)
        Try
            mobjdataAccess.UpdateAgente_Malattia(LocalTable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetViewAgente_Malattia() As List(Of ViewAgenteMalattiaResult)
        Try
            Return mobjdataAccess.GetViewAgente_Malattia()
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
