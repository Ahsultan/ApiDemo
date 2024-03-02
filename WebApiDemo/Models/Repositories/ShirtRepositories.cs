namespace WebApiDemo.Models.Repositories
{
    public class ShirtRepositories
    {
        private static List<Shirt> shirts = new List<Shirt>()
        {
            new() {ShirtId = 1, Brand = "Puma", Color = "Green", Gender="Men" , Size = 9, Price = 900},
            new() {ShirtId = 2, Brand = "Nike", Color = "Blue", Gender="Women" , Size = 6, Price = 700},
            new() {ShirtId = 3, Brand = "Sketchers", Color = "White", Gender="Men" , Size = 9, Price = 1900},
            new() {ShirtId = 4, Brand = "Apple", Color = "Black", Gender="Men" , Size = 7, Price = 9000},
            new() {ShirtId = 5, Brand = "Google", Color = "Black White", Gender="Men" , Size = 8, Price = 800}
        };


        public List<Shirt> Get()
        {
            return shirts;
        }

        public static bool HasShirt(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }

        public Shirt? GetById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);
        }

        public Shirt? GetShirtByProperty(string? brand, string? color, int? size, string? gender)
        {
            return shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(color) &&
            !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
            !string.IsNullOrWhiteSpace(gender) &&
            !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            size.HasValue && x.Size.HasValue &&
            x.Size.Value == size.Value );
        }

        public void AddShirt(Shirt shirt)
        {
            int id = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = id + 1;

            shirts.Add(shirt);
        }

    }
}
