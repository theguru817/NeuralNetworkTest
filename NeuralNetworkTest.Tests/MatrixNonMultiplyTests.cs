using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            MatrixHelper.Matrix firstMatrix = new MatrixHelper.Matrix(firstMatrixArray);
            MatrixHelper.Matrix result = firstMatrix.Transpose();
            MatrixHelper.Matrix correctMatrix = new MatrixHelper.Matrix(correctMatrixArray);

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
            MatrixHelper.Matrix firstMatrix = new MatrixHelper.Matrix(firstMatrixArray);
            MatrixHelper.Matrix secondMatrix = new MatrixHelper.Matrix(secondMatrixArray);
            MatrixHelper.Matrix result = firstMatrix.Add(secondMatrix);
            MatrixHelper.Matrix correctMatrix = new MatrixHelper.Matrix(correctMatrixArray);

            Assert.AreEqual(correctMatrix, result);
        }
    }
}