using MarsProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsProject.Models
{
    public class Rover
    {
        int _x;
        int _y;
        int _position;
        Queue<char> _waitindDirections;

        public Rover(int x, int y, char positionLetter)
        {
            if (x > 0 && y > 0 && InputValidator.IsInitialCommpassValid(positionLetter))
            {
                X = x;
                Y = y;
                Position = RoverUtils.ConvertCompassCharToPositon(positionLetter);
                _waitindDirections = new Queue<char>();
            }
            else
                throw new ArgumentException(ErrorMessages.InvalidCompassMessageAndCoordinatsMessage, "compassAndDimension");
        }
        public int X
        {
            get { return _x; }
            set
            {
                if (value >= 0)
                {
                    _x = value;
                }
                else
                    throw new Exception(ErrorMessages.InvalidCoordinatsMessage);
            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value >= 0)
                {
                    _y = value;
                }
                else
                    throw new Exception(ErrorMessages.InvalidCoordinatsMessage);
            }
        }

        public int WaitindDirectionsCount { get { return _waitindDirections.Count; } }
        public int Position
        {

            get { return _position; }
            set
            {
                if (InputValidator.IsCompassDegreeValid(value))
                {
                    _position = value;
                }
                else
                    throw new ArgumentException(ErrorMessages.CompassMessage);
            }
        }

        public char PositionAsCompassLetter
        {
            get
            {
                return RoverUtils.ConvertPositionToCompassLetter(_position);
            }

        }


        public void SetDirections(string directions)
        {
            if (InputValidator.IsDirectiveListValid(directions))
            {
                directions.ToArray().ToList().ForEach(x => _waitindDirections.Enqueue(x));
            }

            else
                throw new ArgumentException(ErrorMessages.CompassMessage);
        }


        public void ApplyDirectivesOnSpecifiedPlateau(Plateau plateau)
        {
            if (this._waitindDirections.Count > 0)
            {
                do
                {
                    var diretive = this._waitindDirections.Dequeue();

                    switch (diretive)
                    {
                        case Constanst.move:
                            ApplyMove(plateau);
                            break;
                        default:
                            ApplyDirecitonDirective(diretive);
                            break;
                    }
                }
                while (this._waitindDirections.Count > 0);
            }
        }


        private void ApplyMove(Plateau plateau)
        {
            int nextX;
            int nextY;

            if (RoverUtils.IsMoveDirectiveAvailable(plateau, this, out nextX, out nextY))
            {
                X = nextX;
                Y = nextY;
            }
        }


        private void ApplyDirecitonDirective( char directive)
        {
            Position = RoverUtils.CalculateDirectionPositionViaUnitCircle(Position, directive);
        }
    }
}
