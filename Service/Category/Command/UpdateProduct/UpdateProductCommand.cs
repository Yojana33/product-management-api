public class UpdateProductCommand
    {
        public required string Id { get; set; }
        public string NewName { get; set; }=" ";
        public decimal NewPrice { get; set; }
    }