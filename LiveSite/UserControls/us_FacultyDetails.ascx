<%@ Control Language="C#" AutoEventWireup="true" CodeFile="us_FacultyDetails.ascx.cs"
    Inherits="User_Control_us_FacultyDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccf" %>
<div class="section-header">
    <div class="title">
        <img src="Images/forms/ico-promotions.png" alt="Edit campaign details">
        Teachers&#39; Details</div>
    <div class="options">
    </div>
</div>
<div style="width: 787px">
    <%--<asp:Button ID="btnclear" runat="server" Text="Clear" OnClick="btnclear_Click" Style="float: right;
        margin: 0px 0px 0px 2px" CssClass="submitbtn" />--%>
    <%--   <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" ValidationGroup="savef"
        Style="float: right; margin: 0px 0px 0px 2px" CssClass="submitbtn" />--%>
</div>
<br />
<br />
<div style="padding-bottom: 10px;">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblSDZoneName" runat="server" Text="Super Duper Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="ddlSDZone" Width="160px" DataTextField="SDZoneName"  TabIndex="0"
                            DataValueField="SDZoneId" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlSDZone_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Select Super Duper Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="ddlSDZone">*</asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblsuperzoe" runat="server" Text="Super Zone :"></asp:Label>
            </td>
            <td valign="top">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList CssClass="ddl-form" ID="DDLSuperZone" TabIndex="1" runat="server" DataTextField="SuperZoneName"
                            DataValueField="SuperZoneID" Width="160px" OnSelectedIndexChanged="DDLSuperZone_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="reqsuper" runat="server" ErrorMessage="Please Select SuperZone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLSuperZone">*</asp:RequiredFieldValidator>
                        <ccf:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="CustomValidatorCallOutStyle"
                            PopupPosition="Right" TargetControlID="reqsuper">
                        </ccf:ValidatorCalloutExtender>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSDZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="lblZone" runat="server" Text="Zone :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="upanel" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="DDLZone" runat="server" AutoPostBack="True" CssClass="ddl-form"
                            TabIndex="2" DataTextField="ZoneName" DataValueField="ZoneID" Width="160px" OnSelectedIndexChanged="DDLZone_SelectedIndexChanged">
                        </asp:DropDownList>
                       <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Zone"
                            InitialValue="0" ValidationGroup="savef" ControlToValidate="DDLZone" Display="None">*</asp:RequiredFieldValidator>
                          <ccf:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" HighlightCssClass="CustomValidatorCallOutStyle"
                            PopupPosition="Right" TargetControlID="RequiredFieldValidator2">
                        </ccf:ValidatorCalloutExtender>--%>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td style="padding-left: 60px;">
                <asp:Button ID="btnsave" runat="server" Text="Save" TabIndex="16" OnClick="btnsave_Click"
                    ValidationGroup="savef" CssClass="submitbtn" />
            </td>
        </tr>
        <tr>
         
            <td colspan="6" align="center">
              <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblsdzselect"  ForeColor="Red" runat="server" Visible="false"></asp:Label>
                   </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSDZone" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                         <asp:AsyncPostBackTrigger ControlID="DDLZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
          <%--  <td>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblszselect" Width="160px" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLSuperZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Label ID="lblzselect" Width="160px" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DDLZone" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>--%>
        </tr>
    </table>
</div>
<asp:Panel ID="pnladdform" runat="server" CssClass="panelDetails" Width="749px">
    <asp:Label ID="lblfacultyid" Style="display: none;" runat="server" Text="0"></asp:Label>
    <table>
        <tr>
            <td>
                <asp:Label ID="lbladdname" runat="server" Text="Name:"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtaddname" runat="server" TabIndex="3" OnTextChanged="txtaddname_TextChanged"
                    CssClass="inp-form" Width="379px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtaddname"
                    Display="None" ErrorMessage="Please insert name" ValidationGroup="savef">*</asp:RequiredFieldValidator>
                <ccf:ValidatorCalloutExtender ID="validfname" runat="server" HighlightCssClass="CustomValidatorCallOutStyle"
                    PopupPosition="Right" TargetControlID="RequiredFieldValidator1">
                </ccf:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdsch" runat="server" Text="Name of the Institute/School:"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtaddschool" CssClass="inp-form" runat="server" TabIndex="4" Width="379px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdaddress" runat="server" Text="Residence Address:"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtaddaddress" CssClass="inp-form" runat="server" TextMode="MultiLine"
                    TabIndex="5" Width="379px"></asp:TextBox>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdpin" runat="server" Text="Pincode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtaddpincode" CssClass="inp-form" runat="server" TabIndex="6" MaxLength="6"
                    Width="128px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdcontact" runat="server" Text="Contact No: Cell no.:"></asp:Label>
                &nbsp;
            </td>
            <td>
                <asp:TextBox ID="txtaddcontact" runat="server" CssClass="inp-form" MaxLength="10"
                    TabIndex="7" Width="128px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:Label ID="lbladdresno" runat="server" Text="Res.No:"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="txtaddresno" runat="server" CssClass="inp-form" TabIndex="8" Width="128px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtaddcontact"
                    Display="None" ErrorMessage="Please insert cell no" Text="*" ValidationGroup="savef">
                </asp:RequiredFieldValidator>
                <ccf:ValidatorCalloutExtender ID="validfrgno" runat="server" HighlightCssClass="CustomValidatorCallOutStyle"
                    PopupPosition="Right" TargetControlID="RequiredFieldValidator3">
                </ccf:ValidatorCalloutExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdqual" runat="server" Text="Qualification:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtaddqual" Width="128px" CssClass="inp-form" runat="server" TabIndex="9"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lbladdtchexp" runat="server" Text="Teaching Experience:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtaddtchexp" Width="128px" runat="server" CssClass="inp-form" TabIndex="10"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdsplsub" runat="server" Text="Specialized Subject:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtaddsplsub" Width="128px" CssClass="inp-form" runat="server" TabIndex="11"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdints" runat="server" Text="In which subject Interested in Writing:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtaddints" Width="128px" CssClass="inp-form" runat="server" TabIndex="12"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdprvsexp" runat="server" Text="Any previous experience of writing:"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoyesno" runat="server" RepeatDirection="Horizontal" TabIndex="13">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdplsbook" runat="server" Text="If yes, please mention name of books and Publisher:"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtaddplsbooks" Width="379px" CssClass="inp-form" runat="server"
                    TabIndex="14" TextMode="MultiLine"></asp:TextBox>
                &nbsp; &nbsp; &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbladdplsbook0" runat="server" Text="Remarks:"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="inp-form" TabIndex="15" TextMode="MultiLine"
                    Width="379px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Panel>
