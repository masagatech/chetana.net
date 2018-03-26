<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Token_Register_View.aspx.cs" Inherits="Token_Register_View" Title="Token Register View" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .TextBoxWodth
        {
            width: 60px;
        }
        .TextBoxWodths
        {
            width: 84px;
        }
        .panelDetail
        {
            border: 1px solid #9C9C9C;
            background-color: #EEE;
            width: 993px;
            padding: 1.5em 18px;
            background: #008800;
            background: -moz-linear-gradient(top, #BDBDBD, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#BDBDBD), to(#9C9C9C));
        }
        .submitbtn
        {
            margin-top: 10px;
            color: #FFFFFF;
            font: 12px ARIAL;
            background-color: #fed;
            padding: 2px;
            border: 1px solid #9C9C9C;
            background: #008800;
            background: -moz-linear-gradient(top, #C6C6C6, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#C6C6C6), to(#9C9C9C));
            -webkit-box-shadow: 0 8px 15px rgba(0, 0, 0, 0.7);
            -webkit-box-shadow: 0 2px 2px rgba(0, 0, 0, 0.7);
            -webkit-box-shadow: 0 2px 2px rgba(0, 0, 0, 0.7);
        }
        .ddlReceiveWidth
        {
            width: 100%;
        }
        .customercss
        {
            width: 205px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
       View Token Register<a href="Campaigns.aspx" title="back to campaign list"></a>
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
    <%--<asp:UpdatePanel ID="KycAndDateWise" runat="server">
        <ContentTemplate>--%>
    <table>
        <tr>
            <td>
                <asp:RadioButton ID="rbtnToken" AutoPostBack="true" runat="server" Text="Token No"
                    GroupName="TokenRadio" OnCheckedChanged="rbtnKyc_CheckedChanged" />
                <asp:RadioButton ID="rbtnKyc" AutoPostBack="true" runat="server" Text="Kyc No" GroupName="TokenRadio"
                    OnCheckedChanged="rbtnKyc_CheckedChanged" />
                <asp:RadioButton ID="rbtDatewise" runat="server" AutoPostBack="true" Text="Date Wise"
                    GroupName="TokenRadio" OnCheckedChanged="rbtnKyc_CheckedChanged" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Panel ID="TokenWise" runat="server">
                    <asp:Label ID="Label1" runat="server" Text="Token No"></asp:Label>
                    <asp:TextBox ID="txtTokenFind" CssClass="TextBoxWodth" runat="server" TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required Token No"
                        ValidationGroup="Token" ControlToValidate="txtTokenFind">.</asp:RequiredFieldValidator>
                    <asp:Button ID="btnToken" runat="server" CssClass="submitbtn" Text="Get" Width="53px"
                        OnClick="Get_Click" ValidationGroup="Token" TabIndex="2" />
                        <asp:Button ID="btnPrintToken" runat="server" CssClass="submitbtn" Text="Print" TabIndex="3"
                        Width="53px" OnClick="btnPrintChecked_Click"/>
                </asp:Panel>
                <asp:Panel ID="KycNoWise" runat="server" Visible="false">
                    <asp:Label ID="lblKycFind" runat="server" Text="Kyc No"></asp:Label>
                    <asp:TextBox ID="txtKycFind" CssClass="TextBoxWodth" runat="server" TabIndex="4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Kyc No"
                        ValidationGroup="Kyc" ControlToValidate="txtKycFind">.</asp:RequiredFieldValidator>
                    <asp:Button ID="kycbtnGet" runat="server" CssClass="submitbtn" Text="Get" Width="53px" TabIndex="5"
                        OnClick="Get_Click" ValidationGroup="Kyc" />
                         <asp:Button ID="btnPrintKycNo" runat="server" CssClass="submitbtn" Text="Print" TabIndex="6"
                        Width="53px" OnClick="btnPrintChecked_Click"/>
                </asp:Panel>
                <asp:Panel ID="DateWise" runat="server" Visible="false">
                    <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                    <asp:TextBox ID="txtFromDate" runat="server" CssClass="TextBoxWodths" TabIndex="7"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required From Date"
                        ValidationGroup="V" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                    <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                    <asp:TextBox ID="txtToDate" runat="server" CssClass="TextBoxWodths" TabIndex="8"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtToDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtToDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required To Date"
                        ValidationGroup="V" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                    <asp:Button ID="btnGet" runat="server" CssClass="submitbtn" Text="Get" Width="53px" TabIndex="9"
                        OnClick="Get_Click" ValidationGroup="V" />
                    <asp:Button ID="btnPrintDateWise" runat="server" CssClass="submitbtn" Text="Print" TabIndex="10"
                        Width="53px" OnClick="btnPrintChecked_Click"/>
                    
                </asp:Panel>
            </td>
            <td>
            <%--<asp:Button ID="btnPrintChecked" runat="server" CssClass="submitbtn" Text="Print"
                        Width="53px" OnClick="btnPrintChecked_Click" />--%>
            </td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="V" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary2" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="Kyc" runat="server" />
                <asp:ValidationSummary ID="ValidationSummary3" ShowMessageBox="true" ShowSummary="false"
                    ValidationGroup="Token" runat="server" />
            </td>
        </tr>
    </table>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <br />
    <asp:UpdatePanel ID="UpGridData" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grdTokenRegister" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="8" Width="1025px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true" OnRowEditing="grdTokenRegister_RowEditing" OnSelectedIndexChanged="grdTokenRegister_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="Selected" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%--<asp:ImageButton ID="btnEdits" ImageUrl="~/Images/icon/edit_Icon.png" runat="server"
                                OnClick="btnEdits_Click" />
                            <asp:ImageButton ID="btnRemove" ImageUrl="~/Images/icon/DeleteIcon.gif" OnClick="btnRemove_Click"
                                OnClientClick="return confirm('Are you sure want to remove this book');" runat="server" />--%>
                            <asp:CheckBox ID="gridChk" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Token No" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTokenNo" runat="server" Text='<%#Eval("TokenNo")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kyc No" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTokenId" Style="display: none;" runat="server" Text='<%#Eval("TokenNo")%>'></asp:Label>
                            <asp:Label ID="lblKycNo" runat="server" Text='<%#Eval("KYC_No")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Received Date" HeaderStyle-Width="50px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblOrderRecDate" runat="server" Text='<%#Eval("Ord_Rec_Date")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cust Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomer" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Customer Name" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblDeliveryDate" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area Name" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblArea" runat="server" Text='<%#Eval("AreaName")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delivery Add." HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="40px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Received Via" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblReceived" runat="server" Text='<%#Eval("ReceivedVia")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order No" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblHanded" runat="server" Text='<%#Eval("HandOver")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("Remark")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                </Columns>
                <AlternatingRowStyle CssClass="alt" />
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGet" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="kycbtnGet" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
