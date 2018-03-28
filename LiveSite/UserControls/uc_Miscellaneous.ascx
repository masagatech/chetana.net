<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Miscellaneous.ascx.cs" Inherits="UserControls_uc_Miscellaneous" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Miscellaneous Report<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<div>
    <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Height="80px" Width="620px">
        <table>
            <tr>
                
                <td>
                    <asp:RadioButtonList ID="rdOptions" runat="server" RepeatDirection="Vertical" 
                        Height="80px" Width="730px">
                        <asp:ListItem>Customer Without Email</asp:ListItem>
                        <asp:ListItem>Customer Without Mobile</asp:ListItem>
                        <asp:ListItem>Customer With Additional discount – Eligible</asp:ListItem>
                        <asp:ListItem>Customer With Additional discount –Approved – Vs Disburse</asp:ListItem>
                    </asp:RadioButtonList>
                   
                </td>
            </tr>
            
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" CssClass="panelDetails" Width="620px" Height="45px">
            <table>
            <tr>
            <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                    
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                    
                    </td>

            
            </tr>
                <tr>
                <td>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Customer Category" Width="100px"></asp:Label>
                        <font color="red"></font>
                    </td>
            <td>
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLCC" Width="250px" DataTextField="Name"
                                            TabIndex="1" DataValueField="CMID" runat="server" AutoPostBack="true"  >
                                        </asp:DropDownList>
                                       
                                    </td>
                                    <td> <asp:Button ID="btnget" runat="server" CssClass="submitbtn" OnClick="btnget_Click"
                        TabIndex="5" Text="Get" ValidationGroup="Discount" Width="80px" /></td>
                                     
                    
                    
                   
                </tr>
            </table>
        </asp:Panel>
    <br />
    <br />
    <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
  <%--  <asp:GridView ID="grdDetails" ShowFooter="true" CssClass="product-table" runat="server"
        AutoGenerateColumns="true" OnRowDataBound="grdDetails_RowDataBound" FooterStyle-HorizontalAlign="Right">
    </asp:GridView>--%>
    
     <asp:GridView ID="grdDetails" AllowPaging="True" AutoGenerateColumns="true"
            CellPadding="4" CssClass="product-table" ForeColor="#333333" 
            PageSize="100" runat="server"
            AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="grdDetails_PageIndexChanging"
           
            OnRowCreated="grdDetails_RowCreated">
            
            <AlternatingRowStyle CssClass="alt" />
        </asp:GridView>
</div>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Discount"
    runat="server" ID="ss" />
