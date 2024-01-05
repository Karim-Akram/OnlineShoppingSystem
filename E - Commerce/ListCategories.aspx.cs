using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E___Commerce
{
    public partial class ListCategories : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
            }
        }

        private void BindCategories()
        {
            using (var context = new OnlineShopDbContext())
            {
                var categories = context.Categories.ToList();
                GridViewCategories.DataSource = categories;
                GridViewCategories.DataBind();
            }
        }

        protected void GridViewCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var gridView = (GridView)sender;
            gridView.PageIndex = e.NewPageIndex;
            BindCategories();
        }

        protected void GridViewCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCategories.EditIndex = e.NewEditIndex;
            BindCategories();

        }


        protected void GridViewCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCategories.EditIndex = -1;
            BindCategories();
        }

        protected void GridViewCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int categoryId = Convert.ToInt32(GridViewCategories.DataKeys[e.RowIndex].Value);
                string updatedCategoryName = (GridViewCategories.Rows[e.RowIndex].FindControl("txtEditCategoryName") as TextBox)?.Text;
                string updatedCategoryDescription = (GridViewCategories.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox)?.Text;

                using (var context = new OnlineShopDbContext())
                {
                    var categoryToUpdate = context.Categories.Find(categoryId);
                    if (categoryToUpdate != null)
                    {
                        categoryToUpdate.CategoryName = updatedCategoryName;
                        categoryToUpdate.CategoryDescription = updatedCategoryDescription;
                        context.SaveChanges();
                    }
                }

                GridViewCategories.EditIndex = -1;
                BindCategories();
            }
            catch (Exception ex)
            {
        
            }
        }


        protected void GridViewCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int categoryId = Convert.ToInt32(GridViewCategories.DataKeys[e.RowIndex].Value);

            using (var context = new OnlineShopDbContext())
            {
                var categoryToDelete = context.Categories.Find(categoryId);
                if (categoryToDelete != null)
                {
                    context.Categories.Remove(categoryToDelete);
                    context.SaveChanges();
                }
            }

            BindCategories();
        }
    }
}
