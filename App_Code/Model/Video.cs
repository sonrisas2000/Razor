using System.Data;

namespace M05_UF3_P2_Template.App_Code.Model
{
    public class Video
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public float Duration { get; set; }
        public Product product { get; set; }

        public Video(DataRow row)
        {
            UpdateContructor(row);
        }

        public void UpdateContructor(DataRow row) {

            Id = int.Parse(row[0].ToString());
            Product_Id = int.Parse(row[1].ToString());
            Duration = float.Parse(row[2].ToString());
            if (Product_Id > 0)
            {
                product = new Product(DatabaseManager.Select("Product", null, "Id = " + Product_Id + " ").Rows[0]);
            }
        }
        public Video() { }
        public Video(int Id) : this(DatabaseManager.Select("Video", null, "Id = " + Id + " ").Rows[0]) { }


        public bool Update()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {
                new DatabaseManager.DB_Field("Product_id", Product_Id),
                new DatabaseManager.DB_Field("Duration", Duration)
               

            };
            return DatabaseManager.Update("Video", fields, "Id = " + Id + " ") > 0 ? true : false;
        }

        public bool Add()
        {
            DatabaseManager.DB_Field[] fields = new DatabaseManager.DB_Field[]
            {

                new DatabaseManager.DB_Field("Product_id", Product_Id),
                new DatabaseManager.DB_Field("Duration", Duration)

            };
            return DatabaseManager.Insert("Video", fields) > 0 ? true : false;
        }
    }
}
