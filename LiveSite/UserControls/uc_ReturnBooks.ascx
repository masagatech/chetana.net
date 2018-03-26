<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_ReturnBooks.ascx.cs"
    Inherits="UserControls_uc_ReturnBooks" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
       <span runat="server" id="pageName"></span>
      Return Books <a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <div class="options">
    </div>
</div> 
<asp:Panel ID="pnl1" CssClass="panelDetails"  Width="860px" runat="server">
    <table>
    <tr>
    <td width="100px">
    <asp:Label ID="Label8" runat="server" CssClass="lbl-form" Text="Salesman Name"></asp:Label>
            <font color="red">*</font>
    </td>
    <td width="100px">
        <asp:DropDownList  CssClass="ddl-form" ID="DDLSalesman" DataTextField="Name" DataValueField="EmpCode"
           width="400px" runat="server" Style="float: right"></asp:DropDownList>
    </td>
     <td>
        <asp:RequiredFieldValidator ID="reqDDlSal" runat="server" ErrorMessage="Select Employee" InitialValue="none"
            ValidationGroup="RB" ControlToValidate="DDLSalesman">*</asp:RequiredFieldValidator>
     </td>
    <td width="100px">
        <asp:Button ID="btngetRec" Style="float: left;" CssClass="submitbtn" runat="server"
            Text="Get Records" onclick="btngetRec_Click" ValidationGroup="RB"  />
    </td>
    
    <td width="100px">
                <asp:Button ID="btnview" Enabled="true" CssClass="submitbtn" TabIndex="4" runat="server"
                    Width="80px" Text="View" OnClick="btnview_Click" ValidationGroup="RB" />
    </td>
    </tr>
       <%-- <tr>
            <td width="100px">
                <asp:Label ID="lbldno" runat="server" Text="Document No."></asp:Label>
            </td>
            <td width="100px">
                <asp:TextBox ID="txtdocno" Width="80px" runat="server"></asp:TextBox>
                <ajaxCt:FilteredTextBoxExtender ID="filter1" runat="server" TargetControlID="txtdocno"
                    FilterType="Custom, Numbers" ValidChars="+-=/*()." />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqreturn" runat="server" ErrorMessage="Require Document No."
                    ValidationGroup="RB" ControlToValidate="txtdocno">*</asp:RequiredFieldValidator>
            </td>
            <td width="100px">
                <asp:Button ID="btnget" Enabled="true" CssClass="submitbtn" TabIndex="2" runat="server"
                    Width="80px" Text="Get" OnClick="btnget_Click" ValidationGroup="RB" />
            </td>
            
        </tr>--%>
    </table>
</asp:Panel>
<p></p>
<asp:Panel ID="Panel2" runat="server" Width="900px">
    <div class="actiontab" style="margin-bottom: 6px;">
        <table width="900px" border="0" cellpadding="2" cellspacing="2">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSave" CssClass="submitbtn" TabIndex="4" runat="server" Text="Save"
                        Width="80px" OnClick="btnSave_Click" ValidationGroup="RB" />
                </td>
            </tr>
        </table>
    </div>
    <asp:GridView ID="GrdSpecdetails" CellPadding="4" AlternatingRowStyle-CssClass="alt"
        CssClass="product-table" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label ID="lblbook" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                    <asp:Label ID="lblspdt" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
                    <asp:Label ID="lbldocNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                    <asp:Label ID="lblempid" Style="display: none;" runat="server" Text='<%#Eval("SalesmanID")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblqty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblavailable" Style="text-align: right;" runat="server" Text='<%#Eval("AvailableQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Returned Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lblrqty" Style="text-align: right;" runat="server" Text='<%#Eval("ReturnQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Return Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:TextBox ID="txtreturn" MaxLength="10" Text='0' Enabled='<%#Convert.ToBoolean( Eval("Enable")) %>'
                        CssClass="inp-form" Style="text-align: right;" runat="server" Width="30px" onkeypress="return CheckNumeric(event)"
                        onblur='<%#"javascript:SetMaxNumber(this,"+Eval("ValidateRQty")+")"%>' onkeyup='<%#"javascript:SetMaxNumber(this,"+Eval("ValidateRQty")+")"%>'></asp:TextBox>
                    <ajaxCt:FilteredTextBoxExtender ID="filter" runat="server" TargetControlID="txtreturn"
                        FilterType="Custom, Numbers" ValidChars="+-=/*()." />
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="100px">
                <ItemTemplate>
                    <asp:TextBox ID="txtcmmt" Enabled='<%#Convert.ToBoolean( Eval("Enable")) %>' CssClass="inp-form"
                        Width="200px" Height="35px" runat="server" TextMode="MultiLine"></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:Panel ID="Panel3" runat="server" Width="900px">
    <asp:GridView ID="GrdSpecdetails1" CellPadding="4" AlternatingRowStyle-CssClass="alt"
        CssClass="product-table" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label ID="lbl1book" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                    <asp:Label ID="lbl1spdt" Style="display: none;" runat="server" Text='<%#Eval("SpecimenDetailID")%>'></asp:Label>
                    <asp:Label ID="lbl1docNo" Style="display: none;" runat="server" Text='<%#Eval("DocumentNo")%>'></asp:Label>
                    <asp:Label ID="lbl1empid" Style="display: none;" runat="server" Text='<%#Eval("SalesmanID")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Name">
                <ItemTemplate>
                    <asp:Label ID="lbl1Name" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbl1qty" Style="text-align: right;" runat="server" Text='<%#Eval("Quantity")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Available Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbl1available" Style="text-align: right;" runat="server" Text='<%#Eval("AvailableQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
                <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Return Qty" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="right">
                <ItemTemplate>
                    <asp:Label ID="lbl1rtqt" Style="text-align: right;" runat="server" Text='<%#Eval("ReturnQty") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Comment" HeaderStyle-Width="100px">
                <ItemTemplate>
                    <asp:TextBox ID="txt1cmmt" CssClass="inp-form" Width="200px" Height="40px" runat="server"
                        TextMode="MultiLine" Enabled="false" Text='<%#Eval("Comment") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px"></HeaderStyle>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="RB"
    runat="server" ID="ss" />
