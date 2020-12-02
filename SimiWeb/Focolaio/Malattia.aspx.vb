Imports Simiweb.BusinessFacade
Imports System.Data.Linq
Partial Class Focolaio_Malattia
    Inherits System.Web.UI.Page
    Private mobjMalattie As New BllMalattie
    Private _lastValue As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Dim alphabet As String() = _
                "A;B;C;D;E;F;G;H;I;J;K;L;M;N;O;P;Q;R;S;T;U;V;W;X;Y;Z".Split(";")
            rptAlphabet.DataSource = alphabet
            rptAlphabet.DataBind()
            rptMalattie.DataSource = mobjMalattie.GetAllMalattieList(BllMalattie.tipo.focolaio)
            rptMalattie.DataBind()
        End If
        ImpostaJavascript()
    End Sub
    Protected Function AddBreak() As String
        Dim strRet As String = ""
        Dim currValue As String = Left(Eval("DescrizioneBreve"), 1).ToString
        If _lastValue <> currValue Then
            _lastValue = currValue
            strRet = "</br><label id=#" + currValue + "><b>" + currValue + "</b></label><hr>"
            Return strRet
        Else
            Return String.Empty
        End If
    End Function
    Private Sub ImpostaJavascript()
        Me.ricerca.Attributes("onkeyup") = "cerca()"
    End Sub
End Class
