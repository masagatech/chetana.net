<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="BankSummary.aspx.cs" Inherits="BankSummary" Title="Bank Book Summary" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblBank" runat="server" CssClass="lbl-form" Text="Bank"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtBank" onfocus="setfocus('Bank');" autocomplete="off" Width="130px"
                            CssClass="inp-form" TabIndex="1" runat="server" AutoPostBack="true" OnTextChanged="txtBank_TextChanged"></asp:TextBox>
                        <div id="dvBank" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Bank_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtBank"
                            UseContextKey="true" ContextKey="Bank" CompletionListElementID="dvBank">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RFVBank" runat="server" ErrorMessage="Require Bank Code"
                            ValidationGroup="a1" ControlToValidate="txtBank">.</asp:RequiredFieldValidator>
                        <asp:Label ID="lblBankName" CssClass="lbl-form" ForeColor="Blue" Font-Size="12px"
                            runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                <td></td>
                    <td>
                        <asp:DropDownList ID="ddlFinancialYear" runat="server" TabIndex="2" DataTextField="TextField"
                            DataValueField="valuefield">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Year"
                            ValidationGroup="a1" ControlToValidate="ddlFinancialYear" InitialValue="0"> .</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnget" CssClass="submitbtn" TabIndex="3" runat="server" Text="Get"
                            Width="80px" ValidationGroup="a1" OnClick="btnget_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br /><br />
        <asp:GridView ID="grdBankbook" runat="server" AutoGenerateColumns="False"
            CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="600px" PageSize="15"
            AlternatingRowStyle-CssClass="alt" 
            onselectedindexchanged="grdBankbook_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Month" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkyear" runat="server" Text='<%#Eval("strMonthName")%>' OnClick="lnkyear_Click"
                            CommandArgument='<%#Eval("iMonthNo")%>' CommandName='<%#Eval("OpeningBalance","{0:0.00}")%>'></asp:LinkButton>
                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("iMonthNo")%>' Style="display: none"></asp:Label>
                        <asp:Label ID="lblyear" runat="server" Text='<%#Eval("strMonthName") %>' Style="display: none"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Debit Amt." ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lbldebit" runat="server" Text='<%#Eval("Debit","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblCredit" runat="server" Text='<%#Eval("Credit","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Opening Balance" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblopeningbal" runat="server" Text='<%#Eval("OpeningBalance","{0:0.00}")%>' ></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Closing Balance" ItemStyle-HorizontalAlign="Right">
                    <ItemTemplate>
                        <asp:Label ID="lblclosebal" runat="server" Text='<%#Eval("ClosingBalance","{0:0.00}")%>'></asp:Label>
                        <asp:Label ID="lblopenbal" runat="server" Text='<%#Eval("OpeningBalance")%>' Style="display: none"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                
                 <asp:TemplateField HeaderText="Not Reconciled" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate><CENTER>
                            <asp:LinkButton ID="lnknotreconcile" runat="server" 
                                CommandArgument='<%#Eval("iMonthNo")%>' 
                                CommandName='<%#Eval("ClosingBalance","{0:0.00}")%>' 
                               OnClick="lnknotreconcile_Click"  Text='<%#Eval("IsnotReco")%>'></asp:LinkButton>
                            <%--<asp:Label ID="lblnotreconcile" runat="server"  Text='<%#Eval("IsnotReco")%>'></asp:Label>--%>
                        <CENTER></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                 </asp:TemplateField>
                 
                  <asp:TemplateField HeaderText="Reconciled In Same Month" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate><CENTER>
                            <asp:LinkButton ID="lnkismonthreco" runat="server" 
                                CommandArgument='<%#Eval("iMonthNo")%>' 
                                CommandName='<%#Eval("OpeningBalance","{0:0.00}")%>'
                                OnClick="lnkismonthreco_Click"
                                Text='<%#Eval("IsMonthReco")%>'></asp:LinkButton>
                                 
                            <%--<asp:Label ID="lblnotreconcile" runat="server"  Text='<%#Eval("IsnotReco")%>'></asp:Label>--%>
                        <CENTER></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Reconciled In Other Month" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate><CENTER>
                            <asp:LinkButton ID="lnkisnotmonthreco" runat="server" 
                                CommandArgument='<%#Eval("iMonthNo")%>' 
                                CommandName='<%#Eval("OpeningBalance","{0:0.00}")%>'
                                OnClick="lnkisnotmonthreco_Click"
                                Text='<%#Eval("IsNotMonthReco")%>'></asp:LinkButton>
                            <%--<asp:Label ID="lblnotreconcile" runat="server"  Text='<%#Eval("IsnotReco")%>'></asp:Label>--%>
                        <CENTER></ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                 </asp:TemplateField>
                 
                 <asp:TemplateField HeaderText="Reconciled Data" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left"
                    HeaderStyle-HorizontalAlign="Center">
                 <ItemTemplate><CENTER>
                        <asp:LinkButton ID="lnkmonth" runat="server" Text='<%#Eval("strMonthName")%>' OnClick="lnkmonth_Click"
                            CommandArgument='<%#Eval("iMonthNo")%>' CommandName='<%#Eval("OpeningBalance","{0:0.00}")%>'></asp:LinkButton>
                        <asp:Label ID="lblID1" runat="server" Text='<%#Eval("iMonthNo")%>' Style="display: none"></asp:Label>
                        <asp:Label ID="lblyear1" runat="server" Text='<%#Eval("strMonthName") %>' Style="display: none"></asp:Label>
                    </CENTER></ItemTemplate>
                        
                    <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>
                
            </Columns>
            <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
        </asp:GridView>
        <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="a1"
            runat="server" ID="ValidationSummary3" />
    </div>
</asp:Content>
