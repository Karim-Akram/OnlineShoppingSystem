<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCategories.aspx.cs" Inherits="E___Commerce.ListCategories" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Categories</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        .table-bordered th,
        .table-bordered td {
            border: 1px solid #dee2e6;
        }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: #f9f9f9;
        }

        .table-striped tbody tr:nth-of-type(even) {
            background-color: #e9ecef;
        }

        .custom-pager-style {
            margin-top: 10px;
        }

        .btn-info {
            color: #fff;
            background-color: #17a2b8;
            border-color: #17a2b8;
        }

        .btn-info:hover {
            background-color: #117a8b;
            border-color: #10707f;
        }

        .text-center {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <h1 class="text-center">List of Categories</h1>
        <asp:GridView ID="GridViewCategories" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            PageSize="5" CssClass="table table-striped table-bordered" OnPageIndexChanging="GridViewCategories_PageIndexChanging"
            OnRowEditing="GridViewCategories_RowEditing" OnRowCancelingEdit="GridViewCategories_RowCancelingEdit"
            OnRowUpdating="GridViewCategories_RowUpdating" OnRowDeleting="GridViewCategories_RowDeleting"
            DataKeyNames="CategoryID">
            <Columns>
                <asp:BoundField DataField="CategoryID" HeaderText="Category ID" SortExpression="CategoryID" ItemStyle-CssClass="text-center" />
                <asp:TemplateField HeaderText="Category English Name" SortExpression="CategoryName" ItemStyle-CssClass="text-center">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CategoryDescription" HeaderText="Category Description" SortExpression="CategoryDescription" ItemStyle-CssClass="text-center" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn-group">
                <ItemStyle HorizontalAlign="Center" />
                <ControlStyle CssClass="btn btn-info" />
                </asp:CommandField>

            </Columns>
            <PagerStyle CssClass="custom-pager-style" />
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" Position="Bottom" />
        </asp:GridView>
    </form>
</body>
</html>
