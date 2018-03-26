<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OutstandingAutoEmail.ascx.cs"
    Inherits="UserControls_OutstandingAutoEmail" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Outstanding Auto email Configuration<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:UpdatePanel ID="uppanel" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnDetails" runat="server" DefaultButton="btnsave">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblFlag" runat="server">Amount</asp:Label>
                        <asp:Label ID="lblId" runat="server" Style="display: none">0</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server" style="text-align:right" TabIndex="1" onkeypress="return CheckNumeric(event)"></asp:TextBox>
                        <asp:TextBox ID="txtCC" Visible="false" runat="server" TabIndex="1"></asp:TextBox>
                        <asp:Label ID="label3" runat="server" Style="color: red">*</asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Style="display: none" ErrorMessage="Please Enter Amount" runat="server" ValidationGroup="V" ControlToValidate="txtAmount">
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
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnsave" EventName="Click" />
    </Triggers>
</asp:UpdatePanel>

<script type="text/javascript">
    $('input[id=ctl00_ContentPlaceHolder1_uc_CustomerMaster1_rbtnSendTo]').click(function () {
        if (this.previous) {
            this.checked = false;
        }
        this.previous = this.checked;
    });
</script>
