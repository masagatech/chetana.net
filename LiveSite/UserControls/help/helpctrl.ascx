<%@ Control Language="C#" AutoEventWireup="true" CodeFile="helpctrl.ascx.cs" Inherits="UserControls_help_helpctrl" %>

<script type="text/javascript">
</script>
 <asp:Label ID="lblhelp" runat="server"></asp:Label>
<asp:UpdatePanel ID="upHelp" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <asp:ListBox ID="lstShorthelp" DataTextField="Name" DataValueField="Name" runat="server"
            Height="400px" Width="200px"></asp:ListBox>
    </ContentTemplate>
</asp:UpdatePanel>
