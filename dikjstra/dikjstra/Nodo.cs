using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dikjstra
{
    public class Nodo
    {
        static int index;  // Dichiarazione di una variabile statica (condivisa da tutte le istanze) di tipo intero chiamata "index"
        string nome;  // Dichiarazione di una variabile di istanza di tipo stringa chiamata "nome"
        List<Arco> archi;  // Dichiarazione di una variabile di istanza di tipo List di Arco chiamata "archi"
        List<Riga> camminominimo;  // Dichiarazione di una variabile di istanza di tipo List di Riga chiamata "camminominimo"

        public Nodo()  // Costruttore senza parametri
        {
            archi = new List<Arco>();  // Inizializza la variabile "archi" con una nuova istanza di List di Arco
            index++;  // Incrementa la variabile statica "index" di uno
            nome = index.ToString();  // Inizializza la variabile "nome" con il valore convertito in stringa della variabile "index"
        }

        public Nodo(string nome) : this()  // Costruttore con un parametro di tipo stringa chiamato "nome" che chiama il costruttore senza parametri "this()"
        {
            this.nome = nome;  // Inizializza la variabile "nome" con il valore del parametro "nome"
        }

        public string Nome { get => nome; }  // Proprietà di sola lettura per accedere al valore della variabile "nome"
        internal List<Arco> Archi { get => archi; }  // Proprietà di sola lettura per accedere al valore della variabile "archi"
        internal List<Riga> CamminoMinimo(Nodo partenza, Nodo arrivo)  // Metodo per calcolare il cammino minimo tra due nodi
        {
            Grafo g = new Grafo(this);  // Crea una nuova istanza di Grafo con il nodo corrente come parametro

            return g.CamminoMinimo(partenza, arrivo);  // Chiama il metodo CamminoMinimo del grafo appena creato con i nodi di partenza e arrivo come parametri e restituisce il risultato
        }
    }



}
