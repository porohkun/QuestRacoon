using System;
using System.Drawing;

namespace QuestRacoon
{
	/// <summary>
	/// Basic geometry class : easy to replace
	/// Written so as to be generalized
	/// </summary>
	public struct Vector2
    {
        public float X;        
        public float Y;

        private bool _lengthCalculated;
        private float _length;
        public float Length
        {
            get
            {
                if (!_lengthCalculated)
                    _length = (float)Math.Sqrt(X * X + Y * Y);
                return _length;
            }
        }
        
        public Vector2(float x, float y)
		{
			X = x;
            Y = y;
            _length = 0f;
            _lengthCalculated = false;
        }
        
        public Vector2(Point P1, Point P2)
        {
            X = P2.X - P1.X;
            Y = P2.Y - P1.Y;
            _length = 0f;
            _lengthCalculated = false;
        }
        
        #region ѕереназначение операторов

        public static Vector2 operator +(Vector2 v1,Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
		/// ѕроизведение вектора на скал€рное значение.
		/// </summary>
		/// <param name="V">Vector to operate.</param>
		/// <param name="Factor">Factor value.</param>
		/// <returns>New vector resulting from the multiplication.</returns>
        public static Vector2 operator *(Vector2 V, float Factor)
        {
            return new Vector2(V.X * Factor, V.Y * Factor);
        }

		/// <summary>
		/// ƒеление вектора на скал€рное значение.
		/// </summary>
		/// <exception cref="ArgumentException">Divider cannot be 0.</exception>
		/// <param name="V">Vector to operate.</param>
		/// <param name="Divider">Divider value.</param>
		/// <returns>New vector resulting from the division.</returns>
        public static Vector2 operator /(Vector2 V, float Divider)
		{
			if ( Divider==0 ) throw new ArgumentException("Divider cannot be 0 !\n");
            return new Vector2(V.X / Divider, V.Y / Divider);
		}

		/// <summary>
		/// —кал€рное произведение двух векторов
		/// </summary>
		/// <param name="V1">First vector.</param>
		/// <param name="V2">Second vector.</param>
		/// <returns>Value resulting from the scalar product.</returns>
		public static float operator |(Vector2 V1, Vector2 V2)
		{
            return V1.X * V2.X + V1.Y * V2.Y;
		}

		/// <summary>
		/// Returns a point resulting from the translation of a specified point.
		/// </summary>
		/// <param name="P">Point to translate.</param>
		/// <param name="V">Vector to apply for the translation.</param>
		/// <returns>Point resulting from the translation.</returns>
		public static Point operator+(Point P, Vector2 V)
		{
            return new Point((int)(P.X + V.X), (int)(P.Y + V.Y));
		}

        public static implicit operator Point(Vector2 v)
        {
            return new Point((int)v.X, (int)v.Y);
        }

        public static implicit operator Vector2(Point p)
        {
            return new Vector2(p.X, p.Y);
        }

        #endregion

        #region ћетоды

        /// <summary>
		/// Gets the square norm of the vector.
		/// </summary>
        public float SquareNorm
		{
			get
			{
                return this | this;
			}
		}

		/// <summary>
		/// Gets the norm of the vector.
		/// </summary>
		/// <exception cref="InvalidOperationException">Vector's norm cannot be changed if it is 0.</exception>
        public float Norm
		{
			get { return (float)Math.Sqrt(SquareNorm); }
			set
            {
                float N = Norm;
                if (N == 0) { X = 0f;Y = 0f; }//throw new InvalidOperationException("Cannot set norm for a nul vector !");
                if (N != value)
                {
                    float Facteur = value / N;
                    X *= Facteur;
                    Y *= Facteur;
                }
                _lengthCalculated = false;
            }
        }
        
        public Vector2 Normalized()
        {
            return new Vector2(X, Y).Normalize();
        }

        public Vector2 Normalize()
        {
            Norm = 1f;
            return this;
        }

        private const float DegToRad = (float)Math.PI / 180f;

        public Vector2 Rotate(float degrees)
        {
            return RotateRadians(degrees * DegToRad);
        }

        public Vector2 RotateRadians(float radians)
        {
            var ca = (float)Math.Cos(radians);
            var sa = (float)Math.Sin(radians);
            return new Vector2(ca * X - sa * Y, sa * X + ca * Y);
        }

        #endregion

        public override string ToString()
        {
            return string.Format("[{0}:{1}]", X.ToString("0.00"), Y.ToString("0.00"));
        }
    }
}
