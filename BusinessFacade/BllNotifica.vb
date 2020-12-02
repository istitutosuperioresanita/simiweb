Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess


Public Class BllNotifica
    Inherits BizClass
    Private _mobjdataAccess As New DalNotifica
    Private _MobjBllMalattie As New BllMalattie
    Private _mobjGeografiche As New BllGeografiche
    Private _mobjMib As New BllMib
    Private mobjdataMail As New DalMessaggio
    Private _username As String
    Private _record As String
    Private _DataNascita As Nullable(Of Date) = Nothing
    Private _DataPrimiSintomi As Nullable(Of Date) = Nothing
    Private _DataSegnalazione As Nullable(Of Date) = Nothing
    Private _DataNotifica As Nullable(Of Date) = Nothing


    Public Property username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property record() As String
        Get
            Return _record
        End Get
        Set(ByVal value As String)
            _record = value
        End Set
    End Property
    Public Property DataNascita As Nullable(Of Date)
        Get
            Return _DataNascita
        End Get
        Set(value As Nullable(Of Date))
            _DataNascita = value
        End Set
    End Property
    Public Property DataPrimiSintomi As Nullable(Of Date)
        Get
            Return _DataPrimiSintomi
        End Get
        Set(value As Nullable(Of Date))
            _DataPrimiSintomi = value
        End Set
    End Property
    Public Property DataSegnalazione As Nullable(Of Date)
        Get
            Return _DataSegnalazione
        End Get
        Set(value As Nullable(Of Date))
            _DataSegnalazione = value
        End Set
    End Property
    Public Property DataNotifica As Nullable(Of Date)
        Get
            Return _DataNotifica
        End Get
        Set(value As Nullable(Of Date))
            _DataNotifica = value
        End Set
    End Property

    Public Function GetInfoNotifica(ByVal idNotifica As Integer) As Notifica_InfoResult
        Try
            Return _mobjdataAccess.GetInfo(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetNotificaBase(ByVal idNotifica As Integer) As Notifica_ViewResult
        Try
            Return _mobjdataAccess.GetNotificaBase(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetById(ByVal idNotifica As Integer) As Notifica
        Try
            Return _mobjdataAccess.getById(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddSegnalazione(ByVal localtable As Notifica) As Integer
        Try


            Dim mobjProfilo As New DalProfilo
            Dim eta As Nullable(Of Integer) = Nothing

            Dim profilo As Utenti_Profilo = mobjProfilo.GetByUsername(localtable.username)

            If localtable.AslDiNotifica Is Nothing Then
                localtable.AslDiNotifica = profilo.idAsl
            End If

            localtable.idRegione = profilo.idRegione
            'localtable.Clinica.Classificazione = ClassificaCaso(localtable.Clinica.IdMalattia, _
            '                                      localtable.Clinica.CriterioClinico, _
            '                                      localtable.Clinica.CriterioEpidemiologico, _
            '                                      localtable.Clinica.CriterioLaboratorio)

            localtable.Clinica.Classificazione = "non classificato"
            eta = BizClass.GetAge(localtable.Anagrafica.DataNascita, localtable.Clinica.DataPrimiSintomi)
            localtable.Anagrafica.Eta = eta
            If localtable.Anagrafica.IdComuneResidenza <> "" Then
                localtable.AslDiResidenza = _mobjGeografiche.GetCodiceAslByComune(localtable.Anagrafica.IdComuneResidenza)
            End If
            Dim id As Integer

            id = _mobjdataAccess.AddSegnalazione(localtable)



            Dim info As Notifica_InfoResult = _mobjdataAccess.GetInfo(id)
            If BllConfig.retrieveTracingStatus = True Then

                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                With audit
                    .idRecord = id
                    .sezione = "Notifica"
                    .tipo_operazione = "Inserimento"
                    .categoria = "Notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.AslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then
                            '  Dim audit As New Audit
                            With audit
                                .idRecord = id
                                .sezione = "Notifica"
                                .tipo_operazione = "Inserimento"
                                .categoria = "Notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If
            End If
            '   If _MobjBllMalattie.isMib(localtable.Clinica.IdMalattia) Then

            'BllExtService.SegnalazioneToMib(localtable)

            'End If
            If localtable.Clinica.IdMalattia = "1001" Then 'meningococco
                Dim testoMail As String = "Inserita Nuova malattia Batterica Invasiva da Meningocco ID : " + localtable.id.ToString + "----" + localtable.Anagrafica.Nome + " " + localtable.Anagrafica.Cognome
                InviaMail(testoMail, True, info.regione)
                '  BllExtService.UpdateMibToMib(localtable)
            End If
            Return localtable.id
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub UpdateAnagrafica(ByVal localtable As Anagrafica, Optional ByVal idMalattia As Integer = 0)
        Try

            _mobjdataAccess.UpdateAnagrafica(localtable)
            _mobjdataAccess.UpdateAslResidenza(localtable.idNotifica, localtable.IdComuneResidenza)
            _mobjdataAccess.UpdateEta(localtable.idNotifica, BizClass.GetAge(DataNascita, DataPrimiSintomi))


            Dim info As Notifica_InfoResult = _mobjdataAccess.GetInfo(localtable.idNotifica)




            If BllConfig.retrieveTracingStatus = True Then

                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                Dim id As Integer

                id = localtable.idNotifica
                With audit
                    .idRecord = id
                    .sezione = "Anagrafica"
                    .tipo_operazione = "aggiornamento"
                    .categoria = "Notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.idAslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then

                            With audit
                                .idRecord = localtable.idNotifica
                                .sezione = "Anagrafica"
                                .tipo_operazione = "aggiornamento"
                                .categoria = "Notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If
            End If
            '###########Chiamata Web Service

            'If _MobjBllMalattie.isMib(idMalattia) Then
            '    Dim InfoNotifica As Notifica_InfoResult = _mobjdataAccess.GetInfo(localtable.idNotifica)
            '    If InfoNotifica.stato = "Notifica" Then
            '        Dim service As New BllExtService
            '        service.UpdateAnagraficaToMib(localtable)
            '    End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetNotificaDoppi(Optional ByVal cognome As String = Nothing, _
                             Optional ByVal nome As String = Nothing, _
                             Optional ByVal dataNascita As Nullable(Of Date) = Nothing, _
                             Optional ByVal idAslNotifica As String = Nothing, _
                             Optional ByVal idAslResidenza As String = Nothing, _
                             Optional ByVal idRegione As String = Nothing) As Object
        Try


            Dim lstDoppi As List(Of Notifica_lista_doppiResult) = _mobjdataAccess.GetNotificaDoppi(cognome, _
                                                    nome, _
                                                    dataNascita, _
                                                    idAslNotifica, _
                                                    idAslResidenza, _
                                                    idRegione)
            Return New With { _
 Key .Result = "OK", _
 Key .Records = lstDoppi _
}



        Catch ex As Exception
            Return New With { _
 Key .Result = "OK", _
 Key .Message = ex.Message _
}



        End Try
    End Function
    Public Sub UpdateNotifica(ByVal localtable As Notifica)
        Try
            _mobjdataAccess.UpdateNotifica(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub CambiaStato(ByVal idNotifica As Integer, ByVal stato As String)
        Try
            _mobjdataAccess.Cambiastato(idNotifica, stato)
            'TrasmettiNotifica(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub TrasmettiNotifica(ByVal idnotifica As Integer)
        Try
           
        Catch ex As Exception

        End Try
    End Sub
    Public Sub UpdateInfo(ByVal idNotifica As Integer, _
                        ByVal datanotifica As Nullable(Of Date), _
                        ByVal datasegnalazione As Nullable(Of Date), _
                        ByVal stato As String, _
                        ByVal idReferenteAsl As Integer,
                        ByVal medicoSegnalatore As String, _
                        ByVal idAslNotifica As String, _
                        Optional ByVal idMalattia As String = Nothing, _
                        Optional ByVal origineSegnalazione As String = Nothing, _
                        Optional ByVal malattiaCambiata As Boolean = Nothing)

        Try


            _mobjdataAccess.UpdateInfo(idNotifica, _
                                         datanotifica, _
                                         datasegnalazione, _
                                         stato, _
                                         idReferenteAsl, _
                                         medicoSegnalatore,
                                         idAslNotifica, _
                                         idMalattia, _
                                         origineSegnalazione)

            If malattiaCambiata = True Then
                _mobjdataAccess.DeleteExtra(idNotifica)
            End If

            Dim info As Notifica_InfoResult = _mobjdataAccess.GetInfo(idNotifica)

            Dim id As Integer
            id = idNotifica
            If BllConfig.retrieveTracingStatus = True Then
                id = idNotifica
                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                With audit
                    .idRecord = id
                    .sezione = "Info"
                    .tipo_operazione = "aggiornamento"
                    .categoria = "Notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now

                End With
                mobjAudit.Add(audit)
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.idAslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then


                            With audit
                                .idRecord = id
                                .sezione = "Info"
                                .tipo_operazione = "aggiornamento"
                                .categoria = "Notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Public Function ExportData() As List(Of Notifica_EsportaResult)
        Try
            Return _mobjdataAccess.ExportData
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportAnagrafica(Optional ByVal idRegione As String = Nothing, _
                                     Optional ByVal idAsl As String = Nothing, _
                                     Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                                     Optional ByVal username As String = Nothing, _
                                     Optional ByVal usernameMedico As String = Nothing) As List(Of Anagrafica_exportResult)
        Try
            Return _mobjdataAccess.ExportAnagrafica(idRegione, idAsl, anno, username, usernameMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportNotifica(Optional ByVal idRegione As String = Nothing, _
                                   Optional ByVal idAsl As String = Nothing, _
                                   Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                                   Optional ByVal username As String = Nothing, _
                                   Optional ByVal usernameMedico As String = Nothing) As List(Of Notifica_exportResult)
        Try
            Return _mobjdataAccess.ExportNotifica(idRegione, idAsl, anno, username, usernameMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportClinica(Optional ByVal idRegione As String = Nothing, _
                                  Optional ByVal idAsl As String = Nothing, _
                                  Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                                    Optional ByVal username As String = Nothing, _
                                   Optional ByVal usernameMedico As String = Nothing) As List(Of Clinica_exportResult)
        Try
            Return _mobjdataAccess.ExportClinica(idRegione, idAsl, anno, username, usernameMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteExtra(ByVal idNotifica As Integer)
        Try
            _mobjdataAccess.DeleteExtra(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ExportMinistero_classe_2(ByVal dataDa As Nullable(Of Date), _
                                        ByVal dataA As Nullable(Of Date), _
                                        ByVal idRegione As String) As List(Of Notifica_Esporta_Classe_2Result)
        If IsNothing(dataDa) Then
            dataDa = "01/01/1900"
        End If
        If IsNothing(dataA) Then
            dataDa = Now.ToShortDateString
        End If
        Try
            Return _mobjdataAccess.ExportMinistero_classe_2(dataDa, dataA, idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportMinistero_classe_3(ByVal dataDa As Nullable(Of Date), _
                                            ByVal dataA As Nullable(Of Date), _
                                            ByVal idRegione As String) As List(Of Notifica_Esporta_Classe_3Result)
        If IsNothing(dataDa) Then
            dataDa = "01/01/1900"
        End If
        If IsNothing(dataA) Then
            dataDa = Now.ToShortDateString
        End If
        Try
            Return _mobjdataAccess.ExportMinistero_classe_3(dataDa, dataA, idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportMinistero_classe_4(ByVal dataDa As Nullable(Of Date), _
                                        ByVal dataA As Nullable(Of Date), _
                                        ByVal idRegione As String) As List(Of Notifica_Esporta_Classe_4Result)
        If IsNothing(dataDa) Then
            dataDa = "01/01/1900"
        End If
        If IsNothing(dataA) Then
            dataDa = Now.ToShortDateString
        End If
        Try
            Return _mobjdataAccess.ExportMinistero_classe_4(dataDa, dataA, idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportMinistero(ByVal dataDa As Nullable(Of Date), _
                                    ByVal dataA As Nullable(Of Date), _
                                    ByVal idRegione As String) As List(Of esportazioneResult)


        If IsNothing(dataDa) Then
            dataDa = "01/01/1900"
        End If

        If IsNothing(dataA) Then
            dataA = Now.ToShortDateString
        End If

        Dim stato As String = "Notifica"
        Dim Criterio As String = "5"



        Dim str As New System.Text.StringBuilder

        str.Append(" Select  ")
        str.Append("  CAST('' as varchar(6)) as numero_record  			 ")                                                             '(6,"")								'NUMERO RECORD 							(1-6)	
        str.Append(" ,CONVERT(varchar(8),dataSegnalazione,112) as datasegnalazione	 ")                                                 '(8,rs("data_segnalazione")) 			'DATA_COMPILAZIONE						(7-14)
        str.Append(" ,CAST(dbo.Geo_Regioni.descrizione as varchar(20)) as denominazione_regione	 ")                                     '(20,rs("regione_asl"))				'REGIONE								(15-34)
        str.Append(" ,CAST(left(dbo.Notifica.idRegione,2) as varchar(2)) as  codice_regione	 ")                                         '(2,rs("codice_regione"))      		'CODICE REGIONE      					(35-36)
        str.Append(" ,CAST(aslProvincie.descrizione as varchar(20)) as provincia_segnalazione	 ")                                     '(20,rs("provincia_segnalazione"))		'PROVINCIA           					(37-56)
        str.Append(" ,CAST(Geo_asl.provincia as varchar(2)) as sigla_provincia		 ")                                                 '(2,rs("siglaProvSegnalazione"))		'SIGLA PROVINCIA       					(57-58)
        str.Append(" ,CAST(aslProvincie.idProvincia as varchar(3)) as 	cod_prov_Seg	 ")                                             '(3,rs("cod_prov_Seg"))				'CODICE PROVINCIA						(59-61)
        str.Append(" ,CAST(Geo_asl.citta as varchar(20)) as citta_asl		 ")                                                         '(20,rs("citta_asl"))					'COMUNE 								(62-61)      
        str.Append(" ,CAST(AslComune.CodiceComune as varchar(6)) as id_comune	 ")                                                     '(6,rs("id_comune"))					 'CODICE COMUNE 							(82-87)
        str.Append(" ,CAST(AslComune.descrizione as varchar(20)) as descrizione_asl	 ")                                                 '(20,rs("descrizione_asl"))			 'USL 									(88-107)       
        str.Append(" ,right(AslDiNotifica,2)	as numero_usl	 ")                                                                     '(2,rs("codice_asl"))   				'NUMERO USL								(108-109)
        str.Append(" ,CAST('' as varchar(3)) as ex_usl		 ")                                                                         '(3,"")   							'EXUSL									(110-112)
        str.Append(" ,CAST(AslDiNotifica as varchar(7))	as codusl ")                                                                    '(7,rs("cod_prov_Seg")& rs("codice_asl")) 							'CODUSL 								(113-119)
        str.Append(" ,CAST('' as varchar(2)) as distretto		 ")                                                                     '(2,"")									'DISTR									(120-121)	
        str.Append(" ,CAST(dbo.Malattie.DescrizioneBreve as varchar(20)) as malattia ")                                                 '(20,rs("malattia"))					'CASO DI 								(122-141) 
        str.Append(" ,CAST(dbo.Malattie.icd9	as varchar(5))		as icd9		 ")                                                     '(5,rs("cod_malattia")) 					'ICD9    								(142-146) 
        str.Append(" ,case when CriterioClinico = CAST('si' as varchar(4)) THEN CAST('1' as varchar(4)) ELSE CAST('' as varchar(4)) END as criterio   ") '(4,CodiceCriterio(rs("criterio")))		' 								(147-150)
        str.Append(" ,'1' as tipo_caso		 ")                                                                                         '(1,rs("TipoCaso")) 'tipo caso			'TIPO CASO 								(151)    
        str.Append(" ,CAST(dbo.notifica.id as varchar(6)) as codice_scheda ")                                                           '(6,rs("id_notifica"))					'CODICE SCHEDA 							(152-157)
        str.Append(" ,CAST(lower(dbo.Notifica_Anagrafica.cognome) as varchar(29)) as cognome	 ")                                     '(29,rs("cognome"))					 'COGNOME 								(158-186)  
        str.Append(" ,CAST(lower(dbo.Notifica_Anagrafica.nome) as varchar(21)) as nome	 ")                                             '(21,rs("nome"))						 'NOME									(187-207)
        str.Append(" ,CAST(sesso as varchar(1)) as sesso				 ")                                                             '(1,rs("sesso"))						  'SESSO 									(208)
        str.Append(" ,CONVERT(varchar(8),dbo.Notifica_Anagrafica.DataNascita,112) as data_nascita ")                                    '(8,rs("data_nascita"))   				'DATA DI NASCITA						(209-216)
        str.Append(" ,CAST(dbo.Notifica_Anagrafica.CodiceFiscale as varchar(19)) as cod_SSN	 ")                                         '(19,rs("cod_SSN"))					  'COD SSN								(217-235)
        str.Append(" ,CASE WHEN dbo.Professioni.CodiceMinistero is null THEN '00'  ")
        str.Append(" 		ELSE	CAST(dbo.Professioni.CodiceMinistero as varchar(2)) END as Professione	 ")                         '(2,rs("professione")) 					'PROFESSIONE							(236-237)
        str.Append(" ,CAST('' as varchar(20)) as altra_professione		 ")                                                             '(20,"")							  'ALTRA PROFESSIONE						(238-257)
        str.Append(" ,CASE dbo.Notifica_Anagrafica.IdNazionalitaCittadinanza  ")
        str.Append(" 		WHEN NULL THEN CAST('' as varchar(1))  ")
        str.Append(" 		WHEN '000' THEN '1' ELSE '2' END as cod_nazione	 ")                                                         '(1,rs("cod_nazione")) 					'CITTADINANZA							(258)
        str.Append(" ,CASE dbo.Notifica_Anagrafica.IdNazionalitaCittadinanza   ")
        str.Append(" 		WHEN NULL THEN CAST('' as varchar(3))  ")
        str.Append(" 		WHEN '000' THEN CAST('' as varchar(3)) ELSE dbo.Notifica_Anagrafica.IdNazionalitaCittadinanza END as cod_nazione_estera ") '(3,rs("cod_nazione_estera")) 			'CITTADINANAZA ESTERA					(259-261)
        str.Append(" ,'9' as residenza				 ")                                                                                 '(1,"9")            						'RESIDENZA								(262)
        str.Append(" ,CAST('0' as varchar(2)) as num_asl_residenza ")                                                                   '(2,"0")            						'NUM USL RESIDENZA 						(263-264)
        str.Append(" ,CAST('' as varchar(3)) as ex_usl_residenza	 ")                                                                 '(3,"")								 'EX USL RESIDENZA  						(265-267)
        str.Append(" ,CAST(ResidenzaProvincia.sigla as varchar(2)) as siglaProvResidenza	 ")                                         '(2,rs("siglaProvResidenza"))			  'SIGLA PROVINCIA DI RESIDENZA			(268-269)
        str.Append(" ,CAST(ResidenzaComune.descrizione as varchar(20)) as comune_resid	")                                              '(20,rs("comune_resid"))				  'COMUNE RESIDENZA						(270-289)
        str.Append(" ,CAST(dbo.Notifica_Anagrafica.IndirizzoResidenza as varchar(29)) as 	indirizzo ")                                '(29,rs("indirizzo"))					  'DOMICILIO ABITUALE						(290-318)
        str.Append(" ,CAST(dbo.Notifica.AslDiResidenza  as varchar(7)) as asl_residenza		 ")                                         '(7,rs("codice_asl_residenza"))			'CODICE USL DI RESIDENZA				(319-325)
        str.Append(" ,CASE dbo.Notifica_Anagrafica.Eta WHEN '0' THEN '2' ELSE '1' END as codice_eta ")                                  '(1,rs("codice_eta"))					  'ETA'									(326)
        str.Append(" ,CAST( '' as varchar(2)) as mesi	 ")                                                                             '(2,rs("mesi"))						  'ETA IN MESI							(327-328)
        str.Append(" ,CAST(eta as varchar(2)) as eta		 ")                                                                         '(2,rs("anni"))							 'ETA' IN ANNI							(329-330)
        str.Append(" ,CONVERT(varchar(8),dbo.Notifica_clinica.DataPrimiSintomi,112) as data_ps ")                                       '(8,rs("data_ps")) 						'DATA SINTOMI							(331-338)
        str.Append(" ,CAST(SintomiComune.descrizione	as varchar(20)) as comune_ps		 ")                                         '(20,rs("comune_ps"))					'LOCALITA' INIZIO SINTOMI				(339-358)
        str.Append(" ,CAST(SintomiProvincia.sigla as varchar(2)) as Provincia_Primi_Sintomi ")                                          '(2,rs("Provincia_Primi_Sintomi"))		'SIGLA PROVINCIA SINTOMI				(359-360)
        str.Append(" ,case when dbo.notifica_clinica.RicoveroOspedaliero = 'Si' THEN '9' ELSE '1' END  as cod_luogo_ricovero ")         '(1,rs("cod_luogo_ricovero"))			'RICOVERO 								(361)
        str.Append(" ,CAST(dbo.notifica_clinica.LuogoRicovero as varchar(37)) as luogo_ricovero	 ")                                     '(37,rs("luogo_ricovero")) 				'LUOGO RICOVERO							(362-398)
        str.Append(" ,CAST(ContagioComune.descrizione as varchar(30)) as comune_contagio ")                                             '(30,rs("comune_contagio"))    			'COMUNE CONTAGIO						(399-428)
        str.Append(" ,CAST('' as varchar(1)) as statoVaccinale					 ")                                                     '(1,rs("StatoVaccinale")) 				'VACCINANZIONE							(429)
        ' str.Append(" ,RIGHT(CAST(year(dbo.notifica_clinica.DataDoseUltimoVaccino) as varchar(2)),2)	 as annoVaccino	 ")                 '(2,rs("anno_vaccino")) 			'ANNO VACCINAZIONE						(430-431)
        str.Append(" ,CAST(RIGHT(year(dbo.notifica_clinica.DataDoseUltimoVaccino) ,2) as varchar(2))	 as annoVaccino	 ")                 '(2,rs("anno_vaccino")) 			'ANNO VACCINAZIONE						(430-431)
        str.Append(" ,CONVERT(varchar(8),dbo.Notifica.DataSegnalazione,112) as data_segnalazione ")                                     '(8,rs("data_segnalazione"))   	'DATASMED								(432-439)
        str.Append(" ,CONVERT(varchar(8),dbo.Notifica.DataNotifica,112)	as 	data_not	 ")                                             '(8,rs("data_not"))       			'DATA NOTIFICA							(440-447)
        str.Append(" ,CAST(lower(dbo.Notifica.medicoSegnalatore) as varchar(36))	as medicoSegnalatore ")                             '(36,rs("medico_segnalatore")) 	'SANITARIO								(448-483)
        str.Append(" ,CAST('' as varchar(62))	as recapito_medico ")                                                                   '(62,rs("recapito_sanitario")) 	'RECAPITO								(484-545)
        str.Append(" ,CAST('' as varchar(22))	as telefono_medico ")                                                                   '(22,rs("telefono_Medico"))    	'TELEFONO								(546-567)
        str.Append(" ,CAST('' as varchar(65))	as note	")                                                                              '(65,rs("annotazione")) 			'NOTE									(568-632)
        str.Append(" from dbo.Notifica ")
        str.Append(" INNER JOIN dbo.Geo_Regioni ON dbo.Notifica.idregione = dbo.Geo_Regioni.idRegione ")
        str.Append(" INNER JOIN dbo.Notifica_Clinica ON dbo.Notifica.id = dbo.Notifica_Clinica.IdNotifica ")
        str.Append(" INNER JOIN dbo.Malattie ON dbo.Notifica_Clinica.IdMalattia = dbo.Malattie.id_malattia ")
        str.Append(" INNER JOIN dbo.Notifica_Anagrafica ON dbo.Notifica.id = dbo.Notifica_Anagrafica.IdNotifica ")
        str.Append(" LEFT JOIN dbo.Professioni ON dbo.Notifica_Anagrafica.idProfessione = dbo.Professioni.codice ")
        str.Append(" LEFT JOIN dbo.Geo_Province as ResidenzaProvincia ON dbo.Notifica_Anagrafica.idProvinciaResidenza = ResidenzaProvincia.idProvincia ")
        str.Append(" LEFT JOIN dbo.Geo_Comuni as ResidenzaComune ON dbo.Notifica_Anagrafica.IdComuneResidenza = ResidenzaComune.CodiceComune ")
        str.Append(" LEFT JOIN dbo.Geo_Province as SintomiProvincia ON dbo.Notifica_Clinica.IdProvinciaPrimiSintomi = SintomiProvincia.idProvincia ")
        str.Append(" LEFT JOIN dbo.Geo_Comuni as SintomiComune ON dbo.Notifica_Clinica.idComunePrimiSintomi = SintomiComune.CodiceComune ")
        str.Append(" LEFT JOIN dbo.Geo_Comuni as ContagioComune ON dbo.Notifica_Clinica.idComuneContagio = ContagioComune.CodiceComune ")
        str.Append(" LEFT JOIN dbo.Geo_asl ON dbo.Notifica.AslDiNotifica = dbo.Geo_asl.idAsl ")
        str.Append(" LEFT JOIN dbo.Geo_Province as aslProvincie ON dbo.Geo_asl.provincia = aslProvincie.sigla ")
        str.Append(" LEFT JOIN dbo.Geo_Comuni as AslComune ON Geo_asl.citta = AslComune.descrizione ")



        str.Append(BizClass.NotificaFilterQueryBuilder(Criterio, _
                                                        dataDa, _
                                                        dataA, _
                                                        Nothing, _
                                                        Nothing, _
                                                        idRegione, _
                                                        Nothing, _
                                                        Nothing, _
                                                        stato))

        str.Append("AND Malattie.Exclasse='2' order by datanotifica ")
        Dim a As String = str.ToString



        Dim rs As List(Of esportazioneResult) = _mobjdataAccess.ExportMinistero(str.ToString)


        Return rs



    End Function
    Public Function GetElenchi(Optional ByVal stato As String = Nothing, _
                                                Optional ByVal idMalattia As Nullable(Of Integer) = Nothing, _
                                                Optional ByVal NotificatoDa As String = Nothing, _
                                                Optional ByVal idComuneResidenza As String = Nothing, _
                                                Optional ByVal Criterio As String = Nothing, _
                                                Optional ByVal DataDa As Nullable(Of Date) = Nothing, _
                                                Optional ByVal DataA As Nullable(Of Date) = Nothing, _
                                                Optional ByVal Asl As String = Nothing, _
                                                Optional ByVal idRegione As String = Nothing, _
                                                Optional ByVal username As String = Nothing, _
                                                Optional ByVal ruolo As String = Nothing) As List(Of Notifica_ElenchiResult)



        If IsNothing(DataDa) Then
            DataDa = "01/01/1900"
        End If

        If IsNothing(DataA) Then
            DataA = Now.ToShortDateString
        End If

        Dim str As New System.Text.StringBuilder
        str.Append(" select  ")

        str.Append("Nome ")
        str.Append(",Cognome ")
        str.Append(",sesso ")
        str.Append(",dbo.Malattie.DescrizioneBreve as Malattia ")
        str.Append(",dbo.Malattie.icd9 as ICDIX ")
        str.Append(",dbo.Geo_Comuni.descrizione as ComunePrimiSintomi ")
        str.Append(",DataNascita ")
        str.Append(",DataPrimiSintomi ")
        str.Append(",dataSegnalazione ")
        str.Append(",datanotifica ")
        str.Append(",AslDiResidenza ")
        str.Append(",AslDiNotifica ")
        str.Append(",res.descrizione as ComuneResidenza ")
        str.Append(",CASE WHEN IdNazionalitaCittadinanza ='000' THEN 'si' ELSE 'no' END as Cittadinanza_Italiana")
        str.Append(",RicoveroOspedaliero as ricovero")
        str.Append(",strutturaRicovero")
        str.Append(",indirizzoDomicilio")
        str.Append(",StatoVaccinale")
        str.Append(",Notifica.id ")
        str.Append("From ")
        str.Append("dbo.Notifica INNER JOIN dbo.Notifica_Anagrafica ")
        str.Append("ON  dbo.Notifica.id = dbo.Notifica_Anagrafica.idNotifica ")
        str.Append("INNER JOIN dbo.Notifica_Clinica ")
        str.Append("ON dbo.Notifica.id = dbo.Notifica_Clinica.IdNotifica ")
        str.Append("INNER JOIN dbo.Malattie  ")
        str.Append("ON dbo.Notifica_Clinica.idMalattia = dbo.Malattie.id_malattia ")
        str.Append("LEFT JOIN dbo.Geo_Comuni ")
        str.Append("ON dbo.Notifica_Clinica.IdComunePrimiSintomi = dbo.Geo_Comuni.CodiceComune ")
        str.Append("LEFT JOIN dbo.Geo_Comuni as res ")
        str.Append("ON dbo.Notifica_Anagrafica.IdComuneResidenza = res.CodiceComune ")
        str.Append("INNER JOIN dbo.Malattie_Gruppo ")
        str.Append("ON dbo.Notifica_Clinica.idMalattia = dbo.Malattie_Gruppo.idmalattia ")
        str.Append("INNER JOIN dbo.Utenti_Gruppi_Malattie ")
        str.Append("ON dbo.Malattie_Gruppo.idGruppo = dbo.Utenti_Gruppi_Malattie.id_Malattie_gruppo ")





        str.Append(BizClass.NotificaFilterQueryBuilder(Criterio, _
                                                       DataDa, _
                                                       DataA, _
                                                       NotificatoDa, _
                                                       Asl, _
                                                       idRegione, _
                                                       idComuneResidenza, _
                                                       idMalattia, _
                                                       stato, _
                                                       username, _
                                                       ruolo))

        Dim a As String = str.ToString
        Dim rs As List(Of Notifica_ElenchiResult) = _mobjdataAccess.GetElenchi(str.ToString)


        Return rs



    End Function

    Public Function GetNotificaLista(Optional ByVal cognome As String = Nothing, _
                                     Optional ByVal nome As String = Nothing, _
                                     Optional ByVal dataNascita As Nullable(Of Date) = Nothing, _
                                     Optional ByVal codicefiscale As String = Nothing, _
                                     Optional ByVal idmalattia As Nullable(Of Integer) = Nothing, _
                                     Optional ByVal idComuneResidenza As String = Nothing, _
                                     Optional ByVal idComunePrimiSintomi As String = Nothing, _
                                     Optional ByVal stato As String = Nothing, _
                                     Optional ByVal dataNotificaDa As Nullable(Of Date) = Nothing, _
                                     Optional ByVal dataNotificaA As Nullable(Of Date) = Nothing, _
                                     Optional ByVal dataSegnalazioneDa As Nullable(Of Date) = Nothing, _
                                     Optional ByVal dataSegnalazioneA As Nullable(Of Date) = Nothing, _
                                     Optional ByVal idAslNotifica As String = Nothing, _
                                     Optional ByVal idAslResidenza As String = Nothing, _
                                     Optional ByVal idRegione As String = Nothing, _
                                     Optional ByVal idScheda As Nullable(Of Integer) = Nothing, _
                                     Optional ByVal username As String = Nothing, _
                                     Optional ByVal ruolo As String = Nothing) As List(Of Notifica_listaResult)
        Try


            Dim usernameMedico As String = ""

            If ruolo = "medico" Then
                usernameMedico = username
            Else
                usernameMedico = Nothing
            End If

            Return _mobjdataAccess.GetNotificaLista(cognome, _
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
                                                    idAslNotifica, _
                                                    idAslResidenza, _
                                                    idRegione,
                                                    idScheda, _
                                                    username, _
                                                    usernameMedico)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetNotificaListaRegione(Optional ByVal cognome As String = Nothing, _
                                 Optional ByVal nome As String = Nothing, _
                                 Optional ByVal dataNascita As Nullable(Of Date) = Nothing, _
                                 Optional ByVal codicefiscale As String = Nothing, _
                                 Optional ByVal idmalattia As Nullable(Of Integer) = Nothing, _
                                 Optional ByVal idComuneResidenza As String = Nothing, _
                                 Optional ByVal idComunePrimiSintomi As String = Nothing, _
                                 Optional ByVal stato As String = Nothing, _
                                 Optional ByVal dataNotificaDa As Nullable(Of Date) = Nothing, _
                                 Optional ByVal dataNotificaA As Nullable(Of Date) = Nothing, _
                                 Optional ByVal dataSegnalazioneDa As Nullable(Of Date) = Nothing, _
                                 Optional ByVal dataSegnalazioneA As Nullable(Of Date) = Nothing, _
                                 Optional ByVal idAslNotifica As String = Nothing, _
                                 Optional ByVal idAslResidenza As String = Nothing, _
                                 Optional ByVal idRegione As String = Nothing, _
                                 Optional ByVal idScheda As Nullable(Of Integer) = Nothing, _
                                 Optional ByVal username As String = Nothing, _
                                 Optional ByVal ruolo As String = Nothing) As List(Of Notifica_lista_regioneResult)
        Try


            Dim usernameMedico As String = Nothing



            Return _mobjdataAccess.GetNotificaListaRegione(cognome, _
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
                                                    idAslNotifica, _
                                                    idAslResidenza, _
                                                    idRegione,
                                                    idScheda, _
                                                    username, _
                                                    usernameMedico)

        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function GetAnagraficaByIdNotifica(ByVal idNotifica As Integer) As Anagrafica
        Try
            Return _mobjdataAccess.GetAnagraficaByIdNotifica(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAnagraficaView(ByVal idNotifica As Integer) As Anagrafica_ViewResult
        Try
            Return _mobjdataAccess.GetAnagraficaView(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function ClassificaCaso(ByVal idMalattia As Integer, _
                                    ByVal clinico As String, _
                                    ByVal epidemiologico As String, _
                                    ByVal laboratorio As String) As String

        Dim classificazione As String = "non classificato"
        Dim rsClassificazione As List(Of Malattie_Classificazione_Caso) = _mobjdataAccess.retrieveClassification(idMalattia)

        For Each cla As Malattie_Classificazione_Caso In rsClassificazione

            If clinico = cla.Clinico And _
               epidemiologico = cla.Epidemiologico And _
               laboratorio = cla.Laboratorio Then
                classificazione = cla.Tipo
            End If
        Next
        Return classificazione
    End Function

    Public Function Notificabile(ByVal idNotifica As Integer, ByRef errorLista As List(Of String), ByVal idMalattia As Integer) As Boolean

        Dim isNotificabile As Boolean = True
        Try

            Dim malattia As Malattia = _MobjBllMalattie.GetMalattia(idMalattia)
            If malattia.gruppo = MalattieLivello.Mib Then
                isNotificabile = _mobjMib.notificabile(idNotifica, errorLista)
            End If
            Return isNotificabile
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#Region "Clinica"
    Public Function AddClinica(ByVal localtable As Clinica) As Integer
        Try

            Return _mobjdataAccess.AddClinica(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateClinica(ByVal localtable As Clinica)
        Try
            Dim id As Integer
            'da rivedere

            'localtable.Classificazione = ClassificaCaso(localtable.IdMalattia, _
            '                                            localtable.CriterioClinico, _
            '                                            localtable.CriterioEpidemiologico, _
            '                                            localtable.CriterioLaboratorio)
            localtable.Classificazione = "non classificato"
            _mobjdataAccess.UpdateClinica(localtable)
            _mobjdataAccess.UpdateEta(localtable.IdNotifica, BizClass.GetAge(_DataNascita, _DataPrimiSintomi))

            Dim info As Notifica_InfoResult = _mobjdataAccess.GetInfo(localtable.IdNotifica)
            If BllConfig.retrieveTracingStatus = True Then

                Dim mobjAudit As New BllAudit
                id = localtable.IdNotifica
                Dim audit As New Audit
                With audit
                    .idRecord = id
                    .sezione = "Clinica"
                    .tipo_operazione = "aggiornamento"
                    .categoria = "Notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now                    
                End With
                mobjAudit.Add(audit)
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.idAslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then
                            With audit
                                .idRecord = localtable.IdNotifica
                                .sezione = "Clinica"
                                .tipo_operazione = "aggiornamento"
                                .categoria = "Notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If

            End If


            'If _MobjBllMalattie.isMib(localtable.IdMalattia) Then
            '    Dim InfoNotifica As Notifica_InfoResult = _mobjdataAccess.GetInfo(localtable.IdNotifica)
            '    If InfoNotifica.stato = "Notifica" Then
            '        Dim service As New BllExtService
            '        service.UpdateClinicaToMib(localtable)
            '    End If
            'End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetClinicaByIdNotifica(ByVal idNotifica As Integer) As Clinica
        Try
            Return _mobjdataAccess.GetClinicaByIdNotifica(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetClinicaView(ByVal idNotifica As Integer) As Clinica_ViewResult
        Try
            Return _mobjdataAccess.GetClinicaView(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "Esami"
    Public Function GetEsamiList(ByVal idNotifica As Integer) As List(Of Esami_ViewResult)
        Try
            Return _mobjdataAccess.GetEsamiList(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddEsame(ByVal localtable As Notifica_Esami) As Integer
        Try
            Return _mobjdataAccess.AddEsame(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteEsame(ByVal id As Integer)
        Try
            _mobjdataAccess.DeleteEsame(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
#Region "tbc"
    Public Function GetTbcFAttori(ByVal idNotifica As Integer) As Notifica_Tbc_Fattori
        Try
            Return _mobjdataAccess.GetTbcFAttori(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddTbcFAttori(ByVal localtable As Notifica_Tbc_Fattori) As Integer
        Try
            Return _mobjdataAccess.AddTbcFattori(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateTbcFAttori(ByVal localtable As Notifica_Tbc_Fattori)
        Try
            _mobjdataAccess.UpdateTbcFattori(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetTbc_View(ByVal idNotifica As Integer) As Notifica_Tbc
        Try
            Return _mobjdataAccess.GetTbc_View(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region "malaria"
    Public Function GetMalaria(ByVal idNotifica As Integer) As Notifica_Malaria
        Try
            Return _mobjdataAccess.GetMalaria(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddMalaria(ByVal localtable As Notifica_Malaria) As Integer
        Try

            Dim id As Integer
            id = _mobjdataAccess.AddMalaria(localtable)


            Dim info As Notifica_InfoResult = _mobjdataAccess.GetInfo(localtable.idNotifica)
            If BllConfig.retrieveTracingStatus = True Then



                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                With audit
                    .idRecord = localtable.idNotifica
                    .sezione = "malaria"
                    .tipo_operazione = "Inserimento"
                    .categoria = "notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.idAslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then

                            With audit
                                .idRecord = localtable.idNotifica
                                .sezione = "malaria"
                                .tipo_operazione = "Inserimento"
                                .categoria = "notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If
            End If
            '  BllExtService.UpdateMibToMib(localtable)
            Return localtable.idNotifica

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateMalaria(ByVal localtable As Notifica_Malaria)
        Try
            _mobjdataAccess.UpdateMalaria(localtable)

            Dim info As Notifica_InfoResult = _mobjdataAccess.GetInfo(localtable.idNotifica)
            If BllConfig.retrieveTracingStatus = True Then
                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                With audit
                    .idRecord = localtable.idNotifica
                    .sezione = "malaria"
                    .tipo_operazione = "aggiornamento"
                    .categoria = "notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.idAslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then                            
                            With audit
                                .idRecord = localtable.idNotifica
                                .sezione = "malaria"
                                .tipo_operazione = "aggiornamento"
                                .categoria = "notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetMalariaView(ByVal idNotifica As Integer) As Notifica_view_MalariaResult
        Try
            Return _mobjdataAccess.GetMalariaView(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class

