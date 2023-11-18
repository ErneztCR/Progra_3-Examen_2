<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Equipos.aspx.cs" Inherits="TallerDeReparaciones.Equipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />

    <div class="container text-center">
        <h1>Equipos</h1>
    </div>

    <br />
    <br />

    <div class="container text-center">
        <asp:GridView ID="datagrid" PageSize="10" HorizontalAlign="Center"
            CssClass="mydatagrid" AutoGenerateColumns="true" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
            RomStyle-CssClass="rows" AllowPaging="true" runat="server">
        </asp:GridView>
    </div>

    <br />
    <br />

    <div class="container text-center">
        Tipo de equipo:
        <asp:TextBox ID="TextBoxtipoequipo" class="form-control" runat="server"></asp:TextBox>
        Modelo:
        <asp:TextBox ID="TextBoxmodel" class="form-control" runat="server"></asp:TextBox>
        ID de Usuario:
        <asp:TextBox ID="TextBoxuserid" class="form-control" runat="server"></asp:TextBox>
    </div>

    <br />
    <br />

    <div class="container text-center">
        <asp:Button ID="Button1" class="btn btn-outline-primary" runat="server" Text="Agregar" />
        <asp:Button ID="Button2" class="btn btn-outline-secondary" runat="server" Text="Borrar" />
        <asp:Button ID="Button3" runat="server" class="btn btn-outline-danger" Text="Modificar" />
        <asp:Button ID="Bconsulta" runat="server" class="btn btn-outline-danger" Text="Consultar" />
    </div>
</asp:Content>
