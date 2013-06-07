using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem
{
    public class Refiner
    {

        //This class is used for refining the results after receiving them from Bing

        List<Context> contexts = new List<Context>();
        String searchString;

        public Refiner(List<Context> contexts, String searchString)
        {
            this.contexts = contexts;
            this.searchString = searchString;
        }

        public void Refine(List<Result> results)
        {

            for (int i = 0; i < results.Count; i++)
            {
                for (int y = 0; y < contexts.Count; y++)
                {
                    for (int k = 0; k < contexts[y].tags.Count; k++)
                    {
                        if (results[i].url.Contains(contexts[y].tags[k]))
                        {
                            results[i].AddRelevance();
                        }
                        if (results[i].description.Contains(contexts[y].tags[k]))
                        {
                            results[i].AddRelevance();
                        }
                        if (results[i].title.Contains(contexts[y].tags[k]))
                        {
                            results[i].AddRelevance();
                        }
                    }
                    
                }

            }

            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].url.Contains(searchString))
                {
                    results[i].AddRelevance();
                }
                if (results[i].description.Contains(searchString))
                {
                    results[i].AddRelevance();
                }
                if (results[i].title.Contains(searchString))
                {
                    results[i].AddRelevance();
                }

                if (results[i].GetRelevance() == 0)
                {

                    results.Remove(results[i]);

                }
            }

            for (int i = 0; i < (results.Count - 1); i++)
            {
                for (int j = (i + 1); j < results.Count; j++)
                {
                    if (results[i].GetRelevance() > results[j].GetRelevance())
                    {
                        Result temp = results[i];
                        results[i] = results[j];
                        results[j] = temp;
                    }
                }
            }

            results.Reverse();

        }


    }
}
