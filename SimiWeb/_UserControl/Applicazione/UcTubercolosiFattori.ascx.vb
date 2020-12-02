Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcTubercolosiFattori
    Inherits System.Web.UI.UserControl
    Private _idNotifica As Integer
    Private _modifica As Boolean = False
    Private _mobjNotifica As New BllNotifica
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
        Response.Redirect("~/Notifica/EditTubercolosiFattori.aspx", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaVista(_idNotifica)
            lnkAggiorna.Visible = _modifica
        End If
    End Sub

    Private Sub CaricaVista(ByVal _idNotifica As Integer)
        Dim localtable As Notifica_tbc_fattori = _mobjNotifica.GetTbcFAttori(_idNotifica)
        With localtable


            If Not IsNothing(localtable) Then
                esitiradiografici.Text = .esitiradiografici
                graveimmudeficenza.Text = .graveimmudeficenza
                terapiaImmunosoppresiva.Text = .terapiaImmunosoppresiva
                deperimentoOrganico.Text = .deperimentoOrganico
                recenteViaggioTbc.Text = .recenteViaggioTbc
                diabeteScarsamenteControllato.Text = .diabeteScarsamenteControllato
                silicosi.Text = .silicosi
                insufficenzaRenale.Text = .insufficenzaRenale
                gastrectomia.Text = .gastrectomia
                ContattoMalato.Text = .ContattoMalato
                tossicodipendenza.Text = .tossicodipendenza
                Immigrazione.Text = .Immigrazione
                carcere.Text = .carcere
                alcolismo.Text = .alcolismo
                senzaFissaDimora.Text = .senzaFissaDimora
                personaleSanitario.Text = .personaleSanitario
                altro.Text = .Altro
            Else
                esitiradiografici.Text = "no"
                graveimmudeficenza.Text = "no"
                terapiaImmunosoppresiva.Text = "no"
                deperimentoOrganico.Text = "no"
                recenteViaggioTbc.Text = "no"
                diabeteScarsamenteControllato.Text = "no"
                silicosi.Text = "no"
                insufficenzaRenale.Text = "no"
                gastrectomia.Text = "no"
                ContattoMalato.Text = "no"
                tossicodipendenza.Text = "no"
                Immigrazione.Text = "no"
                carcere.Text = "no"
                alcolismo.Text = "no"
                senzaFissaDimora.Text = "no"
                personaleSanitario.Text = "no"
                altro.Text = "no"
            End If

        End With
    End Sub
End Class
