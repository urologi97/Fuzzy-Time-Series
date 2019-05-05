using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MembershipSegi3
{
    private double corA, corB, corC, alphaA, alphaB, alphaC;

    public MembershipSegi3()
    {

    }

    public MembershipSegi3(double a, double b, double c)
    {
        corA = a;
        corB = b;
        corC = c;
        alphaA = 0;
        alphaB = 1;
        alphaC = 0;
    }

    public MembershipSegi3(double a, double b, double c, double alphaA, double alphaB, double alphaC)
    {
        corA = a;
        corB = b;
        corC = c;
        this.alphaA = alphaA;
        this.alphaB = alphaB;
        this.alphaC = alphaC;
    }

    public double getCorA { get { return corA; } set { corA = value; } }
    public double getCorB { get { return corB; } set { corB = value; } }
    public double getCorC { get { return corC; } set { corC = value; } }
    public double getAlphaA { get { return alphaA; } set { alphaA = value; } }
    public double getAlphaB { get { return alphaB; } set { alphaB = value; } }
    public double getAlphaC { get { return alphaC; } set { alphaC = value; } }


    public double getGradien1()
    {
        double gradien;
        gradien = (alphaA - alphaB) / (corA - corB);
        return gradien;
    }

    public double getGradien2()
    {
        double gradien;
        gradien = (alphaB - alphaC) / (corB - corC);
        return gradien;
    }

    public bool isBerpotongan(MembershipSegi3 a, MembershipSegi3 b)
    {
        if (a.getCorC > b.getCorA)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public double[] berpotonganPada(MembershipSegi3 a, MembershipSegi3 b)
    {
        double[] potongan = new double[2];
        double titikX, titikY, x1a, y1a, x1b, y1b, ma, mb;

        x1a = a.getCorC;
        y1a = a.getAlphaC;
        x1b = b.getCorA;
        y1b = b.getAlphaA;
        ma = a.getGradien2();
        mb = b.getGradien1();

        if (isBerpotongan(a, b))
        {
            titikX = ((-1 * mb * x1b) + y1b + (ma * x1a) + y1a) / (ma - mb);
            titikY = (b.getGradien1() * titikX) - ((b.getGradien1()) * x1b) + y1b;
            potongan[0] = titikX;
            potongan[1] = titikY;
        }
        return potongan;
    }

    public double[] alphaCut(double alpha)
    {
        double[] titikx = new double[2];
        double titikX1, titikX2;

        if (alpha == 0)
        {
            titikx[0] = corA;
            titikx[1] = corC;
            return titikx;
        }

        if (alphaA == 1)
        {
            titikX1 = (alpha - alphaA + ((this.getGradien1()) * corA)) / this.getGradien1();
            titikx[0] = corA;
            titikx[1] = titikX1;
            return titikx;
        }

        if (alphaC == 1)
        {
            titikX1 = (alpha - alphaC + ((this.getGradien2()) * corC)) / this.getGradien2();
            titikx[0] = titikX1;
            titikx[1] = corC;
            return titikx;
        }

        titikX1 = (alpha - alphaA + ((this.getGradien1()) * corA)) / this.getGradien1();
        titikX2 = (alpha - alphaC + ((this.getGradien2()) * corC)) / this.getGradien2();

        titikx[0] = titikX1;
        titikx[1] = titikX2;

        return titikx;
    }

    public double getYfromX(double x)
    {
        double result=0;
        if (x < corB && x > corA)
        {
            result = (this.getGradien1() * x) - ((this.getGradien1()) * corA) + alphaA;
            return result;
        }
        if (x > corB && x < corC )
        {
            result = (this.getGradien2() * x) - ((this.getGradien2()) * corC) + alphaC;
            return result;
        }
        if (x == corB)
        {
            result = alphaB;
            return result;
        }
        if ((alphaA == 1 && x < corB) || (alphaC == 1 && x > corB))
        {
            result = 1;
            return result;
        }
        else
        {
            result = 0;
            return result;
        }
    }

    public bool isAnggota(double x)
    {
        if (x >= corA && x <= corC)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}