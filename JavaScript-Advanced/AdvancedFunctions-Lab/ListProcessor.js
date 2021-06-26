function solve(command){
    let result = [];

    let operateResult = {
        add: function(str){
            result.push(str);
        },
        remove: function(str){
            result = result.filter(x => x != str)
        },
        print: function(){
            console.log(result.join());
        }
    }


    for (let i = 0; i < command.length; i++) {
        let cmd = command[i].split(' ');
        let operation = cmd[0];
        let str = cmd[1];
        
        operateResult[operation](str);
    }
}


solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);