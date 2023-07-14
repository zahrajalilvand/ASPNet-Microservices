namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
                
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public string UserNAme { get; set; }
        public List<ShoppingCartItem> Item { get; set; }
    }
}
