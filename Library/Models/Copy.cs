using System.Collections.Generic;
using System.ComponentModel;
using System;

namespace Library.Models
{
  public class Copy
  {
    public int CopyId { get; set; }
    public DateTime CheckoutDate { get; set; }
    public DateTime DueDate { get; set; }
    public Boolean IsCheckedOut { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}