<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Trial_Balance.aspx.cs" Inherits="Trial_Balance" Title="Trial Balance" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<asp:Panel ID ="pnlsalesmanwise" CssClass="panelDetails" runat ="server">
        <table>
        <tr>
        <td>
            <asp:DropDownList  CssClass="ddl-form"  ID="DDLSuperZone" width="250px" DataTextField="SuperZoneName"
                     DataValueField="SuperZoneId"  AutoPostBack="true" runat="server">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone " InitialValue="0"
                    ValidationGroup="S" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:DropDownList  CssClass="ddl-form"  ID="DDlZone" width="250px" DataTextField="ZoneName" DataValueField="ZoneID" runat="server">
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require SuperZone " InitialValue="0"
                    ValidationGroup="S" ControlToValidate="DDlZone">.</asp:RequiredFieldValidator>
        </td>
        <td>
         <asp:Button ID="btnget" runat="server" width="80px" Text="Get"  ValidationGroup="S" CssClass="submitbtn"
            onclick="btnget_Click" style="height: 26px" />
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
        </table>
        
       
             
            <input id="btnprint" type="BUTTON" value="Print this Page" style="display: none" onclick="printThis()"/> 
            </asp:Panel>
</div>

</asp:Content>

