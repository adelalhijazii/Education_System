using Education.Models;
using System.ComponentModel.DataAnnotations;

namespace Education.Areas.Admin.ViewModels
{
    public class TransactionNewsLetterViewModel : BaseEntity
    {
        public int TransactionNewsLetterId { get; set; }

        [DataType(DataType.EmailAddress)]
        public string TransactionNewsLetterEmail { get; set; }
    }
}
