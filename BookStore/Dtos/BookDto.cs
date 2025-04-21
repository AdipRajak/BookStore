namespace BookStore.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }

        public string Format { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool AvailableInLibrary { get; set; }

        public bool IsOnSale { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public DateTime? DiscountStart { get; set; }
        public DateTime? DiscountEnd { get; set; }

        // Convert to UTC while setting DateTime properties
        public DateTime GetPublicationDateUtc() => PublicationDate.ToUniversalTime();
        public DateTime? GetDiscountStartUtc() => DiscountStart?.ToUniversalTime();
        public DateTime? GetDiscountEndUtc() => DiscountEnd?.ToUniversalTime();
    }
}
