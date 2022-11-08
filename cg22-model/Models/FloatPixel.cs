namespace cg22_model.Models
{
    /// <summary>
    /// Represents pixel in any color space, that has 3 streams
    /// </summary>
    public class FloatPixel
    {
        private float _component1;
        private float _component2;
        private float _component3;
        /// <summary>
        /// constructor for pixel
        /// </summary>
        /// <param name="component1">first component</param>
        /// <param name="component2">second component</param>
        /// <param name="component3">third component</param>
        public FloatPixel(float component1, float component2, float component3)
        {
            _component1 = component1;
            _component2 = component2;
            _component3 = component3;
        }
        /// <summary>
        /// Base constructor for pixel
        /// </summary>
        public FloatPixel()
        {
            _component1 = 0.0f;
            _component2 = 0.0f;
            _component3 = 0.0f;
        }

        /// <summary>
        /// Get Float value, representing 1-st component
        /// </summary>
        public float Component1
        {
            get => _component1;
            set => _component1 = value;
        }

        /// <summary>
        /// Get Float value, representing 2-nd component
        /// </summary>
        public float Component2
        {
            get => _component2;
            set => _component2 = value;
        }

        /// <summary>
        /// Get Float value, representing 3-rd component
        /// </summary>
        public float Component3
        {
            get => _component3;
            set => _component3 = value;
        }
    }
}
