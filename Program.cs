using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

public class Calc 
{
    
    static float Calculate(string inExp)
    {
        inExp = '(' + inExp + ')';
        string subResult = "";
        while (inExp.IndexOf('(')!=-1)
        {
            int openBrack = inExp.LastIndexOf('(');
            int closeBrack = inExp.IndexOf(')', openBrack);
            
            string sub = inExp.Substring(openBrack + 1, closeBrack - 1 - openBrack);
            string sub1 = inExp.Substring(openBrack, closeBrack - openBrack + 1);
      
            subResult = StringToValue(sub).ToString();
            
            inExp = inExp.Replace(sub1, subResult);
            
        }

        return float.Parse(inExp);
    }
    static void Main()
    {
        while(true){
            string expression = Console.ReadLine();
            Console.WriteLine(Calculate(expression));
        }
        //"2,152*-25,0+2,521*-257,2*-25,5+2,521*-257,2*-25,5+(2,521*-257,2*-25,5)" 
        //"0-2*25+2*256*25"
    }
    
    public static float StrCalc(ref string inStr, float result)
    {
        string cropStr = inStr.Substring(1, inStr.Length - 1);
                
        int indOperation = cropStr.IndexOfAny(new []{'-', '+', '*', '/', '№', '~'});
        int first2 = indOperation == -1 ? cropStr.Length : indOperation;
                
        inStr = cropStr.Substring(first2, cropStr.Length - first2);
        cropStr = cropStr.Substring(0, first2);

        return float.Parse(cropStr);
    }
    static string CalcSergment(ref float result, string inStr)
    {
        switch (inStr.First(c => (c == '+' || c == '-' || c == '*' || c == '/'|| c == '№'|| c == '~')))
        {
            case '+': result += StrCalc(ref inStr, result); break;
            case '-': result -= StrCalc(ref inStr, result); break;
            case '*': result *= StrCalc(ref inStr, result); break;
            case '/': result /= StrCalc(ref inStr, result); break; 
            case '~': result = -(result * StrCalc(ref inStr, result)); break;
            case '№': result = -(result / StrCalc(ref inStr, result)); break;
        }

        return inStr;
    }

    static void CleanExpression(ref string inStr, char operat)
    {
        string[] splitStr = inStr.Split(new [] { '+' , '-', '*', '/', '№', '~'});
        string plus2 = "";
        
        string inStr2 = inStr;
        int i = 0;
        while (splitStr.Length - 1 > i)
        {
            plus2 += inStr2.First(c => (c == '+' || c == '-' || c == '*' || c == '/'|| c == '№'|| c == '~'));
            inStr2 = inStr2.Remove(inStr2.IndexOfAny(new[] { '+', '-', '*', '/', '№', '~'}), 1);
            i++;
        }
            
        string newSt = "";
            
        int fs = plus2.IndexOf(operat);
        newSt += splitStr[fs];
        char ft = operat;
        int ind = fs;
        while (ft == operat)
        {
            ft = plus2[ind];

            ind++;
            if (ft == operat)
                newSt += operat + splitStr[ind];
        }

        float result2 = StringToValue(newSt, false);
        inStr = inStr.Replace(newSt, result2.ToString());
    }
    static float StringToValue(string inStr, bool rec = true)
    {
        
        inStr = inStr.Replace("*-", "~");
        inStr = inStr.Replace("/-", "№");
        
        inStr = inStr[0] == '-' ? ("0" + inStr + "+0") : ("0+" + inStr + "+0");
        
        string[] plus = inStr.Split(new [] { '+' , '-', '*', '/', '№', '~'});
        float result = 0.0f;
        
        if (rec)
        {
            while(inStr.IndexOf('№') != -1)
                CleanExpression(ref inStr, '№');
            
            while(inStr.IndexOf('~') != -1)
                CleanExpression(ref inStr, '~');
            
            while(inStr.IndexOf('*') != -1)
                CleanExpression(ref inStr, '*');
            
            while(inStr.IndexOf('/') != -1)
                CleanExpression(ref inStr, '/');
        }

        
        result += float.Parse(plus[0], NumberStyles.Float);
        
        inStr = inStr.Substring(plus[0].Length, inStr.Length - plus[0].Length);

        inStr = inStr.Replace("--", "+");
        inStr = inStr.Replace("+-", "-");
        inStr = inStr.Replace("-+", "-");
        inStr = inStr.Replace("++", "+");
        
        while (inStr.Length > 0)
            inStr = CalcSergment(ref result, inStr);
        
        return result; 
    }
}
