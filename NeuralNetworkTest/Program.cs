using NeuralNetworkTest.MatrixHelper;
using System;

namespace NeuralNetworkTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double[,] inputArray = new double[,] { { 1 }, { 0 } };
            NeuralNetwork nn = new NeuralNetwork(inputArray, 2, 1);
            nn.PerformFeedForward();

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}