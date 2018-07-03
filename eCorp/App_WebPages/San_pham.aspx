<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="San_pham.aspx.cs" Inherits="eCorp.App_WebPages.San_pham" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0">
    <tr>
        <td style="height:28px; background-color: #CCCCFF; border-top-style: double; border-top-color: #FFFFFF; border-top-width: thin; border-bottom-style: double; border-bottom-width: thin; border-bottom-color: #FFFFFF;" 
            valign="middle">
            &nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image6" runat="server" 
                ImageUrl="~/Images/Orthers/Bullet_02.GIF" />
            <asp:Label ID="lbProductLink" runat="server" 
                Text="Gạch &gt; Gạch lát &gt; Gạch bông kính" Font-Bold="False" 
                Font-Names="Tahoma" Font-Overline="False" ForeColor="#003366"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" style=" width:500px">
            <asp:ListView ID="dtlProducts" runat="server" GroupItemCount="3">
                <LayoutTemplate>
                    <table>
                            <tr ID="groupPlaceholder" runat="server">
                            </tr>
                    </table>
                </LayoutTemplate>
                <GroupTemplate>
                    <tr>
                        <td ID="itemPlaceholder" runat="server">

                        </td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td align="center" valign="top">
                        <asp:Image ID="Image5" runat="server" ImageUrl='<%# Eval("ImageURL") %>' 
                                Width="150px" Height = "150px" GenerateEmptyAlternateText="True" /><br />
                        <asp:HyperLink ID="HyperLink10" runat="server" 
                            Text='<%# Eval("ProductTitle") %>' 
                            NavigateUrl='<%# "~/App_WebPages/ProductDetail.aspx?ID=" + Eval("ProductID") %>'>
                        </asp:HyperLink><br />
                        <asp:ImageButton ID="ibtnDetail" runat="server" Height="20px" 
                            ImageUrl="~/Images/Orthers/Chi_tiet.png" 
                            PostBackUrl='<%# "~/App_WebPages/San_pham_chi_tiet.aspx?ID=" + Eval("ProductID") %>' />
                    </td>
                </ItemTemplate>
                <GroupSeparatorTemplate>
                    <tr id="Tr1" runat="server">
                    <td colspan="3"><hr /></td>
                    </tr>
                </GroupSeparatorTemplate> 
            </asp:ListView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataPager ID="DataPager1" QueryStringField="Page" PagedControlID="dtlProducts" runat="server" PageSize="12">
                <Fields>               
                    <asp:NumericPagerField ButtonType="Link"/>
                </Fields>
            </asp:DataPager>
        </td>
    </tr>
    </table>
</asp:Content>
