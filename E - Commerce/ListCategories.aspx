<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCategories.aspx.cs" Inherits="E___Commerce.ListCategories" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Categories</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:GridView ID="GridViewCategories" runat="server" AutoGenerateColumns="False" AllowPaging="True"
    PageSize="5" CssClass="table table-striped" OnPageIndexChanging="GridViewCategories_PageIndexChanging"
    OnRowEditing="GridViewCategories_RowEditing" OnRowCancelingEdit="GridViewCategories_RowCancelingEdit"
    OnRowUpdating="GridViewCategories_RowUpdating" OnRowDeleting="GridViewCategories_RowDeleting"
    DataKeyNames="CategoryID">
    <Columns>
        <asp:BoundField DataField="CategoryID" HeaderText="Category ID" SortExpression="CategoryID" />
        <asp:TemplateField HeaderText="Category English Name" SortExpression="CategoryName">
            <EditItemTemplate>
                <asp:TextBox ID="txtEditCategoryName" runat="server" Text='<%# Bind("CategoryName") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="CategoryDescription" HeaderText="Category Description" SortExpression="CategoryDescription" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
    <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" Position="Bottom" />
</asp:GridView>


    </form>
</body>
</html>
