using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueryResponseList = System.Collections.Generic.List<System.Tuple<string, string[]>>;

namespace Test
{
    class QueryHandler
    {
        DataAccess dA;
        QueryGenerator queryGen;
        Func<string, string> stringOp;
        List<Query> queries;        

        public QueryHandler(
                            DataAccess dA,
                            SentenceBoiler sb,
                            Func<string, string> stringOp
                            )
        {                                                                               
            this.dA = dA;
            queryGen = new QueryGenerator(sb);
            this.stringOp = stringOp;
            queries = new List<Query>();
        }

        /// <summary>
        /// takes in input from front end and generates queries
        /// </summary>
        /// <param name="sentences">input quries from front end</param>
        private void genQueries(string[] sentences)
        {
            foreach (string sentence in sentences)
            {
                queries.Add(queryGen.queryGen(sentence));
            }
        }

        /// <summary>
        /// retrieves responses to queries and aggregates those responses
        /// </summary>
        /// <param name="q">Query to be sent off to data tier</param>
        private QueryResponseList aggregateQueryResults(Query q)
        {
            QueryResponseList blockList = new QueryResponseList();           
            foreach(var kvpair in dA.query(q))
            {
                blockList.Add(new Tuple<string, string[]>(q.originalSentence, kvpair.Value.ToArray()));
            }
            return blockList;
        }

        /// <summary>
        /// sends off query objects to the data tier
        /// </summary>
        private async Task<QueryResponseList[]> sendOff()
        {
            List<Task<QueryResponseList>> issuedQueries = new List<Task<QueryResponseList>>();
            foreach (Query q in queries)
            {
                issuedQueries.Add
                (
                    Task<QueryResponseList>.Factory.StartNew
                    (() => {return aggregateQueryResults(q);})
                );
            }
            return await Task.WhenAll(issuedQueries).ConfigureAwait(false);
        }

        /// <summary>
        /// encapsulates the algorithm for summarizing the help files
        /// </summary>
        /// <param name="toSummarize">responses from data access tier that will be summarized</param>
        public Tuple<string,string>[] summarize(List<QueryResponseList> toSummarize)//TODO
        { }

        /// <summary>
        /// acts as the junction for communcication between data access and front end
        /// </summary>
        /// <param name="sentences">input queries from the front end</param>
        public Tuple<string, string>[] handleQuery(string[] sentences)
        {
            genQueries(sentences);
            List<QueryResponseList> handledQueries = new List<QueryResponseList>();
            QueryResponseList[] response = sendOff().Result;
            foreach(QueryResponseList dict in response)
            {
                var deferred = from r in dict
                           select new Tuple<string, string[]>(r.Item1, r.Item2.Select((x) => stringOp(x)).ToArray());
                handledQueries.Add(deferred.ToList());
            }
            //return handledQueries;
            return summarize(handledQueries);
        }
    }
}
