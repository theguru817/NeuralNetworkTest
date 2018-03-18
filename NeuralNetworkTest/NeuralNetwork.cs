using System;

namespace NeuralNetworkTest
{
    public class NeuralNetwork
    {
        private MatrixHelper.Matrix hiddenNodes;
        private MatrixHelper.Matrix inputNodes;
        private MatrixHelper.Matrix outputNodes;
        private MatrixHelper.Matrix inputWeightsMatrix;
        private MatrixHelper.Matrix hiddenWeightsMatrix;
        private double[,] inputsArray;
        private int numHiddenNodes;
        private int numOutputNodes;
        private double learningRate=0.2;
        private MatrixHelper.Matrix outputBias;
        private MatrixHelper.Matrix hiddenBias;

        public NeuralNetwork(double[,] inputsArray, int numHiddenNodes, int numOutputNodes)
        {
            inputNodes = new MatrixHelper.Matrix(inputsArray);
            outputNodes = new MatrixHelper.Matrix();
            this.inputsArray = inputsArray;
            this.numHiddenNodes = numHiddenNodes;
            this.numOutputNodes = numOutputNodes;
        }

        public void InitializeWeights()
        {
            double[,] inputWeightsArray = new double[numHiddenNodes, inputsArray.GetLength(0)];
            double[,] hiddenWeightsArray = new double[numOutputNodes, numHiddenNodes];

            for (int i = 0; i < numHiddenNodes; i++)
            {
                for (int j = 0; j < inputsArray.GetLength(0); j++)
                {
                    inputWeightsArray[i, j] = (new Random()).NextDouble();
                }
            }

            inputWeightsMatrix = new MatrixHelper.Matrix(inputWeightsArray);

            for (int i = 0; i < numOutputNodes; i++)
            {
                for (int j = 0; j < numHiddenNodes; j++)
                {
                    hiddenWeightsArray[i, j] = (new Random()).NextDouble();
                }
            }

            hiddenWeightsMatrix = new MatrixHelper.Matrix(hiddenWeightsArray);
        }

        public void PerformFeedForward()
        {
            InitializeWeights();

            double[,] hiddenBiasArray = new double[numHiddenNodes, 1];
            for (int i=0; i< numHiddenNodes; i++)
            {
                hiddenBiasArray[i, 0] = (new Random()).NextDouble();
            }
            hiddenBias = new MatrixHelper.Matrix(hiddenBiasArray);

            double[,] outputBiasArray = new double[numOutputNodes, 1];
            for (int i = 0; i < numOutputNodes; i++)
            {
                outputBiasArray[i, 0] = (new Random()).NextDouble();
            }
            outputBias = new MatrixHelper.Matrix(outputBiasArray);

            hiddenNodes = inputWeightsMatrix.DotMultiply(inputNodes).Add(hiddenBias);

            foreach (MatrixHelper.MatrixRow mRow in hiddenNodes)
            {
                foreach (MatrixHelper.MatrixCol mCol in mRow)
                {
                    mCol.data = 1 + Math.Pow(Math.E, (-1) * mCol.data);
                }
            }

            outputNodes = hiddenWeightsMatrix.DotMultiply(hiddenNodes).Add(outputBias);

            foreach (MatrixHelper.MatrixRow mRow in outputNodes)
            {
                foreach (MatrixHelper.MatrixCol mCol in mRow)
                {
                    mCol.data = 1 + Math.Pow(Math.E, (-1) * mCol.data);
                }
            }
        }

        public void PerformBackPropogation(MatrixHelper.Matrix desiredOutput)
        { 
            MatrixHelper.Matrix outputNeg = outputNodes.ScalarMultiply(-1);
            MatrixHelper.Matrix outputError = desiredOutput.Add(outputNeg);
            MatrixHelper.Matrix hiddenError = hiddenWeightsMatrix.Transpose().DotMultiply(outputError);
            MatrixHelper.Matrix deltaWeightsHO = outputError.HadamardProduct(outputNodes.Add(outputNodes.HadamardProduct(outputNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate).DotMultiply(hiddenNodes.Transpose());
            MatrixHelper.Matrix deltaWeightsIH = hiddenError.HadamardProduct(hiddenNodes.Add(hiddenNodes.HadamardProduct(hiddenNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate).DotMultiply(inputNodes.Transpose());
            MatrixHelper.Matrix deltaBiasO = outputError.HadamardProduct(outputNodes.Add(outputNodes.HadamardProduct(outputNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate);
            MatrixHelper.Matrix deltaBiasH = hiddenError.HadamardProduct(hiddenNodes.Add(hiddenNodes.HadamardProduct(hiddenNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate);

            hiddenWeightsMatrix = hiddenWeightsMatrix.Add(hiddenWeightsMatrix.Add(deltaWeightsHO));
            inputWeightsMatrix = inputWeightsMatrix.Add(inputWeightsMatrix.Add(deltaWeightsIH));

            outputBias = outputBias.Add(deltaBiasO);
            hiddenBias = hiddenBias.Add(deltaBiasH);
        }

    }
}