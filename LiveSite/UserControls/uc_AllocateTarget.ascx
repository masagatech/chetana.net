<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_AllocateTarget.ascx.cs"
    Inherits="UserControls_uc_AllocateTarget" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        <span runat="server" id="pageName"></span><a href="Campaigns.aspx" title="back to campaign list">
        </a>
    </div>
    <div class="options">
    </div>
</div>
<div style="float: right; width: 70%">
    <asp:Button ID="btn_Save" CssClass="submitbtn" ValidationGroup="target" runat="server"
        Text="Save" Width="80px" OnClick="btn_Save_Click" />
    <%-- <asp:Button ID="btncancel" CssClass="form-submit" runat="server" Text="Cancel" Width="80px"
        OnClick="btncancel_Click" />--%>
</div>
<br />
<br />
<asp:Panel ID="Pnlallocate" CssClass="panelDetails" runat="server">
    <table width="40%" cellpadding="0" cellspacing="0">
        <tr>
            <td  valign="top" >
               
                <asp:Label ID="lbltargetid" runat="server" CssClass="lbl-form" Text="" Style="display: none"></asp:Label>
                <asp:Label ID="Label1" runat="server" CssClass="lbl-form" Text="Target Person"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <%--
                  <asp:DropDownList ID="DDLtargetperson" DataTextField="Name" CssClass="ddl-form" Width = "150px"
                      DataValueField="EmpID" AutoPostBack="true" runat="server" 
                      onselectedindexchanged="DDLtargetperson_SelectedIndexChanged" >
                        </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqDatE" runat="server" ErrorMessage="Require Target Person" InitialValue = "0"
                    ValidationGroup="target" ControlToValidate="DDLtargetperson">.</asp:RequiredFieldValidator>       --%>
                <asp:DropDownList ID="DDLsuperzone" TabIndex="1" DataTextField="Name" CssClass="ddl-form"
                    Width="150px" DataValueField="EmpID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLsuperzone_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" InitialValue="0"
                    ErrorMessage="select SuperZone" ControlToValidate="DDLsuperzone" ValidationGroup="ct">.</asp:RequiredFieldValidator>
            </td>
          <%--  <td>
                <asp:Label ID="Label3" runat="server" CssClass="lbl-form" Text="Target Amount"></asp:Label>
                <font color="red">*</font>
            </td>--%>
          <%--  <td>
                <asp:TextBox ID="txttargetamt" CssClass="inp-form" TabIndex="3" onkeypress="return CheckNumeric(event)"
                    MaxLength="10" Width="120px" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Require Target Amount"
                    ValidationGroup="target" ControlToValidate="txttargetamt">.</asp:RequiredFieldValidator>
            </td>--%>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="lbl-form" Text="Start Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtstartDate" CssClass="inp-form" TabIndex="2" Width="120px" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtstartDate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtstartDate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Start Date"
                    ValidationGroup="target" ControlToValidate="txtstartDate">.</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" CssClass="lbl-form" Text="End Date"></asp:Label>
                <font color="red">*</font>
            </td>
            <td>
                <asp:TextBox ID="txtendate" CssClass="inp-form" TabIndex="2" Width="120px" runat="server"></asp:TextBox>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtendate"
                    Format="dd/MM/yyyy" />
                <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtendate"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select End Date"
                    ValidationGroup="target" ControlToValidate="txtendate">.</asp:RequiredFieldValidator>
            </td>
        </tr>--%>
    </table>
