
// Book                            Author              Copies
// * Title                         * Name              * Many to one Copies - Books
// * Publication Date              * DOB               * Copy ID
// * Authors                       * Books             * Book Id
// * BookId                        * AuthorId          * Book Obj
// * Description                   * Bio Blurb         * 

using System.Collections.Generic;

namespace Library.Models
{
  public class Author
  {
    public Author()
    {
      this.Books = new HashSet<AuthorBook>();
    }

    public int AuthorId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Bio { get; set; }
    public ICollection<AuthorBook> Books { get; set; }
  }
}