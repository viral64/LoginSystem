function handleRegistration(event) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Get form values
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    var profileImage = document.getElementById('profileImage').value;

    // Create an object representing the data to be sent to the API
    var formData = {
        username: username,
        passwordHash: password,
        profileImage: profileImage
    };
    console.log(formData);

    fetch('https://localhost:7153/api/User', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
    .then(response => {
        if (response.ok) {
            // window.location.href = 'index.html';
            
        } else {
            throw new Error('Failed to register user');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('Failed to register user');
       
    });
}

// Add an event listener for the form submission
document.getElementById('registrationForm').addEventListener('submit', handleRegistration);
