document.addEventListener("DOMContentLoaded", function () {
    fetchBooks();
});

let currentView = 'table'; // Текущий вид (table/json/plain)
let booksData = []; // Данные книг

function fetchBooks() {
    // Получаем параметры из текущего URL
    const params = new URLSearchParams(window.location.search);

    // Формируем URL для fetch запроса с параметрами
    const url = new URL('/Book/GetFilteredBooksJson', window.location.origin);
    url.search = params.toString();

    fetch(url)
        .then(response => response.json())
        .then(data => {
            booksData = data; // Сохраняем данные для использования в переключении вида
            renderTableView();
        })
        .catch(error => {
            console.error('Error fetching books:', error);
            document.getElementById('message').textContent = 'An error occurred while fetching the books.';
        });
}

function renderTableView() {
    const booksTableBody = document.querySelector('#booksTable tbody');
    const jsonView = document.getElementById('jsonView');
    const plainTextView = document.getElementById('plainTextView');
    booksTableBody.innerHTML = '';
    jsonView.style.display = 'none';
    plainTextView.style.display = 'none';
    document.getElementById('booksTable').style.display = '';

    if (booksData.length === 0) {
        document.getElementById('message').textContent = 'No books match the filter criteria.';
        window.open('https://www.google.com', '_blank');
    } else {
        booksData.forEach(book => {
            const row = document.createElement('tr');
            row.innerHTML = `
                        <td>${book.title}</td>
                        <td>${book.author}</td>
                        <td>${book.style}</td>
                        <td>${book.theme}</td>
                        <td>${book.publishingHouse}</td>
                        <td>${book.pagesCount}</td>
                        <td>${book.cost}</td>
                        <td>${new Date(book.publishedAt).toLocaleDateString()}</td>
                        <td>
                                <form action="/Book/CreateFile" method="post">
                                <input type="hidden" name="title" value="${book.title}" />
                                <input type="hidden" name="author" value="${book.author}" />
                                <input type="hidden" name="style" value="${book.style}" />
                                <input type="hidden" name="theme" value="${book.theme}" />
                                <input type="hidden" name="publishingHouse" value="${book.publishingHouse}" />
                                <input type="hidden" name="pagesCount" value="${book.pagesCount}" />
                                <input type="hidden" name="cost" value="${book.cost}" />
                                <input type="hidden" name="publishedAt" value="${new Date(book.publishedAt).toLocaleDateString()}" />
                                <button type="submit">Download</button>
                            </form>
                        </td>
                    `;
            booksTableBody.appendChild(row);
        });
    }
}

function renderJsonView() {
    const jsonView = document.getElementById('jsonView');
    const plainTextView = document.getElementById('plainTextView');
    document.getElementById('booksTable').style.display = 'none';
    plainTextView.style.display = 'none';
    jsonView.style.display = 'block';
    jsonView.textContent = JSON.stringify(booksData, null, 2);
}

function renderPlainTextView() {
    const plainTextView = document.getElementById('plainTextView');
    const jsonView = document.getElementById('jsonView');
    document.getElementById('booksTable').style.display = 'none';
    jsonView.style.display = 'none';
    plainTextView.style.display = 'block';

    let plainText = booksData.map(book => {
        return `
                Title: ${book.title}
                Author: ${book.author}
                Style: ${book.style}
                Theme: ${book.theme}
                Publishing House: ${book.publishingHouse}
                Pages Count: ${book.pagesCount}
                Cost: ${book.cost}
                Published At: ${new Date(book.publishedAt).toLocaleDateString()}
                `.trim();
    }).join('\n\n');

    plainTextView.textContent = plainText;
}

function toggleView() {
    if (currentView === 'table') {
        renderJsonView();
        currentView = 'json';
    } else if (currentView === 'json') {
        renderPlainTextView();
        currentView = 'plain';
    } else {
        renderTableView();
        currentView = 'table';
    }
}

function goBack() {
    window.history.back();
}