Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_EditMib
    Inherits System.Web.UI.Page
    Private _mobjNotifica As New BllNotifica
    Private _mobjMib As New BllMib
    Private _MobjEsami As New BllEsami
    Private _mobMalattia As New BllMalattie
    Private _idNotifica As Integer = 0
    Private _idMalattia As Integer = 0
    Private _id As Integer = 0
    Private _cUSer As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_id", _id)
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _id = CInt(ViewState("_id"))
        _idNotifica = CInt(ViewState("_idNotifica"))
        _idMalattia = CInt(ViewState("_idMalattia"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idNotifica = Session("idNotifica")
            CaricaValoriStartUp()
            checkTipoMalattia()
            CaricaEntity()
            ImpostaJavascript()
            UcStatoSegnalazione1.IdNotifica = _idNotifica
        Else
            _cUSer = User.Identity.Name
        End If
        _mobjMib.username = _cUSer
        _mobjMib.record = UcStatoSegnalazione1.nome + " " + UcStatoSegnalazione1.cognome
    End Sub
  

    Private Sub ImpostaCampi()


        labBatterio.Items.Clear()

        pnlAltroAgente.Enabled = False

        If _idMalattia = 1003 Then
            ' agenteEziologico.SelectedValue = "4"
            LabSierotipoHI.Enabled = True
            'labBatterio.Items.Add(New ListItem(
            labBatterio.Items.Insert(0, New ListItem("Selezionare...", ""))
            labBatterio.Items.Insert(1, New ListItem("Haemophilus influenzae", "2"))
            CheckPneumo(False)
        Else
            LabSierotipoHI.Enabled = False
            LabSierotipoHI.SelectedValue = ""
            CheckPneumo(False)

        End If
        If _idMalattia = 1001 Then
            'agenteEziologico.SelectedValue = "000108"
            LabSierogruppoMen.Enabled = True
            labBatterio.Items.Insert(0, New ListItem("Selezionare...", ""))
            labBatterio.Items.Insert(1, New ListItem("Meningococco", "1"))
            CheckPneumo(False)
        Else
            LabSierogruppoMen.Enabled = False
            LabSierogruppoMen.SelectedValue = ""
            CheckPneumo(False)
        End If

        If _idMalattia = 1002 Then 'Pneumococco
            'agenteEziologico.SelectedValue = "000109"
            LabSierotipoPNU.Enabled = True
            labBatterio.Items.Insert(0, New ListItem("Selezionare...", ""))
            labBatterio.Items.Insert(1, New ListItem("Pneumococco", "3"))
            CheckPneumo(True)
        Else
            LabSierotipoPNU.Enabled = False
            LabSierotipoPNU.SelectedValue = ""
            CheckPneumo(False)
        End If

        If _idMalattia = 1098 Then 'non identificato
            pnlAltroAgente.Enabled = True
            CheckPneumo(False)
        End If
        agenteEziologico.Enabled = True

    End Sub
    Private Sub CheckPneumo(ByVal stato As Boolean)
        If stato = True Then
            Pg_Val.Enabled = True
            Pg_Mic.Enabled = True
            Pg_Cat.Enabled = True
            Pg_Val_Est.Enabled = True
            Pg_Mic_Est.Enabled = True
            Pg_Cat_ESt.Enabled = True
            Pg_disco.Enabled = True
            Pg_Disco_Cat.Enabled = True
            Em_val.Enabled = True
            Em_Mic.Enabled = True
            Em_Cat.Enabled = True
            Em_val_est.Enabled = True
            Em_Mic_Est.Enabled = True
            Em_Cat_Est.Enabled = True
            Em_disco.Enabled = True
            Em_Disco_Cat.Enabled = True
            Cip_Val.Enabled = True
            Cip_Mic.Enabled = True
            Cip_Cat.Enabled = True
            Cip_Val_Est.Enabled = True
            Cip_Mic_Est.Enabled = True
            Cip_Cat_Est.Enabled = True
            Cip_Disco.Enabled = True
            Cip_Disco_Cat.Enabled = True
            Cli_Val.Enabled = True
            Cli_Mic.Enabled = True
            Cli_Cat.Enabled = True
            Cli_Val_Est.Enabled = True
            Cli_Mic_Est.Enabled = True
            Cli_Cat_Est.Enabled = True
            Cli_Disco.Enabled = True
            Cli_Disco_Cat.Enabled = True
        Else
            Pg_Val.Enabled = False
            Pg_Mic.Enabled = False
            Pg_Cat.Enabled = False
            Pg_Val_Est.Enabled = False
            Pg_Mic_Est.Enabled = False
            Pg_Cat_ESt.Enabled = False
            Pg_disco.Enabled = False
            Pg_Disco_Cat.Enabled = False
            Em_val.Enabled = False
            Em_Mic.Enabled = False
            Em_Cat.Enabled = False
            Em_val_est.Enabled = False
            Em_Mic_Est.Enabled = False
            Em_Cat_Est.Enabled = False
            Em_disco.Enabled = False
            Em_Disco_Cat.Enabled = False
            Cip_Val.Enabled = False
            Cip_Mic.Enabled = False
            Cip_Cat.Enabled = False
            Cip_Val_Est.Enabled = False
            Cip_Mic_Est.Enabled = False
            Cip_Cat_Est.Enabled = False
            Cip_Disco.Enabled = False
            Cip_Disco_Cat.Enabled = False
            Cli_Val.Enabled = False
            Cli_Mic.Enabled = False
            Cli_Cat.Enabled = False
            Cli_Val_Est.Enabled = False
            Cli_Mic_Est.Enabled = False
            Cli_Cat_Est.Enabled = False
            Cli_Disco.Enabled = False
            Cli_Disco_Cat.Enabled = False
            Pg_Val.SelectedValue = ""
            Pg_Mic.SelectedValue = ""
            Pg_Cat.SelectedValue = ""
            Pg_Val_Est.SelectedValue = ""
            Pg_Mic_Est.SelectedValue = ""
            Pg_Cat_ESt.SelectedValue = ""
            Pg_disco.Text = ""
            Pg_Disco_Cat.SelectedValue = ""
            Em_val.SelectedValue = ""
            Em_Mic.SelectedValue = ""
            Em_Cat.SelectedValue = ""
            Em_val_est.SelectedValue = ""
            Em_Mic_Est.SelectedValue = ""
            Em_Cat_Est.SelectedValue = ""
            Em_disco.Text = ""
            Em_Disco_Cat.SelectedValue = ""
            Cip_Val.SelectedValue = ""
            Cip_Mic.SelectedValue = ""
            Cip_Cat.SelectedValue = ""
            Cip_Val_Est.SelectedValue = ""
            Cip_Mic_Est.SelectedValue = ""
            Cip_Cat_Est.SelectedValue = ""
            Cip_Disco.Text = ""
            Cip_Disco_Cat.SelectedValue = ""
            Cli_Val.SelectedValue = ""
            Cli_Mic.SelectedValue = ""
            Cli_Cat.SelectedValue = ""
            Cli_Val_Est.SelectedValue = ""
            Cli_Mic_Est.SelectedValue = ""
            Cli_Cat_Est.SelectedValue = ""
            Cli_Disco.Text = ""
            Cli_Disco_Cat.SelectedValue = ""
        End If
    End Sub
    Private Sub caricaAgenti()
        agenteEziologico.DataTextField = "descrizione"
        agenteEziologico.DataValueField = "codice"
        agenteEziologico.DataSource = _mobMalattia.GetAgentiJsonByIdMalattia(_idMalattia)
        agenteEziologico.DataBind()
    End Sub
    Private Sub ImpostaJavascript()

        Me.altraDiagnosi.Attributes("onclick") = "CheckDiagnosi();"
        Me.altroDiagnosiDescr.Attributes("onblur") = "CheckDiagnosi();"
        Me.Tipizzazione.Attributes("onchange") = "CheckTipizzazione();"
        Me.dataPrelievo.Attributes("onblur") = "check_date(this);"
        Me.labBatterio.Attributes("onchange") = "checkTipizzazione();"
        Me.agenteEziologico.Attributes("onchange") = "CheckAltroAgente();"
        Me.antibioticoResistenza.Attributes("onchange") = "checkPneumoAntibiotico();"
        Me.Esito.Attributes("onchange") = "checkEsito();"
        Me.fattori.Attributes("onchange") = "checkCondizioni();"
        Me.sequele.Attributes("onchange") = "checkSequele();"
    End Sub

  
    Private Sub checkTipoMalattia()
        Dim malattia As Malattia = _mobMalattia.GetMalattia(_idMalattia)
        If LCase(malattia.ModuloMibTipizzazione) = "si" Then
            Pnltipizzazione.Visible = True
        Else
            Pnltipizzazione.Visible = False
        End If

    End Sub

    Private Sub BindLocalizzazioni(ByRef cmb As DropDownList, ByVal ds As List(Of JsonDto))
        cmb.DataSource = ds
        cmb.DataTextField = "descrizione"
        cmb.DataValueField = "codice"
        cmb.DataBind()
        cmb.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaValoriStartUp()
        BindIntestazione()
        caricaAgenti()
        ImpostaCampi()
    End Sub

    Private Sub BindIntestazione()
        Dim notificaInfo As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)
        With notificaInfo
            UcStatoSegnalazione1.malattia = .malattia
            UcStatoSegnalazione1.nome = .nome
            UcStatoSegnalazione1.cognome = .cognome
            _idMalattia = .idmalattia
        End With
    End Sub

    Private Sub CaricaEntity()        
        Dim localEntity As Notifica_MIB = _mobjMib.GetMib(_idNotifica)
        If Not IsNothing(localEntity) Then

            With localEntity
                _idNotifica = .idNotifica
                _id = .id


                AltroAgente.Text = .AltroAgente
                ContattoLab.Text = .ContattoLab
                ContattoOspedale.Text = .ContattoOspedale
                contattoTelefono.Text = .ContattoTelefono
                agenteEziologico.SelectedValue = .IdAgenteEziologico
                LabAltroBatterio.Text = .LabAltroBatterio
                ' labBatterio.SelectedValue = .LabBatterio
                noteTipizzazione.Text = .LabNote
                LabSierogruppoMen.SelectedValue = .LabSierogruppoMen
                LabSierotipoHI.SelectedValue = .LabSierotipoHI
                LabSierotipoPNU.SelectedValue = .LabSierotipoPNU
                LabTipizzazione.Text = .LabTipizzazione
                liquor.SelectedValue = .Liquor
                Materiale1.SelectedValue = .Materiale1
                Materiale2.SelectedValue = .Materiale2
                Metodo1.SelectedValue = .Metodo1
                Metodo2.SelectedValue = .Metodo2
                noteDiagnosi.Text = .NoteDiagnosi
                altraDiagnosi.Checked = Helper.ConvertStringToBoolean(.QC_Altro)
                altroDiagnosiDescr.Text = .Qc_AltroSpecificare
                artrite.Checked = Helper.ConvertStringToBoolean(.QC_Artrite)
                cellulite.Checked = Helper.ConvertStringToBoolean(.QC_Cellulite)
                epiglottite.Checked = Helper.ConvertStringToBoolean(.QC_Epiglottite)
                polmonite.Checked = Helper.ConvertStringToBoolean(.Qc_Polmonite)
                meningite.Checked = Helper.ConvertStringToBoolean(.Qc_Meningite)
                pericardite.Checked = Helper.ConvertStringToBoolean(.QC_Pericardite)
                peritonite.Checked = Helper.ConvertStringToBoolean(.QC_Peritonite)
                sepsi.Checked = Helper.ConvertStringToBoolean(.Qc_Sepsi)
                Tipizzazione.SelectedValue = .Tipizzazione
                dataWeb.Text = Helper.IsNullDate(.DataWeb)
                dataPrelievo.Text = Helper.IsNullDate(.dataPrelievo)
                ' ImpostaCampi()
                labBatterio.SelectedValue = .LabBatterio
                'antibiotico resistenza
                Pg_Val.SelectedValue = .Pg_Val
                Pg_Mic.SelectedValue = .Pg_Mic
                Pg_Cat.SelectedValue = .Pg_Cat
                Pg_Val_Est.SelectedValue = .Pg_Val_Est
                Pg_Mic_Est.SelectedValue = .Pg_Mic_Est
                Pg_Cat_ESt.SelectedValue = .Pg_Cat_ESt
                Pg_disco.Text = .Pg_disco
                Pg_Disco_Cat.SelectedValue = .Pg_Disco_Cat
                Em_val.SelectedValue = .Em_val
                Em_Mic.SelectedValue = .Em_Mic
                Em_Cat.SelectedValue = .Em_Cat
                Em_val_est.SelectedValue = .Em_val_est
                Em_Mic_Est.SelectedValue = .Em_Mic_Est
                Em_Cat_Est.SelectedValue = .Em_Cat_Est
                Em_disco.Text = .Em_disco
                Em_Disco_Cat.SelectedValue = .Em_Disco_Cat
                Cip_Val.SelectedValue = .Cip_Val
                Cip_Mic.SelectedValue = .Cip_Mic
                Cip_Cat.SelectedValue = .Cip_Cat
                Cip_Val_Est.SelectedValue = .Cip_Val_Est
                Cip_Mic_Est.SelectedValue = .Cip_Mic_Est
                Cip_Cat_Est.SelectedValue = .Cip_Cat_Est
                Cip_Disco.Text = .Cip_Disco
                Cip_Disco_Cat.SelectedValue = .Cip_Disco_Cat
                Cli_Val.SelectedValue = .Cli_Val
                Cli_Mic.SelectedValue = .Cli_Mic
                Cli_Cat.SelectedValue = .Cli_Cat
                Cli_Val_Est.SelectedValue = .Cli_Val_Est
                Cli_Mic_Est.SelectedValue = .Cli_Mic_Est
                Cli_Cat_Est.SelectedValue = .Cli_Cat_Est
                Cli_Disco.Text = .Cli_Disco
                Cli_Disco_Cat.SelectedValue = .Cli_Disco_Cat
                antibioticoResistenza.SelectedValue = .antibiogramma
                Esito14Giorni.SelectedValue = .Esito14gg
                Esito.SelectedValue = .Esito



                sequele.SelectedValue = .Sequele
                SequeleUdito.Checked = Helper.ConvertStringToBoolean(.SequeleUdito)
                SequelVista.Checked = Helper.ConvertStringToBoolean(.SequelVista)
                SequeleNeuro.Checked = Helper.ConvertStringToBoolean(.SequeleNeuro)
                SequeleAmputazione.Checked = Helper.ConvertStringToBoolean(.SequeleAmputazione)
                SequeleNecrosi.Checked = Helper.ConvertStringToBoolean(.SequeleNecrosi)
                SequeleAltro.Checked = Helper.ConvertStringToBoolean(.SequeleAltro)
                SequeleAltroSpecificare.Text = .SequeleAltroSpecificare




                fattori.SelectedValue = .condizioni
                Asplenia.Checked = Helper.ConvertStringToBoolean(.Con_Asplenia)
                Immunodeficienza.Checked = Helper.ConvertStringToBoolean(.Con_Immunodeficienza)
                Immunodeficienzaacquisita.Checked = Helper.ConvertStringToBoolean(.Con_Immunodeficienzaacquisita)
                Leucemie.Checked = Helper.ConvertStringToBoolean(.Con_Leucemie)
                Neoplasie.Checked = Helper.ConvertStringToBoolean(.Con_neoplasie)
                TerapieImmuno.Checked = Helper.ConvertStringToBoolean(.Con_TerapieImmuno)
                Altrocondizione.Checked = Helper.ConvertStringToBoolean(.Con_Altrocondizione)
                Trapianto.Checked = Helper.ConvertStringToBoolean(.Con_Trapianto)
                Cocleare.Checked = Helper.ConvertStringToBoolean(.Con_cocleare)
                Fistole.Checked = Helper.ConvertStringToBoolean(.Con_Fistole)
                Insufficenzarenale.Checked = Helper.ConvertStringToBoolean(.Con_Insufficenzarenale)
                Diabete.Checked = Helper.ConvertStringToBoolean(.Con_Diabete)
                Epatopatia.Checked = Helper.ConvertStringToBoolean(.Con_Epatopatia)
                Cardiopatie.Checked = Helper.ConvertStringToBoolean(.Con_Cardiopatie)
                Asma.Checked = Helper.ConvertStringToBoolean(.Con_Asma)
                Tossicodipendenza.Checked = Helper.ConvertStringToBoolean(.Con_Tossicodipendenza)
                Alcolismo.Checked = Helper.ConvertStringToBoolean(.Con_Alcolismo)
                Tabagismo.Checked = Helper.ConvertStringToBoolean(.Con_Tabagismo)
                AltraCondizionedescrizione.Text = .Con_altrospecificare


                Con_altrePolmonari.Checked = Helper.ConvertStringToBoolean(.Con_altrePolmonari)
                Con_Deficit.Checked = Helper.ConvertStringToBoolean(.Con_Deficit)
                Con_Emoglobinopatie.Checked = Helper.ConvertStringToBoolean(.Con_Emoglobinopatie)


            End With
        End If

    End Sub
    Private Function impostaEntity() As Notifica_MIB
        Dim localtable As Notifica_Mib = New Notifica_Mib
        With localtable
            '  .id = _id
            .idNotifica = _idNotifica
            .AltroAgente = AltroAgente.Text
            .ContattoLab = ContattoLab.Text
            .ContattoOspedale = ContattoOspedale.Text
            .ContattoTelefono = contattoTelefono.Text
            .IdAgenteEziologico = agenteEziologico.SelectedValue
            .LabAltroBatterio = LabAltroBatterio.Text
            .LabBatterio = labBatterio.SelectedValue
            .LabNote = noteTipizzazione.Text
            .LabSierogruppoMen = LabSierogruppoMen.SelectedValue
            .LabSierotipoHI = LabSierotipoHI.SelectedValue
            .LabSierotipoPNU = LabSierotipoPNU.SelectedValue
            .LabTipizzazione = LabTipizzazione.Text
            .Liquor = liquor.SelectedValue
            .Materiale1 = Materiale1.SelectedValue
            .Materiale2 = Materiale2.SelectedValue
            .Metodo1 = Metodo1.SelectedValue
            .Metodo2 = Metodo2.SelectedValue
            .NoteDiagnosi = noteDiagnosi.Text
            .QC_Altro = Helper.ConvertBooleanToString(altraDiagnosi.Checked)
            .Qc_AltroSpecificare = altroDiagnosiDescr.Text
            .QC_Artrite = Helper.ConvertBooleanToString(artrite.Checked)
            .QC_Cellulite = Helper.ConvertBooleanToString(cellulite.Checked)
            .QC_Epiglottite = Helper.ConvertBooleanToString(epiglottite.Checked)
            .Qc_Polmonite = Helper.ConvertBooleanToString(polmonite.Checked)
            .Qc_Meningite = Helper.ConvertBooleanToString(meningite.Checked)
            .QC_Peritonite = Helper.ConvertBooleanToString(peritonite.Checked)
            .QC_Pericardite = Helper.ConvertBooleanToString(pericardite.Checked)
            .Qc_Sepsi = Helper.ConvertBooleanToString(sepsi.Checked)
            .Tipizzazione = Tipizzazione.SelectedValue
            .LastUser = _cUSer
            .dataPrelievo = Helper.ConvertEmptyDateToNothing(dataPrelievo.Text)
            '.completo = True

            'antibiotico resistenza
            .Pg_Val = Pg_Val.SelectedValue
            .Pg_Mic = Pg_Mic.SelectedValue
            .Pg_Cat = Pg_Cat.SelectedValue
            .Pg_Val_Est = Pg_Val_Est.SelectedValue
            .Pg_Mic_Est = Pg_Mic_Est.SelectedValue
            .Pg_Cat_ESt = Pg_Cat_ESt.SelectedValue
            .Pg_disco = Pg_disco.Text
            .Pg_Disco_Cat = Pg_Disco_Cat.SelectedValue
            .Em_val = Em_val.SelectedValue
            .Em_Mic = Em_Mic.SelectedValue
            .Em_Cat = Em_Cat.SelectedValue
            .Em_val_est = Em_val_est.SelectedValue
            .Em_Mic_Est = Em_Mic_Est.SelectedValue
            .Em_Cat_Est = Em_Cat_Est.SelectedValue
            .Em_disco = Em_disco.Text
            .Em_Disco_Cat = Em_Disco_Cat.SelectedValue
            .Cip_Val = Cip_Val.SelectedValue
            .Cip_Mic = Cip_Mic.SelectedValue
            .Cip_Cat = Cip_Cat.SelectedValue
            .Cip_Val_Est = Cip_Val_Est.SelectedValue
            .Cip_Mic_Est = Cip_Mic_Est.SelectedValue
            .Cip_Cat_Est = Cip_Cat_Est.SelectedValue
            .Cip_Disco = Cip_Disco.Text
            .Cip_Disco_Cat = Cip_Disco_Cat.SelectedValue
            .Cli_Val = Cli_Val.SelectedValue
            .Cli_Mic = Cli_Mic.SelectedValue
            .Cli_Cat = Cli_Cat.SelectedValue
            .Cli_Val_Est = Cli_Val_Est.SelectedValue
            .Cli_Mic_Est = Cli_Mic_Est.SelectedValue
            .Cli_Cat_Est = Cli_Cat_Est.SelectedValue
            .Cli_Disco = Cli_Disco.Text
            .Cli_Disco_Cat = Cli_Disco_Cat.SelectedValue
            .antibiogramma = antibioticoResistenza.SelectedValue
            .Esito14gg = Esito14Giorni.SelectedValue
            .Esito = Esito.SelectedValue

            .Sequele = sequele.SelectedValue
            .SequeleUdito = Helper.ConvertBooleanToString(SequeleUdito.Checked)
            .SequelVista = Helper.ConvertBooleanToString(SequelVista.Checked)
            .SequeleNeuro = Helper.ConvertBooleanToString(SequeleNeuro.Checked)
            .SequeleAmputazione = Helper.ConvertBooleanToString(SequeleAmputazione.Checked)
            .SequeleNecrosi = Helper.ConvertBooleanToString(SequeleNecrosi.Checked)
            .SequeleAltro = Helper.ConvertBooleanToString(SequeleAltro.Checked)
            .SequeleAltroSpecificare = SequeleAltroSpecificare.Text




            .condizioni = fattori.SelectedValue
            .Con_Asplenia = Helper.ConvertBooleanToString(Asplenia.Checked)
            .Con_Immunodeficienza = Helper.ConvertBooleanToString(Immunodeficienza.Checked)
            .Con_Immunodeficienzaacquisita = Helper.ConvertBooleanToString(Immunodeficienzaacquisita.Checked)
            .Con_Leucemie = Helper.ConvertBooleanToString(Leucemie.Checked)
            .Con_neoplasie = Helper.ConvertBooleanToString(Neoplasie.Checked)
            .Con_TerapieImmuno = Helper.ConvertBooleanToString(TerapieImmuno.Checked)
            .Con_Altrocondizione = Helper.ConvertBooleanToString(Altrocondizione.Checked)
            .Con_Trapianto = Helper.ConvertBooleanToString(Trapianto.Checked)
            .Con_cocleare = Helper.ConvertBooleanToString(Cocleare.Checked)
            .Con_Fistole = Helper.ConvertBooleanToString(Fistole.Checked)
            .Con_Insufficenzarenale = Helper.ConvertBooleanToString(Insufficenzarenale.Checked)
            .Con_Diabete = Helper.ConvertBooleanToString(Diabete.Checked)
            .Con_Epatopatia = Helper.ConvertBooleanToString(Epatopatia.Checked)
            .Con_Cardiopatie = Helper.ConvertBooleanToString(Cardiopatie.Checked)
            .Con_Asma = Helper.ConvertBooleanToString(Asma.Checked)
            .Con_Tossicodipendenza = Helper.ConvertBooleanToString(Tossicodipendenza.Checked)
            .Con_Alcolismo = Helper.ConvertBooleanToString(Alcolismo.Checked)
            .Con_Tabagismo = Helper.ConvertBooleanToString(Tabagismo.Checked)
            .Con_altrospecificare = AltraCondizionedescrizione.Text

            .Con_altrePolmonari = Helper.ConvertBooleanToString(Con_altrePolmonari.Checked)
            .Con_Deficit = Helper.ConvertBooleanToString(Con_Deficit.Checked)
            .Con_Emoglobinopatie = Helper.ConvertBooleanToString(Con_Emoglobinopatie.Checked)

            If dataWeb.Text <> "" Then
                .DataWeb = Helper.ConvertEmptyDateToNothing(dataWeb.Text)
            Else
                .DataWeb = Now
            End If

            .DataModifica = Now
        End With
        Return localtable
    End Function
    Private Sub Salva()
        Try
            _mobjMib.username = _cUSer
            If _id = 0 Then
                _mobjMib.Add(impostaEntity)
            Else
                _mobjMib.Update(impostaEntity)
            End If
            Response.Redirect("Riepilogo.aspx?tab=mib", True)
        Catch ex As Exception
            lblErrore.Visible = True
            lblErrore.Text = ex.ToString
            btn.Enabled = False
        End Try
    End Sub
    Protected Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn.Click       
            Salva()

    End Sub

    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("Riepilogo.aspx?tab=mib", True)
    End Sub
End Class
