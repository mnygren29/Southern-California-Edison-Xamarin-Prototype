using System;
using System.Collections.Generic;
using System.Text;

namespace SCEPrototype.Models
{
    public class Outage
    {
        public string Id { get; set; }
        public int OutageNumber { get; set; }
        public string OutageLocation { get; set; }
        public int CustomersImpacted { get; set; }
        public string OutageStartTime { get; set; }
        public string OutageType { get; set; }
        public string OutageReasoning { get; set; }
        public bool OutageResolved { get; set; }
    }
}
