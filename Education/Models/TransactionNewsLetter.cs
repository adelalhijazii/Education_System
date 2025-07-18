using System.ComponentModel.DataAnnotations;

namespace Education.Models
{
    public class TransactionNewsLetter : BaseEntity
    {
        public int TransactionNewsLetterId { get; set; }

        [DataType(DataType.EmailAddress)]
        public string TransactionNewsLetterEmail { get; set; }
    }
}
