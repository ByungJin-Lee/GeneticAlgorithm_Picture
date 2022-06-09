using System.Collections;

namespace Genetic
{
    class Model
    {
        public GenePool pool;
        public GeneScore elite;
        public List<GeneScore> scores;
        public delegate int EvaluateGeneType(ArrayList gene);
        public EvaluateGeneType evaluate;

        public Model(GenePool pool, EvaluateGeneType eval)
        {
            this.pool = pool;
            this.evaluate = eval;
        }
        
        public void Fit_Next()
        {
            Fit();
            Next();
        }

        public void Next()
        {
            if (scores != null) 
                this.pool.Next(scores);
        }

        public List<GeneScore> Fit()
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
            scores.Sort((lhs, rhs) => lhs.Score.CompareTo(rhs.Score));
            elite = scores[0];
            this.scores = scores;
            return scores;
        }

        public override string ToString()
        {
            if(elite == null)
                return String.Format("G{0} P{1} UL{2} E{3} M{4}% HS-1", pool.generation, pool.population, pool.blueprint.length, pool.blueprint.elite, pool.blueprint.mutation);
            return String.Format("G{0} P{1} UL{2} E{3} M{4}% HS{5}", pool.generation, pool.population, pool.blueprint.length, pool.blueprint.elite, pool.blueprint.mutation, elite.Score);
        }
    }
    abstract class GeneBluePrint
    {
        protected static Random random = new Random();
        /// <summary> 유전자 염기서열 길이 </summary>
        public int length, maskLength, elite, mutation, overcross;

        public GeneBluePrint(int length, int maskLength, int elite, int mutation, int overcross)
        {
            this.length = length;
            this.maskLength = maskLength;
            this.elite = elite;
            this.mutation = mutation;
            this.overcross = overcross;
        }
        /// <summary> 난수 유전자 생성 </summary>
        public ArrayList GenerateGene()
        {
            ArrayList gene = new ArrayList();
            for (int i = 0; i < length; i++) gene.Add(GetUnit());
            return gene;
        }

        public bool IsMutation()
        {
            return random.Next(100) < mutation;
        }

        public bool IsOvercross()
        {
            return random.Next(100) < overcross;
        }

        static public bool[] GenerateBinaryMask(int length)
        {
            bool[] mask = new bool[length];
            for(int i = 0; i < length; i++)
            {
                mask[i] = random.Next(2) == 1;
            }
            return mask;
        }

        

        /// <summary> 유전자 염기서열 생성 </summary>
        abstract public object GetUnit();
        /// <summary> 유전자 교차 </summary>
        public List<ArrayList> Overcross(ArrayList lhs, ArrayList rhs)
        {
            List<ArrayList> overcrossed = new List<ArrayList>();

            for(int m = 0; m < maskLength; m++)
            {
                bool[] mask = GenerateBinaryMask(length);

                ArrayList g1 = new ArrayList(), g2 = new ArrayList();
                for (int i = 0; i < mask.Length; i++) {
                    if (mask[i])
                    {
                        g1.Add(lhs[i]);
                        //g2.Add(rhs[i]);
                    }
                    else
                    {
                        g1.Add(rhs[i]);
                        //g2.Add(lhs[i]);
                    }
                }
                overcrossed.Add(g1);
                //overcrossed.Add(g2);
            }
            return overcrossed;
        }
        /// <summary> 돌연변이 생성 </summary>
        public List<ArrayList> Mutate(ArrayList lhs)
        {
            List<ArrayList> mutations = new List<ArrayList>();
            if(lhs == null) mutations.Add(GenerateGene());
            else mutations = Overcross(lhs, GenerateGene());
            return mutations;
        }
    }

    class GenePool
    {
        public int generation, population, interval = 25;
        public List<ArrayList> genes;
        public GeneBluePrint blueprint;
        public GenePool(int population, GeneBluePrint blueprint)
        {
            this.population = population;
            this.blueprint = blueprint;
            this.genes = new List<ArrayList>();
            this.generation = 0;
        }

        public int Next(List<GeneScore> scores)
        {
            List<ArrayList> desending = new List<ArrayList>();
            foreach (GeneScore cs in scores) desending.Add(cs.gene);
            List<ArrayList> nextGenes = desending.GetRange(0, blueprint.elite);
            //GeneScore.GetHighScoreCount(scores) > 1
            if (GeneScore.GetHighScoreCount(scores) > 1)
            {
                while(nextGenes.Count < population)
                {
                    nextGenes.AddRange(blueprint.Mutate(desending[0]));
                }
                genes = nextGenes;
                return ++generation;
            }

            int i = 0;
            while(nextGenes.Count < population && i < population - 1)
            {
                if (blueprint.IsMutation())
                {
                    nextGenes.AddRange(blueprint.Mutate(desending[i]));
                }
                else
                {
                    nextGenes.AddRange(blueprint.Overcross(desending[i], desending[i+1]));
                }
            }
            genes = nextGenes.GetRange(0, (int)population);

            return ++generation;
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

        static public int GetHighScoreCount(List<GeneScore> scores)
        {
            int count = 0, sc = scores[0].Score;
            foreach(GeneScore score in scores)
            {
                if(score.Score == sc)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        static public int IsDup(List<GeneScore> scores)
        {
            int count = 0;
            for (int i = scores.Count - 1; i > 0 ; i--)
            {
                if (scores[i].Score == scores[i - 1].Score) count++;
            }

            return count;
        }

    }
}
