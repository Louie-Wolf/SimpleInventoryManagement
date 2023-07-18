using SQLite;

namespace SimpleInventoryManagement.Model
{
    [Table("item")]
    public class Item
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [MaxLength(250), Unique, Column("name")]
        public string Name { get; set; }
        [Unique, Column("photo")]
        public string Photo { get; set; }
    }
}
