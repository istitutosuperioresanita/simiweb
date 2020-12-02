Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalNotifica
    '  Private _Abilitato As Boolean = False
    Public Function ExportMinistero_classe_2(ByVal dataDa As Nullable(Of Date), _
                                        ByVal dataA As Nullable(Of Date), _
                                        ByVal idRegione As String) As List(Of Notifica_Esporta_Classe_2Result)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

 
                Return ObjDataContext.Notifica_Esporta_Classe_2(idRegione, dataDa, dataA).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ExportMinistero_classe_3(ByVal dataDa As Nullable(Of Date), _
                                    ByVal dataA As Nullable(Of Date), _
                                    ByVal idRegione As String) As List(Of Notifica_Esporta_Classe_3Result)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Notifica_Esporta_Classe_3(idRegione, dataDa, dataA).ToList
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportMinistero_classe_4(ByVal dataDa As Nullable(Of Date), _
                                    ByVal dataA As Nullable(Of Date), _
                                    ByVal idRegione As String) As List(Of Notifica_Esporta_Classe_4Result)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Notifica_Esporta_Classe_4(idRegione, dataDa, dataA).ToList
            End Using

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddSegnalazione(ByVal localtable As Notifica) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                '  ObjDataContext.ObjectTrackingEnabled = _Abilitato                
                ObjDataContext.Notificas.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                i = localtable.id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Cambiastato(ByVal idNotifica As Integer, ByVal stato As String)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_cambia_stato(idNotifica, stato)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteExtra(ByVal idNotifica As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Delete_Extra(idNotifica)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function getById(ByVal idNotifica As Integer) As Notifica
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Dim dlo As DataLoadOptions = New DataLoadOptions
                dlo.LoadWith(Of Notifica)(Function(n As Notifica) n.Anagrafica)
                dlo.LoadWith(Of Notifica)(Function(n As Notifica) n.Clinica)
                dlo.LoadWith(Of Notifica)(Function(n As Notifica) n.Notifica_MIB)
                ObjDataContext.LoadOptions = dlo
                Return (From tab In ObjDataContext.Notificas Select tab Where tab.id = idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddNotifica(ByVal localtable As Notifica) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notificas.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                i = localtable.id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateNotifica(ByVal LocalTable As Notifica)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notificas.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)


                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetInfo(ByVal idNotifica As Integer) As Notifica_InfoResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return ObjDataContext.Notifica_Info(idNotifica).SingleOrDefault

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNotificaBase(ByVal idNotifica As Integer) As Notifica_ViewResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return ObjDataContext.Notifica_View(idNotifica).SingleOrDefault

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNotificaDoppi(ByVal cognome As String, _
                                     ByVal nome As String, _
                                     ByVal dataNascita As Nullable(Of Date), _
                                     ByVal IdASlNotifica As String, _
                                     ByVal IdAslResidenza As String, _
                                     ByVal IdRegione As String) As List(Of Notifica_lista_doppiResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return ObjDataContext.Notifica_lista_doppi(cognome, _
                                                           nome, _
                                                            dataNascita, _
                                                           IdASlNotifica, _
                                                           IdAslResidenza, _
                                                           IdRegione).ToList




            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNotificaLista(ByVal cognome As String, _
                                     ByVal nome As String, _
                                     ByVal dataNascita As Nullable(Of Date), _
                                     ByVal codicefiscale As String, _
                                     ByVal idmalattia As Nullable(Of Integer), _
                                     ByVal idComuneResidenza As String, _
                                     ByVal idComunePrimiSintomi As String, _
                                     ByVal stato As String, _
                                     ByVal dataNotificaDa As Nullable(Of Date), _
                                     ByVal dataNotificaA As Nullable(Of Date), _
                                     ByVal dataSegnalazioneDa As Nullable(Of Date), _
                                     ByVal dataSegnalazioneA As Nullable(Of Date), _
                                     ByVal IdASlNotifica As String, _
                                     ByVal IdAslResidenza As String, _
                                     ByVal IdRegione As String, _
                                     ByVal IdScheda As Nullable(Of Integer), _
                                     ByVal username As String, _
                                     ByVal usernameMedico As String) As List(Of Notifica_listaResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return ObjDataContext.Notifica_lista(cognome, _
                                                     nome, _
                                                     dataNascita, _
                                                     codicefiscale, _
                                                     idmalattia, _
                                                     idComuneResidenza, _
                                                     idComunePrimiSintomi, _
                                                     stato, _
                                                     dataNotificaDa, _
                                                     dataNotificaA, _
                                                     dataSegnalazioneDa, _
                                                     dataSegnalazioneA, _
                                                     IdASlNotifica, _
                                                     IdAslResidenza, _
                                                     IdRegione,
                                                     IdScheda, _
                                                     username, _
                                                     usernameMedico).ToList


            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNotificaListaRegione(ByVal cognome As String, _
                                 ByVal nome As String, _
                                 ByVal dataNascita As Nullable(Of Date), _
                                 ByVal codicefiscale As String, _
                                 ByVal idmalattia As Nullable(Of Integer), _
                                 ByVal idComuneResidenza As String, _
                                 ByVal idComunePrimiSintomi As String, _
                                 ByVal stato As String, _
                                 ByVal dataNotificaDa As Nullable(Of Date), _
                                 ByVal dataNotificaA As Nullable(Of Date), _
                                 ByVal dataSegnalazioneDa As Nullable(Of Date), _
                                 ByVal dataSegnalazioneA As Nullable(Of Date), _
                                 ByVal IdASlNotifica As String, _
                                 ByVal IdAslResidenza As String, _
                                 ByVal IdRegione As String, _
                                 ByVal IdScheda As Nullable(Of Integer), _
                                 ByVal username As String, _
                                 ByVal usernameMedico As String) As List(Of Notifica_lista_regioneResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return ObjDataContext.Notifica_lista_regione(cognome, _
                                                     nome, _
                                                     dataNascita, _
                                                     codicefiscale, _
                                                     idmalattia, _
                                                     idComuneResidenza, _
                                                     idComunePrimiSintomi, _
                                                     stato, _
                                                     dataNotificaDa, _
                                                     dataNotificaA, _
                                                     dataSegnalazioneDa, _
                                                     dataSegnalazioneA, _
                                                     IdASlNotifica, _
                                                     IdAslResidenza, _
                                                     IdRegione,
                                                     IdScheda, _
                                                     username, _
                                                     usernameMedico).ToList


            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetElenchi(ByVal sql As String) As List(Of Notifica_ElenchiResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Dim rs As IEnumerable(Of Notifica_ElenchiResult) = ObjDataContext.ExecuteQuery(Of Notifica_ElenchiResult)(sql.ToString)
                Return rs.ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function ExportDataByAsl(Optional ByVal stato As String = Nothing, _
    '                                    Optional ByVal malattia As Nullable(Of Integer) = Nothing, _
    '                                    Optional ByVal ComResidenza As String = Nothing, _
    '                                    Optional ByVal DataNotificaDa As Nullable(Of Date) = Nothing, _
    '                                    Optional ByVal DataNotificaA As Nullable(Of Date) = Nothing, _
    '                                    Optional ByVal DataSegnalazioneDa As Nullable(Of Date) = Nothing, _
    '                                    Optional ByVal DataSegnalazioneA As Nullable(Of Date) = Nothing, _
    '                                    Optional ByVal DataSintomiDa As Nullable(Of Date) = Nothing, _
    '                                    Optional ByVal DataSintomiA As Nullable(Of Date) = Nothing, _
    '                                    Optional ByVal AslNotifica As String = Nothing, _
    '                                    Optional ByVal AslResidenza As String = Nothing) As List(Of Notifica_EsportaResult)

    '    Try
    '        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
    '            Return ObjDataContext.Notifica_Esporta(malattia, _
    '                                                    ComResidenza, _
    '                                                    Nothing, _
    '                                                    stato, _
    '                                                    DataNotificaDa, _
    '                                                    DataNotificaA, _
    '                                                    DataSegnalazioneDa, _
    '                                                    DataSegnalazioneA, _
    '                                                    DataSintomiDa, _
    '                                                    DataSintomiA, _
    '                                                    AslNotifica, _
    '                                                    AslResidenza).ToList
    '        End Using
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function
    Public Function ExportData() As List(Of Notifica_EsportaResult)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Notifica_Esporta(Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing, _
                                                       Nothing).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Function ExportMinistero(ByVal sql As String) As List(Of esportazioneResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Dim rs As IEnumerable(Of esportazioneResult) = ObjDataContext.ExecuteQuery(Of esportazioneResult)(sql.ToString)
                Return rs.ToList
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
    Public Sub UpdateInfo(ByVal idNotifica As Integer, _
                            ByVal datanotifica As Nullable(Of Date), _
                            ByVal datasegnalazione As Nullable(Of Date), _
                            ByVal stato As String, _
                            ByVal idReferenteAsl As Integer,
                            ByVal medicoSegnalatore As String, _
                            ByVal idAslNotifica As String, _
                            ByVal idMalattia As String, _
                            ByVal origineSegnalzione As String)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_AggiornaInfo(idNotifica, _
                                                    datanotifica, _
                                                    datasegnalazione, _
                                                    stato, _
                                                    idReferenteAsl, _
                                                    medicoSegnalatore, _
                                                    idAslNotifica, _
                                                    idMalattia, _
                                                    origineSegnalzione)
            End Using
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Sub UpdateAslResidenza(ByVal idnotifica As Integer, ByVal idComune As String)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Try
                ObjDataContext.Notifica_AggiornaAslResidenza(idnotifica, idComune)
            Catch ex As Exception
                Throw ex
            End Try

        End Using
    End Sub
    Public Function ExportNotifica(ByVal idRegione As String, _
                                   ByVal idAsl As String, _
                                   ByVal anno As Nullable(Of Integer), _
                                   ByVal username As String, _
                                   ByVal usernameMedico As String) As List(Of Notifica_exportResult)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Return ObjDataContext.Notifica_export(idRegione, idAsl, anno, username, usernameMedico).ToList
        End Using
    End Function
#Region "Anagrafica"
    Public Function AddAnagrafica(ByVal localtable As Anagrafica) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Anagraficas.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateAnagrafica(ByVal LocalTable As Anagrafica)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Anagraficas.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Sub UpdateEta(ByVal idNotifica As Integer, ByVal eta As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Anagrafica_aggiornaEta(idNotifica, eta)
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetAnagraficaByIdNotifica(ByVal idNotifica As Integer) As Anagrafica
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From ana In ObjDataContext.Anagraficas Select ana Where ana.idNotifica = idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAnagraficaView(ByVal idNotifica As Integer) As Anagrafica_ViewResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return (From ana In ObjDataContext.Anagrafica_View(idNotifica) Select ana).SingleOrDefault

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportAnagrafica(ByVal idRegione As String, _
                                     ByVal idAsl As String, _
                                     ByVal anno As Nullable(Of Integer), _
                                     ByVal username As String, _
                                     ByVal usernameMedico As String) As List(Of Anagrafica_exportResult)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Return ObjDataContext.Anagrafica_export(idRegione, idAsl, anno, username, usernameMedico).ToList
        End Using
    End Function

#End Region

#Region "Clinica"
    Public Function AddClinica(ByVal localtable As Clinica) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Clinicas.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateClinica(ByVal LocalTable As Clinica)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Clinicas.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetClinicaByIdNotifica(ByVal idNotifica As Integer) As Clinica
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Clinicas Select tab Where tab.IdNotifica = idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetClinicaView(ByVal idNotifica As Integer) As Clinica_ViewResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return (From ana In ObjDataContext.Clinica_View(idNotifica) Select ana).SingleOrDefault

            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportClinica(ByVal idRegione As String, _
                                  ByVal idAsl As String, _
                                  ByVal anno As Nullable(Of Integer), _
                                  ByVal username As String, _
                                  ByVal usernameMedico As String) As List(Of Clinica_exportResult)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Return ObjDataContext.Clinica_export(idRegione, idAsl, anno, username, usernameMedico).ToList
        End Using
    End Function
#End Region

#Region "Esami"
    Public Function GetEsamiList(ByVal idNotifica As Integer) As List(Of Esami_ViewResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return (From tab In ObjDataContext.Esami_View(idNotifica) Select tab).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddEsame(ByVal localtable As Notifica_Esami) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Esamis.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteEsame(ByVal id As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Esamis.DeleteOnSubmit( _
                    (From tab In ObjDataContext.Notifica_Esamis _
                    Where tab.id = id).Single)
                ObjDataContext.SubmitChanges()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "Fattori"
    Public Function GetTbcFAttori(ByVal idNotifica As Integer) As Notifica_Tbc_Fattori
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Notifica_Tbc_Fattoris Select tab Where tab.idNotifica = idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddTbcFattori(ByVal localtable As Notifica_Tbc_Fattori) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Tbc_Fattoris.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateTbcFattori(ByVal LocalTable As Notifica_Tbc_Fattori)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Tbc_Fattoris.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetTbc_View(ByVal idNotifica As Integer) As Notifica_Tbc
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return (From tbc In ObjDataContext.Notifica_view_tbc(idNotifica) Select tbc).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Malaria"
    Public Function AddMalaria(ByVal localtable As Notifica_Malaria) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Malarias.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                ' i = localtable.Id
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateMalaria(ByVal LocalTable As Notifica_Malaria)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Notifica_Malarias.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetMalariaView(ByVal idNotifica As Integer) As Notifica_view_MalariaResult
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                Return (From tbc In ObjDataContext.Notifica_view_Malaria(idNotifica) Select tbc).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetMalaria(ByVal idNotifica As Integer) As Notifica_Malaria
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Notifica_Malarias Select tab Where tab.idNotifica = idNotifica).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function


#End Region


End Class
