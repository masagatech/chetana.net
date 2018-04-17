<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SupplierBill_View.ascx.cs" Inherits="UserControls_uc_SupplierBill_View" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Supplier Bill<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<br />
<br />
<asp:Panel ID="pnlViewSupllierBill" CssClass="panelDetails" runat="server" Style="width: auto; height: auto;">
    <div class="float-right">
        <asp:Button ID="btnAdd" CssClass="submitbtn" runat="server" Text="Add" TabIndex="9" Width="80px" OnClick="btnAdd_Click" />
    </div>
</asp:Panel>


<div class="m-30">
    <asp:GridView ID="gvSupplierBill" runat="server" AutoGenerateColumns="false" CssClass="product-table">
        <Columns>
            <asp:TemplateField HeaderText="Account Name">
                <ItemTemplate>
                    <asp:Label ID="lblSBillID" runat="server" Text='<%#Eval("SBillID") %>' CssClass="hide"></asp:Label>
                    <asp:Label ID="lblSupplierCode" runat="server" Text='<%#Eval("SupplierCode") %>' CssClass="hide"></asp:Label>
                    <asp:Label ID="lblSupplierName" runat="server" Text='<%#Eval("SupplierName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Purchase Name">
                <ItemTemplate>
                    <asp:Label ID="lblPurchaseCode" runat="server" Text='<%#Eval("PurchaseCode") %>' CssClass="hide"></asp:Label>
                    <asp:Label ID="lblPurchaseName" runat="server" Text='<%#Eval("PurchaseName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Invoice No" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Invoice Date">
                <ItemTemplate>
                    <asp:Label ID="lblInvoiceDate" runat="server" Text='<%#Eval("InvoiceDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GST Percent" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblGSTPer" runat="server" Text='<%#Eval("GSTPer") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="GST Amount" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblGSTAmount" runat="server" Text='<%#Eval("GSTAmount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Grand Total" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblGrandTotal" runat="server" Text='<%#Eval("GrandTotal") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="submitbtn" Width="80px" CausesValidation="false"
                        OnClick="btnEdit_Click" TabIndex="10" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

<div class="m-30 hide">
    <asp:GridView ID="gvSupplierBillDetails" runat="server" AutoGenerateColumns="false" CssClass="product-table">
        <Columns>
            <asp:TemplateField HeaderText="Account Name">
                <ItemTemplate>
                    <asp:Label ID="lblSBillDID" runat="server" Text='<%#Eval("SBillDID") %>' CssClass="hide"></asp:Label>
                    <asp:Label ID="lblAccountCode" runat="server" Text='<%#Eval("AccountCode") %>' CssClass="hide"></asp:Label>
                    <asp:Label ID="lblAccountName" runat="server" Text='<%#Eval("AccountName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remark">
                <ItemTemplate>
                    <asp:Label ID="lblRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
