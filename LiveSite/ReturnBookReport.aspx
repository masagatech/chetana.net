<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="ReturnBookReport.aspx.cs" Inherits="ReturnBookReport" Title="Return Book Report" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnl1" CssClass="panelDetails" runat="server">
    <table>
    
    <tr>
    <td width="100px"></td>
    <td width="100px">
    <asp:DropDownList  CssClass="ddl-form" ID="DDLSalesman" DataTextField="Name" DataValueField="EmpID"
        runat="server" Style="float: right"></asp:DropDownList>
    </td>
     <td>
    <asp:RequiredFieldValidator ID="reqDDlSal" runat="server" ErrorMessage="Select Employee" InitialValue="0"
        ValidationGroup="RB_Report" ControlToValidate="DDLSalesman">*</asp:RequiredFieldValidator>
     </td>
    <td width="100px">
        <asp:Button ID="btngetRec" Style="float: left;" CssClass="submitbtn" runat="server"
            Text="Get Records" onclick="btngetRec_Click" ValidationGroup="RB_Report"  />
    </td>    
    </tr>    
    </table>
</asp:Panel>
<br />
<br />  
<cr:crystalreportviewer id="crystalreportviewer1" runat="server" 
        AutoDataBind="true" displaygrouptree="false" enabledatabaselogonprompt="false" 
        enabledrilldown="false" enableparameterprompt="false" enabletheming="false" 
        enabletooltips="false" hasdrillupbutton="false" hasgotopagebutton="false" 
        haspagenavigationbuttons="false" hasrefreshbutton="true" 
        hassearchbutton="false" hastogglegrouptreebutton="false" hasviewlist="false" 
        haszoomfactorlist="false" height="1039px" width="773px" />
    </div>
    <asp:validationsummary showmessagebox="true" showsummary="false" validationgroup="Stockr"
    runat="server" id="ss" />
    
</asp:Content>

