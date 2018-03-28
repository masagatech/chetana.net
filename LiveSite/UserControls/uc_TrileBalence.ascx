<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_TrileBalence.ascx.cs"
    Inherits="UserControls_ODC_uc_TrileBalence" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style type="text/css">
    .style1
    {
        height: 18px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Trile Balence<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<br />
<br />
<asp:GridView ID="gvTrileBlance" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
    CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="843px" PageSize="100">
    <Columns>
        <asp:TemplateField HeaderText="Particulars" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblid" runat="server" Style="display: none" Text='<%#Eval("AUTOID") %>'></asp:Label>
                <asp:Label ID="lblcode" runat="server" Style="display: none" Text='<%#Eval("AC_Code") %>'></asp:Label>
                <asp:Label ID="lblgroup" runat="server" Style="display: none" Text='<%#Eval("AC_GROUP") %>'></asp:Label>
                <asp:Label ID="lblhead" runat="server" Text='<%#Eval("GR_HEAD") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AC. NAME" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblAcName" runat="server" Text='<%#Eval("AC_NAME") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="100px">
            <ItemTemplate>
                <asp:Label ID="lblDebit" runat="server" Text='<%#Eval("Debit","{0:0.00}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
            <ItemTemplate>
                <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit","{0:0.00}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <%--  <asp:TemplateField HeaderText="Action" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="center"
            HeaderStyle-HorizontalAlign="Center">
            <ItemTemplate>
  <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CssClass="close" 
                        ImageUrl="../../Images/icon/save_as.png"/>
            </ItemTemplate>
        </asp:TemplateField>--%>
    </Columns>
</asp:GridView>
<table width="843px">
    <tr>
        <td width="560px">
            <asp:Label ID="lblGrand" style="font-family:Book Antiqua;font-size:medium"  Font-Bold="true" runat="server" Text="Grand Amount :"></asp:Label>
        </td>
        <td width="120px">
            <asp:Label ID="lblnetdebit" style="font-family:Book Antiqua;font-size:medium"  Font-Bold="true" runat="server"></asp:Label>
        </td>
        <td width="50px">
            <asp:Label ID="lblnetcredit" style="font-family:Book Antiqua;font-size:medium" Font-Bold="true" runat="server"></asp:Label>
        </td>
    </tr>
</table>
