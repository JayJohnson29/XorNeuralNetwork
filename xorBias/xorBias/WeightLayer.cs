using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xor
{
	public class WeightLayer
	{
		public Node[] Nodes { get; set; }

		public double[] Values
		{
			get
			{
				double[] v = new double[Nodes.Length];
				for (int i = 0; i < Nodes.Length - 1; i++)
				{
					v[i] = Nodes[i].Value;
				}

				// last node is a bias node
				v[Nodes.Length - 1] = 1.0;
				return v;
			}
		}



		public WeightLayer(int numNodes, int numInputs)
		{
			Nodes = new Node[numNodes + 1];
			for (int i = 0; i < Nodes.Length; i++)
			{
				Nodes[i] = new Node(numInputs);
			}

		}
	}
}
