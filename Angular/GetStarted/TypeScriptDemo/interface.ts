export interface User { // In curr file dont use I while creating interfaces because the teacher doesnt use it, and also bc Angular doc doesnt use it
    name: string;
    age?: number;
    id: number;
    email: string;
}

let user: User = { name: 'John', id: 1, email: '' };

interface Employees extends User {
    salary: number;
}

let employee: Employees = { name: 'John', id: 1, email: '', salary: 1000 };

export interface Login {
    Login(): User;
}

let [user1, user2, user3]: User[] = [
    { name: 'John', id: 1, email: '' },
    { name: 'Gosho', id: 2, email: '' },
    { name: 'Ivan', id: 3, email: '' }
];

console.log(user1);
console.log(user2);


@Component({})
class Component {
    constructor(public name: string) { }
}