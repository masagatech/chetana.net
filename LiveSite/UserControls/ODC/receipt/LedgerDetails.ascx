<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LedgerDetails.ascx.cs"
    Inherits="UserControls_ODC_receipt_LedgerDetails" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" /> 
        Invoice Details<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<style type="text/css">
    .submitbtn
    {
        height: 26px;
    }
    .inp-form
    {
        margin-left: 0px;
    }
</style>
<%--<div style="float: left; width: 71%">
    <asp:Button ID="btnPrint"  OnClick="btnPrint_Click"
               runat="server" Text="Print" Style="float: right;" 
                                                ToolTip="click to print" />
</div>--%>
<%--<asp:Panel ID="pnlfilter" runat="server">
    <div id="filter" runat="server" style="width: 61%; clear: both; float: right;">
        <span>Filter Data:</span>
        <input name="filt" id="find" onkeyup="filter(this, 'sf', '<%=gvLedger.ClientID%>')"
            type="text" />
        <asp:Label ID="lblmsg" runat="server" Text=" "></asp:Label>
    </div>
</asp:Panel>--%>
<%--<asp:Panel ID="Panel1" runat="server">
   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtcustomer" onfocus="setfocus('customer');" autocomplete="off"
                            Width="120px" CssClass="inp-form" TabIndex="7" runat="server" AutoPostBack="true"  ></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                            UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                            ValidationGroup="S" ControlToValidate="txtcustomer">.</asp:RequiredFieldValidator>
                        <asp:Label ID="Label4" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                            runat="server"></asp:Label></ContentTemplate>
                </asp:UpdatePanel>
</asp:Panel>--%>

<asp:Panel ID="pnlfalse" runat="server" CssClass="panelDetails" Width="743px" Height="30px">
    <table style="width: 700px">
        <tr>
            <td width="50px">
                <asp:Label ID="lblcust" runat="server" CssClass="lbl-form" Text="Client"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtcustomerid" onfocus="setfocus('customer');" autocomplete="off"
                    Width="130px" CssClass="inp-form" TabIndex="1" runat="server" 
                    OnTextChanged="txtcustomerid_TextChanged"></asp:TextBox>
                <div id="dvcust" class="divauto">
                </div>
                <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomerid"
                    UseContextKey="true" ContextKey="customer" CompletionListElementID="dvcust">
                </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RFVCust" runat="server" ErrorMessage="Require Customer Code"
                    ValidationGroup="S" ControlToValidate="txtcustomerid">.</asp:RequiredFieldValidator>
                <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                    runat="server"></asp:Label>
            </td>
              <td>
                <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate"
                    Format="dd/MM/yyyy" />
               <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rqffdt1" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="pdateft" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
               <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="pdateft" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnGetData" TabIndex="4" runat="server" Text="Get Details" OnClick="btnGetData_Click" />
            </td>
            <%--<td colspan="4">
                <asp:TextBox ID="txtcustomerid" AutoPostBack="true" CssClass="inp-form" TabIndex="3"
                    Width="160px" runat="server" Height="15px" OnTextChanged="txtcustomerid_TextChanged"></asp:TextBox>
                <div id="Div1" class="divauto">
                </div>
                <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" DelimiterCharacters=""
                    CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                    ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                    CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomerid"
                    UseContextKey="true" ContextKey="customer" CompletionListElementID="Div1">
                </ajaxCt:AutoCompleteExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Client"
                    ValidationGroup="Discount" ControlToValidate="txtcustomerid">.</asp:RequiredFieldValidator>
                <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                    runat="server"></asp:Label>
            </td>--%>
        </tr>
       
    </table>
</asp:Panel>
<div>
    <asp:Button ID="btnPrint"  OnClick="btnPrint_Click" 
               runat="server" Text="Print" Style="float: right;" 
                                                ToolTip="click to print" />
</div><br />
<br />
<asp:Panel ID="pnlLedger" runat="server">
 <div style="float: right"> 
     <asp:Label ID="Label4" runat="server" style="font-size:12px; font-family:Times New Roman;display:none;" Text="Outstanding : " ></asp:Label>
        <asp:Label ID="lbloutstndamt" Font-Size="12px" Font-Names="Times New Roman" CssClass="inp-form"  runat="server" Text="" style="display:none"></asp:Label>
       
    </div>
    <br />
        <br />
    <asp:GridView ID="gvLedger" runat="server" AutoGenerateColumns="false" CssClass="product-table" 
    FooterStyle-BackColor="DarkKhaki" FooterStyle-Font-Bold="true"
        ShowFooter="true" ForeColor="#333333" PageSize="100" Width="700px" OnRowDataBound="gvLedger_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Date" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lbldate" runat="server" Text='<%#Eval("LedgerDate")%>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Right"   />
                <HeaderStyle Width="80px" />
                <FooterTemplate>
                    <asp:Label ID="lblTotalAmt" runat="server" Text="Total"></asp:Label>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Client Name">
                <ItemTemplate>
                    <asp:Label ID="lblcust_id" runat="server" Style="display: none" Text='<%#Eval("CustId")%>'></asp:Label>
                    <asp:Label ID="lbl_CustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="100px" />
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Opening Balance" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right" style="display:none">
                <ItemTemplate>
                    <asp:Label ID="lblopenbal" runat="server" Style="display: none" Text='<%#Eval("Openingbalance","{0:0.00}")%>' style="display:none"></asp:Label>
                    <asp:Label ID="Lbl1" runat="server" Text='<%#Eval("opbalamt")%>' style="display:none"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotalbalance" runat="server"></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice No." ItemStyle-HorizontalAlign="Left" 
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lbl_Amount"  runat="server" Text='<%#Eval("otherId")%>' ></asp:Label>
                    <%--<asp:Label ID="Label2" runat="server" Text='<%#Eval("crAmount")%>' style="display:none"></asp:Label>--%>
                </ItemTemplate>
                
               
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Invoice Amount" ItemStyle-HorizontalAlign="Right"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblche_no" Style="display: none" runat="server" Text='<%#Eval("DebitAmount","{0:0.00}")%>'></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("DrAmount")%>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotaldebitAmt" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            
           <%-- <asp:TemplateField HeaderStyle-Width="80px" HeaderText="CN Amount" ItemStyle-HorizontalAlign="Right" style="display:none"
                FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                    <asp:Label ID="lblCNAmount" runat="server" Style="display: none" Text='<%#Eval("CNAmt","{0:0.00}")%>' style="display:none"></asp:Label>
                    <asp:Label ID="Label3" runat="server" style="display:none" Text='<%#Eval("CNAmount")%>'></asp:Label>
                       <asp:Label ID="lbl_deposit" runat="server" Text='<%#Eval("FinancialYearFrom")+"-"+Eval("FinancialYearTo")%>' style="display:none"></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Label ID="lblTotalCNAmt" runat="server" Text="" style="display:none"></asp:Label>
                </FooterTemplate>
                <FooterStyle HorizontalAlign="Right" />
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>--%>
           <%-- <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Years" ItemStyle-HorizontalAlign="Right">
                <ItemTemplate>
                 
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>
    <br />
    <div >
     <asp:Label ID="Label5" runat="server" Text="Outstanding : " style="display:none"></asp:Label>
        <asp:Label ID="lblopbal1" Font-Size="12px" Font-Names="Times New Roman"  CssClass ="inp-form" runat="server" Text="" style="display:none"></asp:Label>
       <br /> <br />
      <asp:Button ID="Button1"  OnClick="btnPrint_Click"
               runat="server" Text="Print" Style="float: left;" ToolTip="click to print" /> 
    </div>
    <br />
</asp:Panel>
