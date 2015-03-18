using System;

namespace MobilePhone
{
    class Display
    {
        private uint numberOfColors;
        //pixel dimensions, not physical
        private uint width;
        private uint height;

        //default (paramless) constructor
        public Display() : this(0, 0)
        { }

        //constructor for width and height
        public Display(uint width, uint height) : this(width, height, 0)
        { }

        //full constructor for width, height and num of colors
        public Display(uint width, uint height, uint numberOfColors)
        {
            this.Width = width;
            this.Height = height;
            this.NumberOfColors = numberOfColors;
        }

        //read-write
        public uint NumberOfColors
        {
            get { return this.numberOfColors; }
            set { this.numberOfColors = value; }    //type limit to non-negative value
        }

        //read-write
        public uint Width
        {
            get { return this.width; }
            set { this.width = value; }             //type limit to non-negative value
        }

        //read-write
        public uint Height
        {
            get { return this.height; }
            set { this.height = value; }            //type limit to non-negative value
        }

        //read-only
        public ulong PixelArea
        {
            //maximum = (uint.MaxValue * uint.MaxValue) < ulong.MaxValue => maximum is compatible with ulong
            get { return (ulong)this.height * (ulong)this.width; }
        }
    }

    public enum ColorCount
    {
        NA,
        Monochrome = 1 << 1,            //2 (1-bit) color
        Quad = 1 << 2,                  //4 (2-bit) color
        Hex = 1 << 4,                   //16 (4-bit) color
        HundredsOfColors = 1 << 8,      //256 (8-bit) color (paletted/indexed)
        ThousandsOfColors = 1 << 16,    //65K (16-bit) color, aka. High Color
        MillionsOfColors = 1 << 24,     //16M (24-bit) color, aka. True Color
        AlphaColor = UInt16.MaxValue    //4G  (32-bit) color, aka. Alpha Color
    }
}
