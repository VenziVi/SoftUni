class Bank {
    constructor(bankName){
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer (customer) {
        let currPersonalId = customer.personalId;
        if (this.allCustomers.find(c => c.personalId === currPersonalId)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney (personalId, amount) {
        // let foundCustomer = this.allCustomers.filter(x => x.personalId === personalId);
        // if (foundCustomer.length === 0) {
        //     throw new Error('We have no customer with this ID!');
        // }
        // foundCustomer = foundCustomer[0];

        amount = Number(amount);
        if (!this.allCustomers.find(c => c.personalId === personalId)) {
            throw new Error('We have no customer with this ID!');
        }

        let currCostumer = this.allCustomers.findIndex(c => c.personalId === personalId);

        if (this.allCustomers[currCostumer].totalMoney === undefined) {
            this.allCustomers[currCostumer]['totalMoney'] = 0; 
        }
        this.allCustomers[currCostumer]['totalMoney'] += amount;

        if (this.allCustomers[currCostumer].transactions === undefined) {
            this.allCustomers[currCostumer]['transactions'] = [];
        }

        this.allCustomers[currCostumer].transactions.push(`${this.allCustomers[currCostumer].firstName} ${this.allCustomers[currCostumer].lastName} made deposit of ${amount}$!`);

        let total = this.allCustomers[currCostumer].totalMoney;
        return `${total}$`;
    }

    withdrawMoney (personalId, amount) {
        amount = Number(amount);
        if (!this.allCustomers.find(c => c.personalId === personalId)) {
            throw new Error('We have no customer with this ID!');
        }
        let currCostumer = this.allCustomers.findIndex(c => c.personalId === personalId);

        if (this.allCustomers[currCostumer]['totalMoney'] < amount) {
            throw new Error(`${this.allCustomers[currCostumer].firstName} ${this.allCustomers[currCostumer].lastName} does not have enough money to withdraw that amount!`);
        }
        this.allCustomers[currCostumer]['totalMoney'] -= amount;

        if (this.allCustomers[currCostumer].transactions === undefined) {
            this.allCustomers[currCostumer]['transactions'] = [];
        }

         this.allCustomers[currCostumer].transactions.push(`${this.allCustomers[currCostumer].firstName} ${this.allCustomers[currCostumer].lastName} withdrew ${amount}$!`);

        let total = this.allCustomers[currCostumer].totalMoney;
        return `${total}$`;
    }

    customerInfo (personalId) {
        if (!this.allCustomers.find(c => c.personalId === personalId)) {
            throw new Error('We have no customer with this ID!');
        }

        let currCostumer = this.allCustomers.findIndex(c => c.personalId === personalId);
        let costumer = this.allCustomers[currCostumer];

        let result = `Bank name: ${this._bankName}\n`;
        result += `Customer name: ${costumer.firstName} ${costumer.lastName}\n`;
        result += `Customer ID: ${costumer.personalId}\n`;
        result += `Total Money: ${costumer.totalMoney}$\n`;
        result += 'Transactions:\n';
        for (let index = costumer.transactions.length; index >= 0; index--) {
            if (index === costumer.transactions.length) {

            }else{
                result += `${index + 1}. ${costumer.transactions[index]}\n`;
            }
        }

        return result.trimEnd();
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267}));
console.log(bank.newCustomer({firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

