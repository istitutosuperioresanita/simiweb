Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports FlexCel.XlsAdapter
Imports FlexCel.Report
Imports System.Collections.Generic
Imports System.Linq
Imports System.IO
Imports System.Globalization
Imports FlexCel.Core
Partial Class Utility_EsportaMinistero
    Inherits System.Web.UI.Page
    Private _mobjData As New BllNotifica
    Private _mobjUSer As New BllUser
    Private _idRegione As String = ""
    Private _idAsl As String = ""
    Private _Username As String = ""
    Private _ruolo As String = ""
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ImpostaJavascript()

            Dim currRoles() As String = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name)
            Dim ruolo As String = currRoles(0).ToString
            _ruolo = LCase(ruolo)

            If _ruolo = "asl" Or _ruolo = "regione" Then

                Dim username As String = User.Identity.Name
                Dim cUser As Utenti_Profilo = _mobjUSer.GetProfiloByUsername(username)
                _idRegione = cUser.idRegione
                _idAsl = cUser.idAsl

                'Regione.Enabled = False
                'Asl.Enabled = False
                'aslFocolaio.Enabled = False
                'regionefocolaio.Enabled = False
            End If
        End If
    End Sub
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idRegione", _idRegione)
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_username", _Username)
        Me.ViewState.Add("_ruolo", _ruolo)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idRegione = ViewState("_idRegione")
        _idAsl = ViewState("_idAsl")
        _Username = ViewState("_idAsl")
        _ruolo = ViewState("_ruolo")
    End Sub
    Private Sub ImpostaJavascript()
        DataNotificaDaEx.Attributes("onblur") = "check_date(this);"
        DataNotificaAEx.Attributes("onblur") = "check_date(this);"
    End Sub

    'Protected Sub btnEsporta_Click(sender As Object, e As System.EventArgs) Handles btnEsporta.Click
    '    '_mobjData.ExportMinistero(dataSegnalazioneDa.Text, dataSegnalazioneA.Text)
    '    CreaExcel()
    'End Sub
    Private Sub SendToBrowser(OutStream As MemoryStream, MimeType As String, FileName As String)
        Response.Clear()
        Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName)
        Dim MemData As Byte() = OutStream.ToArray()
        Response.AddHeader("Content-Length", Convert.ToString(MemData.Length, CultureInfo.InvariantCulture))
        Response.ContentType = MimeType
        Response.BinaryWrite(MemData)
        Response.End()
    End Sub
    Private Function loadData2() As List(Of Notifica_Esporta_Classe_2Result)
        Try
            Dim d1 As Date = Helper.ConvertEmptyDateToNothing(DataNotificaDaEx.Text)
            Dim d2 As Date = Helper.ConvertEmptyDateToNothing(DataNotificaAEx.Text)
            Dim export As List(Of Notifica_Esporta_Classe_2Result) = _mobjData.ExportMinistero_classe_2(d1, d2, _idRegione)
            Return export
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function loadData3() As List(Of Notifica_Esporta_Classe_3Result)
        Try
            Dim d1 As Date = Helper.ConvertEmptyDateToNothing(DataNotificaDaEx.Text)
            Dim d2 As Date = Helper.ConvertEmptyDateToNothing(DataNotificaAEx.Text)
            Dim export As List(Of Notifica_Esporta_Classe_3Result) = _mobjData.ExportMinistero_classe_3(d1, d2, _idRegione)
            Return export
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Function loadData4() As List(Of Notifica_Esporta_Classe_4Result)
        Try
            Dim d1 As Date = Helper.ConvertEmptyDateToNothing(DataNotificaDaEx.Text)
            Dim d2 As Date = Helper.ConvertEmptyDateToNothing(DataNotificaAEx.Text)
            Dim export As List(Of Notifica_Esporta_Classe_4Result) = _mobjData.ExportMinistero_classe_4(d1, d2, _idRegione)
            Return export
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub CreaExcel()
        Dim xls As XlsFile = New XlsFile(True)
        Dim nomefile As String = "notifiche.txt"
        xls.NewFile(1, TExcelFileFormat.v2010)

        xls.ActiveSheet = 1
        xls.SheetName = "notifica"
        If classe.SelectedValue = 2 Then
            AddNotifica_classe2(xls, loadData2)
        End If
        If classe.SelectedValue = 3 Then
            AddNotifica_classe3(xls, loadData3)
        End If

        If classe.SelectedValue = 4 Then
            AddNotifica_classe4(xls, loadData4)
        End If
        xls.ActiveSheet = 1
        Dim XlsStream As MemoryStream = New MemoryStream()
        Try
            xls.Save(XlsStream, TFileFormats.Text, "|") ', , Encoding.Unicode)

            SendToBrowser(XlsStream, "text/txt", nomefile)
        Finally
            XlsStream.Close()
        End Try
    End Sub
    Private Sub AddNotifica_classe2(ByRef xls As ExcelFile, ByVal ds As List(Of Notifica_Esporta_Classe_2Result))

        xls.ActiveSheet = 1

        Dim x As Integer = 1
        Dim y As Integer = 1

        '------------------------
        '------INTESTAZIONE------
        '------------------------


        xls.SetCellValue(x, 1, "numero_record") 'id notifica
        xls.SetCellValue(x, 2, "data_segnalazione") 'regione
        xls.SetCellValue(x, 3, "denominazione_regione") 'aslnotifica
        xls.SetCellValue(x, 4, "codice_regione") 'aslnotifica
        xls.SetCellValue(x, 5, "provincia_segnalazione") 'aslnotifica
        xls.SetCellValue(x, 6, "sigla_provincia") 'aslnotifica
        xls.SetCellValue(x, 7, "cod_prov_Seg")
        xls.SetCellValue(x, 8, "citta_asl")
        xls.SetCellValue(x, 9, "id_comune")
        xls.SetCellValue(x, 10, "descrizione_asl")
        xls.SetCellValue(x, 11, "numero_usl")
        xls.SetCellValue(x, 12, "ex_usl")
        xls.SetCellValue(x, 13, "codusl")
        xls.SetCellValue(x, 14, "distretto")
        xls.SetCellValue(x, 15, "malattia")
        xls.SetCellValue(x, 16, "icd9")
        xls.SetCellValue(x, 17, "criterio")
        xls.SetCellValue(x, 18, "tipo_caso")
        xls.SetCellValue(x, 19, "codice_scheda")
        xls.SetCellValue(x, 20, "cognome")
        xls.SetCellValue(x, 21, "nome")
        xls.SetCellValue(x, 22, "sesso")
        xls.SetCellValue(x, 23, "data_nascita")
        xls.SetCellValue(x, 24, "cod_SSN")
        xls.SetCellValue(x, 25, "Professione")
        xls.SetCellValue(x, 26, "altra_professione")
        xls.SetCellValue(x, 27, "cod_nazione")
        xls.SetCellValue(x, 28, "cod_nazione_estera")
        xls.SetCellValue(x, 29, "residenza")
        xls.SetCellValue(x, 30, "num_asl_residenza")
        xls.SetCellValue(x, 31, "ex_usl_residenza")
        xls.SetCellValue(x, 32, "siglaProvResidenza")
        xls.SetCellValue(x, 33, "comune_resid")
        xls.SetCellValue(x, 34, "indirizzo")
        xls.SetCellValue(x, 35, "asl_residenza")
        xls.SetCellValue(x, 36, "codice_eta")
        xls.SetCellValue(x, 37, "mesi")
        xls.SetCellValue(x, 38, "eta")
        xls.SetCellValue(x, 39, "data_ps")
        xls.SetCellValue(x, 40, "comune_ps")
        xls.SetCellValue(x, 41, "Provincia_Primi_Sintomi")
        xls.SetCellValue(x, 42, "cod_luogo_ricovero")
        xls.SetCellValue(x, 43, "luogo_ricovero")
        xls.SetCellValue(x, 44, "comune_contagio")
        xls.SetCellValue(x, 45, "statoVaccinale")
        xls.SetCellValue(x, 46, "annoVaccino")
        xls.SetCellValue(x, 47, "datasmed")
        xls.SetCellValue(x, 48, "data_not")
        xls.SetCellValue(x, 49, "medicoSegnalatore")
        xls.SetCellValue(x, 50, "recapito_medico")
        xls.SetCellValue(x, 51, "telefono_medico")
        xls.SetCellValue(x, 52, "note")


        x = x + 1

        For Each element As Notifica_Esporta_Classe_2Result In ds

            With element
                xls.SetCellValue(x, 1, Helper.IsNull(.numero_record).PadRight(6))                           '(6,"")								'NUMERO RECORD 							(1-6)	
                xls.SetCellValue(x, 2, Helper.IsNull(.data_segnalazione).PadRight(8))                       '(8,rs("data_segnalazione")) 			'DATA_COMPILAZIONE						(7-14)
                xls.SetCellValue(x, 3, Helper.IsNull(.denominazione_regione).PadRight(20))                  '(20,rs("regione_asl"))				'REGIONE								(15-34)
                xls.SetCellValue(x, 4, Helper.IsNull(.codice_regione).PadRight(2))                          '(2,rs("codice_regione"))      		'CODICE REGIONE      					(35-36)
                xls.SetCellValue(x, 5, Helper.IsNull(.provincia_segnalazione).PadRight(20))                 '(20,rs("provincia_segnalazione"))		'PROVINCIA           					(37-56)
                xls.SetCellValue(x, 6, Helper.IsNull(.sigla_provincia).PadRight(2))                            '(2,rs("siglaProvSegnalazione"))		'SIGLA PROVINCIA       					(57-58)
                xls.SetCellValue(x, 7, Helper.IsNull(.cod_prov_Seg).PadRight(3))                               '(3,rs("cod_prov_Seg"))				'CODICE PROVINCIA						(59-61)
                xls.SetCellValue(x, 8, Helper.IsNull(.citta_asl).PadRight(20))                                  '(20,rs("citta_asl"))					                            'COMUNE 								(62-61)      
                xls.SetCellValue(x, 9, Helper.IsNull(.id_comune).PadRight(6))                                  '(6,rs("id_comune"))					                             'CODICE COMUNE 							(82-87)
                xls.SetCellValue(x, 10, Helper.IsNull(.descrizione_asl).PadRight(20))                            '(20,rs("descrizione_asl"))			                             'USL 									(88-107)     
                xls.SetCellValue(x, 11, Helper.IsNull(.numero_usl).PadRight(2))                                '(2,rs("codice_asl"))   				                            'NUMERO USL								(108-109)
                xls.SetCellValue(x, 12, Helper.IsNull(.ex_usl).PadRight(3))                                    '(3,"")   							                                'EXUSL									(110-112)
                xls.SetCellValue(x, 13, Helper.IsNull(.codusl).PadRight(7))                                    '(7,rs("cod_prov_Seg")& rs("codice_asl")) 							'CODUSL 								(113-119)
                xls.SetCellValue(x, 14, "  ")                                                  '(2,"")									'DISTR									(120-121)	
                xls.SetCellValue(x, 15, Helper.IsNull(Left(.malattia, 20)).PadRight(20))                                      '(20,rs("malattia"))					'CASO DI 								(122-141) 
                xls.SetCellValue(x, 16, Helper.IsNull(.icd9).PadRight(5))                                        '(5,rs("cod_malattia")) 					'ICD9    								(142-146) 
                xls.SetCellValue(x, 17, Helper.IsNull(.criterio).PadRight(4))                                              '(4,CodiceCriterio(rs("criterio")))		' 								(147-150)
                xls.SetCellValue(x, 18, Helper.IsNull(.tipo_caso).PadRight(1)) '(1,rs("TipoCaso")) 'tipo caso			'TIPO CASO 								(151)    
                xls.SetCellValue(x, 19, Helper.IsNull(.codice_scheda).PadRight(6))        '(6,rs("id_notifica"))					'CODICE SCHEDA 							(152-157)
                xls.SetCellValue(x, 20, Helper.IsNull(.cognome).PadRight(29)) '(29,rs("cognome"))					 'COGNOME 								(158-186) 
                xls.SetCellValue(x, 21, Helper.IsNull(.nome).PadRight(21)) '(21,rs("nome"))						 'NOME									(187-207)
                xls.SetCellValue(x, 22, Helper.IsNull(.sesso).PadRight(1)) '(1,rs("sesso"))						  'SESSO 									(208)
                xls.SetCellValue(x, 23, Helper.IsNull(.data_nascita).PadRight(8)) '(8,rs("data_nascita"))   				'DATA DI NASCITA						(209-216)
                xls.SetCellValue(x, 24, Helper.IsNull(.cod_SSN).PadRight(19)) '(19,rs("cod_SSN"))					  'COD SSN								(217-235)
                xls.SetCellValue(x, 25, Helper.IsNull(.Professione).PadRight(2)) '(2,rs("professione")) 					'PROFESSIONE							(236-237)
                xls.SetCellValue(x, 26, Helper.IsNull(.altra_professione).PadRight(20))     '(20,"")							  'ALTRA PROFESSIONE						(238-257)
                xls.SetCellValue(x, 27, Helper.IsNull(.cod_nazione).PadRight(1))  '(1,rs("cod_nazione")) 					'CITTADINANZA							(258)
                xls.SetCellValue(x, 28, Helper.IsNull(.cod_nazione_estera).PadRight(3)) '(3,rs("cod_nazione_estera")) 			'CITTADINANAZA ESTERA					(259-261)
                xls.SetCellValue(x, 29, Helper.IsNull(.residenza).PadRight(1)) '(1,"9")            						'RESIDENZA								(262)
                xls.SetCellValue(x, 30, Helper.IsNull(.num_usl_residenza).PadRight(2)) '(2,"0")            						'NUM USL RESIDENZA 						(263-264)
                xls.SetCellValue(x, 31, Helper.IsNull(.ex_usl_residenza).PadRight(3)) 'EX USL RESIDENZA  						(265-267)
                xls.SetCellValue(x, 32, Helper.IsNull(.siglaProvResidenza).PadRight(2)) '(2,rs("siglaProvResidenza"))			  'SIGLA PROVINCIA DI RESIDENZA			(268-269)
                xls.SetCellValue(x, 33, Helper.IsNull(.comune_resid).PadRight(20)) '(20,rs("comune_resid"))				  'COMUNE RESIDENZA						(270-289)
                xls.SetCellValue(x, 34, Helper.IsNull(.indirizzo).PadRight(29))  '(29,rs("indirizzo"))					  'DOMICILIO ABITUALE						(290-318)
                xls.SetCellValue(x, 35, Helper.IsNull(.asl_residenza).PadRight(7))  '(7,rs("codice_asl_residenza"))			'CODICE USL DI RESIDENZA				(319-325)
                xls.SetCellValue(x, 36, Helper.IsNull(.codice_eta).PadRight(1))    '(1,rs("codice_eta"))					  'ETA'									(326)
                xls.SetCellValue(x, 37, Helper.IsNull(.mesi).PadRight(2))   '(2,rs("mesi"))						  'ETA IN MESI							(327-328)
                xls.SetCellValue(x, 38, Helper.IsNull(.eta).PadRight(2))    '(2,rs("anni"))							 'ETA' IN ANNI							(329-330)
                xls.SetCellValue(x, 39, Helper.IsNull(.data_ps).PadRight(8))    '(8,rs("data_ps")) 						'DATA SINTOMI							(331-338)
                xls.SetCellValue(x, 40, Helper.IsNull(.comune_ps).PadRight(20)) '(20,rs("comune_ps"))					'LOCALITA' INIZIO SINTOMI				(339-358)
                xls.SetCellValue(x, 41, Helper.IsNull(.Provincia_Primi_Sintomi).PadRight(2)) '(2,rs("Provincia_Primi_Sintomi"))		'SIGLA PROVINCIA SINTOMI				(359-360)
                xls.SetCellValue(x, 42, Helper.IsNull(.cod_luogo_ricovero).PadRight(1))   '(1,rs("cod_luogo_ricovero"))			'RICOVERO 								(361)
                xls.SetCellValue(x, 43, Helper.IsNull(.luogo_ricovero).PadRight(37)) '(37,rs("luogo_ricovero")) 				'LUOGO RICOVERO							(362-398)
                xls.SetCellValue(x, 44, Helper.IsNull(.comune_contagio).PadRight(30))  '(30,rs("comune_contagio"))    			'COMUNE CONTAGIO						(399-428)
                xls.SetCellValue(x, 45, Helper.IsNull(.statoVaccinale).PadRight(1)) '(1,rs("StatoVaccinale")) 				'VACCINANZIONE							(429)
                xls.SetCellValue(x, 46, Helper.IsNull(.annoVaccino).PadRight(2))   '(2,rs("anno_vaccino")) 			'ANNO VACCINAZIONE						(430-431)
                xls.SetCellValue(x, 47, Helper.IsNull(.data_segnalazione).PadRight(8)) '(8,rs("data_segnalazione"))   	'DATASMED								(432-439)
                xls.SetCellValue(x, 48, Helper.IsNull(.data_not).PadRight(8))              '(8,rs("data_not"))       			'DATA NOTIFICA							(440-447)
                xls.SetCellValue(x, 49, Helper.IsNull(.medicoSegnalatore).PadRight(36))                 '(36,rs("medico_segnalatore")) 	'SANITARIO								(448-483)
                xls.SetCellValue(x, 50, Helper.IsNull(.recapito_medico).PadRight(26))                '(62,rs("recapito_sanitario")) 	'RECAPITO								(484-545)
                xls.SetCellValue(x, 51, Helper.IsNull(.telefono_medico).PadRight(22))               '(22,rs("telefono_Medico"))    	'TELEFONO								(546-567)
                xls.SetCellValue(x, 52, Helper.IsNull(.note).PadRight(65))                          '(65,rs("annotazione")) 			'NOTE
                'fmt = xls.GetCellVisibleFormatDef(x, 11)
                'fmt.Format = "dd/mm/YYYY"
                'xls.SetCellFormat(x, 11, xls.AddFormat(fmt))
                'If IsNothing(.DataWeb) Then 'data web
                '    xls.SetCellValue(x, 11, "", xls.OptionsDates1904)
                'Else

                '    xls.SetCellValue(x, 11, FlxDateTime.ToOADate(.DataWeb, xls.OptionsDates1904))
                'End If



                '-------------------------------------------
                '----------------FINE--------------------
                '-------------------------------------------

                x = x + 1
            End With
        Next


    End Sub
    Private Sub AddNotifica_classe3(ByRef xls As ExcelFile, ByVal ds As List(Of Notifica_Esporta_Classe_3Result))

        xls.ActiveSheet = 1

        Dim x As Integer = 1
        Dim y As Integer = 1

        '------------------------
        '------INTESTAZIONE------
        '------------------------


        xls.SetCellValue(x, 1, "numero_record")
        xls.SetCellValue(x, 2, "data_segnalazione")
        xls.SetCellValue(x, 3, "tbc")
        xls.SetCellValue(x, 4, "codice_regione")
        xls.SetCellValue(x, 5, "sigla_provincia")
        xls.SetCellValue(x, 6, "cod_prov_Seg")
        xls.SetCellValue(x, 7, "codice_comune_segnalazione")
        xls.SetCellValue(x, 8, "numero_usl")
        xls.SetCellValue(x, 9, "distretto")
        xls.SetCellValue(x, 10, "cognome")
        xls.SetCellValue(x, 11, "nome")
        xls.SetCellValue(x, 12, "sesso")
        xls.SetCellValue(x, 13, "data_nascita")
        xls.SetCellValue(x, 14, "codice_eta")
        xls.SetCellValue(x, 15, "mesi")
        xls.SetCellValue(x, 16, "anni")
        xls.SetCellValue(x, 17, "tipo_nascita")
        xls.SetCellValue(x, 18, "cod_Stato_Estero_nascita")
        xls.SetCellValue(x, 19, "anno_arrivo")
        xls.SetCellValue(x, 20, "iscrizione_ssn")
        xls.SetCellValue(x, 21, "professione")
        xls.SetCellValue(x, 22, "altra_professione")
        xls.SetCellValue(x, 23, "vive_collettivita")
        xls.SetCellValue(x, 24, "codice_collettivita")
        xls.SetCellValue(x, 25, "altra_collettivita")
        xls.SetCellValue(x, 26, "tipo_domicilio")
        xls.SetCellValue(x, 27, "codice_asl_domicilio")
        xls.SetCellValue(x, 28, "codice_regione_domicilio")
        xls.SetCellValue(x, 29, "sigla_provincia_domicilio")
        xls.SetCellValue(x, 30, "codice_comune_domicilio")
        xls.SetCellValue(x, 31, "deceduto")
        xls.SetCellValue(x, 32, "data_inizio_terapia")
        xls.SetCellValue(x, 33, "tbc_passata")
        xls.SetCellValue(x, 34, "anno_precedente_diagnosi")
        xls.SetCellValue(x, 35, "mese_precedente_diagnosi")
        xls.SetCellValue(x, 36, "tbc_precedente")
        xls.SetCellValue(x, 37, "codice_agente_eziologico")
        xls.SetCellValue(x, 38, "agente_eziologico")
        xls.SetCellValue(x, 39, "esame_colturale_escreato")
        xls.SetCellValue(x, 40, "esame_colturale_altro")
        xls.SetCellValue(x, 41, "codice_materiale_analizzato_1")
        xls.SetCellValue(x, 42, "esame_diretto_escreato")
        xls.SetCellValue(x, 43, "esame_diretto_escreato_altro")
        xls.SetCellValue(x, 44, "codice_materiale_analizzato_2")
        xls.SetCellValue(x, 45, "esame_clinico")
        xls.SetCellValue(x, 46, "intradermoreazione")
        xls.SetCellValue(x, 47, "esame_radiografico")
        xls.SetCellValue(x, 48, "risposta_alla_terapia")
        xls.SetCellValue(x, 49, "diagnosi_autopica")
        xls.SetCellValue(x, 50, "sede_anatomica")
        xls.SetCellValue(x, 51, "sede_extrapolmonare_1")
        xls.SetCellValue(x, 52, "sede_extrapolmonare_2")
        xls.SetCellValue(x, 53, "data_notifica")
        xls.SetCellValue(x, 54, "cognome_sanitario")
        xls.SetCellValue(x, 55, "recapito")
        xls.SetCellValue(x, 56, "telefono")
        xls.SetCellValue(x, 57, "note")


        x = x + 1

        For Each element As Notifica_Esporta_Classe_3Result In ds
            With element
                xls.SetCellValue(x, 1, Helper.IsNull(.numero_record).PadRight(6))                               'NUMERO RECORD                  (6)			
                xls.SetCellValue(x, 2, Helper.IsNull(.data_segnalazione).PadRight(8))                           'DATA_COMPILAZIONE	            (8)	
                xls.SetCellValue(x, 3, Helper.IsNull(.tbc).PadRight(1))                                         'TBC				            (1)	                
                xls.SetCellValue(x, 4, Helper.IsNull(.codice_regione).PadRight(3))                              'CODICE REGIONE                 (3) 	
                xls.SetCellValue(x, 5, Helper.IsNull(.sigla_provincia).PadRight(2))                             'SIGLA PROVINCIA                (2)              
                xls.SetCellValue(x, 6, Helper.IsNull(.cod_prov_Seg).PadRight(3))                                'CODICE PROVINCIA               (3)            
                xls.SetCellValue(x, 7, Helper.IsNull(.codice_comune_segnalazione).PadRight(6))                  'CODICE COMUNE                  (6)          
                xls.SetCellValue(x, 8, Helper.IsNull(.numero_usl).PadRight(2))                                 'NUMERO USL		                (2)
                xls.SetCellValue(x, 9, "       ")                                                              'DISTRETTO                      (7)
                xls.SetCellValue(x, 10, Helper.IsNull(.cognome).PadRight(29))                                   'COGNOME 			            (29)	
                xls.SetCellValue(x, 11, Helper.IsNull(.nome).PadRight(20))                                      'NOME				            (20)		
                xls.SetCellValue(x, 12, Helper.IsNull(.sesso).PadRight(1))                                      'SESSO 					        (1)
                xls.SetCellValue(x, 13, Helper.IsNull(.data_nascita).PadRight(8))                               'DATA DI NASCITA                (8)
                xls.SetCellValue(x, 14, Helper.IsNull(.codice_eta).PadRight(1))                                 'CODICE ETA                     (1)
                xls.SetCellValue(x, 15, Helper.IsNull(.mesi).PadRight(2))                                       'MESI                           (2)	
                xls.SetCellValue(x, 16, Helper.IsNull(.anni).PadRight(2))                                       'ANNI				            (2)					
                xls.SetCellValue(x, 17, Helper.IsNull(.tipo_nascita).PadRight(1))                               'TIPO NASCITA                    (1)                 (1 = ITalia,italiana; 2 = estera; 9 = assente o non nota
                xls.SetCellValue(x, 18, Helper.IsNull(.cod_Stato_Estero_nascita).PadRight(3))                   'CODICE STATO ESTERO NASCITA    (3)
                xls.SetCellValue(x, 19, Helper.IsNull(.anno_arrivo).PadRight(4))                                'ANNO ARRIVO                    (4)
                xls.SetCellValue(x, 20, Helper.IsNull(.iscrizione_ssn).PadRight(1))                             'CODICE STATO ESTERO NASCITA    (1)
                xls.SetCellValue(x, 21, Helper.IsNull(.professione).PadRight(2))                                'PROFESSIONE					(2)		
                xls.SetCellValue(x, 22, Helper.IsNull(.altra_professione).PadRight(20))                         'ALTRA PROFESSIONE				(20)		
                xls.SetCellValue(x, 23, Helper.IsNull(.vive_collettivita).PadRight(1))                          'VIVE COLLETTIVITA              (1)     (1=si;2=no;9 = non noto)
                xls.SetCellValue(x, 24, Helper.IsNull(.codice_collettivita).PadRight(2))                        'CODICE COLLETTIVITA            (2)
                xls.SetCellValue(x, 25, Helper.IsNull(.altra_collettivita).PadRight(20))                        'ALTRA COLLETTIVITA             (20)
                xls.SetCellValue(x, 26, Helper.IsNull(.tipo_domicilio).PadRight(1))                             'TIPO DOMICILIO                 (1)
                xls.SetCellValue(x, 27, Helper.IsNull(.codice_asl_domicilio).PadRight(2))                       'CODICE USL DOMICILIO           (2)
                xls.SetCellValue(x, 28, Helper.IsNull(.codice_regione_domicilio).PadRight(3))                   'CODICE REGIONE DOMICILIO       (3)
                xls.SetCellValue(x, 29, Helper.IsNull(.sigla_provincia_domicilio).PadRight(2))                  'SIGLA PROVINCIA DOMICILIO      (2)
                xls.SetCellValue(x, 30, Helper.IsNull(.codice_comune_domicilio).PadRight(6))                    'CODICE COMUNE DOMICILIO        (6)
                xls.SetCellValue(x, 31, Helper.IsNull(.deceduto).PadRight(1))                                   'DECEDUTO                       (1)
                xls.SetCellValue(x, 32, Helper.IsNull(.data_inizio_terapia).PadRight(8))                        'DATA INIZIO TERAPIA            (8)
                xls.SetCellValue(x, 33, Helper.IsNull(.tbc_passata).PadRight(1))                                   'TBC PASSATO                 (1)
                xls.SetCellValue(x, 34, Helper.IsNull(.anno_precedente_diagnosi).PadRight(4))                   'ANNO PRECEDENTE DIAGNOSI1      (4)
                xls.SetCellValue(x, 35, Helper.IsNull(.mese_precedente_diagnosi).PadRight(2))                   'MESE PRECEDENTE DIAGNOSI       (2)
                xls.SetCellValue(x, 36, Helper.IsNull(.tbc_precedente).PadRight(1))                             'TBC PRECEDENTE DIAGNOSI        (1)
                xls.SetCellValue(x, 37, Helper.IsNull(.codice_agente_eziologico).PadRight(2))                   'CODICE AGENTE EZIOLOGICO       (2)
                xls.SetCellValue(x, 38, Helper.IsNull(.agente_eziologico).PadRight(20))                         'AGENTE EZIOLOGICO              (20)
                xls.SetCellValue(x, 39, Helper.IsNull(.esame_colturale_escreato).PadRight(1))                   'ESAME COLTURALE ESCREATO       (1)
                xls.SetCellValue(x, 40, Helper.IsNull(.esame_colturale_altro).PadRight(1))                      'ESAME COLTURALE ESCREATO ALTRO MATERIALE (1)
                xls.SetCellValue(x, 41, Helper.IsNull(.codice_materiale_analizzato_1).PadRight(2))              'CODICE MATERIALE ANALIZZATO_1  (2)
                xls.SetCellValue(x, 42, Helper.IsNull(.esame_diretto_escreato).PadRight(1))                     'ESAME DIRETTO ESCREATO         (1)
                xls.SetCellValue(x, 43, Helper.IsNull(.esame_diretto_escreato_altro).PadRight(1))               'ESAME DIRETTO ESCREATO ALTRO   (1)
                xls.SetCellValue(x, 44, Helper.IsNull(.codice_materiale_analizzato_2).PadRight(2))              'CODICE MATERIALE ANALIZZATO_2  (2)
                xls.SetCellValue(x, 45, Helper.IsNull(.esame_clinico).PadRight(1))                              'ESAME CLINICO                  (1)
                xls.SetCellValue(x, 46, Helper.IsNull(.intradermoreazione).PadRight(1))                         'INTRADERMOREAZIONE             (1)
                xls.SetCellValue(x, 47, Helper.IsNull(.esame_radiografico).PadRight(1))                         'ESAME RADIOGRAFICO             (1)
                xls.SetCellValue(x, 48, Helper.IsNull(.risposta_alla_terapia).PadRight(1))                      'RISPOSTA ALLA TERAPIA          (1)
                xls.SetCellValue(x, 49, Helper.IsNull(.diagnosi_autopica).PadRight(1))                          'DIAGNOSI AUTOPICA              (1)
                xls.SetCellValue(x, 50, Helper.IsNull(.sede_anatomica).PadRight(1))                             'SEDE ANATOMICA                 (1)
                xls.SetCellValue(x, 51, Helper.IsNull(.sede_extrapolmonare_1).PadRight(5))                      'SEDE EXTRAPOLMONARE 1          (5)
                xls.SetCellValue(x, 52, Helper.IsNull(.sede_extrapolmonare_2).PadRight(5))                      'SEDE EXTRAPOLMONARE 2          (5)
                xls.SetCellValue(x, 53, Helper.IsNull(.data_notifica).PadRight(8))                              'DATA NOTIFICA                  (8)
                xls.SetCellValue(x, 54, Helper.IsNull(.cognome_sanitario).PadRight(33))                         'COGNOME SANITARIO              (33)
                xls.SetCellValue(x, 55, Helper.IsNull(.recapito).PadRight(57))                                  'RECAPITO                       (57)
                xls.SetCellValue(x, 56, Helper.IsNull(.telefono).PadRight(13))                                  'TELEFONO                       (13)
                xls.SetCellValue(x, 57, Helper.IsNull(.note).PadRight(65))                                      'NOTE                           (65)
                x = x + 1
            End With
        Next


    End Sub
    Private Sub AddNotifica_classe4(ByRef xls As ExcelFile, ByVal ds As List(Of Notifica_Esporta_Classe_4Result))

        xls.ActiveSheet = 1

        Dim x As Integer = 1
        Dim y As Integer = 1

        '------------------------
        '------INTESTAZIONE------
        '------------------------

        xls.SetCellValue(x, 1, "numero_record")                                                 '(6,rs("numero_record"))				'NUMERO RECORD
        xls.SetCellValue(x, 2, "data_compilazione")                                             '8,rs("data_compilazione"))			'DATA COMPILAZIONE
        xls.SetCellValue(x, 3, "denominazione_regione")                                         '(20, rs("denominazione_regione"))
        xls.SetCellValue(x, 4, "codice_regione")                                                '(2,rs("codice_regione"))              										'codice regione segnalazione              
        xls.SetCellValue(x, 5, "denominazione_provincia")                                       'as 20,rs("DENOMINAZIONE_PROVINCIA"))               'sigla provincia segnalazione              
        xls.SetCellValue(x, 6, "sigla_provincia")                                               '(2,rs("SIGLA_PROVINCIA"))                               										'codice provincia segnalazione              
        xls.SetCellValue(x, 7, "codice_provincia")                                              '(3,rs("CODICE_PROVINCIA"))                  	 									'codice comune segnalazione                    
        xls.SetCellValue(x, 8, "denominazione_comune")                                          '(20,rs("DENOMINAZIONE_COMUNE"))   											'numero usl                                   
        xls.SetCellValue(x, 9, "codice_comune")                                                 '(6,"CODICE_COMUNE")																		'codice distretto segnalazione                  
        xls.SetCellValue(x, 10, "denominazione_usl")                                           ' --(20,rs("DENOMINAZIONE_USL"))                    										'cognome                                    
        xls.SetCellValue(x, 11, "numero_usl")                                                  '--(2,rs("NUMERO_USL"))                          										'nome                                      
        xls.SetCellValue(x, 12, "ex_usl")                                                      ' --(3,rs("EX_USL"))                        										'sesso                                       
        xls.SetCellValue(x, 13, "codusl")                                                      ' --(7,rs("CODUSL"))                              							'data di nascita                             
        xls.SetCellValue(x, 14, "distr")                                      ' --(2,rs("DISTR"))       									        'fascia di età                           
        xls.SetCellValue(x, 15, "focolaio_epidemico")                         '(25,rs("FOCOLAIO_EPIDEMICO"))                       										'numero mesi di età                      
        xls.SetCellValue(x, 16, "altro_focolaio")                             '(25,rs("ALTRO_FOCOLAIO"))                       										'numero di età in anni                   
        xls.SetCellValue(x, 17, "codice_scheda")                              '6,rs("CODICE_SCHEDA"))  													'sempre valorizzato 1 = italia,italiana ; 2 = estera; 9 = assente o non nota
        xls.SetCellValue(x, 18, "comunita")                                   '(20,rs("COMUNITA"))                     										                                     
        xls.SetCellValue(x, 19, "altra_comunita")                             '(20,rs("ALTRA_COMUNITA"))            	                     		
        xls.SetCellValue(x, 20, "numero_persone_a_rischio")                   '(3,rs("NUMERO_PERSONE_A_RISCHIO"))         	                                              
        xls.SetCellValue(x, 21, "indirizzo_comunita")                         '40,rs("INDIRIZZO_COMUNITA")) 										'professione                            
        xls.SetCellValue(x, 22, "agente_eziologico")                          '(27,rs("AGENTE_EZIOLOGICO"))																	'altra prof
        xls.SetCellValue(x, 23, "altro_Agente")                               '(27,rs("ALTRO_AGENTE"))																	'vive collettività 1=si;2=no;9 = non noto
        xls.SetCellValue(x, 24, "codice_agente_eziologico")                      '(2,rs("CODICE_AGENTE_EZIOLOGICO"))	
        xls.SetCellValue(x, 25, "identificazione_agente")                        ' (1,rs("IDENTIFICAZIONE_AGENTE"))
        xls.SetCellValue(x, 26, "veicolo")                                       '(27,rs("VEICOLO"))
        xls.SetCellValue(x, 27, "identificazione_veicolo")                        ' 1,rs("IDENTIFICAZIONE_VEICOLO"))												'codice usl di domicilio
        xls.SetCellValue(x, 28, "data_epidemia")                                  ' 8,rs("DATA_EPIDEMIA"))														'codice regione residenza
        xls.SetCellValue(x, 29, "durata")                                         ' 3,rs("DURATA"))													'sigla provincia residenza
        xls.SetCellValue(x, 30, "numero_casi")                                   '4,rs("NUMERO_CASI"))										'comune residenza									
        xls.SetCellValue(x, 31, "stato_estero_epidemia")                         '(20,rs("STATO_ESTERO_EPIDEMIA"))							'deceduto
        xls.SetCellValue(x, 32, "codice_stato_estero")                            '3,rs("CODICE_STATO_ESTERO"))			'data inizio terapia
        xls.SetCellValue(x, 33, "usl_epidemia")                                  '(20,rs("USL_EPIDEMIA"))
        xls.SetCellValue(x, 34, "regione_epidemia")                              '(20,rs("REGIONE_EPIDEMIA"))
        xls.SetCellValue(x, 35, "data_notifica")                                  '(8,rs("DATA_NOTIFICA"))
        xls.SetCellValue(x, 36, "sanitario")                                     '(36,rs("SANITARIO"))
        xls.SetCellValue(x, 37, "recapito_Sanitario")                                 '(62,rs("RECAPITO_SANITARIO"))
        xls.SetCellValue(x, 38, "telefono_sanitario")                            '(22,rs("TELEFONO_SANITARIO"))
        xls.SetCellValue(x, 39, "note")


        x = x + 1

        For Each element As Notifica_Esporta_Classe_4Result In ds


            With element
                xls.SetCellValue(x, 1, Helper.IsNull(.numero_record).PadRight(6))                                                 '(6,rs("numero_record"))				'NUMERO RECORD
                xls.SetCellValue(x, 2, Helper.IsNull(.data_compilazione).PadRight(8))                                             '8,rs("data_compilazione"))			'DATA COMPILAZIONE
                xls.SetCellValue(x, 3, Helper.IsNull(.denominazione_regione).PadRight(20))                                         '(20, rs("denominazione_regione"))
                xls.SetCellValue(x, 4, Helper.IsNull(.codice_regione).PadRight(2))                                                '(2,rs("codice_regione"))              										'codice regione segnalazione              
                xls.SetCellValue(x, 5, Helper.IsNull(.denominazione_provincia).PadRight(20))                                       'as 20,rs("DENOMINAZIONE_PROVINCIA"))               'sigla provincia segnalazione              
                xls.SetCellValue(x, 6, Helper.IsNull(.sigla_provincia).PadRight(2))                                               '(2,rs("SIGLA_PROVINCIA"))                               										'codice provincia segnalazione              
                xls.SetCellValue(x, 7, Helper.IsNull(.codice_provincia).PadRight(3))                                              '(3,rs("CODICE_PROVINCIA"))                  	 									'codice comune segnalazione                    
                xls.SetCellValue(x, 8, Helper.IsNull(.denominazione_comune).PadRight(20))                                          '(20,rs("DENOMINAZIONE_COMUNE"))   											'numero usl                                   
                xls.SetCellValue(x, 9, Helper.IsNull(.codice_comune).PadRight(6))                                                 '(6,"CODICE_COMUNE")																		'codice distretto segnalazione                  
                xls.SetCellValue(x, 10, Helper.IsNull(.denominazione_usl).PadRight(20))                                           ' --(20,rs("DENOMINAZIONE_USL"))                    										'cognome                                    
                xls.SetCellValue(x, 11, Helper.IsNull(.numero_usl).PadRight(2))                                                  '--(2,rs("NUMERO_USL"))                          										'nome                                      
                xls.SetCellValue(x, 12, Helper.IsNull(.ex_usl).PadRight(3))                                                      ' --(3,rs("EX_USL"))                        										'sesso                                       
                xls.SetCellValue(x, 13, Helper.IsNull(.codusl).PadRight(7))                                                      ' --(7,rs("CODUSL"))                              							'data di nascita                             
                xls.SetCellValue(x, 14, Helper.IsNull(.distr).PadRight(2))                                      ' --(2,rs("DISTR"))       									        'fascia di età                           
                xls.SetCellValue(x, 15, Helper.IsNull(.focolaio_epidemico).PadRight(25))                         '(25,rs("FOCOLAIO_EPIDEMICO"))                       										'numero mesi di età                      
                xls.SetCellValue(x, 16, Helper.IsNull(.altro_focolaio).PadRight(25))                             '(25,rs("ALTRO_FOCOLAIO"))                       										'numero di età in anni                   
                xls.SetCellValue(x, 17, Helper.IsNull(.codice_scheda).PadRight(6))                              '6,rs("CODICE_SCHEDA"))  													'sempre valorizzato 1 = italia,italiana ; 2 = estera; 9 = assente o non nota
                xls.SetCellValue(x, 18, Helper.IsNull(.comunita).PadRight(20))                                   '(20,rs("COMUNITA"))                     										                                     
                xls.SetCellValue(x, 19, Helper.IsNull(.altra_comunita).PadRight(20))                             '(20,rs("ALTRA_COMUNITA"))            	                     		
                xls.SetCellValue(x, 20, Helper.IsNull(.numero_persone_a_rischio).PadRight(3))                   '(3,rs("NUMERO_PERSONE_A_RISCHIO"))         	                                              
                xls.SetCellValue(x, 21, Helper.IsNull(.indirizzo_comunita).PadRight(40))                         '40,rs("INDIRIZZO_COMUNITA")) 										'professione                            
                xls.SetCellValue(x, 22, Helper.IsNull(.agente_eziologico).PadRight(27))                          '(27,rs("AGENTE_EZIOLOGICO"))																	'altra prof
                xls.SetCellValue(x, 23, Helper.IsNull(.altro_Agente).PadRight(27))                               '(27,rs("ALTRO_AGENTE"))																	'vive collettività 1=si;2=no;9 = non noto
                xls.SetCellValue(x, 24, Helper.IsNull(.codice_agente_eziologico).PadRight(2))                      '(2,rs("CODICE_AGENTE_EZIOLOGICO"))	
                xls.SetCellValue(x, 25, Helper.IsNull(.identificazione_agente).PadRight(1))                        ' (1,rs("IDENTIFICAZIONE_AGENTE"))
                xls.SetCellValue(x, 26, Helper.IsNull(.veicolo).PadRight(27))                                       '(27,rs("VEICOLO"))
                xls.SetCellValue(x, 27, Helper.IsNull(.identificazione_veicolo).PadRight(1))                        ' 1,rs("IDENTIFICAZIONE_VEICOLO"))												'codice usl di domicilio
                xls.SetCellValue(x, 28, Helper.IsNull(.data_epidemia).PadRight(8))                                  ' 8,rs("DATA_EPIDEMIA"))														'codice regione residenza
                xls.SetCellValue(x, 29, Helper.IsNull(.durata).PadRight(3))                                         ' 3,rs("DURATA"))													'sigla provincia residenza
                xls.SetCellValue(x, 30, Helper.IsNull(.numero_casi).PadRight(4))                                   '4,rs("NUMERO_CASI"))										'comune residenza									
                xls.SetCellValue(x, 31, Helper.IsNull(.stato_estero_epidemia).PadRight(20))                         '(20,rs("STATO_ESTERO_EPIDEMIA"))							'deceduto
                xls.SetCellValue(x, 32, Helper.IsNull(.codice_stato_estero).PadRight(3))                            '3,rs("CODICE_STATO_ESTERO"))			'data inizio terapia
                xls.SetCellValue(x, 33, Helper.IsNull(.usl_epidemia).PadRight(20))                                  '(20,rs("USL_EPIDEMIA"))
                xls.SetCellValue(x, 34, Helper.IsNull(.regione_epidemia).PadRight(20))                              '(20,rs("REGIONE_EPIDEMIA"))
                xls.SetCellValue(x, 35, Helper.IsNull(.data_notifica).PadRight(8))                                  '(8,rs("DATA_NOTIFICA"))
                xls.SetCellValue(x, 36, Helper.IsNull(.sanitario).PadRight(36))                                     '(36,rs("SANITARIO"))
                xls.SetCellValue(x, 37, Helper.IsNull(.recapito_Sanitario).PadRight(62))                                 '(62,rs("RECAPITO_SANITARIO"))
                xls.SetCellValue(x, 38, Helper.IsNull(.telefono_sanitario).PadRight(22))                            '(22,rs("TELEFONO_SANITARIO"))
                xls.SetCellValue(x, 39, Helper.IsNull(.note).PadRight(65))                                       ' 65,rs("NOTE"))	
                x = x + 1
            End With
        Next
    End Sub
    Protected Sub btnEsportaEx_Click(sender As Object, e As System.EventArgs) Handles btnEsportaEx.Click
        CreaExcel()
    End Sub
End Class
