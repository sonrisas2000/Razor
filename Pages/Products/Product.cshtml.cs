using M05_UF3_P2_Template.App_Code.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace M05_UF3_P2_Template.Pages.Products
{
    public class ProductModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public int Game_Id { get; set; }
        public int Video_Id { get; set; }
        [BindProperty]
        public Product product { get; set; }
         


        public void OnGet()
        {
            if (Id > 0)
            {
                product = new Product(Id);
                if(product.Type == Product.TYPE.GAME){

                   Game_Id = (int)DatabaseManager.Select("Game", new string[] {"Id"}, "Product_id = " + Id + "").Rows[0][0];
                   Video_Id = (int)DatabaseManager.Select("Video", new string[] { "Id" }, "Product_id = " + Id + "").Rows[0][0];

                }
                else if(product.Type == Product.TYPE.VIDEO)
                {
                    
                }
            }
        }
        public void OnPost()
        {
            product.Id = Id;
            if (Id > 0)
            {
                product.Update();
                
            }
            else
            {
                product.Add();
                Id = (int)DatabaseManager.Scalar("Product", DatabaseManager.SCALAR_TYPE.MAX, new string[] { "Id" }, " ");
                OnGet();
            }
        }
    }
}

