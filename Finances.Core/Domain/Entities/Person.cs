using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string TaxNumber { get; set; }
        public char Gender { get; set; }
    }
}
