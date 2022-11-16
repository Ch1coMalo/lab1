using System;
using System.Collections.Generic;
using System.Linq;

namespace Calcul
{
    
    public class Program
    {
            public static void Main()
            {
                Console.WriteLine("Введите выражение:");
                string text = Console.ReadLine();
        }
           
            private string Math(string a, string b, string op)
            {
                double n1 = Convert.ToDouble(a);
                double n2 = Convert.ToDouble(b);    
                
                if (op == "+") 
                    return (n1 + n2).ToString();
                if (op == "-")
                    return (n1 - n2).ToString();
                if (op == "*")
                    return (n1 * n2).ToString();
                if (op == "/")
                {
                    if (n2 != 0)
                    {
                        return (n1 / n2).ToString();
                    }
                    else return "На ноль делить нельзя!";
                }
                return "";
            }   
            private string Calculate(string text)
            {
                var list = new List<string>();
                string s = "";
                
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '+' || text[i] == '-' || text[i] == '*' || text[i] == '/' )
                    {
                        list.Add(s);
                        list.Add(text[i]);
                        s = "";
                    }
                    else
                    { 
                        s += text[i];   
                    }
                }
                list.Add(s);

                for (int i = 0; i < list.Count; i++)
                {     
                    if (list[i].ToString() == "*" || list[i].ToString() == "/" || list[i].ToString() == "+" || list[i].ToString() == "/")
                    {
                        if (i == 0)
                        {
                            return "Операция не может быть в начале выражения";
                        }
                    Math(list[i - 1].ToString(), list[i].ToString(), list[i + 1].ToString());
                    }
                }
            return list[0].ToString();
            }
            
            private string Brackets(string text)
            {
                bool Beg = false;
                bool End = false;
                int Pos1 = -1;
                int Pos2 = -1;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '(')
                    {
                        Beg = true;
                        Pos1 = i;
                    }
                    if (text[i] == ')')
                    {
                        if (Beg == true)
                        {
                            End = true;
                            Pos2 = i;
                            string result = Calculate(text.Substring(Pos1 + 1, Pos2 - Pos1 - 1));
                            Beg = false;
                            End = false;
                            i = 0;
                            Pos1 = -1;
                            Pos2 = -1;
                        }
                    }
                }
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '(')
                    {
                        if (text[i] == '(') Brackets(text);
                    }
                }
                return Calculate(text);
            }
        }
    }

