//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Expense_Tracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CategoryTable
    {
        public int Expense_ID { get; set; }
        public string Category_Name { get; set; }
        public string Category_Expense_Limit { get; set; }
        public int Category_ID { get; set; }
    
        public virtual ExpenseTable ExpenseTable { get; set; }
    }
}
