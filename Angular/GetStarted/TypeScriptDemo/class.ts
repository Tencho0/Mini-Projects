class Employee {
    // private id: number;
    #id: number;
    protected name: string;
    address: string;

    get empId(): number {
        return this.#id;
    }

    set empId(id: number) {
        this.#id = id;
    }


    static getEmployeeCount(): number {
        return 50;
    }

    constructor(id: number, name: string, address: string) {
        this.#id = id;
        // this.id = id;
        this.name = name;
        this.address = address;
    }

    getNameWithAddress(): string {
        return `${this.name} stays at ${this.address}`;
    }
}

let john = new Employee(1, 'John', 'Highway 71');

john.empId = 100;
console.log(john.empId);

class Manager extends Employee { // extends == inherit
    constructor(id: number, name: string, address: string) {
        super(id, name, address) // equals to base(...) in C#
    }

    getNameWithAddress(): string {
        return `${this.name} is a manager at ${this.address}`;
    }
}

let address = john.getNameWithAddress();

console.log(john);
console.log(address);

let mike = new Manager(2, 'Mike', 'Bratq Miladinowi');
console.log(mike.getNameWithAddress());
