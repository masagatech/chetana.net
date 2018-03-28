<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="OrderEvulation.aspx.cs" Inherits="UserControls_OrderEvulation" Title="Order valuation" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%@ register src="UserControls/uc_OrderValuation_DashBoard.ascx" tagname="uc_OrderValuation_DashBoard"
        tagprefix="uc2" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Order Valuation <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <br />
    <asp:Panel ID="Pnlselect" CssClass="panelDetails" runat="server" Width="522px">
        <table>
            <tr>
               <%-- <td width="120px">
                    <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text=" "></asp:Label>
                </td>--%>
                <td>
                    <asp:RadioButtonList ID="RdbtnSelect1" runat="server" RepeatDirection="Horizontal"
                        CssClass="lbl-form" Width="295px" OnSelectedIndexChanged="RdbtnSelect1_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem Value="Summary" Text="Summary" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Details" Text="Details"></asp:ListItem>
                        <asp:ListItem Value="Summary-Excel" Text="Summary-Excel"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <p>
    </p>
    <asp:Panel ID="Pnl1" runat="server">
        <div>
            <asp:Panel ID="pnlsalesmanwise" CssClass="panelDetails" runat="server" Width="750px">
                <table>
                    <tr>
                        <td>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                                TabIndex="1" DataValueField="SuperZoneId" AutoPostBack="true" runat="server"
                                OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                                InitialValue="0" ValidationGroup="S" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="ddl-form" ID="DDlZone" Width="250px" DataTextField="ZoneName"
                                TabIndex="2" DataValueField="ZoneID" runat="server">
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Zone " InitialValue="0"
                    ValidationGroup="S" ControlToValidate="DDlZone">.</asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                        <td>
                                    <asp:DropDownList CssClass="ddl-form" TabIndex="5" ID="DDLCC" runat="server"
                                        Width="225px" DataValueField="CMID" AutoPostBack="true" DataTextField="Name"
                                        >
                                    </asp:DropDownList>
                                </td>
                        </td>
                        <%-- <td>
            <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                      <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                    ValidationGroup="S" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
        </td>
        
        <td>
            <asp:Label ID="Label2" runat="server" Text="TO Date" CssClass="lbl-form"></asp:Label>
        </td>
        <td>
             <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txttoDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                    ValidationGroup="S" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
        </td>--%>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox><font color="red">*</font>
                            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtfromDate"
                                WatermarkText="FromDate">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                                ValidationGroup="Date" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="4" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox><font color="red">*</font>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txtToDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <ajaxCt:TextBoxWatermarkExtender ID="wat" runat="server" TargetControlID="txtToDate"
                                WatermarkText="ToDate">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                                ValidationGroup="Date" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                        </td>
                       
                    </tr>
                    <tr>
                    <td>
                     <asp:RadioButtonList ID="rdbselect" runat="server" RepeatDirection="Horizontal" TabIndex="5"
                        CssClass="lbl-form" Width="250px" 
                            onselectedindexchanged="rdbselect_SelectedIndexChanged" >
                         <asp:ListItem Value="nonzero" Text="Without Zero" Selected="True"></asp:ListItem> 
                         <asp:ListItem Value="zero" Text="Zero" ></asp:ListItem>
                         <asp:ListItem Value="both" Text="Both"></asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                     <td>
                            <asp:Button ID="btnview" runat="server" Width="60px" Text="Get" ValidationGroup="Date"
                                TabIndex="6" CssClass="submitbtn" Style="height: 26px" OnClick="btnget_Click" />
                        </td>
                     </tr>
                </table>
                <input id="btnprint" type="BUTTON" value="Print this Page" style="display: none"
                    onclick="printThis()" /></asp:Panel>
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Date"
                runat="server" ID="ss" />
            <br />
            <asp:Button ID="btnget" runat="server" Width="60px" Text="Print" ValidationGroup="S"
                CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px;" Visible="false" />
            <p>
            </p>
            <asp:Repeater ID="RepDetails" runat="server" OnItemDataBound="RepDetails_ItemDataBound">
                <ItemTemplate>
                    <div class="actiontab" style="margin-bottom: 2px;">
                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                            <tr>
                                <td valign="bottom">
                                    <span>
                                        <label style="font-size: 11px">
                                            Zone Code :
                                        </label>
                                        <asp:Label ID="ZoneCode" runat="server" Style="font-weight: bold; font-size: 11px"
                                            Text='<%#Eval("ZoneCode") %>'></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Style="font-weight: bold; font-size: 11px"
                                            Text='<%#" : "+Eval("ZoneName") %>'></asp:Label>
                                </td>
                                <%--<td align="right">
                                            <asp:Button ID="btnPrint" CommandArgument='<%#Eval("SubConfirmID")%>' OnClick="btnPrint_Click"
                                                runat="server" Text="Print" Style="float: right;" CssClass='<%#Eval("class")%>'
                                                ToolTip="click to print" />
                                        </td>--%>
                            </tr>
                        </table>
                    </div>
                    <asp:GridView ID="grdSalesAnalysis" Width="700px" AlternatingRowStyle-CssClass="alt"
                        CssClass="product-table" ShowFooter="true" AutoGenerateColumns="false" runat="server"
                        OnRowDataBound="grdSalesAnalysis_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Party Code" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>' Style="font-size: 11px"></asp:Label>
                                    <%--<asp:Label ID="lblspecidatils" Style="display: none;" runat="server" Text='<%#Eval("GanerateinvoiceId")%>'></asp:Label>
                                            <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Party Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gross Amt" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lbldebtamt" runat="server" Text='<%#Eval("GrossAmount","{0:0.00}")%>'
                                        HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTBillamt" Style="font-weight: bold" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Net. Amt" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right"
                                FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Label ID="lblcramt" runat="server" Text='<%#Eval("NetAmount","{0:0.00}")%>'
                                        HeaderStyle-HorizontalAlign="Left"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTRecdAmt" Style="font-weight: bold" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:Repeater>
            <table width="700px">
                <tr>
                    <td>
                        <asp:Label ID="lblTRecdAmt" Style="font-weight: bold" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTotalGrAmount" Style="font-size: medium; float: right; text-align: right;
                            width: 248px; font-weight: bold" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTotalNtAmount" Style="font-size: medium; float: right; text-align: right;
                            width: 43px; font-weight: bold" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <p>
    </p>
    
    <%--Me --%>
    
     <asp:Panel ID="Pnl3" runat="server">
        <div>
            <asp:Panel ID="Panel2" CssClass="panelDetails" runat="server" Width="750px">
                <table>
                    <tr>
                         <td>
                            <asp:DropDownList ID="ddlSDZone" runat="server" AutoPostBack="true" 
                                CssClass="ddl-form" DataTextField="SDZoneName" DataValueField="SDZoneId" 
                                OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged" TabIndex="1" 
                                Width="229px" Height="23px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="ddlSDZone" ErrorMessage="Require SuperDuper Zone " 
                                InitialValue="0" ValidationGroup="Date">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone1" Width="250px" DataTextField="SuperZoneName"
                                TabIndex="1" DataValueField="SuperZoneId" AutoPostBack="true" runat="server"
                                OnSelectedIndexChanged="DDLSuperZone1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require SuperZone "
                                InitialValue="0" ValidationGroup="Date" ControlToValidate="DDLSuperZone1">.</asp:RequiredFieldValidator>
                        </td>
                        </tr>
                   <tr>
                        
                        <td>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLZone1" Width="250px" DataTextField="ZoneName"
                                TabIndex="2" DataValueField="ZoneID" runat="server">
                            </asp:DropDownList>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Zone " InitialValue="0"
                           ValidationGroup="S" ControlToValidate="DDlZone">.</asp:RequiredFieldValidator>--%>
                        </td>
                  </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtfromDate1" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox><font color="red">*</font>
                            <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfromDate1"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtfromDate1"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtfromDate1"
                                WatermarkText="FromDate">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Require From Date"
                                ValidationGroup="Date" ControlToValidate="txtfromDate1">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtToDate1" CssClass="inp-form" TabIndex="4" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox><font color="red">*</font>
                            <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate1"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtToDate1"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtToDate1"
                                WatermarkText="ToDate">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Require To Date"
                                ValidationGroup="Date" ControlToValidate="txtToDate1">.</asp:RequiredFieldValidator>
                        </td>
                        <td></td>
                        <td>
                         <asp:Button ID="btnget1" runat="server" Width="60px" Text="Get"  
                CssClass="submitbtn" OnClick="btnget1_Click" Style="height: 26px;" Visible="true" />
                        </td>
                       
                    </tr>
                  
                </table>
                <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Date"
                runat="server" ID="ValidationSummary1" />
            <br />
           
           </asp:Panel>  
        </div>
    </asp:Panel>
    
   <p></p>
    
    
    
    <CR:CrystalReportViewer ID="CrOrderValuation" runat="server" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
        Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
    <asp:Panel ID="Pnl2" runat="server">
        <uc2:uc_OrderValuation_DashBoard ID="uc_OrderValuation_DashBoard1" runat="server" />
    </asp:Panel>
</asp:Content>
