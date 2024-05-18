using Aurora.Domain.Models;

namespace Aurora
{
    public class CategoryValue : Category
    {
        public SubliminalMemory? Memory { get; set; }
        public CategoryDescription? Description { get; set; }
        public CategorySignification? Signification { get; set; }
        public CategoryHierarchy? Hierarchy { get; set; }
        public string? Value { get; set; }

        public static List<Category>? GetCertainFromMemory(CategoryValue category)
        {
            var certain = category?.Memory?.Certain?.Where(certain => certain?.Category?.Id == category?.Id)?.ToList();

            if (certain.IsNotNull() && certain.Count != 0)
            {
                var lineOfThinking = GetLineOfThinking(certain);

                if(lineOfThinking.IsNull() == false)
                {
                    var categoriesHierarchy = string.Join(' ', lineOfThinking);
                }
            }

            return null;
        }

        private static List<Category> GetLineOfThinking(List<Comprehension> certain)
        {
            var categoryHierarchically = new List<Category>();

            foreach (var c in certain)
            {
                MakeHierarchyFromCertainWithCategoryHierarchical(categoryHierarchically, c);
            }

            return categoryHierarchically;
        }

        private static void MakeHierarchyFromCertainWithCategoryHierarchical(List<Category> categoryHierarchically, Comprehension? certain)
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
            var certainCategoryHierarchy = certain?.Category?.Hierarchy;

            if (certainCategoryHierarchy.IsNull() && category.IsNull())
                return;

            var index = categoryHierarchically.IndexOf(category);

            if (certainCategoryHierarchy.IsNull())
                return;

            var subCategory = certainCategoryHierarchy?.SubCategory;
            var parentCategory = certainCategoryHierarchy?.ParentCategory;
            _ = categoryHierarchically.IndexOf(category);

            if (subCategory.IsNotNull())
                categoryHierarchically.Insert(index - 1, category);

            if (parentCategory.IsNotNull())
                categoryHierarchically.Insert(index + 1, category);
        }
    }
}