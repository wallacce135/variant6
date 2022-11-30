using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variant_6.Classes
{
    class Element
    {
        public Element() { }

        public Element(string ElementName)
        {
            m_elementName = ElementName;
            m_enterPoints = 1;
            m_outPoints = 1;
        }

        public Element(string elementName, int enterPoints, int outPoints)
        {
            m_elementName = elementName;
            m_enterPoints = enterPoints;
            m_outPoints = outPoints;
        }

        public string m_nameP { get { return m_elementName; } }
        public int m_enterPointsP { get { return m_enterPoints; } 
            set 
            {
                if(value > 0) m_enterPoints = value;
                else m_enterPoints = 0;
            } 
        }

        public int m_outPointsP { get { return m_outPoints; }
            set
            {
                if(value > 0) m_outPoints = value;
                else m_outPoints = 0;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Element temp = (Element)obj;
            return (m_elementName == temp.m_elementName) && (m_enterPoints == temp.m_enterPoints) && (m_outPoints == temp.m_outPoints);
        }

        public override int GetHashCode()
        {
            return m_elementName.GetHashCode() ^ m_enterPoints.GetHashCode() ^ m_outPoints.GetHashCode();
        }


        private readonly string m_elementName;
        int m_enterPoints;
        int m_outPoints;
    }
}
