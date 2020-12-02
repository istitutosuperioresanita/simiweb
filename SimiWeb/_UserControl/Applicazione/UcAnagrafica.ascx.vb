Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcAnagrafica
    Inherits System.Web.UI.UserControl
    Private _idNotifica As Integer
    Private _mobjNotifica As New BllNotifica
    Private _modifica As Boolean = False
    Private _mobjUser As New BllUser
    Public Property IdNotifica() As Integer
        Get
            Return _idNotifica
        End Get
        Set(ByVal value As Integer)
            _idNotifica = value
        End Set
    End Property
    Public Property Modifica() As Boolean
        Get
            Return _Modifica
        End Get
        Set(ByVal value As Boolean)
            _Modifica = value
        End Set
    End Property
    Public Sub ControllaModifica()
        lnkAggiorna.Visible = _modifica
    End Sub
    Protected Sub lnkAggiorna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAggiorna.Click
        Response.Redirect("~/Notifica/EditAnagrafica.aspx", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaVista(_idNotifica)
            lnkAggiorna.Visible = _modifica
            Dim profilo As Utenti_Profilo = _mobjUser.GetProfiloByUsername(HttpContext.Current.User.Identity.Name)
            If profilo.idRegione = "190" Then
                pnlCentroPermanenza.Visible = False
            End If
        End If
    End Sub
    Private Sub CaricaVista(ByVal idNotifica As Integer)
        Try
            Dim anagraficaView As Anagrafica_ViewResult = _mobjNotifica.GetAnagraficaView(idNotifica)
            With anagraficaView
                Nome.Text = .Nome
                Cognome.Text = .Cognome
                sesso.Text = .Sesso
                'NatoEstero.Text = .
                ProvinciaNascita.Text = .Provincia_nascita
                ComuneNascita.Text = .Comune_Nascita
                DataNascita.Text = .DataNascita
                Nazionalita.Text = .Nazionalita
                codiceFiscale.Text = .CodiceFiscale
                NumeroSTP.Text = .NumeroStp
                StranieroNonInRegola.Text = .StranieroNonInRegola
                Professione.Text = .Professione
                SenzaFissaDimora.Text = .SenzaFissaDimora
                ProvinciaResidenza.Text = .Provincia_Residenza
                ComuneResidenza.Text = .Comune_Residenza
                IndirizzoResidenza.Text = .IndirizzoResidenza
                ProvinciaDomicilio.Text = .Provincia_Residenza
                ComuneDomicilio.Text = .Comune_domicilio
                Telefono.Text = .Telefono
                Professione.Text = .Professione
                NatoEstero.Text = .NatoEstero
                CodiceEni.Text = .codiceEni
                indirizzoDiDomicilio.Text = .indirizzoDomicilio
                NazioneResidenza.Text = .nazione_residenza
                arrivoItalia.Text = .arrivoitalia
                centroPermanenza.Text = .CentroPermanenza
                NomeCentroPermanenza.Text = .NomeCentroPermanenza
                'ResidenteEstero.Text = .
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class
