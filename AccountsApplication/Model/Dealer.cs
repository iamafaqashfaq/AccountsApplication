using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsApplication.Model
{
    class Dealer
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string CompanyFullName { get; set; }
        public string CompanyPhoneNo { get; set; }
        public string CompanyTelNo { get; set; }
        public string RepresentativeName { get; set; }
        public string CompanyAddress { get; set; }
        public string RepresentativePhoneNo { get; set; }
        public bool Distribution { get; set; }
        public bool Reseller { get; set; }
    }
}
