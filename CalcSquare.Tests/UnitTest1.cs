namespace CalcSquare.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GetCircleSquare()
        {
            // Arrange
            double Radius = 1;
            // Act
            var figure1 = new CalcSquare.Circle(Radius);
            var figure2 = new CalcSquare.Circle(Radius*2);
            var figure3 = new CalcSquare.Circle(Radius * 3);
            // Assert
            Assert.Equal(figure1.Square, Math.PI * Radius * Radius);
            Assert.Equal(figure2.Square, Math.PI * Radius * Radius*4);
            Assert.Equal(figure3.Square, Math.PI * Radius * Radius * 9);
        }
        [Fact]
        public void GetTriangleSquare()
        {
            // Arrange
            double A = 1;
            double B = 1;
            double C = 1;
            double p = (A + B + C)/2.0;
            // Act
            var figure1 = new CalcSquare.Triangle(A, B, C);
            // Assert
            Assert.Equal(figure1.Square, Math.Sqrt(p * (p - A) * (p - B) * (p - C)));
        }
        [Fact]
        public void IsRightTriangle()
        {
            // Arrange
            double A = 3;
            double B = 4;
            double C = 5;
            // Act
            var figure1 = new CalcSquare.Triangle(A, B, C);
            // Assert
            Assert.Equal(figure1.Message, "Заданный треугольник является прямоугольным");
        }
        [Fact]
        public void IsNotRightTriangle()
        {
            // Arrange
            double A = 1;
            double B = 4;
            double C = 5;
            // Act
            var figure1 = new CalcSquare.Triangle(A, B, C);
            // Assert
            Assert.Equal(figure1.Message, "");
        }
    }
}