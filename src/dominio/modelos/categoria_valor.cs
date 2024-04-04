using Aurora.Domain.Models;

namespace Aurora
{
    public class CategoryValue : Category
    {
        public int ValueId { get; set; }
        public SubliminalMemory? Memory { get; set; }
        public DescriptionOfCategory? Descripiton { get; set; }
        public CategorySignification? Signification { get; set; }
        public HierarchyOfCategory? Hierarchy { get; set; }
        public string? Value { get; set; }

        public static IEnumerable<Category>? GetCertainsFromMemory(CategoryValue category)
        {
            var certains = category?.Memory?.Certains?.Where(certain => certain?.Category?.Id == category?.Id);

            if (certains?.Any() == true)
            {
                var lineOfThinking = GetLineOfThinking(certains);

                if(lineOfThinking?.IsNull() == false)
                {
                    var categoriesHierarchy = string.Join(' ', lineOfThinking);
                }
            }

            return null;
        }

        private static List<Category>? GetLineOfThinking(IEnumerable<Comprehension> certains)
        {
            if (certains.IsNull())
                return null;

            var categoryHierarchically = new List<Category>();

            foreach (var certain in certains)
            {
                MakeHierarchyFromCertainWithCategoryhierarchical(categoryHierarchically, certain);
            }

            return categoryHierarchically;
        }

        private static void MakeHierarchyFromCertainWithCategoryhierarchical(List<Category> categoryHierarchically, Comprehension? certain)
        {
            if (categoryHierarchically.Count != 0)
            {
                foreach (var category in categoryHierarchically)
                {
                    SetHierarchyToCertainListFromCategory(categoryHierarchically, certain, category);

                }
            }
        }

        private static void SetHierarchyToCertainListFromCategory(List<Category> categoryHierarchically, Comprehension? certain, Category category)
        {
            var certainCategoryHierach = certain?.Category?.Hierarchy;

            if (certainCategoryHierach.IsNull() && category.IsNull())
                return;

            var index = categoryHierarchically.IndexOf(category);

            if (certainCategoryHierach.IsNull())
                return;

            var subCategory = certainCategoryHierach?.SubCategory;
            var parentCategory = certainCategoryHierach?.ParentCategoria;
            _ = categoryHierarchically.IndexOf(category);

            if (subCategory.IsNotNull())
                categoryHierarchically.Insert(index - 1, category);

            if (parentCategory.IsNotNull())
                categoryHierarchically.Insert(index + 1, category);
        }
    }
}