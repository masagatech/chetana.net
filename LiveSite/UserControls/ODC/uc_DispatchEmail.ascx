<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_DispatchEmail.ascx.cs" Inherits="UserControls_ODC_uc_DispatchEmail" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <td>
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            <span runat="server" id="pageName">Get Pass Out</span><a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
        <div class="options">
        </div>
    </td>
</div>
<div style="float: left; width: 518px">
    <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
    <asp:Label ID="lblDocNo" Style="display: none;" runat="server"></asp:Label>
   
</div>
<br />
<br />
<asp:Panel ID="pnlGetForm" CssClass="panelDetails" runat="server" Width="480px">
    <table cellpadding="1" cellspacing="2">
        <tr>
            <td>
                <asp:Label ID="lblSelect" runat="server" Text="Select" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoOL" runat="server" RepeatDirection="Horizontal"
                    TabIndex="11" onselectedindexchanged="rdoOL_SelectedIndexChanged">
                    <asp:ListItem Value="O">Outstation</asp:ListItem>
                    <asp:ListItem Value="L">Local</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
                                <td style="margin-left: 80px">
                                    <asp:Label ID="Label15" runat="server" Text="Doc No" 
                                        CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDocIdEdit" ValidationGroup="get" onkeypress="return CheckNumeric(event)"
                                        runat="server" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
        <tr>
        <td align="right">
         <asp:Button ID="BtnGetDCDetails" CssClass="submitbtn" runat="server" ValidationGroup="get"
          Text="Get Details" onclick="BtnGetDCDetails_Click" />
  </td> </tr>
    </table>
    <script type="text/javascript">


    </script>
</asp:Panel>

<asp:Panel ID="pnlDetailsGridOL" runat="server" Width="480px" Visible="false">
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           

            <asp:GridView ID="gvOL" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                CellPadding="4" CssClass="product-table">
                <Columns>
                    <asp:TemplateField HeaderText="Doc No">
                        <ItemTemplate>
                            <asp:Label runat="server" Style="display: none;" ID="lblSubID" Text='<%#Eval("Doc_No") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblDcNo" Text='<%#Eval("Doc_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DC No">
                        <ItemTemplate>
                            <asp:Label ID="lblArea" runat="server" Text='<%#Eval("DC_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer Name">
                        <ItemTemplate>
                            <asp:Label runat="server" Style="display: none;" ID="lblCustid" Text='<%#Eval("CustomerName") %>'></asp:Label>
                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustomerName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email ID">
                        <ItemTemplate>
                            <asp:Label ID="lblArea" runat="server" Text='<%#Eval("EmailID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Trasporter" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTrasporter" runat="server" Text='<%#Eval("Trasporter") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="No of Parcels" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNO_OF_BUNDLES" runat="server" Text='<%#Eval("NO_OF_BUNDLES") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LR_No" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblLR_No" runat="server" Text='<%#Eval("LR_No") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LR_Date" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblLR_Date" runat="server" Text='<%#Eval("LR_Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    

                    
                    
                    
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="Save" CssClass="submitbtn" runat="server" ValidationGroup="get"
          Text="Send Mail" onclick="Save_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>



























