using NeuralNetworkTest.MatrixHelper;
using System;
using System.Collections.Generic;

namespace NeuralNetworkTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double[,] inputArray = new double[,] { { 1 }, { 0 } };
            double[,] inputArray1 = new double[,] { { 0 }, { 1 } };
            double[,] inputArray2 = new double[,] { { 0 }, { 0 } };
            double[,] inputArray3 = new double[,] { { 1 }, { 1 } };
            List<Tuple<double[,],double[,]>> trainingData = new List<Tuple<double[,], double[,]>>();
            double[,] outputArray = new double[,] { { 1 } };
            double[,] outputArray1 = new double[,] { { 1 } };
            double[,] outputArray2 = new double[,] { { 0 } };
            double[,] outputArray3 = new double[,] { { 0 } };
            NeuralNetwork nn = new NeuralNetwork(2, 1);

            trainingData.Add(new Tuple<double[,], double[,]>(inputArray, outputArray));
            trainingData.Add(new Tuple<double[,], double[,]>(inputArray1, outputArray1));
            trainingData.Add(new Tuple<double[,], double[,]>(inputArray2, outputArray2));
            trainingData.Add(new Tuple<double[,], double[,]>(inputArray3, outputArray3));

            foreach (var trainingSet in trainingData)
            {
                nn.Train(trainingSet.Item1, trainingSet.Item2, 5);
            }

            Matrix guess = nn.Guess(inputArray);

            Console.WriteLine(String.Format("Guess:{0}",guess[0][0].data));
            Console.ReadLine();
        }
    }
}