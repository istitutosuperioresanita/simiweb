<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Mib.ascx.vb" Inherits="_UserControl_ExtraField_Mib" %>
<fieldset >
    <legend >Specifiche</legend>
<p style="background-color:#ECE87E">
    <label class="label">quadro clinico</label>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown"></asp:DropDownList>  
<br />
    <label class="label">Metodo</label>
    <asp:DropDownList ID="metodo" runat="server" CssClass="dropdown"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="ReqMetodo" runat="server" ControlToValidate="metodo" InitialValue="" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
    <label class="label">Materiale</label>
    <asp:DropDownList ID="materiale" runat="server" CssClass="dropdown"></asp:DropDownList>
    <asp:RequiredFieldValidator ID="reqMateriale" runat="server" ControlToValidate="materiale" InitialValue="" Text="*" CssClass="alert"></asp:RequiredFieldValidator>
</p>
</fieldset>