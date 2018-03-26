<%@ Page Title="Book Set Limit" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="BooksetLimit.aspx.cs" Inherits="SpecimanMaster" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
       
        .panelDetail
        {
            border: 1px solid #9C9C9C;
            background-color: #EEE;
            width: 496px;
            padding: 1.5em 18px;
            background: #008800;
            background: -moz-linear-gradient(top, #BDBDBD, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#BDBDBD), to(#9C9C9C));
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       Book Set Limit<a href="Campaigns.aspx" title="back to campaign list"></a>
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

    <asp:UpdatePanel ID="HeaderUpdate" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PanelId" runat="server" CssClass="panelDetail">
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblmrcode">M.R Code</asp:Label>
                            <asp:TextBox ID="txtMRCode" runat="server" CssClass="inp-form" OnTextChanged="txtMRCode_TextChanged" onfocus="FocusIn()" AutoPostBack="true" style="width: 250px" TabIndex="1"></asp:TextBox>
                            <ajaxCt:AutoCompleteExtender ID="Title_Get" runat="server" CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtMRCode"
                                UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvcust">
                            </ajaxCt:AutoCompleteExtender>
                            <div id="dvcust" class="divauto350">
                            </div>
                        </td>
                        <td>
                            <asp:Button Text="Save" ID="btn_Save" CssClass="submitbtn" runat="server" OnClick="btn_Save_Click" style="width: 80px"/>
                        </td>
                    </tr>
                </table>
                </asp:Panel>
                <asp:GridView ID="grdBookset" Visible="false" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="3" Width="535" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true">
                <Columns>
                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Key")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Limit" HeaderStyle-Width="10px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:TextBox ID="lbllimit" runat="server" style="width:40px"  Text='<%#Eval("Limit")%>' onkeypress="return CheckNumeric(event)" />
                        </ItemTemplate>
                        <HeaderStyle Width="10px" />
                        <ItemStyle HorizontalAlign="Center"/>
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="alt" />
            </asp:GridView>
                   <asp:Button Text="Save" ID="btndownsave" Visible="false" CssClass="submitbtn" runat="server" OnClick="btn_Save_Click" style="width: 80px"/>
            </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function FocusIn()
        {
            $('#<%=txtMRCode.ClientID%>').val('');
        }
    </script>

</asp:Content>

