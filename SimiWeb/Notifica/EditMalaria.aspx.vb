Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_EditMalaria
    Inherits System.Web.UI.Page
    Private _mobjNotifica As New BllNotifica
    Private mobjdataMail As New DalMessaggio
    Private mobjdataNotifica As New DalNotifica
    Private _idMalattia As Integer = 0
    Private _idNotifica As Integer = 0
    Private _modifica As Boolean = False
    Private _uCuser As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_modifica", _modifica)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idNotifica = CInt(ViewState("_idNotifica"))
        _modifica = CBool(ViewState("_modifica"))
    End Sub
    Private Sub ImpostaJavascript()
        Me.DataClinica.Attributes("onblur") = "check_date(this);"
        Me.dataEmoscopia.Attributes("onblur") = "check_date(this);"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idNotifica = Session("idNotifica")
            CAricaEntity()
            ImpostaJavascript()
            CaricaValoriStartUp()
        Else
            _uCuser = User.Identity.Name
        End If

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
    Private Sub CAricaEntity()
        Dim localEntity As Notifica_Malaria = _mobjNotifica.GetMalaria(_idNotifica)

        If Not IsNothing(localEntity) Then
            With localEntity
                _modifica = True
                _idNotifica = .idNotifica

                tipo.SelectedValue = .tipo
                DataClinica.Text = Helper.IsNullDate(.dataClinica)
                dataEmoscopia.Text = Helper.IsNullDate(.dataEmoscopia)
                speciePlasmodio.SelectedValue = .speciePlasmodio
                formeMisteSpecificare.Text = .formeMisteSpecificare
                terapia.SelectedValue = .terapia
                altraTerapia.Text = .altraTerapia
                faramcoResistenza.Text = .faramcoResistenza
                prevenzioneRicevuta.SelectedValue = .prevenzioneRicevuta
                AltroEnte.Text = .AltroEnte
                chemioprofilassi.SelectedValue = .chemioprofilassi
                farmaciChemioprofilassi.SelectedValue = .farmaciChemioprofilassi
                assunzioniInterrotte.SelectedValue = .assunzioniInterrotte
                chemioProfilassiCompletata.SelectedValue = .chemioProfilassiCompletata
                motivoInterruzione.SelectedValue = .motivoInterruzione
                Effetto1.SelectedValue = .Effetto1
                altroEffetto1Specificare.Text = .altroEffetto1Specificare
                Effetto2.SelectedValue = .Effetto2
                altroEffetto2Specificare.Text = .altroEffetto2Specificare
                protezionePunture.SelectedValue = .protezionePunture
                zanzareZoneRischio.SelectedValue = .zanzareZoneRischio
                Repellenti.SelectedValue = .Repellenti
                specificaRepellente.Text = .specificaRepellente
                Emoscopiapervenuta.SelectedValue = .Emoscopiapervenuta
                Emoscopiacontrollo.SelectedValue = .Emoscopiacontrollo
            End With
        Else
            _modifica = False
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
    End Sub

    Private Function impostaEntity() As Notifica_Malaria

        Dim localtable As Notifica_Malaria = New Notifica_Malaria
        With localtable


            .idNotifica = _idNotifica
            .tipo = tipo.SelectedValue
            .dataClinica = Helper.ConvertEmptyDateToNothing(DataClinica.Text)
            .dataEmoscopia = Helper.ConvertEmptyDateToNothing(dataEmoscopia.Text)
            .speciePlasmodio = speciePlasmodio.SelectedValue
            .formeMisteSpecificare = formeMisteSpecificare.Text
            .terapia = terapia.SelectedValue
            .altraTerapia = altraTerapia.Text
            .faramcoResistenza = faramcoResistenza.Text
            .prevenzioneRicevuta = prevenzioneRicevuta.SelectedValue
            .AltroEnte = AltroEnte.Text
            .chemioprofilassi = chemioprofilassi.SelectedValue
            .farmaciChemioprofilassi = farmaciChemioprofilassi.SelectedValue
            .assunzioniInterrotte = assunzioniInterrotte.SelectedValue
            .chemioProfilassiCompletata = chemioProfilassiCompletata.SelectedValue
            .motivoInterruzione = motivoInterruzione.SelectedValue
            .Effetto1 = Effetto1.SelectedValue
            .altroEffetto1Specificare = altroEffetto1Specificare.Text
            .Effetto2 = Effetto2.SelectedValue
            .altroEffetto2Specificare = altroEffetto2Specificare.Text
            .protezionePunture = protezionePunture.SelectedValue
            .zanzareZoneRischio = zanzareZoneRischio.SelectedValue
            .Repellenti = Repellenti.SelectedValue
            .specificaRepellente = specificaRepellente.Text
            .Emoscopiapervenuta = Emoscopiapervenuta.SelectedValue
            .Emoscopiacontrollo = Emoscopiacontrollo.SelectedValue
            If _modifica = False Then
                .DataWeb = Now
            Else
                .DataWeb = Helper.ConvertEmptyDateToNothing(dataWeb.Value)
            End If
            .LastUser = _uCuser
            .DataModifica = Now
        End With
        Return localtable
    End Function

    Private Sub salva()

        Try
            _mobjNotifica.username = _uCuser
            If _modifica = False Then
                _mobjNotifica.AddMalaria(impostaEntity)
            Else
                _mobjNotifica.UpdateMalaria(impostaEntity)
            End If

            Response.Redirect("Riepilogo.aspx?tab=malaria", True)
        Catch ex As Exception
            lblErrore.Text = ex.ToString
            lblErrore.Visible = True
            btnSalva.Enabled = False
        End Try
    End Sub
    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        salva()

    End Sub

    Protected Sub BtnAnnulla_Click(sender As Object, e As System.EventArgs) Handles BtnAnnulla.Click
        Response.Redirect("Riepilogo.aspx?tab=malaria", True)
    End Sub
End Class
