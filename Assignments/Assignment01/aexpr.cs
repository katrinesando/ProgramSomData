using System;
using System.Collections.Generic;

//namespace aexpr;

class aexpr
{
    public void Main(String[] args)
    {
        AExpr e = new Add{Exp1 = new CSTI{I = 17}, Exp2 = new Var{Name = "z"}};
        //1.4(ii)
        AExpr e1 = new Sub{Exp1 = new Add{Exp1 = new CSTI{I = 21}, Exp2 = new CSTI{I = 18}}, Exp2 = new Var{Name = "x"}};
        AExpr e2 = new Mul{Exp1 = new Sub{Exp1 = new Var{Name = "y"}, Exp2 = new CSTI{I = 70}}, Exp2 = new CSTI{I = 7}};
        AExpr e3 = new Add{Exp1 = new CSTI{I = 17}, Exp2 = 
                new Add{Exp1 = new CSTI{I = 21},Exp2 = 
                new Mul{Exp1 = new CSTI{I =3}, Exp2 = new Var{Name= "w"}}}};
        Console.WriteLine(e.ToString());
        Console.WriteLine(e1.ToString());
        Console.WriteLine(e2.ToString());
        Console.WriteLine(e3.ToString());
    }
}

abstract class AExpr
{
    public abstract AExpr simplify();
    public abstract int eval( List<Tuple<string,int>> env);
}

class CSTI : AExpr
{
    public int I { get; init; }

    public override AExpr simplify()
    {
        return this;
    }

    public override int eval(List<Tuple<string,int>> env)
    {
        return I;
    }

    public override string ToString()
    {
        return I.ToString();
    }
}

class Var : AExpr
{
    public string Name { get; init; }

    public override AExpr simplify()
    {
        return this;
    }

    public override int eval(List<Tuple<string,int>> env)
    {
        return 0;
    }

    public override string ToString()
    {
        return Name;
    }
}

abstract class Binop : AExpr
{
    public AExpr Exp1 { get; init; }
    public AExpr Exp2 { get; init; }

    public abstract override int eval(List<Tuple<string,int>> env);
}

class Add : Binop
{
    public override AExpr simplify()
    {
        if (Exp2.Equals(new CSTI{I = 0}))
        {
            return Exp1;
        } 
        if (Exp1.Equals(new CSTI { I = 0 }))
        {
            return Exp2;
        }

        return new Add{Exp1 = Exp1.simplify(),Exp2 = Exp2.simplify()}.simplify();
    }

    public override int eval(List<Tuple<string, int>> env)
    {
        return Exp1.eval(env) + Exp2.eval(env);
    }

    public override string ToString()
    {
        return $"({Exp1} + {Exp2})";
    }
}
class Sub : Binop
{
    public override AExpr simplify()
    {
        if (Exp2.Equals(new CSTI{I = 0}))
        {
            return Exp1;
        } 
        if (Exp1.Equals(Exp2))
        {
            return new CSTI{I= 0};
        }

        return new Sub{Exp1 = Exp1.simplify(),Exp2 = Exp2.simplify()}.simplify();
    }

    public override int eval(List<Tuple<string, int>> env)
    {
        return Exp1.eval(env) - Exp2.eval(env);
    }
    public override string ToString()
    {
        return $"({Exp1} - {Exp2})";
    }
}
class Mul : Binop
{
    public override AExpr simplify()
    {
        if (Exp2.Equals(new CSTI{I = 0}) || Exp1.Equals(new CSTI { I = 0 }))
        {
            return new CSTI{I= 0};
        } 
        if(Exp2.Equals(new CSTI{I = 1}))
        {
            return Exp1;
        } 
        if (Exp1.Equals(new CSTI { I = 1}))
        {
            return Exp2;
        }
        return new Mul{Exp1 = Exp1.simplify(),Exp2 = Exp2.simplify()}.simplify();
    }

    public override int eval(List<Tuple<string, int>> env)
    {
        return Exp1.eval(env) * Exp2.eval(env);
    }
    public override string ToString()
    {
        return $"({Exp1} * {Exp2})";
    }
}
