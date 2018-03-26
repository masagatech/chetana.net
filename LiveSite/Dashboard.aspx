<%@ Page Language="C#" MasterPageFile="~/MasterPages/NewChetana.master" AutoEventWireup="true"
    CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" Title="Chetana:Dashboard" %>

<%@ Register Src="UserControls/uc_Dashboard.ascx" TagName="uc_Dashboard" TagPrefix="uc1" %>
<%@ Register Src="UserControls/uc_DragThings.ascx" TagName="uc_DragThings" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Css/dragthings.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="section-header">
        <table>
            <tr>
                <td>
                    <div class="title">
                        <img src="Images/forms/ico-promotions.png" alt="View" />
                        <span runat="server" id="pageName">DashBoard</span>
                    </div>
                    <div class="options">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <uc1:uc_Dashboard ID="uc_Dashboard1" runat="server" />
    <div style="display: none;">
        <uc2:uc_DragThings ID="uc_DragThings1" runat="server" />
    </div>
</asp:Content>
