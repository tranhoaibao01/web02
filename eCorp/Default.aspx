<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eCorp.App_WebPages.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style2">
        <tr>
            <td height="30px" 
                style="background-color: #000000; border-bottom-style: double; border-bottom-color: #FFFFFF; border-bottom-width: thin;" 
                valign="bottom">
                &nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image5" runat="server" Height="20px" 
                    ImageUrl="~/Images/Orthers/check_blue_01.png" />
                &nbsp;<asp:HyperLink ID="HyperLink10" runat="server" Font-Bold="True" 
                    ForeColor="White" Font-Italic="False" Font-Names="Arial">Gạch</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" valign="top" width="100%">
                <asp:DataList ID="ddl_Product_Gach" runat="server" RepeatColumns="3" 
                    Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="3" class="style2">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl='<%# Eval("ImageURL") %>' Height="150px" Width="150px" 
                                        PostBackUrl='<%# "~/App_WebPages/ProductDetail.aspx?ID=" + Eval("ProductID") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style1">
                                    <asp:HyperLink ID="HyperLink11" runat="server" 
                                        Text='<%# Eval("ProductTitle") %>' 
                                        
                                        NavigateUrl='<%# "~/App_WebPages/ProductDetail.aspx?ID=" + Eval("ProductID") %>' 
                                        Font-Bold="True" Font-Names="Arial" Font-Size="Smaller" 
                                        style="font-weight: 700"></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                                        
                                        
                                        
                                        
                                        PostBackUrl='<%# "~/App_WebPages/San_pham_chi_tiet.aspx?ID=" + Eval("ProductID") %>' 
                                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" 
                                        ImageUrl="~/Images/Orthers/Chi_tiet.png" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td style=" height:10px; border-bottom-style: double; border-bottom-width: thin; border-bottom-color: #FFFFFF;" 
                align="right" valign="top">

                <asp:HyperLink ID="HyperLink16" runat="server" Font-Names="Arial" 
                    Font-Size="Smaller" ForeColor="White">Xem thêm&gt;&gt;</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td height="30px" 
                style="background-color: #000000; border-bottom-style: double; border-bottom-color: #FFFFFF; border-bottom-width: thin;" 
                valign="bottom">
                &nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image6" runat="server" Height="20px" 
                    ImageUrl="~/Images/Orthers/check_blue_01.png" Width="20px" />
                &nbsp;<asp:HyperLink ID="HyperLink11" runat="server" Font-Bold="True" 
                    Font-Italic="False" ForeColor="White" Font-Names="Arial">Thiết bị WC</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="ddl_Product_Wc" runat="server" RepeatColumns="3" Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="3" class="style2">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl='<%# Eval("ImageURL") %>' Height="150px" Width="150px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style1">
                                    <asp:HyperLink ID="HyperLink14" runat="server" 
                                        Text='<%# Eval("ProductTitle") %>' Font-Bold="True" Font-Names="Arial" 
                                        Font-Size="Smaller" 
                                        NavigateUrl='<%# "~/App_WebPages/ProductDetail.aspx?ID=" + Eval("ProductID") %>'></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                                        ImageUrl="~/Images/Orthers/Chi_tiet.png" 
                                        
                                        PostBackUrl='<%# "~/App_WebPages/San_pham_chi_tiet.aspx?ID=" + Eval("ProductID") %>' 
                                        BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td style=" height:10px; border-bottom-style: double; border-bottom-width: thin; border-bottom-color: #FFFFFF;" 
                align="right" valign="top">

                <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Arial" 
                    Font-Size="Smaller" ForeColor="White">Xem thêm&gt;&gt;</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td height="30px" 
                style="background-color: #000000; border-bottom-style: double; border-bottom-color: #FFFFFF; border-bottom-width: thin;" 
                valign="bottom">
                &nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image7" runat="server" Height="20px" 
                    ImageUrl="~/Images/Orthers/check_blue_01.png" Width="20px" />
                <asp:HyperLink ID="HyperLink12" runat="server" Font-Bold="True" 
                    Font-Italic="False" ForeColor="White" Font-Names="Arial">Thiết bị bếp</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="ddl_Product_Bep" runat="server" RepeatColumns="3" 
                    Width="100%">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="3" class="style2">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl='<%# Eval("ImageURL") %>' Height="150px" Width="150px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="style1">
                                    <asp:HyperLink ID="HyperLink14" runat="server" 
                                        Text='<%# Eval("ProductTitle") %>' Font-Bold="True" Font-Names="Arial" 
                                        Font-Size="Smaller" 
                                        NavigateUrl='<%# "~/App_WebPages/ProductDetail.aspx?ID=" + Eval("ProductID") %>'></asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="ImageButton2" runat="server" BorderColor="#CCCCCC" 
                                        BorderStyle="Solid" BorderWidth="1px" Height="25px" 
                                        ImageUrl="~/Images/Orthers/Chi_tiet.png" 
                                        PostBackUrl='<%# "~/App_WebPages/San_pham_chi_tiet.aspx?ID=" + Eval("ProductID") %>' />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td style=" height:10px" align="right" valign="top">

                <asp:HyperLink ID="HyperLink2" runat="server" Font-Names="Arial" 
                    Font-Size="Smaller" ForeColor="White">Xem thêm&gt;&gt;</asp:HyperLink>
                    &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
