<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_PendingDC.ascx.cs" 
    Inherits="UserControls_ODC_uc_PendingDC" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Transaction > ORDER > Pending D. C. </a>
    </div>
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
</div>
<table width="90%">
    <tr>
        <td width="70%" valign="top">
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
            <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server">
                <table>
                    <asp:RadioButtonList ID="RdlView" runat="server" RepeatDirection="Horizontal" CssClass="lbl-form"
                        Width="300px" OnSelectedIndexChanged="RdlView_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="DeliveryDate" Text="  Date Wise"></asp:ListItem>
                        <asp:ListItem Value="Customer" Text="  Customer Wise"></asp:ListItem>
                        <asp:ListItem Value="City" Text="  City Wise "></asp:ListItem>
                        <asp:ListItem Value="All" Text="  All "></asp:ListItem>
                    </asp:RadioButtonList>
                </table>
                
                
            </asp:Panel>
            <br />
            <asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server">
                <asp:UpdatePanel ID="Upanelcust" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Customer Code" CssClass="lbl-form"></asp:Label>
                                    <font color="red">*</font>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="ddl-form" ID="DDLCustomer" DataTextField="CustName" DataValueField="CustID"
                                        runat="server" Width="300px" OnSelectedIndexChanged="DDLCustomer_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                                        InitialValue="none" ValidationGroup="DDlcust" ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnsearch" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlcust"
                                        Width="50px" OnClick="btnsearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="Pnldeldate" CssClass="panelDetails" runat="server">
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="From Date" CssClass="lbl-form"></asp:Label>
                                    <font color="red">*</font>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                        Enabled="true"></asp:TextBox>
                                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate"
                                        Format="dd/MM/yyyy" />
                                    <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtFromDate"
                                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                        AutoComplete="true" CultureName="en-US" />
                                    <asp:RequiredFieldValidator ID="Rqffdate" runat="server" ErrorMessage="Require From Date"
                                        InitialValue="none" ValidationGroup="DDlDeldate" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="To Date" CssClass="lbl-form"></asp:Label><font
                                        color="red">*</font> &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                                        Enabled="true"></asp:TextBox>
                                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttoDate"
                                        Format="dd/MM/yyyy" />
                                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttoDate"
                                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                        AutoComplete="true" CultureName="en-US" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Require To Date"
                                        InitialValue="0" ValidationGroup="DDlDelDate" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnfind" runat="server" TabIndex="3" Text="Get" CssClass="submitbtn"
                                        ValidationGroup="DDlDelDate" Width="50px" OnClick="btnfind_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="pnlcity" CssClass="panelDetails" runat="server">
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="State" CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="ddl-form" ID="DDlstate" DataValueField="DMID" DataTextField="Name"
                                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDlstate_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require State"
                                        InitialValue="0" ValidationGroup="DDlArea" ControlToValidate="DDlstate">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="City" CssClass="lbl-form"></asp:Label>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList CssClass="ddl-form" ID="DDlCity" DataValueField="DMID" DataTextField="Name"
                                                Width="140px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDlCity_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DDlstate" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rqfzone" runat="server" ErrorMessage="Require City"
                                        InitialValue="0" ValidationGroup="DDlArea" ControlToValidate="DDlCity">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="findarea" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlArea"
                                        Style="display: none;" Width="50px" OnClick="findarea_Click" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <br />
            <asp:UpdatePanel ID="upOrderNO" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlconfirm" Height="100px" ScrollBars="Vertical" CssClass="panelDetails"
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
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="utpanel" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlDetails" runat="server">
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
                                <td width="110px">
                                    <span>email id :
                                        <label id="lblemailid" style="font-size: 12px; font-weight: bold"  runat="server">
                                        </label>
                                        
                                     </span>
                                </td>
                                <td width="110px">
                                    <span>
                                        
                                           <asp:Label ID="lblEmailAlert" runat="server"  Text="" Font-Bold="True"></asp:Label>
                                 </span>
                                </td>
                              
                            </tr>
                            <tr>
                                <%--<td>
                                        <span>Document Date :
                                            <label id="lbldcdate" style="font-size: 12px; font-weight: bold" runat="server">
                                            </label>
                                        </span>
                                    </td>--%>
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
                                    <asp:Label ID="lblemp" CssClass="lbl-form" runat="server" Text="Godown Team"></asp:Label>
                                </td>
                                <td width="110px" align="left">
                                    <asp:TextBox ID="txtempc" runat="server" onfocus="setfocus('salesman');" autocomplete="off"
                                        AutoPostBack="true" CssClass="inp-form" OnTextChanged="txtempc_TextChanged"></asp:TextBox>
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
                                        runat="server" Text="Confirm" Width="100px" 
                                        OnClientClick="javascript:Openpopup();"  />
                                    <asp:Button ID="btnPendingDC" Visible="true" runat="server" Text="PendingDC" CssClass="submitbtn"
                                        ToolTip="click to print" OnClick="btnPendingDC_Click" />
                                    <asp:Button ID="btnBookWice" Width="100px" CssClass="submitbtn" runat="server" Text="BookWise"
                                        OnClick="btnBookWice_Click" Style="display: none;" />
                                    <asp:Button ID="btnPrint" Visible="false" runat="server" Text="Print" CssClass="submitbtn"
                                        ToolTip="click to print" OnClick="btnPrint_Click" />
                                    <asp:Button ID="btnDocWice" CssClass="submitbtn"
                                            Width="100px" runat="server" Text="Print Without %" OnClick="btnDocWice_Click" />
					 <asp:Button ID="btnEmail" Visible="true"  runat="server" Text="Email" CssClass="submitbtn"
                                     ToolTip="Click to EMail"   onclick="btnEmail_Click" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td width="80px">
                                </td>
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
                                <asp:TemplateField HeaderText="HSN Code" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblHsnCode" runat="server" Text='<%#Eval("HSNCode")%>'></asp:Label>
                                        <asp:Label ID="lblGst" Style="display: none;" runat="server" Text='<%#Eval("GST")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                    <asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnconfirm1" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td width="20%" valign="top">
         
        </td>
         
    </tr>
