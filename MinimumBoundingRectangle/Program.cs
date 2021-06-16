using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumBoundingRectangle {
    public class Program {
        static void Main() {
            Helpers.ConsoleHelper.RedirectInputToFile();
            var numberOfCases = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numberOfCases; i++) {
                var numberOfElements = Convert.ToInt32(Console.ReadLine());
                var rectangles = new List<Rectangle>();
                for (int j = 0; j < numberOfElements; j++) {
                    var figure = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    var figureType = figure[0];
                    if (figureType == "p") {
                        var point = new Point {
                            Coordinates = new[] { Convert.ToInt32(figure[1]), Convert.ToInt32(figure[2]) }
                        };
                        rectangles.Add(point.GetBoundingRectangle());
                    }
                    else if (figureType == "c") {
                        var circle = new Circle {
                            Center = new[] { Convert.ToInt32(figure[1]), Convert.ToInt32(figure[2]) },
                            Radius = Convert.ToInt32(figure[3])
                        };
                        rectangles.Add(circle.GetBoundingRectangle());
                    }
                    else {
                        var lineSegment = new LineSegment {
                            Start = new[] { Convert.ToInt32(figure[1]), Convert.ToInt32(figure[2]) },
                            End = new[] { Convert.ToInt32(figure[3]), Convert.ToInt32(figure[4]) }
                        };
                        rectangles.Add(lineSegment.GetBoundingRectangle());
                    }
                }

                Console.ReadLine();
                var minX = rectangles.Min(a => a.LeftDownCorner[0]);
                var minY = rectangles.Min(a => a.LeftDownCorner[1]);
                var maxX = rectangles.Max(a => a.RightUpCorner[0]);
                var maxY = rectangles.Max(a => a.RightUpCorner[1]);
                Console.WriteLine($"{minX} {minY} {maxX} {maxY}");
            }
        }

        public Rectangle MinimumBoundingRectangle(IList<IFigure> figureList) {
            throw new NotImplementedException();
        }
    }

    public interface IFigure {
        Rectangle GetBoundingRectangle();
    }

    public class Rectangle : IFigure {
        public int[] LeftDownCorner { get; set; }
        public int[] RightUpCorner { get; set; }

        public Rectangle GetBoundingRectangle() {
            return this;
        }
    }

    public class Point : IFigure {
        public int[] Coordinates { get; set; }

        public Rectangle GetBoundingRectangle() {
            return new Rectangle {
                LeftDownCorner = Coordinates,
                RightUpCorner = Coordinates
            };
        }
    }

    public class LineSegment : IFigure {
        public int[] Start { get; set; }
        public int[] End { get; set; }

        public Rectangle GetBoundingRectangle() {
            if (Start[1] > End[1] && Start[0] < End[0]) {
                return new Rectangle {
                    LeftDownCorner = new[] { Start[0], End[1] },
                    RightUpCorner = new[] { End[0], Start[1] }
                };
            }

            if (Start[0] > End[0] && Start[1] < End[1]) {
                return new Rectangle {
                    LeftDownCorner = new[] { End[0], Start[1] },
                    RightUpCorner = new[] { Start[0], End[1] }
                };
            }

            if (Start[0] < End[0] && Start[1] <= End[1]) {
                return new Rectangle {
                    LeftDownCorner = new[] { Start[0], Start[1] },
                    RightUpCorner = new[] { End[0], End[1] }
                };
            }

            return new Rectangle {
                LeftDownCorner = new[] { End[0], End[1] },
                RightUpCorner = new[] { Start[0], Start[1] }
            };
        }
    }

    public class Circle : IFigure {
        public int[] Center { get; set; }
        public int Radius { get; set; }

        public Rectangle GetBoundingRectangle() {
            return new Rectangle {
                LeftDownCorner = new[] { Center[0] - Radius, Center[1] - Radius },
                RightUpCorner = new[] { Center[0] + Radius, Center[1] + Radius }
            };
        }
    }
}