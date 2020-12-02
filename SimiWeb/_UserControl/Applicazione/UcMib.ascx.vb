Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcMib
    Inherits System.Web.UI.UserControl
    Private _idNotifica As Integer
    Private _modifica As Boolean = False
    Private _mobjMib As New BllMib
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
        Response.Redirect("~/Notifica/EditMib.aspx", True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaVista(_idNotifica)
            lnkAggiorna.Visible = _modifica
        End If
    End Sub

    Private Sub CaricaVista(ByVal _idNotifica As Integer)
        Dim localtable As notifica_View_mibResult = _mobjMib.GetMibView(_idNotifica)
        With localtable


            If Not IsNothing(localtable) Then
                AltroAgente.Text = .AltroAgente
                ContattoLab.Text = .ContattoLab
                ContattoOspedale.Text = .ContattoOspedale
                contattoTelefono.Text = .ContattoTelefono
                agenteEziologico.Text = .IdAgenteEziologico
                LabAltroBatterio.Text = .LabAltroBatterio
                labBatterio.Text = .LabBatterio
                noteTipizzazione.Text = .LabNote
                LabSierogruppoMen.Text = .LabSierogruppoMen
                LabSierotipoHI.Text = .LabSierotipoHI
                LabSierotipoPNU.Text = .LabSierotipoPNU
                LabTipizzazione.Text = .LabTipizzazione
                liquor.Text = .Liquor
                Materiale1.Text = .Materiale1
                Materiale2.Text = .Materiale2
                Metodo1.Text = .Metodo1
                Metodo2.Text = .Metodo2
                noteDiagnosi.Text = .NoteDiagnosi
                altraDiagnosi.Text = .QC_Altro
                altroDiagnosiDescr.Text = .Qc_AltroSpecificare
                artrite.Text = .QC_Artrite
                cellulite.Text = .QC_Cellulite
                epiglottite.Text = .QC_Epiglottite
                polmonite.Text = .Qc_Polmonite
                meningite.Text = .Qc_Meningite
                pericardite.Text = .QC_Pericardite
                peritonite.Text = .QC_Peritonite
                sepsi.Text = .Qc_Sepsi
                Tipizzazione.Text = .Tipizzazione
                dataPrelievo.Text = Helper.IsNullDate(.dataprelievo)
                Pg_Val.Text = .Pg_Val
                Pg_Mic.Text = .Pg_Mic
                Pg_Cat.Text = .Pg_Cat
                Pg_Val_Est.Text = .Pg_Val_Est
                Pg_Mic_Est.Text = .Pg_Mic_Est
                Pg_Cat_ESt.Text = .Pg_Cat_ESt
                Pg_disco.Text = .Pg_disco
                Pg_Disco_Cat.Text = .Pg_Disco_Cat
                Em_val.Text = .Em_val
                Em_Mic.Text = .Em_Mic
                Em_Cat.Text = .Em_Cat
                Em_val_est.Text = .Em_val_est
                Em_Mic_Est.Text = .Em_Mic_Est
                Em_Cat_Est.Text = .Em_Cat_Est
                Em_disco.Text = .Em_disco
                Em_Disco_Cat.Text = .Em_Disco_Cat
                Cip_Val.Text = .Cip_Val
                Cip_Mic.Text = .Cip_Mic
                Cip_Cat.Text = .Cip_Cat
                Cip_Val_Est.Text = .Cip_Val_Est
                Cip_Mic_Est.Text = .Cip_Mic_Est
                Cip_Cat_Est.Text = .Cip_Cat_Est
                Cip_Disco.Text = .Cip_Disco
                Cip_Disco_Cat.Text = .Cip_Disco_Cat
                Cli_Val.Text = .Cli_Val
                Cli_Mic.Text = .Cli_Mic
                Cli_Cat.Text = .Cli_Cat
                Cli_Val_Est.Text = .Cli_Val_Est
                Cli_Mic_Est.Text = .Cli_Mic_Est
                Cli_Cat_Est.Text = .Cli_Cat_Est
                Cli_Disco.Text = .Cli_Disco
                Cli_Disco_Cat.Text = .Cli_Disco_Cat
                Antibiogramma.Text = .antibiogramma
                Esito14Giorni.Text = .Esito14gg
                Esito.Text = .Esito

                sequele.Text = .Sequele
                SequeleUdito.Text = .SequeleUdito
                SequelVista.Text = .SequelVista
                SequeleNeuro.Text = .SequeleNeuro
                SequeleAmputazione.Text = .SequeleAmputazione
                SequeleNecrosi.Text = .SequeleNecrosi
                SequeleAltro.Text = .SequeleAltro
                SequeleAltroSpecificare.Text = .SequeleAltroSpecificare




                fattori.Text = .condizioni
                Asplenia.Text = .Con_Asplenia
                Immunodeficienza.Text = .Con_Immunodeficienza
                Immunodeficienzaacquisita.Text = .Con_Immunodeficienzaacquisita
                Leucemie.Text = .Con_Leucemie
                Neoplasie.Text = .Con_neoplasie
                TerapieImmuno.Text = .Con_TerapieImmuno
                Altrocondizione.Text = .Con_Altrocondizione
                Trapianto.Text = .Con_Trapianto
                Cocleare.Text = .Con_cocleare
                Fistole.Text = .Con_Fistole
                Insufficenzarenale.Text = .Con_Insufficenzarenale
                Diabete.Text = .Con_Diabete
                Epatopatia.Text = .Con_Epatopatia
                Cardiopatie.Text = .Con_Cardiopatie
                Asma.Text = .Con_Asma
                Tossicodipendenza.Text = .Con_Tossicodipendenza
                Alcolismo.Text = .Con_Alcolismo
                Tabagismo.Text = .Con_Tabagismo
                AltraCondizionedescrizione.Text = .Con_altrospecificare


                Con_altrePolmonari.Text = .Con_altrePolmonari
                Con_Deficit.Text = .Con_Deficit
                Con_Emoglobinopatie.Text = .Con_Emoglobinopatie
            End If

        End With
    End Sub
End Class
