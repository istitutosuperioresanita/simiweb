<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ViewControlliTubercolosi.ascx.vb" Inherits="Tubercolosi__UserControl_ViewControlliTubercolosi" %>
                <p  style="padding-left:550px">
                    <asp:LinkButton ID="lnkNuovo" runat="server" Text="Nuovo controllo" CssClass="funzione"></asp:LinkButton>
                </p>
                <table class="yui-grid">
                        <tr>
                            <td colspan="3" class="intestazioneColonne"><b>Data Controllo: 14/02/2011</b></td>
                            <td colspan="3" class="intestazioneColonne">&nbsp;</td>
                            <td style="width:40px" class="intestazioneColonne">
                                <asp:ImageButton ID="ImageButton5" runat="server" CommandName="dettaglio" ImageUrl="~/_Styles/All/images/edit.png"  />
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="dettaglio" ImageUrl="~/_Styles/All/images/delete.png"  />
                            </td>      
                        </tr>                    
                    <tr>
                        <td colspan="3"> 
                              Effettuato : SI
                        </td>
                            <td colspan="3" align="center" >
                                <b>ESAMI RICHIESTI</b>
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                        <td>diretto bk: <label style="color:Red">No</label>
                        </td>
                        <td>
                            Rx Standard:<label style="color:Green">Si</label>
                        </td>
                        <td>
                            Stratigrafia:<label style="color:Red">No</label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                            <td>colturale:<label style="color:Red">No</label>
                            </td>
                            <td>
                                audiometria:<label style="color:Red">No</label>
                            </td>
                            <td>
                                mantoux:<label style="color:Red">No</label>
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                            <td>emocromo:<label style="color:Red">No</label>
                            </td>
                            <td>
                                campo visivo:<label style="color:Green">Si</label>
                            </td>
                            <td>
                                broncoscopia:<label style="color:Red">No</label>
                            </td>
                            <td>&nbsp;</td>
                    
                    </tr>
                        <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                            <td>funz. epatica:<label style="color:Red">No</label>
                            </td>
                            <td>
                                TAC: <label style="color:Red">No</label>
                            </td>
                            <td>
                                Antibiogramma:<label style="color:Red">No</label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3" class="intestazioneColonne"><b>Data Controllo: 21/03/2011</b></td>
                            <td colspan="3" class="intestazioneColonne">&nbsp;</td>
                            <td style="width:40px" class="intestazioneColonne">
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="dettaglio" ImageUrl="~/_Styles/All/images/edit.png"  />
                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="dettaglio" ImageUrl="~/_Styles/All/images/delete.png"  />
                            </td>      
                        </tr>                    
                    <tr>
                        <td colspan="3"> 
                                Effettuato : No
                        </td>
                            <td colspan="3" align="center" >
                                <b>ESAMI RICHIESTI</b>
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                        <td>diretto bk: <label style="color:Red">No</label>
                        </td>
                        <td>
                            Rx Standard:<label style="color:Green">Si</label>
                        </td>
                        <td>
                            Stratigrafia:<label style="color:Green">Si</label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                            <td>colturale:<label style="color:Red">No</label>
                            </td>
                            <td>
                                audiometria:<label style="color:Red">No</label>
                            </td>
                            <td>
                                mantoux:<label style="color:Red">No</label>
                            </td>
                            <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                            <td>emocromo:<label style="color:Red">No</label>
                            </td>
                            <td>
                                campo visivo:<label style="color:Red">No</label>
                            </td>
                            <td>
                                broncoscopia:<label style="color:Red">No</label>
                            </td>
                            <td>&nbsp;</td>
                    
                    </tr>
                        <tr>
                        <td colspan="3"> 
                                &nbsp;
                        </td>
                            <td>funz. epatica:<label style="color:Red">No</label>
                            </td>
                            <td>
                                TAC: <label style="color:Red">No</label>
                            </td>
                            <td>
                                Antibiogramma:<label style="color:Red">No</label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
               </table>
              <p>
               <asp:Image ID="img" runat="server" ImageUrl="~/_Styles/All/images/edit.png" /><label class="label" style="Width:150px">Aggiorna</label><br />
               <asp:Image ID="Image1" runat="server" ImageUrl="~/_Styles/All/images/delete.png" /><label class="label" style="Width:150px">Elimina</label><br />
                </p>