Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq


Public Class DalMalattie




    Public Function GetAllMalattieManager() As List(Of Malattia)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Select mal Order By mal.DescrizioneBreve Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMalattieList() As List(Of Malattia)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Order By mal.DescrizioneBreve Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieValideList() As List(Of Malattia)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Select mal Where mal.valida = "si" Order By mal.DescrizioneBreve Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function GetAuthMallatieList(ByVal username As String) As List(Of Malattia)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.MalattieGetAuth(username).ToList
                '                Return (From mal In ObjDataContext.Malattias Where mal.DescrizioneBreve.StartsWith(Str) And mal.valida = "si" Select mal Order By mal.DescrizioneBreve Ascending).ToList

            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieList(ByVal str As String) As List(Of Malattia)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.DescrizioneBreve.StartsWith(str) And mal.valida = "si" Select mal Order By mal.DescrizioneBreve Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieFocolaioList() As List(Of Malattia)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.PrevistoFocolaio = "Si" And mal.valida = "si" Select mal Order By mal.DescrizioneBreve Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function retrieveClassification(ByVal idMalattia As Integer) As List(Of Malattie_Classificazione_Caso)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Malattie_Classificazione_Casos Select tab Where tab.idMalattia = idMalattia Order By tab.ordine).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMalattieNoFocolaioList() As List(Of Malattia)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.PrevistoFocolaio = "No" And mal.valida = "si" Select mal Order By mal.DescrizioneBreve Ascending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieJson() As List(Of JsonDto)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Order By mal.DescrizioneBreve Ascending Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieValideJson() As List(Of JsonDto)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.valida = "si" Order By mal.DescrizioneBreve Ascending Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieVisualizzabiliJson() As List(Of JsonDto)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.visualizzabile = "si" Order By mal.DescrizioneBreve Ascending Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieJsonByLevel(ByVal gruppo As String, ByVal username As String) As List(Of JsonDto)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Join gru In ObjDataContext.Malattie_Gruppos _
                        On mal.id_malattia Equals gru.idMalattia _
                        Join user In ObjDataContext.Utenti_Gruppi_Malatties _
                        On user.id_Malattie_gruppo Equals gru.idGruppo _
                        Where mal.valida = "si" And mal.gruppo = gruppo And user.username = username _
                        Order By mal.DescrizioneBreve Ascending Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CanChange(ByVal idmalattia As String) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.id_malattia = idmalattia And mal.modificabile = "si" Order By mal.DescrizioneBreve).Count
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InfoMalattia(ByVal idmalattia As String) As Malattia
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.id_malattia = idmalattia And mal.modificabile = "si" Order By mal.DescrizioneBreve).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllMalattieNoFocolaioJson() As List(Of JsonDto)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.PrevistoFocolaio = "No" And mal.valida = "si" Order By mal.DescrizioneBreve Ascending Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieFocolaioJson() As List(Of JsonDto)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.PrevistoFocolaio = "Si" And mal.valida = "si" Order By mal.DescrizioneBreve Ascending Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function GetAllMalattieMibJson() As List(Of JsonDto)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.ModuloMib.ToLower = "si" And mal.valida = "si" Order By mal.DescrizioneBreve Ascending Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function getMalattia(ByVal idMalattia As Integer) As Malattia

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Select mal Where mal.id_malattia = idMalattia).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCriteri(ByVal idMalattia As Integer) As Malattie_Criteri
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattie_Criteris Select mal Where mal.idMalattia = idMalattia).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDescrizioneMalattia(ByVal idMalattia As Integer) As String
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From mal In ObjDataContext.Malattias Where mal.id_malattia = idMalattia Select mal.DescrizioneBreve).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMalattiaByIdAgenteJson(ByVal codiceAgente As String) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From age In ObjDataContext.Agente_Malattias Join mal In ObjDataContext.Malattias On age.IdMalattia Equals mal.id_malattia
                                Where age.CodiceAgente = codiceAgente Select New JsonDto(mal.id_malattia, mal.DescrizioneBreve)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Add(ByVal localtable As Malattia) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Malattias.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal LocalTable As Malattia)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Malattias.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub

    Public Sub UpdateClassificazione(ByVal LocalTable As Malattie_Classificazione_Caso)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Malattie_Classificazione_Casos.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub


    Public Sub UpdateCriterio(ByVal LocalTable As Malattie_Criteri)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Malattie_Criteris.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetAgentiJsonByIdMalattia(ByVal idMalattia As Integer) As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From age In ObjDataContext.Agente_Eziologicos Join mal In ObjDataContext.Agente_Malattias On age.Codice Equals mal.CodiceAgente
                                Where mal.IdMalattia = idMalattia Select New JsonDto(age.Codice, age.Descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAllGruppiMalattieJson() As List(Of JsonDto)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Malattie_Definizione_Gruppos Select New JsonDto(tab.id, tab.Descrizione)).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
