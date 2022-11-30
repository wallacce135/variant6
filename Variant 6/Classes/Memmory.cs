using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_6.Classes
{
    class Memmory : Element
    {
        bool[] m_inputs;
        bool m_output, // выход
            m_noutput, //инверсный выход
            m_qt; // переменная для хранения данных внутри триггера(памяти)

        public Memmory(): base("Память",2, 1)
        {
            m_inputs = new bool[2];
            m_output = false; 
            m_noutput = false;
        }

        public Memmory(Memmory previous)
        {
            previous.m_inputs.CopyTo(this.m_inputs, 0);
            this.m_output = previous.m_output;
            this.m_noutput = previous.m_noutput;

        }
        /// <summary>
        /// Метод, задающий значения на входах
        /// </summary>
        /// <param name="values"></param>
        /// <returns>true || false</returns>
        public bool SetValues(bool[] values)
        {
            if(values.GetLength(0) == m_inputs.GetLength(0))
            {
                values.CopyTo(this.m_inputs, 0);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Метод для опрашивания входов
        /// </summary>
        /// <param name="index"></param>
        /// <param name="error"></param>
        /// <returns>m_inputs[index](true || false) || false</returns>
        public bool GetValues(int index, out bool error)
        {
            if (index < m_inputs.GetLength(0))
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

        public bool SetQT(bool value)
        {
            return m_qt = value;
        }
        /// <summary>
        /// Метод для вычисления состояния объекта на выходе
        /// </summary>
        /// <returns></returns>
        public bool GetResult()
        {
            if (!m_inputs[1])
            {
                if (m_inputs[0] == m_qt)
                {
                    m_output = m_inputs[0];
                    m_noutput = !m_noutput;
                }
                else
                {
                    m_output = !m_inputs[0];
                    m_noutput = !m_output;
                    m_qt = m_inputs[0];
                }
            }
            else
            {
                m_output = false;
                m_noutput = false;
                m_qt = false;
            }
            return m_output;
        }

        public bool GetOutput()
        {
            return m_output;
        }

        public bool GetNOutput()
        {
            return m_noutput;
        }

        //Переопределение метода проверки эквивалентности
        public override bool Equals(object obj)
        {
            Memmory m = obj as Memmory;
            if(m == null)
            {
                return false;
            }
            if(m_inputs.Length != m.m_inputs.Length) return false;

            for (int i = 0; i < m_inputs.Length; i++)
            {
                if (m_inputs[i] != m.m_inputs[i])
                {
                    return false;
                }    
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ m_noutput.GetHashCode();
        }

        //Переопределение операторов сравнения для работы класса
        public static bool operator ==(Memmory k, Memmory n)
        {
            return (k.m_noutput == n.m_noutput) && (k.m_inputs == n.m_inputs) && (k.m_output == n.m_output);
        }

        public static bool operator !=(Memmory k, Memmory n)
        {
            return !(k == n);
        }

    }
}
