using System.ComponentModel.DataAnnotations.Schema;

namespace Readify.DTOs.WhiteList
{
    public class InsertWhiteListDto
    {
        public Guid UserId { get; set; }

        public Guid BookId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
