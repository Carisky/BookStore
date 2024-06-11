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

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('addBookForm').addEventListener('submit', function (e) {
        e.preventDefault();

        var title = document.getElementById('title').value;
        var author = document.getElementById('author').value;
        var style = document.getElementById('style').value;
        var theme = document.getElementById('theme').value;
        var publishingHouse = document.getElementById('publishingHouse').value;
        var pagesCount = document.getElementById('pagesCount').value;
        var cost = document.getElementById('cost').value;
        var publishedAt = document.getElementById('publishedAt').value;

        var bookData = {
            Title: title,
            Author: author,
            Style: style,
            Theme: theme,
            PublishingHouse: publishingHouse,
            PagesCount: pagesCount,
            Cost: cost,
            PublishedAt: publishedAt
        };

        fetch('/Admin/AddBook', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(bookData)
        })
            .then(response => {
                if (!response.ok) {
                    
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                // Handle response from server if needed
            })
            .catch(error => {
                console.log(bookData)
                console.error('There was a problem with the fetch operation:', error);
            });
    });
});

