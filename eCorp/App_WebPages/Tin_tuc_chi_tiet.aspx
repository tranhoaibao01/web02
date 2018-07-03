<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Tin_tuc_chi_tiet.aspx.cs" Inherits="eCorp.App_WebPages.Tin_tuc_chi_tiet" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style3">
        <tr>
            <td>
                &gt;&gt; Tin tức</td>
        </tr>
        <tr>
            <td>
                <asp:FormView ID="FormView1" runat="server" AllowPaging="True" Width="500px">
                    <ItemTemplate>
                        <table cellpadding="0" cellspacing="0" class="style3" style="width: 500px; background-color:White">
                            <tr>
                                <td align="center" valign="top">
                                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" 
                                        Font-Size="Larger" Text='<%# Eval("Title") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height: 16px">
                                    <asp:Image ID="Image5" runat="server" ImageUrl='<%# Eval("ImageURL") %>' 
                                        Width="500px" />
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
                Các tin đã đăng
            </td>
        </tr>
        <tr>
            <td style="width:500px; background-color:White">
                <asp:ListView ID="ListView1" runat="server">
                    <ItemTemplate>
                        <table>
                            <tr>
                                <td align="left" valign="top"> 
                                    <asp:HyperLink ID="HyperLink1" runat="server" 
                                        NavigateUrl='<%# "~/App_WebPages/Tin_tuc_chi_tiet.aspx?ID=" + Eval("NewsID") %>'><%# Eval("Title") %></asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:ListView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataPager ID="DataPager1" QueryStringField="Page" PagedControlID="ListView1" runat="server">
                    <Fields>               
                        <asp:NumericPagerField ButtonType="Link" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    </table>
</asp:Content>
