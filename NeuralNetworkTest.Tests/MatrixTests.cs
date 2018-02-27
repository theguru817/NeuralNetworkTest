using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeuralNetworkTest.Tests
{
    [TestClass]
    public class MatrixTests
    {

        [TestMethod]
        public void MatrixDotMultiplyIdentityTest()
        {
            double[][] firstMatrixArray = new double[][] { new double[] {2, 4, 8 },
                new double[] {3, 5, 6 },
                new double[] {7, 2, 5 }
            };
            double[][] secondMatrixArray = new double[][] { new double[] {1, 0, 0 },
                new double[] {0, 1, 0 },
                new double[] {0, 0, 1 }
            };
            MatrixHelper.Matrix firstMatrix = new MatrixHelper.Matrix(firstMatrixArray);
            MatrixHelper.Matrix secondMatrix = new MatrixHelper.Matrix(secondMatrixArray);
            MatrixHelper.Matrix result = firstMatrix.DotMultiply(secondMatrix);

            Assert.AreEqual(result, firstMatrix);
        }

        public void MatrixDotMultiplyTest()
        {
            double[][] firstMatrixArray = new double[][] { new double[] {2, 4, 8 },
                new double[] {3, 5, 6 },
                new double[] {7, 2, 5 }
            };
            double[][] secondMatrixArray = new double[][] { new double[] { 5 },
                    new double[] {7 },
                    new double[] {9 }
            };
            double[][] correctMatrixArray = new double[][] { new double[] {2*5+4*7+8*9},
                new double[] {3*5+5*7+6*9},
                new double[] {7*5+2*7+5*9}
            };
            MatrixHelper.Matrix firstMatrix = new MatrixHelper.Matrix(firstMatrixArray);
            MatrixHelper.Matrix secondMatrix = new MatrixHelper.Matrix(secondMatrixArray);
            MatrixHelper.Matrix result = firstMatrix.DotMultiply(secondMatrix);
            MatrixHelper.Matrix correctMatrix = new MatrixHelper.Matrix(correctMatrixArray);

            Assert.AreEqual(result, correctMatrix);
        }
    }
}
