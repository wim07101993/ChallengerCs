namespace Math.Core.TestData
{
    public class CalculatorMockData
    {
        public PrimeExample FirstPrime { get; set; } = new PrimeExample { PrimeNumber = 1, Prime = 2 };
        public PrimeExample SecondPrime { get; set; } = new PrimeExample { PrimeNumber = 2, Prime = 3 };
        public PrimeExample ThirdPrime { get; set; } = new PrimeExample { PrimeNumber = 3, Prime = 5 };
        public PrimeExample FourthPrime { get; set; } = new PrimeExample { PrimeNumber = 4, Prime = 7 };
        public PrimeExample TwentiethPrime { get; set; } = new PrimeExample { PrimeNumber = 20, Prime = 71 };
        public PrimeExample EightyThirdPrime { get; set; } = new PrimeExample { PrimeNumber = 83, Prime = 431 };
        public PrimeExample NineHundrethAndSeventySixthPrime { get; set; } = new PrimeExample { PrimeNumber = 976, Prime = 7691 };

        public FibonacciExample Fibonacci { get; set; } = new FibonacciExample();

        public DegreesExample SineMinus50 { get; set; } = new DegreesExample
        {
            Degrees = -50,
            Radians = -.872664626,
            Sine = -.766044443,
            Cosine = .64278761,
            Tan = -1.191753593,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees0 { get; set; } = new DegreesExample
        {
            Degrees = 0,
            Radians = 0,
            Sine = 0.0,
            Cosine = 0.0,
            Tan = 1,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees20 { get; set; } = new DegreesExample
        {
            Degrees = 20,
            Radians = 0.34906585,
            Sine = 0.342020143,
            Cosine = 0.939692621,
            Tan = 0.363970234,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees30 { get; set; } = new DegreesExample
        {
            Degrees = 30,
            Radians = 0.523598776,
            Sine = 0.5,
            Cosine = 0.866025404,
            Tan = 0.577350269,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees60 { get; set; } = new DegreesExample
        {
            Degrees = 60,
            Radians = 1.047197551,
            Sine = 0.866025404,
            Cosine = 0.5,
            Tan = 1.732050808,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees80 { get; set; } = new DegreesExample
        {
            Degrees = 80,
            Radians = 1.396263402,
            Sine = 0.984807753,
            Cosine = 0.173648178,
            Tan = 5.67128182,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees90 { get; set; } = new DegreesExample
        {
            Degrees = 90,
            Radians = 1.570796327,
            Sine = 1,
            Cosine = 0.0,
            Tan = double.PositiveInfinity,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees100 { get; set; } = new DegreesExample
        {
            Degrees = 100,
            Radians = 1.745329252,
            Sine = 0.984807753,
            Cosine = -0.173648178,
            Tan = -5.67128182,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees220 { get; set; } = new DegreesExample
        {
            Degrees = 220,
            Radians = 3.839724354,
            Sine = -0.64278761,
            Cosine = -0.766044443,
            Tan = 0.839099631,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees240 { get; set; } = new DegreesExample
        {
            Degrees = 240,
            Radians = 4.188790205,
            Sine = -0.866025404,
            Cosine = 0.5,
            Tan = 1.732050808,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees260 { get; set; } = new DegreesExample
        {
            Degrees = 260,
            Radians = 4.537856055,
            Sine = -0.984807753,
            Cosine = -0.173648178,
            Tan = 5.67128182,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees340 { get; set; } = new DegreesExample
        {
            Degrees = 340,
            Radians = 5.934119457,
            Sine = -0.342020143,
            Cosine = 0.939692621,
            Tan = -0.363970234,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees360 { get; set; } = new DegreesExample
        {
            Degrees = 360,
            Radians = 6.283185307,
            Sine = 0,
            Cosine = 1,
            Tan = 0.0,
            Accuracy = 0.000001
        };

        public DegreesExample Degrees400 { get; set; } = new DegreesExample
        {
            Degrees = 400,
            Radians = 6.981317008,
            Sine = 0.64278761,
            Cosine = 0.766044443,
            Tan = 0.839099631,
            Accuracy = 0.000001
        };

        public FactorialExample Factorial1 { get; set; } = new FactorialExample { Input = 1, Output = 1 };
        public FactorialExample Factorial2 { get; set; } = new FactorialExample { Input = 1, Output = 2 };
        public FactorialExample Factorial3 { get; set; } = new FactorialExample { Input = 1, Output = 6 };
        public FactorialExample Factorial4 { get; set; } = new FactorialExample { Input = 1, Output = 24 };
        public FactorialExample Factorial5 { get; set; } = new FactorialExample { Input = 1, Output = 120 };
        public FactorialExample Factorial10 { get; set; } = new FactorialExample { Input = 1, Output = 3628800 };
        public FactorialExample Factorial20 { get; set; } = new FactorialExample { Input = 1, Output = 2432902008176640000 };

        public I2I1 GCF1 { get; set; } = new I2I1 { Input1 = 12, Input2 = 6, Output = 6 };
        public I2I1 GCF2 { get; set; } = new I2I1 { Input1 = 12, Input2 = 90, Output = 6 };
        public I2I1 GCF3 { get; set; } = new I2I1 { Input1 = 10, Input2 = 45, Output = 9 };

        public I2I1 LCM1 { get; set; } = new I2I1 { Input1 = 12, Input2 = 6, Output = 12 };
        public I2I1 LCM2 { get; set; } = new I2I1 { Input1 = 12, Input2 = 90, Output = 180 };
        public I2I1 LCM3 { get; set; } = new I2I1 { Input1 = 10, Input2 = 45, Output = 90 };
    }
}
