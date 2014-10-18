using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTT
{
    class XO
    {
        private int row;
        private int col;        

        public XO(int RowNumber, int ColumnNumber)
        {
            row = RowNumber;
            col = ColumnNumber;
        }

        public int Row
        {
            get
            {
                return row;
            }
        }
        public int Column
        {
            get
            {
                return col;
            }

        }
        
    }
    
}
