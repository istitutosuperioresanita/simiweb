Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcTubercolosi
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
        Response.Redirect("~/Notifica/EditTubercolosi.aspx", True)
    End Sub
    Private Sub CaricaEntity()
        Dim localEntity As Notifica_Tbc = _mobjNotifica.GetTbc_View(_idNotifica)

        If Not IsNothing(localEntity) Then
            With localEntity
                Agente.Text = .AgenteEziologico
                AltroAgente.Text = .AltroAgente
                anno.Text = .AnnoTbcPassato
                Antibiogramma.Text = .Antibiogramma
                DataInizioTerapiaTubercolare.Text = Helper.IsNullDate(.DataInizioTerapia)
                DiagnosiTubercolosiPassato.Text = .DiagnosiTbcPassato
                Disseminata.Text = .Disseminata
                SedeExtraPolmonare.Text = .ExtraPolmonare
                LivelloDiAccertamento.Text = .LivelloDiAccertamento
                Localizzazione1.Text = .localizzazione1
                Localizzazione2.Text = .localizzazione2
                mese.Text = .MeseTbcPAssato
                Miliare.Text = .Miliare
                '.MotivoIterDiagnostico = 
                Note.Text = .Note
                SedePolmonare.Text = .SedePolmonare
                Tipo.Text = .tipo
                TipoClassificazione.Text = .TipoClassificazione
                '.TipoIterDiagnostico = tipo
                STRE.Text = .STRE
                INH.Text = .INH
                RMP.Text = .RMP
                EMB.Text = .EMB
                PZA.Text = .PZA

                DataInizioTerapiaCentro.Text = Helper.IsNullDate(.DataInizioTerapiaCentro)
                IsoniazideInizio.Text = .IsoniazideInizio
                IsoniazideFine.Text = .IsoniazideFine
                RifampicinaInizio.Text = .RifampicinaInizio
                RifampicinaFine.Text = .RifampicinaFine
                PirazinamideInizio.Text = .PirazinamideInizio
                PirazinamideFine.Text = .PirazinamideFine
                EtambutoloInizio.Text = .EtambutoloInizio
                EtambutoloFIne.Text = .EtambutoloFine
                TerapiaModificata.Text = .TerapiaModificata
                Esito.Text = .Esito
                trasferito.Text = .trasferito
                DataChiusura.Text = Helper.IsNullDate(.DataChiusura)
                trattamentoInterotto.Text = .trattamentoInterotto

                EsameColturaleEscreato.Text = .EsameColturaleEscreato
                EsameColturaleAltroMateriale.Text = .EsameColturaleAltroMateriale
                EsameColturaleDesc.Text = .EsameColturaleAltroDesc
                EsameDirettoEscreato.Text = .EsameDirettoEscreato
                Esamedirettoaltromateriale.Text = .Esamedirettoaltromateriale
                EsamedirettoaltromaterialeDesc.Text = .EsamedirettoaltromaterialeDesc
                Clinica.Text = .Clinica
                Mantoux.Text = .Mantoux
                RxStandard.Text = .RxStandard
                RispostaTerapia.Text = .RispostaTerapia
                RiscontroAutopico.Text = .RiscontroAutopico
                Quantiferon.Text = .Quantiferon



                Rifampicina.Text = .Rifampicin
                Isoniazide.Text = .Isoniazide
                Pirazinamide.Text = .Pirazinamide
                Etambutolo.Text = .Etambutolo


                altro1.Text = .Altro1
                altro1Inizio.Text = .Altro1Inizio
                altro1Fine.Text = .Altro1Fine
                altro2.Text = .Altro2
                altro2Inizio.Text = .Altro2Inizio
                altro2Fine.Text = .Altro2Fine
                altro3.Text = .Altro3
                altro3Inizio.Text = .Altro3Inizio
                altro3Fine.Text = .Altro3Fine
                altro4.Text = .Altro4
                altro4Inizio.Text = .Altro4Inizio
                altro4Fine.Text = .Altro4Fine


            End With
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaEntity()
            lnkAggiorna.Visible = _modifica
        End If
    End Sub
End Class
