<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="CustomerManage.aspx.cs" Inherits="eCorp.App_WebAdmins.CustomerManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="lbTitle" runat="server" Text="Quản lý danh mục khách hàng"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnInsert1" runat="server" Text="Thêm mới" 
                    onclick="btnInsert1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gView" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="gView_RowCommand" onrowediting="gView_RowEditing">
                    <Columns>
                        <asp:BoundField DataField="CustomerID" HeaderText="ID" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Tên khách hàng" />
                        <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Hình ảnh">
                        </asp:ImageField>
                        <asp:HyperLinkField 
                            DataTextField="Website" HeaderText="Website" />
                        <asp:HyperLinkField DataTextField="Email" 
                            HeaderText="Email" />
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CustomerID") %>' 
                                    CommandName="btnEdit" Text="Sửa" />
                                <asp:Button ID="btnDelete" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CustomerID") %>' 
                                    CommandName="btnDelete" Text="Xóa" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnInsert2" runat="server" Text="Thêm mới" 
                    onclick="btnInsert2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
