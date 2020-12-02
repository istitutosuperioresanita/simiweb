Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_EditTubercolosi
    Inherits System.Web.UI.Page
    Private _mobjNotifica As New BllNotifica
    Private _mobjTbc As New BllTbc
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
        Dim localEntity As Notifica_tbc_fattori = _mobjNotifica.GetTbcFAttori(_idNotifica)

        If Not IsNothing(localEntity) Then
            With localEntity
                _modifica = True
                _idNotifica = .idNotifica
                esitiradiografici.SelectedValue = .esitiradiografici
                graveimmudeficenza.SelectedValue = .graveimmudeficenza
                terapiaImmunosoppresiva.SelectedValue = .terapiaImmunosoppresiva
                deperimentoOrganico.SelectedValue = .deperimentoOrganico
                recenteViaggioTbc.SelectedValue = .recenteViaggioTbc
                diabeteScarsamenteControllato.SelectedValue = .diabeteScarsamenteControllato
                silicosi.SelectedValue = .silicosi
                insufficenzaRenale.SelectedValue = .insufficenzaRenale
                gastrectomia.SelectedValue = .gastrectomia
                ContattoMalato.SelectedValue = .ContattoMalato
                tossicodipendenza.SelectedValue = .tossicodipendenza
                Immigrazione.SelectedValue = .Immigrazione
                carcere.SelectedValue = .carcere
                alcolismo.SelectedValue = .alcolismo
                senzaFissaDimora.SelectedValue = .senzaFissaDimora
                personaleSanitario.SelectedValue = .personaleSanitario
                altro.SelectedValue = .Altro
                dataWeb.Value = Helper.IsNullDate(.DataWeb)

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

    Private Function impostaEntity() As Notifica_tbc_fattori

        Dim localtable As Notifica_tbc_fattori = New Notifica_tbc_fattori
        With localtable

            '   .id = _id
            .idNotifica = _idNotifica
            .esitiradiografici = esitiradiografici.SelectedValue
            .graveimmudeficenza = graveimmudeficenza.SelectedValue
            .terapiaImmunosoppresiva = terapiaImmunosoppresiva.SelectedValue
            .deperimentoOrganico = deperimentoOrganico.SelectedValue
            .recenteViaggioTbc = recenteViaggioTbc.SelectedValue
            .diabeteScarsamenteControllato = diabeteScarsamenteControllato.SelectedValue
            .silicosi = silicosi.SelectedValue
            .insufficenzaRenale = insufficenzaRenale.SelectedValue
            .gastrectomia = gastrectomia.SelectedValue
            .ContattoMalato = ContattoMalato.SelectedValue
            .tossicodipendenza = tossicodipendenza.SelectedValue
            .Immigrazione = Immigrazione.SelectedValue
            .carcere = carcere.SelectedValue
            .alcolismo = alcolismo.SelectedValue
            .senzaFissaDimora = senzaFissaDimora.SelectedValue
            .personaleSanitario = personaleSanitario.SelectedValue
            .Altro = altro.SelectedValue
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
        _mobjNotifica.username = _uCuser
        Try
            If _modifica = False Then
                _mobjNotifica.AddTbcFAttori(impostaEntity)
            Else
                _mobjNotifica.UpdateTbcFAttori(impostaEntity)
            End If

            Response.Redirect("Riepilogo.aspx?tab=fattori", True)
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
        Response.Redirect("Riepilogo.aspx?tab=fattori", True)
    End Sub
End Class
