namespace MySoko.Models
{
    public class Product
    {
        public int ProductId { get; set; }         
        public string? Name { get; set; }           
        public string? Description { get; set; }   
        public string? Category { get; set; }       

        // Pricing and Inventory
        public decimal Price { get; set; }        
        public int? StockQuantity { get; set; }
        public byte[]? ItemPhoto { get; set; }
    }
}
