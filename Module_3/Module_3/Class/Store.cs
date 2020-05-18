using Module_3.Utils;

namespace Module_3.Class
{
    public class Store
    {

        public Store(ClothingType clothingType, Products products)
        {
            ClothingType = clothingType;
            Products = products;

        }
        public ClothingType ClothingType { get; }
        public Products Products { get; }




        
    }
}