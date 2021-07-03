function ticket(arr, criteria) {

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let ticketArr = [];

    for (let i = 0; i < arr.length; i++) {
        let[destination, price, status] = arr[i].split('|');
        price = Number(price);
        let ticket = new Ticket(destination, price, status);
        ticketArr.push(ticket);
    }

    let sortedArr = sorting(ticketArr, criteria);

    function sorting(arr, criteria){
        let sorted = [];
        if(criteria === 'destination'){
            sorted = arr.sort((a, b) => a.destination.localeCompare(b.destination));
        }else if(criteria === 'price'){
            sorted = arr.sort((a, b) => a.price - b.price);
        }else if(criteria === 'status'){
            sorted = arr.sort((a, b) => a.status.localeCompare(b.status));
        }
        return sorted;
    }

    return sortedArr;
}

ticket(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);

// function ticket(arr, sortingCreterion) {

//     class Ticket {
//         constructor(destination, price, status) {
//             this.destination = destination;
//             this.price = price;
//             this.status = status
//         }
//     }

//     function splitTicket(line) {
//         return line.split('|')
//     }

//     function convertToTicket([destination, price, status]) {
//         return new Ticket(destination, Number(price), status)
//     }

//     const sortMapper = {
//         'destination': (a, b) => a.destination.localeCompare(b.destination),
//         'price': (a, b) => a.price - b.price,
//         'status': (a, b) => a.status.localeCompare(b.status)
//     }

//     return arr
//         .map(splitTicket)
//         .map(convertToTicket)
//         .sort(sortMapper[sortingCreterion])
// }