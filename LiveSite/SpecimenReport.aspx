<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="SpecimenReport.aspx.cs" Inherits="SpecimenReport" Title="Chetana : Specimen Report" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
     <asp:Panel ID ="pnlspecimen" CssClass="panelDetails" runat ="server">
    <table>
    <tr>
        <td>
            <asp:Label ID="lbldoc" runat="server" Text="Document No." CssClass ="lbl-form"></asp:Label>
        </td>
             <td>
              <asp:TextBox ID="txtDocno"  autocomplete="off" onkeypress="return CheckNumeric(event)"
                            Width="80px" CssClass="inp-form" TabIndex="1" runat="server" 
                     AutoPostBack="true" ontextchanged="txtDocno_TextChanged" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Document No."
                    ValidationGroup="Confirm" ControlToValidate="txtDocno">.</asp:RequiredFieldValidator>
            </td>
             <td>
                 &nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList  CssClass="ddl-form" ID="DDLsubconfirmid"  DataValueField="SubConfirmID" 
                 runat="server" TabIndex="2" Height="18px">
                 </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require SubConfirm ID" InitialValue="0"
                    ValidationGroup="Confirm" ControlToValidate="DDLsubconfirmid">.</asp:RequiredFieldValidator>
            </td>
        <td>
               &nbsp;&nbsp;&nbsp;&nbsp; 
                 
             <asp:Button ID="btnget" TabIndex="3" runat="server" width="80px" Text="Get"   ValidationGroup="Confirm" CssClass="submitbtn"
                onclick="btnget_Click" style="height: 26px" />
        </td>
      </tr>
</table>
</asp:Panel>
  <br />
        <br />
    
    <br />
<cr:crystalreportviewer id="crtspecimen" runat="server" 
            AutoDataBind="True" displaygrouptree="false" enabledatabaselogonprompt="false" 
            enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
            enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="false" 
            haspagenavigationbuttons="true" hasrefreshbutton="true" 
            hassearchbutton="false" hastogglegrouptreebutton="false" height="50px" 
            width="350px" />
            
     </div>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Confirm"
    runat="server" ID="ss" />

</asp:Content>
