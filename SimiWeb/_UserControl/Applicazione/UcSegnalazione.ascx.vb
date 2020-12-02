Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcSegnalazione
    Inherits System.Web.UI.UserControl
    Private _idNotifica As Integer
    Private _mobjNotifica As New BllNotifica
    Public Property IdNotifica() As Integer
        Get
            Return _idNotifica
        End Get
        Set(ByVal value As Integer)
            _idNotifica = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim NotificaView As Notifica_ViewResult = _mobjNotifica.GetNotificaBase(_idNotifica)
            If Not NotificaView Is Nothing Then
                With NotificaView
                    clinico.Text = .clinico
                    codiceFiscale.Text = .codiceFiscale
                    codiceFiscaleNonconosciuto.Text = .codiceFiscaleNonconosciuto
                    Cognome.Text = .Cognome
                    ComuneNascita.Text = .ComuneNascita
                    DataNascita.Text = .DataNascita
                    dataSegnalazione.Text = .dataSegnalazione
                    epidemiologico.Text = .epidemiologico
                    laboratorio.Text = .laboratorio
                    ReferenteUlss.Text = .ReferenteUlss
                    Nazionalita.Text = .Nazionalita
                    Nome.Text = .Nome
                    NumeroSTP.Text = .NumeroSTP
                    Professione.Text = .Professione
                    ProvinciaNascita.Text = .ProvinciaNascita
                    RicoveroLuogoDicura.Text = .RicoveroLuogoDicura
                    sesso.Text = .sesso
                    StatoVaccinale.Text = .StatoVaccinale
                    StranieroNonInRegola.Text = .StranieroNonInRegola                
                End With
            End If
        End If
    End Sub
End Class
