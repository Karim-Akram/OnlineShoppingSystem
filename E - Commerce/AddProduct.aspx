<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="E___Commerce.AddProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Product</title>
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
            <h2 style="color: #007bff;">Add New Product</h2>

            <div class="form-group">
                <asp:Label ID="lblProductName" runat="server" Text="Product English Name:" ForeColor="#007bff"></asp:Label>
                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName"
                    Display="Dynamic" ErrorMessage="Product English Name is required." ForeColor="#dc3545" />
            </div>
            <div class="form-group">
    <asp:Label ID="lblProductArabicName" runat="server" Text="Product Arabic Name:" ForeColor="#007bff"></asp:Label>
    <asp:TextBox ID="txtProductArabicName" runat="server" CssClass="form-control"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvProductArabicName" runat="server" ControlToValidate="txtProductArabicName"
        Display="Dynamic" ErrorMessage="Product Arabic Name is required." ForeColor="#dc3545" />
</div>


            <div class="form-group">
                <asp:Label ID="lblProductDescription" runat="server" Text="Product Description:" ForeColor="#007bff"></asp:Label>
                <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblProductPrice" runat="server" Text="Product Price:" ForeColor="#007bff"></asp:Label>
                <asp:TextBox ID="txtProductPrice" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvProductPrice" runat="server" ControlToValidate="txtProductPrice"
                    Display="Dynamic" ErrorMessage="Product Price is required." ForeColor="#dc3545" />
                <asp:RegularExpressionValidator ID="revProductPrice" runat="server" ControlToValidate="txtProductPrice"
                    Display="Dynamic" ErrorMessage="Invalid format. Enter a valid numeric value."
                    ForeColor="#dc3545" ValidationExpression="^\d+(\.\d{1,2})?$" />
            </div>

            <div class="form-group">
                <asp:Label ID="lblProductCategory" runat="server" Text="Product Category:" ForeColor="#007bff"></asp:Label>
                <asp:DropDownList ID="ddlProductCategory" runat="server" CssClass="form-control">
                   
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvProductCategory" runat="server" ControlToValidate="ddlProductCategory"
                    Display="Dynamic" ErrorMessage="Product Category is required." ForeColor="#dc3545" />
            </div>

            <div class="form-group">
    <asp:Label ID="lblProductImage" runat="server" Text="Product Image:" ForeColor="#007bff"></asp:Label>
    <asp:FileUpload ID="fileProductImage" runat="server" CssClass="form-control" Accept=".gif, .jpg, .bmp, .png" />
    <asp:RequiredFieldValidator ID="rfvProductImage" runat="server" ControlToValidate="fileProductImage"
        Display="Dynamic" ErrorMessage="Product Image is required." ForeColor="#dc3545" />
    <asp:CustomValidator ID="cvProductImage" runat="server" ControlToValidate="fileProductImage"
        Display="Dynamic" ErrorMessage="Invalid file format or size. Please upload a file with format (.gif, .jpg, .bmp, .png) and size not exceeding 1MB."
        ForeColor="#dc3545" OnServerValidate="cvProductImage_ServerValidate" />
</div>


            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click"
                CssClass="btn btn-primary btn-block" />

            <div class="row">
                <div class="col-md-6">
                    <a href='<%= ResolveUrl("~/ListProducts.aspx") %>' class="btn btn-primary btn-block">View Products</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
