using System;
using System.Collections.Generic;

#nullable disable

namespace ShoppingBackendApi.Models
{
    public partial class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Pieces { get; set; }
    }
}
