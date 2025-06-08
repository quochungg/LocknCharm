﻿namespace LocknCharm.Application.DTOs
{
    public class CreatePreMadeKeychainDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }

        public Guid CategoryID { get; set; }
    }
}
