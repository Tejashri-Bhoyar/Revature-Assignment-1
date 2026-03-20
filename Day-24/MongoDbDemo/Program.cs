// using MongoDB.Driver;

// // Replace with your credentials and server details
// string username = "sa";
// string password = "p@ssw0rd";

// // 1. Create the credential object
// var credentials = MongoCredential.CreateCredential("testdb", username, password);

// // 2. Create the settings object and add credentials
// var settings = new MongoClientSettings
// {
//     Credential = credentials,
//     Server = new MongoServerAddress("localhost", 27017)
// };

// // 3. Create the MongoClient with the settings
// var client = new MongoClient(settings);
// var database = client.GetDatabase("testdb");
// Console.WriteLine("Connection successful!");

// // customer collection

// var collection = database.GetCollection<Customer>("customers");

// collection.InsertOne(new Customer
// {
//     Name = "John Doe",
//     Age = 30,
//     Email = "john.doe@example.com"
// });

// // Read data

// var customers = collection.Find(_ => true).ToList();

// foreach (var customer in customers)
// {
//     Console.WriteLine($"Name: {customer.Name}, Age: {customer.Age}, Email: {customer.Email}");
// }

// class Customer
// {
//     public string Name { get; set; }
//     public int Age { get; set; }
//     public string Email { get; set; }
// }

using MongoDB.Driver;

var connectionString =
"mongodb://admin:temppwd123@localhost:27017/crmdb?authSource=admin&authMechanism=SCRAM-SHA-1";

var client = new MongoClient(connectionString);

var db = client.GetDatabase("crmdb");

Console.WriteLine("Connected to MongoDB");

// get customers collection
var customersCollection = db.GetCollection<Customer>("customers");

// create a new customer
var newCustomer = new Customer
{
    Name = "Sarah Smith",
    Email = "sarah.smith@example.com",
    Age = 20
};

// insert the new customer into the collection
await customersCollection.InsertOneAsync(newCustomer);
Console.WriteLine("Inserted new customer: " + newCustomer.Name);

// read all customers

var customers = await customersCollection.Find(_ => true).ToListAsync();

Console.WriteLine("Customers in database:");
foreach (var customer in customers)
{
    Console.WriteLine($"- {customer.Name} ({customer.Email})");
}

class Customer
{
    // declare Object ID with BSON data annotation
    [MongoDB.Bson.Serialization.Attributes.BsonId]
    [MongoDB.Bson.Serialization.Attributes.BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)
    ]
    public MongoDB.Bson.ObjectId Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public int Age { get; set; }
}