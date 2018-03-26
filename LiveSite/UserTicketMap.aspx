<%@ Page Title="User Mapping" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="UserTicketMap.aspx.cs" Inherits="UserTicketMap" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       User Ticket Mapping<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <asp:Panel ID="pnlra" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
            </div>
        </div>
    </asp:Panel>
    <div class="options">
    </div>
</div>
    <asp:UpdatePanel ID="Uppanel" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <asp:Panel ID="Pnel" runat="server">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="label" runat="server" Text="Users"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUser" Width="250px" runat="server"></asp:TextBox>
                            <ajaxCt:AutoCompleteExtender ID="Emp_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtUser"
                                UseContextKey="true" ContextKey="empCode" CompletionListElementID="DisEmp">
                            </ajaxCt:AutoCompleteExtender>
                            <div id="DisEmp" style="width: 170px" class="divauto350">
                            </div>
                        </td>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="submitbtn" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="submitbtn" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <asp:Panel ID="PanelGrid" runat="server" ScrollBars="Vertical" Style="Height: 420px; width: 92%; margin-left: 9%;">
                <asp:GridView ID="usergrid" runat="server" AutoGenerateColumns="False" AlternatingRowStyle-CssClass="alt"
                    CellPadding="4" CssClass="product-table">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="chkid" runat="server" Style="display: none" Text='<%#Eval("SuperZoneID") %>'></asp:Label>
                                <asp:CheckBox ID="ChkVal" runat="server" Text='<%#Eval("SuperZoneName")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>


</asp:Content>

