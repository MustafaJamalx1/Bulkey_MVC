﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace BulkeyWeb.Models
{
    public class Catagory
    {
        [Key]
        public int CatagoreyId { get; set; }
        
        [DisplayName("Catagory Name")]
        [MaxLength(30)]
        public required string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
