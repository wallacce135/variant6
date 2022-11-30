using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Variant_6.Classes
{
    class Register
    {
        Memmory[] m_register;
        bool[] m_inputs;
        bool[] m_qt;


        public Register()
        {
            m_register = new Memmory[10];
            m_qt = new bool[10];

            for (int i = 0; i < m_register.Length; i++)
            {
                m_register[i] = new Memmory();
                m_qt[i] = true;
            }

            m_inputs = new bool[20];

        }

        public bool SetValues(bool[] newValues) 
        {
            if(m_inputs.GetLength(0) == newValues.GetLength(0))
            {
                bool[] temp = new bool[2];
                newValues.CopyTo(m_inputs, 0);

                for (int i = 0; i < m_register.GetLength(0); i++)
                {
                    temp[0] = m_inputs[i * 2];
                    temp[1] = m_inputs[i * 2 + 1];
                    if (m_register[i].SetValues(temp) == false) return false;
                    
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool GetOutput(int index, out bool error)
        {
            if(index < m_register.GetLength(0))
            {
                error = false;
                m_register[index].GetResult();
                return m_register[index].GetOutput();
            }
            else
            {
                error = true;
                return false;
            }
        }

        public string Result()
        {
            string result = "";
            bool[] temp = new bool[2];

            for (int i = 0; i < m_register.Length; i++)
            {
                temp[0] = m_inputs[i * 2];
                temp[1] = m_inputs[i * 2 + 1];
                m_register[i].SetValues(temp);
                m_register[i].SetQT(m_qt[i]);
                m_register[i].GetResult();

                result = result + (Convert.ToInt32(m_register[i].GetOutput())).ToString();
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            Register r = obj as Register;

            if (r == null)
            {
                return false;
            }

            if (m_inputs.Length != r.m_inputs.Length) return false;

            for (int i = 0; i < m_inputs.Length; i++)
            {
                if (m_inputs[i] != r.m_inputs[i])
                {
                    return false;
                }
            }

            if (m_register.Length != r.m_inputs.Length) return false;

            for (int i = 0; i < m_register.Length; i++)
            {
                if (!m_register[i].Equals(r.m_inputs[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return m_inputs.GetHashCode() ^ m_register.GetHashCode();
        }

        public static bool operator ==(Register a, Register b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Register a, Register b)
        {
            return !(a == b);
        }

    }
}
