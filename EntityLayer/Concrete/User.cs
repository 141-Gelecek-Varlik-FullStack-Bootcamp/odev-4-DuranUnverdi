using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        [ DataType(DataType.Password)]
        public string UserPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        public string UserMail { get; set; }
    }
}
