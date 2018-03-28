<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="BankRecoDetail.aspx.cs" Inherits="BankRecoDetail" Title="Bank Reconcillation" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="float: right; width: 101%">
        <div class="section-header">
            <div class="title">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
                Bank Book<a href="Campaigns.aspx" title="back to campaign list"></a>
            </div>
        </div>
    </div>
    <div>
    <div style="float: left; width: 71%">
      <asp:Button ID="btn_Save"  Style="float: right;" CssClass="submitbtn"
        ValidationGroup="S" TabIndex="22" runat="server" Text="Save" Width="80px" OnClick="btn_Save_Click" />
       </div> 
      <br />
      <br />
        <asp:Panel ID="pnlLedger" runat="server">
        
            <asp:GridView ID="gvBankreco" runat="server" AutoGenerateColumns="false" CssClass="product-table"
                ShowFooter="true" ForeColor="#333333" PageSize="2000" Width="80%" >
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("DepositeDate")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="50px" />
                        <FooterTemplate>
                            <asp:Label ID="lblTotalAmt" runat="server" Text="Total"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Customer Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("Party")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Type" ItemStyle-HorizontalAlign="Left"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Deposite_Type")%>'></asp:Label>
                            <asp:Label ID="lblOpeningBalance" runat="server" Text='<%#Eval("OpeningBalance","{0:0.00}")%>'
                                Style="display: none"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Debit Amount" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblDebitAmount" runat="server" Text='<%#Eval("DebitAmount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblDebitTotal" runat="server"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="50px" HeaderText="Credit Amount" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblCreditamount" runat="server" Text='<%#Eval("CreditAmount","{0:0.00}")%>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotalcreditAmt" runat="server"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="40px" HeaderText="CheQue No.">
                        <ItemTemplate>
                            <asp:Label ID="lblChequeNo" runat="server" Text='<%#Eval("CheQueNo")%>'></asp:Label>
                             <asp:Label ID="lblflag" runat="server" Text='<%#Eval("Flag")%>' style="display:none"></asp:Label>
                             <asp:Label ID="lbldetailid" runat="server" Text='<%#Eval("DetailId")%>' style="display:none"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Check" HeaderStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkBxSelect" runat="server" TabIndex="7"></asp:CheckBox>
                        </ItemTemplate>
                        <HeaderStyle Width="70px" />
                        <ItemStyle HorizontalAlign="Center" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="200px" HeaderText="Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtrecodate"  Text='<%#Eval("RecoDate")%>' Width="80px" Style="text-align: right;" runat="server"
                                AutoComplete="off" ></asp:TextBox>
                            <ajaxct:calendarextender id="CalendarExtender4" runat="server" targetcontrolid="txtrecodate"
                                format="dd/MM/yyyy" />
                            <ajaxct:maskededitextender id="DeliveryDate" runat="server" targetcontrolid="txtrecodate"
                                masktype="Date" mask="99/99/9999" acceptampm="true" messagevalidatortip="false"
                                autocomplete="true" culturename="en-US" />
                        </ItemTemplate>
                        <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
        </asp:Panel>
    </div>
    <script type="text/javascript">
var TotalChkBx;
var Counter;

window.onload = function()
{
   //Get total no. of CheckBoxes in side the GridView.
   TotalChkBx = parseInt('<%= this.gvBankreco.Rows.Count %>');

   //Get total no. of checked CheckBoxes in side the GridView.
   Counter = 0;
}

function HeaderClick(CheckBox)
{
   //Get target base & child control.
   var TargetBaseControl = 
       document.getElementById('<%= this.gvBankreco.ClientID %>');
   var TargetChildControl = "chkBxSelect";

   //Get all the control of the type INPUT in the base control.
   var Inputs = TargetBaseControl.getElementsByTagName("input");

   //Checked/Unchecked all the checkBoxes in side the GridView.
   for(var n = 0; n < Inputs.length; ++n)
      if(Inputs[n].type == 'checkbox' && 
                Inputs[n].id.indexOf(TargetChildControl,0) >= 0)
         Inputs[n].checked = CheckBox.checked;

   //Reset Counter
   Counter = CheckBox.checked ? TotalChkBx : 0;
}

function ChildClick(CheckBox, HCheckBox)
{
   //get target control.
   var HeaderCheckBox = document.getElementById(HCheckBox);

   //Modifiy Counter; 
   if(CheckBox.checked && Counter < TotalChkBx)
      Counter++;
   else if(Counter > 0) 
      Counter--;

   //Change state of the header CheckBox.
   if(Counter < TotalChkBx)
      HeaderCheckBox.checked = false;
   else if(Counter == TotalChkBx)
      HeaderCheckBox.checked = true;
}
</script>
</asp:Content>
