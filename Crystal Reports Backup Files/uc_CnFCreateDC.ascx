<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_CnFCreateDC.ascx.cs" Inherits="CNF_UserControl_uc_CnFCreateDC" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:Panel ID="PnlSpecimenDetails" CssClass="panelDetails" Width="68%" runat="server">
    <table width="100%" cellpadding="0" cellspacing="0">
 <tr>
        <td>
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text=" CnF"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:DropDownList CssClass="ddl-form" ID="ddlCnF" runat="server" TabIndex="8"
                 DataTextField="cnfname" DataValueField="cnfid"
                    Width="150px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                    ErrorMessage="select CnF" ControlToValidate="ddlCnF" ValidationGroup="ct">.</asp:RequiredFieldValidator>
                <asp:Label ID="Label5" runat="server" Text="Label" Style="display: none"></asp:Label>
            </td>
 </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlgrid" runat="server">
<asp:GridView ID="grdBookDetails" CssClass="product-table" AutoGenerateColumns="False"
    TabIndex="21" Width="800px" runat="server" 
    AlternatingRowStyle-CssClass="alt" 
    ShowFooter="true">
    <Columns>
   <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
                <asp:Label ID="lblDCDetailID" Style="display: none;" runat="server" Text=""></asp:Label>
                 <asp:TextBox ID="txtbkcod" onfocus="setfocus('book');" onblur="setfocus('');" autocomplete="off"
                                TabIndex="19" CssClass="inp-form" runat="server" 
                                Width="240px"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarktxtbook" runat="server" TargetControlID="txtbkcod"
                                WatermarkText="Enter BookCode to add  ">
                            </ajaxCt:TextBoxWatermarkExtender>
                           
                          
                            <div id="divwidth" class="divauto">
                            </div>
                            <ajaxCt:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" DelimiterCharacters=""
                                CompletionListCssClass="AutoExtender" CompletionListItemCssClass="AutoExtenderList"
                                CompletionListHighlightedItemCssClass="AutoExtenderHighlight" Enabled="True"
                                ServiceMethod="GetCodes" CompletionInterval="100" MinimumPrefixLength="1" CompletionSetCount="20"
                                ServicePath="~/AutoComplete.asmx" EnableCaching="false" TargetControlID="txtbkcod"
                                UseContextKey="true" ContextKey="book" CompletionListElementID="divwidth">
                            </ajaxCt:AutoCompleteExtender>
            </ItemTemplate>
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
   <asp:TemplateField HeaderText="Book Code" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
            <ItemTemplate>
  
         <asp:TextBox ID="txtbookqty" TabIndex="20" Width="35px" AutoComplete="off" CssClass="inp-form"
                                Style="text-align: right;" MaxLength="5" onkeypress="return CheckNumeric(event)"
                                runat="server"></asp:TextBox>
                            <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtbookqty"
                                WatermarkText="Qty">
                                </ajaxCt:TextBoxWatermarkExtender>
                                </ItemTemplate>
            <HeaderStyle Width="80px" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Panel>
