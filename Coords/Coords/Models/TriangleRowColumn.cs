using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coords.Shared.Models
{
    public class TriangleRowColumn
    {
        public string Row { get; set; }
        public int Column { get; set; }

        public override bool Equals(object obj)
        {
            TriangleRowColumn other = obj as TriangleRowColumn;
            if (other == null) return false;
            return other.Row == this.Row && other.Column == Column;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Row + Column;
        }
    }
}
