Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class _UserControl_Navigazione_UcLeftMenu
    Inherits System.Web.UI.UserControl
    Private _mobjUTente As New BllUser
    Private _lettura As Boolean = True
    Private _aggiornamento As Boolean = True
    Private _eliminazione As Boolean = True
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then


            Dim utente As Utenti_Profilo = _mobjUTente.GetProfiloByUsername(HttpContext.Current.User.Identity.Name)
            _lettura = utente.Letttura
            _aggiornamento = utente.Aggiornamento
            _eliminazione = utente.Eliminazione
            Dim currRoles() As String = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name)
            Dim ruolo As String = currRoles(0).ToString


            Select Case ruolo
                Case "admin"
                    lnkNuovaNotifica.Visible = False
                    lnkNuovaNotifica.Visible = False
                    lnkGestioneMedici.Visible = False
                    LnkDashBoard.Visible = True
                Case "asl"
                    lnkGestioneMedici.Visible = False
                    LnkDashBoard.Visible = False
                    lnkEsportaMinistero.Visible = False
                Case "iss"
                    lnkNuovaNotifica.Visible = False
                    lnkAnalisiAdv.NavigateUrl = "~/Iss/Analisi.aspx"
                    lnkGestioneMedici.Visible = False
                    LnkDashBoard.Visible = False
                    lnkNuovoFocolaio.Visible = False

                Case "regione"
                    lnkNuovaNotifica.Visible = True
                    lnkNuovoFocolaio.Visible = True
                    LnkDashBoard.Visible = False
                Case "laboratorio"

                    lnkAnalisiAdv.Visible = False
                    lnkGestioneMedici.Visible = False
                    LnkDashBoard.Visible = False
                    lnkNuovoFocolaio.Visible = False
                    lnkListaFocolaio.Visible = False
                    lnkEsportaFocolaio.Visible = False
                    lnkFocolaioAnalisi.Visible = False
                    lnkEsportaMinistero.Visible = False
                    'lnkEsporta.Visible = False
                    lnkMod16.Visible = False
                Case "medico"
                    lnkAnalisiAdv.Visible = False
                    lnkGestioneMedici.Visible = False
                    LnkDashBoard.Visible = False
                    lnkNuovoFocolaio.Visible = True
                    lnkListaFocolaio.Visible = True
                    lnkEsportaFocolaio.Visible = False
                    lnkFocolaioAnalisi.Visible = False
                    lnkEsportaMinistero.Visible = False
                    lnkEsporta.Visible = True
                    lnkMod16.Visible = False
            End Select


            If _aggiornamento = False Then
                lnkNuovaNotifica.Visible = False
                lnkNuovoFocolaio.Visible = False
                lnkGestioneMedici.Visible = False
            End If

        End If
    End Sub
End Class
