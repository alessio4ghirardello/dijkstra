using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dikjstra
{
    internal class Arco
    {
        int peso; // dichiarazione della variabile di istanza "peso" di tipo int
        Nodo destinazione; // dichiarazione della variabile di istanza "destinazione" di tipo Nodo

    public Arco(Nodo destinazione, int peso) // costruttore che prende come argomenti la destinazione e il peso dell'arco
        {
            this.destinazione = destinazione; // assegna il valore della destinazione dell'arco alla variabile di istanza "destinazione"
            this.peso = peso; // assegna il valore del peso dell'arco alla variabile di istanza "peso"
        }

        public Nodo Destinazione { get => destinazione; } // proprietà "Destinazione" che restituisce la destinazione dell'arco
        public int Peso { get => peso; } // proprietà "Peso" che restituisce il peso dell'arco
    }
}
