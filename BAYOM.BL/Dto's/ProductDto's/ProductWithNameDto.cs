﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Dto_s.ProductDto_s
{
    public class ProductWithNameDto
    {
        public int Productid { get; set; }

        public string? Productname { get; set; }

        public decimal? ProductpriceB { get; set; }

        public string? Productimage { get; set; }

        public int? Categoryid { get; set; }
        public string? Categoryname { get; set; }

        public int? Productbrandid { get; set; }
        public string? Productbrandname { get; set; }

        public string? Productdescription { get; set; }

        public decimal? ProductpriceS { get; set; }
        public byte? Topcategoryid { get; set; }
        public string? Topcategoryname { get; set; }
    }
}