</asp:Panel>
<br />
<%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>--%>
        <asp:Label ID="lblDetails" CssClass="lbl-form" ForeColor="Blue" Font-Bold="true"
            Font-Size="15px" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView Style="width: 690px" CssClass="product-table" AlternatingRowStyle-CssClass="alt"
            ID="DDLtargetperson" AutoGenerateColumns="false" runat="server" 
    onrowdatabound="DDLtargetperson_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Select">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelected" TabIndex="2" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Zone">
                    <ItemTemplate>
                     <asp:Label ID="lblID" runat="server" CssClass="lbl-form" Text='<%#Eval("TargetdetailsId") %>' Style="display: none"></asp:Label>
                        <asp:Label ID="lblZoneName" runat="server" Text='<%#Eval("ZoneName") %>'></asp:Label>
                        <asp:Label ID="lblZoneID" runat="server" Text='<%#Eval("ZoneID") %>' Style="display: none"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="From Date">
                    <ItemTemplate>
                        <asp:TextBox ID="txtstartDate" CssClass="inp-form" TabIndex="2" Text='<%#Eval("TargetStartDate","{0:dd/MM/yyyy}") %>' Width="120px" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtstartDate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="meeRequestDate" runat="server" TargetControlID="txtstartDate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Start Date"
                            ValidationGroup="target" ControlToValidate="txtstartDate">.</asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="To Date">
                    <ItemTemplate>
                        <asp:TextBox ID="txtendate" CssClass="inp-form" Text='<%#Eval("TargetEndDate","{0:dd/MM/yyyy}") %>' TabIndex="2" Width="120px" runat="server"></asp:TextBox>
                        <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtendate"
                            Format="dd/MM/yyyy" />
                        <ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtendate"
                            MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                            AutoComplete="true" CultureName="en-US" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select End Date"
                            ValidationGroup="target" ControlToValidate="txtendate">.</asp:RequiredFieldValidator>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:TextBox Width="130px" TabIndex="2" Text='<%#Eval("TargetAmt") %>' AutoComplete="off" style="text-align:right;" ID="txtAmount" onkeypress="return CheckNumericWithDot(event)" runat="server"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <%-- <asp:DropDownList CssClass="ddl-form" ID="DDLtargetperson" runat="server" TabIndex="9"
                            AutoPostBack="True" DataTextField="ZoneName" DataValueField="ZoneID" Width="100px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0"
                            ErrorMessage="select ZoneName" ControlToValidate="DDLtargetperson" ValidationGroup="ct">.</asp:RequiredFieldValidator>--%>
    <%--</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="DDLsuperzone" EventName="SelectedIndexChanged" />
    </Triggers>
</asp:UpdatePanel>--%>
<asp:Panel ID="pnlallocatedetails" runat="server">
    <asp:GridView ID="grdallocateDetails" CssClass="product-table" AutoGenerateColumns="False"
        Width="800px" TabIndex="11" runat="server" AllowPaging="true" AlternatingRowStyle-CssClass="alt"
        OnRowEditing="grdallocateDetails_RowEditing">
        <Columns>
            <asp:TemplateField HeaderText="Zone" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblTargetdetailsId" Style="display: none;" runat="server" Text='<%#Eval("TargetdetailsId")%>'></asp:Label>
                    <asp:Label ID="lblTargetId" Style="display: none;" runat="server" Text='<%#Eval("TargetId")%>'></asp:Label>
                    <asp:Label ID="lblzone" runat="server" Text='<%#Eval("ZoneName")%>'></asp:Label>
                    <asp:Label ID="lblzoneid" Style="display: none;" runat="server" Text='<%#Eval("Personlevel")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="80px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Employee" HeaderStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblTargetPersonId" Style="display: none;" runat="server" Text='<%#Eval("TargetPersonId")%>'></asp:Label>
                    <asp:Label ID="lbltargetperson" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Target Amount" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lbltargetamt" Style="text-align: right;" runat="server" Text='<%#Eval("TargetAmt","{0:0.00}")%>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Right" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Date" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblstartdate" runat="server" Text='<%#Eval("TargetStartDate")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="End Date" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="lblenddate" Style="text-align: right;" runat="server" Text='<%#Eval("TargetEndDate")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="../Images/icon/edit_icon.png" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>
<asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="target"
    runat="server" ID="ss" />

<script type="text/javascript">
     setTimeout("setSatus()",2000);
   function setSatus()
   {
   var status="[ Ctrl+Shift+N : New ]&nbsp;&nbsp;&nbsp;[ Ctrl+S : Save ]";
   document.getElementById('status').innerHTML=status;
   }
</script>

<script type="text/javascript">
      
shortcut.add("Ctrl+S",function() {
document.getElementById('ctl00_ContentPlaceHolder1_uc_AllocateTarget1_btn_Save').click();
});


function chec(id,amt)
{
    
        var Amtc =  document.getElementById(amt).value;

        if(Amtc > 0)
        {
            document.getElementById(id).checked = true;
        }
        else
        {
           document.getElementById(id).checked = false;
        }
        
  for (var r = 1; r < tablea.rows.length-1; r++)
  {
      rate = $(tablea.rows[r].cells[4]).find('input:text').attr("value");
     
      TotalQty = TotalQty + parseInt(tablea.rows[r].cells[6].innerHTML.replace(/<[^>]+>/g,""));
       // alert(rate);
      TotalAmt = TotalAmt + parseFloat(tablea.rows[r].cells[7].innerHTML.replace(/<[^>]+>/g,""));
   //Totalrate  = Totalrate  + parseFloat(rate);
  
  }
}

</script>

