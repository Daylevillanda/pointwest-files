let myHeader = document.querySelector('#my-header');

// set text
// myHeader.textContent = 'Something else';

// set html
myHeader.innerHTML = 'Something <em>else</em>';

let myListItems = document.querySelectorAll('#my-list li');

// add content
let myDiv = document.querySelector('#my-div');
let someParagraph = document.createElement('p');
someParagraph.textContent = 'This was added by JavaScript';
myDiv.appendChild(someParagraph);

// add content 2
let myList = document.querySelector('#my-list');
let names = ['Sana', 'Tzuyu', 'Dahyun'];
for (let name of names) {
  let li = document.createElement('li');
  li.textContent = name;
  myList.appendChild(li);
}

// remove child
let myOtherList = document.querySelector('#my-other-list');
let listItems = document.querySelectorAll('#my-other-list li');
for (let li of listItems) {
  if (li.textContent == 'I should disappear') {
    myOtherList.removeChild(li);
    break;
  }
}

// remove
let removeMe = document.querySelector('#remove-me');
removeMe.remove();

// set attribute via js
let dynamicTextField = document.querySelector('#dynamic-text-field');
dynamicTextField.setAttribute('value', 'Value set by JS');

// set color
let colorChange = document.querySelector('.color-change');
colorChange.style.fontFamily = '"Comic Sans MS", sans-serif';
colorChange.style.color = 'green';

// set class
let message = document.querySelector('.message');
let classes = message.getAttribute('class');
message.setAttribute('class', classes + ' error');