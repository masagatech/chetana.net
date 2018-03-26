<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Calender.ascx.cs" Inherits="UserControls_ODC_receipt_Calender" %>
<%@ Register Namespace="DataControls" Assembly="DataCalendar" TagPrefix="dc" %>

        <div id="Content">
            <div class="box">
                <div class="box-head">
                    <div class="headerbox">
                    </div>
                </div>
                <div class="divRightBar">
                    <dc:DataCalendar ID="dcEventsCalendar" runat="server" DayField="Date" Width="903px"
                        NextPrevFormat="FullMonth" Height="190px">
                        <DayStyle Height="60px" Width="100px" />
                        <itemtemplate>
                            <a href='<%# "ChequeCashReport.aspx?a=a&Date="+ Container.DataItem["RDate"]  %>'  title='<%# Container.DataItem["Date"] %>'>
                            <asp:Label ID="Label1" runat="server" Text='<%# "("+ Container.DataItem["Count"]+")" %>' CssClass="BoldLabel" title='<%# Container.DataItem["Date"] %>' Font-Bold="True" Font-Size="Larger"></asp:Label>
                            </a>
                        </itemtemplate>
                    </dc:DataCalendar>
                </div>
            </div>
        </div>
