using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

internal class Program
{
    private static void Main(string[] args)
    {

        using (TextFieldParser Parser = new TextFieldParser("Shapes-49464.txt"))
        {
            Parser.SetDelimiters(new string[] { "," });

            var output_file = "output.csv";

            // We will write line-by-line as we iterate through the input file
            using (StreamWriter writer = new StreamWriter(new FileStream(output_file, FileMode.Create, FileAccess.Write)))
            {
                writer.WriteLine("Id,Area,Perimeter,CentroidX,CentroidY");
                while (!Parser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = Parser.ReadFields();
                    string type = fields[1];

                    // Create an object of that specifc shape type and calculate the geometric properties
                    if (type.Equals("Square"))
                    {
                        Square square = new Square(fields[0], Convert.ToDouble(fields[3]), Convert.ToDouble(fields[5]), Convert.ToDouble(fields[7]), Convert.ToDouble(fields[9]));
                        string first = square.get_ID;
                        string second = Convert.ToString(square.Area);
                        string third = Convert.ToString(square.Perimeter);
                        string fourth = Convert.ToString(square.CentroidX);
                        string fifth = Convert.ToString(square.CentroidY);
                        string csvline = string.Format("{0},{1},{2},{3},{4}", first, second, third, fourth, fifth);
                        writer.WriteLine(csvline);
                    }
                    else if (type.Equals("Circle"))
                    {
                        Circle circle = new Circle(fields[0], Convert.ToDouble(fields[3]), Convert.ToDouble(fields[5]), Convert.ToDouble(fields[7]));
                        string first = circle.get_ID;
                        string second = Convert.ToString(circle.Area);
                        string third = Convert.ToString(circle.Perimeter);
                        string fourth = Convert.ToString(circle.CentroidX);
                        string fifth = Convert.ToString(circle.CentroidY);
                        string csvline = string.Format("{0},{1},{2},{3},{4}", first, second, third, fourth, fifth);
                        writer.WriteLine(csvline);
                    }
                    else if (type.Equals("Equilateral Triangle"))
                    {
                        Triangle triangle = new Triangle(fields[0], Convert.ToDouble(fields[3]), Convert.ToDouble(fields[5]), Convert.ToDouble(fields[7]), Convert.ToDouble(fields[9]));
                        string first = triangle.get_ID;
                        string second = Convert.ToString(triangle.Area);
                        string third = Convert.ToString(triangle.Perimeter);
                        string fourth = Convert.ToString(triangle.CentroidX);
                        string fifth = Convert.ToString(triangle.CentroidY);
                        string csvline = string.Format("{0},{1},{2},{3},{4}", first, second, third, fourth, fifth);
                        writer.WriteLine(csvline);
                    }
                    else if (type.Equals("Ellipse"))
                    {
                        Ellipse ellipse = new Ellipse(fields[0], Convert.ToDouble(fields[3]), Convert.ToDouble(fields[5]), Convert.ToDouble(fields[7]), Convert.ToDouble(fields[9]), Convert.ToDouble(fields[11]));
                        string first = ellipse.get_ID;
                        string second = Convert.ToString(ellipse.Area);
                        string third = Convert.ToString(ellipse.Perimeter);
                        string fourth = Convert.ToString(ellipse.CentroidX);
                        string fifth = Convert.ToString(ellipse.CentroidY);
                        string csvline = string.Format("{0},{1},{2},{3},{4}", first, second, third, fourth, fifth);
                        writer.WriteLine(csvline);
                    }
                    else if (type.Equals("Polygon"))
                    {
                        int size_of_array = (fields.Length / 4);
                        double[] x = new double[size_of_array];
                        double[] y = new double[size_of_array];
                        int j = 0;
                        for (int i = 5; i < fields.Length; i = i + 4)
                        {
                            x[j] = Convert.ToDouble(fields[i - 2]);
                            y[j] = Convert.ToDouble(fields[i]);
                            j++;
                        }

                        Polygon polygon = new Polygon(fields[0], x, y);
                        string first = polygon.get_ID;
                        string second = Convert.ToString(polygon.Area);
                        string third = Convert.ToString(polygon.Perimeter);
                        string fourth = Convert.ToString(polygon.CentroidX);
                        string fifth = Convert.ToString(polygon.CentroidY);
                        string csvline = string.Format("{0},{1},{2},{3},{4}", first, second, third, fourth, fifth);
                        writer.WriteLine(csvline);
                    }
                }

            }
        }
    }
}

public interface Shape
{
    string get_ID { get; }
    double Area { get; }
    double Perimeter { get; }
    double CentroidX { get; }
    double CentroidY { get; }
}

