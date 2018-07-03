<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="eCorp.App_WebPages.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dtlProducts" runat="server" BorderStyle="Groove" 
    CellPadding="0" RepeatColumns="3" Width="100%">
    <ItemTemplate>
        <table cellpadding="0" cellspacing="3" class="style2">
            <tr>
                <td align="center">
                    <asp:Image ID="Image5" runat="server" ImageUrl='<%# Eval("ImageURL") %>' 
                        Height="150px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:HyperLink ID="HyperLink10" runat="server" 
                        Text='<%# Eval("ProductTitle") %>'></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label2" runat="server" Text="Hiện trạng:"></asp:Label>
                    &nbsp;<asp:HyperLink ID="HyperLink11" runat="server">Còn hàng</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text="Giá:"></asp:Label>
                    &nbsp;<asp:HyperLink ID="HyperLink12" runat="server">Liên hệ</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" 
                        ImageUrl="~/Images/Orthers/Button_Detail.png" 
                        PostBackUrl="~/App_WebPages/ProductDetail.aspx?ID=ProductID" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
</asp:Content>
