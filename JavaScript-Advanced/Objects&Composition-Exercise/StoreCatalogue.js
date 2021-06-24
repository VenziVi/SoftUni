function orderedCatalogue(array){
    let catalogue = [];
    for (let i = 0; i < array.length; i++) {
        let elements = array[i].split(' : ');
        let product = {
            name: elements[0],
            price: parseFloat(elements[1])
        };
        catalogue.push(product);
    }
    catalogue.sort((a,b) => a.name.localeCompare(b.name));
 
    let currentLetter = '';
    for (const product of catalogue) {
        if (product.name.charAt(0).toUpperCase() === currentLetter){
            console.log(`  ${product.name}: ${product.price}`)
        }else {
            currentLetter = product.name.charAt(0).toUpperCase();
            console.log(currentLetter);
            console.log(`  ${product.name}: ${product.price}`)
        }
    }
}

function solve(arr){
    let productList = {};
    for (const iter of arr) {
        let[name, price] = iter.split(' : ');
        price = Number(price);
        let letter = name[0].toUpperCase();
        
        if (productList[letter] === undefined) {
            productList[letter] = {};
        }

        productList[letter][name] = price;
    }
    //console.log(productList);
    let result = [];
    let sortedList = Object.keys(productList).sort((a,b) => a.localeCompare(b));
    for (const key of sortedList) {
        let products = Object.entries(productList[key])
            .sort((a,b) => a[0].localeCompare(b[0]));
        result.push(key);
        let productAsString = products.map(x => `  ${x[0]}: ${x[1]}`)
        .join('\n');
        result.push(productAsString);
    }
    
    return result.join('\n');
}

console.log(solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']));