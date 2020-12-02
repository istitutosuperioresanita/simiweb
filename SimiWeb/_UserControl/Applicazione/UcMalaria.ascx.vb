Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcMalaria
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
        Response.Redirect("~/Notifica/EditMalaria.aspx", True)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaVista(_idNotifica)
            lnkAggiorna.Visible = _modifica
        End If
    End Sub

    Private Sub CaricaVista(ByVal _idNotifica As Integer)
        Dim localtable As Notifica_view_MalariaResult = _mobjNotifica.GetMalariaView(_idNotifica)
        With localtable
            If Not IsNothing(localtable) Then
                tipo.Text = .tipo
                DataClinica.Text = Helper.IsNullDate(.dataClinica)
                dataEmoscopia.Text = Helper.IsNullDate(.dataEmoscopia)
                speciePlasmodio.Text = .speciePlasmodio
                formeMisteSpecificare.Text = .formeMisteSpecificare
                terapia.Text = .terapia
                altraTerapia.Text = .altraTerapia
                faramcoResistenza.Text = .faramcoResistenza
                prevenzioneRicevuta.Text = .prevenzioneRicevuta
                AltroEnte.Text = .AltroEnte
                chemioprofilassi.Text = .chemioprofilassi
                farmaciChemioprofilassi.Text = .farmaciChemioprofilassi
                assunzioniInterrotte.Text = .assunzioniInterrotte
                chemioProfilassiCompletata.Text = .chemioProfilassiCompletata
                motivoInterruzione.Text = .motivoInterruzione
                Effetto1.Text = .Effetto1
                altroEffetto1Specificare.Text = .altroEffetto1Specificare
                Effetto2.Text = .Effetto2
                altroEffetto2Specificare.Text = .altroEffetto2Specificare
                protezionePunture.Text = .protezionePunture
                zanzareZoneRischio.Text = .zanzareZoneRischio
                Repellenti.Text = .Repellenti
                specificaRepellente.Text = .specificaRepellente
                Emoscopiapervenuta.Text = .Emoscopiapervenuta
                Emoscopiacontrollo.Text = .Emoscopiacontrollo
            End If
        End With
    End Sub
End Class
