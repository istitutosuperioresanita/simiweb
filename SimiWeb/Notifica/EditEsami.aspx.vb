Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_EditEsami
    Inherits System.Web.UI.Page
    Private _mobjNotifica As New BllNotifica
    Private _mobjEsami As New BllEsami
    Private _idClinica As Integer = 0
    Private _idMalattia As Integer = 0
    Private _idNotifica As Integer = 0
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idClinica", _idClinica)
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idClinica = CInt(ViewState("_idClinica"))
        _idNotifica = CInt(ViewState("_idNotifica"))
        _idMalattia = CInt(ViewState("_idMalattia"))
    End Sub
    Private Function ImpostaEntity() As Notifica_Esami

        Dim localTable As New Notifica_Esami
        With localTable
            .CodiceMateriale = Request.Form("ctl00$Contenuto$materiale")
            .codiceMetodo = metodo.SelectedValue
            .Data = Helper.ConvertEmptyDateToNothing(data.Text)
            .EffettuatoDa = effetuato.Text
            .Luogo = luogo.Text
            .Risultato = risultato.Text
            .Note = note.Text
            .IdNotifica = _idNotifica

        End With
        Return localTable
    End Function
    Private Sub salva()
        Try
            _mobjNotifica.username = User.Identity.Name
            _mobjNotifica.record = UcStatoSegnalazione1.nome + " " + UcStatoSegnalazione1.cognome
            _mobjNotifica.AddEsame(ImpostaEntity)
            'ViewEsami1.bind()
            ViewEsami1.IdNotifica = _idNotifica
            ViewEsami1.bind()
        Catch ex As Exception
            lblErrore.Visible = True
            lblErrore.Text = ex.ToString
        End Try
    End Sub
    Private Sub CaricaValoriStartUp()

        BindIntestazione()
        bind(metodo, _mobjEsami.GetAllMetodoJson)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idNotifica = Session("idNotifica")
            ViewEsami1.IdNotifica = _idNotifica
            ViewEsami1.AbilitaModifiche = True
            UcStatoSegnalazione1.IdNotifica = _idNotifica
            CaricaValoriStartUp()
            ImpostaJavascript()
        End If
    End Sub
    Private Sub ImpostaJavascript()
        Me.metodo.Attributes("onchange") = "getMateriale('metodo','materiale');"
        Me.data.Attributes("onblur") = "check_date(this);"
    End Sub
    Private Sub bind(ByRef cmb As DropDownList, ByRef ds As List(Of JsonDto))
        cmb.DataValueField = "codice"
        cmb.DataTextField = "descrizione"
        cmb.DataSource = ds
        cmb.DataBind()
        cmb.Items.Insert(0, New ListItem("Selezionare..", ""))
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

    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        salva()
        metodo.SelectedValue = ""
    End Sub

    Protected Sub annulla_Click(sender As Object, e As System.EventArgs) Handles annulla.Click
        Response.Redirect("riepilogo.aspx", True)
    End Sub
End Class
