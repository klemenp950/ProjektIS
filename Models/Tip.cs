using System;
using System.Collections.Generic;

namespace projekt.Models
{
    public class Tip{
        public int TipID {get; set;}
        public String? Ime {get; set;}
        public ICollection<Dokument>? Dokumenti { get; set; }

    }
}