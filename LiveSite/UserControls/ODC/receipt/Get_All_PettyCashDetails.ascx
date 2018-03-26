<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Get_All_PettyCashDetails.ascx.cs"
    Inherits="UserControls_ODC_receipt_Get_All_PettyCashDetails" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
        PettyCash Details View<a href="Campaigns.aspx" title="back to campaign list"></a>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div style="float: right; width: 58%">
            <div id="filter" runat="server">
                <span>Filter Data:</span>
                <input name="filt" onkeyup="filter(this, 'sf', '<%=gvAllPettyCash.ClientID%>')" type="text">
            </div>
        </div>
    </asp:Panel>
    <div style="float: right; width: 10%">
        <asp:Button ID="btnprint" CssClass="submitbtn" TabIndex="12" runat="server" Text="Print"
            Width="80px" Height="26px" OnClick="btnprint_Click" />
    </div>
    <div class="options">
    </div>
</div>
<asp:Panel ID="pnldate" runat="server" CssClass="panelDetails" Width="684px">
    <table>
        <tr>
        
            <td>
            <font color="red">*</font>
                <asp:TextBox ID="txtFrom" AutoComplete="off" Width="100px" AutoPostBack="false" CssClass="inp-form"
                    TabIndex="1" runat="server" Height="15px" ValidationGroup="Date">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter FromDate"
                        ValidationGroup="Date" ControlToValidate="txtFrom">*</asp:RequiredFieldValidator>
                <ajaxCt:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrom"
                    Format="dd/MM/yyyy" />
                    <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkDDlset" runat="server" TargetControlID="txtFrom"
                        WatermarkText="From Date">
                    </ajaxCt:TextBoxWatermarkExtender>
                <%--<ajaxCt:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />--%>
            </td>
            <td>
            <font color="red">*</font>
                <asp:TextBox ID="txtTo" AutoComplete="off" Width="100px" AutoPostBack="false" CssClass="inp-form"
                    TabIndex="2" runat="server" Height="15px">
                </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter ToDate"
                        ValidationGroup="Date" ControlToValidate="txtTo">*</asp:RequiredFieldValidator>
                <ajaxCt:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                    Format="dd/MM/yyyy" />
                <%--<ajaxCt:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTo"
                    MaskType="Date" Mask="99/99/9999" AcceptAMPM="true" MessageValidatorTip="false"
                    AutoComplete="true" CultureName="en-US" />--%>
                     <ajaxCt:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtTo"
                        WatermarkText="To Date">
                    </ajaxCt:TextBoxWatermarkExtender>
            </td>
       
        <td>
            <asp:Button ID="btnGet" runat="server" CssClass="submitbtn" Width="80px" 
                Text="Get" Height="26px" ValidationGroup="Date" onclick="btnGet_Click" />
        </td>
        </tr>
         </table>
         </asp:Panel>
         <br />
        <asp:Panel ID="pnlget" runat="server">
            <asp:GridView ID="gvAllPettyCash" runat="server" AutoGenerateColumns="false" CaptionAlign="Bottom"
                CellPadding="4" CssClass="product-table" ForeColor="#333333" Width="100px" PageSize="100">
                <Columns>
                    <asp:TemplateField HeaderText="Voucher No" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="lblVoucherNo" runat="server" Text='<%#Eval("VoucherNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Party/Employee Name" ItemStyle-HorizontalAlign="Left"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblEmpId" Style="display: none" runat="server" Text='<%#Eval("EmpId") %>'></asp:Label>
                           <%-- <asp:Label ID="lblEmpname" runat="server" Text='<%#Eval("FirstName")+" "+Eval("MiddleName")+" "+Eval("LastName") %>'></asp:Label>--%>
                            <asp:Label ID="lblemp" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Voucher SubmitDate" ItemStyle-HorizontalAlign="Right"
                        FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblVoucherdate" runat="server" Text='<%#Eval("VoucherBillSubmitDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Amount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount","{0:0.00}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payment Date" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("PaidOnDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Paid Amount" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("PaidAmount","{0:0.00}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Given From" ItemStyle-HorizontalAlign="Left" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("GivenFrom") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:TemplateField HeaderText="OtherParty" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <asp:Label ID="lbltype" runat="server" Text='<%#Eval("OtherParty") %>'></asp:Label>
                </ItemTemplate>
             </asp:TemplateField>--%>
                    <%--<asp:TemplateField HeaderText="Expense Head" ItemStyle-HorizontalAlign="Right" FooterStyle-HorizontalAlign="Right">
                <ItemTemplate>
                <asp:Label ID="Label1" runat="server" style="display:none" Text='<%#Eval("ExpenseHead") %>'></asp:Label>
                    <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("Value") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>

            <script type="text/javascript">
    	                function filter (phrase, _id){
		                var words = phrase.value.toLowerCase().split(" ");
		                var table = document.getElementById('<%=gvAllPettyCash.ClientID%>');
		                //document.getElementById(_id);
		                var ele;
		                for (var r = 1; r < table.rows.length; r++){
			                ele = table.rows[r].innerHTML.replace(/<[^>]+>/g,"");
		                        var displayStyle = 'none';
		                        for (var i = 0; i < words.length; i++) {
			                    if (ele.toLowerCase().indexOf(words[i])>=0)
				                displayStyle = '';
			                    else {
				                displayStyle = 'none';
				                break;
			                    }
		                        }
			                table.rows[r].style.display = displayStyle;
		                }
		                  if(words != "")
		{
		sloder('search for : '+ words);
		}
		else
		{
		cloder();
		}
	                }
            </script>
 <asp:ValidationSummary ShowMessageBox="true" ShowSummary="false" ValidationGroup="Date"
        runat="server" ID="ValidationSummary3" />

        </asp:Panel>
   
        
