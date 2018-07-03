<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="ServiceManage.aspx.cs" Inherits="eCorp.App_WebAdmins.ServiceManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="lbModeMessage" runat="server" Text="Cập nhập dịch vụ"></asp:Label>
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
                        <asp:BoundField DataField="ServiceID" HeaderText="Mã" />
                        <asp:BoundField DataField="ServiceName" HeaderText="Tên dịch vụ" />
                        <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Hình ảnh">
                        </asp:ImageField>
                        <asp:TemplateField HeaderText="Chức năng">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ServiceID") %>' 
                                    CommandName="btnEdit" Text="Sửa" Width="50px" />
                                <asp:Button ID="btnDelete" runat="server" 
                                    CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ServiceID") %>' 
                                    CommandName="btnDelete" Text="Xóa" Width="50px" />
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
