<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewFattoriRischio.ascx.vb" Inherits="Tubercolosi__UserControl_ViewFattoriRischio" %>
               <br />  
                            <table class="yui-grid">
                        <tr>
                            <th>
                                Rischio Medico
                            </th>
                            <th> 
                                Altri Fattori
                            </th>
                            <th style="width:50px">
                            </th>      
                        </tr>  
                    <tr>
                        <td> 
                            Silicosi
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/edit.png" />
                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
                        </td>
                    </tr>                                         
                    <tr>
                        <td> 
                            Altro
                        </td>
                        <td>
                            immigrazione
                        </td>
                        <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/edit.png" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
                        </td>
                    </tr>
                    </table>