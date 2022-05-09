using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTCApi.EntityClasses
{
  [Table("Category", Schema = "dbo")]
  public partial class Category
  {
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }
  }
}
