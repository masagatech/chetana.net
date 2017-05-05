<%@ Page Title="MultiPrint Pending DC" Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/NewChetana.master"
CodeFile="MultiPendingDC_Print.aspx.cs" Inherits="MultiPendingDC_Print" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
            MultiPrint PendingDC <a href="Campaigns.aspx" title="back to campaign list"></a>
        </div>
        <div class="options">
        </div>
    </div>
    <asp:Panel runat="server" ID="aa" DefaultButton="btnadd" CssClass="panelDetails">
       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPendingDCNo" autocomplete="off" TabIndex="19" CssClass="inp-form" runat="server"
                                Width="150px" onkeypress="return CheckNumericWithDot(event)"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtPendingDCNo"
                                WatermarkText="Enter PendingDC.No">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <div id="divwidth" class="divauto">
                            </div>


                              <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtPendingDCNo"
                                UseContextKey="true" ContextKey="MultiPendingDC" CompletionListElementID="divwidth">
                            </ajaxCt:AutoCompleteExtender>


                            
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnPrint" runat="server" CssClass="submitbtn" Text="Get" Width="70px"
                                OnClick="btnPrint_Click" Visible="false" />
                        </td>
                    </tr>
                </table>
           <%-- </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnadd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>--%>
    </asp:Panel>
    <asp:Button ID="btnadd" CssClass="form-submit" runat="server" ValidationGroup="Date"
        Text="Add" Width="70px" Style="display: none;" OnClick="btnadd_Click" />
    <br />
    <%--<asp:UpdatePanel ID="upGridInvData" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <asp:GridView runat="server" ID="grdinvDetails" CssClass="product-table" AutoGenerateColumns="False"
                AlternatingRowStyle-CssClass="alt" Width="80px" OnRowDeleting="grdinvDetails_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Pending DC.No">
                        <ItemTemplate>
                            <asp:Label ID="lblPendingDCNo" runat="server" Text='<%#Eval("PendingDCNo")%>'></asp:Label>
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
            
       <%-- </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnadd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnPrint" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
    
    <CR:CrystalReportViewer ID="CrptPendingDC" runat="server" AutoDataBind="true" 
                EnableDatabaseLogonPrompt="false" EnableDrillDown="false" EnableParameterPrompt="false"
                EnableTheming="false" HasDrillUpButton="false" HasCrystalLogo="False" HasPageNavigationButtons="true"
                HasRefreshButton="true" HasSearchButton="True"  HasZoomFactorList="false"
                Height="1039px" Width="773px" ShowAllPageIds="True" />
</asp:Content>
