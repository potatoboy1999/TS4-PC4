<%@ Page Title="" Language="C#" MasterPageFile="~/Galeria.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GaleriaPC4.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="dlFotos" RepeatColumns="2" runat="server" Width="100%" DataSourceID="objFotos">
        <ItemTemplate>
           <a href="Foto.aspx?codFoto=<%#Eval("id") %>"><img width="450" src="Imagenes/<%#Eval("foto")%>"/></a> 
        </ItemTemplate>
    </asp:DataList>
    <asp:ObjectDataSource runat="server" ID="objFotos" SelectMethod="obtenerFotos" TypeName="GaleriaPC4.Models.AccesoDB">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="codCat" DefaultValue="2" Name="CatId" Type="Int32"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
