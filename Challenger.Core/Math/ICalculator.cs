using System.Collections.Generic;

namespace Challenger.Core.Math
{
    public interface ICalculator
    {
        /// <summary>Calculates the next prime number after number <see cref="i" />.</summary>
        /// <param name="i">The lower limit.</param>
        /// <returns>The next prime number.</returns>
        int NextPrime(int i);

        /// <summary>Generates the fibonacci numbers. (An infinite series)</summary>
        /// <returns>An infinite series of fibbonacci numbers.</returns>
        IEnumerable<int> Fibonacci();

        /// <summary>Calculates the sin of an angle.</summary>
        /// <param name="angle">The angle in degrees to calculate the sin of.</param>
        /// <returns>The sin value</returns>
        double Sin(double angle);

        /// <summary>Calculates the cos of an angle.</summary>
        /// <param name="angle">The angle in degrees to calculate the cos of.</param>
        /// <returns>The cos value</returns>
        double Cos(double angle);

        /// <summary>Calculates the tan of an angle.</summary>
        /// <param name="angle">The angle in degrees to calculate the tang of.</param>
        /// <returns>The tan value</returns>
        double Tan(double angle);

        /// <summary>Converts an angle in degrees to radians.</summary>
        /// <param name="deg">The degrees to convert.</param>
        /// <returns>The radians.</returns>
        double DegToRad(double deg);

        /// <summary>Converts an angle in radians to degress.</summary>
        /// <param name="rad">The radians to convert.</param>
        /// <returns>The degrees.</returns>
        double RadToDeg(double rad);

        /// <summary>Calculates the factorial of a number</summary>
        /// <param name="i">The input number</param>
        /// <returns>The factorial of the input number.</returns>
        long Factorial(int i);

        /// <summary>Calculates the greatest common denominator.</summary>
        /// <param name="num1">The first number.</param>
        /// <param name="num2">The second number</param>
        /// <returns>The result</returns>
        int GreatestCommonDenominator(int num1, int num2);

        /// <summary>Calculates the lowest commom multiple.</summary>
        /// <param name="num1">The first number.</param>
        /// <param name="num2">The second number</param>
        /// <returns>The result</returns>
        int LowestCommonMultiple(int num1, int num2);
    }
}
