<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="E___Commerce.AddCategory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Category</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            background-color: #f8f9fa;
        }

        .form-container {
            max-width: 400px;
            margin: auto;
            margin-top: 50px;
            background-color: #ffffff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-group {
            margin-bottom: 20px;
        }

        .btn-primary {
            background-color: #007bff;
            border-color: #007bff;
            margin-bottom: 10px; 
        }

        .btn-primary:hover {
            background-color: #0056b3;
            border-color: #0056b3;
        }

        .form-control {
            border-radius: 5px;
        }

        .form-control:focus {
            border-color: #007bff;
            box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
        }

        .required-field {
            color: #dc3545;
            font-size: 80%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container form-container">
            <h2 style="color: #007bff;">Add New Category</h2>

            <div class="form-group">
                <asp:Label ID="lblCategoryName" runat="server" Text="Category English Name:" ForeColor="#007bff"></asp:Label>
                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblCategoryDescription" runat="server" Text="Category Description:" ForeColor="#007bff"></asp:Label>
                <asp:TextBox ID="txtCategoryDescription" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="row"> 
                <div class="col-md-6"> 
                    <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="btnAddCategory_Click" CssClass="btn btn-primary btn-block" />
                </div>
                <div class="col-md-6"> 
                    <a href='<%= ResolveUrl("~/ListCategories.aspx") %>' class="btn btn-primary btn-block">View Categories</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
