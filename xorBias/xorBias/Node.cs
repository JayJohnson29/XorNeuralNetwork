using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xor
{
    public class Node
    {
        public double[] Weights { get; set; }
        public double Value { get; set; }
		public double ErrorSignal { get; set; }


        public void Calc( double[] inputs)
        {
            double v = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                v += inputs[i]*Weights[i];
            }
			Value = LogSigmoid( v );
        }

		public double LogSigmoid(double x)
		{
			if (x < -45.0)
				return 0.0;
			else if (x > 45.0)
				return 1.0;
			else 
				return 1.0 / (1.0 + Math.Exp(-x));
		}

        public Node(int inputConnections)
        {
            Random random = new Random();

            Weights = new double[inputConnections];
            for (int i = 0; i < inputConnections; i++)
            {
				Weights[i] = random.NextDouble() / 2;

				if (i%2 == 0)
					Weights[i] = Weights[i]*-1;
            }
        }
    }
}
