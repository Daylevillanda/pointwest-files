let myList = document.querySelector('#my-list');

function alertHelloWorld() {
  // alert('Hello world!');
  let li = document.createElement('li');
  li.textContent = Math.random();
  myList.appendChild(li);
}

let clickMeToo = document.querySelector('button#js-on-click');
clickMeToo.addEventListener('click', alertHelloWorld);

let myForm = document.querySelector('#my-form');
myForm.addEventListener('submit', (event) => {
  event.preventDefault();
  let regex = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
  if (document.querySelector('#email').value.match(regex)) {
    alert('Valid!');
  } else {
    alert('Invalid!')
  }
});