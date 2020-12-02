Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalEsami
    Private ObjDataContext As New SimiWebLinqDataContext
#Region "Materiale"
    Public Function GetAllMaterialeList() As List(Of Materiale)
        Try
            Return (From mat In ObjDataContext.Materiales Select mat Order By mat.DescrizioneBreve Ascending).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMateriale() As Table(Of Materiale)
        Try
            Return (From mat In ObjDataContext.Materiales)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMaterialeById(ByVal id As Integer) As Materiale
        Try
            Return (From mat In ObjDataContext.Materiales Where mat.id = id).SingleOrDefault
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMaterialeJson() As List(Of JsonDto)
        Try
            Return (From mat In ObjDataContext.Materiales Select mat Order By mat.DescrizioneBreve Ascending _
                                                Select New JsonDto(mat.Codice, mat.DescrizioneBreve)).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMaterialeByMetodo(ByVal IdMetodo As String) As List(Of JsonDto)
        Try
            Return (From mat In ObjDataContext.Metodos Join age_met_mat In ObjDataContext.Agente_Metodo_Materiales _
                             On mat.id Equals age_met_mat.IdMateriale _
                                            Where age_met_mat.IdMetodo = IdMetodo _
                                            Select mat Order By mat.DescrizioneBreve Ascending _
                             Select New JsonDto(mat.Codice, mat.DescrizioneBreve)).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddMateriale(ByVal localtable As Materiale) As Integer
        Try
            ObjDataContext.Materiales.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Sub DeleteMateriale(ByVal idMateriale As Integer)
        Try
            ObjDataContext.Materiales.DeleteOnSubmit( _
                (From mat In ObjDataContext.Materiales _
                 Where mat.id = idMateriale).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Sub UpdateMAteriale(ByVal LocalTable As Materiale)
        Try
            ObjDataContext.Materiales.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As Exception
            Throw ex

        End Try
    End Sub

#End Region

#Region "Metodo"
    Public Function GetAllMetodo() As List(Of Metodo)
        Try
            Return (From met In ObjDataContext.Metodos)
        Catch ex As Exception
            Throw ex

        End Try
    End Function
    Public Function GetAllMetodoList() As List(Of Metodo)
        Try
            Return (From met In ObjDataContext.Metodos Select met Order By met.Descrizione).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMetodoById(ByVal id As Integer) As Metodo
        Try
            Return (From met In ObjDataContext.Metodos Where met.id = id).SingleOrDefault
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMetodoJson() As List(Of JsonDto)

        Try
            Return (From met In ObjDataContext.Metodos Select met Order By met.DescrizioneBreve Ascending _
                                                Select New JsonDto(met.Codice, met.DescrizioneBreve)).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddMetodo(ByVal localtable As Metodo) As Integer
        Try
            ObjDataContext.Metodos.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteMetodo(ByVal idMetodo As Integer)
        Try
            ObjDataContext.Materiales.DeleteOnSubmit( _
                (From met In ObjDataContext.Materiales _
                 Where met.id = idMetodo).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateMetodo(ByVal LocalTable As Metodo)
        Try
            ObjDataContext.Metodos.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
#End Region

#Region "Agente_Eziologico"
    Public Function GetAllAgenteList() As List(Of Agente_Eziologico)
        Try
            Return (From age In ObjDataContext.Agente_Eziologicos Select age Order By age.DescrizioneBreve).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAgenteById(ByVal id As Integer) As Agente_Eziologico
        Try
            Return (From age In ObjDataContext.Agente_Eziologicos Where age.id = id).SingleOrDefault
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgenteJson() As List(Of JsonDto)
        Try
            Return (From age In ObjDataContext.Agente_Eziologicos Select age Order By age.DescrizioneBreve Ascending _
                                                Select New JsonDto(age.Codice, age.Descrizione)).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgente() As Table(Of Agente_Eziologico)
        Try
            Return (From age In ObjDataContext.Agente_Eziologicos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente(ByVal localtable As Agente_Eziologico) As Integer
        Try
            ObjDataContext.Agente_Eziologicos.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente(ByVal idAgente As Integer)
        Try
            ObjDataContext.Agente_Eziologicos.DeleteOnSubmit( _
                (From age In ObjDataContext.Agente_Eziologicos _
                 Where age.id = idAgente).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateAgente(ByVal LocalTable As Agente_Eziologico)
        Try
            ObjDataContext.Agente_Eziologicos.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetAgenteByIdMalattia(ByVal idMalattia As Integer) As List(Of JsonDto)
        Try
            Return (From age In ObjDataContext.Agente_Malattias Join agente In ObjDataContext.Agente_Eziologicos On age.CodiceAgente Equals agente.Codice
                            Where age.IdMalattia = idMalattia Select New JsonDto(agente.Codice, agente.Descrizione)).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Esame"
    Public Function GetAllEsami() As Table(Of Esami)
        Try
            Return (From esa In ObjDataContext.Esamis)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllEsamiList() As List(Of Esami)
        Try
            Return (From esa In ObjDataContext.Esamis).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddEsame(ByVal localtable As Esami) As Integer
        Try
            ObjDataContext.Esamis.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteEsame(ByVal idEsame As Integer)
        Try
            ObjDataContext.Esamis.DeleteOnSubmit( _
                (From es In ObjDataContext.Esamis _
                 Where es.id = idEsame).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateEsame(ByVal LocalTable As Esami)
        Try
            ObjDataContext.Esamis.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
#End Region

#Region "Agente_Metodo_Materiale"
    Public Function GetAllAgente_Metodo_Materiale() As Table(Of Agente_Metodo_Materiale)
        Try
            Return (From esa In ObjDataContext.Agente_Metodo_Materiales)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgente_Metodo_MaterialeList() As List(Of Agente_Metodo_Materiale)
        Try
            Return (From esa In ObjDataContext.Agente_Metodo_Materiales).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente_Metodo_Materiale(ByVal localtable As Agente_Metodo_Materiale) As Integer
        Try
            ObjDataContext.Agente_Metodo_Materiales.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente_Metodo_Materiale(ByVal id As Integer)
        Try
            ObjDataContext.Agente_Metodo_Materiales.DeleteOnSubmit( _
                (From es In ObjDataContext.Agente_Metodo_Materiales _
                 Where es.id = id).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Public Function GetViewAgente_Metodo_Materiale() As List(Of ViewAgenteMetodoMaterialeResult)
        Try
            Return (From esa In ObjDataContext.ViewAgenteMetodoMateriale).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Sub UpdateAgente_Metodo_Materiale(ByVal LocalTable As Agente_Metodo_Materiale)
        Try
            ObjDataContext.Agente_Metodo_Materiales.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

#Region "Veicolo"
    Public Function GetAllVeicoloList() As List(Of Veicolo)
        Try
            Return (From vei In ObjDataContext.Veicolos Select vei Order By vei.DescrizioneBreve).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetVeicoloById(ByVal id As Integer) As Veicolo
        Try
            Return (From vei In ObjDataContext.Veicolos Where vei.id = id).SingleOrDefault
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllVeicoloJson() As List(Of JsonDto)
        Try
            Return (From vei In ObjDataContext.Veicolos Select vei Order By vei.DescrizioneBreve Ascending _
                                                Select New JsonDto(vei.Codice, vei.DescrizioneBreve)).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllVeicolo() As Table(Of Veicolo)
        Try
            Return (From vei In ObjDataContext.Veicolos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddVeicolo(ByVal localtable As Veicolo) As Integer
        Try
            ObjDataContext.Veicolos.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteVeicolo(ByVal idAgente As Integer)
        Try
            ObjDataContext.Veicolos.DeleteOnSubmit( _
                (From vei In ObjDataContext.Veicolos _
                 Where vei.id = idAgente).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateVeicolo(ByVal LocalTable As Veicolo)
        Try
            ObjDataContext.Veicolos.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub


#End Region

#Region "Agente_Veicolo"
    Public Function GetAllAgente_Veicolo() As Table(Of Agente_Veicolo)
        Try
            Return (From esa In ObjDataContext.Agente_Veicolos)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgente_VeicoloList() As List(Of Agente_Veicolo)
        Try
            Return (From esa In ObjDataContext.Agente_Veicolos).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente_Veicolo(ByVal localtable As Agente_Veicolo) As Integer
        Try
            ObjDataContext.Agente_Veicolos.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente_Veicolo(ByVal id As Integer)
        Try
            ObjDataContext.Agente_Veicolos.DeleteOnSubmit( _
                (From age In ObjDataContext.Agente_Veicolos _
                 Where age.id = id).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetViewAgente_Veicolo() As List(Of ViewAgenteVeicoloResult)
        Try
            Return (From age In ObjDataContext.ViewAgenteVeicolo).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateAgente_Veicolo(ByVal LocalTable As Agente_Veicolo)
        Try
            ObjDataContext.Agente_Veicolos.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region


#Region "Agente_Malattia"
    Public Function GetAllAgente_Malattia() As Table(Of Agente_Malattia)
        Try
            Return (From age In ObjDataContext.Agente_Malattias)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllAgente_MalattiaList() As List(Of Agente_Malattia)
        Try
            Return (From age In ObjDataContext.Agente_Malattias).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddAgente_Malattia(ByVal localtable As Agente_Malattia) As Integer
        Try
            ObjDataContext.Agente_Malattias.InsertOnSubmit(localtable)
            ObjDataContext.SubmitChanges()
            Dim i As Integer
            i = localtable.id
            Return i
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteAgente_Malattia(ByVal id As Integer)
        Try
            ObjDataContext.Agente_Malattias.DeleteOnSubmit( _
                (From age In ObjDataContext.Agente_Malattias _
                 Where age.id = id).Single)
            ObjDataContext.SubmitChanges()
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetViewAgente_Malattia() As List(Of ViewAgenteMalattiaResult)
        Try
            Return (From age In ObjDataContext.ViewAgenteMalattia).ToList
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateAgente_Malattia(ByVal LocalTable As Agente_Malattia)
        Try
            ObjDataContext.Agente_Malattias.Attach(LocalTable)
            ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
            ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class
