<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="San_pham_chi_tiet.aspx.cs" Inherits="eCorp.App_WebPages.San_pham_chi_tiet" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style3">
        <tr>
            <td style="background-color: #CCCCFF; border-top-style: double; border-bottom-style: double; border-top-width: 1px; border-bottom-width: 1px; border-top-color: #FFFFFF; border-bottom-color: #FFFFFF; height: 28px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image6" runat="server" 
                    ImageUrl="~/Images/Orthers/Bullet_02.GIF" />
&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="Chi tiết sản phẩm" 
                    ForeColor="#000066"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="fvProductDetail" runat="server">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="style3" style=" width:500px">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ProductTitle") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Image ID="Image5" runat="server" ImageAlign="Middle" 
                                        ImageUrl='<%# Eval("ImageURL") %>' Width="450px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Giới thiệu"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </asp:Content>
