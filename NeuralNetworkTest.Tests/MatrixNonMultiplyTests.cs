using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworkTest.MatrixHelper;

namespace NeuralNetworkTest.Tests
{
    [TestClass]
    public class MatrixNonMultiplyTests
    {
        [TestMethod]
        public void MatrixTransposeTest()
        {
            double[,] firstMatrixArray = new double[,] { {2, 4, 8 },
                {3, 5, 6 },
                {7, 2, 5 }
            };
            double[,] correctMatrixArray = new double[,] { {2, 3, 7 },
                {4, 5, 2 },
                {8, 6, 5 }
            };

            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix result = firstMatrix.Transpose();
            Matrix correctMatrix = new Matrix(correctMatrixArray);

            Assert.AreEqual(result, correctMatrix);
        }

        [TestMethod]
        public void MatrixAdditionTest()
        {
            double[,] firstMatrixArray = new double[,] { {2, 4, 8 },
                {3, 5, 6 },
                {7, 2, 5 }
            };
            double[,] secondMatrixArray = new double[,] { { 5, 10, 2 },
                { 1, 3, 4 },
                { 9, 7, 2 }
            };
            double[,] correctMatrixArray = new double[,] { {2+5, 4+10, 2+8},
                {3+1, 5+3, 6+4},
                {7+9, 2+7, 5+2}
            };
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            Matrix result = firstMatrix.Add(secondMatrix);
            Matrix correctMatrix = new Matrix(correctMatrixArray);

            Assert.AreEqual(correctMatrix, result);
        }
    }
}