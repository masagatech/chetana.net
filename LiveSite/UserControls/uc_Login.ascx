<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uc_Login.ascx.cs" Inherits="UserControls_uc_Login" %>
 <!-- Start: login-holder -->
    <div id="login-holder">
        <!-- start logo -->
        <div id="logo-login">
            <img src="Images/Logo/chetanaLogo.png"  class="log"/> 
            
        </div>
        <!-- end logo -->
        <div class="clear">
        </div>
        <!--  start loginbox ................................................................................. -->
        <div id="loginbox">
            <!--  start login-inner -->
            <div id="login-inner">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            User Name
                        </th>
                        <td>
                            <asp:TextBox  runat="server" ID="txtuser" class="login-inp" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Password
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtpwd" TextMode="Password" 
                                onfocus="this.value=''" class="login-inp" MaxLength="25" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Company</th>
                        <td>
                            <asp:DropDownList ID="ddlChetanaCompanyName" runat="server">
                                <asp:ListItem Selected="True" Value="cppl">Chetana Book Depot</asp:ListItem>
                                <asp:ListItem Value="cspl">Chetana Stationery</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            Financial Year</th>
                        <td>
                            <asp:DropDownList ID="ddlFinancialYear" runat="server" 
                            DataTextField="TextField" DataValueField="valuefield">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="display:none;">
                        
                        <td valign="top">
                            <asp:CheckBox class="checkbox-size" runat="server" ID="logincheck"/> <label for="login-check">
                            Remember
                                me</label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td>
                            <asp:Button runat="server" ID="btnlogin" Text="" class="submit-login" 
                                onclick="btnlogin_Click" />
                            <asp:Label ID="lblErrMsg" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <!--  end login-inner -->
            <div class="clear">
                <asp:Label ID="lblMsg" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
            <a href="" class="forgot-pwd"  style="display:none;">Forgot Password?</a>
        </div>
        <!--  end loginbox -->
        <!--  start forgotbox ................................................................................... -->
        <div id="forgotbox">
            <div id="forgotbox-text">
                Please send us your email and we'll reset your password.</div>
            <!--  start forgot-inner -->
            <div id="forgot-inner">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <th>
                            Email address:
                        </th>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmailId" class="login-inp" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                        </th>
                        <td>
                            <asp:Button runat="server" ID="btnsendPwd" Text="" class="submit-login" />
                        </td>
                    </tr>
                </table>
            </div>
            <!--  end forgot-inner -->
            <div class="clear">
            </div>
            <a href="" class="back-login">Back to login</a>
        </div>
        <!--  end forgotbox -->
    </div>
    <!-- End: login-holder -->