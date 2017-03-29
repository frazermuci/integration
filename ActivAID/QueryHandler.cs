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
        Func<string, string> stringOp;
        List<Query> queries;
        SentenceBoiler sb;
        DataAccess dA;

        public QueryHandler(
                            DataAccess dA,
                            SentenceBoiler sb,
                            Func<string, string> stringOp
                            ) //later associate results with
        {                                                                               //query
            this.dA = dA;
            this.sb = sb;
            this.stringOp = stringOp;
            this.queries = new List<Query>();
        }

        private void genQueries(string[] sentences)
        {
            QueryGenerator queryGen = new QueryGenerator(sb);
            foreach (string sentence in sentences)
            {
                queries.Add(queryGen.queryGen(sentence));
            }
        }
        private QueryResponseList aggregateQueryResults(Query q)
        {
            QueryResponseList blockList = new QueryResponseList();           
            foreach(var kvpair in dA.query(q))
            {
                blockList.Add(new Tuple<string, string[]>(q.originalSentence, kvpair.Value.ToArray()));
            }
            return blockList;
        }

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

        public List<QueryResponseList> handleQuery(string[] sentences)
        {
            genQueries(sentences);
            List<QueryResponseList> handledQueries = new List<QueryResponseList>();
            QueryResponseList[] response = sendOff().Result;
            foreach(QueryResponseList dict in response)
            {
                var deferred = from r in dict
                           select new Tuple<string, string[]>(r.Item1, r.Item2.Select((x) => stringOp(x)).ToArray());//stringOp(r.Value);
                handledQueries.Add(deferred.ToList());
            }
            return handledQueries;
        }
    }
}
