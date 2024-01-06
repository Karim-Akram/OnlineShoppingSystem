<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="E_Commerce.WebForms.ShoppingCart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <style>
        body {
            padding: 20px;
            font-family: Arial, sans-serif;
        }

        .container {
            max-width: 800px;
            margin: auto;
        }

        .product-container {
            margin-bottom: 20px;
        }

        .product-list {
            margin-top: 20px;
        }

        .mini-basket {
            margin-top: 20px;
        }

        .mini-basket h4 {
            margin-bottom: 10px;
        }

        .mini-basket ul {
            list-style-type: none;
            padding: 0;
            margin: 0;
        }

        .mini-basket li {
            margin-bottom: 10px;
        }

        .basket-container {
            margin-top: 20px;
        }

        .basket-container h2 {
            margin-bottom: 10px;
        }

        .basket-product-list {
            margin-top: 20px;
        }

        .btn-add-to-basket {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Product List -->
            <div class="product-container">
                <div class="product-list">
                    <h2>Product List</h2>
                <asp:GridView ID="gvProductList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" OnRowCommand="gvProductList_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" />
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="True" />
                            <asp:BoundField DataField="ProductPrice" HeaderText="Price" ReadOnly="True" DataFormatString="{0:C}" />
                            <asp:TemplateField HeaderText="Quantity">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQuantity" runat="server" Text="1" Width="30"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add to Basket">
                                <ItemTemplate>
                                    <asp:Button ID="btnAddToBasket" runat="server" Text="Add to Basket" CommandName="AddToBasket" CommandArgument='<%# Eval("ProductID") %>' CssClass="btn btn-primary btn-add-to-basket" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <hr />

            <!-- Mini Basket -->
            <div class="mini-basket">
                <h4>Mini Basket</h4>
                <ul>
                    <asp:Repeater ID="rptMiniBasket" runat="server">
                        <ItemTemplate>
                            <li>
                                <%# Eval("Product.ProductName") %> - <%# Eval("Product.ProductPrice", "{0:C}") %> - Quantity: <%# Eval("Quantity") %>
                                <img src='<%# Eval("Product.ProductImage") %>' alt="Product Thumbnail" width="50" height="50" />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <asp:Button ID="btnProceedToOrder" runat="server" Text="Proceed to Order" OnClick="btnProceedToOrder_Click" CssClass="btn btn-primary" />
            </div>

            <!-- Add Products to Basket -->
            <div class="basket-container">
                <h2>Add Products to Basket</h2>
              <asp:GridView ID="gvProductBasket" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered basket-product-list" EnableViewState="true">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="Product ID" ReadOnly="True" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" ReadOnly="True" />
                        <asp:BoundField DataField="ProductPrice" HeaderText="Price" ReadOnly="True" DataFormatString="{0:C}" />
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="txtBasketQuantity" runat="server" Text="1" Width="30"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add to Basket">
                            <ItemTemplate>
                                <asp:Button ID="btnAddToBasketInBasket" runat="server" Text="Add to Basket" CommandName="AddToBasketInBasket" CommandArgument='<%# Eval("ProductID") %>' CssClass="btn btn-success btn-add-to-basket" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
