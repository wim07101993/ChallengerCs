namespace Challenger.Core.Math
{
    public interface IConstantGenerator
    {
        /// <summary>Calculates the methematicl constant PI.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>The mathematical constant PI.</returns>
        decimal Pi(int decimals);

        /// <summary>Calculates euler's number e.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>Euler's number e.</returns>
        decimal E(int decimals);

        /// <summary>Calculates the root of 2.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>The root of 2.</returns>
        decimal Root2(int decimals);

        /// <summary>Calculates the golden ratio.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>The golden ratio.</returns>
        decimal GoldenRatio(int decimals);
    }
}
