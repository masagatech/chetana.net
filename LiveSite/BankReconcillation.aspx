<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="BankReconcillation.aspx.cs" Inherits="BankReconcillation" Title="Bank Reconcillation" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Bank Book<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="564px" Height="48px">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblBank" runat="server" CssClass="lbl-form" Text="Bank"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtBank" runat="server" autocomplete="off" AutoPostBack="true" CssClass="inp-form"
                            onfocus="setfocus('Bank');" OnTextChanged="txtBank_TextChanged" TabIndex="1"
                            Width="130px"></asp:TextBox>
                        <div id="dvBank" class="divauto">
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="true"
                                ShowSummary="false" ValidationGroup="a1" />
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Bank_AutoCompleteExtender" runat="server" CompletionInterval="100"
                            CompletionListCssClass="AutoExtender" CompletionListElementID="dvBank" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="Bank"
                            DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                            ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtBank"
                            UseContextKey="true">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RFVBank" runat="server" ControlToValidate="txtBank"
                            ErrorMessage="Require Bank Code" ValidationGroup="a1">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblBankName" runat="server" CssClass="lbl-form" Font-Size="12px" ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFinancialYear" runat="server" DataTextField="TextField"
                            DataValueField="valuefield" TabIndex="2">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFinancialYear"
                            ErrorMessage="Select Year" InitialValue="0" ValidationGroup="a1"> .</asp:RequiredFieldValidator>
                        <asp:Button ID="btnget" runat="server" CssClass="submitbtn" OnClick="btnget_Click"
                            TabIndex="3" Text="Get" ValidationGroup="a1" Width="80px" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
        <asp:GridView ID="grdBankbook" runat="server" AllowPaging="false" AlternatingRowStyle-CssClass="alt"
            AutoGenerateColumns="false" CellPadding="4" CssClass="product-table" ForeColor="#333333"
            PageSize="15" Width="600px">
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="100px"
                    HeaderText="Month" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkyear" runat="server" CommandArgument='<%#Eval("iMonthNo")%>'
                            CommandName='<%#Eval("OpeningBalance","{0:0.00}")%>' OnClick="lnkyear_Click"
                            Style="display: none" Text='<%#Eval("strMonthName")%>'></asp:LinkButton>
                        <asp:Label ID="lblID" runat="server" Style="display: none" Text='<%#Eval("iMonthNo")%>'></asp:Label>
                        <asp:Label ID="lblyear" runat="server" Text='<%#Eval("strMonthName") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Debit Amt." ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lbldebit" runat="server" Text='<%#Eval("Debit","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closing Balance" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblclosebal" runat="server" Text='<%#Eval("ClosingBalance","{0:0.00}")%>'></asp:Label>
                        <asp:Label ID="lblopenbal" runat="server" Style="display: none" Text='<%#Eval("OpeningBalance")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reconciled" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkreconcile" runat="server" CommandArgument='<%#Eval("iMonthNo")%>'
                            CommandName='<%#Eval("OpeningBalance","{0:0.00}")%>' OnClick="lnkreconcile_Click"
                            Text='<%#Eval("IsReco")%>' OnClientClick="document.forms[0].target ='_blank';">
                        </asp:LinkButton>
                        <%--<asp:Label ID="lblreconcile" runat="server" Text='<%#Eval("IsReco")%>'></asp:Label>--%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Not Reconciled" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnknotreconcile" runat="server" CommandArgument='<%#Eval("iMonthNo")%>'
                            CommandName='<%#Eval("OpeningBalance","{0:0.00}")%>' OnClick="lnknotreconcile_Click"
                            Text='<%#Eval("IsnotReco")%>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                        <%--<asp:Label ID="lblnotreconcile" runat="server"  Text='<%#Eval("IsnotReco")%>'></asp:Label>--%>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" />
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle CssClass="alt" />
        </asp:GridView>
    </div>
</asp:Content>
