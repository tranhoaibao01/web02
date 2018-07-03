<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="CategoriesManage.aspx.cs" Inherits="eCorp.App_WebAdmins.CategoriesManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
        <tr>
            <td align="left">
                <asp:Label ID="lbTitle" runat="server" Text="Quản trị danh mục thể loại"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="btnInsert1" runat="server" Text="Thêm mới" Width="70px" 
                    onclick="btnInsert1_Click" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:GridView ID="gView" runat="server" AutoGenerateColumns="False" 
                    onrowcommand="gView_RowCommand" onrowediting="gView_RowEditing">
                    <Columns>
<asp:BoundField DataField="ID" HeaderText="ID" Visible="False"></asp:BoundField>
                        <asp:BoundField DataField="ParentID" HeaderText="Parent Id" Visible="False" />
                        <asp:BoundField DataField="Level" HeaderText="Bậc" />
                        <asp:BoundField DataField="CateID" HeaderText="Mã thể loại" />
                        <asp:BoundField DataField="CateName" HeaderText="Tên thể loại" />
                        <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Hình ảnh">
                        </asp:ImageField>
                        <asp:BoundField DataField="CatePos" HeaderText="Vị trí" />
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CateID") %>' 
                                    CommandName="btnEdit" Text="Sửa" Width="50px" />
                                &nbsp;<asp:Button ID="btnDelete" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CateID") %>' 
                                    CommandName="btnDelete" Text="Xóa" Width="50px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="btnInsert2" runat="server" Text="Thêm mới" Width="70px" 
                    onclick="btnInsert2_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
