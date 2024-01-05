using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E___Commerce
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }
        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            
            string categoryName = txtCategoryName.Text;
            string categoryDescription = txtCategoryDescription.Text;

            using (var context = new OnlineShopDbContext())
            {
                context.AddCategory(categoryName, categoryDescription);
            }

           
            Response.Redirect("ListCategories.aspx");
        }
        protected void btnViewCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListCategories.aspx");
        }




    }
}