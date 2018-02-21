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
            for (int i=0; i<marray.Length; i++ )
            {
                MatrixRow mRow = new MatrixRow(marray[i]);
                matrixData.Add(mRow);
            }
        }

        public Matrix()
        {
            matrixData = new List<MatrixRow>();

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
