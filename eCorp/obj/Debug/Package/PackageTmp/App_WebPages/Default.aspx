<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eCorp.App_WebPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style4
        {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td>
                <asp:Image ID="Image5" runat="server" Height="10px" 
                    ImageUrl="~/Images/Orthers/600px-Black_check.svg.png" />
                <asp:HyperLink ID="HyperLink10" runat="server">Gạch</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" width="100%">
                <asp:DataList ID="ddl_Product_Gach" runat="server" RepeatColumns="3" 
                    Width="100%" BorderStyle="Groove">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="3" class="style2">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl='<%# Eval("ImageURL") %>' Height="150px" Width="150px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style4">
                                    <asp:HyperLink ID="HyperLink11" runat="server" 
                                        Text='<%# Eval("ProductTitle") %>'></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label3" runat="server" Text="Hiện trạng:"></asp:Label>
                                    &nbsp;<asp:HyperLink ID="HyperLink12" runat="server">Còn hàng</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" Text="Giá:"></asp:Label>
                                    &nbsp;<asp:HyperLink ID="HyperLink13" runat="server">Liên hệ</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                                        ImageUrl="~/Images/Orthers/Button_Detail.png" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image6" runat="server" Height="10px" 
                    ImageUrl="~/Images/Orthers/600px-Black_check.svg.png" />
                <asp:HyperLink ID="HyperLink11" runat="server">Thiết bị WC</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="ddl_Product_Wc" runat="server" RepeatColumns="3" Width="100%" 
                    BorderStyle="Groove">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="3" class="style2">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl='<%# Eval("ImageURL") %>' Height="150px" Width="150px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style4">
                                    <asp:HyperLink ID="HyperLink14" runat="server" 
                                        Text='<%# Eval("ProductTitle") %>'></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label3" runat="server" Text="Hiện trạng:"></asp:Label>
                                    &nbsp;<asp:HyperLink ID="HyperLink15" runat="server">Còn hàng</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" Text="Giá:"></asp:Label>
                                    &nbsp;<asp:HyperLink ID="HyperLink13" runat="server">Liên hệ</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                                        ImageUrl="~/Images/Orthers/Button_Detail.png" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image7" runat="server" Height="10px" 
                    ImageUrl="~/Images/Orthers/600px-Black_check.svg.png" />
                <asp:HyperLink ID="HyperLink12" runat="server">Thiết bị bếp</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="ddl_Product_Bep" runat="server" RepeatColumns="3" 
                    Width="100%" BorderStyle="Groove">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="3" class="style2">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl='<%# Eval("ImageURL") %>' Height="150px" Width="150px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style4">
                                    <asp:HyperLink ID="HyperLink14" runat="server" 
                                        Text='<%# Eval("ProductTitle") %>'></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label3" runat="server" Text="Hiện trạng:"></asp:Label>
                                    &nbsp;<asp:HyperLink ID="HyperLink15" runat="server">Còn hàng</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" Text="Giá:"></asp:Label>
                                    &nbsp;<asp:HyperLink ID="HyperLink13" runat="server">Liên hệ</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                                        ImageUrl="~/Images/Orthers/Button_Detail.png" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>
