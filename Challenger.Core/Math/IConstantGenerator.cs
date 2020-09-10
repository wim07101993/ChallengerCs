namespace Challenger.Core.Math
{
    public interface IConstantGenerator
    {
        /// <summary>Calculates the methematicl constant PI.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>The mathematical constant PI.</returns>
        double Pi(int decimals);

        /// <summary>Calculates euler's number e.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>Euler's number e.</returns>
        double E(int decimals);

        /// <summary>Calculates the root of 2.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>The root of 2.</returns>
        double Root2(int decimals);

        /// <summary>Calculates the golden ratio.</summary>
        /// <param name="decimals">The number of decimals that should be correct.</param>
        /// <returns>The golden ratio.</returns>
        double GoldenRatio(int decimals);
    }
}
