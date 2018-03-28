<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SalesmantoSchool.ascx.cs"
    Inherits="UserControls_uc_SalesmantoSchool" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Salesman To Customer
    </div>
    <div class="options">
        <asp:Button ID="BtnBack" CssClass="submitbtn" runat="server" Text="Back" Width="80px"
            OnClick="BtnBack_Click" />
    </div>
</div>
<%--<asp:UpdatePanel ID="upgrddetails" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
<asp:Panel ID="PnlDashboard" CssClass="panelDetails" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="DDLSalesman" DataTextField="Name" DataValueField="EmpCode"
                    runat="server" Style="float: right">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btngetRec" Style="float: left;" CssClass="submitbtn" runat="server"
                    Text="Get Records" OnClick="btngetRec_Click" />
            </td>
            <td>
                <asp:TextBox ID="TxtDocNum" runat="server" Width="67px" Style="text-align: center;
                    display: none;"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BtnGetByDocNum" CssClass="submitbtn" runat="server" Text="Get Records"
                    Style="text-align: center; display: none;" OnClick="BtnGetByDocNum_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
    <%--<asp:UpdatePanel ID="upDetails" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>
    <table>
        <tr>
            <td valign="top">
                <asp:Panel ID="Panel1" GroupingText="Qty Details" CssClass="pnldash" runat="server">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Ordered Qty"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton CssClass="nav_bar_link" ID="lnkorder" runat="server" OnClick="lnkorder_Click"></asp:LinkButton>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label2" CssClass="lbl-form" runat="server" Text="Received Qty"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton CssClass="nav_bar_link" ID="lnkReceive" runat="server" OnClick="lnkReceive_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Alloted Qty"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton CssClass="nav_bar_link" ID="lnkAllot" runat="server" OnClick="lnkAllot_Click"></asp:LinkButton>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label7" CssClass="lbl-form" runat="server" Text="Pending Qty"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton Class="nav_bar_link" ID="lnkPending" runat="server" OnClick="lnkPending_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td valign="top">
                <asp:Panel ID="Panel2" GroupingText="Customer Details" Width="100px" CssClass="pnldash"
                    runat="server">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Total Customer"></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton CssClass="nav_bar_link" ID="lnkCustomerCount" runat="server" OnClick="lnkCustomerCount_Click"></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <%--    </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btngetRec" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>--%>
</asp:Panel>
<div id="filter" visible="false" runat="server" style="width: 80%; text-align: right;">
    <span>Filter Data:</span>
    <input name="filt" onkeyup="filter(this, 'sf', '<%=grdSchooldetails.ClientID%>')"
        id="filterdata" type="text"></div>
<br />
<asp:GridView ID="grdSchooldetails" runat="server" AutoGenerateColumns="false" CssClass="product-table"
    OnRowDeleting="grdSchooldetails_RowDeleting" AlternatingRowStyle-CssClass="alt"
    OnRowEditing="grdSchooldetails_RowEditing" Width="80%">
    <Columns>
        <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblSpecimenDetailID" runat="server" CssClass="lbl-form" Style="display: none;"
                    Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
                <asp:Label ID="lblBookcode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Book Name" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblBookname" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="30px" HeaderText="Medium" ItemStyle-HorizontalAlign="left">
            <ItemTemplate>
                <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="30px" HeaderText="Standard" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="OrderedQty" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblquantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="ReceivedQty" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblReceivedqty" runat="server" Text='<%#Eval("ReceivedQty")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="AllotQty" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblGivedquantity" runat="server" Text='<%#Eval("GivedQty")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Remaining Qty" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblremain" runat="server" Text='<%#Eval("RemainQty") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderStyle-Width="40px" HeaderText="Allot" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:LinkButton ID="LnkAllot" runat="server" CausesValidation="false" CommandName="Edit">Allot</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <asp:Label ID="lblEmpty" runat="server" CssClass="headings" Text="No data available"
            Visible="<%#bool.Parse((grdSchooldetails.Rows.Count==0).ToString()) %>"></asp:Label>
    </EmptyDataTemplate>
