using System;
using cg22_model.Models.SignatureReadersStrategies;

namespace cg22_model.Models
{
    /// <summary>
    /// Static class for matching signature and interpreting strategy
    /// </summary>
    internal static class SignatureChecker
    {
        private const Int16 PPM = 0x5036; // TODO Check if it's correct
        private const String PPMString = "P6";

        private const Int16 PGM = 0x5035; // TODO Check if it's correct
        private const String PGMString = "P5";

        /// <summary>
        /// Checks signature and if supported, returns strategy for this file signature
        /// </summary>
        /// <param name="signature"> File signature as Int16 </param>
        /// <returns> Strategy for this file </returns>
        public static IFormat CheckSignature(Int16 signature)
        {
            switch (signature)
            {
                case PPM:
                    return new PPM();
                    break;
                case PGM:
                    return new PGM();
                    break;
                default:
                    return new FormatDoesntSupported();
            }
        }

        /// <summary>
        /// Checks signature and if supported, returns strategy for this file signature
        /// </summary>
        /// <param name="signature"> File signature as string </param>
        /// <returns> Strategy for this file </returns>
        public static IFormat CheckSignature(string signature)
        {
            switch (signature)
            {
                case PPMString:
                    return new PPM();
                    break;
                case PGMString:
                    return new PGM();
                    break;
                default:
                    return new FormatDoesntSupported();
            }
        }
    }
}