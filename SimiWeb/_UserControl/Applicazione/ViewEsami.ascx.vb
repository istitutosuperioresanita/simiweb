Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_ViewEsami
    Inherits System.Web.UI.UserControl
    Private _idNotifica As Integer
    Private _idEsame As Integer
    Private _modifica As Boolean = False
    Private _abilitaModifiche As Boolean = False
    Private _mobjNotifica As New BllNotifica
    Private _mobjEsami As New BllEsami
    Public Property IdNotifica() As Integer
        Get
            Return _idNotifica
        End Get
        Set(ByVal value As Integer)
            _idNotifica = value
        End Set
    End Property
    Public Property AbilitaModifiche() As Boolean
        Get
            Return _abilitaModifiche
        End Get
        Set(ByVal value As Boolean)
            _abilitaModifiche = value
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
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_abilitaModifiche", _abilitaModifiche)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idNotifica = CInt(ViewState("_idNotifica"))
        _abilitaModifiche = CBool(ViewState("_abilitaModifiche"))
    End Sub
    Public Sub bind()
        lstEsami.DataSource = _mobjNotifica.GetEsamiList(_idNotifica)
        lstEsami.DataBind()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            bind()

        Else
        End If
    End Sub

    Protected Sub lstEsami_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstEsami.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        _idEsame = lstEsami.DataKeys(dataItem.DisplayIndex).Value

        If e.CommandName = "elimina" Then
            Try
                _mobjNotifica.DeleteEsame(_idEsame) '
                bind()

            Catch ex As Exception

            End Try

        End If
    End Sub


    Protected Sub lstEsami_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lstEsami.ItemDataBound
        Dim imgDelete As ImageButton = e.Item.FindControl("imgDelete")

        imgDelete.Attributes("onclick") = "javascript:return confirm('Attenzione il record verrà eliminato, proseguire ?');"
        If _abilitaModifiche = False Then
            imgDelete.Visible = False
        Else
            imgDelete.Visible = True
        End If

        Dim imgUpdate As ImageButton = e.Item.FindControl("imgUpdate")
        imgUpdate.Attributes("onclick") = "javascript:alert('Modifica non implementata');"
        If _abilitaModifiche = False Then
            imgUpdate.Visible = False
        Else
            imgUpdate.Visible = True
        End If
    End Sub

End Class
