Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Helper
Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text

Partial Class Notifica_Riepilogo
    Inherits System.Web.UI.Page
    Private _idMalattia As Integer = 0
    Private _idNotifica As Integer = 0
    Private _malattia As String = ""
    Private _nomelbl As String = ""
    Private _cognomelbl As String = ""
    Private _esito As Integer = 0
    Private _ruolo As String = ""
    Private _mobjNotifica As New BllNotifica
    Private _mobMalattia As New BllMalattie
    Private _mobjUser As New BllUser
    Private _mobMib As New BllMib
    Private _lettura As Boolean = True
    Private _aggiornamento As Boolean = True
    Private _eliminazione As Boolean = True
   
    'Private _tbc As New BllTbc
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_malattia", _malattia)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_nomelbl", _nomelbl)
        Me.ViewState.Add("_cognomelbl", _cognomelbl)
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_ruolo", _ruolo)
        Me.ViewState.Add("_lettura", _lettura)
        Me.ViewState.Add("_aggiornamento", _aggiornamento)
        Me.ViewState.Add("_eliminazione", _eliminazione)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _malattia = ViewState("_malattia")
        _idMalattia = CInt(ViewState("_idMalattia"))
        _idNotifica = CInt(ViewState("_idNotifica"))
        _nomelbl = ViewState("_nomelbl")
        _cognomelbl = ViewState("_cognomelbl")
        _ruolo = ViewState("_ruolo")
        _lettura = CBool(ViewState("_lettura"))
        _aggiornamento = CBool(ViewState("_aggiornamento"))
        _eliminazione = CBool(ViewState("_eliminazione"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        message.Text = ""
        message.Visible = False
        If Not Page.IsPostBack Then
            Dim currRoles() As String = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name)
            Dim profilo As Utenti_Profilo = _mobjUser.GetProfiloByUsername(User.Identity.Name)
            _ruolo = currRoles(0).ToString
            _lettura = profilo.Letttura
            _aggiornamento = profilo.Aggiornamento
            _eliminazione = profilo.Eliminazione
            _idNotifica = CInt(Session("idNotifica"))
            impostaJavascript()
            If CInt(Request.QueryString("esito")) <> 0 Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "AlertMsg", "alert('salvataggio effettuato con successo');", True)
                _esito = 0
            End If
            Dim tab As String = Request.QueryString("tab")
            CaricaValori()
            CaricaTab(tab)
        End If
        ControllaStatoScheda()
    End Sub
    Private Sub ControllaStatoScheda()
        UcAnagrafica1.Modifica = True
        UcClinici1.Modifica = True
        UcTubercolosi.Modifica = True
        UcTubercolosiFattori1.Modifica = True
        ' ViewEsami1.Modifica = True
        UcStato1.Modifica = True
        'lnkAggiorna.Visible = True
        UcMib1.Modifica = True
        Me.UcTabMalaria.Modifica = True

        If stato.Text = "Archiviata" Then
            UcAnagrafica1.Modifica = False
            UcClinici1.Modifica = False
            UcTubercolosi.Modifica = False
            UcTubercolosiFattori1.Modifica = False
            '   ViewEsami1.Modifica = False
            UcStato1.Modifica = False
            '  lnkAggiorna.Visible = False
            pnlInvalida.Visible = False
            pnlNotifica.Visible = False
            Me.UcMib1.Modifica = False
            Me.UcTabMalaria.Modifica = False
        End If

        If stato.Text = "Notifica" Then
            pnlNotifica.Visible = False

            UcAnagrafica1.Modifica = True
            UcClinici1.Modifica = True
            UcTubercolosi.Modifica = True
            UcStato1.Modifica = True
            Me.UcMib1.Modifica = True
            Me.UcTabMalaria.Modifica = True
        End If

        'If Not User.IsInRole("asl") Then
        If _ruolo <> "asl" And _ruolo <> "regione" And _ruolo <> "laboratorio" And _ruolo <> "medico" Then
            UcAnagrafica1.Modifica = False
            UcClinici1.Modifica = False
            UcTubercolosi.Modifica = False
            Me.UcTabMalaria.Modifica = False
            UcStato1.Modifica = False
            Me.UcMib1.Modifica = False
            UcTubercolosiFattori1.Modifica = False
            pnlInvalida.Visible = False
            pnlNotifica.Visible = False
        End If



        If _ruolo = "medico" Then
            pnlNotifica.Visible = False
            If stato.Text = "Notifica" Then
                UcAnagrafica1.Modifica = False
                UcClinici1.Modifica = False
                UcTubercolosi.Modifica = False
                Me.UcTabMalaria.Modifica = False
                UcStato1.Modifica = False
                Me.UcMib1.Modifica = False
                UcTubercolosiFattori1.Modifica = False
                pnlInvalida.Visible = False                
            End If
        End If


        If _aggiornamento = False Then
            UcAnagrafica1.Modifica = False
            UcClinici1.Modifica = False
            UcTubercolosi.Modifica = False
            UcTubercolosiFattori1.Modifica = False
            '   ViewEsami1.Modifica = False
            UcStato1.Modifica = False
            '  lnkAggiorna.Visible = False
            pnlInvalida.Visible = False
            pnlNotifica.Visible = False
            Me.UcMib1.Modifica = False
            Me.UcTabMalaria.Modifica = False
        End If


        UcClinici1.ControllaModifica()
        UcAnagrafica1.ControllaModifica()
        UcStato1.ControllaModifica()
        UcTubercolosi.ControllaModifica()
        UcTubercolosiFattori1.ControllaModifica()
        UcMib1.ControllaModifica()
        UcTabMalaria.ControllaModifica()





    End Sub
    Private Sub CaricaValori()
        Dim notificaInfo As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)
        With notificaInfo
            _malattia = .malattia
            _idMalattia = .idmalattia
            _nomelbl = .nome
            _cognomelbl = .cognome
            cognome.Text = .cognome
            nome.Text = .nome
            '  Classificazione.Text = .classificazione
            malattiaLabel.Text = .malattia
            stato.Text = .stato

            UcStato1.segnalatore = .medicoSegnalatore
            UcStato1.referente = .ReferenteUlss
            UcStato1.dataNotifica = Helper.IsNullDate(.DataNotifica)
            UcStato1.dataSegnalazione = .DataSegnalazione
            UcStato1.aslNotifica = .AslNotifica
            UcStato1.aslResidenza = .AslRes
            UcStato1.inserita = .username
            UcStato1.origineSegnalazione = .origineSegnalazione
        End With
    End Sub
    Private Sub CaricaTab(ByVal tab As String)

        UcAnagrafica1.IdNotifica = _idNotifica
        UcClinici1.IdNotifica = _idNotifica
        'ViewEsami1.IdNotifica = _idNotifica
        'ViewEsami1.AbilitaModifiche = False
        UcTubercolosi.IdNotifica = _idNotifica


        Me.TabSpecifico.Visible = False
        Me.TabFattoriTbc.Visible = False
        Me.TabMalaria.Visible = False


        If _malattia = "Tubercolosi" Or _malattia = "Micobatteriosi non tubercolare" Then
            Me.TabSpecifico.Visible = True
            Me.TabFattoriTbc.Visible = True
            Me.UcTubercolosi.IdNotifica = _idNotifica
            Me.UcTubercolosiFattori1.IdNotifica = _idNotifica
        End If


        If _malattia = "Malaria" Then
            TabMalaria.Visible = True
            UcTabMalaria.IdNotifica = _idNotifica
        End If


        If _mobMalattia.isMib(_idMalattia) Then
            Me.TabMib.Visible = True

            Me.UcMib1.Visible = True
            Me.UcMib1.IdNotifica = _idNotifica


        Else
            Me.TabMib.Visible = False
            Me.UcMib1.Visible = False
        End If

        'If _idMalattia = 142 Or _idMalattia = 14 Or _idMalattia = 138 Then


        'Else

        'End If


        Select Case tab
            Case ""
                TabContainer1.ActiveTabIndex = 0
            Case "anagrafica"
                TabContainer1.ActiveTabIndex = 1
            Case "Clinico"
                TabContainer1.ActiveTabIndex = 2
                'Case "esami"
                '    TabContainer1.ActiveTabIndex = 5
            Case "extra"
                TabContainer1.ActiveTabIndex = 3
            Case "fattori"
                TabContainer1.ActiveTabIndex = 4
            Case "mib"
                TabContainer1.ActiveTabIndex = 6
            Case "malaria"
                TabContainer1.ActiveTabIndex = 5

        End Select

        '  TabEsami.Visible = False

    End Sub
    'Protected Sub lnkAggiorna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAggiorna.Click
    '    Response.Redirect("~/Notifica/EditEsami.aspx", True)
    'End Sub
    Protected Sub invalida_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles invalida.Click
        _mobjNotifica.CambiaStato(_idNotifica, "Archiviata")
        CaricaValori()
        CaricaTab(0)
        ControllaStatoScheda()

    End Sub
    Protected Sub notifica_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles notifica.Click
        Dim lista As New List(Of String)
        If _mobjNotifica.Notificabile(_idNotifica, lista, _idMalattia) = True Then
            _mobjNotifica.CambiaStato(_idNotifica, "Notifica")
            CaricaValori()
            CaricaTab(0)
            ControllaStatoScheda()
        Else
            For Each s As String In lista
                message.Text = s & message.Text
            Next
            message.Visible = True
        End If

    End Sub
    Private Sub impostaJavascript()
        invalida.Attributes("onclick") = "javascript:return confirm('Attenzione il record verrà invalidato, proseguire ?');"
        notifica.Attributes("onclick") = "javascript:return confirm('Si sta per notificare la segnalazione, proseguire ?');"
        '  stampa.Attributes("onclick") = "javascript:alert('La stampa sarà implementata dopo la fase di test');return false;"
    End Sub

    Protected Sub messaggio_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles messaggio.Click
        Response.Redirect("~/messaggi/nuovo.aspx?tipo=notifica", True)
    End Sub

    Protected Sub storico_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles storico.Click
        Response.Redirect("storico.aspx", True)
    End Sub
    'Private Function MalattiaPdf() As MemoryStream

    'End Function
    Private Sub StampaPdf()

        Using pdfMerge As New MemoryStream
            Dim doc As New Document
            Dim numberofPAges As Integer = 0
            Dim currentPAgeNumber As Integer = 0
            Dim writere As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, pdfMerge)
            doc.Open()
            Dim cb As iTextSharp.text.pdf.PdfContentByte = writere.DirectContent
            Dim page As iTextSharp.text.pdf.PdfImportedPage
            Dim rotation As Integer

            'MemStream.WriteTo(Response.OutputStream)

            Dim pdfTemplate As String = Server.MapPath("~/Stampe/malattia.pdf")
            Dim pdfTemplateMib As String = Server.MapPath("~/Stampe/Mib.pdf")
            Dim pdfTemplateTbc As String = Server.MapPath("~/Stampe/tubercolosi.pdf")
            Dim pdfTemplateMal As String = Server.MapPath("~/Stampe/malaria.pdf")

            Dim MemStream As New MemoryStream
            Dim MemStreamMib As New MemoryStream

            Using m As New MemoryStream


                Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)
                Dim pdfStampera As PdfStamper = New PdfStamper(pdfReader, m)
                Dim pdfFormFields As AcroFields = pdfStampera.AcroFields



                pdfStampera.Writer.CloseStream = False

                Dim c As Clinica_ViewResult = _mobjNotifica.GetClinicaView(_idNotifica)
                Dim a As Anagrafica_ViewResult = _mobjNotifica.GetAnagraficaView(_idNotifica)
                Dim n As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)



                pdfFormFields.SetField("malattia", n.malattia)
                pdfFormFields.SetField("regione", n.regione)
                pdfFormFields.SetField("datasegnalazione", Helper.IsNullDate(n.DataSegnalazione))
                pdfFormFields.SetField("datanotifica", Helper.IsNullDate(n.DataNotifica))
                pdfFormFields.SetField("aslnotifica", n.AslNotifica)
                pdfFormFields.SetField("aslresidenza", n.AslRes)
                pdfFormFields.SetField("referenteusl", n.ReferenteUlss)
                pdfFormFields.SetField("segnalatore", n.medicoSegnalatore)
                pdfFormFields.SetField("nome", a.Nome)
                pdfFormFields.SetField("cognome", a.Cognome)
                pdfFormFields.SetField("sesso", a.Sesso)
                pdfFormFields.SetField("natoestero", a.NatoEstero)
                pdfFormFields.SetField("provincianascita", a.Provincia_nascita)
                pdfFormFields.SetField("luogonascita", a.Nazione_Nascita)
                pdfFormFields.SetField("datanascita", Helper.IsNullDate(a.DataNascita))
                pdfFormFields.SetField("nazionalita", a.Nazionalita)
                pdfFormFields.SetField("codicefiscale", a.CodiceFiscale)
                pdfFormFields.SetField("smtp", a.NumeroStp)
                pdfFormFields.SetField("eni", a.codiceEni)
                pdfFormFields.SetField("noninregola", a.StranieroNonInRegola)
                pdfFormFields.SetField("professione", a.Professione)
                pdfFormFields.SetField("senzafissadimora", a.SenzaFissaDimora)
                pdfFormFields.SetField("provinciadomicilio", a.Provincia_Domicilio)
                pdfFormFields.SetField("nazioneresidenza", a.nazione_residenza)
                pdfFormFields.SetField("comunedomicilio", a.Comune_domicilio)
                pdfFormFields.SetField("provinciaresidenza", a.Provincia_Residenza)
                pdfFormFields.SetField("indirizzodomicilio", a.indirizzoDomicilio)
                pdfFormFields.SetField("comuneresidenza", a.Comune_Residenza)
                pdfFormFields.SetField("telefono", a.Telefono)
                pdfFormFields.SetField("indirizzoresidenza", a.IndirizzoResidenza)
                pdfFormFields.SetField("clinico", c.CriterioClinico)
                pdfFormFields.SetField("epidemiologico", c.CriterioEpidemiologico)
                pdfFormFields.SetField("laboratorio", c.CriterioLaboratorio)
                pdfFormFields.SetField("dataprimisintomi", Helper.IsNullDate(c.DataPrimiSintomi))
                pdfFormFields.SetField("vaccinato", c.StatoVaccinale)
                pdfFormFields.SetField("nazionesintomi", c.nazionePrimiSintomi)
                pdfFormFields.SetField("provinciasintomi", c.provinciaSintomi)
                pdfFormFields.SetField("comunesintomi", c.comuneSintomi)
                pdfFormFields.SetField("dosevaccino", c.DoseVaccino)
                pdfFormFields.SetField("ultimadose", Helper.IsNullDate(c.DataDoseUltimoVaccino))
                pdfFormFields.SetField("ricovero", c.RicoveroOspedaliero)
                pdfFormFields.SetField("strutturaricovero", c.StrutturaRicovero)
                pdfFormFields.SetField("repartoricovero", c.Reparto)
                pdfFormFields.SetField("motivoricovero", c.MotivoDelRicovero)
                pdfFormFields.SetField("dataricovero", Helper.IsNullDate(c.DataRicovero))
                pdfFormFields.SetField("datadimissione", Helper.IsNullDate(c.DataDimissione))
                pdfFormFields.SetField("tiporicerca", c.ricerca1)
                pdfFormFields.SetField("dataesame", Helper.IsNullDate(c.dataesame1))
                pdfFormFields.SetField("luogoesame", c.luogo1)
                pdfFormFields.SetField("risultato", c.risultato1)
                pdfFormFields.SetField("tiporicerca2", c.ricerca2)
                pdfFormFields.SetField("tipoesame2", c.ricerca2)
                pdfFormFields.SetField("luogoesame2", c.luogo2)
                pdfFormFields.SetField("dataesame2", Helper.IsNullDate(c.dataesame2))
                pdfFormFields.SetField("risultato2", c.risultato2)
                pdfFormFields.SetField("nazione1", c.nazione1)
                pdfFormFields.SetField("nazione2", c.nazione2)
                pdfFormFields.SetField("nazione3", c.nazione3)
                pdfFormFields.SetField("periodo1", c.nazione1Periodo)
                pdfFormFields.SetField("periodo2", c.nazione2Periodo)
                pdfFormFields.SetField("periodo3", c.nazione3Periodo)
                pdfFormFields.SetField("nazionecontagio", c.nazioneContagio)
                pdfFormFields.SetField("provinciacontagio", c.provinciaContagio)
                pdfFormFields.SetField("comunecontagio", c.comuneContagio)
                pdfFormFields.SetField("casicorrelati", c.CasiCorrelati)
                pdfFormFields.SetField("contattistretti", c.ContattiStretti)
                pdfFormFields.SetField("collettivita", c.comunita)
                pdfFormFields.SetField("altracollettivita", c.AltraColletivita)
                pdfFormFields.SetField("pazientedeceduto", c.deceduto)
                pdfFormFields.SetField("note", c.Note)

                pdfStampera.FormFlattening = True
                pdfReader.Close()
                pdfStampera.Close()

                m.Position = 0

                Dim reader As New PdfReader(m)
                numberofPAges = reader.NumberOfPages
                currentPAgeNumber = 0

                Do While currentPAgeNumber < numberofPAges
                    currentPAgeNumber += 1
                    doc.SetPageSize(PageSize.A4)
                    doc.NewPage()
                    page = writere.GetImportedPage(reader, currentPAgeNumber)
                    rotation = reader.GetPageRotation(currentPAgeNumber)
                    If (rotation = 90) Or (rotation = 270) Then
                        cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(currentPAgeNumber).Height)
                    Else
                        cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                    End If
                Loop
            End Using
            If _mobMalattia.isMib(_idMalattia) Then


                Dim mib As notifica_View_mibResult = _mobMib.GetMibView(_idNotifica)





                Using m As New MemoryStream


                    Dim pdfReader As PdfReader = New PdfReader(pdfTemplateMib)
                    Dim pdfStampera As PdfStamper = New PdfStamper(pdfReader, m)
                    Dim pdfFormFields As AcroFields = pdfStampera.AcroFields



                    pdfStampera.Writer.CloseStream = False



                    If Not IsNothing(mib) Then

                        pdfFormFields.SetField("sepsi", mib.Qc_Sepsi)
                        pdfFormFields.SetField("meningite", mib.Qc_Meningite)
                        pdfFormFields.SetField("epiglottide", mib.QC_Epiglottite)
                        pdfFormFields.SetField("cellulite", mib.QC_Cellulite)
                        pdfFormFields.SetField("pericardite", mib.QC_Pericardite)
                        pdfFormFields.SetField("artrite", mib.QC_Artrite)
                        pdfFormFields.SetField("polmonite", mib.Qc_Polmonite)
                        pdfFormFields.SetField("altra", mib.QC_Altro)
                        pdfFormFields.SetField("agenteeziologico", mib.IdAgenteEziologico)
                        pdfFormFields.SetField("altroagente", mib.AltroAgente)
                        pdfFormFields.SetField("liquor", mib.Liquor)
                        pdfFormFields.SetField("dataprelievo", Helper.IsNullDate(mib.dataprelievo))
                        pdfFormFields.SetField("personacontatto", mib.ContattoLab)
                        pdfFormFields.SetField("telefonolaboratorio", mib.ContattoTelefono)
                        pdfFormFields.SetField("metododiagnostico1", mib.Metodo1)
                        pdfFormFields.SetField("metododiagnostico2", mib.Metodo2)
                        pdfFormFields.SetField("materiale1", mib.Materiale1)
                        pdfFormFields.SetField("materiale2", mib.Materiale2)
                        pdfFormFields.SetField("tipizzazioneeffettuata", mib.Tipizzazione)
                        pdfFormFields.SetField("riferimentilaboratorio", "") 'riferimento laboratorio
                        pdfFormFields.SetField("speciebatterio", mib.LabBatterio)
                        pdfFormFields.SetField("altrobatterio", mib.LabAltroBatterio)
                        pdfFormFields.SetField("LabSierogruppoMen", mib.LabSierogruppoMen)
                        pdfFormFields.SetField("LabSierotipoPNU", mib.LabSierotipoPNU)
                        pdfFormFields.SetField("Pg_Val", mib.Pg_Val)
                        pdfFormFields.SetField("Pg_Mic", mib.Pg_Mic)
                        pdfFormFields.SetField("Pg_Cat", mib.Pg_Cat)
                        pdfFormFields.SetField("Pg_Val_Est", mib.Pg_Val_Est)
                        pdfFormFields.SetField("Pg_Mic_Est", mib.Pg_Mic_Est)
                        pdfFormFields.SetField("Pg_Cat_ESt", mib.Pg_Cat_ESt)
                        pdfFormFields.SetField("Pg_disco", mib.Pg_disco)
                        pdfFormFields.SetField("Pg_Disco_Cat", mib.Pg_Disco_Cat)
                        pdfFormFields.SetField("Em_val", mib.Em_val)
                        pdfFormFields.SetField("Em_Mic", mib.Em_Mic)
                        pdfFormFields.SetField("Em_Cat", mib.Em_Cat)
                        pdfFormFields.SetField("Em_val_est", mib.Em_val_est)
                        pdfFormFields.SetField("Em_Mic_Est", mib.Em_Mic_Est)
                        pdfFormFields.SetField("Em_Cat_Est", mib.Em_Cat_Est)
                        pdfFormFields.SetField("Em_disco", mib.Em_disco)
                        pdfFormFields.SetField("Em_Disco_Cat", mib.Em_Disco_Cat)
                        pdfFormFields.SetField("Cip_Val", mib.Cip_Val)
                        pdfFormFields.SetField("Cip_Mic", mib.Cip_Mic)
                        pdfFormFields.SetField("Cip_Cat", mib.Cip_Cat)
                        pdfFormFields.SetField("Cip_Val_Est", mib.Cip_Val_Est)
                        pdfFormFields.SetField("Cip_Mic_Est", mib.Cip_Mic_Est)
                        pdfFormFields.SetField("Cip_Cat_Est", mib.Cip_Cat_Est)
                        pdfFormFields.SetField("Cip_Disco", mib.Cip_Disco)
                        pdfFormFields.SetField("Cip_Disco_Cat", mib.Cip_Disco_Cat)
                        pdfFormFields.SetField("Cli_Val", mib.Cli_Val)
                        pdfFormFields.SetField("Cli_Mic", mib.Cli_Mic)
                        pdfFormFields.SetField("Cli_Cat", mib.Cli_Cat)
                        pdfFormFields.SetField("Cli_Val_Est", mib.Cli_Val_Est)
                        pdfFormFields.SetField("Cli_Mic_Est", mib.Cli_Mic_Est)
                        pdfFormFields.SetField("Cli_Cat_Est", mib.Cli_Cat_Est)
                        pdfFormFields.SetField("Cli_Disco", mib.Cli_Disco)
                        pdfFormFields.SetField("Cli_Disco_Cat", mib.Cli_Disco_Cat)
                        pdfFormFields.SetField("LabSierotipoHI", mib.LabSierotipoHI)
                        'pdfFormFields.SetField("altrosierotipohi", mib.al)
                        pdfFormFields.SetField("note", mib.NoteDiagnosi)

                    End If

                    pdfStampera.FormFlattening = True
                    pdfReader.Close()
                    pdfStampera.Close()


                    m.Position = 0
                    Dim reader2 As New PdfReader(m)

                    numberofPAges = reader2.NumberOfPages
                    currentPAgeNumber = 0

                    Do While currentPAgeNumber < numberofPAges
                        currentPAgeNumber += 1
                        doc.SetPageSize(PageSize.A4)
                        doc.NewPage()
                        page = writere.GetImportedPage(reader2, currentPAgeNumber)
                        rotation = reader2.GetPageRotation(currentPAgeNumber)
                        If (rotation = 90) Or (rotation = 270) Then

                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader2.GetPageSizeWithRotation(currentPAgeNumber).Height)
                        Else
                            cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                        End If
                    Loop

                End Using
                '
            End If



            If _mobMalattia.isTbc(_idMalattia) Then


                Dim tbc As Notifica_Tbc = _mobjNotifica.GetTbc_View(_idNotifica)
                Dim tbcFattori As Notifica_Tbc_Fattori = _mobjNotifica.GetTbcFAttori(_idNotifica)





                Using m As New MemoryStream


                    Dim pdfReader As PdfReader = New PdfReader(pdfTemplateTbc)
                    Dim pdfStampera As PdfStamper = New PdfStamper(pdfReader, m)
                    Dim pdfFormFields As AcroFields = pdfStampera.AcroFields



                    pdfStampera.Writer.CloseStream = False



                    If Not IsNothing(tbc) Then


                        pdfFormFields.SetField("AgenteEziologico", tbc.AgenteEziologico)
                        pdfFormFields.SetField("AltroAgente", tbc.AltroAgente)
                        pdfFormFields.SetField("AnnoTbcPassato", tbc.AnnoTbcPassato)
                        pdfFormFields.SetField("Antibiogramma", tbc.Antibiogramma)
                        pdfFormFields.SetField("DataInizioTerapia", Helper.IsNullDate(tbc.DataInizioTerapia))
                        pdfFormFields.SetField("DiagnosiTbcPassato", tbc.DiagnosiTbcPassato)
                        pdfFormFields.SetField("Disseminata", tbc.Disseminata)
                        pdfFormFields.SetField("ExtraPolmonare", tbc.ExtraPolmonare)
                        pdfFormFields.SetField("LivelloDiAccertamento", tbc.LivelloDiAccertamento)
                        pdfFormFields.SetField("localizzazione1", tbc.localizzazione1)
                        pdfFormFields.SetField("localizzazione2", tbc.localizzazione2)
                        pdfFormFields.SetField("MeseTbcPAssato", tbc.MeseTbcPAssato)
                        pdfFormFields.SetField("Miliare", tbc.Miliare)
                        '.MotivoIterDiagnostico = 
                        pdfFormFields.SetField("Note", tbc.Note)
                        pdfFormFields.SetField("SedePolmonare", tbc.SedePolmonare)
                        pdfFormFields.SetField("tipo", tbc.tipo)
                        pdfFormFields.SetField("TipoClassificazione", tbc.TipoClassificazione)
                        '.TipoIterDiagnostico = tipo
                        pdfFormFields.SetField("STRE", tbc.STRE)
                        pdfFormFields.SetField("INH", tbc.INH)
                        pdfFormFields.SetField("RMP", tbc.RMP)
                        pdfFormFields.SetField("EMB", tbc.EMB)
                        pdfFormFields.SetField("PZA", tbc.PZA)

                        pdfFormFields.SetField("DataInizioTerapia", Helper.IsNullDate(tbc.DataInizioTerapia))
                        pdfFormFields.SetField("IsoniazideInizio", tbc.IsoniazideInizio)
                        pdfFormFields.SetField("IsoniazideFine", tbc.IsoniazideFine)
                        pdfFormFields.SetField("RifampicinaInizio", tbc.RifampicinaInizio)
                        pdfFormFields.SetField("RifampicinaFine", tbc.RifampicinaFine)
                        pdfFormFields.SetField("PirazinamideInizio", tbc.PirazinamideInizio)
                        pdfFormFields.SetField("PirazinamideFine", tbc.PirazinamideFine)
                        pdfFormFields.SetField("EtambutoloInizio", tbc.EtambutoloInizio)
                        pdfFormFields.SetField("EtambutoloFine", tbc.EtambutoloFine)
                        pdfFormFields.SetField("TerapiaModificata", tbc.TerapiaModificata)
                        pdfFormFields.SetField("Esito", tbc.Esito)
                        pdfFormFields.SetField("trasferito", tbc.trasferito)
                        pdfFormFields.SetField("DataChiusura", Helper.IsNullDate(tbc.DataChiusura))
                        pdfFormFields.SetField("trattamentoInterotto", tbc.trattamentoInterotto)

                        pdfFormFields.SetField("EsameColturaleEscreato", tbc.EsameColturaleEscreato)
                        pdfFormFields.SetField("EsameColturaleAltroMateriale", tbc.EsameColturaleAltroMateriale)
                        pdfFormFields.SetField("EsameColturaleAltroDesc", tbc.EsameColturaleAltroDesc)
                        pdfFormFields.SetField("EsameDirettoEscreato", tbc.EsameDirettoEscreato)
                        pdfFormFields.SetField("Esamedirettoaltromateriale", tbc.Esamedirettoaltromateriale)
                        pdfFormFields.SetField("EsamedirettoaltromaterialeDesc", tbc.EsamedirettoaltromaterialeDesc)
                        pdfFormFields.SetField("Clinica", tbc.Clinica)
                        pdfFormFields.SetField("Mantoux", tbc.Mantoux)
                        pdfFormFields.SetField("RxStandard", tbc.RxStandard)
                        pdfFormFields.SetField("RispostaTerapia", tbc.RispostaTerapia)
                        pdfFormFields.SetField("RiscontroAutopico", tbc.RiscontroAutopico)
                        pdfFormFields.SetField("Quantiferon", tbc.Quantiferon)



                        pdfFormFields.SetField("Rifampicin", tbc.Rifampicin)
                        pdfFormFields.SetField("Isoniazide", tbc.Isoniazide)
                        pdfFormFields.SetField("Pirazinamide", tbc.Pirazinamide)
                        pdfFormFields.SetField("Etambutolo", tbc.Etambutolo)


                        pdfFormFields.SetField("Altro1", tbc.Altro1)
                        pdfFormFields.SetField("Altro1Inizio", tbc.Altro1Inizio)
                        pdfFormFields.SetField("Altro1Fine", tbc.Altro1Fine)
                        pdfFormFields.SetField("Altro2", tbc.Altro2)
                        pdfFormFields.SetField("Altro2Inizio", tbc.Altro2Inizio)
                        pdfFormFields.SetField("Altro2Fine", tbc.Altro2Fine)
                        pdfFormFields.SetField("Altro3", tbc.Altro3)
                        pdfFormFields.SetField("Altro3Inizio", tbc.Altro3Inizio)
                        pdfFormFields.SetField("Altro3Fine", tbc.Altro3Fine)
                        pdfFormFields.SetField("Altro4", tbc.Altro4)
                        pdfFormFields.SetField("Altro4Inizio", tbc.Altro4Inizio)
                        pdfFormFields.SetField("Altro4Fine", tbc.Altro4Fine)


                    End If

                    If Not IsNothing(tbcFattori) Then


                        pdfFormFields.SetField("esitiradiografici", tbcFattori.esitiradiografici)
                        pdfFormFields.SetField("graveimmudeficenza", tbcFattori.graveimmudeficenza)
                        pdfFormFields.SetField("terapiaImmunosoppresiva", tbcFattori.terapiaImmunosoppresiva)
                        pdfFormFields.SetField("deperimentoOrganico", tbcFattori.deperimentoOrganico)
                        pdfFormFields.SetField("recenteViaggioTbc", tbcFattori.recenteViaggioTbc)
                        pdfFormFields.SetField("diabeteScarsamenteControllato", tbcFattori.diabeteScarsamenteControllato)
                        pdfFormFields.SetField("silicosi", tbcFattori.silicosi)
                        pdfFormFields.SetField("insufficenzaRenale", tbcFattori.insufficenzaRenale)
                        pdfFormFields.SetField("gastrectomia", tbcFattori.gastrectomia)
                        pdfFormFields.SetField("ContattoMalato", tbcFattori.ContattoMalato)
                        pdfFormFields.SetField("tossicodipendenza", tbcFattori.tossicodipendenza)
                        pdfFormFields.SetField("Immigrazione", tbcFattori.Immigrazione)
                        pdfFormFields.SetField("carcere", tbcFattori.carcere)
                        pdfFormFields.SetField("alcolismo", tbcFattori.alcolismo)
                        pdfFormFields.SetField("senzaFissaDimora", tbcFattori.senzaFissaDimora)
                        pdfFormFields.SetField("personaleSanitario", tbcFattori.personaleSanitario)
                        pdfFormFields.SetField("Altro", tbcFattori.Altro)


                    End If


                    pdfStampera.FormFlattening = True
                    pdfReader.Close()
                    pdfStampera.Close()


                    m.Position = 0
                    Dim reader3 As New PdfReader(m)

                    numberofPAges = reader3.NumberOfPages
                    currentPAgeNumber = 0

                    Do While currentPAgeNumber < numberofPAges
                        currentPAgeNumber += 1
                        doc.SetPageSize(PageSize.A4)
                        doc.NewPage()
                        page = writere.GetImportedPage(reader3, currentPAgeNumber)
                        rotation = reader3.GetPageRotation(currentPAgeNumber)
                        If (rotation = 90) Or (rotation = 270) Then

                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader3.GetPageSizeWithRotation(currentPAgeNumber).Height)
                        Else
                            cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                        End If
                    Loop

                End Using
                '
            End If






            Dim mal As Notifica_view_MalariaResult = _mobjNotifica.GetMalariaView(_idNotifica)



            If Not IsNothing(mal) Then

                Using m As New MemoryStream


                    Dim pdfReader As PdfReader = New PdfReader(pdfTemplateMal)
                    Dim pdfStampera As PdfStamper = New PdfStamper(pdfReader, m)
                    Dim pdfFormFields As AcroFields = pdfStampera.AcroFields



                    pdfStampera.Writer.CloseStream = False






                    pdfFormFields.SetField("tipo", mal.tipo)
                    pdfFormFields.SetField("dataClinica", Helper.IsNullDate(mal.dataClinica))
                    pdfFormFields.SetField("dataEmoscopia", Helper.IsNullDate(mal.dataEmoscopia))
                    pdfFormFields.SetField("speciePlasmodio", mal.speciePlasmodio)
                    pdfFormFields.SetField("formeMisteSpecificare", mal.formeMisteSpecificare)
                    pdfFormFields.SetField("terapia", mal.terapia)
                    pdfFormFields.SetField("altraTerapia", mal.altraTerapia)
                    pdfFormFields.SetField("faramcoResistenza", mal.faramcoResistenza)
                    pdfFormFields.SetField("prevenzioneRicevuta", mal.prevenzioneRicevuta)
                    pdfFormFields.SetField("AltroEnte", mal.AltroEnte)
                    pdfFormFields.SetField("chemioprofilassi", mal.chemioprofilassi)
                    pdfFormFields.SetField("farmaciChemioprofilassi", mal.farmaciChemioprofilassi)
                    pdfFormFields.SetField("assunzioniInterrotte", mal.assunzioniInterrotte)
                    pdfFormFields.SetField("chemioProfilassiCompletata", mal.chemioProfilassiCompletata)
                    pdfFormFields.SetField("motivoInterruzione", mal.motivoInterruzione)
                    pdfFormFields.SetField("Effetto1", mal.Effetto1)
                    pdfFormFields.SetField("altroEffetto1Specificare", mal.altroEffetto1Specificare)
                    pdfFormFields.SetField("Effetto2", mal.Effetto2)
                    pdfFormFields.SetField("altroEffetto2Specificare", mal.altroEffetto2Specificare)
                    pdfFormFields.SetField("protezionePunture", mal.protezionePunture)
                    pdfFormFields.SetField("zanzareZoneRischio", mal.zanzareZoneRischio)
                    pdfFormFields.SetField("Repellenti", mal.Repellenti)
                    pdfFormFields.SetField("specificaRepellente", mal.specificaRepellente)
                    pdfFormFields.SetField("Emoscopiapervenuta", mal.Emoscopiapervenuta)
                    pdfFormFields.SetField("Emoscopiacontrollo", mal.Emoscopiacontrollo)



                    pdfStampera.FormFlattening = True
                    pdfReader.Close()
                    pdfStampera.Close()


                    m.Position = 0
                    Dim reader4 As New PdfReader(m)

                    numberofPAges = reader4.NumberOfPages
                    currentPAgeNumber = 0

                    Do While currentPAgeNumber < numberofPAges
                        currentPAgeNumber += 1
                        doc.SetPageSize(PageSize.A4)
                        doc.NewPage()
                        page = writere.GetImportedPage(reader4, currentPAgeNumber)
                        rotation = reader4.GetPageRotation(currentPAgeNumber)
                        If (rotation = 90) Or (rotation = 270) Then

                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader4.GetPageSizeWithRotation(currentPAgeNumber).Height)
                        Else
                            cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                        End If
                    Loop

                End Using
            '
            End If

            doc.Close()
            ''''Fine merge
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-disposition", String.Format("attachment; filename={0};", "Notifica.pdf"))

            Response.OutputStream.Write(pdfMerge.GetBuffer, 0, pdfMerge.GetBuffer.Length)
            Response.OutputStream.Flush()
            Response.OutputStream.Close()
            MemStream.Close()

        End Using
    End Sub

    Protected Sub stampa_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles stampa.Click
        StampaPdf()
    End Sub
End Class
