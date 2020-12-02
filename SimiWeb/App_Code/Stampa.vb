Imports Microsoft.VisualBasic
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Helper
Imports System.IO
Imports iTextSharp.text.pdf

Public Class Stampa
    Private _mobjNotifica As New BllNotifica
    Private _mobjFocolaio As New BllFocolaio
    Public Function StampaFocolaio(ByVal _idFocolaio As Integer) As MemoryStream
        Dim pdfTemplate As String = System.Web.HttpContext.Current.Server.MapPath("~/Stampe/Focolaio_3.pdf")
        '  Dim newFile As String = Server.MapPath("~/TEmp/Focolaio.pdf")


        Dim m As New MemoryStream



        Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)
        Dim pdfStampera As PdfStamper = New PdfStamper(pdfReader, m)
        Dim pdfFormFields As AcroFields = pdfStampera.AcroFields

        pdfStampera.Writer.CloseStream = False

        Dim f As Focolaio_ViewResult = _mobjFocolaio.GetFocolaioView(_idFocolaio)


        With f

            pdfFormFields.SetField("malattia", .malattia)
            pdfFormFields.SetField("regione", .regione)
            pdfFormFields.SetField("provincia", .Provincia)
            pdfFormFields.SetField("comune", .Comune)
            pdfFormFields.SetField("comunita", .Comunita)
            pdfFormFields.SetField("numeropersone", .PersoneRischio)
            pdfFormFields.SetField("indirizzo", .Indirizzo)
            pdfFormFields.SetField("telefono", .Telefono)
            pdfFormFields.SetField("agente", .agente)
            pdfFormFields.SetField("veicolo", .Veicolo)
            pdfFormFields.SetField("datraInizio", .dataInizio)
            pdfFormFields.SetField("durata", .durata)
            pdfFormFields.SetField("numweoCasi", .NumeroCasi)
            pdfFormFields.SetField("LuogoOrigine", .LuogoOrigine)
            pdfFormFields.SetField("note", .Note)
            pdfFormFields.SetField("dataSegnalazione", .DataSegnalazione)
            pdfFormFields.SetField("dataNotifica", Helper.IsNullDate(.DataNotifica))
            pdfFormFields.SetField("aslNotifica", .AslNotifica)
            pdfFormFields.SetField("aslResidenza", "")
            pdfFormFields.SetField("segnalatore", "")

        End With

        pdfStampera.FormFlattening = True

        pdfReader.Close()
        pdfStampera.Close()
        m.Position = 0
        Return m

    End Function
    Public Function StampaNotifica(ByVal _idNotifica As Integer, Optional ByVal Privacy As Boolean = False) As MemoryStream
        Dim pdfTemplate As String = System.Web.HttpContext.Current.Server.MapPath("~/Stampe/Notifica_3.pdf")
        '  Dim newFile As String = Server.MapPath("~/TEmp/Focolaio.pdf")


        Dim m As New MemoryStream



        Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)
        Dim pdfStampera As PdfStamper = New PdfStamper(pdfReader, m)
        Dim pdfFormFields As AcroFields = pdfStampera.AcroFields

        pdfStampera.Writer.CloseStream = False

        Dim c As Clinica_ViewResult = _mobjNotifica.GetClinicaView(_idNotifica)
        Dim a As Anagrafica_ViewResult = _mobjNotifica.GetAnagraficaView(_idNotifica)
        Dim n As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)


        If Privacy = False Then


            pdfFormFields.SetField("nome", a.Nome)
            pdfFormFields.SetField("cognome", a.Cognome)
            pdfFormFields.SetField("indirizzoresidenza", a.IndirizzoResidenza)
            pdfFormFields.SetField("telefono", a.Telefono)
            pdfFormFields.SetField("codicefiscale", a.CodiceFiscale)
        Else

            pdfFormFields.SetField("nome", "xxxxxxxxxxx")
            pdfFormFields.SetField("cognome", "xxxxxxxxxxx")
            pdfFormFields.SetField("indirizzoresidenza", "xxxxxxxxxx")
            pdfFormFields.SetField("telefono", "xxxxxxxxxx")
            pdfFormFields.SetField("codicefiscale", "xxxxxxxxxxxxxxxxx")
        End If

        pdfFormFields.SetField("malattia1", n.malattia)
        pdfFormFields.SetField("malattia2", n.malattia)
        pdfFormFields.SetField("malattia3", n.malattia)

        pdfFormFields.SetField("identifcativo1", a.idNotifica)
        pdfFormFields.SetField("identificativo2", a.idNotifica)
        pdfFormFields.SetField("identifcativo3", a.idNotifica)
        pdfFormFields.SetField("datasegnalazione", n.DataSegnalazione)
        'pdfFormFields.SetField("cognome", a.Cognome)
        pdfFormFields.SetField("estero", a.NatoEstero)
        pdfFormFields.SetField("dataarrivo", "") 'aggiungere data arrivo italia
        pdfFormFields.SetField("povincianascita", a.Provincia_nascita)
        pdfFormFields.SetField("luogonascita", a.Comune_Nascita)
        pdfFormFields.SetField("datanascita", Helper.IsNullDate(a.DataNascita))
        pdfFormFields.SetField("nazionalita", a.Nazionalita)
        'pdfFormFields.SetField("codicefiscale", a.CodiceFiscale)
        pdfFormFields.SetField("straniero", a.StranieroNonInRegola)
        pdfFormFields.SetField("professione", a.Professione)
        pdfFormFields.SetField("senzafissadimora", a.SenzaFissaDimora)
        pdfFormFields.SetField("provinciaresidenza", a.Provincia_Residenza)
        pdfFormFields.SetField("comuneresidenza", a.Comune_Residenza)
        'pdfFormFields.SetField("indirizzoresidenza", a.IndirizzoResidenza)
        pdfFormFields.SetField("provinciadomicilio", a.Provincia_Domicilio)
        pdfFormFields.SetField("comunedomicilio", a.Comune_domicilio)
        '            pdfFormFields.SetField("telefono", a.Telefono)
        pdfFormFields.SetField("sesso", a.Sesso)
        'pdfFormFields.SetField("nome", a.Nome)
        pdfFormFields.SetField("datanotifica", Helper.IsNullDate(n.DataNotifica))
        pdfFormFields.SetField("aslresidenza", n.AslRes)
        pdfFormFields.SetField("aslnotifica", n.AslNotifica)
        pdfFormFields.SetField("segnalatore", n.ReferenteUlss)
        pdfFormFields.SetField("datasegnalazione1", Helper.IsNullDate(n.DataSegnalazione))
        pdfFormFields.SetField("datanotifica1", Helper.IsNullDate(n.DataNotifica))
        pdfFormFields.SetField("aslnotifica1", n.AslNotifica)
        pdfFormFields.SetField("aslresdienza1", n.AslRes)
        pdfFormFields.SetField("segnlatore1", n.ReferenteUlss)
        pdfFormFields.SetField("clinico", c.CriterioClinico)
        pdfFormFields.SetField("epidemiologico", c.CriterioEpidemiologico)
        pdfFormFields.SetField("laboratorio", c.CriterioLaboratorio)
        pdfFormFields.SetField("datasintomi", c.DataPrimiSintomi)
        pdfFormFields.SetField("nazionesintomi", c.nazionePrimiSintomi)
        pdfFormFields.SetField("provinciasintomi", c.provinciaSintomi)
        pdfFormFields.SetField("comunesintomi", c.comuneSintomi)
        pdfFormFields.SetField("vaccinato", c.StatoVaccinale)
        pdfFormFields.SetField("dosevaccino", "")
        pdfFormFields.SetField("dataultimadose", Helper.IsNullDate(c.DataDoseUltimoVaccino))
        pdfFormFields.SetField("ricovero", c.RicoveroOspedaliero)
        pdfFormFields.SetField("ricoveroluogo", c.LuogoRicovero)
        pdfFormFields.SetField("reparto", c.Reparto)
        pdfFormFields.SetField("motivo", c.MotivoDelRicovero)
        pdfFormFields.SetField("dataricovero", Helper.IsNullDate(c.DataRicovero))
        pdfFormFields.SetField("datadimisione", Helper.IsNullDate(c.DataDimissione))
        pdfFormFields.SetField("ricerca1", c.ricerca1)
        pdfFormFields.SetField("dataesame1", Helper.IsNullDate(c.dataesame1))
        pdfFormFields.SetField("luogoesame1", c.luogo1)
        pdfFormFields.SetField("risultatoesame1", c.luogo2)
        pdfFormFields.SetField("ricerca2", c.ricerca2)
        pdfFormFields.SetField("dataesame2", Helper.IsNullDate(c.dataesame2))
        pdfFormFields.SetField("risultatoesame2", c.risultato2)
        pdfFormFields.SetField("luogoesame2", c.luogo2)
        pdfFormFields.SetField("viaggi", c.ViaggioFuoriResidenza)
        pdfFormFields.SetField("nazione1", c.nazione1)
        pdfFormFields.SetField("nazione2", c.nazione2)
        pdfFormFields.SetField("nazione3", c.nazione3)
        pdfFormFields.SetField("nazione1Periodo", c.nazione1Periodo)
        pdfFormFields.SetField("nazione2Periodo", c.nazione2Periodo)
        pdfFormFields.SetField("nazione3Periodo", c.nazione3Periodo)
        pdfFormFields.SetField("nazionecontagio", c.nazioneContagio)
        pdfFormFields.SetField("provinciacontagio", c.provinciaContagio)
        pdfFormFields.SetField("comunecontagio", c.comuneContagio)
        pdfFormFields.SetField("contattistretti", c.ContattiStretti)
        pdfFormFields.SetField("collettivita", c.comunita)
        pdfFormFields.SetField("altrecollettivita", c.AltraColletivita)
        pdfFormFields.SetField("note", c.Note)
        pdfFormFields.SetField("datasegnalazione2", Helper.IsNullDate(n.DataSegnalazione))
        pdfFormFields.SetField("datanotifica2", Helper.IsNullDate(n.DataNotifica))
        pdfFormFields.SetField("aslresdienza2", n.AslRes)
        pdfFormFields.SetField("aslnotifica2", n.AslNotifica)
        pdfFormFields.SetField("segnalatore2", n.ReferenteUlss)


        pdfStampera.FormFlattening = True

        pdfReader.Close()
        pdfStampera.Close()
        m.Position = 0
        Return m

    End Function
End Class
