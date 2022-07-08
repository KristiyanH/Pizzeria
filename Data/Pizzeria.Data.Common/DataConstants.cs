namespace Pizzeria.Data.Common
{
    public class DataConstants
    {
        public class Product
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 5;
            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 4;
            public const int MaxWeight = 2000;
            public const int MinWeight = 5;
        }

        public class Category
        {
            public const int NameMaxLength = 20;
            public const int NameMinLength = 2;
        }
    }
}
