using System.Numerics;


namespace ImageProcessorCore.Tests
{
    using Xunit;


    /// <summary> 
    /// Tests the <see cref="Color"/> struct. 
    /// </summary> 
    public class ColorTests
    {
        /// <summary> 
        /// Tests the equality operators for equality. 
        /// </summary> 
        [Fact]
        public void AreEqual()
        {
            Color color1 = new Color(0, 0, 0);
            Color color2 = new Color(0, 0, 0, 1);
            Color color3 = new Color("#000");
            Color color4 = new Color("#000000");
            Color color5 = new Color("#FF000000");


            Assert.Equal(color1, color2);
            Assert.Equal(color1, color3);
            Assert.Equal(color1, color4);
            Assert.Equal(color1, color5);
        }


        /// <summary> 
        /// Tests the equality operators for inequality. 
        /// </summary> 
        [Fact]
        public void AreNotEqual()
        {
            Color color1 = new Color(255, 0, 0, 255);
            Color color2 = new Color(0, 0, 0, 255);
            Color color3 = new Color("#000");
            Color color4 = new Color("#000000");
            Color color5 = new Color("#FF000000");


            Assert.NotEqual(color1, color2);
            Assert.NotEqual(color1, color3);
            Assert.NotEqual(color1, color4);
            Assert.NotEqual(color1, color5);
        }

    }
}