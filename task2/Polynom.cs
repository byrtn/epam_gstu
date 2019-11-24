﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    /// <summary>
    /// Class for Polynomial and operations
    /// </summary>
    public class Polynom
    {
        int degree;
        int[] coef;
        public Polynom(int []c)
        {           
            coef = c;
            degree = coef.Length;
        }
        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            int[] coef_temp;
            if (p1.degree <= p2.degree)
            {
                coef_temp = new int[p2.degree];
                for (int i=0; i < p2.degree; i++)
                {
                    if (i < p1.degree)
                    {
                        coef_temp[i] = p2.coef[i] + p1.coef[i];
                    }
                    else
                    {
                        coef_temp[i] = p2.coef[i];
                    }
                }
            }
            else
            {
                coef_temp = new int[p1.degree];
                for (int i = 0; i < p1.degree; i++)
                {
                    if (i < p2.degree)
                    {
                        coef_temp[i] = p2.coef[i] + p1.coef[i];
                    }
                    else
                    {
                        coef_temp[i] = p1.coef[i];
                    }
                }
            }
            return new Polynom(coef_temp);
        }
        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            int[] coef_temp;
            if (p1.degree <= p2.degree)
            {
                coef_temp = new int[p2.degree];
                for (int i = 0; i < p2.degree; i++)
                {
                    if (i < p1.degree)
                    {
                        coef_temp[i] = p2.coef[i] - p1.coef[i];
                    }
                    else
                    {
                        coef_temp[i] = p2.coef[i];
                    }
                }
            }
            else
            {
                coef_temp = new int[p1.degree];
                for (int i = 0; i < p1.degree; i++)
                {
                    if (i < p2.degree)
                    {
                        coef_temp[i] = p2.coef[i] - p1.coef[i];
                    }
                    else
                    {
                        coef_temp[i] = p1.coef[i];
                    }
                }
            }
            return new Polynom(coef_temp);
        }
        public static Polynom operator *(Polynom p1, Polynom p2)
        {
            int[] coef_temp = new int[p2.degree + p1.degree - 1];
            if (p1.degree <= p2.degree)
            {
                for (int i = 0; i < p1.degree; i++)
                {
                    for(int k = 0; k < p2.degree; k++)
                    {
                        coef_temp[i + k] = coef_temp[i+k]+p1.coef[i] * p2.coef[k];
                    }
                }
            }
            else
            {
                for (int i = 0; i < p2.degree; i++)
                {
                    for (int k = 0; k < p1.degree; k++)
                    {
                        coef_temp[i + k] = coef_temp[i+k]+p2.coef[i] * p1.coef[k];
                    }
                }
            }
            return new Polynom(coef_temp);
        }
        public static bool operator ==(Polynom p1, Polynom p2)
        {
            if (p1.degree != p2.degree)
            {
                return false;
            }
            else
            {
                for(int i=0;i<p1.degree;i++)
                {
                    if (p1.coef[i] != p2.coef[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        public static bool operator !=(Polynom p1, Polynom p2)
        {
            return !(p1 == p2);
        }
        public override string ToString()
        {
            string pol = Convert.ToString(coef[0]);
            for (int i=1; i<degree; i++)
            {
                pol += ", "+coef[i];
            }
            return pol;
        }
    }
}
