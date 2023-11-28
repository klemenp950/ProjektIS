using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace projekt.Models
{
    public class Dokument{
        public int? DokumentID {get; set;}
        public String Ime{get; set;}
        public int SteviloVrstic {get; set;}
        public int SteviloZnakov {get; set;}
        public int Velikost {get; set;}
        public DateTime? Datum {get; set;}
        public int? TipID { get; set; }
        public int? AvtorID { get; set; }
        public Avtor? Avtor {get; set;}
        public Tip? Tip {get; set;}
    }
}