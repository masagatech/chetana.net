<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="KycFormReport.aspx.cs" Inherits="KycFormReport" Title="Kyc Form Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <CR:CrystalReportViewer ID="KycFormReportDoc" runat="server" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
        Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
        <asp:HiddenField ID="txtIsExport" runat="server" />


        <script type="text/javascript">
        $("input[title='Export']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        $("input[title='Print']").click(function() {
            document.getElementById('<%=txtIsExport.ClientID %>').value = 'yes';
        });
        
        </script>
</asp:Content>

 
