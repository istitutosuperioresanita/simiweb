Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcClinici
    Inherits System.Web.UI.UserControl
    Private _idNotifica As Integer
    Private _mobjNotifica As New BllNotifica
    Private _modifica As Boolean = False
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
            Return _modifica
        End Get
        Set(ByVal value As Boolean)
            _Modifica = value
        End Set
    End Property
    Public Sub ControllaModifica()
        lnkAggiorna.Visible = _modifica
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaVista(_idNotifica)
            lnkAggiorna.Visible = _modifica
        End If

    End Sub
    Private Sub CaricaVista(ByVal idNotifica As Integer)
        Try
            Dim clinicaView As Clinica_ViewResult = _mobjNotifica.GetClinicaView(_idNotifica)
            With clinicaView
                AltreColettivita.Text = .AltraColletivita
                ComuneContagio.Text = .comuneContagio
                ComuneSintomi.Text = .comuneSintomi
                Collettivita.Text = .comunita
                ContattiStretti.Text = .ContattiStretti
                Clinico.Text = .CriterioClinico
                Epidemiologico.Text = .CriterioEpidemiologico
                Laboratorio.Text = .CriterioLaboratorio
                DataDimissione.Text = Helper.IsNullDate(.DataDimissione)
                DataDoseVaccino.Text = Helper.IsNullDate(.DataDoseUltimoVaccino)
                DoseVaccino.Text = .DoseVaccino
                DataPrimiSintomi.Text = Helper.IsNullDate(.DataPrimiSintomi)
                DataRicovero.Text = Helper.IsNullDate(.DataRicovero)
                ' .Id
                '.IdNotifica
                ' .Localita

                StrutturaRicovero.Text = .StrutturaRicovero
                RicoveroLuogoDicura.Text = .RicoveroOspedaliero
                LuogoRicovero.Text = .LuogoRicovero
                MotivoRicovero.Text = .MotivoDelRicovero
                Nazione1.Text = .nazione1
                Nazione2.Text = .nazione2
                Nazione3.Text = .nazione3
                NazioneContagi.Text = .nazioneContagio
                NazioneSintomi.Text = .nazionePrimiSintomi
                ' .NomeStruttura
                ' .Note
                ProvinciaContagio.Text = .provinciaContagio
                ProvinciaPrimiSintomi.Text = .provinciaSintomi
                Reparto.Text = .Reparto
                ' .RicoveroOspedaliero
                StatoVaccinale.Text = .StatoVaccinale

                Viaggio.Text = .ViaggioFuoriResidenza


                ricerca1.Text = .ricerca1
                ricerca2.Text = .ricerca2
                Luogo1.Text = .luogo1
                Luogo2.Text = .luogo2
                dataesame1.Text = Helper.IsNullDate(.dataesame1)
                dataesame2.Text = Helper.IsNullDate(.dataesame2)
                risultato1.Text = .risultato1
                risultato2.Text = .risultato2

                Nazione1Periodo.Text = .nazione1Periodo
                Nazione2Periodo.Text = .nazione2Periodo
                Nazione3Periodo.Text = .nazione3Periodo
                CasiCorrelati.Text = .CasiCorrelati
                note.Text = .Note
                agente.Text = .agente
                deceduto.Text = .deceduto
                NomeCommerciale.Text = .NomeCommercialeVaccino
                NoteVaccino.Text = .noteVaccino

                contagio.Text = .contagio
                contagioDove.Text = .contagioDove
                focolaio.Text = .focolaio
                focolaioDescrizione.Text = .focolaioDescrizione
                contatto.Text = .contatto

                'Esito.Text = .Esito
                'Esito14Giorni.Text = .Esito14gg
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub linkAggiornaClinica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkAggiorna.Click
        Response.Redirect("~/Notifica/EditClinici.aspx", True)
    End Sub
End Class
