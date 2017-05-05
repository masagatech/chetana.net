<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="Additional Disburse.aspx.cs" Inherits="Additional_Disburse" %>

<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                <a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
        <br />
        <br />
        <asp:Panel ID="pnlcust" runat="server" CssClass="panelDetails" Width="700px" Height="90px">
            <table>
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
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please select SuperZone"
                            InitialValue="0" ValidationGroup="AZone" ControlToValidate="DDLSuperZone">.</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label4" CssClass="lbl-form" runat="server" Text="Zone"></asp:Label>
                        <%--<font color="red">*</font>--%>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLZone" runat="server" TabIndex="2" AutoPostBack="True" CssClass="ddl-form"
                            DataTextField="ZoneName" DataValueField="ZoneID" Width="200px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%-- <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                    </td>

            
            </tr>
                <tr>
                <td>
                        <asp:Label ID="Label1" CssClass="lbl-form" runat="server" Text="Customer Category" Width="100px"></asp:Label>
                        <font color="red"></font>
                    </td>
            <td>
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
                    </td>
                    <td>
                        <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="7" runat="server" Text="GetData"
                            Width="80px" ValidationGroup="AZone" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
   
            <div style="margin: -30px 0 0; position: relative; top: 30px; left: -7.5px;" id="divGridGeneral"
                        runat="server">
                        <asp:GridView ID="gdGeneral" AlternatingRowStyle-CssClass="alt" CssClass="product-table"
                            AutoGenerateColumns="false" ShowFooter="true" runat="server"  >
                            <Columns>
                                <asp:TemplateField HeaderText="Is Active" HeaderStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsActive1" runat="server" Enabled="true" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sr. No." HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Code" HeaderStyle-Width="200px" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
                                      <%--  <asp:Label ID="lblcourierid" runat="server" Text='<%#Eval("GeneralCourierID")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="PartyName" HeaderStyle-Width="200px" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblname" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SuperZone" HeaderStyle-Width="50px" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblszone" runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Zone" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblZone" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Area ZoneName" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblazName" runat="server" Text='<%#Eval("AreaZoneName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="City" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCity" runat="server" Text='<%#Eval("CITY")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="State" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblState" runat="server" Text='<%#Eval("STATE")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discount" HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscount" runat="server" Text='<%#Eval("AdditinalDis")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <asp:TemplateField HeaderText="Amount" ItemStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAmount" Style="width: 70px;" runat="server" Text='<%#Eval("Additionalamt")%>'></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblBPODId11" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                
                                  
                            </Columns>
                        </asp:GridView>
                        </div>
    
                          <table style="float: left;" cellspacing="2" cellpadding="2">
                                
                            </table>
                         <asp:UpdatePanel ID="updateapprove" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                                 <div  style="margin: -30px 0 0; position: relative; top: -5px;left: -7.5px;" id="div1" runat="server" >
         
            
                                    <table style="float: right;" cellspacing="2" cellpadding="2">
                                        
                                        <tr>
                                            <td align="left" colspan="4">
                                                <asp:Button ID="btnUpdate" CommandArgument='<%#Eval("SCMasterAutoId")%>' CommandName="update"
                                                    TabIndex="6" runat="server" Text="Update Amount" CssClass="submitbtn" Width="110px"
                                                    Style="float: right;margin:47px 0 30px 0px" OnClick="btnUpdate_Click"/>
                                                 </td>
                                          
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <hr style="background-color: Red" />
                                            </td>
                                        </tr>
                                    </table>
                                    </div>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                         
                    </div>
                
      
  
</asp:Content>

