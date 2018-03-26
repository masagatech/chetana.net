<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true" CodeFile="DisburseAdditionalCommission.aspx.cs" Inherits="DisburseAdditionalCommission" %>
<%@ Register TagPrefix="ajaxCt" Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript">
    $(document).ready(function () {


    });

    function SelectAllJd(spanChk) {
        // Added as ASPX uses SPAN for checkbox
        var oItem = spanChk.children;
        var theBox = (spanChk.type == "checkbox") ?
            spanChk : spanChk.children.item[0];
        xState = theBox.checked;
        elm = theBox.form.elements;
        for (i = 0; i < elm.length; i++) {
            if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                if (elm[i].checked != xState)
                    elm[i].click();
            }
        }
    }

    </script>
<div class="section-header">
        <div class="title">
            <div style="float: right; width: 101%">
                <img src="Images/forms/ico-promotions.png" alt="Edit campaign details" />
               Disburse Additional Commission<a href="Campaigns.aspx" title="back to campaign list"></a>
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

        <div style=" float: left; margin: 15px 0 0; text-align: center; width: 70%;">
       
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

         
                                
                                   

         
                                
                                    <asp:GridView ID="grdACC" AlternatingRowStyle-CssClass="alt" CssClass="product-table"  AutoGenerateColumns="false" ShowFooter="true" runat="server"
                                     onrowediting="grdACC_RowEditing">
                                    <Columns>
                                    <asp:TemplateField HeaderText="Sel">
                            <HeaderTemplate >
                            <asp:CheckBox id="selectall" onclick ="javascript:SelectAllJd(this);" runat ="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="50px" BackColor="#BDBDBD" />
                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Code" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustCode" runat="server" Text='<%#Eval("CustCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Party Name" HeaderStyle-Width="250px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCustName" runat="server" Text='<%#Eval("CustName")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SuperZone" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSuperZoneName" runat="server" Text='<%#Eval("SuperZoneName")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ZoneName" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblZoneName" runat="server" Text='<%#Eval("ZoneName")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AreaZone" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAreaZoneName" runat="server" Text='<%#Eval("AreaZoneName")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSTATE" runat="server" Text='<%#Eval("STATE")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCITY" runat="server" Text='<%#Eval("CITY")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ADD. DISC" HeaderStyle-Width="50px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblAdditinalDis" runat="server" Text='<%#Eval("AdditinalDis")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ACT. DISC" HeaderStyle-Width="50px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblSchAdditionalDis" runat="server" Text='<%#Eval("SchAdditionalDis")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="NET BILL AMT" HeaderStyle-Width="200px" visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDebitAmount" runat="server" Text='<%#Eval("DebitAmount","{0:0.00}")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NET CN AMT" HeaderStyle-Width="200px"  visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCNAmt" runat="server" Text='<%#Eval("CNAmt","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NET NETAMT" HeaderStyle-Width="200px"  visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNETAMT" runat="server" Text='<%#Eval("NETAmount","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NET ADD DIS" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblADDDIS" runat="server" Text='<%#Eval("RESULT1","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GROSS BILL AMT" HeaderStyle-Width="200px"  visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDebitAmount2" runat="server" Text='<%#Eval("DebitAmount2","{0:0.00}")%>'></asp:Label>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GROSS CN AMT" HeaderStyle-Width="200px"  visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCNAmt2" runat="server" Text='<%#Eval("CNAmt2","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GROSS NET AMT" HeaderStyle-Width="200px"  visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNETAmount2" runat="server" Text='<%#Eval("NETAmount2","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GROSS ADD DIS" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblRESULT2" runat="server" Text='<%#Eval("RESULT2","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Amount" ItemStyle-Width="70px" >
                                       <ItemTemplate>
                                            <asp:Label ID="lblDACAmount" runat="server" Text='<%#Eval("DACAmount","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cheque/Cash Details" ItemStyle-Width="70px" >
                                       <ItemTemplate>
                                            <asp:Label ID="lblDACDetails" runat="server" Text='<%#Eval("DACDetails")%>' ></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TotalAmount" ItemStyle-Width="70px" >
                                       <ItemTemplate>
                                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount","{0:0.00}")%>' ></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="lblEdit" runat="server" CausesValidation="false" CommandName="Edit"
                        CssClass="close" ImageUrl="Images/icon/edit_icon.png" />
             
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
                                    
                                    </Columns>
                                    </asp:GridView>
                            
                            
       


      </div>
      <asp:Panel ID="PnlAddDAC" CssClass="panelDetails" runat="server" Width="310px">
            <asp:Label ID="lblCustCode"  runat="server" Text="0" style="display:none;"></asp:Label>
          <table cellpadding="0" cellspacing="0" style="width: 94%">
            <tr>
              <td >
                <asp:Label ID="lblAmount" CssClass="lbl-form" runat="server" Text="Amount"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtAmount" TabIndex="1" CssClass="inp-form" runat="server" 
                     MaxLength="20"></asp:TextBox>
              </td>
              
            </tr>
            <tr>
              <td >
                <asp:Label ID="lblDetails" CssClass="lbl-form" runat="server" Text="Details"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="txtDetails" TabIndex="2" CssClass="inp-form" runat="server"></asp:TextBox>
              </td>
            
            </tr>
            <tr>
            <td>
                <asp:Button ID="Save" CssClass="submitbtn" TabIndex="3" runat="server" Text="Add Payment"
                            Width="80px" OnClick="Save_Click" />
            </td>
            </tr>
            
          </table>
          <script type="text/javascript">
              shortcut.add("Ctrl+S", function () {
                  document.getElementById('<%=btnSave.ClientID %>').click();
              });
              setTimeout("setSatus()", 2000);
              function setSatus() {
                  var status = "[ Ctrl+S : Save ]";
                  document.getElementById('status').innerHTML = status;

              }   
                    </script>
        </asp:Panel>
    </div>
</asp:Content>


