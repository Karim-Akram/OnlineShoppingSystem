using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using E___Commerce.Models;

namespace E___Commerce
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProductCategories();
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SaveProduct();
            }
        }

        private void BindProductCategories()
        {
            using (var context = new OnlineShopDbContext())
            {
                List<Category> categories = context.Categories.ToList();
                ddlProductCategory.DataSource = categories;
                ddlProductCategory.DataTextField = "CategoryName";
                ddlProductCategory.DataValueField = "CategoryID";
                ddlProductCategory.DataBind();

                ddlProductCategory.Items.Insert(0, new ListItem("Select Category", ""));
            }
        }

        private string SaveProductImage(FileUpload fileUpload)
        {
            try
            {
                string uploadFolder = Server.MapPath("~/ProductImages");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                string fileName = Guid.NewGuid().ToString() + "_" + fileUpload.FileName;
                string filePath = Path.Combine(uploadFolder, fileName);

                fileUpload.SaveAs(filePath);

               
                return "~/ProductImages/" + fileName;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.ToString());
                return null; 
            }
        }

        private void SaveProduct()
        {
            try
            {
                string productImage = SaveProductImage(fileProductImage);

                if (productImage != null)
                {
                    Product newProduct = new Product
                    {
                        ProductName = txtProductName.Text.Trim(),
                        ProductArabicName = txtProductArabicName.Text.Trim(),
                        ProductImage = productImage,
                        ProductDescription = txtProductDescription.Text.Trim(),
                        ProductPrice = decimal.Parse(txtProductPrice.Text),
                        CategoryID = Convert.ToInt32(ddlProductCategory.SelectedValue),
                    };

                    using (var context = new OnlineShopDbContext())
                    {
                        context.Products.Add(newProduct);
                        context.SaveChanges();
                    }

                    Response.Redirect("ListProducts.aspx");
                }
                else
                {
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        protected void cvProductImage_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (fileProductImage.HasFile)
            {
                // Check file type
                string fileExtension = System.IO.Path.GetExtension(fileProductImage.FileName).ToLower();
                if (fileExtension == ".gif" || fileExtension == ".jpg" || fileExtension == ".bmp" || fileExtension == ".png")
                {
                    // Check file size (1MB limit)
                    if (fileProductImage.PostedFile.ContentLength <= 1024 * 1024)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = false;
                }
            }
            else
            {
                args.IsValid = false;
            }
        }
    }
}
