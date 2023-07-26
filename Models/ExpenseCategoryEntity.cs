using System;
using System.ComponentModel.DataAnnotations;



namespace ExpenseMangementApp.Models
{
    public class ExpenseCategoryEntity
    {
        [Key]
        public int ExpenseCateoryId { get; set; }

     
        public string ExpenseCateoryName { get; set; }

    }
}
