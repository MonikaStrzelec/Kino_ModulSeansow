using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprzedazBiletow
{
    class HallView
    {
        private int x;
        private int y;
        private int dost;
        private int id;

        public void setX(int a)
        {
            this.x = a;
        }

        public void setY(int b)
        {
            this.y = b;
        }

        public void setDost(int d)
        {
            this.dost = d;
        }

        public void setId(int e)
        {
            this.id = e;
        }

        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public int getDost()
        {
            return dost;
        }
        public int getId()
        {
            return id;
        }
    }
}
