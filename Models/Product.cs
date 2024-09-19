using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MySoko.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }

        // Pricing and Inventory
        [Display(Name = "Price (KSh)")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Stock Quantity")]
        public int? StockQuantity { get; set; }
        public byte[]? ItemPhoto { get; set; }
    }
}
