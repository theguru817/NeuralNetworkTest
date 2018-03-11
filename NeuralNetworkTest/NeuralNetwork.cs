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

        public MatrixHelper.Matrix PerformFeedForward()
        {
            InitializeWeights();

            hiddenNodes = inputWeightsMatrix.DotMultiply(inputNodes);
            outputNodes = hiddenWeightsMatrix.DotMultiply(hiddenNodes);

            return outputNodes;
        }
    }
}