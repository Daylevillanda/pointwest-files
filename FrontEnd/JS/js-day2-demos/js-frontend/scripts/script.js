document.getElementById('add-btn').addEventListener('click', event => {
  event.preventDefault();
  let task = document.getElementById('task').value;
  
  let li = document.createElement('li');
  li.innerHTML = task;
  document.getElementById('to-do-list').appendChild(li);
});