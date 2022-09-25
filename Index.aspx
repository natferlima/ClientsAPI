<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="clientsapi.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Digite o Id do cliente: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pesquisar" />
            </div>
            <div>
                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <br />
            <div>
                <div>
                    <asp:Label ID="Label2" runat="server" Text="Nome: "></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text="CPF: "></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="Tipo: "></asp:Label>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="Label5" runat="server" Text="Sexo: "></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:Label ID="Label6" runat="server" Text="Situação: "></asp:Label>
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
            <div>
                <asp:Button ID="Button2" runat="server" Text="Inserir" />
                <asp:Button ID="Button3" runat="server" Text="Atualizar" />
                <asp:Button ID="Button4" runat="server" Text="Excluir" />
            </div>
            <div>
                <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <br />
            <div>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
