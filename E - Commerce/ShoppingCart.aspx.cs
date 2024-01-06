using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using E___Commerce.Models;
using E___Commerce;
using E_Commerce.Models;

namespace E_Commerce.WebForms
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductList();
                BindProductBasket();
            }

            BindMiniBasket();
        }


        protected void gvProductList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToBasket")
            {
                try
                {
                    int productId = Convert.ToInt32(e.CommandArgument);
                    AddToBasket(productId);
                    BindMiniBasket();
                }
                catch (Exception ex)
                {
                    HandleError(ex, "Error adding item to basket");
                }
            }
        }


        protected void btnProceedToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                List<OrderItem> miniBasket = Session["MiniBasket"] as List<OrderItem> ?? new List<OrderItem>();

                if (miniBasket.Count > 0)
                {
                    Order newOrder = new Order
                    {
                        OrderDate = DateTime.Now,
                        OrderItems = miniBasket
                    };

                    SaveOrderToDatabase(newOrder);

                    Session["MiniBasket"] = new List<OrderItem>();

                    Response.Redirect("OrderConfirmation.aspx");
                }
                else
                {
                    Response.Redirect("ShoppingCart.aspx");
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error processing order");
            }
        }


        protected void btnAddToBasket_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnAddToBasket = (Button)sender;
                GridViewRow row = (GridViewRow)btnAddToBasket.NamingContainer;

                int productId = Convert.ToInt32(gvProductList.DataKeys[row.RowIndex].Value);
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                int quantity = Convert.ToInt32(txtQuantity.Text);

                AddToBasket(productId, quantity);
                BindMiniBasket();
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error adding item to basket");
            }
        }

        private void BindProductList()
        {
            try
            {
                List<Product> productList = GetProductListFromDatabase();
                gvProductList.DataSource = productList;
                gvProductList.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error loading product list");
            }
        }

        private void BindProductBasket()
        {
            try
            {
                List<OrderItem> basketItems = Session["MiniBasket"] as List<OrderItem> ?? new List<OrderItem>();
                gvProductBasket.DataSource = basketItems;
                gvProductBasket.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error loading basket items");
            }
        }

        private Product GetProductById(int productId)
        {
            try
            {
                return GetProductListFromDatabase().FirstOrDefault(p => p.ProductID == productId);
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error retrieving product by ID");
                return null;
            }
        }

        private List<Product> GetProductListFromDatabase()
        {
            try
            {
                using (var dbContext = new OnlineShopDbContext())
                {
                    return dbContext.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error retrieving product list from the database");
                return new List<Product>();
            }
        }

        private void SaveOrderToDatabase(Order newOrder)
        {
            try
            {
                Console.WriteLine($"Saving Order to Database: OrderNumber = {newOrder.OrderNumber}, TotalPrice = {newOrder.TotalPrice}");
               
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error saving order to the database");
            }
        }

        private void AddToBasket(int productId, int quantity = 1)
        {
            try
            {
                List<OrderItem> miniBasket = Session["MiniBasket"] as List<OrderItem> ?? new List<OrderItem>();
                OrderItem existingItem = miniBasket.FirstOrDefault(item => item.ProductID == productId);

                if (existingItem != null)
                {
                    existingItem.Quantity += quantity;
                }
                else
                {
                    Product product = GetProductById(productId);
                    if (product != null)
                    {
                        OrderItem newItem = new OrderItem
                        {
                            ProductID = product.ProductID,
                            Quantity = quantity,
                            Order = new Order
                            {
                                OrderItems = new List<OrderItem>()
                            },
                            Product = product
                        };

                        miniBasket.Add(newItem);
                    }
                }

                Session["MiniBasket"] = miniBasket;
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error adding item to basket");
            }
        }

        private void BindMiniBasket()
        {
            try
            {
                List<OrderItem> miniBasket = Session["MiniBasket"] as List<OrderItem> ?? new List<OrderItem>();
                rptMiniBasket.DataSource = miniBasket;
                rptMiniBasket.DataBind();
            }
            catch (Exception ex)
            {
                HandleError(ex, "Error binding mini basket");
            }
        }

        private void HandleError(Exception ex, string errorMessage)
        {
            
            Console.WriteLine($"{errorMessage}: {ex.Message}");
           
        }
    }
}
