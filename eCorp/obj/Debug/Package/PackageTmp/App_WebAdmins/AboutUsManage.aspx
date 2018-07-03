<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebAdmin.Master" AutoEventWireup="true" CodeBehind="AboutUsManage.aspx.cs" Inherits="eCorp.App_WebAdmins.AboutUsManage" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%" cellpadding="1" cellspacing="10">
    <tr>
        <td align="left">
            &nbsp;</td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btnInsert1" runat="server" onclick="btnInsert1_Click" 
                Text="Thêm mới" />
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:GridView ID="gView" runat="server" AutoGenerateColumns="False" 
                onrowcommand="gView_RowCommand" onrowediting="gView_RowEditing">
                <Columns>
                    <asp:BoundField DataField="IntroID" HeaderText="ID" />
                    <asp:TemplateField HeaderText="Nội dung giới thiệu">
                        <ItemTemplate>
                            <asp:Literal ID="ltrDescription" runat="server" 
                                Text='<%# Eval("Description") %>'></asp:Literal>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="Active" HeaderText="Kích hoạt">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CheckBoxField>
                    <asp:TemplateField HeaderText="Chức năng">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" 
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"IntroID") %>' 
                                CommandName="btnEdit" Text="Sửa" Width="50px" />
                            <br />
                            <asp:Button ID="btnDelete" runat="server" 
                                CommandArgument='<%#DataBinder.Eval(Container.DataItem,"IntroID") %>' 
                                CommandName="btnDelete" Text="Xóa" Width="50px" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Button ID="btnInsert2" runat="server" onclick="btnInsert2_Click" 
                Text="Thêm mới" />
&nbsp;&nbsp;
            &nbsp;&nbsp;
            </td>
    </tr>
</table>
</asp:Content>
