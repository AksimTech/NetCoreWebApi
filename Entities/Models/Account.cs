using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("account")]
    public class Account : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type id required")]
        public string AccountType { get; set; }

        [Required(ErrorMessage = "Owner Id is required")]
        public int OwnerId { get; set; }

    }
}
