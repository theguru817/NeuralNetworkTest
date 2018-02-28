using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NeuralNetworkTest.Tests
{
    [TestClass]
    public class MatrixMultiplyTests
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

        [TestMethod]
        public void MatrixDotMultiplyVectorTest()
        {
            double[][] firstMatrixArray = new double[][] { new double[] {2, 4, 8 },
                new double[] {3, 5, 6 },
                new double[] {7, 2, 5 }
            };
            double[][] secondMatrixArray = new double[][] { new double[] { 5 },
                    new double[] { 7 },
                    new double[] { 9 }
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

        [TestMethod]
        public void MatrixDotMultiplyInverseTest()
        {
            double[][] firstMatrixArray = new double[][] { new double[] { 1, 5, 7 },
                new double[] { 3, 2, 4 },
                new double[] { 6, 8, 9 }
            };
            double[][] secondMatrixArray = new double[][] { new double[] { -14/55, 11/55, 6/55 },
                    new double[] { -3/55, -33/55, 17/55 },
                    new double[] { 12/55, 22/55, -13/55 }
            };
            double[][] correctMatrixArray = new double[][] { new double[] { 1, 0, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 0, 0, 1 }
            };
            MatrixHelper.Matrix firstMatrix = new MatrixHelper.Matrix(firstMatrixArray);
            MatrixHelper.Matrix secondMatrix = new MatrixHelper.Matrix(secondMatrixArray);
            MatrixHelper.Matrix result = firstMatrix.DotMultiply(secondMatrix);
            MatrixHelper.Matrix correctMatrix = new MatrixHelper.Matrix(correctMatrixArray);

            Assert.AreEqual(result, correctMatrix);
        }

        [TestMethod]
        public void MatrixScalarMultiplyTest()
        {
            double[][] firstMatrixArray = new double[][] { new double[] { -14, 11, 6 },
                new double[] { -3, -33, 17 },
                new double[] { 12, 22, 55 }
            };
            double scalarFactor = 55;
            double[][] correctMatrixArray = new double[][] { new double[] { -14/55, 11/55, 6/55 },
                    new double[] { -3/55, -33/55, 17/55 },
                    new double[] { 12/55, 22/55, -13/55 }
            };
            MatrixHelper.Matrix firstMatrix = new MatrixHelper.Matrix(firstMatrixArray);
            firstMatrix.ScalarMultiply(scalarFactor);
            MatrixHelper.Matrix correctMatrix = new MatrixHelper.Matrix(correctMatrixArray);

            Assert.AreEqual(firstMatrix, correctMatrix);
        }

        [TestMethod]
        public void MatrixHadamardProductTest()
        {
            double[][] firstMatrixArray = new double[][] { new double[] { 1, 5, 7 },
                new double[] { 3, 2, 4 },
                new double[] { 6, 8, 9 }
            };
            double[][] secondMatrixArray = new double[][] { new double[] { 9, 8, 6 },
                    new double[] { 4, 2, 3 },
                    new double[] { 7, 5, 1 }
            };
            double[][] correctMatrixArray = new double[][] { new double[] { 1*9, 5*8, 7*6 },
                new double[] { 3*4, 2*2, 4*3 },
                new double[] { 7*6, 8*5, 9*1 }
            };
            MatrixHelper.Matrix firstMatrix = new MatrixHelper.Matrix(firstMatrixArray);
            MatrixHelper.Matrix secondMatrix = new MatrixHelper.Matrix(secondMatrixArray);
            MatrixHelper.Matrix result = firstMatrix.DotMultiply(secondMatrix);
            MatrixHelper.Matrix correctMatrix = new MatrixHelper.Matrix(correctMatrixArray);

            Assert.AreEqual(result, correctMatrix);
        }
    }
}
