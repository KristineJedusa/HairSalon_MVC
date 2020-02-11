using System;
using System.Collections.Generic;
using System.Text;

namespace HairSalon.Data
{
    public class PriceTag
    {
        public int Id { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string PriceTags { get; set; }
        public string BigPicturePath { get; set; }
        public string Path { get; set; }
    }
}