</asp:GridView>
<asp:Panel ID="pnlSchooldetails"  runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Panel ID="Panel3" GroupingText="Salesmen To Cutomer Details" CssClass="pnldash"
                        Width="690px" runat="server">
                        <table style="width: 133%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblSpDetailid" runat="server" Style="display: none; font-weight: bold"> </asp:Label>
                                </td>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td width="100px;">
                                    <asp:Label ID="lbl1" CssClass="lbl-form" runat="server" Text="Qty :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LblOriginalQty" CssClass="lbl-form" runat="server"></asp:Label>
                                </td>
                                <td width="70px">
                                    <asp:Label ID="LblB" CssClass="lbl-form" runat="server">Book Name :</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="LblBookName" CssClass="lbl-form" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblRQty" CssClass="lbl-form" runat="server" Text="Remaining Qty :"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRemainingQuantity" CssClass="lbl-form" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <%--  <asp:Label ID="Label3" CssClass="lbl-form" runat="server"></asp:Label>--%>
                                    <asp:Label ID="LblRQty1" runat="server" Text="Label" Style="display: none;"></asp:Label>
                                </td>
                                <td>
                                    <%-- <asp:Label ID="Label5" CssClass="lbl-form" runat="server"></asp:Label>--%>
                                </td>
                            </tr>
                            <td>
                                <asp:UpdatePanel ID="upPostbakQty" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl2" CssClass="lbl-form" runat="server" Text="Quantity :"></asp:Label>
                                            </td>
                                            <td width="60px">
                                                <asp:TextBox ID="txtqnty" AutoComplete="off" Width="50px" CssClass="inp-form" Style="text-align: right;"
                                                    runat="server" OnTextChanged="txtqnty_TextChanged" AutoPostBack="true" MaxLength="10"></asp:TextBox>
                                                <ajaxCt:FilteredTextBoxExtender ID="extender" runat="server" TargetControlID="txtqnty"
                                                    FilterType="Custom, Numbers" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Customer :"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtcustomer" runat="server" autocomplete="off" AutoPostBack="true"
                                                CssClass="inp-form" onfocus="setfocus('customer');" OnTextChanged="txtcustomer_TextChanged"
                                                TabIndex="8" Width="80px"></asp:TextBox>
                                            <div id="dvcust" class="divauto">
                                            </div>
                                            <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" CompletionInterval="100"
                                                CompletionListCssClass="AutoExtender" CompletionListElementID="dvcust" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                                                CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="customer"
                                                DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                                                ServiceMethod="GetCustomerCode_ByEmp" ServicePath="~/AutoComplete.asmx" TargetControlID="txtcustomer"
                                                UseContextKey="true">
                                            </ajaxCt:AutoCompleteExtender>
                                            <asp:RequiredFieldValidator ID="RFVCust" runat="server" ControlToValidate="txtcustomer"
                                                ErrorMessage="Require Customer Code" ValidationGroup="S">.</asp:RequiredFieldValidator>
                                            <asp:Label ID="lblCustName" runat="server" CssClass="lbl-form" Font-Size="12px" ForeColor="Blue"></asp:Label>
                                            </td> </tr>
                                            <tr>
                                                <td>
                                                    <asp:DropDownList ID="DDlSelectSchool" runat="server" CssClass="ddl-form" DataTextField="CustName"
                                                        DataValueField="CustID" Style="display: none">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnadd" runat="server" CssClass="submitbtn" OnClick="btnadd_Click"
                                        Text="Add" Width="70px" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
&nbsp; </td> </tr>
<tr>
    <td>
        <%-- <asp:Label ID="LblPrevRecords" Text="Previous Allotments" Style="font-weight: bold"
                        runat="server"></asp:Label>--%>
    </td>
</tr>
<tr>
    <td align="right">
        <asp:Button ID="BtnSaveAllotDetails" CssClass="submitbtn" runat="server" Text="Save"
            Width="70px" OnClick="BtnSaveAllotDetails_Click" Height="26px" />
          <p></p>
    </td>
</tr>

<tr>
    <td>
        <asp:GridView ID="GridView1" CssClass="product-table" AutoGenerateColumns="false"
            Width="690px" runat="server" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="BookName" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="School Name" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblSchoolId" CssClass="lbl-form" runat="server" Text='<%#Eval("CustID") %>'
                            Style="display: none;"></asp:Label>
                        <asp:Label ID="LblSchoolName" CssClass="lbl-form" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alloted Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="LblQuantity" CssClass="lbl-form" runat="server" Text='<%#Eval("AllotQty")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="delete"
                            OnClientClick="javascript:confirm('Are you sure want to remove this book');"
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </td>
</tr>
<tr>
    <td>
        <asp:GridView ID="GrdPreviousallot" CssClass="product-table" AutoGenerateColumns="false"
            Width="650px" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="BookName" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="School Name" ItemStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:Label ID="LblSchoolId" CssClass="lbl-form" runat="server" Text='<%#Eval("CustID") %>'
                            Style="display: none;"></asp:Label>
                        <asp:Label ID="LblSchoolName" CssClass="lbl-form" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Alloted Qty" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="LblQuantity" CssClass="lbl-form" runat="server" Text='<%#Eval("AllotQty")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--   <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="delete"
                                        OnClientClick="javascript:confirm('Are you sure want to remove this book');"
                                        runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </td>
</tr>
</table> </div> </asp:Panel>
<asp:Label ID="demolabel" runat="server" Text="Label" Style="display: none;"></asp:Label>
<%--    </ContentTemplate>
</asp:UpdatePanel>--%>