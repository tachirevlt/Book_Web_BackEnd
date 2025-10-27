using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string title { get; set; } = null!;
        public string authors { get; set; } = null!;
        public double? year { get; set; } = null!;
        public int? books_count { get; set; } = null!;
        public string work_id { get; set; } = null!;
        public string isbn { get; set; } = null!;
        public string language_code { get; set; } = null!;
        public double? average_rating { get; set; } = null!;
        public int? ratings { get; set; } = null!;
    }
}
