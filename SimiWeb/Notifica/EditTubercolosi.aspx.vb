Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_EditTubercolosi
    Inherits System.Web.UI.Page
    Private _mobjNotifica As New BllNotifica
    Private _mobjTbc As New BllTbc
    Private _MobjEsami As New BllEsami
    Private _idNotifica As Integer = 0
    Private _idMalattia As Integer = 0
    Private _modifica As Boolean = False
    '  Private _id As Integer = 0
    Private _CUSer As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        '  Me.ViewState.Add("_id", _id)
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_modifica", _modifica)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        ' _id = CInt(ViewState("_id"))
        _idNotifica = CInt(ViewState("_idNotifica"))
        _idMalattia = CInt(ViewState("_idMalattia"))
        _modifica = CBool(ViewState("_modifica"))
    End Sub
    Private Sub ImpostaJavascript()
        Me.SedeExtraPolmonare.Attributes("onclick") = "abilitaExtraPolmonare();"
        Me.Localizzazione1.Attributes("onchange") = "ControllaLocalizzazioni();"
        Me.Localizzazione2.Attributes("onchange") = "ControllaLocalizzazioni();"
        Me.Miliare.Attributes("onclick") = "ControllaMiliare();"
        Me.Disseminata.Attributes("onchange") = "ControllaDisseminata();"
        Me.anno.Attributes("onblur") = "TbcPassata();isnum(this)"
        Me.mese.Attributes("onblur") = "TbcPassata();isnum(this)"
        Me.DataInizioTerapiaCentro.Attributes("onblur") = "check_date(this);"
        Me.DataChiusura.Attributes("onblur") = "check_date(this);"
        Me.Antibiogramma.Attributes("onchange") = "CheckAntibiogramma();"
        Me.trasferito.Attributes("onblur") = "CheckEsito()"
        Me.Esito.Attributes("onchange") = "CheckEsito()"
        Me.trattamentoInterotto.Attributes("onchange") = "CheckEsito()"
        Me.DiagnosiTubercolosiPassato.Attributes("onchange") = "TbcPassata();"
        Me.Agente.Attributes("onchange") = "CheckAgente();"
        Me.AltroAgente.Attributes("onblur") = "CheckAgente();"
        Me.EsameColturaleAltroMateriale.Attributes("onchange") = "CheckAltroEsameColturale();"
        Me.EsameColturaleDesc.Attributes("onblur") = "CheckAltroEsameColturale();"
        Me.DataInizioTerapiaTubercolare.Attributes("onblur") = "check_date(this);"

        Me.Esamedirettoaltromateriale.Attributes("onchange") = "CheckAltroEsameDiretto();"
        Me.EsamedirettoaltromaterialeDesc.Attributes("onblur") = "CheckAltroEsameDiretto();"


        IsoniazideInizio.Attributes("onblur") = "isnum(this);"
        IsoniazideFine.Attributes("onblur") = "isnum(this);"
        RifampicinaInizio.Attributes("onblur") = "isnum(this);"
        RifampicinaFine.Attributes("onblur") = "isnum(this);"
        PirazinamideInizio.Attributes("onblur") = "isnum(this);"
        PirazinamideFine.Attributes("onblur") = "isnum(this);"
        EtambutoloInizio.Attributes("onblur") = "isnum(this);"
        EtambutoloFIne.Attributes("onblur") = "isnum(this);"
        altro1Inizio.Attributes("onblur") = "isnum(this);"
        altro1Fine.Attributes("onblur") = "isnum(this);"
        altro2Inizio.Attributes("onblur") = "isnum(this);"
        altro2Fine.Attributes("onblur") = "isnum(this);"
        altro3Inizio.Attributes("onblur") = "isnum(this);"
        altro3Fine.Attributes("onblur") = "isnum(this);"
        altro4Inizio.Attributes("onblur") = "isnum(this);"
        altro4Fine.Attributes("onblur") = "isnum(this);"

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idNotifica = Session("idNotifica")
            CaricaValoriStartUp()
            CaricaEntity()
            CheckExtraPolmonare()
            CheckCampi()
            ImpostaJavascript()
            UcStatoSegnalazione1.IdNotifica = _idNotifica
        Else

            _CUSer = User.Identity.Name
        End If
        _mobjTbc.username = _CUSer
        _mobjTbc.record = UcStatoSegnalazione1.nome + " " + UcStatoSegnalazione1.cognome
    End Sub
    Private Sub BindLocalizzazioni(ByRef cmb As DropDownList, ByVal ds As List(Of JsonDto))
        cmb.DataSource = ds
        cmb.DataTextField = "descrizione"
        cmb.DataValueField = "codice"
        cmb.DataBind()
        cmb.Items.Insert(0, New ListItem("Altro", "999999"))
        cmb.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaValoriStartUp()


        BindIntestazione()
        Dim ds As List(Of JsonDto)
        If _idMalattia = 42 Then
            ds = _mobjTbc.GetZoneList(1)
            BindLocalizzazioni(Localizzazione1, ds)
            BindLocalizzazioni(Localizzazione2, ds)
        End If
        If _idMalattia = 43 Then
            ds = _mobjTbc.GetZoneList(2)
            BindLocalizzazioni(Localizzazione1, ds)
            BindLocalizzazioni(Localizzazione2, ds)
        End If


        BindLocalizzazioni(Agente, _MobjEsami.GetAgenteByIdMalattiaJson(_idMalattia))

    End Sub

    Private Sub BindIntestazione()
        Dim notificaInfo As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)
        With notificaInfo
            UcStatoSegnalazione1.malattia = .malattia
            UcStatoSegnalazione1.nome = .nome
            UcStatoSegnalazione1.cognome = .cognome
            _idMalattia = .idmalattia
        End With
    End Sub

    Private Sub CheckCampi()
        If Antibiogramma.SelectedValue = "Si" Then



            STRE.Enabled = True
            INH.Enabled = True
            RMP.Enabled = True
            EMB.Enabled = True
            PZA.Enabled = True

        Else
            STRE.Enabled = False
            INH.Enabled = False
            RMP.Enabled = False
            EMB.Enabled = False
            PZA.Enabled = False

            STRE.SelectedValue = ""
            INH.SelectedValue = ""
            RMP.SelectedValue = ""
            EMB.SelectedValue = ""
            PZA.SelectedValue = ""
        End If
    End Sub

    Private Sub CaricaEntity()
        Dim localEntity As Notifica_Tbc = _mobjTbc.GetTbc(_idNotifica)

        If Not IsNothing(localEntity) Then
            With localEntity
                _idNotifica = .idNotifica
                _modifica = True
                '    _id = .idNotifica

                Agente.SelectedValue = .AgenteEziologico                
                AltroAgente.Text = .AltroAgente
                anno.Text = .AnnoTbcPassato
                Antibiogramma.SelectedValue = .Antibiogramma
                DataInizioTerapiaTubercolare.Text = Helper.IsNullDate(.DataInizioTerapia)
                DiagnosiTubercolosiPassato.Text = .DiagnosiTbcPassato
                Disseminata.SelectedValue = .Disseminata
                SedeExtraPolmonare.Checked = Helper.ConvertStringToBoolean(.ExtraPolmonare)
                LivelloDiAccertamento.Text = .LivelloDiAccertamento
                Localizzazione1.SelectedValue = .localizzazione1
                Localizzazione2.SelectedValue = .localizzazione2
                mese.Text = .MeseTbcPAssato
                Miliare.Checked = Helper.ConvertStringToBoolean(.Miliare)
                '.MotivoIterDiagnostico = 
                Note.Text = .Note
                dataWeb.Value = Helper.IsNullDate(.DataWeb)
                SedePolmonare.Checked = Helper.ConvertStringToBoolean(.SedePolmonare)
                'Tipo.SelectedValue = "" '.tipo
                TipoClassificazione.SelectedValue = .TipoClassificazione
                '.TipoIterDiagnostico = tipo


                'nuovi campi

                STRE.SelectedValue = .STRE
                INH.SelectedValue = .INH
                RMP.SelectedValue = .RMP
                EMB.SelectedValue = .EMB
                PZA.SelectedValue = .PZA
                DataInizioTerapiaCentro.Text = Helper.IsNullDate(.DataInizioTerapiaCentro)
                IsoniazideInizio.Text = .IsoniazideInizio
                IsoniazideFine.Text = .IsoniazideFine
                RifampicinaInizio.Text = .RifampicinaInizio
                RifampicinaFine.Text = .RifampicinaFine
                PirazinamideInizio.Text = .PirazinamideInizio
                PirazinamideFine.Text = .PirazinamideFine
                EtambutoloInizio.Text = .EtambutoloInizio
                EtambutoloFIne.Text = .EtambutoloFine
                TerapiaModificata.SelectedValue = .TerapiaModificata
                Esito.SelectedValue = .Esito
                trasferito.Text = .trasferito
                DataChiusura.Text = Helper.IsNullDate(.DataChiusura)
                trattamentoInterotto.SelectedValue = .trattamentoInterotto



                EsameColturaleEscreato.SelectedValue = .EsameColturaleEscreato
                EsameColturaleAltroMateriale.SelectedValue = .EsameColturaleAltroMateriale
                EsameColturaleDesc.Text = .EsameColturaleAltroDesc
                EsameDirettoEscreato.SelectedValue = .EsameDirettoEscreato
                Esamedirettoaltromateriale.SelectedValue = .Esamedirettoaltromateriale
                EsamedirettoaltromaterialeDesc.Text = .EsamedirettoaltromaterialeDesc
                Clinica.SelectedValue = .Clinica 
                Mantoux.SelectedValue = .Mantoux
                RxStandard.SelectedValue = .RxStandard
                RispostaTerapia.SelectedValue = .RispostaTerapia
                RiscontroAutopico.SelectedValue = .RiscontroAutopico
                Quantiferon.SelectedValue = .Quantiferon


                'modifiche 26 giugno


                Rifampicina.SelectedValue = .Rifampicin
                Isoniazide.SelectedValue = .Isoniazide
                Pirazinamide.SelectedValue = .Pirazinamide
                Etambutolo.SelectedValue = .Etambutolo

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
        Else
            _modifica = False
        End If
    End Sub
    Private Function impostaEntity() As Notifica_Tbc
        Dim localtable As Notifica_Tbc = New Notifica_Tbc
        With localtable

            .idNotifica = _idNotifica
            .AgenteEziologico = Agente.SelectedValue
            .AltroAgente = AltroAgente.Text
            .AnnoTbcPassato = anno.Text
            .Antibiogramma = Antibiogramma.SelectedValue
            .DataInizioTerapia = Helper.ConvertEmptyDateToNothing(DataInizioTerapiaTubercolare.Text)
            .DiagnosiTbcPassato = DiagnosiTubercolosiPassato.Text
            .Disseminata = Disseminata.SelectedValue
            .ExtraPolmonare = Helper.ConvertBooleanToString(SedeExtraPolmonare.Checked)
            .LivelloDiAccertamento = LivelloDiAccertamento.Text
            .localizzazione1 = Localizzazione1.SelectedValue
            .localizzazione2 = Localizzazione2.SelectedValue
            .MeseTbcPAssato = mese.Text
            .Miliare = Helper.ConvertBooleanToString(Miliare.Checked)
            '.MotivoIterDiagnostico = 
            .Note = Note.Text
            .SedePolmonare = Helper.ConvertBooleanToString(SedePolmonare.Checked)
            '.tipo = Tipo.SelectedValue
            .TipoClassificazione = TipoClassificazione.SelectedValue
            '.TipoIterDiagnostico = tipo
            .LastUser = _CUSer
            If _idNotifica = 0 Then
                .DataWeb = Now
            Else
                .DataWeb = Helper.ConvertEmptyDateToNothing(dataWeb.Value)
            End If

            .DataModifica = Now


            'nuovi campi

            .STRE = STRE.SelectedValue
            .INH = INH.SelectedValue
            .RMP = RMP.SelectedValue
            .EMB = EMB.SelectedValue
            .PZA = PZA.SelectedValue
            .DataInizioTerapiaCentro = Helper.ConvertEmptyDateToNothing(DataInizioTerapiaCentro.Text)
            .IsoniazideInizio = IsoniazideInizio.Text
            .IsoniazideFine = IsoniazideFine.Text
            .RifampicinaInizio = RifampicinaInizio.Text
            .RifampicinaFine = RifampicinaFine.Text
            .PirazinamideInizio = PirazinamideInizio.Text
            .PirazinamideFine = PirazinamideFine.Text
            .EtambutoloInizio = EtambutoloInizio.Text
            .EtambutoloFine = EtambutoloFIne.Text
            .TerapiaModificata = TerapiaModificata.SelectedValue
            .Esito = Esito.SelectedValue
            .trasferito = trasferito.Text
            .DataChiusura = Helper.ConvertEmptyDateToNothing(DataChiusura.Text)
            .trattamentoInterotto = trattamentoInterotto.SelectedValue


            .EsameColturaleEscreato = EsameColturaleEscreato.SelectedValue
            .EsameColturaleAltroMateriale = EsameColturaleAltroMateriale.SelectedValue
            .EsameColturaleAltroDesc = EsameColturaleDesc.Text
            .EsameDirettoEscreato = EsameDirettoEscreato.SelectedValue
            .Esamedirettoaltromateriale = Esamedirettoaltromateriale.SelectedValue
            .EsamedirettoaltromaterialeDesc = EsamedirettoaltromaterialeDesc.Text
            .Clinica = Clinica.SelectedValue
            .Mantoux = Mantoux.SelectedValue
            .RxStandard = RxStandard.SelectedValue
            .RispostaTerapia = RispostaTerapia.SelectedValue
            .RiscontroAutopico = RiscontroAutopico.SelectedValue
            .Quantiferon = Quantiferon.SelectedValue




            'modifiche 26 giugno

            .Rifampicin = Rifampicina.SelectedValue
            .Isoniazide = Isoniazide.SelectedValue
            .Pirazinamide = Pirazinamide.SelectedValue
            .Etambutolo = Etambutolo.SelectedValue

            .Altro1 = altro1.Text
            .Altro1Inizio = altro1Inizio.Text
            .Altro1Fine = altro1Fine.Text
            .Altro2 = altro2.Text
            .Altro2Inizio = altro2Inizio.Text
            .Altro2Fine = altro2Fine.Text
            .Altro3 = altro3.Text
            .Altro3Inizio = altro3Fine.Text
            .Altro3Fine = altro3Fine.Text

            .Altro4 = altro4.Text
            .Altro4Inizio = altro4Inizio.Text
            .Altro4Fine = altro4Fine.Text

        End With
        Return localtable
    End Function
    Private Sub Salva()
        Try
            _mobjTbc.username = _CUSer
            If _modifica = False Then
                _mobjTbc.username = _CUSer
                _mobjTbc.AddTbc(impostaEntity)
            Else
                _mobjTbc.UpdateTbc(impostaEntity)
            End If
            Response.Redirect("Riepilogo.aspx?tab=extra", True)
        Catch ex As Exception
            lblErrore.Visible = True
            lblErrore.Text = ex.ToString
            btn.Enabled = False
        End Try
    End Sub
    Protected Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn.Click
        Salva()

    End Sub
    Private Sub CheckExtraPolmonare()
        If SedeExtraPolmonare.Checked = False Then
            Localizzazione1.Enabled = False
            Localizzazione2.Enabled = False
        Else
            Localizzazione1.Enabled = True
            Localizzazione2.Enabled = True
        End If
    End Sub
    Private Sub CheckDisseminata()
        If Disseminata.SelectedValue = "miliare" Then
            Miliare.Checked = True
        End If    
    End Sub

    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("Riepilogo.aspx?tab=extra", True)
    End Sub
End Class
