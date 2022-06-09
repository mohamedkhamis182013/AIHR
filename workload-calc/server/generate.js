//var faker = require('faker');

var database = { products: []};

for (var i = 1; i<= 300; i++) {
  database.products.push({
    id: i,
    name: 'prod' + i,
    description: 'description' + i,
    price: 'price' + i,
    imageUrl: "https://source.unsplash.com/1600x900/?product",
    quantity: 'quantity' + i
  });
}

console.log(JSON.stringify(database));