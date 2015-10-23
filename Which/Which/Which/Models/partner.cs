using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Which.Models
{
    public class partner
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string TEName { get; set; }
        public string BEName { get; set; }
        public string GTMName { get; set; }
    }
}