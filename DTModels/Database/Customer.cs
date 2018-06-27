using System;
using System.Collections.Generic;
using System.Text;

namespace DTModels.Database
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public Users Identity { get; set; }  // navigation property
    }
}
