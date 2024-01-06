<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="E_Commerce.OrderConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Confirmation</title>
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

        .order-details {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Order Confirmation</h2>

            <div class="order-details">
                <div>
                    <label>Delivery Method:</label>
                    <span><asp:Label ID="lblDeliveryMethod" runat="server" Text=""></asp:Label></span>
                </div>
                <div>
                    <label>Delivery Address:</label>
                    <span><asp:Label ID="lblDeliveryAddress" runat="server" Text=""></asp:Label></span>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
