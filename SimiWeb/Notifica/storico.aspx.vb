Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_storico
    Inherits System.Web.UI.Page
    Private _mobjAuditing As New DalAudit
    Private _idNotifica As Integer


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        _idNotifica = Session("idNotifica")

        LstAnagrafica.DataSource = _mobjAuditing.GetHistoryAnagraficaByIdNotifica(_idNotifica)
        LstAnagrafica.DataBind()

        lstClinica.DataSource = _mobjAuditing.GetHistoryClinicaByIdNotifica(_idNotifica)
        lstClinica.DataBind()

    End Sub

End Class
