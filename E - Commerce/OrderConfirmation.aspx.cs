using System;
using System.Linq;
using System.Data.Entity; 
using E___Commerce;
using E___Commerce.Models;

namespace E_Commerce
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Order order = GetOrderDetails();

                if (order != null)
                {
                    string deliveryMethod = GetDeliveryMethod(order);
                    string deliveryAddress = GetDeliveryAddress(order);

                    lblDeliveryMethod.Text = deliveryMethod;
                    lblDeliveryAddress.Text = deliveryAddress;
                }
            }
        }

        private Order GetOrderDetails()
        {
            try
            {
                int orderId = 1;

                using (var dbContext = new OnlineShopDbContext())
                {
                    return dbContext.Orders
                        .Include(o => o.User) 
                        .Include(o => o.OrderItems) 
                        .FirstOrDefault(o => o.OrderID == orderId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetOrderDetails: {ex.Message}");
                throw;
            }
        }

        private string GetDeliveryMethod(Order order)
        {
            
            return "Standard Shipping";
        }

        private string GetDeliveryAddress(Order order)
        {
            return order.DeliveryAddress;
        }
    }
}
