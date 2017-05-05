<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_UpdateBooksStock.ascx.cs"
    Inherits="UserControls_uc_UpdateBooksStock" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>

<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        Update Book Stock <a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>


<asp:Panel ID="pnl" runat="server">
    <asp:Panel ID="pnldate" CssClass="panelDetails" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblfromdate" runat="server" Text="From Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFromDate" CssClass="inp-form" TabIndex="1" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtFromDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFromDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="Reqtdate" runat="server" ErrorMessage="Require From date"
                        ValidationGroup="date" ControlToValidate="txtFromDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtToDate" CssClass="inp-form" TabIndex="2" runat="server"></asp:TextBox>
                    <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                        TargetControlID="txtToDate" />
                    <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtToDate"
                        MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                        AutoComplete="true" CultureName="en-US" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require To date"
                        ValidationGroup="date" ControlToValidate="txtToDate">.</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:Button ID="btngetdate" TabIndex="3" CssClass="submitbtn" runat="server" Text="Get Data"
                        Width="80px" ValidationGroup="date" OnClick="btngetdate_Click" />
                </td>
                <td></td>
                <td>
                <asp:Button  ID="btnsave" runat="server" CssClass="submitbtn" Text="Transfer" 
                        Width="80px" onclick="btnsave_Click"/>
                </td>
            </tr>
        </table>
       
    </asp:Panel>
     <br />
    <asp:GridView ID="Grdstockreport" runat="server" 
        AutoGenerateColumns="False" CellPadding="4" 
        CssClass="product-table" 
        PageSize="2000" 
        Width="915px"> <%--onselectedindexchanged="Grdstockreport_SelectedIndexChanged"--%>
        <Columns>
            <asp:TemplateField HeaderStyle-Width="80px" HeaderText="Book Code" 
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblbkcode" runat="server" Text='<%#Eval("BookCode")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="339px" HeaderText="Book Name" 
                ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("BookName")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="339px" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Book Type" HeaderStyle-Width="80px">
             <ItemTemplate>
                    <asp:Label ID="lblbooktype" runat="server" Text='<%#Eval("Booktype")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField  HeaderText="Standard" 
                 ItemStyle-HorizontalAlign="center">
                <ItemTemplate>
                    <asp:Label ID="lblStandard" runat="server" Text='<%#Eval("Standard")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="center" />
            </asp:TemplateField>
            <asp:TemplateField  HeaderStyle-Width="80px" 
                HeaderText="Net aAvailable" 
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:TextBox ID="txtavailable" onkeypress="return CheckNumeric(event)" runat="server" Text='<%#Eval("Balance QTY") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
             <asp:TemplateField  HeaderStyle-Width="80px" 
                HeaderText="" 
                ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="chkselect"/>
                </ItemTemplate> <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                        </HeaderTemplate>
                <HeaderStyle Width="80px" />
                
                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ValidationSummary ID="vald" runat="server" ValidationGroup="date" ShowMessageBox="true"
        ShowSummary="false" />

   
</asp:Panel>
<script type="text/javascript">
var TotalChkBx;
var Counter;

window.onload = function()
{
   //Get total no. of CheckBoxes in side the GridView.
    TotalChkBx = parseInt('<%= this.Grdstockreport.Rows.Count %>');

   //Get total no. of checked CheckBoxes in side the GridView.
   Counter = 0;
}

function HeaderClick(CheckBox)
{
   //Get target base & child control.
   var TargetBaseControl =
       document.getElementById('<%= this.Grdstockreport.ClientID %>');
   var TargetChildControl = "chkselect";

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

function OnCheckNumeric_chkselect(evt) 
{
    var charCode = (evt.which) ? evt.which : event.keyCode

    if (charCode > 31 && (charCode < 45 || charCode > 57)) 
    {

        document.getElementById('loding').style.display = 'block';
        document.getElementById('loder').innerHTML = 'only numeric value accept';

        return false;
    }
}
</script>