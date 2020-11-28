using CsvHelper.Configuration.Attributes;
using GorinManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorinManagement.Models
{
    public class Account
    {
        //[CsvHelper.Configuration.Attributes.Name("Konyveles datuma")]
        [Index(0)]
        public DateTime DateOfAccount { get; set; }

        //[CsvHelper.Configuration.Attributes.Name("Értéknap")]
        [Index(1)]
        public DateTime ValueDay { get; set; }

        [Index(2)]
        public string AccountNumber { get; set; }

        [Index(3)]
        public string NameOfPartner { get; set; }

        [Index(4)]
        public string PartnersAccountNumber { get; set; }

        [Index(5)]
        public decimal Amount { get; set; }

        [Index(6)]
        public string TypeOfAmount { get; set; }

        [Index(7)]
        public string TypeOfTransaction { get; set; }

        [Index(8)]
        public string Description { get; set; }

    }
}
