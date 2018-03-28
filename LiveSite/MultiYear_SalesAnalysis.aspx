<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="MultiYear_SalesAnalysis.aspx.cs" Inherits="MultiYear_SalesAnalysis"
    Title="Multi Year SalesAnalysis Report" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="js/jquery-1.4.2.min.js" type="text/javascript"></script>

    <script src="js/jquery-ui.min.js" type="text/javascript"></script>

    <link href="Css/innerStyle.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    
    $(document).ready(function() {
   $('.draggableWindow').draggable();
   $( ".content" ).resizable({
			animate: true
			});
	$(".draggableWindow").click(function() {
	 $(".draggableWindow").each(function (i) {
         $(this).css("z-index","1000");
      });
	 
       $(this).css("z-index","1001");
});
	
			
 });
 
    </script>
   

    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Multi Year Sales Analysis Report <a href="Campaigns.aspx" title="back to campaign list">
            </a>
        </div>
    </div>
    <asp:Panel ID="pnlsalesmanwise" Width="750px" CssClass="panelDetails" runat="server">
        <table border="0" width="750px" cellpadding="2" cellspacing="2">
            <tr>
                
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="250px" DataTextField="SDZoneName"
                        DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Require SuperDuper Zone "
                        InitialValue="0" ValidationGroup="S" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                        DataValueField="SuperZoneId" AutoPostBack="true" runat="server" TabIndex="2"
                        OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require SuperZone "
                        InitialValue="0" ValidationGroup="S1" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButtonList ID="rdbselect" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
                        Width="250px">
                        <asp:ListItem Value="nonzero" Text=" Active" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="zero" Text=" Non-Active"></asp:ListItem>
                        <asp:ListItem Value="both" Text=" All"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" TabIndex="5" ValidationGroup="S"
                        CssClass="submitbtn" OnClick="btnget_Click" Style="height: 26px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:DataList ID="DLDashboard" CellSpacing="2" CellPadding="0" runat="server" RepeatColumns="1"
        RepeatDirection="vertical" OnItemDataBound="DLDashboard_ItemDataBound" >
        <ItemTemplate>
            <div class="draggableWindow">
                <div class="content" id="contentid">
                    <div class="dashBoardvaluation">
                        <table border="2" width="100%" cellpadding="0">
                            <tr>
                                <td valign="top" align="center" width="70px" style="background-color: #481A68;">
                                    <asp:LinkButton ID="lnkszname" runat="server" Text='<%#Eval("SuperZoneName")%>' CommandArgument='<%#Eval("SuperZoneID")%>'
                                        CssClass="lnkbtn" OnClick="lnkszname_Click"></asp:LinkButton>
                                    <asp:Label ID="lblSzname" runat="server" Text='<%#Eval("SuperZoneName")%>' Style="display: none"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="GrdDashboard" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                        CaptionAlign="Bottom" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText='Zone' HeaderStyle-BackColor="#999999">
                                           
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkzone" runat="server" Text='<%#Eval("Zone")%>' CommandArgument='<%#Eval("ZoneId")%>' CommandName='<%#Eval("FinancialYear")%>'
                                                        CssClass="lnkbtn" OnClick="lnkzone_Click"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='OB' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblob" CssClass="count" runat="server" Text='<%#Eval("Openingbalance","{0:0.00}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='DebitAmt' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldebitAmt" CssClass="count" runat="server" Text='<%#Eval("DebitAmount","{0:0.00}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='CreditAmt' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcreditAmt" CssClass="count" runat="server" Text='<%#Eval("CreditAmount","{0:0.00}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='CNAmt' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldCNAmt" CssClass="count" runat="server" Text='<%#Eval("CNAmt","{0:0.00}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='CNAmt' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldCNAmt" CssClass="count" runat="server" Text='<%#Eval("CNAmt","{0:0.00}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='CB' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblclosingbalance" CssClass="count" runat="server" Text='<%#Eval("closingbalance","{0:0.00}")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='PP' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpreprimary" CssClass="count" runat="server" Text='<%#Eval("PP")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='PR' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPR" CssClass="count" runat="server" Text='<%#Eval("PR")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText='SEC' HeaderStyle-BackColor="#999999" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSEC" CssClass="count" runat="server" Text='<%#Eval("SEC")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <asp:ValidationSummary ID="Summary1" runat="server" ShowMessageBox="true" ShowSummary="false"
        ValidationGroup="S" />
    <CR:CrystalReportViewer ID="multiyearReportview" runat="server" AutoDataBind="true"
         EnableDatabaseLogonPrompt="false" EnableDrillDown="true"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="True"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="false" HasToggleGroupTreeButton="True"  HasZoomFactorList="false"
        Height="1039px" Width="773px" />
</asp:Content>
