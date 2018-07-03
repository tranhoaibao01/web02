<%@ Page Title="Quản trị sản phẩm" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="ProductManage.aspx.cs" Inherits="eCorp.App_WebAdmins.ProductManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="5" cellspacing="5" style="width: 100%" border="0">
    <tr>
        <td align="left">
            <asp:Label ID="lbTitle" runat="server" Text="Quản lý danh sách sản phẩm"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <hr />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="height: 59px" align="left">
            <asp:Label ID="Label2" runat="server" Text="Chọn thể loại sản phẩm"></asp:Label>
            :&nbsp;
            <asp:DropDownList ID="ddlCategories" runat="server" AutoPostBack="True" 
                onselectedindexchanged="ddlCategories_SelectedIndexChanged" Width="234px">
                <asp:ListItem Value="CateID"></asp:ListItem>
                <asp:ListItem Value="CateName"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="height: 59px">
            </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btnInsert1" runat="server" onclick="btnInsert1_Click" 
                Text="Thêm mới" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            <asp:GridView ID="gvProducts" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" 
                onrowcommand="gvProducts_RowCommand" onrowediting="gvProducts_RowEditing" 
                onpageindexchanging="gvProducts_PageIndexChanging" PageSize="5" 
                onselectedindexchanged="gvProducts_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="CateID" HeaderText="Mã thề loại" Visible="False" />
                    <asp:BoundField DataField="CateName" HeaderText="Loại sản phẩm" 
                        ReadOnly="True" />
                    <asp:BoundField DataField="ProductID" HeaderText="Mã sản phẩm" 
                        ReadOnly="True" />
                    <asp:HyperLinkField DataNavigateUrlFields="ProductID" 
                        DataNavigateUrlFormatString="ProductEdit.aspx?ProductID={0}" 
                        DataTextField="ProductTitle" HeaderText="Tên sản phẩm" />
                    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Hình ảnh">
                    </asp:ImageField>
                    <asp:HyperLinkField DataNavigateUrlFields="ProductID" 
                        DataNavigateUrlFormatString="ProductEdit.aspx?ProductID={0}" HeaderText="Sửa" 
                        Text="Sửa" Visible="False" />
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemTemplate>
                            &nbsp;<asp:LinkButton ID="LinkButton14" runat="server" 
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ProductID") %>' 
                                CommandName="Edit">Sửa</asp:LinkButton>
&nbsp;
                            <asp:Button ID="btnDelete" runat="server" 
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ProductID") %>' 
                                CommandName="Delete" 
                                onclientclick="if (confirm('Bạn muốn xóa tài khoản này?') == false) return false;" 
                                Text="Xóa" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
        <td align="left" style="width: 15px">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btnInsert2" runat="server" onclick="btnInsert2_Click" 
                Text="Thêm mới" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
