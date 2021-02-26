using System;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;

namespace ConsoleApp4
{
    class Program
    {

        public class Zawodnik
        {
            public float jedynka { get; set; }
            public float trojka { get; set; }

            public float piatka { get; set; }
        }

        public class Przewidywanie
        {
            [ColumnName("Score")]
            public float jedynka { get; set; }

        }
        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext();

            Zawodnik[] zawodnik =
            {
                new Zawodnik (){ piatka=155F, trojka=float.NaN,jedynka=175F },
                new Zawodnik (){ piatka=float.NaN, trojka=180,jedynka=195F },
                new Zawodnik (){ piatka=170F, trojka=180F,jedynka=200F },
                new Zawodnik (){ piatka=float.NaN, trojka=127.5F,jedynka=142.5F },
              //  new Zawodnik (){ piatka=605F, trojka=65F,jedynka=67.5F },//kobieta
                new Zawodnik (){ piatka=147.5F, trojka=160,jedynka=175F },
               // new Zawodnik (){ piatka=62.5F, trojka=67.5F,jedynka=72.5F },//kobieta
                new Zawodnik (){ piatka=140F, trojka=float.NaN,jedynka=175.5F },
                new Zawodnik (){ piatka=float.NaN, trojka=117.5F,jedynka=135F },
                new Zawodnik (){ piatka=220F, trojka=230,jedynka=240.5F },
            //z dane
                new Zawodnik() { piatka = 155F, trojka = 165F, jedynka = 175F },
                new Zawodnik() { piatka = 175F, trojka = 180F, jedynka = 195F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 120F, trojka = 127.5F, jedynka = 142.5F },
                new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 155F, trojka = 165F, jedynka = 175F },
                new Zawodnik() { piatka = 175F, trojka = 180F, jedynka = 195F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 120F, trojka = 127.5F, jedynka = 142.5F },
                new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                 new Zawodnik() { piatka = 155F, trojka = 165F, jedynka = 175F },
                new Zawodnik() { piatka = 175F, trojka = 180F, jedynka = 195F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 120F, trojka = 127.5F, jedynka = 142.5F },
                new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                      new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                              new Zawodnik() { piatka = 155F, trojka = 165F, jedynka = 175F },
                new Zawodnik() { piatka = 175F, trojka = 180F, jedynka = 195F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 120F, trojka = 127.5F, jedynka = 142.5F },
                new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                      new Zawodnik() { piatka = 130F, trojka = 140F, jedynka = 155F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 100F, trojka = 110F, jedynka = 115F },
                new Zawodnik() { piatka = 180F, trojka = 190F, jedynka = 200F },
                new Zawodnik() { piatka = 170F, trojka = 180F, jedynka = 200F },
                new Zawodnik() { piatka = 120F, trojka = 127.5F, jedynka = 135F }};
            Zawodnik[] zawodnik_prawdziwy =
{
                new Zawodnik (){ piatka=155F, trojka=float.NaN,jedynka=175F },
                new Zawodnik (){ piatka=float.NaN, trojka=180,jedynka=195F },
                new Zawodnik (){ piatka=170F, trojka=180F,jedynka=200F },
                new Zawodnik (){ piatka=float.NaN, trojka=127.5F,jedynka=142.5F },
              //  new Zawodnik (){ piatka=605F, trojka=65F,jedynka=67.5F },//kobieta
                new Zawodnik (){ piatka=147.5F, trojka=160,jedynka=175F },
               // new Zawodnik (){ piatka=62.5F, trojka=67.5F,jedynka=72.5F },//kobieta
                new Zawodnik (){ piatka=140F, trojka=float.NaN,jedynka=175.5F },
                new Zawodnik (){ piatka=float.NaN, trojka=117.5F,jedynka=135F },
                new Zawodnik (){ piatka=220F, trojka=230,jedynka=240.5F },
                new Zawodnik (){ piatka=220F, trojka=230,jedynka=240.5F }};

            IDataView dane_treningowe = mlContext.Data.LoadFromEnumerable(zawodnik);
             var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "piatka", "trojka" })
             .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "jedynka", maximumNumberOfIterations: 100));

            var pipeline1 = mlContext.Transforms.Concatenate("Features", new[] { "piatka", "trojka" })
              .Append(mlContext.Regression.Trainers.FastTree(labelColumnName: "jedynka", featureColumnName: "Features"));

            var pipeline2 = mlContext.Transforms.Concatenate("Features", new[] { "piatka", "trojka" })
                .Append(mlContext.Regression.Trainers.FastForest(labelColumnName: "jedynka", featureColumnName: "Features"));

            var model = pipeline.Fit(dane_treningowe);
            var model1 = pipeline.Fit(dane_treningowe);
            var model2 = pipeline.Fit(dane_treningowe);


            var proba = new Zawodnik() { piatka = 120F, trojka = 125F };
            var jedynka_proba = mlContext.Model.CreatePredictionEngine<Zawodnik, Przewidywanie>(model).Predict(proba);
            var jedynka_proba_v2 = mlContext.Model.CreatePredictionEngine<Zawodnik, Przewidywanie>(model1).Predict(proba);
            var jedynka_proba_v3 = mlContext.Model.CreatePredictionEngine<Zawodnik, Przewidywanie>(model2).Predict(proba);


            Console.WriteLine($"Przewidywana jedynka dla 5RM:{proba.piatka},3RM :{proba.trojka} to :{jedynka_proba.jedynka}");
            Console.WriteLine($"Przewidywana jedynka dla 5RM:{proba.piatka},3RM :{proba.trojka} to :{jedynka_proba_v2.jedynka}");
            Console.WriteLine($"Przewidywana jedynka dla 5RM:{proba.piatka},3RM :{proba.trojka} to :{jedynka_proba_v3.jedynka}");



            Zawodnik[] testzawodnik =
            {
                new Zawodnik (){ piatka=155F, trojka=165F,jedynka=175F },
                new Zawodnik (){ piatka=175F, trojka=180F,jedynka=195F },
                new Zawodnik (){ piatka=170F, trojka=180F,jedynka=200F },
                new Zawodnik (){ piatka=120F, trojka=127.5F,jedynka=142.5F },
              //  new Zawodnik (){ piatka=605F, trojka=65F,jedynka=67.5F },//kobieta
                new Zawodnik (){ piatka=147.5F, trojka=160,jedynka=175F },
               // new Zawodnik (){ piatka=62.5F, trojka=67.5F,jedynka=72.5F },//kobieta
                new Zawodnik (){ piatka=140F, trojka=160F,jedynka=175.5F },
                new Zawodnik (){ piatka=112.5F, trojka=117.5F,jedynka=135F },
                new Zawodnik (){ piatka=220F, trojka=230,jedynka=240.5F } };
            var testZawodnikDane = mlContext.Data.LoadFromEnumerable(testzawodnik);
            var testJedynkaDane = model.Transform(testZawodnikDane);
            var metrics = mlContext.Regression.Evaluate(testJedynkaDane, labelColumnName: "jedynka");
            Console.WriteLine($"R^2: {metrics.RSquared:0.##}");
            Console.WriteLine($"RMS error: {metrics.RootMeanSquaredError:0.##}");



            Console.ReadLine();


        }
    }
}
