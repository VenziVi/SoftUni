class List{
    constructor(){
        this.arr = [];
        this.size = 0;
    }

    sortElements(arr){
        return arr.sort((a, b) => a - b);
    }

    add(element){
        this.arr.push(element);
        this.arr = this.sortElements(this.arr);
        this.size += 1;
    }

    remove(i){
        if(i < 0 || i >= this.arr.length){
            throw new Error('Invalid index!')
        }
        this.arr.splice(i, 1);
        this.arr = this.sortElements(this.arr);
        this.size -= 1;
    }


    get(i){
        return this.arr[i];
    }

}

let list = new List();
list.add(9);
list.add(2);
list.add(6);
console.log(list.get(1)); 
list.remove(0);
console.log(list.get(1));
console.log(list.size);
