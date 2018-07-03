<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="NewsManage.aspx.cs" Inherits="eCorp.App_WebAdmins.NewsManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="5" style="width: 100%">
    <tr>
        <td>
            <asp:Label ID="lbTitle" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnInsert1" runat="server" onclick="btnInsert1_Click" 
                Text="Thêm mới" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gView" runat="server" AutoGenerateColumns="False" 
                onrowcommand="gView_RowCommand" onrowediting="gView_RowEditing">
                <Columns>
                    <asp:BoundField DataField="NewsID" HeaderText="Mã" />
                    <asp:BoundField DataField="Title" HeaderText="Tiêu đề" />
                    <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Hình ảnh">
                    </asp:ImageField>
                    <asp:BoundField DataField="Copyright" HeaderText="Tác giả" />
                    <asp:BoundField DataField="ViewNumber" HeaderText="Lượt xem" />
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" 
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"NewsID") %>' 
                                CommandName="btnEdit" Text="Sửa" />
                            <asp:Button ID="btnDelete" runat="server" 
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"NewsID") %>' 
                                CommandName="btnDelete" Text="Xóa" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnInsert2" runat="server" onclick="btnInsert2_Click" 
                Text="Thêm mới" />
        </td>
    </tr>
</table>
</asp:Content>
