using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest.MatrixHelper
{
    public class Matrix
    {
        public List<MatrixRow> matrixData;

        public Matrix(double[][] marray)
        {
            matrixData = new List<MatrixRow>();
            for (int i = 0; i < marray.Length; i++)
            {
                MatrixRow mRow = new MatrixRow(marray[i]);
                matrixData.Add(mRow);
            }
        }

        public Matrix()
        {
            matrixData = new List<MatrixRow>();

        }

        public void ScalarMultiply(double scalarFactor)
        {
            foreach (MatrixRow rows in matrixData)
            {
                foreach (MatrixCol colValues in rows.matrixColData)
                {
                    colValues.mdata *= scalarFactor;
                }
            }
        }

        public Matrix DotMultiply(Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstColCount = matrixData[0].matrixColData.Count;
            int mSecondRowCount = secondMatrix.matrixData.Count;
            int mSecondColCount = secondMatrix.matrixData[0].matrixColData.Count;

            if (mFirstColCount == mSecondRowCount)
            {
                for (int i = 0; i < matrixData.Count; i++)
                {
                    for (int k = 0; k < mSecondColCount; k++)
                    {
                        double currentResult = resultMatrix.matrixData[i].matrixColData[k].mdata;
                        for (int j = 0; j < mFirstColCount; j++)
                        {
                            double firstMatrixItem = matrixData[i].matrixColData[j].mdata;
                            double secondMatrixItem = secondMatrix.matrixData[j].matrixColData[k].mdata;
                            currentResult += firstMatrixItem * secondMatrixItem;
                        }
                    }
                }
            }

            return resultMatrix;
        }

        public Matrix Add(Matrix secondMatrix)
        {
            Matrix resultMatrix = new Matrix();
            int mFirstRowCount = matrixData.Count;
            int mFirstColCount = matrixData[0].matrixColData.Count;
            int mSecondRowCount = secondMatrix.matrixData.Count;
            int mSecondColCount = secondMatrix.matrixData[0].matrixColData.Count;

            if (mFirstRowCount==mSecondRowCount && mFirstColCount==mSecondColCount)
            {
                for (int i=0; i<mFirstRowCount; i++)
                {
                    for (int j=0; j<mFirstColCount; j++)
                    {
                        double currentResult = resultMatrix.matrixData[i].matrixColData[j].mdata;
                        double firstMatrixItem = matrixData[i].matrixColData[j].mdata;
                        double secondMatrixItem = secondMatrix.matrixData[i].matrixColData[j].mdata;
                        currentResult = firstMatrixItem + secondMatrixItem;
                    }
                }
            }

            return resultMatrix;
        }

        public Matrix Transpose()
        {
            Matrix resultMatrix = new Matrix();
            int matrixRowCount = matrixData.Count;
            int matrixColCount = matrixData[0].matrixColData.Count;

            for (int i=0; i<matrixColCount; i++)
            {
                for (int j = 0; j < matrixRowCount; j++)
                {
                    resultMatrix.matrixData[i].matrixColData[j].mdata = matrixData[j].matrixColData[i].mdata;
                }
            }

            return resultMatrix;
        }

    }

    public class MatrixRow
    {
        internal List<MatrixCol> matrixColData;

        internal MatrixRow(double[] mColData)
        {
            matrixColData = new List<MatrixCol>();
            foreach (double item in mColData)
            {
                MatrixCol matrixCol = new MatrixCol(item);
                matrixColData.Add(matrixCol);
            }

        }


    }

    internal class MatrixCol
    {
        internal double mdata;

        internal MatrixCol(double mdata)
        {
            this.mdata = mdata;
        }
    }
}
