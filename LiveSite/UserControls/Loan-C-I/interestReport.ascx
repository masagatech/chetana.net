<%@ Control Language="C#" AutoEventWireup="true" CodeFile="interestReport.ascx.cs"
    Inherits="UserControls_Loan_C_I_interestReport" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Panel ID="pnlCust" CssClass="panelDetails" runat="server" Width="352px" DefaultButton="btnAdd">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100px" valign="top">
                <asp:Label ID="lblID" runat="server" Style="display: none;"></asp:Label>
                <asp:RadioButtonList ID="rdoSelection" RepeatDirection="Horizontal" 
                    runat="server" AutoPostBack="True" 
                    onselectedindexchanged="rdoSelection_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Text="Party" Value="p"></asp:ListItem>
                    <asp:ListItem Text="Broker" Value="b"></asp:ListItem>
                </asp:RadioButtonList>
                <%--<asp:Label ID="lblID1" runat="server" Style="display: none;"></asp:Label>--%>
                <%--<asp:Label ID="lblPartyName" runat="server" CssClass="lbl-form" Text="Ac Code"></asp:Label>
                <font color="red">*</font>--%>
            </td>
            <td>
                <asp:UpdatePanel UpdateMode="Conditional" ID="upCodeUpdate" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEMcode" TabIndex="1" autocomplete="off" Width="250px" CssClass="inp-form"
                            runat="server" Height="15px"></asp:TextBox>
                        <div id="dvcust" class="divauto">
                        </div>
                        <ajaxCt:AutoCompleteExtender ID="cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                            ServiceMethod="GetCodes" CompletionSetCount="10" ServicePath="~/AutoComplete.asmx"
                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtEMcode"
                            UseContextKey="true" ContextKey="ACCUSL" CompletionListElementID="dvcust">
                        </ajaxCt:AutoCompleteExtender>
                        <asp:RequiredFieldValidator ID="rfvcust" runat="server" ErrorMessage="Require AC Name"
                            ValidationGroup="Discount12" ControlToValidate="txtEMcode">.</asp:RequiredFieldValidator>
                        <%--<asp:Label ID="lblshow" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px" runat="server"></asp:Label>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="display: none;">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<table width="400px">
    <tr>
        <td align="right">
            <asp:Button ID="btnGenerateReport" CssClass="submitbtn" TabIndex="8" OnClick="btnGenerateRep_Click"
                runat="server" Text="Generate Report" />
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="upDataUpdater" runat="server">
    <ContentTemplate>
        <asp:Panel Width="400px" GroupingText="Details" Enabled="false" ID="getDetails" runat="server"
            CssClass="pnldash">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblDays" runat="server" Text="No of Days : "></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox Width="30px" TabIndex="3" ID="txtDays" runat="server" Text="360"></asp:TextBox>
                    </td>
                </tr>
                <%--  <tr>
          <td>
          </td>
          <td>
          </td>
        </tr>
        <tr>
          <td>
          </td>
          <td>
          </td>
        </tr>--%>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Date From : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromDate" TabIndex="6" runat="server" Width="100px"></asp:TextBox>
                        <%--<asp:TextBox ID="txtdateabc" onblur="ValidInYearDate(this);" CssClass="inp-form"
            Width="100px" runat="server" TabIndex="3"></asp:TextBox>
          --%>
                        <ajaxCt:CalendarExtender Animated="true" PopupPosition="Right" ID="CalendarExtender3"
                            runat="server" TargetControlID="txtFromDate" Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="Maskedorddate" runat="server" TargetControlID="txtFromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Date To : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtToDate" TabIndex="7" runat="server" Width="100px"></asp:TextBox>
                        <ajaxCt:CalendarExtender Animated="true" PopupPosition="Right" ID="CalendarExtender1"
                            runat="server" TargetControlID="txtToDate" Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right" colspan="2">
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="abcpqr" runat="server" Width="500px" ScrollBars="Auto" Height="250px">
            <asp:GridView Width="400px" ID="grdTEmpData" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
                OnRowDeleting="grdBookDetails_RowDeleting" CellPadding="4" CssClass="product-table"
                runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="Acc Code">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("AccountCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acc Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("AccName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Int. Rate(%)">
                        <ItemTemplate>
                            <asp:TextBox onkeypress="return CheckNumericWithDot(event)" onblur="if(this.value==''){this.value='0'}"
                                Style="text-align: right;" TabIndex="2" ID="txtIntRate" runat="server" Text='<%#Eval("Interest") %>'
                                Width="60px"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remove" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" CommandName="delete"
                                runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <br />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>
<%--<asp:Button ID="btnGenerateRep"  runat="server"  />--%>
<CR:CrystalReportViewer ID="crtIntrest" runat="server" HasGotoPageButton="True" AutoDataBind="false"
    HasSearchButton="True" DisplayGroupTree="False" EnableDatabaseLogonPrompt="false"
    EnableDrillDown="false" HasCrystalLogo="False" EnableParameterPrompt="false"
    EnableTheming="false" EnableToolTips="false" HasDrillUpButton="False" HasPageNavigationButtons="True"
    HasRefreshButton="False" HasToggleGroupTreeButton="false" HasViewList="False"
    HasZoomFactorList="False" Width="773px" />
<%--<a href="#" onclick="callReport()"></a>--%><%--<script type="text/javascript"> 
          function callReport()
          {         
            document.getElementById("ctl00_ContentPlaceHolder1_interestReport1_btnGenerateRep").Click();
          }
</script>--%>