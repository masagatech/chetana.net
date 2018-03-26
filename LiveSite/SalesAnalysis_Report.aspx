<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SalesAnalysis_Report.aspx.cs" Inherits="SalesAnalysis_Report" Title="Chetana : Sales Analysis Report" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="section-header">

    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       Sales Analysis Report
         <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
 </div>
<div width="750px">
<asp:Panel ID ="pnlsalesmanwise" width="750px" CssClass="panelDetails" runat ="server" >
        <table border="0" width="750px" cellpadding="2" cellspacing="2">
        <tr>
        <td>
        <asp:DropDownList  CssClass="ddl-form"  ID="ddlSDZone" width="250px" DataTextField="SDZoneName"
                     DataValueField="SDZoneId"  AutoPostBack="true" runat="server"  TabIndex = "1"
                OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Require Super Duper Zone " InitialValue="0"
                    ValidationGroup="S" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:DropDownList  CssClass="ddl-form"  ID="DDLSuperZone" width="250px" DataTextField="SuperZoneName"
                     DataValueField="SuperZoneId"  AutoPostBack="true" runat="server"  TabIndex = "2"
                onselectedindexchanged="DDLSuperZone_SelectedIndexChanged">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone " InitialValue="0"
                    ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
        </td>
        <td >
            <asp:DropDownList  CssClass="ddl-form"  ID="DDlZone" width="250px" DataTextField="ZoneName" 
            TabIndex = "2" DataValueField="ZoneID"  runat="server">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require SuperZone " InitialValue="0"
                    ValidationGroup="S3" ControlToValidate="DDlZone">.</asp:RequiredFieldValidator>
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
            
                                    <asp:DropDownList CssClass="ddl-form" TabIndex="5" ID="DDLCC" runat="server"
                                       width="250px"  DataValueField="CMID" AutoPostBack="true" DataTextField="Name"
                                        >
                                    </asp:DropDownList>
            </td>
         <td>
        <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                     <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtfromDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
                 TargetControlID="txtfromDate" WatermarkText="FromDate">
              </ajaxCt:TextBoxWatermarkExtender>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Require From Date " 
                    ValidationGroup="S" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
                  
        </td>
        <td>
        <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="4" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                    Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtToDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                   <ajaxCt:TextBoxWatermarkExtender ID="wat" runat="server" TargetControlID="txtToDate"
                   WatermarkText="ToDate"></ajaxCt:TextBoxWatermarkExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Require To date " 
                    ValidationGroup="S" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                    
        </td>
        </tr>
        <tr>
        <td>
                     <asp:RadioButtonList ID="rdbselect" runat="server" RepeatDirection="Horizontal"
                        CssClass="lbl-form" Width="250px" >
                         <asp:ListItem Value="nonzero" Text=" Active" Selected="True"></asp:ListItem> 
                         <asp:ListItem Value="zero" Text=" Non-Active" ></asp:ListItem>
                         <asp:ListItem Value="both" Text=" All"></asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
        <td>
         <asp:Button ID="btnget" runat="server" width="80px" Text="Get"  TabIndex = "5"  ValidationGroup="S" CssClass="submitbtn"
            onclick="btnget_Click" style="height: 26px" />
        </td>
        </tr>
        </table>
        
       
             
            <input id="btnprint" type="BUTTON" value="Print this Page" style="display: none" onclick="printThis()"/></asp:Panel>
            <asp:ValidationSummary ID="Summary1" runat ="server" ShowMessageBox="true" ShowSummary="false" 
               ValidationGroup="S"/>
                 
                <cr:crystalreportviewer id="SalesanalysisReportview" runat="server" DisplayGroupTree="False"
             enabledatabaselogonprompt="false" 
            enableparameterprompt="false" enabletheming="false" 
            enabletooltips="true" hasdrillupbutton="False" hasgotopagebutton="True" 
            hassearchbutton="True" haszoomfactorlist="false" height="1039px" width="773px" />
            </div>

</asp:Content>

