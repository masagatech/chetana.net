<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Bookwise_DC_Report.aspx.cs" Inherits="Bookwise_DC_Report" Title="Chetana : Book-Wise Report" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 196px;
        }
        .style2
        {
            width: 70px;
        }
        .style3
        {
            width: 63px;
        }
        .style5
        {
            width: 306px;
        }
    .style7
    {
        width: 48px;
    }
    .style8
    {
        width: 785px;
    }
    .style9
    {
        width: 196px;
        height: 35px;
    }
    .style10
    {
        width: 63px;
        height: 35px;
    }
    .style11
    {
        height: 35px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <div>
        <asp:Panel ID="pnldt" CssClass="panelDetails" runat="server" Width="735px">
            <table>
                <tr>
                    <td colspan="4">
                        <asp:RadioButtonList ID="RdbtnSelect" runat="server" RepeatDirection="Horizontal"
                            TabIndex="1" Width="180px" AutoPostBack="True" 
                            OnSelectedIndexChanged="RdbtnSelect_SelectedIndexChanged">
                            <asp:ListItem Value="Bookwise" Text="Bookwise" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="BookTypewise" Text="BookTypewise"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <%--      <td width="80px" >
                    </td>--%>
                    <%--       <td width="30px" >
                    </td>--%>
                    <td class="style2">
                    </td>
                </tr>
                
                    <tr>
                        <td class="style9">
                        </td>
                        <td class="style10">
                            <asp:Label ID="lblbkt" CssClass="lbl-form" runat="server" Text="Book type"></asp:Label>
                        </td>
                        <td colspan="4" class="style11">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtbktype" CssClass="inp-form" AutoPostBack="true" autocomplete="off"
                                        TabIndex="2" runat="server" Enabled="true" Height="16px" Width="226px"></asp:TextBox>
                                    <div id="dvbook" class="divauto">
                                    </div>
                                    <ajaxCt:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionSetCount="20" ServicePath="~/AutoComplete.asmx"
                                        CompletionInterval="100" MinimumPrefixLength="1" EnableCaching="false" TargetControlID="txtbktype"
                                        UseContextKey="true" ContextKey="bktype" CompletionListElementID="dvbook">
                                    </ajaxCt:AutoCompleteExtender>
                                   
                                </ContentTemplate>
                            </asp:UpdatePanel>
                                       
                        </td>
                    </tr>
                    <tr>
                    <td class="style1">
                    </td>
                        <td class="style3">
                            <asp:Label ID="lblbk" CssClass="lbl-form" runat="server" Text="Book"></asp:Label>
                        </td>
                        <td colspan="4">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtbkcod" CssClass="inp-form" AutoPostBack="true"  autocomplete="off"
                                       TabIndex="3" runat="server" Enabled="true" Width="232px"></asp:TextBox>
                                    <div id="divwidth" class="divauto">
                                    </div>
                                    <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                        CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                        CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                        ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                        ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                                        UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                                    </ajaxCt:AutoCompleteExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>         
                    </td> 
                    </tr>
                    
                    
                    
                    
                    <tr>
                    <td class="style1">
                    </td>
                     <td class="style3">
                            <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="SuperDuper Zone"></asp:Label>
                        </td>
                       <td>
                            <asp:DropDownList ID="ddlSDZone" runat="server" AutoPostBack="true" 
                                CssClass="ddl-form" DataTextField="SDZoneName" DataValueField="SDZoneId" 
                                OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged" TabIndex="1" 
                                Width="229px" Height="23px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                ControlToValidate="ddlSDZone" ErrorMessage="Require SuperDuper Zone " 
                                InitialValue="0" ValidationGroup="book">.</asp:RequiredFieldValidator>
                        </td>
                        
                        <td class="style8">
                            <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Super Zone"></asp:Label>
                        </td>
                         <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" Width="250px" DataTextField="SuperZoneName"
                        DataValueField="SuperZoneId" runat="server" TabIndex="2"
                        OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged">
                         </asp:DropDownList>
                        
                        </td>
                        <td class="style7">
                        </td>
                        </tr>
                        
                        
                        
                        <tr>
                            <td class="style1">
                            </td>
                            <td class="style3">
                                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="From Date"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtfromDate" runat="server" CssClass="inp-form" Enabled="true" 
                                    TabIndex="4" Width="80px"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    Format="dd/MM/yyyy" TargetControlID="txtfromDate" />
                                <ajaxCt:MaskedEditExtender ID="fromDate" runat="server" AcceptAMPM="true" 
                                    AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" 
                                    MessageValidatorTip="false" TargetControlID="txtfromDate" />
                                <asp:RequiredFieldValidator ID="Rfvfdt" runat="server" 
                                    ControlToValidate="txtfromDate" ErrorMessage="Require From Date" 
                                    ValidationGroup="book">.</asp:RequiredFieldValidator>
                            </td>
                           
                            <td class="style8">
                                <asp:Label ID="Label2" runat="server" CssClass="lbl-form" Text="To Date"></asp:Label>
                            </td>
                            <td class="style5">
                                <asp:TextBox ID="txttoDate" runat="server" CssClass="inp-form" Enabled="true" 
                                    TabIndex="5" Width="80px"></asp:TextBox>
                                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" 
                                    Format="dd/MM/yyyy" TargetControlID="txttoDate" />
                                <ajaxCt:MaskedEditExtender ID="toDate" runat="server" AcceptAMPM="true" 
                                    AutoComplete="true" CultureName="en-US" Mask="99/99/9999" MaskType="Date" 
                                    MessageValidatorTip="false" TargetControlID="txttoDate" />
                                <asp:RequiredFieldValidator ID="Rfvtdt" runat="server" 
                                    ControlToValidate="txttoDate" ErrorMessage="Require To Date" 
                                    ValidationGroup="book">.</asp:RequiredFieldValidator>
                            </td>
                            <td class="style7">
                            </td>
                            <td>
                                <asp:Button ID="btnget" runat="server" CssClass="submitbtn" 
                                    OnClick="btnget_Click" Style="height: 26px" TabIndex="6" Text="Get" 
                                    ValidationGroup="book" Width="80px" />
                            </td>
                        </tr>
                    </tr>
            
            </table>
        </asp:Panel>
        <br />
        <br />

        <CR:CrystalReportViewer ID="cryBookwise" runat="server" AutoDataBind="true"
        DisplayGroupTree="false" EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" EnableToolTips="true" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="True" HasToggleGroupTreeButton="false" HasViewList="false" HasZoomFactorList="false"
        Width="773px" ClientTarget="Auto" HasCrystalLogo="False"/>

    </div>
</asp:Content>
