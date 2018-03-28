<%@ Page Title="CNF Book Stock" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CNFBookStock.aspx.cs" Inherits="CNFBookStock" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                CNF Book Stock<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" DefaultButton="btnGet" Width="770px">
        <table>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="DDLCNFReq" runat="server"
                        InitialValue="0" ErrorMessage="Kindly Select CnF from the list" ValidationGroup="V"
                        ControlToValidate="DDLCnf">*</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="DDLCnf" TabIndex="1" DataTextField="CnFName" DataValueField="cnfid"
                        runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lblBook" runat="server" Text="Book Name"></asp:Label>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required book type" ControlToValidate="txtbook"
                        ValidationGroup="V">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtbook" runat="server" autocomplete="off"
                        CssClass="inp-form" onblur="customerName(this);" onfocus="Clear();"
                        TabIndex="2" Width="238px"></asp:TextBox>
                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                        CompletionListCssClass="AutoExtender" CompletionListElementID="divwidth" CompletionListHighlightedItemCssClass="AutoExtenderHighlight"
                        CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" ContextKey="book"
                        DelimiterCharacters="" EnableCaching="false" Enabled="True" MinimumPrefixLength="1"
                        ServiceMethod="GetCodes" ServicePath="~/AutoComplete.asmx" TargetControlID="txtbook"
                        UseContextKey="true">
                    </ajaxCt:AutoCompleteExtender>
                </td>
                <td>
                    <asp:Button ID="btnGet" ValidationGroup="V" TabIndex="3" OnClick="btnGet_Click" CssClass="submitbtn" Width="80px" runat="server" Text="Get" />
                </td>
                <td>
                    <asp:ValidationSummary runat="server" ShowSummary="false" ShowMessageBox="true" ValidationGroup="V" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblBookName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                        runat="server"></asp:Label>
                </td>

            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="panelGrid" runat="server">
        <CR:CrystalReportViewer ID="BookStokeReport" runat="server" AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
            HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
            HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
            Width="773px" ClientTarget="Auto" HasCrystalLogo="False" />
    </asp:Panel>
    <script type="text/javascript">
        function Clear() {
            document.getElementById("<%=txtbook.ClientID%>").value = "";
        }

        function customerName(val) {
            var data = $(val).val();
            var splits = data.split("::");
            if (splits.length > 1) {
                $(val).val(splits[0].toString().trim());
                $('#<%=lblBookName.ClientID %>').text(data);
            }

        }
    </script>
</asp:Content>

