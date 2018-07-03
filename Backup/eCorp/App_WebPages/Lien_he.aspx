<%@ Page Title="" Language="C#" MasterPageFile="~/App_WebMaster/WebPage.Master" AutoEventWireup="true" CodeBehind="Lien_he.aspx.cs" Inherits="eCorp.App_WebPages.Lien_he" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="style3">
        <tr>
            <td style="height: 28px; border-top-style: double; border-bottom-style: double; border-top-width: 1px; border-bottom-width: 1px; border-top-color: #FFFFFF; border-bottom-color: #FFFFFF; background-color: #CCCCFF;">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image5" runat="server" 
                    ImageUrl="~/Images/Orthers/Bullet_02.GIF" />
                &nbsp;<asp:Label ID="Label6" runat="server" ForeColor="#000066" 
                    Text="Thông tin liên hệ"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding: 10px; margin: 10px">
                TRUNG TÂM VLXD LONG CHÂU</td>
        </tr>
        <tr>
            <td align="center" style="padding: 10px; margin: 10px">
                Địa chỉ: 73/17 Lê Đình Cẩn, Phường Tân Tạo, Quận Bình Tân<br />
                Điện thoại: (08) 39 574 176</td>
        </tr>
        <tr>
            <td style="padding: 10px; margin: 10px">
                Quý Khách có nhu cầu xin vui lòng để lại thông tin liên hệ ở form dưới. Chúng 
                tôi sẽ liên hệ với Quý Khách trong vòng 24h.</td>
        </tr>
        <tr>
            <td style="padding: 10px; margin: 10px">
                Lưu ý: Dấu * là bắt buộc</td>
        </tr>
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" class="style3">
                    <tr>
                        <td style="width: 80px; padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                            Họ tên *</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                            Địa chỉ</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                            Điện thoại</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                            Fax</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                            Email</td>
                        <td>
                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                            Tiêu đề</td>
                        <td>
                            <asp:TextBox ID="TextBox6" runat="server" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px; padding-top: 10px; padding-bottom: 10px; padding-left: 10px;">
                            Nội dung</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <CKEditor:CKEditorControl ID="ckEditor" runat="server" EnterMode="DIV" Width="">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
        <td align="center" 
                style="padding-top: 10px; padding-bottom: 10px; margin-top: 10px; margin-bottom: 10px">

            <asp:ImageButton ID="ImageButton1" runat="server" Height="20px" 
                ImageUrl="~/Images/Orthers/Chi_tiet.png" />
&nbsp;
            <asp:ImageButton ID="ImageButton2" runat="server" Height="20px" 
                ImageUrl="~/Images/Orthers/Chi_tiet.png" />

        </td>
        </tr>
    </table>
</asp:Content>
