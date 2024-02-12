document.getElementById('registrationForm').addEventListener('submit', handleRegistration);
function handleRegistration(event) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Get form values
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var profileImage = document.getElementById('profileImage').value;

    // Create an object representing the data to be sent to the API
    console.log(username,password,profileImage);
   let data=[];

    fetch('https://localhost:7153/api/User', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => {
        if (response.ok) {
           for(let i=0;i<data.length;i++){
            if(data.username===username.trim()&&data.password===password.trim()){
                location.href='dashboard.html';
            }
           }
        } else {
            throw new Error('Failed to register user');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('Failed to register user');
        // return false;
    });
}