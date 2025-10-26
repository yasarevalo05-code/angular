using System.ComponentModel.DataAnnotations;

namespace OrmAPI.Modelo
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }
    }
}
