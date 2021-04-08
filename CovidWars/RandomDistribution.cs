using System;

class Rnd {


  // public static void Main (string[] args) {

  //   Console.Clear();

  //   // Generates 20 Random numbers that are normally distributed with a standard deviation of 1 and a mean of 0
  //   for (int i = 0; i < 20; i++){
  //     Console.WriteLine(Dist(0, 1));
  //     Console.WriteLine("");
  //   }
  // }



  // Random number Normally distributed (Gaussian) Reference Website
  // https://gist.github.com/tansey/1444070
  public static double Dist(double mean, double stddev)
  {
    Random random = new Random();

    // The method requires sampling from a uniform random of (0,1]
    // but Random.NextDouble() returns a sample of [0,1).
    // square brackets "[]" means inclusive and parenthesis "()" means exclusive

    // So by putting Random.NextDouble() in form below will return the required sample of (0,1]

    double x1 = 1 - random.NextDouble();
    double x2 = 1 - random.NextDouble();

    // The interesting mathematical part which returns a random value that is randomly distributed
    // The formula uses square roots, logarithms and cosine.
    double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);

    // returns output
    return y1 * stddev + mean;
  }
}