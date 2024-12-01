using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace NeoStore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int OrderID { get; set; }
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public List<CartItem> CartItems { get; set; }

        public void AddItem (CartItem cartItem)
        {
            if(CartItems.Exists(i=> i.Item.ID == cartItem.Item.ID ))
            {
                CartItems.Find(i => i.Item.ID == cartItem.Item.ID).ItemQuantity += 1;

            }
            else
            {
                CartItems.Add(cartItem);
            }
        }

        public void RemoveItem (int ItemID)
        {
            
                var item = CartItems.SingleOrDefault(i => i.Item.ID == ItemID);

                if (item?.ItemQuantity <= 1)
                {
                CartItems.Remove(item);

                }
                else if (item != null)
                {
                    item.ItemQuantity -= 1;
                }
            }




        
        


    }
}
