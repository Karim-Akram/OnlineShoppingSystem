<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListProducts.aspx.cs" Inherits="E___Commerce.ListProducts" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>List Products</title>
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
        <h1 class="text-center">List of Products</h1>
        <asp:GridView ID="GridViewProducts" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            PageSize="10" CssClass="table table-striped table-bordered" OnPageIndexChanging="GridViewProducts_PageIndexChanging"
            OnRowEditing="GridViewProducts_RowEditing" OnRowCancelingEdit="GridViewProducts_RowCancelingEdit"
            OnRowUpdating="GridViewProducts_RowUpdating" OnRowDeleting="GridViewProducts_RowDeleting"
            DataKeyNames="ProductID">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="Product ID" SortExpression="ProductID" ItemStyle-CssClass="text-center" />
                <asp:TemplateField HeaderText="Product Name" SortExpression="ProductName" ItemStyle-CssClass="text-center">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditProductName" runat="server" Text='<%# Bind("ProductName") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Arabic Name" SortExpression="ProductArabicName" ItemStyle-CssClass="text-center">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditProductArabicName" runat="server" Text='<%# Bind("ProductArabicName") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductArabicName" runat="server" Text='<%# Eval("ProductArabicName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Image" SortExpression="ProductImage" ItemStyle-CssClass="text-center">
                    <EditItemTemplate>
                        <asp:FileUpload ID="fileEditProductImage" runat="server" CssClass="form-control" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="imgProductImage" runat="server" ImageUrl='<%# Eval("ProductImage") %>' Height="50" Width="50" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Description" SortExpression="ProductDescription" ItemStyle-CssClass="text-center">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditProductDescription" runat="server" Text='<%# Bind("ProductDescription") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductDescription" runat="server" Text='<%# Eval("ProductDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Product Price" SortExpression="ProductPrice" ItemStyle-CssClass="text-center">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditProductPrice" runat="server" Text='<%# Bind("ProductPrice") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductPrice" runat="server" Text='<%# Eval("ProductPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn-group">
                    <ItemStyle HorizontalAlign="Center" />
                    <ControlStyle CssClass="btn btn-info" />
                </asp:CommandField>
            </Columns>
            <PagerStyle CssClass="custom-pager-style" />
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" Position="Bottom" />
        </asp:GridView>
        <asp:Label ID="ErrorMessageLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
