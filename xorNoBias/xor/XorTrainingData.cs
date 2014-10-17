using System.Security.Policy;

namespace xor
{
    public class TrainingSet
    {
        public double[] Inputs { get; private set; }
        public double[] Outputs { get; private set; }

        public TrainingSet(double i1, double i2, double out1 )
        {
            Inputs = new double[2];
            Outputs = new double[1];

            Inputs[0] = i1;
            Inputs[1] = i2;

            Outputs[0] = out1;
        }
    }

    public class XorTrainingData
    {
	    private const double Zero = 0.05;
		private const double One = 0.95;

	    public TrainingSet[] TrainingData; 

        public XorTrainingData()
        {
			TrainingData = new TrainingSet[4];
			TrainingData[0] = new TrainingSet(Zero, Zero, Zero);
			TrainingData[1] = new TrainingSet(Zero, One, One);
			TrainingData[2] = new TrainingSet(One, Zero, One);
			TrainingData[3] = new TrainingSet(One, One, Zero);
        }
    }
}
