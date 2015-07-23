using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MatrixHelper.Tests
{
    [TestClass()]
    public class MatrixHelperTests
    {
        static string message;

        #region Constructors tests

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareMatrixConstructor_NotSquareInputMatrixExceptionTest()
        {
            GeneralMatrix<int> matrix1 = new SquareMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SquareMatrixConstructor_NullInputMatrixExceptionTest()
        {
            GeneralMatrix<int> matrix1 = new SquareMatrix<int>(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SymmetricalMatrixConstructor_NotSymmetricalInputMatrixExceptionTest()
        {
            GeneralMatrix<int> matrix = new SymmetricalMatrix<int>(new int[3, 3] { { 1, 2, 1 }, { 2, 1, 2 }, { 3, 2, 1 } });
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SymmetricalMatrixConstructor_NullInputMatrixExceptionTest()
        {
            GeneralMatrix<int> matrix1 = new SymmetricalMatrix<int>(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DiagonalMatrixConstructor_NotDiagonalInputMatrixExceptionTest()
        {
            GeneralMatrix<int> matrix = new DiagonalMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DiagonalMatrixConstructor_NullInputMatrixExceptionTest()
        {
            GeneralMatrix<int> matrix1 = new DiagonalMatrix<int>(null);
        }

        #endregion

        #region Event tests

        [TestMethod()]
        public void GeneralMatrixChangeEventTest()
        {
            GeneralMatrix<int> matrix = new GeneralMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            Subscribe(matrix);
            matrix[0, 1] = 5;
            Unsubscribe(matrix);
            Assert.AreEqual<string>("GeneralMatrix", message);
        }

        [TestMethod()]
        public void SquareMatrixChangeEventTest()
        {
            GeneralMatrix<int> matrix = new SquareMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            Subscribe(matrix);
            matrix[0, 1] = 5;
            Unsubscribe(matrix);
            Assert.AreEqual<string>("SquareMatrix", message);
        }

        [TestMethod()]
        public void SymmetricalMatrixChangeEventTest()
        {
            GeneralMatrix<int> matrix = new SymmetricalMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            Subscribe(matrix);
            matrix[0, 1] = 5;
            Assert.AreEqual<string>("SymmetricalMatrix: changed both symmetric and request elements.", message);

            matrix[1, 1] = 5;
            Assert.AreEqual<string>("SymmetricalMatrix: changed element on main diagonal.", message);
            Unsubscribe(matrix);
        }

        [TestMethod()]
        public void DiagonalMatrixChangeEventTest()
        {
            GeneralMatrix<int> matrix = new DiagonalMatrix<int>(new int[3, 3] { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 3 } });
            Subscribe(matrix);
            matrix[0, 1] = 5;
            Assert.AreEqual<string>("DiagonalMatrix: can't change non main diagonal element.", message);

            matrix[1, 1] = 5;
            Assert.AreEqual<string>("DiagonalMatrix: changed element on main diagonal.", message);
            Unsubscribe(matrix);
        }

        #endregion

        #region Setter and Indexer tests

        [TestMethod()]
        public void GeneralMatrixSetterTest()
        {
            GeneralMatrix<int> matrix = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            matrix[0, 3] = 5;
            matrix[1, 1] = 10;
            Assert.AreEqual<int>(5, matrix[0, 3]);
            Assert.AreEqual<int>(10, matrix[1, 1]);
        }

        [TestMethod()]
        public void SquareMatrixSetterTest()
        {
            GeneralMatrix<int> matrix = new SquareMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            matrix[0, 1] = 5;
            matrix[1, 1] = 10;
            Assert.AreEqual<int>(5, matrix[0, 1]);
            Assert.AreEqual<int>(10, matrix[1, 1]);
        }

        [TestMethod()]
        public void SymmetricalMatrixSetterTest()
        {
            GeneralMatrix<int> matrix = new SymmetricalMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            matrix[0, 1] = 5;
            matrix[1, 1] = 10;
            Assert.AreEqual<int>(5, matrix[0, 1]);
            Assert.AreEqual<int>(5, matrix[1, 0]);
            Assert.AreEqual<int>(10, matrix[1, 1]);
        }

        [TestMethod()]
        public void DiagonalMatrixSetterTest()
        {
            GeneralMatrix<int> matrix = new DiagonalMatrix<int>(new int[3, 3] { { 1, 0, 0}, { 0, 2, 0 }, { 0, 0, 3 } });
            matrix[0, 1] = 5;
            matrix[1, 1] = 10;
            Assert.AreEqual<int>(0, matrix[0, 1]);
            Assert.AreEqual<int>(0, matrix[1, 0]);
            Assert.AreEqual<int>(10, matrix[1, 1]);
        }

        #endregion

        #region Addition tests

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void MatricesAdditionCallingOnNullReferenceTest()
        {
            GeneralMatrix<int> matrix1 = null;
            GeneralMatrix<int> matrix2 = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            matrix1.SumWith(matrix2, AdditionMethod);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatricesAdditionCallingWithNullSecondAddendTest()
        {            
            GeneralMatrix<int> matrix1 = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            GeneralMatrix<int> matrix2 = null;
            matrix1.SumWith(matrix2, AdditionMethod);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MatricesAdditionCallingWithAdditionRuleTest()
        {
            GeneralMatrix<int> matrix1 = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            GeneralMatrix<int> matrix2 = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            matrix1.SumWith(matrix2, null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void MatricesAdditionDifferentAddendsSizesTest()
        {
            GeneralMatrix<int> matrix1 = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            GeneralMatrix<int> matrix2 = new GeneralMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            matrix1.SumWith(matrix2, AdditionMethod);
        }

        [TestMethod()]
        public void GeneralMatrixAdditionTest()
        {
            GeneralMatrix<int> matrix1 = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            GeneralMatrix<int> matrix2 = new GeneralMatrix<int>(new int[3, 4] { { 1, 2, 3, 4 }, { 2, 1, 2, 4 }, { 3, 2, 1, 4 } });
            matrix1.SumWith(matrix2, AdditionMethod);

            Assert.AreEqual<int>(2, matrix1[0, 0]);
            Assert.AreEqual<int>(4, matrix1[0, 1]);
            Assert.AreEqual<int>(6, matrix1[0, 2]);
            Assert.AreEqual<int>(8, matrix1[0, 3]);
            Assert.AreEqual<int>(4, matrix1[1, 0]);
            Assert.AreEqual<int>(2, matrix1[1, 1]);
            Assert.AreEqual<int>(4, matrix1[1, 2]);
            Assert.AreEqual<int>(8, matrix1[1, 3]);
            Assert.AreEqual<int>(6, matrix1[2, 0]);
            Assert.AreEqual<int>(4, matrix1[2, 1]);
            Assert.AreEqual<int>(2, matrix1[2, 2]);
            Assert.AreEqual<int>(8, matrix1[2, 3]);            
        }

        [TestMethod()]
        public void SquareMatrixAdditionTest()
        {
            GeneralMatrix<int> matrix1 = new SquareMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            GeneralMatrix<int> matrix2 = new SquareMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            matrix1.SumWith(matrix2, AdditionMethod);

            Assert.AreEqual<int>(2, matrix1[0, 0]);
            Assert.AreEqual<int>(4, matrix1[0, 1]);
            Assert.AreEqual<int>(6, matrix1[0, 2]);
            Assert.AreEqual<int>(4, matrix1[1, 0]);
            Assert.AreEqual<int>(2, matrix1[1, 1]);
            Assert.AreEqual<int>(4, matrix1[1, 2]);
            Assert.AreEqual<int>(6, matrix1[2, 0]);
            Assert.AreEqual<int>(4, matrix1[2, 1]);
            Assert.AreEqual<int>(2, matrix1[2, 2]);
        }

        [TestMethod()]
        public void SymmetricMatrixAdditionTest()
        {
            GeneralMatrix<int> matrix1 = new SymmetricalMatrix<int>(new int[3, 3] { { 1, 2, 3 }, { 2, 1, 2 }, { 3, 2, 1 } });
            GeneralMatrix<int> matrix2 = new SquareMatrix<int>(new int[3, 3] { { 2, 7, 3 }, { 4, 0, 2 }, { 3, 6, 2 } });
            matrix1.SumWith(matrix2, AdditionMethod);

            Assert.AreEqual<int>(3, matrix1[0, 0]);
            Assert.AreEqual<int>(13, matrix1[0, 1]);
            Assert.AreEqual<int>(9, matrix1[0, 2]);
            Assert.AreEqual<int>(13, matrix1[1, 0]);
            Assert.AreEqual<int>(1, matrix1[1, 1]);
            Assert.AreEqual<int>(10, matrix1[1, 2]);
            Assert.AreEqual<int>(9, matrix1[2, 0]);
            Assert.AreEqual<int>(10, matrix1[2, 1]);
            Assert.AreEqual<int>(3, matrix1[2, 2]);
        }

        [TestMethod()]
        public void DiagonalMatrixAdditionTest()
        {
            GeneralMatrix<int> matrix1 = new DiagonalMatrix<int>(new int[3, 3] { { 1, 0, 0 }, { 0, 2, 0 }, { 0, 0, 3 } });
            GeneralMatrix<int> matrix2 = new SquareMatrix<int>(new int[3, 3] { { 2, 7, 3 }, { 4, 0, 2 }, { 3, 6, 2 } });
            matrix1.SumWith(matrix2, AdditionMethod);

            Assert.AreEqual<int>(3, matrix1[0, 0]);
            Assert.AreEqual<int>(0, matrix1[0, 1]);
            Assert.AreEqual<int>(0, matrix1[0, 2]);
            Assert.AreEqual<int>(0, matrix1[1, 0]);
            Assert.AreEqual<int>(2, matrix1[1, 1]);
            Assert.AreEqual<int>(0, matrix1[1, 2]);
            Assert.AreEqual<int>(0, matrix1[2, 0]);
            Assert.AreEqual<int>(0, matrix1[2, 1]);
            Assert.AreEqual<int>(5, matrix1[2, 2]);
        }

        #endregion 

        #region Tests helpers

        static int AdditionMethod(int x, int y)
        {
            return x + y;
        }

        static void Subscribe(GeneralMatrix<int> matrix)
        {
            matrix.ElementChanged += ElementChanged;
        }

        static void Unsubscribe(GeneralMatrix<int> matrix)
        {
            matrix.ElementChanged -= ElementChanged;
        }

        static void ElementChanged(object sender, ElementChangedEventArgs<int> e)
        {
            message = e.Message;
        }
        #endregion
    }
}
