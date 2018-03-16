using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetworkTest.MatrixHelper;

namespace NeuralNetworkTest.Tests
{
    [TestClass]
    public class MatrixMultiplyTests
    {
        [TestMethod]
        public void MatrixDotMultiplyIdentityTest()
        {
            double[,] firstMatrixArray = new double[,] { {2, 4, 8 },
                {3, 5, 6 },
                {7, 2, 5 }
            };
            double[,] secondMatrixArray = new double[,] { {1, 0, 0 },
                {0, 1, 0 },
                {0, 0, 1 }
            };
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            Matrix result = firstMatrix.DotMultiply(secondMatrix);

            Assert.AreEqual(result, firstMatrix);
        }

        [TestMethod]
        public void MatrixDotMultiplyVectorTest()
        {
            double[,] firstMatrixArray = new double[,] { {2, 4, 8 },
                {3, 5, 6 },
                {7, 2, 5 }
            };
            double[,] secondMatrixArray = new double[,] { { 5 },
                { 7 },
                { 9 }
            };
            double[,] correctMatrixArray = new double[,] { {2*5+4*7+8*9},
                {3*5+5*7+6*9},
                {7*5+2*7+5*9}
            };
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            Matrix result = firstMatrix.DotMultiply(secondMatrix);
            Matrix correctMatrix = new Matrix(correctMatrixArray);

            Assert.AreEqual(correctMatrix, result);
        }

        [TestMethod]
        public void MatrixDotMultiplyInverseTest()
        {
            double[,] firstMatrixArray = new double[,] { { 1, 5, 7 },
                { 3, 2, 4 },
                { 6, 8, 9 }
            };
            double[,] secondMatrixArray = new double[,] { { -14.0/55.0, 11.0/55.0, 6.0/55.0 },
                { -3.0/55.0, -33.0/55.0, 17.0/55.0 },
                { 12.0/55.0, 22.0/55.0, -13.0/55.0 }
            };
            double[,] correctMatrixArray = new double[,] { { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            Matrix result = firstMatrix.DotMultiply(secondMatrix);
            Matrix correctMatrix = new Matrix(correctMatrixArray);

            Assert.AreEqual(correctMatrix, result);
        }

        [TestMethod]
        public void MatrixScalarMultiplyTest()
        {
            double[,] firstMatrixArray = new double[,] { { -14, 11, 6 },
                { -3, -33, 17 },
                { 12, 22, -13 }
            };
            double scalarFactor = 1.0 / 55.0;
            double[,] correctMatrixArray = new double[,] { { -14.0/55.0, 11.0/55.0, 6.0/55.0 },
                { -3.0/55.0, -33.0/55.0, 17.0/55.0 },
                { 12.0/55.0, 22.0/55.0, -13.0/55.0 }
            };
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix resultMatrix = firstMatrix.ScalarMultiply(scalarFactor);
            Matrix correctMatrix = new Matrix(correctMatrixArray);

            Assert.AreEqual(correctMatrix, resultMatrix);
        }

        [TestMethod]
        public void MatrixHadamardProductTest()
        {
            double[,] firstMatrixArray = new double[,] { { 1, 5, 7 },
                { 3, 2, 4 },
                { 6, 8, 9 }
            };
            double[,] secondMatrixArray = new double[,] { { 9, 8, 6 },
                { 4, 2, 3 },
                { 7, 5, 1 }
            };
            double[,] correctMatrixArray = new double[,] { { 1*9, 5*8, 7*6 },
                { 3*4, 2*2, 4*3 },
                { 7*6, 8*5, 9*1 }
            };
            Matrix firstMatrix = new Matrix(firstMatrixArray);
            Matrix secondMatrix = new Matrix(secondMatrixArray);
            Matrix result = firstMatrix.HadamardProduct(secondMatrix);
            Matrix correctMatrix = new Matrix(correctMatrixArray);

            Assert.AreEqual(correctMatrix, result);
        }
    }
}