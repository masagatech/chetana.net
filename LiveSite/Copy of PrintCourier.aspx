<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Copy of PrintCourier.aspx.cs" Inherits="PrintCourier" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
           Print Courier <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
    </div>
    <br />
    <div>
        <asp:Panel ID="pnlsalesmanwise" CssClass="panelDetails" runat="server" Width="800px">
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList runat="server" ID="rdbselect" TabIndex="1" RepeatDirection="Horizontal"
                            CssClass="lbl-form" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="rdbselect_SelectedIndexChanged">
                             <asp:ListItem Value="InvoiceNo" Text="Invoice" Selected="True"></asp:ListItem>
               <asp:ListItem Value="Others" Text="Others" ></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlcustomer" runat="server">
                            <table>
                                <tr>
                                <td>
           <asp:DropDownList  CssClass="ddl-form" ID="ddlCourierI" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                    runat="server" ></asp:DropDownList> </td>
                                    <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlBranchI" DataTextField="Branch" 
                      DataValueField="EmpID" TabIndex="2"
                    runat="server" ></asp:DropDownList>
                    
              </td></tr>
              </table>
                            <table>
                                    
                                  
                                    <tr>
                                    <td id="CIDT" runat="server" visible="true">
              <asp:TextBox ID="txtCourierId" Text="CourierId" CssClass="inp-form" TabIndex="3"  runat="server"></asp:TextBox>
            </td>
            <td>
              <asp:TextBox ID="txtInvoiceNoGet" Text="Invoice" CssClass="inp-form" TabIndex="4" runat="server"></asp:TextBox>
            </td>
            <td>
              <asp:TextBox ID="txtDocNoGet" Text="Doc"  CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
            </td>
                                    </tr>
                                    <tr>
                                     <td>
                                        <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select Fromdate"
                                            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="7" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                                    </td>
                             
                                    <td>
                                        <asp:Button ID="btnget" runat="server" Width="60px" Text="Get" ValidationGroup="S"
                                            TabIndex="2" CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlsupplier" runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList  CssClass="ddl-form" ID="ddlCourier" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                    runat="server" ></asp:DropDownList> </td>
                    <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlBranch" DataTextField="Branch" 
                      DataValueField="EmpID" TabIndex="2"
                    runat="server" ></asp:DropDownList>
                    
              </td></tr></table>
              <table>
              <tr>
              <td id="Td2" runat="server" visible="true">
              <asp:TextBox ID="txtGeneralCourierID" Text="CourierId" CssClass="inp-form" TabIndex="3"  runat="server"></asp:TextBox>
            </td></tr><tr>
            <td>
                                        <asp:Label ID="Label6" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromGeneral" CssClass="inp-form" TabIndex="4" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromGeneral"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFromGeneral"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                                            ValidationGroup="AZone" ControlToValidate="txtFromGeneral">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToGeneral" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToGeneral"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtToGeneral"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" ControlToValidate="txtToGeneral">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnsupplier" runat="server" Width="60px" Text="Get" ValidationGroup="S"
                                            TabIndex="2" CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px;" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="S"
                runat="server" ID="ss" />
            <br />
        </asp:Panel>
    </div>
    <CR:CrystalReportViewer ID="CrCustLabel" runat="server" PrintMode="ActiveX" AutoDataBind="true"
         EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="True"  HasZoomFactorList="false"
        Height="1039px" Width="773px" />
</asp:Content>

