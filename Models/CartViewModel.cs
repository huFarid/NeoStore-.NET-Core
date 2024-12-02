namespace NeoStore.Models
{
    public class CartViewModel
    {

        public CartViewModel()
        {
            CartItems = new List<CartItem>();
          
        }

        public List<CartItem> CartItems { get; set; }

        public decimal OrderTotalPrice {  get; set; }
        
    }
}
