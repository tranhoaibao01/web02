<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Tin_tuc.aspx.cs" Inherits="eCorp.App_WebPages.Tin_tuc" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style3">
        <tr>
            <td>
                Tin mới
            </td>
        </tr>
        <tr>
            <td style=" background-color:White;" align="left" valign="top">
                <asp:FormView ID="fvHotNews" runat="server" Width="500px">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="style3">
                            <tr>
                                <td align="center" style="height: 29px">
                                    <asp:Label ID="fvHotNews_ltrTitle" runat="server" Text='<%# Eval("Title") %>' 
                                        Font-Bold="True" Font-Names="Tahoma" Font-Size="Larger" 
                                        ForeColor="#000066"></asp:Label>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100% ">
                                    <asp:ImageButton ID="fvHotNews_imgImageURL" runat="server"
                                        Width="100%" AlternateText='<%# "No Picture" %>' 
                                        ImageUrl='<%# Eval("ImageURL") %>' 
                                        PostBackUrl='<%# "~/App_WebPages/Tin_tuc_chi_tiet.aspx?ID=" + Eval("NewsID") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td align="justify" valign="top">
                                    <asp:Label ID="fvHotNews_ltrShortDescript" runat="server" Font-Bold="True" 
                                        Font-Names="Tahoma" Text='<%# Eval("ShortDescript") %>'></asp:Label>
                                    <asp:HyperLink ID="fvHotNews_hplChiTiet" runat="server" 
                                        NavigateUrl='<%# "~/App_WebPages/Tin_tuc_chi_tiet.aspx?ID=" + Eval("NewsID") %>'>Xem chi tiết</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
            </td>
        </tr>
        <tr>
            <td>
                Các tin đã đăng 
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListView ID="lvPostedNews" runat="server">
                    <ItemTemplate>
                        <table style=" background-color:White" width="500px">
                            <tr>
                                <td style=" width:100px; height:100px;  border-bottom-style:groove; border-bottom-width:1px; 
                                    border-bottom-color:Black"> 
                                    <asp:ImageButton ID="lvPostedNews_imgImageURL" runat="server" Width="100px" 
                                    ImageUrl='<%# Eval("ImageURL") %>' 
                                    PostBackUrl='<%# "~/App_WebPages/Tin_tuc_chi_tiet.aspx?ID=" + Eval("NewsID") %>' />
                                </td>
                                <td align="justify" valign="top" style=" width:400px; height:100px; border-bottom-style:groove; border-bottom-width:1px;
                                    border-bottom-color:Black"> 
                                    <asp:Label ID="lvPostedNews_ltrTitle" runat="server" Text='<%# Eval("Title") %>'
                                    Font-Bold="True" Font-Names="Tahoma" 
                                        ForeColor="#000066"></asp:Label>
                                    <br />
                                    <asp:Label ID="lvPostedNews_ltrShortDescript" runat="server" Text='<%# Eval("ShortDescript") %>'
                                     Font-Names="Tahoma" Font-Bold="true"></asp:Label>
                                    <asp:HyperLink ID="lvPostedNews_hplChiTiet" runat="server" 
                                        NavigateUrl='<%# "~/App_WebPages/Tin_tuc_chi_tiet.aspx?ID=" + Eval("NewsID") %>'>Xem chi tiết</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataPager ID="DataPager1" QueryStringField="Page" PagedControlID="lvPostedNews" runat="server">
                    <Fields>               
                        <asp:NumericPagerField ButtonType="Link" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</asp:Content>
