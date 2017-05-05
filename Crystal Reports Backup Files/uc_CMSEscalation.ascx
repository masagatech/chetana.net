<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CMSEscalation.ascx.cs"
    Inherits="UserControls_CMSEscalation" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style type="text/css">
    .dashboard_Godown
    {
        float: left;
        position: relative;
        width: 200px;
        height: 84px;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        CMS Escalation<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
</div>
<asp:UpdatePanel ID="GodownUpdat" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pnlnew" runat="server" DefaultButton="btnGet" CssClass="panelDetails" Width="330px" Height="25px">
            <asp:Label ID="lblFromdate" runat="server" Text="From Date"></asp:Label>
            <asp:TextBox ID="txtFromDate" runat="server" TabIndex="1" Style="width: 73px;"></asp:TextBox>
            <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFromDate"
                Format="dd/MM/yyyy" />
            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                AutoComplete="true" CultureName="en-US" />
            <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
            <asp:TextBox ID="txtTodate" runat="server" TabIndex="2" Style="width: 73px;"></asp:TextBox>
            <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTodate"
                Format="dd/MM/yyyy" />
            <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTodate"
                MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                AutoComplete="true" CultureName="en-US" />
            <asp:Button ID="btnGet" runat="server" CssClass="submitbtn" Text="Get" Width="53px" TabIndex="3"
                OnClick="btnGet_click" />
        </asp:Panel>
        <br />
        <asp:UpdatePanel ID="upDashBoard" runat="server">
            <ContentTemplate>
                <div class="dashboard_Godown">

                    <asp:DataList ID="DLDashboard1" Visible="false" CellPadding="0" runat="server" RepeatColumns="4">
                        <ItemTemplate>
                            <div id="Div1" class="dashboardback_edited" cssclass="panelDetails" runat="server">
                                <table border="0" width="90%" cellpadding="0">
                                    <tr>
                                        <td valign="bottom" align="left">
                                            <%-- <asp:Label ID="Label2" CssClass="count1" runat="server" Text='<%#Eval("Header_Text")%>'></asp:Label>--%>
                                            <asp:LinkButton ID="Btnlink" runat="server" Style="text-decoration: none; color: #000;"
                                                OnClick="btnlink_Click" Text='<%#Eval("Header_Text")%>'><%#Eval("Header_Text")%></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-top: 08px;" align="center">
                                            <%--<span>--%>
                                            <asp:Label ID="Label1" CssClass="count1" runat="server" Text='<%#Eval("NoOfCount")%>'></asp:Label>
                                            <%--<asp:LinkButton ID="btnlink" runat="server" style="text-decoration:none;color:#000;" onclick="btnlink_Click"><%#Eval("NoOfCount")%></asp:LinkButton>--%>
                                            <%--<%#Eval("NoOfCount")%></span>--%>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>



                    <%--  <asp:DataList ID="DLDashboard2" CellPadding="0" runat="server" RepeatColumns="4">
            <ItemTemplate>
                <div id="Div1" class="dashboardback_edited" cssclass="panelDetails" runat="server">
                    <table border="0" width="90%" cellpadding="0">
                        <tr>
                            <td valign="bottom" align="left">
                                <asp:Label ID="Label1" CssClass="count1" runat="server" Text='<%#Eval("Header_Text")%>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding-top: 08px;" align="center">
                                <span>
                                    <%#Eval("NoOfCount")%></span>
                            </td>
                        </tr>
                    </table>
                </div>
            </ItemTemplate>
        </asp:DataList>--%>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGet" EventName="click" />
            </Triggers>
        </asp:UpdatePanel>
        <br />
        <asp:Panel ID="PnlAdd" CssClass="panelDetails" runat="server" Style="float: left; margin: 0 10px 7px 0; position: relative; width: 1085px;"
            Visible="false">
            <asp:Panel ID="pnlEmployeeDetails" CssClass="pnldash" runat="server">
                <asp:GridView ID="grdGodown" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                    AutoPostBack="true" CellPadding="4" CssClass="product-table" ForeColor="#333333"
                    Width="0px" AllowPaging="True" OnPageIndexChanging="grdEnquires_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="No" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbltktno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                <asp:Label ID="lblTktId" runat="server" Style="display: none" Text='<%#Eval("Tkt_ID")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LblDateCEmpLink_Date" runat="server" Text='<%#Eval("CEmpLink_Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ticket No" HeaderStyle-Width="60px" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lbltktnoTktNumber" runat="server" Text='<%#Eval("TktNumber") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cust Code" HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblcustnmCustCode" runat="server" Text='<%#Eval("CustCode") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cust Name" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblcustnm2" runat="server" Text='<%#Eval("CustName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText="Area" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="LblinType" runat="server" Text='<%#Eval("AreaCode ") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="Address" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="lblSvType" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Inquiry Remraks" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LblStypeRemarks" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText=" Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="LblDateStatus_Name" runat="server" Text='<%#Eval("Status_Name") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="Severity" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="LblSeverity" runat="server" Text='<%#Eval("Severity") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="CBD Representative" HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:Label ID="LblDateFirstName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remark" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" TextMode="MultiLine" runat="server" Style="width: 409px"
                                    Text='<%#Eval("GodRemarks") %>' />
                                <asp:Label ID="lblRemark" runat="server" Style="display: none" Text='<%#Eval("GodRemarks") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Save" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnSave" ImageUrl="~/Images/icon/save_as.png" runat="server"
                                    OnClick="btnSave_Click" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkView" runat="server" Text="View Details" OnClick="lnkView_Click"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Panel ID="Panel3" Style="display: none; width: 80%; height: 400px" runat="server">
    <div class="facebox" style="width: 100%; height: 390px;">
        <a id="A4" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup(4);">
            <img src="Images/button-cross.png" /></a>
        <br />
        <div class="content" style="width: 97%; height: 347px; overflow: auto; display: block;">
            <asp:UpdatePanel ID="UpdatePanel15" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <itemtemplate>
               <div class="actiontab" style="margin-bottom: 2px;">
                                <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                    <asp:GridView ID="popGridview" runat="server" AllowSorting="false" 
                                        AutoGenerateColumns="False" AutoPostBack="true" HeaderStyle-BackColor="#6788BE" 
                                        Width="100%">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="TKTID" runat="server" Text='<%#Eval("TKT_ID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="InquiryDate" runat="server" Text='<%#Eval("CEmpLink_Date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Remarks">
                                                <ItemTemplate>
                                                    <asp:Label ID="Remarks" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="EmpName">
                                                <ItemTemplate>
                                                    <asp:Label ID="EmpName" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                            </table>
                            </div>  
         </itemtemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Panel>
<ajaxCt:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="LinkButton5"
    PopupControlID="Panel3" BackgroundCssClass="modalBackground" DropShadow="false"
    EnableViewState="false" />
<asp:LinkButton ID="LinkButton5" runat="server" Style="display: none;">LinkButton</asp:LinkButton>

<script type="text/javascript">
    $(document).ready(function () {
        //hide the all of the element with class msg_body
        $(".msg_body").show();
        //toggle the componenet with class msg_body
        $(".msg_head").click(function () {
            $(this).next(".msg_body").toggle();
        });
    }); d

    function pageLoad(sender, args) {


        //toggle the componenet with class msg_body
        $(".msg_head").click(function () {
            $(this).next(".msg_body").toggle();
        });
    }
</script>

<script type="text/javascript">
    function Closepopup(id) {

        if (id == 4) {
            $find('<%=ModalPopupExtender2.ClientID %>').hide();
        }

    }
</script>

