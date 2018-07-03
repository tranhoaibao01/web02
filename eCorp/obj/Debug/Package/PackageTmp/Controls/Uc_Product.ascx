<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Uc_Product.ascx.cs" Inherits="eCorp.Controls.Uc_Product" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
</style>

<asp:DataList ID="DataList1" runat="server" RepeatColumns="3" Width="500px">
    <ItemTemplate>
        <table cellpadding="0" cellspacing="3" class="style1">
            <tr>
                <td align="center">
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageURL") %>' />
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" 
                        Text='<%# Eval("ProductTitle") %>'></asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label2" runat="server" Text="Hiện trạng:"></asp:Label>
                    &nbsp;
                    <asp:HyperLink ID="HyperLink3" runat="server">Còn hàng</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Label ID="Label3" runat="server" Text="Giá:"></asp:Label>
                    &nbsp;<asp:HyperLink ID="HyperLink4" runat="server">Liên hệ</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        AlternateText="sdfgsdfgsdfgsdf" ForeColor="White" Height="30px" 
                        ImageUrl="~/Images/Orthers/Button_Detail.png" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>

