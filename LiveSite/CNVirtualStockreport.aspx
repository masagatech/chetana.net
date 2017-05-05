<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CNVirtualStockreport.aspx.cs" Inherits="LiveSite_CNVirtualStockreport" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-header" style="display: block">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        <span runat="server" id="pageName"></span>CN Virtual Stock Report <a href="Campaigns.aspx"
            title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
                <span>Filter Data:</span>
               <%-- <input name="filt" onkeyup="filter(this, 'sf', '<%=Grdvirtualstockreport.ClientID%>')"
                    type="text">--%>
            </div>
        </div>
    </asp:Panel>
</div>
    <table width="100%">
    <tr>
        <td align="right">
            <asp:Label runat="server" ID="Label1" Text="Total Virtual Stock" CssClass="inp-form"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label runat="server" ID="lblTotalBooksInGodown" CssClass="product-table"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnExport" CssClass="submitbtn" runat="server" Text="Export" Width="80px"
                TabIndex="3" Style="height: 26px" />
        </td>
    </tr>
</table>
    <asp:Panel ID="pnl" runat="server">
    <asp:Panel ID="pnldate" runat="server" DefaultButton="btngetdate">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label3" CssClass="lbl-form" Width="100px" runat="server" Text="Book type"></asp:Label>
                </td>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtbktype" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                                TabIndex="1" runat="server" Enabled="true"></asp:TextBox>
                            <div id="Div1" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtbktype"
                                UseContextKey="true" ContextKey="bktype" CompletionListElementID="dvbook">
                            </ajaxCt:AutoCompleteExtender>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Button ID="Btnget" CssClass="submitbtn" runat="server" Text="Get" Width="80px"
                        TabIndex="2" Style="height: 26px; display: none"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblfromdate" runat="server" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtFromDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Reqtdate" runat="server" ErrorMessage="Require From date"
                        ValidationGroup="date1" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtToDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To date"
                        ValidationGroup="date1" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btngetdate" TabIndex="3" CssClass="submitbtn" runat="server" Text="Get Data"
                        Width="80px" ValidationGroup="date1" />
                </td>
            </tr>
        </table>
        <br />
    </asp:Panel>
    <hr />
    <asp:ValidationSummary ID="virtualstockSummary" runat="server" ValidationGroup="date1"
        ShowMessageBox="true" ShowSummary="false" />

       <%-- <asp:GridView ID="Grdvirtualstockreport" runat="server" PageSize="2000" AlternatingRowStyle-CssClass="alt"
        AutoGenerateColumns="false" CellPadding="4" CssClass="product-table">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Yellow" ItemStyle-BorderColor="Yellow"
                HeaderText="Book Code" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblbkcode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name" HeaderStyle-BorderColor="Aqua" ItemStyle-BorderColor="Aqua"
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblName" Width="250px" ToolTip='<%#Eval("BookName")%>' runat="server"
                        Text='<%#Eval("BookName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Type" HeaderStyle-BorderColor="Blue" ItemStyle-BorderColor="Blue"
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookType")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Standard" HeaderStyle-BorderColor="Green" ItemStyle-BorderColor="Green"
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="red" ItemStyle-BorderColor="Red"
                HeaderText="Opening Stock" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblVstock" runat="server" Style="text-align: right;" Text='<%#Eval("OpeningStock")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="#800000" ItemStyle-BorderColor="#800000"
                HeaderText="Pur. Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblReceived_Qty" runat="server" Style="text-align: right;" Text='<%#Eval("Received_Qty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="#F87431" ItemStyle-BorderColor="#F87431"
                HeaderText="Rec. Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblReceivedQty" runat="server" Style="text-align: right;" Text='<%#Eval("ReceivedQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Yellow" ItemStyle-BorderColor="Yellow"
                HeaderText="Total Stock" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblstock" runat="server" Style="text-align: right;" Text='<%#Eval("TotalStock") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Aqua" ItemStyle-BorderColor="Aqua"
                HeaderText="Order Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblOrderDCQty" runat="server" Text='<%#Eval("OrderDCQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="blue" ItemStyle-BorderColor="blue"
                HeaderText="CnF Order Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblCnFOrderQty" runat="server" Text='<%#Eval("CnFOrderQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Blue" ItemStyle-BorderColor="Blue"
                HeaderText="Spe. Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblSpecimenDCQty" runat="server" Text='<%#Eval("SpecimenDCQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Green" ItemStyle-BorderColor="Green"
                HeaderText="CN" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblrtqty" runat="server" Style="text-align: right;" Text='<%#Eval("ReturnedQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="Green" ItemStyle-BorderColor="Green"
                HeaderText="Cnf CN" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblcnrtqty" runat="server" Style="text-align: right;" Text='<%#Eval("CnfCnQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="red" ItemStyle-BorderColor="Red"
                HeaderText="Available Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblavailable" runat="server" Text='<%#Eval("Balance QTY") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderStyle-BorderColor="blue" ItemStyle-BorderColor="blue"
                HeaderText="CnF Qty" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblCnFQty" runat="server" Text='<%#Eval("CnFQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
    </asp:Panel>
</asp:Content>

