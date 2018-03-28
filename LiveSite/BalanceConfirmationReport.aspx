<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="BalanceConfirmationReport.aspx.cs" Inherits="BalanceConfirmationReport"
    Title="Chetana-Balance Confirmation Report" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Balance Confirmation Report<a href="Campaigns.aspx" title="Balance Confirmation Report"></a>
            </div>
        </div>
    </div>
    <script type="text/javascript">
    function pageLoad(sender, args) 
        {
 
 
        
   
    var headerChk =   $(".chkHeader input");
    var itemChk = $(".chkItem input");
    headerChk.bind("click",function()
    { 
        itemChk.each(
        function(){this.checked = headerChk[0].checked;
        })
     });
    itemChk.bind("click",function(){if($(this).checked==false)headerChk[0].checked =false;});  
    }
    </script>

    <script type="text/javascript">
 
        function onUpdating(divid)
        {
            // get the divImage
            var panelProg = $get(divid);
            // set it to visible
            panelProg.style.display = '';
 
            
        }
 
        function onUpdated(divid)
        {
            // get the divImage
            var panelProg = $get(divid);
            // set it to invisible
            panelProg.style.display = 'none';
        }
 
 
    </script>

    <asp:HiddenField ID="hiddenfildYear" runat="server" />
    <asp:Panel ID="pnlsalesman_customer" CssClass="panelDetails" runat="server">
        <table width="100%">
            <tr>
                <td valign="top">
                <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label><br />
                    <asp:DropDownList CssClass="ddl-form" ID="ddlZone" Width="180px" DataTextField="ZoneName"
                        DataValueField="ZoneID" runat="server" TabIndex="1" AutoPostBack="true" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Zone"
                        ValidationGroup="balancecReport" ControlToValidate="ddlZone" InitialValue="0">.</asp:RequiredFieldValidator>
                </td>
                <td><asp:Label ID="Label2" Visible="false" CssClass="lbl-form"  runat="server" Text="Customer" ></asp:Label><br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox OnTextChanged="txtcustomer_TextChanged" Visible="false" ID="txtcustomer" onfocus="setfocus('customer');"
                                autocomplete="off" Width="80px" CssClass="inp-form" TabIndex="2" runat="server"
                                AutoPostBack="true"></asp:TextBox>
                            <div id="dvcust">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="Cust_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtcustomer"
                                UseContextKey="true" ContextKey="no" CompletionListElementID="dvcust">
                            </ajaxCt:AutoCompleteExtender>
                            
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlZone" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>&nbsp;</td>
                <td>
                 <asp:Label ID="Label3" CssClass="lbl-form" runat="server" Text="Amount"></asp:Label><br />
                    <asp:TextBox ID="txtRs" autocomplete="off" Text="0" Width="80px" CssClass="inp-form"
                        TabIndex="2" runat="server"></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="Amount" runat="server" TargetControlID="txtRs"
                        FilterType="Custom, Numbers" ValidChars=".">
                    </ajaxCt:FilteredTextBoxExtender>
                </td>
                <td>
                    <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="To Date"></asp:Label><br />
                    <asp:TextBox ID="txttoDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                        Enabled="true"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttoDate"
                        Format="dd/MM/yyyy" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttoDate"
                        MaskType="Date" Mask="99/99/9999" MessageValidatorTip="false" AutoComplete="false" />
                    <asp:RequiredFieldValidator ID="Rqffdt2" runat="server" ErrorMessage="Require Date"
                        ValidationGroup="balancecReport" ControlToValidate="txttoDate">.</asp:RequiredFieldValidator>
                </td>
                <td valign="top">
               <br />
                    <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" ValidationGroup="balancecReport"
                        CssClass="submitbtn" TabIndex="3" OnClick="btnget_Click" Style="height: 26px" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label ID="lblCustName" CssClass="lbl-form" ForeColor="Blue" Font-Size="15px"
                                runat="server"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="txtcustomer" EventName="TextChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <ajaxCt:MaskedEditValidator ValidationGroup="balancecReport" ID="MaskedEditValidator1"
                        runat="server" ControlToValidate="txttoDate" ControlExtender="MaskedEditExtender2"
                        CssClass="RedLabel" Display="Dynamic" EmptyValueBlurredText="Select to date" InvalidValueBlurredMessage="Invalid Date"
                        IsValidEmpty="false" Style="color: #000; font-size: 12px;" ValidationExpression="^\d{2}/\d{2}/\d{4}$">    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </ajaxCt:MaskedEditValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <CR:CrystalReportViewer ID="crtcustomer" runat="server" 
        AutoDataBind="true"
            DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
            EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
            HasPageNavigationButtons="true" HasRefreshButton="true" HasSearchButton="false"
            HasToggleGroupTreeButton="False" HasViewList="false" HasZoomFactorList="false"
             Width="773px" ShowAllPageIds="True" OnLoad="crtcustomer_Load"  
            OnNavigate="crtcustomer_Navigate" />
    <asp:Label ID="lblMessage" Visible="false" runat="server" Text="No records found" Font-Size="15px"></asp:Label>     
           
    <ajaxCt:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender5" TargetControlID="UpdatePanel2"
        runat="server">
        <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating('divImage');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="false" />                   
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated('divImage');" />
                    <EnableAction AnimationTarget="btnGetRecords" Enabled="true" />
                </Parallel>
            </OnUpdated>
        </Animations>
    </ajaxCt:UpdatePanelAnimationExtender>
    <asp:HiddenField ID="HidFY" runat="server" />
</asp:Content>

