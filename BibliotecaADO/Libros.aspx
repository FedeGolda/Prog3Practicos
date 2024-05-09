<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Libros.aspx.cs" Inherits="BibliotecaADO.Libros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Libros</h1>
    <asp:DropDownList ID="ddlTipoBusqueda" runat="server" AutoPostBack="true">
        <asp:ListItem Text="Autor" Value="Autor"></asp:ListItem>
        <asp:ListItem Text="Titulo" Value="Titulo"></asp:ListItem>
        <asp:ListItem Text="Año" Value="Año"></asp:ListItem>
    </asp:DropDownList>

    <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
    <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="True"></asp:GridView>
</asp:Content>
