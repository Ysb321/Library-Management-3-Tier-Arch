using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM.BussinessLayer.Model
{
    public class Books : AuditEntity
    {
        public int BookId {  get; set; }

        [Required(ErrorMessage ="First Enter Book Name")]
        public string? BookName {  get; set; }

        [Required(ErrorMessage = "Enter Book Author Name")]

        public string? BookAuthor {  get; set; }

    }
}
