using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Models
{
    public class Email
    {
        public string Body { get; set; }

        public string To { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

    }
}