public class Square : Shape
{
    private string id;
    private double center_x;
    private double center_y;
    private double side_length;
    private double orientation;
    public Square(string shape_id, double x, double y, double length, double orient)
    {
        id = shape_id;
        center_x = x;
        center_y = y;
        side_length = length;
        orientation = orient;

    }

    public string get_ID => id;
    public double Area => side_length * side_length;
    public double Perimeter => side_length * 4;

    public double CentroidX => center_x;
    public double CentroidY => center_y;
}

public class Circle : Shape
{
    private string id;
    private double center_x;
    private double center_y;
    private double radius;
    public Circle(string shape_id, double x, double y, double rad)
    {
        id = shape_id;
        center_x = x;
        center_y = y;
        radius = rad;

    }
    public string get_ID => id;
    public double Area => radius * radius * Math.PI;
    public double Perimeter => 2 * radius * Math.PI;
    public double CentroidX => center_x;
    public double CentroidY => center_y;

}

public class Triangle : Shape
{
    private string id;
    private double center_x;
    private double center_y;
    private double side_length;
    private double orientation;
    public Triangle(string shape_id, double x, double y, double length, double orient)
    {
        id = shape_id;
        center_x = x;
        center_y = y;
        side_length = length;
        orientation = orient;

    }
    public string get_ID => id;
    public double Area => side_length * side_length * ((Math.Sqrt(3)) / 4);
    public double Perimeter => side_length * 3;

    public double CentroidX => center_x;
    public double CentroidY => center_y;
}

public class Ellipse : Shape
{
    private string id;
    private double center_x;
    private double center_y;
    private double radius1;
    private double radius2;
    private double orientation;
    public Ellipse(string shape_id, double x, double y, double r1, double r2, double orient)
    {
        id = shape_id;
        center_x = x;
        center_y = y;
        radius1 = r1;
        radius2 = r2;
        orientation = orient;

    }

    public string get_ID => id;
    public double Area => radius1 * radius2 * Math.PI;

    // The perimeter calculation is broken up into several steps for readability sake
    public double Perimeter
    {
        get
        {
            double sub = Math.Pow(radius1 - radius2, 2);
            double add = Math.Pow(radius1 + radius2, 2);
            double div = sub / add;
            double sqroot = Math.Sqrt(-3 * div + 4);
            double denominator = add * (sqroot + 10);
            double last = 3 * (sub / denominator) + 1;
            return Math.PI * (radius1 + radius2) * last;
        }
    }

    public double CentroidX => center_x;
    public double CentroidY => center_y;
}

public class Polygon : Shape
{
    private string id;
    private double []line_x;
    private double []line_y;
    public Polygon(string shape_id, double []x, double []y)
    {
        id = shape_id;
        line_x = x;
        line_y = y;

    }

    public string get_ID => id;

    // Using the shoelace formula, we can calculate the area of a polygon in a single pass
    public double Area
    {
        get
        {
            double sum1 = 0;
            double sum2 = 0;
            for(int i = 0; i < line_x.Length - 1; i++)
            {
                sum1 = sum1 + line_x[i] * line_y[i + 1];
                sum2 = sum2 + line_y[i] * line_x[i + 1];
            }

            return Math.Abs((sum1 - sum2) / 2);
        }
    }

    // Using the distance formula, we can calculate the perimeter
    public double Perimeter
    {
        get
        {
            double perimeter = 0;
            for(int i = 0; i < line_x.Length - 1; i++)
            {
                perimeter = perimeter + Math.Sqrt(Math.Pow(line_x[i + 1] - line_x[i], 2) + Math.Pow(line_y[i + 1] - line_y[i], 2));
            }

            return perimeter;
        }
    }

    // Using the formula for finding the centroid of a polygon, we can find the center coordinates
    public double CentroidX
    {
        get
        {
            double sum = 0;
            for(int i =0; i < line_x.Length - 1; i++)
            {
                sum = sum + ((line_x[i] + line_x[i + 1]) * (line_x[i] * line_y[i + 1] - line_x[i + 1] * line_y[i]));
            }

            return Math.Abs(sum / (6 * Area));
        }
    }
    public double CentroidY
    {
        get
        {
            double sum = 0;
            for (int i = 0; i < line_y.Length - 1; i++)
            {
                sum = sum + ((line_y[i] + line_y[i + 1]) * (line_x[i] * line_y[i + 1] - line_x[i + 1] * line_y[i]));
            }

            return Math.Abs(sum / (6 * Area));
        }
    }
}
