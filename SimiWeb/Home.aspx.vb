﻿
Partial Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If User.IsInRole("admin") Then
                Response.Redirect("admin/home.aspx", True)
            End If
            ViewProfilo1.username = User.Identity.Name
            UcUltimeOperazioni1.username = User.Identity.Name
        End If
    End Sub
End Class