</table>
<asp:Panel ID="PnlInsertDocNum" runat="server" DefaultButton="btnconfirm1" Style="display: none;
    text-align: left; width: 257px; height: 140px;">
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
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtBundles" Width="80px"  onkeypress="return CheckNumeric(event)" Style="text-align: right;" CssClass="lbl-txt"
                                                runat="server" Text="0"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtParcels" Width="80px" onkeypress="return CheckNumeric(event)" Style="text-align: right;" CssClass="lbl-txt"
                                                runat="server" Text="0"></asp:TextBox>
                                        </td>
                                        <td colspan="1" align="right">
                                            <asp:Button ID="btnconfirm1" CssClass="submitbtn" Width="57px" runat="server" ValidationGroup="get"
                                                Text="Ok" OnClick="btnconfirm_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="1" align="left">
                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="get"
                                        InitialValue="0" ControlToValidate="ddldocno">Select Document No.</asp:RequiredFieldValidator>--%>
                                        </td>
                                        <td colspan="1" align="right">
                                        </td>
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

<script>
    function setVal(id) {
       
        document.getElementById("ctl00_ContentPlaceHolder1_uc_PendingDC1_txtdocno").value = id;
        document.getElementById("ctl00_ContentPlaceHolder1_uc_PendingDC1_btnget").click();

    }
    function Openpopup() {

        $find('<%=ModpupConfirmation.ClientID %>').show();
        document.getElementById('<%=txtBundles.ClientID %>').focus();

    }
    function Closepopup() {

        $find('<%=ModpupConfirmation.ClientID %>').hide();

    }


    shortcut.add("esc", function() {

        Closepopup()
    });
    shortcut.add("Ctrl+S", function() {

        Openpopup();
    });

    setTimeout("setSatus()", 2000);
    function setSatus() {
        var status = "[ Ctrl+S : Confirm Dc ] ";
        document.getElementById('status').innerHTML = status;

    }
</script>

<script type="text/javascript">


    $(document).ready(function() {
        // Initialize jQuery keyboard navigation
        $('.menuKey a').keynav('keynav_focusbox', 'keynav_box');

        // Set the first div as the one with focus, this is optional
        //$('.menuKey a:first').removeClass().addClass('keynav_focusbox');

        // Initialize jQuery keyboard navigation
        // $('#demo2 div').keynav('keynav_focusbox','keynav_box');

        // Set the first div as the one with focus, this is optional
        // $('#demo2 div:first').removeClass().addClass('keynav_focusbox')
    });
      


</script>
<div id="divmail" Visible ="false">
<asp:GridView ID="grdconfirm1" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                            AutoGenerateColumns="false" runat="server" Visible ="false" >
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

