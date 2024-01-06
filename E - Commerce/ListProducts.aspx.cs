using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using E___Commerce.Models;

namespace E___Commerce
{
    public partial class ListProducts : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            using (var context = new OnlineShopDbContext())
            {
                var products = context.Products.ToList();
                GridViewProducts.DataSource = products;
                GridViewProducts.DataBind();
            }
        }

        protected void GridViewProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var gridView = (GridView)sender;
            gridView.PageIndex = e.NewPageIndex;
            BindProducts();
        }

        protected void GridViewProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewProducts.EditIndex = e.NewEditIndex;
            BindProducts();
        }

        protected void GridViewProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewProducts.EditIndex = -1;
            BindProducts();
        }

        protected void GridViewProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int productId = Convert.ToInt32(GridViewProducts.DataKeys[e.RowIndex].Value);
                string updatedProductName = (GridViewProducts.Rows[e.RowIndex].FindControl("txtEditProductName") as TextBox)?.Text;
                string updatedProductArabicName = (GridViewProducts.Rows[e.RowIndex].FindControl("txtEditProductArabicName") as TextBox)?.Text;
                string updatedProductDescription = (GridViewProducts.Rows[e.RowIndex].FindControl("txtEditProductDescription") as TextBox)?.Text;
                decimal updatedProductPrice = 0;

                TextBox txtEditProductPrice = GridViewProducts.Rows[e.RowIndex].FindControl("txtEditProductPrice") as TextBox;
                FileUpload fileEditProductImage = GridViewProducts.Rows[e.RowIndex].FindControl("fileEditProductImage") as FileUpload;

                // Find the ErrorMessageLabel within the correct container (Row)
                Label lblErrorMessage = GridViewProducts.Rows[e.RowIndex].FindControl("ErrorMessageLabel") as Label;

                if (lblErrorMessage != null)
                {
                    ShowErrorMessage(lblErrorMessage, "Please enter a valid Product Price.");
                }

                // Validate Product Price
                if (!decimal.TryParse(txtEditProductPrice.Text, out updatedProductPrice))
                {
                    ShowErrorMessage(lblErrorMessage, "Please enter a valid Product Price.");
                    return;
                }

                // Validate Product Image
                if (fileEditProductImage.HasFile)
                {
                    string fileExtension = Path.GetExtension(fileEditProductImage.FileName);
                    if (!IsAllowedFileExtension(fileExtension))
                    {
                        ShowErrorMessage(lblErrorMessage, "Please select a valid image file with extensions: .gif, .jpg, .bmp, .png.");
                        return;
                    }
                }

                using (var context = new OnlineShopDbContext())
                {
                    var productToUpdate = context.Products.Find(productId);
                    if (productToUpdate != null)
                    {
                        productToUpdate.ProductName = updatedProductName;
                        productToUpdate.ProductArabicName = updatedProductArabicName;
                        productToUpdate.ProductDescription = updatedProductDescription;
                        productToUpdate.ProductPrice = updatedProductPrice;

                        // Handle image update
                        if (fileEditProductImage.HasFile)
                        {
                            string newImagePath = SaveProductImage(fileEditProductImage);
                            productToUpdate.ProductImage = newImagePath;
                        }

                        context.SaveChanges();
                    }
                }

                GridViewProducts.EditIndex = -1;
                BindProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        private void ShowErrorMessage(Label errorLabel, string message)
        {
            if (errorLabel != null)
            {
                errorLabel.Text = message;
            }
            else
            {
                
                Console.WriteLine("Error: errorLabel is null. Message: " + message);
            }
        }


        private bool IsAllowedFileExtension(string fileExtension)
        {
            List<string> allowedExtensions = new List<string> { ".gif", ".jpg", ".bmp", ".png" };
            return allowedExtensions.Contains(fileExtension);
        }

        protected void GridViewProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(GridViewProducts.DataKeys[e.RowIndex].Value);

            using (var context = new OnlineShopDbContext())
            {
                var productToDelete = context.Products.Find(productId);
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                }
            }

            BindProducts();
        }

        
        private string SaveProductImage(FileUpload fileUpload)
        {
            string uploadFolder = Server.MapPath("~/ProductImages");
            string fileName = Guid.NewGuid().ToString() + "_" + fileUpload.FileName;
            string filePath = Path.Combine(uploadFolder, fileName);

            fileUpload.SaveAs(filePath);

            
            return "~/ProductImages/" + fileName;
        }
    }
}
