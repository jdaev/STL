namespace Base
{
    public enum STLColor
    {
        Red,
        Green,
        Blue,
        Yellow,
        Cyan,
        Magenta,
    }

    public class ShootableColor
    {
        private STLColor _color;
        private STLColor[] _weaknesses;

        public ShootableColor(STLColor color, STLColor[] weaknesses)
        {
            _color = color;
            _weaknesses = weaknesses;
        }
    }
}