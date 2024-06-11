// admin.js

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('loginForm').addEventListener('submit', function (e) {
        e.preventDefault(); // prevent the default form submission

        var username = document.getElementById('username').value;
        var password = document.getElementById('password').value;

        fetch('/Admin/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ UserName: username, Password: password })
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                if (data.isUserExist === "true") {
                    document.getElementById('loginMessage').textContent = 'Login successful';
                    document.getElementById("additional_content").style.display = "flex";
                } else {
                    document.getElementById('loginMessage').textContent = 'Invalid username or password';
                }
            })
            .catch(error => {
                console.error('There was a problem with the fetch operation:', error);
                document.getElementById('loginMessage').textContent = 'An error occurred';
            });
    });
});
