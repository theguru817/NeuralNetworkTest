using NeuralNetworkTest.MatrixHelper;
using System;

namespace NeuralNetworkTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            double[,] inputArray = new double[,] { { 1 }, { 0 } };
            double[,] outputArray = new double[,] { { 1 } };
            Matrix desiredOutput = new Matrix(outputArray);
            NeuralNetwork nn = new NeuralNetwork(2, 1);

            nn.Train(inputArray, outputArray, 5);
            Matrix guess = nn.Guess(inputArray);

            Console.WriteLine(String.Format("Guess:{0}",guess[0][0].data));
            Console.ReadLine();
        }
    }
}