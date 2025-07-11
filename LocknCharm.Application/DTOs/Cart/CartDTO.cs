﻿using LocknCharm.Application.DTOs.CartItem;

namespace LocknCharm.Application.DTOs.Cart
{
    public class CartDTO
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public bool IsOrdered { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public List<CartItemDTO> CartItems { get; set; } = new List<CartItemDTO>();
        public decimal CartTotalPrice => CartItems.Sum(c => c.TotalPrice);
    }
}
