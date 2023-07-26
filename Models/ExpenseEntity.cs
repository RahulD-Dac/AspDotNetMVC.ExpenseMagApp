using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Drawing.Printing;

namespace ExpenseMangementApp.Models
{
    public class ExpenseEntity
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required(ErrorMessage ="Please Select  Expense  Date ")]
        [DataType(DataType.Date)]
        [Display(Name ="Expense Date")]
        public DateTime ExpenseDate { get; set; }

        [Required(ErrorMessage = "Please enter given to Details ")]
        [MinLength(3,ErrorMessage ="The Name  is to short ")]
        [Display(Name = "Paid To")]
        public string ExpenseGivenTo{ get; set;}

        [Required(ErrorMessage = "Please enter given Expense  Amount ")]
        [Range(0,double.MaxValue,ErrorMessage ="Please enter a valid amount ")]
        [Display(Name = "ExpenseAmount")]

        public double ExpenseAmount { get; set;}


        //====================================

        [Display(Name = "Expense Category")]
        public int ExpenseCategoryId { get; set; }
        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategoryEntity? ExpenseCategory { get; set; }
    }
}
