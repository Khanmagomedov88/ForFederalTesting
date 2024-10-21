using ForFederalTestingCenter;

var warehouse = Warehouse.Instance;
warehouse.Initialize_M(3);

List<Truck> trucks = new List<Truck>
        {
            new Truck(100),
            new Truck(150),
            new Truck(200),
            new Truck(250),
        };

Product productA = new Product("Продукт A", 10, "Box");
Product productB = new Product("Продукт B", 12, "bag");
Product productC = new Product("Продукт C", 8, "Package");

var factoryA = new Factory(productA, 160);
var factoryB = new Factory(productB, 170);
var factoryC = new Factory(productC, 120);

Task taskA = Task.Run(() => factoryA.MakeProduct());
Task taskB = Task.Run(() => factoryB.MakeProduct());
Task taskC = Task.Run(() => factoryC.MakeProduct());

Task.WaitAll(taskA, taskB, taskC);

TruckManager.TransportationProducts(warehouse, trucks);


Console.ReadLine();




