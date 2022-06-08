using System.Collections;

namespace Genetic
{
    class Model
    {
        private GenePool pool;
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
                return String.Format("G{0} UL{1} E{2} M{3} HS-1", pool.generation, pool.blueprint.length, pool.blueprint.elite, pool.blueprint.mutation);
            return String.Format("G{0} UL{1} E{2} M{3} HS{4}", pool.generation, pool.blueprint.length, pool.blueprint.elite, pool.blueprint.mutation, elite.Score);
        }
    }
    abstract class GeneBluePrint
    {
        protected static Random random = new Random();
        /// <summary> 유전자 염기서열 길이 </summary>
        public int length, maskLength, elite, mutation;
        public bool[][] MaskPattern;

        public GeneBluePrint(int length, int maskLength, int elite, int mutation)
        {
            this.length = length;
            this.maskLength = maskLength;
            this.elite = elite;
            this.mutation = mutation;
            this.MaskPattern = new bool[length][];
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
                bool[] mask = MaskPattern[m];
                ArrayList u1 = new ArrayList(), u2 = new ArrayList();

                for(int i = 0; i < mask.Length; i++)
                {
                    if (mask[i])
                    {
                        u1.Add(lhs[i]);
                        u2.Add(rhs[i]);
                    }
                    else
                    {
                        u1.Add(rhs[i]);
                        u2.Add(lhs[i]);
                    }
                }

                overcrossed.Add(u1);
                //overcrossed.Add(u2);
            }
            return overcrossed;
        }
        /// <summary> 돌연변이 생성 </summary>
        public ArrayList Mutate(ArrayList lhs)
        {
            return GenerateGene();
        }
    }

    class GenePool
    {
        public int generation, population;
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

            List<ArrayList> nextGenes = new List<ArrayList>();

            List<ArrayList> eliteGenes = new List<ArrayList>();
            for (int i = 0; i < blueprint.elite; i++) eliteGenes.Add(scores[i].gene);

            for(int i = 0; i < blueprint.elite; i++)
            {
                for(int j = i + 1; j < 4 - i; j++)
                {
                    if (blueprint.IsMutation())
                    {
                        eliteGenes.AddRange(blueprint.Overcross(eliteGenes[i], blueprint.GenerateGene()));
                    }
                    else
                    {
                        eliteGenes.AddRange(blueprint.Overcross(eliteGenes[i], scores[j].gene));
                    }
                }
                    
            }
            nextGenes.AddRange(eliteGenes);

            for(int i = (int)blueprint.elite; i < population - 1 && nextGenes.Count < population; i++)
            {
                if (blueprint.IsMutation())
                {
                    System.Diagnostics.Trace.WriteLine("Oh!");
                    nextGenes.AddRange(blueprint.Overcross(scores[i].gene, blueprint.GenerateGene()));
                }
                else nextGenes.AddRange(blueprint.Overcross(scores[i].gene, scores[i + 1].gene));
            }

            nextGenes.Add(blueprint.GenerateGene());

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
    }
}
