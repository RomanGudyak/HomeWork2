using System;

namespace Demo.Operators
{
    class Fract
    {
        int _ch;
        int _zn;
        public int Chislitel
        {
            get => _ch; set => _ch = value;
        }
        public int Znamenatel
        {
            get => _zn;
            set
            {
                if (value == 0) throw new DivideByZeroException();
                _zn = value;
            }
        }

        public Fract(int chislitel = 0, int znamenatel = 1)
        {
            if (znamenatel == 0) throw new DivideByZeroException();
            _ch = chislitel;
            _zn = znamenatel;
        }
        public override string ToString()
        {
            return _ch > _zn ? $"{_ch / _zn}+{_ch % _zn}/{_zn}" : $"{_ch}/{_zn}";
        }

        public static Fract operator +(Fract a)
        {
            return new Fract(a._ch, a._zn);
        }
        public static Fract operator -(Fract a)
        {
            return new Fract(-a._ch, a._zn);
        }
        public static Fract operator +(Fract a, Fract b)
        {
            return new Fract(a._ch * b._zn + b._ch * a._zn, a._zn * b._zn);
        }
        public static Fract operator -(Fract a, Fract b)
        {
            return new Fract(a._ch * b._zn - b._ch * a._zn, a._zn * b._zn);
        }
        public static Fract operator *(Fract a, Fract b)
        {
            return new Fract(a._ch * b._ch, a._zn * b._zn);
        }
        public static Fract operator /(Fract a, Fract b)
        {
            return new Fract(a._ch * b._zn, a._ch * b._zn);
        }
        public static Fract operator +(Fract a, int x)
        {
            return new Fract(a._ch + x * a._zn, a._zn);
        }
        public static bool operator ==(Fract a, Fract b)
        {
            return a._ch * b._zn == b._ch * a._zn;
        }
        public static bool operator !=(Fract a, Fract b)
        {
            return a._ch * b._zn != b._ch * a._zn;
        }
        public static bool operator false(Fract a)
        {
            return a._ch != 0;
        }
        public static bool operator true(Fract a)
        {
            return a._ch == 0;
        }
        /*public static implicit operator double(Fract a)
        {
            return (double)a._ch / a._zn;
        }
        public static explicit operator int(Fract a)
        {
            return a._ch / a._zn;
        }*/
        public static Fract operator ++(Fract a)
        {
            return new Fract (a._ch + a._zn, a._zn);
        }

        public static Fract operator --(Fract a)
        {
            return new Fract(a._ch - a._zn, a._zn);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fract a = new Fract(1, 2);
            Fract b = new Fract(10, 10);
            Fract d = new Fract(3, 4);
            Fract c = d--;
            Console.WriteLine(c);
            Console.WriteLine(a);
            Console.WriteLine(b);


        }
    }
}
