<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Chi_nhanh.aspx.cs" Inherits="eCorp.App_WebPages.Chi_nhanh" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style3">
        <tr>
            <td style="background-color: #CCCCFF; border-top-style: double; border-top-width: thin; border-top-color: #FFFFFF; border-bottom-style: double; border-bottom-width: thin; border-bottom-color: #FFFFFF; height: 28px" 
                valign="middle">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image5" runat="server" 
                    ImageUrl="~/Images/Orthers/Bullet_02.GIF" />
                        &nbsp;<asp:Label ID="Label6" runat="server" Text="Chi nhánh" Font-Names="Tahoma" 
                    ForeColor="#000066"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListView ID="ListView1" runat="server">
                <ItemTemplate>
                <table style="width:100%; border-bottom-style:inset; border-bottom-width:1px; background-color:White">
                <tr>
                    <td style="width:100%">
                        <asp:Label ID="Label1" Font-Names="Tohoma" Font-Bold="true" ForeColor="Red" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <%--<td style=" width:50px">
                        <asp:Image ID="Image5" runat="server"  Width="50px"
                            ImageUrl='<%# Eval("ImageUrl") %>'/>
                    </td>--%>
                    <td style="width:100%">
                        <asp:Label ID="Label2" Font-Names="Tohoma" Font-Bold="true" runat="server" Text="Địa chỉ:"></asp:Label>
                        <asp:Label ID="Label3" Font-Names="Tohoma" runat="server" Text='<%# Eval("Address") %>'></asp:Label><br />
                        <asp:Label ID="Label4" Font-Names="Tohoma" Font-Bold="true" runat="server" Text="Điện thoại:"></asp:Label>
                        <asp:Label ID="Label5" Font-Names="Tohoma" runat="server" Text='<%# Eval("Phone") %>'></asp:Label><br />
                        <asp:Label ID="Label6" Font-Names="Tohoma" Font-Bold="true" runat="server" Text="Fax:"></asp:Label>
                        <asp:Label ID="Label7" Font-Names="Tohoma" runat="server" Text='<%# Eval("Fax") %>'></asp:Label><br />
                        <asp:Label ID="Label8" Font-Names="Tohoma" Font-Bold="true" runat="server" Text="Email:"></asp:Label>
                        <asp:Label ID="Label9" Font-Names="Tohoma" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:100%" align="justify">
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Contents") %>'></asp:Literal>
                    </td>
                </tr>
                </table>
                </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="1" QueryStringField="Page">
                    <Fields>               
                        <asp:NumericPagerField ButtonType="Link" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</asp:Content>
