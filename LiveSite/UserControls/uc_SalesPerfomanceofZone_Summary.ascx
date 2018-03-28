<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_SalesPerfomanceofZone_Summary.ascx.cs"
    Inherits="UserControls_uc_SalesPerfomanceofZone_Summary" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        SuperZoneWise Sales Report <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div>
<asp:Panel ID="Pnl1" CssClass="panelDetails" runat="server" Width="862px">
    <table>
        <tr>
            <td width ="100px" >
                <asp:Label ID="Label3" runat="server" Text="Superzone" CssClass="lbl-form"></asp:Label>
            </td>
            <td colspan = "2">
                <asp:DropDownList CssClass="ddl-form" ID="DDLsuperzone" DataTextField="SuperZoneName"
                    DataValueField="SuperZoneID" runat="server" TabIndex="1" 
                    Width="200px" >
                </asp:DropDownList>
            </td>
            <td width ="100px" >
                <asp:Label ID="Label1" runat="server" Text="Customer Category" CssClass="lbl-form"></asp:Label>
            </td>
            <td>
                        <td width="300px">
                                    <asp:DropDownList CssClass="ddl-form" TabIndex="5" ID="DDLCC" runat="server"
                                        Width="200px" DataValueField="CMID" AutoPostBack="true" DataTextField="Name"
                                        >
                                    </asp:DropDownList>
                                </td>
                        </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="ll" runat="server"></asp:Label>
            </td>
            <td width ="100px">
                <asp:TextBox ID="txtfromDate" CssClass="inp-form" TabIndex="2" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromDate"
                    Format="dd/MM/yyyy" />
                     <ajaxct:maskededitextender ID="fromDate" runat="server" TargetControlID="txtfromDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtfromDate"
                    WatermarkText="FromDate">
                </ajaxCt:TextBoxWatermarkExtender>
            </td>
            <td >
                <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="3" Width="80px" runat="server"
                    Enabled="true"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate"
                    Format="dd/MM/yyyy" />
                     <ajaxct:maskededitextender ID="Maskededitextender1" runat="server" TargetControlID="txtToDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <ajaxCt:TextBoxWatermarkExtender ID="wat" runat="server" TargetControlID="txtToDate"
                    WatermarkText="ToDate">
                </ajaxCt:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td width ="100px"> 
                <asp:RadioButtonList  ID="rdbselect" runat="server" style="display:none" RepeatDirection="Horizontal" CssClass="lbl-form"
                    TabIndex="4">
                    <asp:ListItem  Value="summary" Text=" Summary" Selected="True" ></asp:ListItem>
                    <asp:ListItem Value="detail" Text=" Detail"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Button ID="btnget" runat="server" Width="80px" Text="Get" ValidationGroup="S"
                    CssClass="submitbtn" TabIndex="5" OnClick="btnget_Click" />
             </td>
            <td>
                <asp:Button ID="btnExport" CssClass="submitbtn" TabIndex="6" runat="server" Text="Export" style="display:none;"
                    Width="80px"  OnClick="btnExport_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<table>
    <tr>
        <td valign="top">
            <asp:GridView ID="grdoutstanding" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="500px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true" OnRowEditing="grdoutstanding_RowEditing" OnRowDataBound="grdoutstanding_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Zone" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblzoneid" Style="display: none;" runat="server" Text='<%#Eval("ZoneID")%>'></asp:Label>
                            <asp:Label ID="lblzonecode" Font-Bold="true" runat="server" Style="float: left" Text='<%#Eval("ZoneCode")%>'></asp:Label>
                            <asp:ImageButton ID="lblEdit" CssClass="close" runat="server" CausesValidation="false"
                                Style="float: right" CommandName="Edit" ToolTip="Edit" ImageUrl="../Images/icon/icon_plus.jpg" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbl1" Text="TOTAL" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="OP. BAL." ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblopeningbalance" runat="server" Text='<%#Eval("openingbalance","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalopbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BILL AMT." ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblBillamt" runat="server" Text='<%#Eval("Billamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalBillamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CN AMT." ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblCNamt" runat="server" Text='<%#Eval("CNamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalCNamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="RECD AMT" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblRecdamt" Style="text-align: right;" runat="server" Text='<%#Eval("Recdamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalRecdamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="BALANCE" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalBalance" Style="text-align: right;" runat="server" Text='<%#Eval("totalBalance","{0:0.00}")%>'></asp:Label>
                            <asp:Label ID="lblTargetGiven" runat="server" Style="display: none" Text='<%#Eval("TargetGiven","{0:0.00}")%>'></asp:Label>
                            <asp:Label ID="lblTargetAchieved" runat="server" Style="display: none" Text='<%#Eval("TargetAchieved","{0:0.00}")%>'></asp:Label>
                            <asp:Label ID="lblTargetdifference" Style="text-align: right; display: none" runat="server"
                                Text='<%#Eval("Targetdifference","{0:0.00}")%>'></asp:Label>
                            <asp:Label ID="lblTargetAchpercent" Style="text-align: right; display: none" runat="server"
                                Text='<%#Eval("TargetAchpercent")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        <td valign="top">
            <asp:GridView ID="grdnoofparty" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="100px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true" OnRowDataBound="grdnoofparty_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Active" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblActive" runat="server" Text='<%#Eval("Active")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalactive" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Non active" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblNonactive" runat="server" Text='<%#Eval("Nonactive")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalNonactive" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        <td valign="top">
            <asp:GridView ID="GrdDiscount" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="160px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true" OnRowDataBound="GrdDiscount_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="20 %" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbltwenty" runat="server" Text='<%#Eval("20")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotaltwenty" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="25 %" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbltwentyfive" runat="server" Text='<%#Eval("25")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotaltwentyfive" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="30 %" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblthirty" runat="server" Text='<%#Eval("30")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalthirty" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="35 %" ItemStyle-HorizontalAlign="Right" 
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblthirtyfive" Style="text-align: right;" runat="server" Text='<%#Eval("35")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalthirtyfive" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="40 %" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblforty" Style="text-align: right;" runat="server" Text='<%#Eval("40")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalforty" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        <td valign="top">
            <asp:GridView ID="grdtargetdetail" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="500px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="false" OnRowDataBound="grdtargetdetail_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearFromTo")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalopbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tar. Given" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetGiven" runat="server" Text='<%#Eval("TargetGiven","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotaltrgiven" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tar Ach" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetAchieved" runat="server" Text='<%#Eval("TargetAchieved","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltarachve" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Def (ASP Tar Ach Flg)" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetdifference" Style="text-align: right;" runat="server" Text='<%#Eval("Targetdifference","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalRecdamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Tar Ach %" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetAchpercent" Style="text-align: right;" runat="server" Text='<%#Eval("TargetAchpercent")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
       
    </tr>
    <tr>
        <td valign="top">
            <asp:GridView ID="GrdBookset" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="500px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="true"  OnRowDataBound="GrdBookset_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="PARTICULARS" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblCode" runat="server" Text='<%#Eval("BookSetCode")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SET" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblset" runat="server" Text='<%#Eval("BookSet")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRICE PER SET" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblprice" runat="server" Text='<%#Eval("Price","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="TOTAL (GROSS)" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblgrossamt" Style="text-align: right;" runat="server" Text='<%#Eval("TotalPrice","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalgrossamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
         <td colspan = "3" valign="top">
         <asp:GridView ID="grdadddiscount" CssClass="product-table" AutoGenerateColumns="true" 
                 runat="server" AlternatingRowStyle-CssClass="alt" 
                onrowdatabound="grdadddiscount_RowDataBound"  />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td valign="top">
            <asp:Label ID="lblgrdemployee" Font-Bold="true" runat="server" Text=""></asp:Label>
            <asp:GridView ID="grdemployee" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="500px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="false" OnRowEditing="grdemployee_RowEditing" OnRowDataBound="grdemployee_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Area Zone" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblempid" Style="display: none;" runat="server" Text='<%#Eval("empid")%>'></asp:Label>
                            <asp:Label ID="lblempcode" Style="float: left" Font-Bold="true" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                            <asp:ImageButton ID="lblEdit" CssClass="close" runat="server" CausesValidation="false"
                                Style="float: right" CommandName="Edit" ToolTip="Edit" ImageUrl="../Images/icon/icon_plus.jpg" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbl1" Text="TOTAL" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("Empname")%>'></asp:Label>
                            <asp:Label ID="lblBillamt" Style="display: none" runat="server" Text='<%#Eval("Billamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalopbal" Font-Bold="true" runat="server"></asp:Label>
                            <asp:Label ID="lbltotalBillamt" Style="display: none" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="BILL AMT." ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblBillamt" runat="server" Text='<%#Eval("Billamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalBillamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </td>
        <td valign="top">
            <asp:Label ID="lblgrdcustomer" Font-Bold="true" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblcustomername" Font-Bold="true" runat="server" Text=""></asp:Label>
            <asp:GridView ID="grdcustomer" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="700px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="false" OnRowDataBound="grdcustomer_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Custcode" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblcustid" Style="display: none;" runat="server" Text='<%#Eval("custid")%>'></asp:Label>
                            <asp:Label ID="lblcustcode" Font-Bold="true" Style="float: left" runat="server" Text='<%#Eval("cuscode")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbl1" Text="TOTAL" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle Width="80px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="240px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("custname")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalopbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="Zone" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblarea" runat="server" Text='<%#Eval("Zonecode")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="OP. BAL." ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblopeningbalance" runat="server" Text='<%#Eval("openingbalance","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalopbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BILL AMT." ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblBillamt" runat="server" Text='<%#Eval("Billamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalBillamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CN AMT." ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblCNamt" runat="server" Text='<%#Eval("CNamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalCNamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="RECD AMT" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblRecdamt" Style="text-align: right;" runat="server" Text='<%#Eval("Recdamt","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalRecdamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="BALANCE" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbltotalBalance" Style="text-align: right;" runat="server" Text='<%#Eval("totalBalance","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
         <td valign="top">
            <asp:GridView ID="grdzonedetail" CssClass="product-table" AutoGenerateColumns="False"
                TabIndex="21" Width="500px" runat="server" AlternatingRowStyle-CssClass="alt"
                ShowFooter="false" OnRowDataBound="grdtargetdetail_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Year" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                           <%-- <asp:Label ID="lblYear" runat="server" Text='<%#Eval("yearFromTo")%>'></asp:Label>--%>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalopbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tar. Given" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetGiven" runat="server" Text='<%#Eval("TargetGiven","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotaltrgiven" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tar Ach" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetAchieved" runat="server" Text='<%#Eval("TargetAchieved","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltarachve" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Def (ASP Tar Ach Flg)" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetdifference" Style="text-align: right;" runat="server" Text='<%#Eval("Targetdifference","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalRecdamt" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Tar Ach %" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTargetAchpercent" Style="text-align: right;" runat="server" Text='<%#Eval("TargetAchpercent")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalbal" Font-Bold="true" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
</table>
<CR:CrystalReportViewer ID="salesperformance" runat="server" AutoDataBind="True"
    EnableTheming="false" SeparatePages="True" HasRefreshButton="True"  
     Height="50px" Width="350px" EnableDrillDown="true" HasDrillUpButton="True"
     />
