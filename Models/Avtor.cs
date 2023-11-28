using System;
using System.Collections.Generic;

namespace projekt.Models
{
    public class Avtor{
        public int AvtorID {get; set;}
        public String? Ime {get; set;}
        public String? Priimek {get; set;}
        public ICollection<Dokument>? Dokumenti { get; set; }

    }
}