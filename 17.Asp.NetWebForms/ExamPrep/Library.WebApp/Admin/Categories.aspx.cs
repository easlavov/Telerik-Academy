using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.WebApp.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        private const string CATEGORIES_PAGE = "~/Admin/Categories.aspx";
        private LibraryEntities context;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.context = new LibraryEntities();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> ListViewCategories_GetData()
        {            
            return this.context.Categories.OrderBy(cat => cat.Id);
        }

        //protected void Edit_Command(object sender, CommandEventArgs e)
        //{

        //}

        //protected void Delete_Command(object sender, CommandEventArgs e)
        //{
        //    int id = int.Parse(e.CommandArgument.ToString());
        //    var context = new LibraryEntities();
        //    var categoryToRemove = context.Categories.Find(id);
        //    context.Categories.Remove(categoryToRemove);
        //    context.SaveChanges();
        //    this.Response.Redirect(CATEGORIES_PAGE);
        //}

        protected void Insert_Command(object sender, CommandEventArgs e)
        {
            string categoryName = this.TextBoxCategoryName.Text;
            var newCategory = new Category { Name = categoryName };
            this.context.Categories.Add(newCategory);
            this.context.SaveChanges();
            this.Response.Redirect(CATEGORIES_PAGE);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategoriesTest_DeleteItem(int id)
        {
            var categoryToDelete = context.Categories.Find(id);
            this.context.Categories.Remove(categoryToDelete);
            this.context.SaveChanges();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategoriesTest_UpdateItem(int id)
        {
            Category item = this.context.Categories.Find(id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                this.context.SaveChanges();
            }
        }

        public void ListViewCategoriesTest_InsertItem()
        {
            var item = new Category();
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                this.context.Categories.Add(item);
                this.context.SaveChanges();
            }
        }
    }
}