using M05_UF3_P2_Template.App_Code.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data;

namespace M05_UF3_P2_Template.Pages.Products
{
    public class SearcherModel : PageModel
    {

        public List<Product> products = new List<Product>();
        public void OnGet()
        {
            DataTable dt = DatabaseManager.Select("Product", new string[] { "*" }, "");
            foreach (DataRow dataRow in dt.Rows)
            {
               
                
                   products.Add(new Product(dataRow));
               
            }
        }
        public void OnPostDelete(int id)
        {
            Product.Remove(id);
            OnGet();
        }
    }
}
