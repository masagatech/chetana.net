<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ChetanaViewCourierCR.aspx.cs" Inherits="ChetanaViewCourierCR" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
               Courier Print<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
          <div id="divLevel1" runat="server" style="margin: -40px 0 0; position: relative; top: 0px;left: 0px;">
   <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server"  >
      <table>
        <tr>
          <td>
            <asp:RadioButtonList runat="server" ID="rdLevel1" TabIndex="1" RepeatDirection="Horizontal"
              CssClass="lbl-form" Width="300px" AutoPostBack="true" onselectedindexchanged="rdLevel1_SelectedIndexChanged" 
                  >
              <asp:ListItem Value="InvoiceNo" Text="Invoice" Selected="True"></asp:ListItem>
               <asp:ListItem Value="Others" Text="Others" ></asp:ListItem>
             <%-- <asp:ListItem Value="General" Text="General"></asp:ListItem>--%>
            </asp:RadioButtonList>
          </td>
        </tr>
        
      </table></asp:Panel>
      </div>
          <div  id="divLevel2" runat="server" >
   <asp:Panel ID="Pnldate" CssClass="panelDetails" runat="server"  style="float: left; height: 84px; margin: 0 4px 0 0; width: 680px;" >
     
        <asp:Panel ID="pnldoc123" runat="server">
        

          <table>          <tr>
             
            <td>
              <asp:Label ID="Label2" runat="server" Text="Courier Company" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
           <asp:DropDownList  CssClass="ddl-form" ID="ddlCourierI" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                    runat="server" ></asp:DropDownList> </td>
             
            
            <td>
              <asp:Label ID="Label11" runat="server" Text="Branch" CssClass="lbl-form"></asp:Label>
            </td>
            <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlBranchI" DataTextField="Branch" 
                      DataValueField="EmpID" TabIndex="2"
                    runat="server" ></asp:DropDownList>
                    
              </td>
            
          </tr>
          
        </table>
        <table>
          <tr>
          <td width="60px" id="CID" runat="server" visible="true">
              <asp:Label ID="Label1" runat="server" Text="Courier Id" CssClass="lbl-form"></asp:Label>
            </td>
            <td id="CIDT" runat="server" visible="true">
              <asp:TextBox ID="txtCourierId" CssClass="inp-form" TabIndex="22"  runat="server"></asp:TextBox>
            </td>
             
            <td>
              <asp:Label ID="Label9" runat="server" Text="Invoice No." CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtInvoiceNoGet" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
            </td>
             
            
            <td>
              <asp:Label ID="Label3" runat="server" Text="Dc No." CssClass="lbl-form"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtDocNoGet" CssClass="inp-form" TabIndex="22" runat="server"></asp:TextBox>
            </td>
            
          </tr>
          
          
          <tr>
          <td>
                                        <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select Fromdate"
                                            ValidationGroup="AZone" ControlToValidate="txtFrom">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" ControlToValidate="txtTo">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
              <asp:Button ID="btnget" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                ValidationGroup="pdadoc" Width="50px" onclick="btnget_Click" />
            </td>
          </tr>
          </table>
      </asp:Panel></asp:Panel></div>
          <div  id="divGeneral" runat="server" >
   <asp:Panel ID="Panel2" CssClass="panelDetails" runat="server"  style="float: left; height: 84px; margin: 0 4px 0 0; width: 690px;" >
      
      <asp:Panel ID="Panel3" runat="server">
        <table>
        <tr>
        <td width="60px" id="Td1" runat="server" visible="true">
              <asp:Label ID="lblGeneralCourierID" runat="server" Text="Courier Id" CssClass="lbl-form"></asp:Label>
            </td>
            <td id="Td2" runat="server" visible="true">
              <asp:TextBox ID="txtGeneralCourierID" CssClass="inp-form" TabIndex="22"  runat="server"></asp:TextBox>
            </td>
            </tr>
          <tr>
             
            <td width="70px">
              <asp:Label ID="Label4" runat="server" Text="Courier Company" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
           <asp:DropDownList  CssClass="ddl-form" ID="ddlCourier" DataTextField="Value" DataValueField="AutoId" TabIndex="1"
                    runat="server" ></asp:DropDownList> </td>
             
            
            <td width="50px">
              <asp:Label ID="Label5" runat="server" Text="Branch" CssClass="lbl-form"></asp:Label>
            </td>
            <td>                  
                  <asp:DropDownList  CssClass="ddl-form" ID="ddlBranch" DataTextField="Branch" 
                      DataValueField="EmpID" TabIndex="2"
                    runat="server" ></asp:DropDownList>
                    
              </td>
            
          </tr>
          <tr>
          <td>
                                        <asp:Label ID="Label6" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromGeneral" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromGeneral"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFromGeneral"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please select Fromdate"
                                            ValidationGroup="AZone" ControlToValidate="txtFromGeneral">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtToGeneral" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToGeneral"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtToGeneral"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select ToDate"
                                            ValidationGroup="AZone" ControlToValidate="txtToGeneral">.</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
              <asp:Button ID="Button1" runat="server" Text="Get" CssClass="submitbtn" TabIndex="24"
                ValidationGroup="pdadoc" Width="50px" onclick="btnget_Click" />
            </td>
          </tr>
        </table>
      </asp:Panel>
    </asp:Panel></div></div>
    <CR:CrystalReportViewer ID="ChetanaViewCourier" runat="server" PrintMode="ActiveX" AutoDataBind="true"
         EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="false" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="True"  HasZoomFactorList="false"
        Height="1039px" Width="773px" />
</asp:Content>


