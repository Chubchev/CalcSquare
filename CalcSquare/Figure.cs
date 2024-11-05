namespace CalcSquare
{
    public class Figure
    {
        public virtual string Message { get; set; }
        public virtual double Square { get; set; }
    }
    public class Circle : Figure 
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get; set; }
        public override double Square
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }
    }
    public class Triangle : Figure
    {
        public Triangle(double a, double c, double b)
        {
            A = a;
            B = b;
            C = c;
        }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public override double Square
        {
            get
            {   //по трем сторонам: S = √p · (p — a)(p — b)(p — c),
                double p = (A + B + C)/2.0; 
                return (Math.Sqrt(p * (p - A) * (p - B) * (p - C)));
            }
        }
        public override string Message
        {
            get
            {
                //прямоугольный ли?
                return A != 0 && B != 0 && C != 0 && (Math.Pow(A, 2) == Math.Pow(B, 2) + Math.Pow(C, 2) ||
                                                      Math.Pow(B, 2) == Math.Pow(A, 2) + Math.Pow(C, 2) ||
                                                      Math.Pow(C, 2) == Math.Pow(B, 2) + Math.Pow(A, 2)) ? 
                   "Заданный треугольник является прямоугольным" : "";
            }               
        }
    }
}
