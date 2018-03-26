<%@ Page Title="Import Customer" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CustomerImport.aspx.cs" Inherits="CustomerImport" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Import Customer<a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
        <asp:Panel ID="pnlra" runat="server">
            <div style="float: right; width: 58%">
                <div id="filter" runat="server">
                </div>
            </div>
        </asp:Panel>
        <div class="options">
        </div>
    </div>
    <asp:Panel ID="pnDetails" runat="server" DefaultButton="btnView" CssClass="panelDetails" Height="24px" Width="390px">
        <table>
            <tr>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnView" runat="server"  CssClass="submitbtn" style="width: 60px;" Text="View" OnClick="btnView_Click" />
                &nbsp;
                <asp:Button ID="btnUpload" runat="server"  CssClass="submitbtn" style="width: 60px;" Text="Upload" Visible="false" OnClick="btnUpload_Click" />
            </tr>
        </table>
    </asp:Panel>
     <asp:Panel ID="grdpanl" runat="server">
            <asp:GridView ID="grdImportCust" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="8" Width="428px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="Cust Code" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("Code")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Split DC" HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblsplitdc" runat="server" Text='<%#Eval("IsSplit")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="20px" />
                        <ItemStyle HorizontalAlign="left" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="alt" />
            </asp:GridView>
        </asp:Panel>
</asp:Content>

