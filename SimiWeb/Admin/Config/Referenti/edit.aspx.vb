Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess

Partial Class Admin_Config_Referenti_edit
    Inherits System.Web.UI.Page
    Private _idRegione As String
    Private _idMedico As Integer = 0
    Private _mobjMedico As New BllMedico
    Private _mobjUtenti As New BllUser
    Private _idAsl As String = ""
    Private _mobjGeo As New BllGeografiche
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idRegione", _idRegione)
        Me.ViewState.Add("_idMedico", _idMedico)
        Me.ViewState.Add("_idAsl", _idAsl)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idRegione = ViewState("_idRegione")
        _idAsl = ViewState("_idAsl")
        _idMedico = CInt(ViewState("_idMedico"))
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Dim utente As Utenti_Profilo = _mobjUtenti.GetProfiloByUsername(User.Identity.Name)
            '_idRegione = utente.idRegione
            _idMedico = Session("_idMedico")




            If _idMedico <> 0 Then
                CaricaEntity()
            End If
            ImpostaCampi()
        End If
    End Sub
    Private Sub CaricaEntity()
        Dim medico As ReferenteUlss = _mobjMedico.GetByID(_idMedico)

        With medico
            _idAsl = .idAsl
            cognome.Text = .cognome
            nome.Text = .nome
            _idRegione = .idRegione
            telefono.Text = .telefono
            email.Text = .email

            regione.SelectedValue = .idRegione
            CaricaAsl(.idRegione)
            asl.SelectedValue = .idAsl
            asl.Enabled = False
            regione.Enabled = False
        End With


    End Sub

    Private Sub ImpostaCampi()
        Dim regioniDs As List(Of JsonDto) = _mobjGeo.GetAllRegioniJson

        Carica(regione, regioniDs, _idRegione)

    End Sub
    Private Sub Carica(ByRef ctr As DropDownList, ByVal dts As List(Of JsonDto), Optional ByVal sel As String = "")
        ctr.DataValueField = "Codice"
        ctr.DataTextField = "Descrizione"
        ctr.DataSource = dts
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
        If sel <> "" Then
            ctr.SelectedValue = sel
        End If
    End Sub

    Private Function ImpostaEntity() As ReferenteUlss

        Dim medico As New ReferenteUlss

        With medico
            If _idMedico <> 0 Then
                .id = _idMedico
            End If
            .cognome = cognome.Text
            .nome = nome.Text
            .idRegione = regione.SelectedValue
            .idAsl = asl.SelectedValue
            .telefono = telefono.Text
            .valido = True
            .email = email.Text
        End With
        Return medico
    End Function

    Protected Sub salva_Click(sender As Object, e As System.EventArgs) Handles salva.Click
        Try

            If _idMedico = 0 Then
                _mobjMedico.Add(ImpostaEntity)
            Else
                _mobjMedico.Update(ImpostaEntity)

            End If
        Catch ex As Exception
            errore.Text = ex.ToString
        End Try
        Response.Redirect("lista.aspx", True)
    End Sub

    Protected Sub regione_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles regione.SelectedIndexChanged
        CaricaAsl(regione.SelectedValue)
    End Sub
    Private Sub CaricaAsl(ByVal idRegione As String)
        Dim aslDs As List(Of JsonDto) = _mobjGeo.GetAllAslByIdRegioneJson(idRegione)
        Carica(asl, aslDs)
    End Sub
End Class
