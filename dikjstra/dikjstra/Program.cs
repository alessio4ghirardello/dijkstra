using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dikjstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definizione di quattro nodi con nomi "1", "2", "3" e "4"
            Nodo n1 = new Nodo("1");
            Nodo n2 = new Nodo("2");
            Nodo n3 = new Nodo("3");
            Nodo n4 = new Nodo("4");

            // Aggiunta di tre archi al nodo n1, che collegano n1 ai nodi n2, n3 e n4 con pesi rispettivamente 7, 9 e 14.
            n1.Archi.Add(new Arco(n2, 7));
            n1.Archi.Add(new Arco(n3, 9));
            n1.Archi.Add(new Arco(n4, 14));

            // Aggiunta di due archi al nodo n2, che collegano n2 ai nodi n3 e n4 con pesi rispettivamente 10 e 15.
            n2.Archi.Add(new Arco(n3, 10));
            n2.Archi.Add(new Arco(n4, 15));

            // Aggiunta di un arco al nodo n3, che collega n3 al nodo n4 con peso 11.
            n3.Archi.Add(new Arco(n4, 11));

            // Creazione di un nuovo grafo a partire dal nodo n1.
            Grafo grafo = new Grafo(n1);

            // Definizione del nodo di partenza e del nodo di arrivo.
            Nodo partenza = n1;
            Nodo arrivo = n4;

            // Calcolo del cammino minimo tra il nodo di partenza e il nodo di arrivo.
            List<Riga> cammino = grafo.CamminoMinimo(partenza, arrivo);

            // Stampa a video del cammino minimo.
            Console.WriteLine($"Cammino minimo tra {partenza.Nome} e {arrivo.Nome}:");
            foreach (Riga r in cammino)
            {
                Console.WriteLine(r.Da + " -> " + r.A + " : " + r.Costo);
            }

            // Attende l'input da tastiera per chiudere la console.
            Console.ReadLine();
        }
    }
}