using SchoolGrades;
using SchoolGrades.BusinessObjects;
using System.Collections.Generic;

namespace gamon.TreeMptt
{
    /// <summary>
    /// Calcola i valori LeftNode e RightNode per un albero di Topic senza dipendenze dall'interfaccia utente.
    /// Questa classe è ottimizzata per l'uso nel thread di background.
    /// </summary>
    internal class MpttLeftRight
    {
        private readonly TreeMpttDb dbMptt;

        internal MpttLeftRight(TreeMpttDb dbMptt)
        {
            this.dbMptt = dbMptt;
        }

        /// <summary>
        /// Calcola i valori LeftNode/RightNode per l'intero albero leggendo dal database.
        /// NON usa TreeView, lavora solo su List&lt;Topic&gt;.
        /// </summary>
        /// <returns>Lista di Topic con LeftNodeNew/RightNodeNew aggiornati</returns>
        internal List<Topic> CalculateLeftRightFromDatabase()
        {
            List<Topic> result = new List<Topic>();
            int nodeCount = 1;

            try
            {
                // Apri la connessione una volta sola per tutta l'operazione
                 dbMptt.OpenLocalConnectionIfClosed();

                // Leggi le radici dell'albero (false = non chiudere la connessione alla fine)
                List<Topic> roots = dbMptt.GetNodesRoots(false);

                if (roots != null && roots.Count > 0)
                {
                    foreach (Topic root in roots)
                    {
                        // Verifica se l'operazione deve essere interrotta
                        if (Commons.BackgroundTaskClose)
                            break;

                        // Calcola left/right ricorsivamente per ogni radice
                        CalculateLeftRightRecursive(root, ref nodeCount, ref result);
                    }
                }
            }
            finally
            {
                // Chiudi la connessione alla fine
                dbMptt.CloseLocalConnectionIfWasFoundClosed();
            }

            return result;
        }

        /// <summary>
        /// Calcola ricorsivamente LeftNodeNew/RightNodeNew per un nodo e i suoi figli.
        /// Questa è una versione "pura" senza dipendenze da TreeView.
        /// </summary>
        private void CalculateLeftRightRecursive(Topic currentNode, ref int nodeCount, ref List<Topic> result)
        {
            if (Commons.BackgroundTaskClose)
                return;

            // Assegna il valore sinistro
            currentNode.LeftNodeNew = nodeCount++;
            result.Add(currentNode);

            // Leggi i figli dal database (ordinati per ChildNumber)
            // false = non chiudere la connessione alla fine
            List<Topic> children = dbMptt.GetNodesChildsByParent(currentNode, false);

            if (children != null && children.Count > 0)
            {
                int brotherNo = 1;
                foreach (Topic child in children)
                {
                    if (Commons.BackgroundTaskClose)
                        return;

                    // Imposta il parent del figlio
                    child.ParentNodeNew = currentNode.Id;
                    child.ChildNumberNew = brotherNo++;

                    // Ricorsione sui figli
                    CalculateLeftRightRecursive(child, ref nodeCount, ref result);
                }
            }

            // Assegna il valore destro dopo aver processato tutti i figli
            currentNode.RightNodeNew = nodeCount++;
        }
    }
}
