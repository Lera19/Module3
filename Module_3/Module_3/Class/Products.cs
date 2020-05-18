using Module_3.Interface;
using Module_3.Utils;
using System;

namespace Module_3.Class
{
    public class Products : IClothing
    {
        private double _price;
        private double _basePrice;

        public event EventHandler<string> ProductsSt;

        public Products(ClothingType clothingType, double priceProducts, double baseProducts)
        {
            ClothingType = clothingType;
            PriceProducts = priceProducts;
            BaseProduct = baseProducts;

        }
        public ClothingType ClothingType { get; }
        public double PriceProducts
        {
            private set
            {
                if (value >= 0)
                {
                    _price = value;
                }
            }
            get => _price;
        }
        public double BaseProduct
        {
            get => _basePrice;
            private set
            {
                if (value >= 0)
                {
                    _basePrice = value;
                    _basePrice = PriceProducts + (PriceProducts / 100 * BaseProduct);
                }
            }
        }

        public void Move()
        {
            ProductsSt?.Invoke(null, $"Clothing{ClothingType} has price {PriceProducts} has markup {BaseProduct}");

        }
        public override string ToString()
        {
            return $"Clothing{ClothingType} has price {PriceProducts} has markup {BaseProduct}";
        }

    }
}
