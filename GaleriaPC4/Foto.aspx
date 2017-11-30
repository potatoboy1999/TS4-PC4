<%@ Page Title="" Language="C#" MasterPageFile="~/Galeria.Master" AutoEventWireup="true" CodeBehind="Foto.aspx.cs" Inherits="GaleriaPC4.Foto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FormView ID="fvFoto" runat="server" DataSourceID="objFoto">
        <ItemTemplate>
            <div class="LeftLikes">
                <div>
                    <span><%#Eval("likes") %> Likes</span>
                </div>
            </div>
            <div class="RightDislikes">
                <div>
                    <span><%#Eval("dislikes") %> Dislikes</span>
                </div>
            </div>
            <div class="Foto">
                <img width="400" src="Imagenes/<%#Eval("foto") %>" />
            </div>
            <div id="buttons">
                <asp:Button ID="btnLikes" CssClass="btnLike" runat="server" Text="Dar Like :D" OnClick="btnLikes_Click" />
                <asp:Button ID="btnDislikes" CssClass="btnDislike" runat="server" Text="Dar Dislike :(" OnClick="btnDislikes_Click" />
            </div>
            <div id="linkBack">
                <a href="Default.aspx?codCat=<%#Eval("CategoriaId")%>">Regresar a la galería</a>
            </div>
        </ItemTemplate>

    </asp:FormView>




    <asp:ObjectDataSource runat="server" ID="objFoto" SelectMethod="obtenerFoto" TypeName="GaleriaPC4.Models.AccesoDB">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="codFoto" Name="codFoto" Type="Int32"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

