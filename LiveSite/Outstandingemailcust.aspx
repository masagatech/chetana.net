<%@ Page Title="Outstanding Auto email to customer" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Outstandingemailcust.aspx.cs" Inherits="Outstandingemailcust" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            Outstanding Auto email to customer<a href="Campaigns.aspx" title="back to campaign list"></a>
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
    <asp:Panel ID="panelDetails" runat="server" CssClass="panelDetails" Height="40px" Width="735px">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lable1" runat="server">cc</asp:Label>
                    <asp:Label ID="lblId" runat="server" Style="display: none">0</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcc" runat="server" TabIndex="1"></asp:TextBox>
                    <asp:Label ID="label3" runat="server" Style="color: red">*</asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Style="display: none" ErrorMessage="Please Enter Amount" runat="server" ValidationGroup="V" ControlToValidate="txtcc">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:RadioButton ID="rbtnSendTo" GroupName="SendTo" runat="server" TabIndex="2" Text="Send To" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="label2" runat="server">Email Ids</asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmailIds" runat="server" TextMode="MultiLine" TabIndex="3" Style="width: 700px; height: 189px;"></asp:TextBox>
                    <asp:Label ID="label1" runat="server" Style="color: red">*</asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Style="display: none" ErrorMessage="Please Enter Email " runat="server" ValidationGroup="V" ControlToValidate="txtEmailIds">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" TabIndex="4" Style="width: 115px;" CssClass="submitbtn" ValidationGroup="V" />
                </td>
                <td>
                    <asp:ValidationSummary ID="Validation" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="V" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        $('input[id=ctl00_ContentPlaceHolder1_rbtnSendTo]').click(function () {
            if (this.previous) {
                this.checked = false;
            }
            this.previous = this.checked;
        });
    </script>
</asp:Content>

