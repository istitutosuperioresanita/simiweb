Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Admin_Tabelle_Malattie_Edit
    Inherits System.Web.UI.Page
    Private _idMalattia As Integer
    Private _idCriterio As Integer
    Private _idClassificazione As Integer
    Private _mobjMalattia As New BllMalattie
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_idCriterio", _idCriterio)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idMalattia = CInt(ViewState("_idMalattia"))
        _idCriterio = CInt(ViewState("_idCriterio"))
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idMalattia = Session("Admin_malattia_id")
            impostaJavascript()
            ImpostaCampi()

        End If
    End Sub
    Private Sub ImpostaCampi()
        CaricaMalattia()
        caricaCriteri()
        caricaClassificazione()
    End Sub
    Private Sub impostaJavascript()
        Me.Epidemiologico_help.Attributes("onblur") = "CheckEpidemiologico();"
        Me.Laboratorio_help.Attributes("onblur") = "CheckLaboratorio();"
        Me.Clinico_help.Attributes("onblur") = "CheckClinico();"


        Me.epidemiologico.Attributes("onclick") = "CheckEpidemiologico();"
        Me.laboratorio.Attributes("onclick") = "CheckLaboratorio();"
        Me.clinico.Attributes("onclick") = "CheckClinico();"
    End Sub
    Private Sub CaricaMalattia()

        Try

            Dim Malattia As Malattia = _mobjMalattia.GetMalattia(_idMalattia)

            With Malattia
                DescrizioneBreve.Text = .DescrizioneBreve
                Descrizione.Text = .Descrizione
                icd9.Text = .icd9
                icd10.Text = .icd10
                CodiceMinistero.Text = .CodiceMinistero
                AliasDescrizione.Text = .Alias
                exClasse.SelectedValue = .ExClasse
                Help.Text = .HelpCompilazione
                PrevistoFocolaio.SelectedValue = .PrevistoFocolaio
                '  PrevistiEsami.SelectedValue = .PrevistiEsami
                'PrevistoMib.SelectedValue = .ModuloMib
                'PrevistoTbc.SelectedValue = .ModuloTbc
                valida.SelectedValue = .valida
                PrevistoFocolaio.SelectedValue = .PrevistoFocolaio
                PrevistoMib.SelectedValue = .ModuloMib
                PrevistoMibTipizzazioni.SelectedValue = .ModuloMibTipizzazione
                PrevistoTbc.SelectedValue = .ModuloTbc
                modificabile.SelectedValue = .modificabile
                visualizzabile.SelectedValue = .visualizzabile
                gruppo.SelectedValue = .gruppo
                obbligtori.SelectedValue = .obbligatoriExtra
            End With
        Catch ex As Exception
            EsitoOperazione.Text = ex.ToString
        End Try

    End Sub
    Private Sub caricaCriteri()

        Try

            Dim criterio As Malattie_Criteri = _mobjMalattia.GetCriteri(_idMalattia)
            With criterio
                _idCriterio = .id
                Epidemiologico_help.Text = .Epidemilogico_Help
                Clinico_help.Text = .Clinico_help
                Laboratorio_help.Text = .Laboratorio_help
                clinico.Checked = Helper.ConvertIntToBoolean(.Clinico)
                epidemiologico.Checked = Helper.ConvertIntToBoolean(.Epidemilogico)
                laboratorio.Checked = Helper.ConvertIntToBoolean(.Laboratorio)

            End With
        Catch ex As Exception
            EsitoOperazione.Text = ex.ToString
        End Try

    End Sub
    Private Sub caricaClassificazione()

        Try

            Dim classificazione As List(Of Malattie_Classificazione_Caso) = _mobjMalattia.retrieveClassification(_idMalattia)
            For Each cla As Malattie_Classificazione_Caso In classificazione
                With cla

                    Select Case cla.Tipo
                        Case "possibile"
                            PossibileClinico.Checked = Helper.ConvertStringToBoolean(.Clinico)
                            PossibileLaboratorio.Checked = Helper.ConvertStringToBoolean(.Laboratorio)
                            PossibileEpidemiologico.Checked = Helper.ConvertStringToBoolean(.Epidemiologico)
                            idClassificazionePossibile.Text = .id
                        Case "probabile"
                            ProbabileClinico.Checked = Helper.ConvertStringToBoolean(.Clinico)
                            ProbabileLaboratorio.Checked = Helper.ConvertStringToBoolean(.Laboratorio)
                            ProbabileEpidemiologico.Checked = Helper.ConvertStringToBoolean(.Epidemiologico)
                            idClassificazioneProbabile.Text = .id
                        Case "confermato"
                            ConfermatoClinico.Checked = Helper.ConvertStringToBoolean(.Clinico)
                            ConfermatoLaboratorio.Checked = Helper.ConvertStringToBoolean(.Laboratorio)
                            ConfermatoEpidemiologico.Checked = Helper.ConvertStringToBoolean(.Epidemiologico)
                            idClassificazioneConfermato.Text = .id

                            Classificazione_help.Text = .Help
                    End Select
                End With
            Next
        Catch ex As Exception
            EsitoOperazione.Text = ex.ToString
        End Try

    End Sub

    Private Sub SalvaCriterio()

        Try

            Dim criterio As New Malattie_Criteri
            With criterio
                .id = _idCriterio
                .idMalattia = _idMalattia
                .Clinico = Helper.ConvertBooleanToInt(clinico.Checked)
                .Laboratorio = Helper.ConvertBooleanToInt(laboratorio.Checked)
                .Epidemilogico = Helper.ConvertBooleanToInt(epidemiologico.Checked)
                .Clinico_help = Clinico_help.Text
                .Laboratorio_help = Laboratorio_help.Text
                .Epidemilogico_Help = HttpUtility.HtmlDecode(Epidemiologico_help.Text)

            End With
            _mobjMalattia.UpdateCriterio(criterio)
            caricaCriteri()
            EsitoOperazione.Visible = True
            EsitoOperazione.Text = "Criteri salvati correttamente"
        Catch ex As Exception
            EsitoOperazione.Visible = True
            EsitoOperazione.Text = ex.ToString
        End Try


    End Sub
    Private Sub salvaClassifcazione(ByVal tipo As String)
        Try

            Dim classificazione As New Malattie_Classificazione_Caso

            With classificazione

                Select Case tipo
                    Case "possibile"
                        .Clinico = Helper.ConvertBooleanToString(PossibileClinico.Checked)
                        .Laboratorio = Helper.ConvertBooleanToString(PossibileLaboratorio.Checked)
                        .Epidemiologico = Helper.ConvertBooleanToString(PossibileEpidemiologico.Checked)
                        .Tipo = "possibile"
                        .ordine = 1
                        .id = idClassificazionePossibile.Text
                        .idMalattia = _idMalattia

                    Case "probabile"
                        .Clinico = Helper.ConvertBooleanToString(ProbabileClinico.Checked)
                        .Laboratorio = Helper.ConvertBooleanToString(ProbabileLaboratorio.Checked)
                        .Epidemiologico = Helper.ConvertBooleanToString(ProbabileEpidemiologico.Checked)
                        .Tipo = "probabile"
                        .ordine = 2
                        .id = idClassificazioneProbabile.Text
                        .idMalattia = _idMalattia
                    Case "confermato"
                        .Clinico = Helper.ConvertBooleanToString(ConfermatoClinico.Checked)
                        .Laboratorio = Helper.ConvertBooleanToString(ConfermatoLaboratorio.Checked)
                        .Epidemiologico = Helper.ConvertBooleanToString(ConfermatoEpidemiologico.Checked)
                        .Tipo = "confermato"
                        .ordine = 3
                        .id = idClassificazioneConfermato.Text
                        .idMalattia = _idMalattia
                End Select

                .Help = HttpUtility.HtmlDecode(Classificazione_help.Text)
            End With


            _mobjMalattia.UpdateClassificazione(classificazione)
            EsitoOperazione.Visible = True
            EsitoOperazione.Text = "criterio aggiornato con successo"
        Catch ex As Exception
            EsitoOperazione.Text = ex.ToString
        End Try

    End Sub
    Private Function impostaEntity() As Malattia
        Dim malattia As New Malattia

        With malattia
            If _idMalattia <> 0 Then
                .id_malattia = _idMalattia
            End If
            .Alias = AliasDescrizione.Text
            .CodiceMinistero = CodiceMinistero.Text
            .Descrizione = Descrizione.Text
            .DescrizioneBreve = DescrizioneBreve.Text
            .ExClasse = exClasse.SelectedValue
            .gruppo = gruppo.SelectedValue
            .HelpCompilazione = Help.Text
            .icd10 = icd10.Text
            .icd9 = icd9.Text
            .modificabile = modificabile.SelectedValue
            .ModuloMib = PrevistoMib.SelectedValue
            .ModuloMibTipizzazione = PrevistoMibTipizzazioni.SelectedValue
            .ModuloTbc = PrevistoTbc.SelectedValue
            .PrevistiEsami = "no"
            .PrevistoFocolaio = PrevistoFocolaio.SelectedValue
            .valida = valida.SelectedValue
            .visualizzabile = visualizzabile.SelectedValue
            .obbligatoriExtra = obbligtori.SelectedValue
        End With

        Return malattia

    End Function

    Protected Sub btnAggiornaConfermato_Click(sender As Object, e As System.EventArgs) Handles btnAggiornaConfermato.Click
        salvaClassifcazione("confermato")
    End Sub

    Protected Sub btnAggiornaPossibile_Click(sender As Object, e As System.EventArgs) Handles btnAggiornaPossibile.Click
        salvaClassifcazione("possibile")
    End Sub

    Protected Sub btnAggiornaProbabile_Click(sender As Object, e As System.EventArgs) Handles btnAggiornaProbabile.Click
        salvaClassifcazione("probabile")
    End Sub

    Protected Sub btnSalvaCriteri_Click(sender As Object, e As System.EventArgs) Handles btnSalvaCriteri.Click
        SalvaCriterio()
    End Sub

    Protected Sub btnSalvaMalattia_Click(sender As Object, e As System.EventArgs) Handles btnSalvaMalattia.Click
        If _idMalattia <> 0 Then
            _mobjMalattia.Update(impostaEntity)
        Else
            _mobjMalattia.Add(impostaEntity)
        End If
    End Sub
End Class
