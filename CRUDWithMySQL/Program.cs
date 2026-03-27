// Project: CRUD Calibration for MS Backend Module
// Motto: Control the memory, control the machine.
// Target: June 1st WGU MSSWEAIE Start

using CRUDWithMySQL.Models;
using System.Text.Json;

Console.WriteLine("--- System Online: MS Backend Dev Calibration ---");

// --- 1. CREATE (Initial Inbetriebnahme) ---
// We start by injecting a fresh record into the hardware registry.
using (var context = new ApplicationDbContext())
{
    var testProduct = new Product
    {
        Name = "Knect 17-in-1",
        Price = 24.99m
    };

    context.Products.Add(testProduct);
    context.SaveChanges(); // Committing the data to the MySQL disk.
    Console.WriteLine($"[Success]: '{testProduct.Name}' added to database.");
}

// --- 2. READ (Inventory Review) ---
// Checking the full registry to ensure all data points are present.
using (var context = new ApplicationDbContext())
{
    var allProducts = context.Products.ToList(); // Bulk read from the table.
    Console.WriteLine("\n--- Current DB Inventory ---");
    foreach (var product in allProducts)
    {
        Console.WriteLine($"ID: {product.Id}, Name: {product.Name}, Price: ${product.Price}");
    }
}

// --- 3. UPDATE & SERIALIZE (System Calibration) ---
// Targeting ID 1 to recalibrate it to our primary workstation specs.
string jsonOutput = ""; // Holding string for our Serialization export.

using (var db = new ApplicationDbContext())
{
    var productToUpdate = db.Products.Find(1); // O(1) Search via Primary Key.

    if (productToUpdate != null)
    {
        // Modifying the values in the Yoga 9i memory.
        productToUpdate.Price = 1499.99m;
        productToUpdate.Name = "Lenovo Yoga 9i";

        db.SaveChanges(); // Saving the update to the persistent storage.
        Console.WriteLine($"\n[Update Success]: {productToUpdate.Name} calibrated to ${productToUpdate.Price}");

        // Serialization: Turning our C# object into a JSON string for AI/Mobile integration.
        jsonOutput = JsonSerializer.Serialize(productToUpdate);
        Console.WriteLine($"[JSON Export]: {jsonOutput}");
    }
}

// --- 4. VERIFICATION (Spot Check) ---
// Grabbing the first available record to ensure the context is still responsive.
using (var context = new ApplicationDbContext())
{
    var savedProduct = context.Products.FirstOrDefault();
    if (savedProduct != null)
    {
        Console.WriteLine($"\n[Verified]: Active record '{savedProduct.Name}' found in database.");
    }
}

// --- 5. DELETE (Decommissioning) ---
// Final step of the CRUD cycle: Removing the test entry to keep the DB lean.
using (var context = new ApplicationDbContext())
{
    var productToDelete = context.Products.Find(1);
    if (productToDelete != null)
    {
        context.Products.Remove(productToDelete);
        context.SaveChanges();
        Console.WriteLine("\n[Decommissioned]: Record ID 1 has been removed from the system.");
    }
}

// --- 6. DESERIALIZATION (The Round Trip) ---
// Proving we can reconstruct the machine from the JSON "Schematic."
Console.WriteLine("\n--- Testing Deserialization (The Round Trip) ---");
if (!string.IsNullOrEmpty(jsonOutput))
{
    var decodedProduct = JsonSerializer.Deserialize<Product>(jsonOutput);
    if (decodedProduct != null)
    {
        Console.WriteLine($"Object Reconstructed: {decodedProduct.Name} - ${decodedProduct.Price}");
    }
}

// --- 7. SEARCH (Targeted Diagnostic) ---
// Searching the registry for a hard-coded term: "Knect"
using (var context = new ApplicationDbContext())
{
    string searchTerm = "Knesct";
    Console.WriteLine($"\n--- Scanning for term: '{searchTerm}' ---");

    // LINQ: Filter the Products table where the Name contains our term.
    var results = context.Products
        .Where(p => p.Name.Contains(searchTerm))
        .ToList();

    if (results.Any())
    {
        foreach (var item in results)
        {
            Console.WriteLine($"[Match Found]: ID {item.Id} | {item.Name} | ${item.Price}");
        }
    }
    else
    {
        Console.WriteLine($"[No Match]: Term '{searchTerm}' not found in active inventory.");
    }
}
