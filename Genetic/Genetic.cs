using System.Collections;

namespace Genetic
{
    class Model
    {
        private GenePool pool;
        public GeneScore elite;
        public delegate int EvaluateGeneType(ArrayList gene);
        public EvaluateGeneType evaluate;

        public Model(GenePool pool, EvaluateGeneType eval)
        {
            this.pool = pool;
            this.evaluate = eval;
        }

        public uint Fit()
        {
            return pool.Next(EvaluatePool());
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
            scores.Sort((lhs, rhs) => lhs.Score.CompareTo(rhs.Score));
            elite = scores[0];
            return scores;
        }

        public override string ToString()
        {
            if(elite == null)
                return String.Format("G{0} UL{1} HS-1", pool.generation, pool.blueprint.length);
            return String.Format("G{0} UL{1} HS{2}", pool.generation, pool.blueprint.length, elite.Score);
        }
    }
    abstract class GeneBluePrint
    {
        protected static Random random = new Random();
        /// <summary> 유전자 염기서열 길이 </summary>
        public uint length, maskLength, elite, mutation;
        public bool[][] MaskPattern;

        public GeneBluePrint(uint length, uint maskLength, uint elite, uint mutation)
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

        static public bool[] GenerateBinaryMask(uint length)
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
                overcrossed.Add(u2);
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

        public uint Next(List<GeneScore> scores)
        {
            scores.Sort((lhs, rhs) => lhs.Score.CompareTo(rhs.Score));

            List<ArrayList> nextGenes = new List<ArrayList>();

            List<ArrayList> eliteGenes = new List<ArrayList>();
            for (int i = 0; i < blueprint.elite; i++) eliteGenes.Add(scores[i].gene);

            for(int i = 0; i < blueprint.elite - 1; i++)
            {
                for(int j = 0; j < blueprint.elite; j++)
                    eliteGenes.AddRange(blueprint.Overcross(eliteGenes[i], eliteGenes[j]));
            }
            nextGenes.AddRange(eliteGenes);

            for(int i = (int)blueprint.elite; i < population - 1 && nextGenes.Count < population; i++)
            {
                nextGenes.AddRange(blueprint.Overcross(scores[i].gene, scores[i + 1].gene));
            }


            nextGenes = nextGenes.GetRange(0, (int)(population - blueprint.mutation));

            for (int i = 0; i < blueprint.mutation; i++)
            {
                nextGenes.Add(blueprint.Mutate(eliteGenes[i]));
            }

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
