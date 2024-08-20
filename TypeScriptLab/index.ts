import { InventoryItem } from "./iInventoryItem";
import { Mountain } from "./iMountain";
import { Product } from "./iProduct";

const mountain:Mountain[] = [
    {name:"Kilimanjaro", height: 19341},
    {name:"Everest", height: 29029},
    {name:"Denali", height: 20310}
]

function findNameOfTallestMountain(mountains:Mountain[]) : string {
    //finds tallest mountain
    //Math.max.apply(Math, mountains.map(x => x.height)).toString()

    mountains.sort(x => x.height).reverse()
    
    return mountains[0].name

}

console.log(findNameOfTallestMountain(mountain))


const products : Product[] = [
    {name: "Smartwatch Pro X", price: 299.99},
    {name: "Eco-Friendly Yoga Mat", price: 45.00},
    {name: "Wireless Noise-Cancelling Headphones", price: 129.95},
    {name: "Organic Coffee Beans - 12oz", price: 18.75},
    {name: "Portable Solar Charger", price: 34.99}
]

//Refactor for reduce function
// function calcAverageProductPrice(products: Product[]) : number {
    
//     let sum : number = 0

//     products.forEach(x => sum += x.price)

//     return sum/products.length
// }

function calcAverageProductPrice( products: Product[]) : number {

    let sum = products.reduce((a, b) => a + (b.price),0)

    return sum
}


console.log(calcAverageProductPrice(products))


const inventory : InventoryItem[] = [
    {product: {name: "motor", price : 10.00}, quantity : 10},
    {product: {name: "sensor", price : 12.50}, quantity : 4},
    {product: {name: "LED", price : 1.00}, quantity : 20}
]

//Refactor for reduce function
// function calcInventoryValue( inventory: InventoryItem[]) : number {

//     let sum : number = 0 

//     inventory.forEach(x => sum =+ x.product.price * x.quantity)

//     return sum
// }

function calcInventoryValue( inventory: InventoryItem[]) : number {
    
    const initial = 0;

    let sum = inventory.reduce<number>((a, b) => a + (b.product.price * b.quantity),initial)

    return sum
}


console.log(calcInventoryValue(inventory))