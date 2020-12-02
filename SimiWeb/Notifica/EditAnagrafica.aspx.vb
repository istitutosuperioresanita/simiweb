'Imports System.Threading
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess

Partial Class Notifica_EditAnagrafica
    Inherits System.Web.UI.Page
    Private _MobjMalattia As New BllMalattie
    Private _MobjGeografiche As New BllGeografiche
    Private _MobjAccesorie As New BllAccessorie
    Private _MobjNotifica As New BllNotifica
    Private _mobjUser As New BllUser

    Private _idAnagrafica As Integer = 0
    Private _idNotifica As Integer
    Private _idMalattia As Integer = 0   
    Private _nomelbl As String = ""
    Private _cognomelbl As String = ""
    Private _cUser As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_idAnagrafica", _idAnagrafica)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idNotifica = CInt(ViewState("_idNotifica"))
        _idAnagrafica = CInt(ViewState("_idAnagrafica"))
        _idMalattia = CInt(ViewState("_idMalattia"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Expires = 0
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        If Not Page.IsPostBack Then

            Dim profilo As Utenti_Profilo = _mobjUser.GetProfiloByUsername(User.Identity.Name)
            If profilo.idRegione = "190" Then
                pnlCentroPermanenza.Visible = True
            Else
                pnlCentroPermanenza.Visible = False
            End If

            _idNotifica = Session("idNotifica")
            CaricaValoriStartUp()
            If _idNotifica <> 0 Then
                caricaEntity(_idNotifica)
            End If
            BindIntestazione()
            AddJavascript()
        Else
            _cUser = User.Identity.Name
        End If
    End Sub
    Private Sub CaricaValoriStartUp()
        'malattiaLabel.Text = _malattia
        CaricaNazioni(Nazionalita)
        CaricaProvince(ProvinciaDomicilio)
        CaricaProvince(ProvinciaResidenza)
        CaricaProvince(ProvinciaNascita)
        CaricaProfessioni(Professione)
        CaricaNazioni(NazioneResidenza)

    End Sub
    Private Sub AddJavascript()
        Me.ProvinciaResidenza.Attributes("onchange") = "getComuni('ProvinciaResidenza','ComuneResidenza');"
        Me.ProvinciaDomicilio.Attributes("onchange") = "getComuni('ProvinciaDomicilio','ComuneDomicilio');"
        Me.ProvinciaNascita.Attributes("onchange") = "getComuni('ProvinciaNascita','ComuneNascita');"
        Me.NatoEstero.Attributes("onchange") = "AbilitaEstero();"
        Me.SenzaFissaDimora.Attributes("onchange") = "AbilitaResidenza();"
        Me.DataNascita.Attributes("onblur") = "check_date(this);"
        Me.Professione.Attributes("onchange") = "checkProfessione();"
        Me.altraProfessione.Attributes("onblur") = "checkProfessione();"
        Me.arrivoItalia.Attributes("onblur") = "checkEstero();"
        Me.centroPermanenza.Attributes("onchange") = "checkPermanenza()"
    End Sub

#Region "Metodi Form"

    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        Salva()
    End Sub
    Private Sub BindIntestazione()
        Dim notificaInfo As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)
        With notificaInfo
            UcStatoSegnalazione1.malattia = .malattia
            UcStatoSegnalazione1.nome = .nome
            UcStatoSegnalazione1.cognome = .cognome
            DataPrimiSintomi.Value = Format(DateTime.Parse(.DataPrimiSintomi), "dd/MM/yyyy")
            _idMalattia = .idmalattia
        End With
    End Sub
    Private Sub caricaEntity(ByVal idNotifica As Integer)
        Try

            Dim anagrafica As Anagrafica = _MobjNotifica.GetAnagraficaByIdNotifica(idNotifica)

            With anagrafica

                _idAnagrafica = .Id
                codiceFiscale.Text = .CodiceFiscale
                ' .CodiceFiscaleNonConosciuto = "" 'codic
                '.CodiceRegionaleCriptazione = ""
                Cognome.Text = .Cognome

                ProvinciaNascita.SelectedValue = .idProvinciaNascita
                ComuneNascita.DataSource = _MobjGeografiche.GetAllComuniByIdProvinciaJson(.idProvinciaNascita)
                ComuneNascita.DataTextField = "descrizione"
                ComuneNascita.DataValueField = "codice"
                ComuneNascita.DataBind()
                ComuneNascita.SelectedValue = .IdComuneNascita
                DataNascita.Text = .DataNascita
                arrivoItalia.Text = .ArrivoItalia
                '.Eta = 0 'Eta.Text
                '.IdAslResidenza = ""
                ProvinciaDomicilio.SelectedValue = .IdProvinciaDomicilio
                ComuneDomicilio.DataSource = _MobjGeografiche.GetAllComuniByIdProvinciaJson(.IdProvinciaDomicilio)
                ComuneDomicilio.DataTextField = "descrizione"
                ComuneDomicilio.DataValueField = "codice"
                ComuneDomicilio.DataBind()
                ComuneDomicilio.SelectedValue = .IdComuneDomicilio
                indirizzoDiDomicilio.Text = .IndirizzoDomicilio

                ProvinciaResidenza.SelectedValue = .idProvinciaResidenza
                ComuneResidenza.DataSource = _MobjGeografiche.GetAllComuniByIdProvinciaJson(.idProvinciaResidenza)
                ComuneResidenza.DataTextField = "descrizione"
                ComuneResidenza.DataValueField = "codice"
                ComuneResidenza.DataBind()
                ComuneResidenza.SelectedValue = .IdComuneResidenza


                IndirizzoResidenza.Text = .IndirizzoResidenza


                Nazionalita.SelectedValue = .IdNazionalitaCittadinanza
                Professione.SelectedValue = .IdProfessione
                StranieroNonInRegola.Checked = Helper.ConvertStringToBoolean(.StranieroNonInRegola)
                Nome.Text = .Nome
                NumeroSTP.Text = .NumeroStp
                SenzaFissaDimora.Text = .SenzaFissaDimora
                sesso.SelectedValue = .Sesso
                Telefono.Text = .Telefono
                CodiceEni.Text = .CodiceEni
                '    ResidenteEstero.Text = .residenzaEstero
                NatoEstero.SelectedValue = .NatoEstero
                NazioneResidenza.SelectedValue = .IdNazioneResidenza
                dataWeb.Value = Helper.IsNullDate(.DataWeb)

                centroPermanenza.Text = .CentroPermanenza
                NomeCentroPermanenza.Text = .NomeCentroPermanenza

            End With
        Catch ex As Exception
            lblErrore.Visible = True
            lblErrore.Text = ex.ToString
        End Try

    End Sub

    Private Function impostaEntity() As Anagrafica

        Dim localdataEntity As New Anagrafica
        With localdataEntity

            .Id = _idAnagrafica
            .idNotifica = _idNotifica
            .CodiceFiscale = codiceFiscale.Text
            .CodiceFiscaleNonConosciuto = "" 'codic
            .CodiceRegionaleCriptazione = ""
            .Cognome = Cognome.Text
            .idProvinciaNascita = Request.Form("ctl00$Contenuto$ProvinciaNascita")
            .IdComuneNascita = Request.Form("ctl00$Contenuto$ComuneNascita")
            .DataNascita = DataNascita.Text
            .ArrivoItalia = arrivoItalia.Text
            .Eta = 0 'Eta.Text
            .IdProvinciaDomicilio = Request.Form("ctl00$Contenuto$ProvinciaDomicilio")
            .IdComuneDomicilio = Request.Form("ctl00$Contenuto$ComuneDomicilio")
            .IdComuneResidenza = Request.Form("ctl00$Contenuto$ComuneResidenza")
            .IdNazionalitaCittadinanza = Nazionalita.SelectedValue
            .IdProfessione = Professione.SelectedValue
            .idProvinciaResidenza = ProvinciaResidenza.SelectedValue
            .IndirizzoResidenza = IndirizzoResidenza.Text
            .IdNazioneNascita = ""
            .Nome = Nome.Text
            .NumeroStp = NumeroSTP.Text
            .NatoEstero = NatoEstero.SelectedValue
            '.StranieroNonInRegola = StranieroNonInRegola.Text
            .SenzaFissaDimora = SenzaFissaDimora.Text
            .Sesso = sesso.SelectedValue
            .Telefono = Telefono.Text
            .StranieroNonInRegola = Helper.ConvertBooleanToString(StranieroNonInRegola.Checked)
            .LastUser = _cUser
            .DataModifica = Now
            .DataWeb = Helper.ConvertEmptyDateToNothing(dataWeb.Value)
            .IndirizzoDomicilio = indirizzoDiDomicilio.Text
            .CodiceEni = CodiceEni.Text
            .IdNazioneResidenza = NazioneResidenza.SelectedValue
            '   .residenzaEstero = ResidenteEstero.Text
            '.Eta = BizClass.GetAge(DataNascita.Text, DataPrimiSintomi.Value)

            .CentroPermanenza = centroPermanenza.Text
            .NomeCentroPermanenza = NomeCentroPermanenza.Text
        End With


        Return localdataEntity
    End Function

    Private Sub Salva()

        Try
            _MobjNotifica.DataNascita = DataNascita.Text
            _MobjNotifica.DataPrimiSintomi = DataPrimiSintomi.Value
            _MobjNotifica.username = _cUser
            _MobjNotifica.record = UcStatoSegnalazione1.nome + " " + UcStatoSegnalazione1.cognome
            _MobjNotifica.UpdateAnagrafica(impostaEntity, _idMalattia)
            Response.Redirect("Riepilogo.aspx?tab=anagrafica", True)
        Catch ex As Exception
            lblErrore.Visible = True
            lblErrore.Text = ex.ToString
        End Try

    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.Form.Attributes("onsubmit") = "javascript:return CompareDate();"
    End Sub

#End Region

#Region "Sub"

    Private Sub CaricaNazioni(ByRef ctr As DropDownList)
        ctr.DataTextField = "Nazione"
        ctr.DataValueField = "IdNazione"
        ctr.DataSource = _MobjGeografiche.GetAllNazioni
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaProvince(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "IdProvincia"
        ctr.DataSource = _MobjGeografiche.GetAllProvince
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaProfessioni(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjAccesorie.GettAllProfessioniJson
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub

#End Region

    '#Region "Jquery Call"
    '    <System.Web.Services.WebMethod()> _
    '    Public Shared Function Submit() As String
    '        Dim str As New StringBuilder
    '        Return str.Append("false").ToString
    '    End Function
    '#End Region

    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("Riepilogo.aspx?tab=anagrafica", True)
    End Sub
End Class
