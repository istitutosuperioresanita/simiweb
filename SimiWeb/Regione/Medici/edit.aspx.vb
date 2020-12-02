Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Regione_Medici_edit
    Inherits System.Web.UI.Page
    Private _idRegione As String
    Private _idMedico As Integer = 0
    Private _mobjMedico As New BllMedico
    Private _mobjUtenti As New BllUser
    Private _idAsl As String = ""
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
            Dim utente As Utenti_Profilo = _mobjUtenti.GetProfiloByUsername(User.Identity.Name)
            _idRegione = utente.idRegione
            _idMedico = Session("_idMedico")

            If _idMedico <> 0 Then
                caricaEntity()
            End If
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

        End With


    End Sub
    Private Function ImpostaEntity() As ReferenteUlss

        Dim medico As New ReferenteUlss

        With medico
            If _idMedico <> 0 Then
                .id = _idMedico
            End If
            .cognome = cognome.Text
            .nome = nome.Text
            .idRegione = _idRegione
            .idAsl = _idAsl
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
End Class
