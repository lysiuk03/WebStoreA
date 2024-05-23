﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStoreA.Data.Entities.Identity;
using WebStoreA.Data.Entities.Identity;

namespace WebStoreA.Data.Entities
{
    [Table("tblCategories")]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [ForeignKey("User")]
        public long? UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}