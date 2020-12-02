Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_EditClinici
    Inherits System.Web.UI.Page
    Private _idNotifica As Integer = 0
    Private _MobjMalattia As New BllMalattie
    Private _MobjGeografiche As New BllGeografiche
    Private _MobjNotifica As New BllNotifica
    Private _MobjAccesorie As New BllAccessorie

    Private _idMalattia As Integer = 0
    Private _idClinica As Integer = 0
    Private _cUser As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idClinica ", _idClinica)
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idClinica = CInt(ViewState("_idClinica "))
        _idNotifica = CInt(ViewState("_idNotifica"))
        _idMalattia = CInt(ViewState("_idMalattia"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idNotifica = Session("idNotifica")
            If _idNotifica <> 0 Then
                caricaEntity(_idNotifica)
            End If
            CaricaValoriStartUp()
            AddJavascript()
        Else
            _cUser = User.Identity.Name
        End If
    End Sub
    Private Sub AddJavascript()
        Me.NazioneSintomi.Attributes("onchange") = "AbilitaSintomi();"
        Me.ProvinciaSintomi.Attributes("onchange") = "getComuni('ProvinciaSintomi','ComuneSintomi');"
        Me.ProvinciaContagio.Attributes("onchange") = "getComuni('ProvinciaContagio','ComuneContagio');"
        Me.Viaggio.Attributes("onchange") = "AbilitaEsposizione();"
        Me.NazioneContagio.Attributes("onchange") = "AbilitaContagio();"
        Me.StatoVaccinale.Attributes("onchange") = "AbilitaVaccino();"
        Me.Ricovero.Attributes("onchange") = "AbilitaRicovero();"
        Me.Collettivita.Attributes("onchange") = "AbilitaCollettivita();"
        Me.AltreColettivita.Attributes("onblur") = "AbilitaCollettivita();"
        Me.DataDimissione.Attributes("onblur") = "check_date(this);"
        Me.DataDoseVaccino.Attributes("onblur") = "check_date(this);"
        Me.DataRicovero.Attributes("onblur") = "check_date(this);"
        Me.DataPrimiSintomi.Attributes("onblur") = "check_date(this);"
        '   Me.imgItaliaSintomi.Attributes("onclick") = "ImpostaItalia('NazioneSintomi','sintomi');"
        '   Me.imgItaliaContagio.Attributes("onclick") = "ImpostaItalia('NazioneContagio','contagio');"
        Me.dataesame1.Attributes("onblur") = "check_date(this)"
        Me.dataesame2.Attributes("onblur") = "check_date(this)"
        Me.Nazione1Periodo.Attributes("onblur") = "checkPeriodo()"
        Me.Nazione2Periodo.Attributes("onblur") = "checkPeriodo()"
        Me.Nazione3Periodo.Attributes("onblur") = "checkPeriodo()"

        Me.Nazione1.Attributes("onchange") = "checkPeriodo()"
        Me.Nazione2.Attributes("onchange") = "checkPeriodo()"
        Me.Nazione3.Attributes("onchange") = "checkPeriodo()"

        Me.contagio.Attributes("onchange") = "abilitaContatto()"
        Me.focolaio.Attributes("onchange") = "abilitaFocolaio()"

    End Sub

    Private Sub CheckVaccini()
        If StatoVaccinale.SelectedValue = "vaccinato" Then
            DoseVaccino.Enabled = True
            DataDoseVaccino.Enabled = True
        Else
            DoseVaccino.Enabled = False
            DataDoseVaccino.Enabled = False
            DoseVaccino.Text = ""
            DataDoseVaccino.Text = ""
        End If
        If DoseVaccino.Text = "" Then

        End If
    End Sub
    Private Sub CaricaValoriStartUp()
        Dim criteri As Malattie_Criteri = _MobjMalattia.GetCriteri(_idMalattia)
        With criteri
            Clinico.Enabled = .Clinico
            Epidemiologico.Enabled = .Epidemilogico
            Laboratorio.Enabled = .Laboratorio
            divClinici.InnerHtml = Server.HtmlDecode(.Clinico_help)
            divEpidemiologico.InnerHtml = Server.HtmlDecode(.Epidemilogico_Help)
            divLaboratorio.InnerHtml = Server.HtmlDecode(.Laboratorio_help)
        End With
        If (_idMalattia = 1001 Or _idMalattia = 1002 Or _idMalattia = 1003) Then
            pnlMib.Visible = True
        Else
            pnlMib.Visible = False
        End If
        CheckVaccini()
        CheckLuogoDiCura()
        BindIntestazione()
    End Sub
    Private Sub caricaEntity(ByVal idNotifica As Integer)
        Try

            Dim tblClinica As Clinica = _MobjNotifica.GetClinicaByIdNotifica(_idNotifica)
            Dim DsNazioni As List(Of JsonDto) = _MobjGeografiche.GetAllNazioniJson()
            Dim dsProvince As List(Of JsonDto) = _MobjGeografiche.GetAllProvinceJson
            Dim dsColletività As List(Of JsonDto) = _MobjAccesorie.GettAllComunitaJson

            With tblClinica


                '                .AltriCasiCorrelati =
                AltreColettivita.Text = .AltraColletivita
                ContattiStretti.SelectedValue = .ContattiStretti
                bind(Collettivita, dsColletività)
                Collettivita.SelectedValue = .collettivita
                Clinico.Checked = Helper.ConvertStringToBoolean(.CriterioClinico)
                Epidemiologico.Checked = Helper.ConvertStringToBoolean(.CriterioEpidemiologico)
                Laboratorio.Checked = Helper.ConvertStringToBoolean(.CriterioLaboratorio)

                DataDimissione.Text = Helper.IsNullDate(.DataDimissione)
                DataDoseVaccino.Text = Helper.IsNullDate(.DataDoseUltimoVaccino)
                DoseVaccino.Text = .DoseVaccino
                dataweb.Text = Helper.IsNullDate(.DataWeb)
                DataPrimiSintomi.Text = Helper.IsNullDate(.DataPrimiSintomi)
                DataRicovero.Text = Helper.IsNullDate(.DataRicovero)
                _idMalattia = .IdMalattia

                If Not .IdNazione1 Is Nothing Then
                    bind(Nazione1, DsNazioni)
                    Nazione1.SelectedValue = .IdNazione1
                End If
                If Not .IdNazione2 Is Nothing Then
                    bind(Nazione2, DsNazioni)
                    Nazione2.SelectedValue = .IdNazione2
                End If
                If Not .IdNazione3 Is Nothing Then
                    bind(Nazione3, DsNazioni)
                    Nazione3.SelectedValue = .IdNazione3
                End If

                bind(NazioneSintomi, DsNazioni)
                If Not .IdNazionePrimiSintomi Is Nothing Then
                    NazioneSintomi.SelectedValue = .IdNazionePrimiSintomi
                Else
                    NazioneSintomi.SelectedValue = ""
                End If

                _idNotifica = .IdNotifica
                bind(NazioneContagio, DsNazioni)
                NazioneContagio.SelectedValue = .IdNazionePresuntoContagio
                '.Localita = 
                LuogoRicovero.Text = .LuogoRicovero
                '.ModalitaTrasmissione = 
                MotivoRicovero.Text = .MotivoDelRicovero
                '.NomeStruttura = 
                '.Note = 
                Reparto.Text = .Reparto
                Ricovero.SelectedValue = .RicoveroOspedaliero
                StatoVaccinale.SelectedValue = .StatoVaccinale
                StrutturaRicovero.Text = .StrutturaRicovero
                '.VeicoloTrasmissione = 
                Viaggio.SelectedValue = .ViaggioFuoriResidenza
                CasiCorrelati.SelectedValue = .CasiCorrelati
                'If .IdNazionePresuntoContagio = "000" Then

                'End If

                If Not .IdComuneContagio Is Nothing And .IdComuneContagio <> "" Then
                    ComuneContagio.DataSource = _MobjGeografiche.GetAllComuniByIdProvinciaJson(.idProvinciaPresuntoContagio)
                    ComuneContagio.DataTextField = "descrizione"
                    ComuneContagio.DataValueField = "codice"
                    ComuneContagio.DataBind()
                    ComuneContagio.SelectedValue = .IdComuneContagio
                End If

                If Not .IdComunePrimiSintomi Is Nothing And .IdComunePrimiSintomi <> "" Then
                    ComuneSintomi.DataSource = _MobjGeografiche.GetAllComuniByIdProvinciaJson(.IdProvinciaPrimiSintomi)
                    ComuneSintomi.DataTextField = "descrizione"
                    ComuneSintomi.DataValueField = "codice"
                    ComuneSintomi.DataBind()
                    ComuneSintomi.SelectedValue = .IdComunePrimiSintomi
                End If


                If Not .idProvinciaPresuntoContagio Is Nothing And .idProvinciaPresuntoContagio <> "" Then
                    bind(ProvinciaContagio, dsProvince)
                    ProvinciaContagio.SelectedValue = .idProvinciaPresuntoContagio
                End If
                If Not .IdProvinciaPrimiSintomi Is Nothing And .IdProvinciaPrimiSintomi <> "" Then
                    bind(ProvinciaSintomi, dsProvince)
                    ProvinciaSintomi.SelectedValue = .IdProvinciaPrimiSintomi
                End If



                'Nuovi campi

                ricerca1.Text = .ricerca1
                ricerca2.Text = .ricerca2
                Luogo1.Text = .luogo1
                Luogo2.Text = .luogo2
                dataesame1.Text = Helper.IsNullDate(.dataesame1)
                dataesame2.Text = Helper.IsNullDate(.dataesame2)
                risultato1.Text = .risultato1
                risultato2.Text = .risultato2

                Nazione1Periodo.Text = .Nazione1Periodo
                Nazione2Periodo.Text = .Nazione2Periodo
                Nazione3Periodo.Text = .Nazione3Periodo
                StrutturaRicovero.Text = .StrutturaRicovero
                note.Text = .Note
                agente.Text = .Agente
                deceduto.SelectedValue = .deceduto
                NomeCommercialeVaccino.Text = .NomeCommercialeVaccino
                'Esito.SelectedValue = .Esito
                'Esito14Giorni.SelectedValue = .Esito14gg
                NoteVaccino.Text = .noteVaccino


                contagio.SelectedValue = .contagio
                contagioDove.Text = .contagioDove
                focolaio.SelectedValue = .focolaio
                focolaioDescrizione.Text = .focolaioDescrizione
                contatto.SelectedValue = .contatto

            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub bind(ByRef cmb As DropDownList, ByVal ds As List(Of JsonDto))
        cmb.DataTextField = "descrizione"
        cmb.DataValueField = "codice"
        cmb.DataSource = ds
        cmb.DataBind()
        cmb.Items.Insert(0, New ListItem("Selezionare...", ""))

    End Sub
    Private Function ImpostaEntity() As Clinica
        Dim localdataEntity As New Clinica
        With localdataEntity
            '.AltriCasiCorrelati =
            '.AltriContatti =
            .AltraColletivita = AltreColettivita.Text
            .collettivita = Collettivita.SelectedValue
            .ContattiStretti = ContattiStretti.SelectedValue
            .CriterioClinico = Helper.ConvertBooleanToString(Clinico.Checked)
            .CriterioEpidemiologico = Helper.ConvertBooleanToString(Epidemiologico.Checked)
            .CriterioLaboratorio = Helper.ConvertBooleanToString(Laboratorio.Checked)
            .DataDimissione = Helper.ConvertEmptyDateToNothing(DataDimissione.Text)
            .DataDoseUltimoVaccino = Helper.ConvertEmptyDateToNothing(DataDoseVaccino.Text)
            .DataModifica = Now
            .DataPrimiSintomi = Helper.ConvertEmptyDateToNothing(DataPrimiSintomi.Text)
            .DataRicovero = Helper.ConvertEmptyDateToNothing(DataRicovero.Text)
            .DoseVaccino = DoseVaccino.Text
            .Id = _idClinica
            .IdComuneContagio = Request.Form("ctl00$Contenuto$ComuneContagio")
            .IdComunePrimiSintomi = Request.Form("ctl00$Contenuto$ComuneSintomi")
            .IdMalattia = _idMalattia
            .idProvinciaPresuntoContagio = Request.Form("ctl00$Contenuto$ProvinciaContagio")
            .IdProvinciaPrimiSintomi = Request.Form("ctl00$Contenuto$ProvinciaSintomi")
            .IdNazione1 = Request.Form("ctl00$Contenuto$Nazione1")
            .IdNazione2 = Request.Form("ctl00$Contenuto$Nazione2")
            .IdNazione3 = Request.Form("ctl00$Contenuto$Nazione3")
            .IdNazionePrimiSintomi = Request.Form("ctl00$Contenuto$NazioneSintomi")
            .IdNotifica = _idNotifica
            .IdNazionePresuntoContagio = NazioneContagio.SelectedValue
            '.Localita = 
            .LuogoRicovero = LuogoRicovero.Text
            '.ModalitaTrasmissione = 
            .MotivoDelRicovero = MotivoRicovero.Text
            '.NomeStruttura = 
            '.Note = 
            .Reparto = Reparto.Text
            .RicoveroOspedaliero = Ricovero.SelectedValue
            .StatoVaccinale = StatoVaccinale.SelectedValue
            .StrutturaRicovero = StrutturaRicovero.Text
            '.VeicoloTrasmissione = 
            .ViaggioFuoriResidenza = Viaggio.SelectedValue
            .DataWeb = Helper.ConvertEmptyDateToNothing(dataweb.Text)
            .CasiCorrelati = CasiCorrelati.SelectedValue

            .ricerca1 = ricerca1.Text
            .ricerca2 = ricerca2.Text
            .luogo1 = Luogo1.Text
            .luogo2 = Luogo2.Text
            .dataesame1 = Helper.ConvertEmptyDateToNothing(dataesame1.Text)
            .dataesame2 = Helper.ConvertEmptyDateToNothing(dataesame2.Text)
            .risultato1 = risultato1.Text
            .risultato2 = risultato2.Text
            .Note = note.Text


            .Nazione1Periodo = Nazione1Periodo.Text
            .Nazione2Periodo = Nazione2Periodo.Text
            .Nazione3Periodo = Nazione3Periodo.Text
            .Agente = agente.Text
            .LastUSer = _cUser
            .deceduto = deceduto.SelectedValue
            '.Esito = Esito.SelectedValue
            '.Esito14gg = Esito14Giorni.SelectedValue
            .NomeCommercialeVaccino = NomeCommercialeVaccino.Text
            .noteVaccino = NoteVaccino.Text


            .contagio = contagio.SelectedValue
            .contagioDove = contagioDove.Text
            .focolaio = focolaio.SelectedValue
            .focolaioDescrizione = focolaioDescrizione.Text
            .contatto = contatto.SelectedValue
        End With
        Return localdataEntity
    End Function
    Private Sub CheckLuogoDiCura()

    End Sub

    Private Sub BindIntestazione()
        Dim notificaInfo As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)
        With notificaInfo
            UcStatoSegnalazione1.malattia = .malattia
            UcStatoSegnalazione1.nome = .nome
            UcStatoSegnalazione1.cognome = .cognome
            DataNascita.Value = Format(DateTime.Parse(.datanascita), "dd/MM/yyyy")
            datasegnalazione.Value = Format(DateTime.Parse(.DataSegnalazione), "dd/MM/yyyy")
            _idMalattia = .idmalattia
        End With
    End Sub

    Private Sub Salva()
        Try
            _MobjNotifica.DataNascita = DataNascita.Value
            _MobjNotifica.DataPrimiSintomi = DataPrimiSintomi.Text
            _MobjNotifica.username = _cUser
            _MobjNotifica.record = UcStatoSegnalazione1.nome + " " + UcStatoSegnalazione1.cognome
            _MobjNotifica.UpdateClinica(ImpostaEntity)
            Response.Redirect("Riepilogo.aspx?tab=Clinico", True)
        Catch ex As Exception
            lblErrore.Visible = True
            lblErrore.Text = ex.ToString
            btn.Enabled = False

        End Try

    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.Form.Attributes("onsubmit") = "javascript:return CompareDate();"
    End Sub
    Protected Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn.Click
        Salva()

    End Sub

    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("Riepilogo.aspx?tab=Clinico", True)
    End Sub
End Class

