﻿using Rocky.Dto.Common;
using System.ComponentModel;

namespace Rocky.Dto.Product
{
    public class ProductGetDto : EntityGetDto
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }
        public int ApplicationTypeId { get; set; }

        [DisplayName("Caegogry Type")]
        public string CategoryType { get; set; }

        [DisplayName("Application Type")]
        public string ApplicationType { get; set; }

    }
}
