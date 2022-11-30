using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_6.Classes
{
    class Combination : Element 
    {
        bool[] m_inputs;

        public Combination(int enterPoints) : base("Комбинационный элемент И-8", enterPoints, 1)
        {
            m_inputs = new bool[enterPoints];
        }

        public bool SetEnterPoints(bool[] value)
        {
            if(m_inputs.GetLength(0) == value.GetLength(0))
            {
                value.CopyTo(m_inputs, 0);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool getValues(int index, out bool error)
        {
            if(index < m_inputs.GetLength(0))
            {
                error = false;
                return m_inputs[index];
            }
            else
            {
                error = true;
                return false;
            }
        }

        public bool Result()
        {
            bool temp = m_inputs[0];
            for (int i = 1; i < m_inputs.GetLength(0); i++)
            {
                temp = temp ^ m_inputs[i];
            }
            return temp;
        }

        public override bool Equals(object obj)
        {
            Combination temp = obj as Combination;
            if(temp == null)
            {
                return false;
            }
            return base.Equals(obj) && (m_inputs == temp.m_inputs);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ m_inputs.GetHashCode();
        }

    }
}
