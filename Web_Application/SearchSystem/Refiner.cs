using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchSystem
{
    class Refiner
    {

        List<Context> contexts = new List<Context>();

        public Refiner(List<Context> contexts)
        {
            this.contexts = contexts;

        }

        public List<Result> Refine(List<Result> results)
	    {
	
		    List<Result> refinedResults = new List<Result>();
		
		    for(int i = 0; i < results.Count; i++)
		    {
			    for(int y = 0; y < contexts.Count; y++)
			    {
                    for (int k = 0; k < contexts[y].tags.Count; k++)
				    {
					    if(results[i].url.Contains(contexts[y].tags[k]))
					    {
						    results[i].AddRelevance();
					    }
                        if (results[i].description.Contains(contexts[y].tags[k]))
					    {
						    results[i].AddRelevance();
					    }
					    if(results[i].title.Contains(contexts[y].tags[k]))
					    {
						    results[i].AddRelevance();
					    }
				    }
			    }
			
		    }
		
		    foreach(Result r in results)
		    {
			    if(r.GetRelevance() > 0)
			    {
				
				    refinedResults.Add(r);
				
			    }
		    }
		
		    for (int i = 0; i < (refinedResults.Count - 1); i++)
		    {
			    for (int j = (i + 1); j < refinedResults.Count; j++) 
			    {
				    if (refinedResults[i].GetRelevance() > refinedResults[j].GetRelevance())
				    {
					    Result temp = refinedResults[i];
					    refinedResults[i] = refinedResults[j];
					    refinedResults[j] = temp;
				    }
			    }
		    }
		
		    return refinedResults;
	}


    }
}
