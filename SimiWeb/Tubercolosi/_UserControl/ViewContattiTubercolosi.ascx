<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewContattiTubercolosi.ascx.vb" Inherits="Tubercolosi__UserControl_ViewContattiTubercolos" %>
                <p  style="padding-left:550px">
                    <asp:LinkButton ID="lnkNuovo" runat="server" Text="Nuovo contatto" CssClass="funzione"></asp:LinkButton>
                </p>
                <br />  
                            <table class="yui-grid">
                        <tr>
                            <th>
                                Nome
                            </th>
                            <th> 
                                Cognome
                            </th>
                            <th>
                                Indirizzo
                            </th>
                            <th>
                                Comune
                            </th>
                            <th>
                                Provincia
                            </th>
                            <th>
                                Telefono
                            </th>
                            <th>
                                Ricontattare
                            </th>
                            <th>
                                in data
                            </th>
                            <th style="width:50px">
                            </th>      
                        </tr>
                    
                    <tr>
                        <td> 
                            Mario
                        </td>
                        <td>
                            Gialloni
                        </td>
                        <td>
                            Via Roma 13    
                        </td>
                        <td>
                            Venezia
                        </td>
                        <td>
                            Venezia    
                        </td>
                        <td>
                            53544354353
                        </td>
                        <td>
                            <label style="color:Green">Si</label>
                        </td>
                        <td>
                            13/01/2011
                        </td>
                        <td>
                        <asp:ImageButton ID="btnUpdate" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/edit.png" />
                        <asp:ImageButton ID="btnDelete" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            Anna
                        </td>
                        <td>
                            Rossi
                        </td>
                        <td>
                            Via Milano 13    
                        </td>
                        <td>
                            Venezia
                        </td>
                        <td>
                            Venezia    
                        </td>
                        <td>
                            54343222
                        </td>
                        <td>
                            <label style="color:Red">No</label>
                        </td>
                        <td>
                            15/02/2011
                        </td>
                        <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/edit.png" />
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
                        </td>
                    </tr>
                    <tr>
                        <td> 
                            Luigi
                        </td>
                        <td>
                            Blu
                        </td>
                        <td>
                            Via Ampolla 39    
                        </td>
                        <td>
                            Mestre
                        </td>
                        <td>
                            Venezia    
                        </td>
                        <td>
                            54343222
                        </td>
                        <td>
                            <label style="color:Red">No</label>
                        </td>
                        <td>
                            15/03/2011
                        </td>
                        <td>
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/edit.png" />
                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="elimina" ImageUrl="~/_Styles/All/images/delete.png" />
                        </td>
                    </tr>
               </table>

              <p>
               <asp:Image ID="img" runat="server" ImageUrl="~/_Styles/All/images/edit.png" /><label class="label" style="Width:150px">Aggiorna</label><br />
               <asp:Image ID="Image1" runat="server" ImageUrl="~/_Styles/All/images/delete.png" /><label class="label" style="Width:150px">Elimina</label><br />
                </p>