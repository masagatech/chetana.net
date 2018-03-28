<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="CallReport.aspx.cs" Inherits="CallReport" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Call  Report<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="700px" Height="110px">
            <table>
            <tr>
             <td>
                                        <asp:Label ID="lblFromdateCust" runat="server" Text="FromDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFrom" CssClass="inp-form" TabIndex="5" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrom"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                      
                                    </td>
                                    <td>
                                        <asp:Label ID="lblToDateCust" runat="server" Text="ToDate" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTo" CssClass="inp-form" TabIndex="6" runat="server"></asp:TextBox>
                                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                                            Format="dd/MM/yyyy" />
                                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtTo"
                                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                                            AutoComplete="true" CultureName="en-GB" />
                                        
                                    </td>
            </tr>


            <tr>
             <td>
                                           <asp:Label ID="lblTicktNoFrom" runat="server" Text="TicketNoFrom" CssClass="lbl-form"></asp:Label>
                                        <font color="red">*</font>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTicketNoFrom" runat="server" CssClass="inp-form" ></asp:TextBox>
                                    </td>
                                    <td> <asp:Label ID="lblTicktNoTrom" runat="server" Text="TicketNoTo" CssClass="lbl-form"></asp:Label></td>
                                    <td>
                                     
                    <asp:TextBox ID="txtTicketNoTo" runat="server" CssClass="inp-form" ></asp:TextBox>
                                    </td>
            </tr>
            
            
            <tr>
            <td>
                        <asp:Label ID="Label5" CssClass="lbl-form" runat="server" Text="Super Zone"></asp:Label>
                        <font color="red">*</font>
                    </td>
                    <td>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server"
                            DataTextField="SuperZoneName" DataValueField="SuperZoneID" Width="200px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                       
                    </td>
                    <td>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                   
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                    </td>

            
            </tr>
                <tr>
                
                <td id="td1" runat="server" visible ="false">
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Customer Category" Width="100px"></asp:Label>
                        <font color="red"></font>
                    </td>
           <td id="td2" runat="server" visible ="false">
                                        <asp:DropDownList CssClass="ddl-form" ID="DDLCC" Width="250px" DataTextField="Name"
                                            TabIndex="1" DataValueField="CMID" runat="server" AutoPostBack="true"  >
                                        </asp:DropDownList>
                                       
                                    </td>
                    
                    <td>
                        <asp:Label ID="lblCustomer" runat="server" Text="Customer"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCustmore" runat="server" TabIndex="3" CssClass="ddl-form"
                            Width="200px" DataTextField="CustName" DataValueField="CustID">
                        </asp:DropDownList>
                    </td>
                    <td>
                    
                          <asp:Label ID="Label2" runat="server" Text="Status" CssClass="lbl-form"></asp:Label>
                    <font color="red">*</font>
                    </td>
            <td>
              <asp:DropDownList ID="ddlStatus" runat="server" TabIndex="3" CssClass="ddl-form"
                            Width="200px" DataTextField="Status_Name" DataValueField="Status_Name">
                        </asp:DropDownList>
                     </td>
                        <td>
                    </td>
                    
                </tr>
                <tr>
            
                     <td>
                        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="GetData"
                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                    </td>
            </tr>
            </table>
        </asp:Panel>
        
     
    </div>
       <CR:CrystalReportViewer ID="CrCustLabel" runat="server" AutoDataBind="true"
         EnableDatabaseLogonPrompt="false" EnableDrillDown="false"
        EnableParameterPrompt="false" EnableTheming="false" HasDrillUpButton="false"
        HasGotoPageButton="True" HasPageNavigationButtons="True" HasRefreshButton="true"
        HasSearchButton="False" HasToggleGroupTreeButton="True"  HasZoomFactorList="false"
        Height="1039px" Width="773px" ShowAllPageIds="True" />
</asp:Content>
