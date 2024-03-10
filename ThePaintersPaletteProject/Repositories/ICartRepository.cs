namespace ThePaintersPaletteProject.Repositories
{
    public interface ICartRepository
    {
        Task<int> AddItem(int artId, int qty);
        Task<int> RemoveItem(int artId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout();
        //decimal GetTotalAmount();
    }
}

