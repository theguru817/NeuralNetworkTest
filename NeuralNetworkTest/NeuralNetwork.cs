using System;
using NeuralNetworkTest.MatrixHelper;

namespace NeuralNetworkTest
{
    public class NeuralNetwork
    {
        private Matrix hiddenNodes;
        private Matrix inputNodes;
        private Matrix outputNodes;
        private Matrix inputWeightsMatrix;
        private Matrix hiddenWeightsMatrix;
        private double[,] inputsArray;
        private int numHiddenNodes;
        private int numOutputNodes;
        private double learningRate=0.2;
        private Matrix outputBias;
        private Matrix hiddenBias;

        public NeuralNetwork(int numHiddenNodes, int numOutputNodes)
        {
            
            outputNodes = new Matrix();
            
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

            inputWeightsMatrix = new Matrix(inputWeightsArray);

            for (int i = 0; i < numOutputNodes; i++)
            {
                for (int j = 0; j < numHiddenNodes; j++)
                {
                    hiddenWeightsArray[i, j] = (new Random()).NextDouble();
                }
            }

            hiddenWeightsMatrix = new Matrix(hiddenWeightsArray);
        }

        public void PerformFeedForward()
        {
            double[,] hiddenBiasArray = new double[numHiddenNodes, 1];
            for (int i=0; i< numHiddenNodes; i++)
            {
                hiddenBiasArray[i, 0] = (new Random()).NextDouble();
            }
            hiddenBias = new Matrix(hiddenBiasArray);

            double[,] outputBiasArray = new double[numOutputNodes, 1];
            for (int i = 0; i < numOutputNodes; i++)
            {
                outputBiasArray[i, 0] = (new Random()).NextDouble();
            }
            outputBias = new Matrix(outputBiasArray);

            hiddenNodes = inputWeightsMatrix.DotMultiply(inputNodes).Add(hiddenBias);

            hiddenNodes = hiddenNodes.ApplyFunction(Sigmoid);

            outputNodes = hiddenWeightsMatrix.DotMultiply(hiddenNodes).Add(outputBias);

            outputNodes = outputNodes.ApplyFunction(Sigmoid);
        }

        public double Sigmoid (double x)
        {
            double result;

            result = 1 / (1 + Math.Pow(Math.E, -x));

            return result;
        }

        public void PerformBackPropogation(Matrix desiredOutput)
        { 
            Matrix outputNeg = outputNodes.ScalarMultiply(-1);
            Matrix outputError = desiredOutput.Add(outputNeg);
            Matrix hiddenError = hiddenWeightsMatrix.Transpose().DotMultiply(outputError);
            Matrix deltaWeightsHO = outputError.HadamardProduct(outputNodes.Add(outputNodes.HadamardProduct(outputNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate).DotMultiply(hiddenNodes.Transpose());
            Matrix deltaWeightsIH = hiddenError.HadamardProduct(hiddenNodes.Add(hiddenNodes.HadamardProduct(hiddenNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate).DotMultiply(inputNodes.Transpose());
            Matrix deltaBiasO = outputError.HadamardProduct(outputNodes.Add(outputNodes.HadamardProduct(outputNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate);
            Matrix deltaBiasH = hiddenError.HadamardProduct(hiddenNodes.Add(hiddenNodes.HadamardProduct(hiddenNodes).ScalarMultiply(-1))).ScalarMultiply(learningRate);

            hiddenWeightsMatrix = hiddenWeightsMatrix.Add(hiddenWeightsMatrix.Add(deltaWeightsHO));
            inputWeightsMatrix = inputWeightsMatrix.Add(inputWeightsMatrix.Add(deltaWeightsIH));

            outputBias = outputBias.Add(deltaBiasO);
            hiddenBias = hiddenBias.Add(deltaBiasH);
        }

        public void Train(double[,] inputArray, double[,] desiredOutputArray, int numEpochs)
        {
            this.inputNodes = new Matrix(inputArray);
            this.inputsArray = inputArray;
            Matrix desiredOutput = new Matrix(desiredOutputArray);

            InitializeWeights();

            for (int i=0; i<numEpochs; i++)
            {
                PerformFeedForward();
                PerformBackPropogation(desiredOutput);
            }
        }

        public Matrix Guess(double[,] inputArray)
        {
            this.inputNodes = new Matrix(inputArray);
            this.inputsArray = inputArray;
            PerformFeedForward();
            return outputNodes;

        }

    }
}