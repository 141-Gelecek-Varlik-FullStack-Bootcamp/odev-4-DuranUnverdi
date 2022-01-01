using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.Model
{
   public class Email

    {
 
            [Required]
            public string From { get; set; }
            [Required]
            public string FromMail { get; set; }
            [Required]
            public string To { get; set; }
            [Required]
            public string ToMail { get; set; }
            [Required]
            public string SmtpPass { get; set; }
            [Required]
            public string Subject { get; set; }
            [Required]
            public string Body { get; set; }
        
    }
}
