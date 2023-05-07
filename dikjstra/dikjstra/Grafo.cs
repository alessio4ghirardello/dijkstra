using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dikjstra
{
    internal class Grafo
    {
        List<Nodo> nodi;
        public Grafo(Nodo n)
        {
            nodi = new List<Nodo>();
            nodi.Add(n);
            for (int i = 0; i < nodi.Count; i++)
                foreach (Arco a in nodi[i].Archi)
                    if (nodi.Find(x => x.Nome.Equals(a.Destinazione.Nome)) is null)
                        nodi.Add(a.Destinazione);
        }

        // Questo metodo restituisce il cammino minimo tra il nodo di partenza e quello di arrivo.
        public List<Riga> CamminoMinimo(Nodo partenza, Nodo arrivo)
        {
            // Inizializza due liste di righe. Indagine è la lista dei nodi da esplorare, finale è la lista dei nodi esplorati.
            List<Riga> finale = new List<Riga>();
            List<Riga> indagine = new List<Riga>();

            // Per ogni nodo del grafo, aggiunge una riga alla lista indagine con costo massimo.
            foreach (Nodo nodo in nodi)
                indagine.Add(new Riga(partenza.Nome, nodo.Nome, int.MaxValue));

            // Imposta il costo del nodo di partenza a 0.
            indagine[nodi.IndexOf(partenza)].Costo = 0;

            // Finché ci sono nodi nella lista indagine, esplora il nodo con costo minimo.
            while (indagine.Count > 0)
            {
                Riga minimo = indagine[0];

                // Cerca il nodo con costo minimo nella lista indagine.
                foreach (Riga r in indagine)
                    if (r.Costo < minimo.Costo)
                        minimo = r;

                // Rimuove il nodo esplorato dalla lista indagine e lo aggiunge alla lista finale.
                indagine.Remove(minimo);
                finale.Add(minimo);

                // Se il nodo esplorato è quello di arrivo, esce dal ciclo.
                if (minimo.A == arrivo.Nome)
                    break;

                // Per ogni arco del nodo esplorato, calcola il costo del nodo adiacente e lo aggiorna se minore del costo corrente.
                foreach (Arco a in nodi.Find(x => x.Nome.Equals(minimo.A)).Archi)
                {
                    Riga riga = indagine.Find(x => x.A.Equals(a.Destinazione.Nome));
                    int nuovoCosto = minimo.Costo + a.Peso;
                    if (nuovoCosto < riga.Costo)
                        riga.Costo = nuovoCosto;
                }
            }

            // Restituisce la lista dei nodi esplorati.
            return finale;
        }
    }
}




