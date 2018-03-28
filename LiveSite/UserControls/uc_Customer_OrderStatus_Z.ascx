<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Customer_OrderStatus_Z.ascx.cs"
    Inherits="UserControls_uc_Customer_OrderStatus_Z" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<style>
    .nav_bar_link:focus
    {
        border: 1px solid green;
    }
</style>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span>Transaction > ORDER > Pending D. C.<a href="Campaigns.aspx"
            title="back to campaign list"> </a>
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
        <asp:Label ID="lblFY" runat="server" Text=""></asp:Label>
    </div>
</div>
<table width="90%">
    <tr>
        <td width="70%" valign="top">
            <br />
            <asp:Panel ID="Pnlcust" CssClass="panelDetails" runat="server">
                <table>
                    <tr>
                        <td valign="top">
                            <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="200px" DataTextField="SDZoneName"
                                DataValueField="SDZoneId" AutoPostBack="true" runat="server" TabIndex="1" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select Super Duper Zone"
                                InitialValue="0" ValidationGroup="AZone123" ControlToValidate="ddlSDZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td valign="top">
                            <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="2" runat="server"
                                DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="150px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                                InitialValue="0" ValidationGroup="AZone123" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:DropDownList ID="DDLZone" runat="server" TabIndex="3" AutoPostBack="True" CssClass="ddl-form"
                                DataTextField="ZoneName" DataValueField="ZoneID" Width="150px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
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
                                        runat="server" Width="300px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="Rqfcust" runat="server" ErrorMessage="Require Customer"
                                        InitialValue="none" ValidationGroup="DDlcust" ControlToValidate="DDLCustomer">.</asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnsearch" TabIndex="0" runat="server" Text="Get" CssClass="submitbtn"
                                        ValidationGroup="DDlcust" Width="50px" OnClick="btnsearch_Click" />
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
                                    <asp:Button ID="btnfind" runat="server" Text="Get" CssClass="submitbtn" ValidationGroup="DDlDelDate"
                                        Width="50px" OnClick="btnfind_Click" />
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
                                                Width="140px" runat="server">
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
                    <asp:Panel ID="Panel1" CssClass="panelDetails" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <asp:Panel ID="pnlconfirm" CssClass="pnldash" Width="300px" Height="300px" ScrollBars="Vertical"
                                        runat="server">
                                        <table>
                                            <tr>
                                                <td>
                                                    <%--  <div class="menuKey">--%>
                                                    <asp:Repeater ID="Rptrpending" runat="server">
                                                        <ItemTemplate>
                                                            <a class='<%#Eval("classPending")%>' tabindex="0" href='<%#"javascript:setVal("+Eval("DocumentNo")+")" %>'>
                                                                <%#Eval("DocumentNo") %></a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <%-- </div>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                                <td>
                                <img id="loadingimg" style="display:none; position:absolute;" src="Images/loading.gif" />
                                    <div id="result">
                                    </div>
                                    
                                    
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="utpanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Panel ID="pnlDetails" runat="server">
                        <div class="actiontab">
                            <table>
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
                                    <td colspan="3">
                                        <label id="lblmessage" style="font-size: 12px; font-weight: bold" runat="server">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <table width="100%">
                            <tr>
                                <td colspan="2">
                                    <span>Document Date :
                                        <label id="lbldcdate" style="font-size: 12px; font-weight: bold" runat="server">
                                        </label>
                                    </span>
                                </td>
                                <td width="450px">
                                    <span>Order Date :
                                        <label id="lblorder" style="font-size: 12px; font-weight: bold" runat="server">
                                        </label>
                                    </span>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td width="80px">
                                    <asp:Label ID="lblemp" CssClass="lbl-form" runat="server" Text="Godown Person"></asp:Label>
                                </td>
                                <td width="250px" align="left">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtempc" runat="server" onfocus="setfocus('salesman');" autocomplete="off"
                                                AutoPostBack="true" CssClass="inp-form" OnTextChanged="txtempc_TextChanged"></asp:TextBox>
                                            <div id="dvCode" class="divauto">
                                            </div>
                                            <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtempc"
                                                UseContextKey="true" ContextKey="salesman" CompletionListElementID="dvCode">
                                            </ajaxCt:AutoCompleteExtender>
                                            <asp:Label ID="lblEmpName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                                runat="server"></asp:Label></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Lblremark" runat="server" Text="Remark"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtremark" runat="server" CssClass="inp-form" TextMode="MultiLine"
                                        Width="300px" Height="30px"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnconfirm" Enabled="false" Style="display: none;" CssClass="submitbtn"
                                        Visible="false" runat="server" Text="Confirm" Width="100px" OnClick="btnconfirm_Click"
                                        OnClientClick="return confirm('Do you want to Confirm ?');" />
                                    <asp:Button ID="btnDocWice" Style="display: none;" CssClass="submitbtn" Visible="false"
                                        Width="100px" runat="server" Text="Document Wise" OnClick="btnDocWice_Click" />
                                    <asp:Button ID="btnBookWice" Style="display: none;" Width="100px" CssClass="submitbtn"
                                        runat="server" Text="BookWise" OnClick="btnBookWice_Click" />&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnPrint" Visible="false" runat="server" Text="Print" Style="float: right;
                                        display: none;" CssClass="submitbtn" ToolTip="click to print" OnClick="btnPrint_Click" />
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
                                        <asp:Label ID="lblDeliveryDate1" Style="text-align: right;" runat="server" Text='<%#Eval("RemainQty")%>'></asp:Label>
                                        <asp:TextBox ID="lblavailable" Enabled='<%#Convert.ToBoolean(Eval("Enabled"))%>'
                                            MaxLength="5" onkeypress="return CheckNumeric(event)" onkeyup='<%#"javascript:MaxordNum(this,"+Eval("RemainQty")+")"%>'
                                            CssClass="lbl-txt" Style="text-align: right; display: none;" runat="server" Width="40px"
                                            Text='<%#Eval("RemainQty") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <triggers>
                    <asp:AsyncPostBackTrigger  ControlID="btnget" EventName="Click"  />
                </triggers>
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnsearch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnconfirm" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="btnconfirm" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="btnconfirm" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnconfirm" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td width="20%" valign="top">
        </td>
    </tr>
</table>
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

<script>
         function setVal(id)
         {
           var fy = document.getElementById('<%=lblFY.ClientID %>').innerHTML;
           //  document.getElementById("ctl00_ContentPlaceHolder1_uc_PendingDC1_btnget").click();
        $("#loadingimg").show('fast');
        $("#result").hide('slow');
         callAjax("result",id,"data",fy);          
         $("#result").show('slow');
         $("#loadingimg").hide('fast');
         }
</script>

<script type="text/javascript">


$(document).ready(function() {
       
      });
      


</script>

