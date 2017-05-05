<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="CNFPending.aspx.cs" Inherits="CNFPending" Title="CnF Pending DC" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <style type="text/css">
        .panelDetailsNew
        {
            border: 1px solid #9C9C9C;
            background-color: #EEE;
            width: 346px;
            padding: 1.5em 18px;
            background: #008800;
            background: -moz-linear-gradient(top, #BDBDBD, #9C9C9C);
            background: -webkit-gradient(linear, left top, left bottom, from(#BDBDBD), to(#9C9C9C));
        }
    </style>
    <div class="section-header">
        <div class="title">
            <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
            CnF Pending DC <a href="Campaigns.aspx" title="back to campaign list"></a>
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
   
    <asp:Panel ID="Pnd" CssClass="panelDetailsNew" DefaultButton="btnGetData" runat="server">
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="DDLCnf" DataTextField="CnFName" DataValueField="cnfid" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="DDLCNFReq" Style="display: none;" runat="server"
                        InitialValue="0" ErrorMessage="Kindly Select CnF from the list" ValidationGroup="V" ControlToValidate="DDLCnf">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="lblStar" runat="server" Style="color: Red">*</asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnGetData" OnClick="btnGetData_click" runat="server" CssClass="submitbtn"
                        Text="Get" ValidationGroup="V" Style="width: 200%" />
                </td>
                <td>
                    <asp:ValidationSummary ID="validation" runat="server" ShowMessageBox="true" ShowSummary="false"
                        ValidationGroup="V" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div class="options">
        <table>
            <tr>
                <td width="100px" style="display: none;">
                    <asp:Label ID="Label1" runat="server" Text="Document No."></asp:Label>
                </td>
                <td width="100px" style="display: none">
                    <asp:TextBox ID="txtdocno" Width="80px" runat="server" MaxLength="10"></asp:TextBox>
                </td>
                <td style="display: none">
                    <asp:RequiredFieldValidator ID="reqbook" runat="server" ErrorMessage="Require Document No."
                        ValidationGroup="confirm" ControlToValidate="txtdocno">.</asp:RequiredFieldValidator>
                </td>
                <td width="100px" style="display: none">
                    <asp:Button ID="btnget" CssClass="submitbtn" runat="server" Width="80px" Text="Get"
                        OnClick="btnget_Click" />
                </td>
            </tr>
        </table>
    </div>
    <table width="90%">
        <tr>
            <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <td width="100%" valign="top">
                <asp:UpdatePanel ID="upOrderNO"  UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="pnlconfirm" Visible="false" Height="100px" ScrollBars="Vertical" CssClass="panelDetails"
                            runat="server">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Repeater ID="Rptrpending" runat="server">
                                            <ItemTemplate>
                                                <a class='<%#Eval("classPending")%>' href='<%#"javascript:setVal("+Eval("DocumentNo")+")" %>'>
                                                    <%#Eval("DocumentNo") %></a>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnGetData" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="utpanel" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:Panel ID="pnlDetails" runat="server" Style="width: 160%">
                            <table id="tblNo" runat="server">
                                <tr>
                                    <td width="110px">
                                        <span>Document No :
                                            <label id="docno" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                    <td width="210px">
                                        <span>M.R. Name :
                                            <label id="lblempname1" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                    <td width="450px">
                                        <span>Customer Name :
                                            <label id="lblcustname" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="110px" style="display: none">
                                        <span>email id :
                                            <label id="lblemailid" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                    <td width="110px">
                                        <span>
                                            <asp:Label ID="lblEmailAlert" runat="server" Text="" Font-Bold="True"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <label id="lblmessage" style="font-size: 12px; font-weight: bold" runat="server">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" id="tblDate" runat="server">
                                <tr>
                                    <td colspan="2">
                                        <span>Document Date :
                                            <label id="lbldcdate" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                    <td colspan="3">
                                        <span>Order Date :
                                            <label id="lblorder" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80px">
                                        <asp:Label ID="lblemp" CssClass="lbl-form" runat="server" Text="Godown Team" Style="display: none"></asp:Label>
                                    </td>
                                    <td width="110px" align="left">
                                        <asp:TextBox ID="txtempc" runat="server" onfocus="setfocus('salesman');" autocomplete="off"
                                            Style="display: none" AutoPostBack="true" CssClass="inp-form" OnTextChanged="txtempc_TextChanged"></asp:TextBox>
                                        <div id="dvCode" class="divauto">
                                        </div>
                                        <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                            CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                            ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                            CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtempc"
                                            UseContextKey="true" ContextKey="team" CompletionListElementID="dvCode">
                                        </ajaxCt:AutoCompleteExtender>
                                    </td>
                                    <td align="left" width="80px">
                                        <asp:Label ID="Lblremark" runat="server" Text="Remark"></asp:Label>
                                    </td>
                                    <td align="left" width="245px">
                                        <asp:TextBox ID="txtremark" runat="server" CssClass="inp-form" TextMode="MultiLine"
                                            Width="242px" Height="15px"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnconfirm" Enabled="false" CssClass="submitbtn" Visible="false"
                                            runat="server" Text="Confirm" Width="100px" OnClientClick="javascript:Openpopup();" />
                                        <asp:Button ID="btnPendingDC" Visible="true" Style="display: none" runat="server"
                                            Text="PendingDC" CssClass="submitbtn" ToolTip="click to print" OnClick="btnPendingDC_Click" />
                                        <asp:Button ID="btnBookWice" Width="100px" CssClass="submitbtn" runat="server" Text="BookWise"
                                            OnClick="btnBookWice_Click" Style="display: none;" />
                                        <asp:Button ID="btnPrint" Visible="false" runat="server" Text="Print" CssClass="submitbtn"
                                            ToolTip="click to print" OnClick="btnPrint_Click" />
                                        <asp:Button ID="btnDocWice" CssClass="submitbtn" Width="100px" runat="server" Text="Print Without %"
                                            OnClick="btnDocWice_Click" />
                                        <asp:Button ID="btnEmail" Visible="true" runat="server" Text="Email" CssClass="submitbtn"
                                            Style="display: none" ToolTip="Click to EMail" OnClick="btnEmail_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="80px"></td>
                                    <td align="left" colspan="4" width="250px">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lblEmpName" runat="server" CssClass="lbl-form" Font-Size="15px" ForeColor="Blue"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="TxtEmpCode" EventName="TextChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <span>Sp. Instruction :
                                            <label id="lblspinstruction" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="grdconfirm" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                                AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblbook" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                                            <asp:Label ID="lblDCdatils" Style="display: none;" runat="server" Text='<%#Eval("DCDetailID")%>'></asp:Label><asp:Label
                                                ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Book Name" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblqty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblprice" Style="text-align: right;" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeliveryDate" Style="text-align: right;" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="40px" ItemStyle-Width="40px"
                                        ItemStyle-HorizontalAlign="right">
                                        <ItemTemplate>
                                            <asp:TextBox ID="lblavailable" Enabled='<%#Convert.ToBoolean(Eval("Enabled"))%>'
                                                MaxLength="5" onkeypress="return CheckNumeric(event)" onkeyup='<%#"javascript:MaxordNum(this,"+Eval("RemainQty")+")"%>'
                                                CssClass="lbl-txt" Style="text-align: right;" runat="server" Width="40px" Text='<%#Eval("RemainQty") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <%--<asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />--%>
                        <asp:AsyncPostBackTrigger ControlID="btnconfirm1" EventName="Click"></asp:AsyncPostBackTrigger>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="btnconfirm1" Style="display: none; text-align: left; width: 257px; height: 140px;">
        <div class="facebox" width="257px">
            <asp:Label ID="Label9" runat="server" Style="float: left; font-size: 11px; font-weight: bold"
                ForeColor="White"></asp:Label>
            <a id="A1" class="close" runat="server" href="javascript:void(0);" onclick="Closepopup();">
                <img src="Images/button-cross.png" /></a>
            <br />
            <div class="content" width="275px">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBundle" runat="server" Font-Bold="true" Font-Size="12px" Text="Bundles : "
                                                    CssClass="lbl-form"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDocNo" runat="server" Font-Bold="true" Font-Size="12px" Text="Parcel : "
                                                    CssClass="lbl-form"></asp:Label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtBundles" Width="80px" onkeypress="return CheckNumeric(event)"
                                                    Style="text-align: right;" CssClass="lbl-txt" runat="server" Text="0"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtParcels" Width="80px" onkeypress="return CheckNumeric(event)"
                                                    Style="text-align: right;" CssClass="lbl-txt" runat="server" Text="0"></asp:TextBox>
                                            </td>
                                            <td colspan="1" align="right">
                                                <asp:Button ID="btnconfirm1" CssClass="submitbtn" Width="57px" runat="server" ValidationGroup="get"
                                                    Text="Ok" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="1" align="left">
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="get"
                                        InitialValue="0" ControlToValidate="ddldocno">Select Document No.</asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td colspan="1" align="right"></td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <table style="display: none;">
        <tr>
            <td>
                <asp:Label ID="LablEmpCode" runat="server" Text="Emp Code"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtEmpCode" runat="server" OnTextChanged="TxtEmpCode_TextChanged"></asp:TextBox>
            </td>
        </tr>
    </table>
    <ajaxCt:ModalPopupExtender ID="ModpupConfirmation" runat="server" TargetControlID="LnkBtn"
        PopupControlID="PnlInsertDocNum" OkControlID="A1" BackgroundCssClass="modalBackground"
        DropShadow="false" EnableViewState="false" />
    <asp:LinkButton ID="LnkBtn" runat="server" Style="display: none;">LinkButton</asp:LinkButton>

    <script type="text/javascript">
        function setVal(id) {

            document.getElementById("ctl00_ContentPlaceHolder1_txtdocno").value = id;
            document.getElementById("ctl00_ContentPlaceHolder1_btnget").click();

        }
        function Openpopup() {

            $find('<%=ModpupConfirmation.ClientID %>').show();
            document.getElementById('<%=txtBundles.ClientID %>').focus();

        }
        function Closepopup() {

            $find('<%=ModpupConfirmation.ClientID %>').hide();

        }


        shortcut.add("esc", function () {

            Closepopup()
        });
        shortcut.add("Ctrl+S", function () {

            Openpopup();
        });

        setTimeout("setSatus()", 2000);
        function setSatus() {
            var status = "[ Ctrl+S : Confirm Dc ] ";
            document.getElementById('status').innerHTML = status;

        }
    </script>

    <script type="text/javascript">


        //$(document).ready(function () {
        //    // Initialize jQuery keyboard navigation
        //    $('.menuKey a').keynav('keynav_focusbox', 'keynav_box');

        //    // Set the first div as the one with focus, this is optional
        //    //$('.menuKey a:first').removeClass().addClass('keynav_focusbox');

        //    // Initialize jQuery keyboard navigation
        //    // $('#demo2 div').keynav('keynav_focusbox','keynav_box');

        //    // Set the first div as the one with focus, this is optional
        //    // $('#demo2 div:first').removeClass().addClass('keynav_focusbox')
        //});



    </script>

    <div id="divmail" visible="false">
        <asp:GridView ID="grdconfirm1" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
            AutoGenerateColumns="false" runat="server" Visible="false">
            <Columns>
                <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                    <ItemTemplate>
                        <asp:Label ID="lblbook" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                        <asp:Label ID="lblDCdatils" Style="display: none;" runat="server" Text='<%#Eval("DCDetailID")%>'></asp:Label><asp:Label
                            ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Book Name" HeaderStyle-Width="120px">
                    <ItemTemplate>
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Standard" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medium" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblMedium" runat="server" Text='<%#Eval("Medium")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lblqty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lblprice" Style="text-align: right;" runat="server" Text='<%#Eval("Rate","{0:0.00}")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delivery Date" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lblDeliveryDate" Style="text-align: right;" runat="server" Text='<%#Eval("DeliveryDate")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="40px" ItemStyle-Width="40px"
                    ItemStyle-HorizontalAlign="right">
                    <ItemTemplate>
                        <asp:Label ID="lblDeliveryDate" Style="text-align: right;" runat="server" Text='<%#Eval("RemainQty")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
