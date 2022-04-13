let myNumber = 2;

function add(num1: number, num2: number) {
  return num1 + num2;
}

console.log(add(1, 2));

type Person = {
  id: number,
  name: string,
  position: string,
  email?: string
};

const data: Person = JSON.parse('{"id":123,"name":"JM","position":"SE"}');

enum AccountStatus {
  ACTIVE,
  DORMANT,
  CLOSED
}

type Account = {
  accountNumber: string,
  accountName: string,
  status: AccountStatus
};

let myAccount: Account = {
  accountNumber: '1234567890',
  accountName: 'JM Flores Lovelife Mo Sagot Ko Foundation, Inc.',
  status: AccountStatus.ACTIVE
}

class CustomPromise<T> {
  thenFn?: (value: T) => any;

  constructor(resolveFn: (resolve: Function) => any) {
    resolveFn(this.resolve);
  }

  resolve(value: T): void {
    if (this.thenFn) {
      this.thenFn(value);
    }
  }

  then(handler: (value: T) => any): CustomPromise<T> {
    this.thenFn = handler;
    return this;
  }
}

let pramise = new CustomPromise<number>(resolve => {
  setTimeout(() => {
    resolve(123);
  }, 1000);
});
pramise.then(value => console.log(value));