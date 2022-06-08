using System.Collections;

namespace Genetic
{
    class Model
    {
        private GenePool pool;
        public delegate int EvaluateGeneType(ArrayList gene);
        public EvaluateGeneType evaluate;

        public Model(GenePool pool, EvaluateGeneType eval)
        {
            this.pool = pool;
            this.evaluate = eval;
        }
        public List<GeneScore> EvaluatePool()
        {
            List<GeneScore> scores = new List<GeneScore>();
            List<ArrayList> genes = this.pool.genes;
            for (int i = 0; i < this.pool.population; i++)
            {
                scores.Add(new GeneScore(
                    this.evaluate(genes[i]),
                    i,
                    genes[i]
                ));
            }
            // scores.Sort((lhs, rhs) => lhs.Score.CompareTo(rhs.Score));
            return scores;
        }
    }
    abstract class GeneBluePrint
    {
        /// <summary> 유전자 염기서열 길이 </summary>
        public uint length;
        public GeneBluePrint(uint length)
        {
            this.length = length;
        }
        /// <summary> 난수 유전자 생성 </summary>
        public ArrayList GenerateGene()
        {
            ArrayList gene = new ArrayList();
            for (int i = 0; i < length; i++) gene.Add(GetUnit());
            return gene;
        }
        /// <summary> 유전자 염기서열 생성 </summary>
        abstract protected object GetUnit();
        /// <summary> 유전자 교차 </summary>
        abstract protected ArrayList Overcross(ArrayList lhs, ArrayList rhs);
        /// <summary> 돌연변이 생성 </summary>
        abstract protected ArrayList Mutate(ArrayList lhs);
    }

    class GenePool
    {
        public uint generation, population;
        public List<ArrayList> genes;
        public GeneBluePrint blueprint;
        public GenePool(uint population, GeneBluePrint blueprint)
        {
            this.population = population;
            this.blueprint = blueprint;
            this.genes = new List<ArrayList>();
            this.generation = 0;
        }
        /// <summary> 난수 유전자로 풀 채우기 </summary>
        public void FillRandom()
        {
            for (uint i = 0; i < population; i++)
            {
                genes.Add(blueprint.GenerateGene());
            }
        }
    }

    class GeneScore
    {
        public int Score, Index;
        public ArrayList gene;
        public GeneScore(int score, int idx, ArrayList gene)
        {
            this.Score = score;
            this.Index = idx;
            this.gene = gene;
        }
    }
}
