using System;
using System.Globalization;

public class Complex
{
    public double Img { get; private set; }
    public double Real { get; private set; }

    public double this[int n]
    {
        get => n == 0 ? Img : Real;

        set
        {
            if (n == 0)
                this.Img = value;
            else
                this.Real = value;
        }

    }


    public double this[string p]
    {
        get => p.ToLower().Equals("img") ? Img : Real;

        set
        {
            if (p.ToLower().Equals("img"))
                this.Img = value;
            else
                this.Real = value;
        }

    }
    public Complex(double img, double real)
    {
        this.Img = img;
        this.Real = real;
    }

    public static Complex operator +(Complex c1, Complex c2) =>
        new Complex(c1.Img + c2.Img, c1.Real + c2.Real);

    public static Complex operator +(Complex c1, double d) =>
        new Complex(c1.Img, c1.Real + d);

    public static Complex operator *(Complex c1, double d) =>
        new Complex(c1.Img * d, c1.Real * d);

    public static Complex operator *(Complex c1, Complex c2) =>
        new Complex((c1.Img * c2.Real) + (c1.Real*c2.Img),(c1.Real * c2.Real) - (c1.Img * c2.Img));

    public static Complex operator ++(Complex c)
    {
        c.Real++;
        return c;
    }

    public static implicit operator Complex(double from) =>
        new Complex(0, from);

    // 5.5i+4
    public static implicit operator Complex(string str)
    {
        var toks = str.Split('+');
        var img = toks[0].Trim(new char[] { ' ', 'i' });
        var real = toks[1].Trim();
        return new Complex(double.Parse(img, CultureInfo.InvariantCulture), double.Parse(real, CultureInfo.InvariantCulture));
    }

    public static explicit operator double(Complex c) => c.Real;

    public override bool Equals(object obj)
    {
        Complex s = obj as Complex;
        return s == this; 
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return this.Real.ToString() + "+" + this.Img.ToString() + "i";
    }

    public static explicit operator string(Complex c) => c.Real.ToString() + "+" + c.Img.ToString() + "i";

    public static bool operator ==(Complex lhs, Complex rhs)
    {
        return lhs.Img == rhs.Img && lhs.Real == rhs.Real;
    }

    public static bool operator !=(Complex lhs, Complex rhs)
    {
        return !(lhs == rhs);
    }

}