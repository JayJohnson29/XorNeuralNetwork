using System;

namespace xor
{
	class Program
	{
		public const double LearningRate = 0.35;

		private static void Main(string[] args)
		{
			var x = new XorTrainingData();
			var w = new WeightLayer(2, 3);
			var outputNode = new Node(3);

			double error = 1.0;
			int i = 0;
			while (Math.Abs(error) > 0.005 && i++ < 70000)
			{
				error = Apply(x, w, outputNode);
				if (i%10000 == 0)
				{
					Console.WriteLine(string.Format("Iteration {0} {1}", i, error));
					Check(x, w, outputNode);
					Console.WriteLine();
				}
			}
			Console.WriteLine(string.Format("Iterations = {0} {1}", i, error));

			Check(x, w, outputNode);
			Console.WriteLine("Press enter to exit.");
			Console.ReadLine();
		}

		private static void Check(XorTrainingData xorTrainingData, WeightLayer weightLayer, Node outputNode)
		{
			foreach (var v in xorTrainingData.TrainingData)
			{
				// for each hidden unit calculate its activation or value

				for (int i = 0; i < weightLayer.Nodes.Length; i++)
				{
					weightLayer.Nodes[i].Calc(v.Inputs);
				}

				// Calculate the output or activation value for the network

				outputNode.Calc(weightLayer.Values);

				// Calculate the error (actual - target )

				Console.WriteLine(string.Format("{0} {1} {2}", v.Outputs[0], outputNode.Value, (v.Outputs[0] - outputNode.Value)));
			}
		}


		private static double Apply(XorTrainingData xorTrainingData, WeightLayer weightLayer, Node outputNode)
		{
			double totalError = 0;
			foreach (var v in xorTrainingData.TrainingData)
			{
				// Forward

				// for each hidden unit calculate its activation or value

				for (int i = 0; i < weightLayer.Nodes.Length; i++)
				{
					weightLayer.Nodes[i].Calc(v.Inputs);
				}

				// Calculate the output or activation value for the network
	
				outputNode.Calc(weightLayer.Values);

				// Calculate the error (actual - target )

				totalError += Math.Abs(v.Outputs[0] - outputNode.Value);


				// Back Prop

				// calculate error signal for output node
				outputNode.ErrorSignal = (v.Outputs[0] - outputNode.Value)*outputNode.Value*(1 - outputNode.Value);

				// calculate error term for hidden unit
				for (int i = 0; i < weightLayer.Nodes.Length; i++)
				{
					weightLayer.Nodes[i].ErrorSignal = weightLayer.Nodes[i].Value*(1 - weightLayer.Nodes[i].Value)*outputNode.Weights[i]*outputNode.ErrorSignal;
				}

				// update the weights

				// update the input to hidden layer weights

				for (int i = 0; i < weightLayer.Nodes.Length; i++)
				{
					for (int j = 0; j < weightLayer.Nodes[i].Weights.Length; j++)
					{
						weightLayer.Nodes[i].Weights[j] += LearningRate * weightLayer.Nodes[i].ErrorSignal * v.Inputs[j];
					}
				}

				// update the hidden layer to output weights

				for (int i = 0; i < outputNode.Weights.Length; i++)
				{
					outputNode.Weights[i] += LearningRate * outputNode.ErrorSignal * weightLayer.Nodes[i].Value;
				}

			}
			return totalError;
		}
	}
}
