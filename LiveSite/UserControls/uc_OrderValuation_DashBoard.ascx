<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_OrderValuation_DashBoard.ascx.cs"
    Inherits="UserControls_uc_OrderValuation_DashBoard" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<table border="0" width="900px">
    <tr>
        <td width="60%">
            <asp:Panel ID="pnldate" runat="server" CssClass="panelDetails" Width="500px">
                <table border="0" width="522px">
                    <tr>
                        <td>
                            <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="1" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <ajaxCt:TextBoxWatermarkExtender ID="txtWMFDate" runat="server" TargetControlID="txtfromDate"
                                WatermarkText="From Date">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require From Date"
                                ValidationGroup="dashboard" ControlToValidate="txtfromDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                Enabled="true"></asp:TextBox>
                            <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                                Format="dd/MM/yyyy" />
                            <ajaxCt:MaskedEditExtender ID="toDate" runat="server" TargetControlID="txttoDate"
                                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                AutoComplete="true" CultureName="en-US" />
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txttoDate"
                                WatermarkText="To Date">
                            </ajaxCt:TextBoxWatermarkExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To Date"
                                ValidationGroup="dashboard" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="3" runat="server"
                                DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" >
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" CssClass="submitbtn"
                                TabIndex="4" ValidationGroup="dashboard" Style="height: 26px" OnClick="btnget_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td width="40%">
            <table border="0" width="100%">
                <tr>
                    <td width="100px">
                        <asp:Label ID="lbltotalgross" runat="server" Text='<%#Eval("TotalGrossAmount","{0:0.00}")%>'
                            CssClass="OrderValuationcss"></asp:Label>
                    </td>
                    <td width="100px">
                        <asp:Label ID="lbltotalnet" runat="server" Text='<%#Eval("TotalNetAmount","{0:0.00}")%>'
                            CssClass="OrderValuationcss"></asp:Label>
                    </td>
                    <td width="100px">
                        <asp:Label ID="lblactulnet" runat="server" Text='<%#Eval("actualnetamount","{0:0.00}")%>'
                            CssClass="OrderValuationcss"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="dashboard"
    runat="server" ID="ss" />
<asp:DataList ID="DLDashboard" CellSpacing="2" CellPadding="0" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
    OnItemDataBound="DLDashboard_ItemDataBound">
    <ItemTemplate>
        <div class="dashBoardvaluation">
            <table border="2" width="100%" cellpadding="0">
                <tr>
                    <td valign="top" align="center" width="70px" style="background-color: #DDDDDD;">
                        <asp:LinkButton ID="lnkszname" runat="server" Text='<%#Eval("SZoneName")%>' CommandArgument='<%#Eval("SuperZoneId")%>'
                            CssClass="lnkbtnorder" OnClick="lnkszname_Click"></asp:LinkButton>
                        <asp:Label ID="lblSzname" runat="server" Text='<%#Eval("SZoneName")%>' Style="display: none"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GrdDashboard" runat="server" AutoGenerateColumns="false" CellPadding="4"
                            CaptionAlign="Bottom" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText='Gross' HeaderStyle-BackColor="#999999">
                                    <ItemTemplate>
                                        <asp:Label ID="lblgrossamt" CssClass="countorder" runat="server" Text='<%#Eval("TotalGrossAmount","{0:0.00}")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='Net' HeaderStyle-BackColor="#999999">
                                    <ItemTemplate>
                                        <asp:Label ID="lblnetamt" CssClass="countorder" runat="server" Text='<%#Eval("TotalNetAmount","{0:0.00}")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <%--  <div class = "dashBoardvaluation">
        
            <table border="0" width="90%" cellpadding="0">
                <tr>
                    <td valign="top" width="70px" height="70px">
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("SZoneName")%>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Gross"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Net"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblgrossamt" CssClass="count" runat="server" Text='<%#Eval("TotalGrossAmount","{0:0.00}")%>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblnetamt" CssClass="count" runat="server" Text='<%#Eval("TotalNetAmount","{0:0.00}")%>'></asp:Label>
                    </td>
                </tr>
            </table>
        </div>--%>
    </ItemTemplate>
</asp:DataList>
<asp:Panel ID="pnlzone" runat="server">
    <div class="facebox" width="300px">
        <a id="A1" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup();">
            <img src="Images/button-cross.png" /></a>
        <div class="content" width="275px">
            <asp:GridView ID="GrdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                CaptionAlign="Bottom" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText='Zone' HeaderStyle-BackColor="#999999">
                        <ItemTemplate>
                            <asp:Label ID="lblZone" CssClass="grdLabel" runat="server" Text='<%#Eval("Zonename")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='Gross' HeaderStyle-BackColor="#999999">
                        <ItemTemplate>
                            <asp:Label ID="lblgrossamt" CssClass="grdLabel" runat="server" Text='<%#Eval("TotalGrossAmount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText='Net' HeaderStyle-BackColor="#999999">
                        <ItemTemplate>
                            <asp:Label ID="lblnetamt" CssClass="grdLabel" runat="server" Text='<%#Eval("TotalNetAmount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Panel>
<ajaxCt:ModalPopupExtender ID="modalPopupForZone" runat="server" TargetControlID="LinkBtn1"
    PopupControlID="pnlzone" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LinkBtn1" Style="display: none;" runat="server">LinkButton</asp:LinkButton>

<script type="text/javascript">

  function Openpopup()
   {
    
        $find('ctl00_ContentPlaceHolder1_uc_OrderValuation_DashBoard1_modalPopupForZone').show();
      //  document.getElementById('ctl00_ContentPlaceHolder1_uc_OrderValuation_DashBoard1_TxtDocNo').focus();
    
   }
   function Closepopup(id)
   {
    
        $find('ctl00_ContentPlaceHolder1_uc_OrderValuation_DashBoard1_modalPopupForZone').hide();
    
   }
</script>

