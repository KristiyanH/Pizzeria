namespace Pizzeria.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using static Pizzeria.Data.Common.DataConstants.Category;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }
    }
}
