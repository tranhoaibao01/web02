<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Gioi_thieu.aspx.cs" Inherits="eCorp.App_WebPages.Gioi_thieu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style2" width="100%">
        <tr>
            <td valign="bottom" style="height: 30px">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image16" runat="server" Height="20px" 
                    ImageUrl="~/Images/Orthers/check_blue_01.png" Width="20px" />
                <asp:Label ID="Label7" runat="server" Text="Giới thiệu"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FormView1" runat="server" Width="500px">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="style3">
                            <tr>
                                <td align="justify" valign="top" width="500px">
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
