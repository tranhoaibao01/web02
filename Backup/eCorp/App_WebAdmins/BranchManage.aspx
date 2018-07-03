<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="BranchManage.aspx.cs" Inherits="eCorp.App_WebAdmins.BranchManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table cellpadding="0" cellspacing="5" style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="lbTitle" runat="server" Text="Quản lý thông tin liên hệ"></asp:Label>
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
                        <asp:BoundField DataField="BranchID" HeaderText="Mã" />
                        <asp:BoundField DataField="FullName" HeaderText="Tên chi nhánh" />
                        <asp:TemplateField HeaderText="Ảnh">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' 
                                    Width="100px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Address" HeaderText="Địa chỉ" />
                        <asp:BoundField DataField="Phone" HeaderText="Điện thoại" />
                        <asp:BoundField DataField="Mobile" HeaderText="Di động" />
                        <asp:BoundField DataField="Fax" HeaderText="Fax" />
                        <asp:HyperLinkField DataTextField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="WebSite" HeaderText="Website" />
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"BranchID") %>' 
                                    CommandName="btnEdit" Text="Sửa" />
                                <asp:Button ID="btnDelete" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"BranchID") %>' 
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
